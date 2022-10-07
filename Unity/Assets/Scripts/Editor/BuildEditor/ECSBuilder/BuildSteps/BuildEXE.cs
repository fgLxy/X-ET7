using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Build;
using Unity.Build.Classic;
using Unity.Build.Classic.Private;
using Unity.Build.Common;
using UnityEditor;
using System.Linq;
using ET;
using UnityEngine;

public class BuildEXE : BuildStepBase
{
    public override Type[] UsedComponents { get; } =
    {
            typeof(SceneList),
            typeof(GeneralSettings),
            typeof(OutputBuildDirectory),
            typeof(RunSettings),
            typeof(ETBuild),
    };

    public override BuildResult Run(BuildContext context)
    {

        var classicSharedData = context.GetValue<ClassicSharedData>();
        var target = classicSharedData.BuildTarget;
        if (target <= 0)
            return context.Failure($"Invalid build target '{target.ToString()}'.");
        if (target != EditorUserBuildSettings.activeBuildTarget)
            return context.Failure($"{nameof(EditorUserBuildSettings.activeBuildTarget)} must be switched before build exe step.");

        var embeddedScenes = context.GetComponentOrDefault<SceneList>().GetScenePathsForBuild();
        if (embeddedScenes.Length == 0)
            return context.Failure("There are no scenes to build.");

        var outputPath = context.GetOutputBuildDirectory();
        if (!Directory.Exists(outputPath))
            Directory.CreateDirectory(outputPath);

        var generalSettings = context.GetComponentOrDefault<GeneralSettings>();
        var methodGetExecutableExtension = typeof(ClassicBuildProfile).GetMethod("GetExecutableExtension", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var locationPathName = Path.Combine(outputPath, generalSettings.ProductName + methodGetExecutableExtension.Invoke(null, new object[] { target }));

        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = embeddedScenes,
            target = target,
            locationPathName = locationPathName,
            targetGroup = UnityEditor.BuildPipeline.GetBuildTargetGroup(target),
        };

        buildPlayerOptions.options = BuildOptions.None;

        foreach (var customizer in classicSharedData.Customizers)
            buildPlayerOptions.options |= customizer.ProvideBuildOptions();

        var extraScriptingDefines = classicSharedData.Customizers.SelectMany(c => c.ProvidePlayerScriptingDefines()).ToArray();
        buildPlayerOptions.extraScriptingDefines = extraScriptingDefines;

        var etConfig = context.GetComponentOrDefault<ETBuild>();
        if (Define.EnableCodes)
        {
            throw new Exception("now in ENABLE_CODES mode, do not need Build!");
        }
        var globalConfig = new GlobalConfig
        {
            CodeMode = etConfig.RunMode,
        };
        //编译Hotfix代码
        BuildAssembliesHelper.BuildModel(etConfig.Optimization, globalConfig);
        BuildAssembliesHelper.BuildHotfix(etConfig.Optimization, globalConfig);

        HybridCLR.Editor.Commands.CompileDllCommand.AfterCompileCallback -= CopyHotfixDLL;
        HybridCLR.Editor.Commands.CompileDllCommand.AfterCompileCallback += CopyHotfixDLL;

        HybridCLR.Editor.Commands.PrebuildCommand.GenerateAll();

        var report = UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);

        CopyAOTS(classicSharedData.BuildTarget);

        context.SetValue(report);
        HybridCLR.Editor.Commands.CompileDllCommand.AfterCompileCallback -= CopyHotfixDLL;

        return report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded ?
            context.Success() : context.Failure("See console log for more details.");
    }

    private void CopyAOTS(BuildTarget buildTarget)
    {
        var aotsPath = HybridCLR.Editor.SettingsUtil.GetAssembliesPostIl2CppStripDir(buildTarget);
        var aotBundlePath = "Assets/Bundles/AOTS";
        if (Directory.Exists(aotBundlePath))
        {
            Directory.Delete(aotBundlePath, true);
        }
        Directory.CreateDirectory(aotBundlePath);

        foreach (var aotName in CodeLoader.AOTS)
        {
            var src = Path.Join(aotsPath, aotName);
            if (!File.Exists(src))
            {
                Debug.LogError($"ab中添加AOT补充元数据dll:{src} 时发生错误,文件不存在。裁剪后的AOT dll在BuildPlayer时才能生成，因此需要你先构建一次游戏App后再打包。");
                continue;
            }
            var target = Path.Join(aotBundlePath, aotName + ".bytes");
            File.Copy(src, target, true);
        }

        AssetDatabase.Refresh();
    }

    public override BuildResult Cleanup(BuildContext context)
    {
        HybridCLR.Editor.Commands.CompileDllCommand.AfterCompileCallback -= CopyHotfixDLL;
        return base.Cleanup(context);
    }

    private void CopyHotfixDLL()
    {
        var hotfixPath = HybridCLR.Editor.SettingsUtil.GetHotFixDllsOutputDirByTarget(EditorUserBuildSettings.activeBuildTarget);
        File.Copy(Path.Join(BuildAssembliesHelper.CodeDir, "Hotfix.dll.bytes"), Path.Join(hotfixPath, "Hotfix.dll"), true);
        File.Copy(Path.Join(BuildAssembliesHelper.CodeDir, "Model.dll.bytes"), Path.Join(hotfixPath, "Model.dll"), true);
    }
}


