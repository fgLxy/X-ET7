﻿using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public static class BuildHelper
    {
        private const string relativeDirPrefix = "../Release";

        public static string BuildFolder = "../Release/{0}/StreamingAssets/";
        
        
        [InitializeOnLoadMethod]
        public static void ReGenerateProjectFiles()
        {
            if (Unity.CodeEditor.CodeEditor.CurrentEditor.GetType().Name== "RiderScriptEditor")
            {
                FieldInfo generator = Unity.CodeEditor.CodeEditor.CurrentEditor.GetType().GetField("m_ProjectGeneration", BindingFlags.Static | BindingFlags.NonPublic);
                var syncMethod = generator.FieldType.GetMethod("Sync");
                syncMethod.Invoke(generator.GetValue(Unity.CodeEditor.CodeEditor.CurrentEditor), null);
            }
            else
            {
                Unity.CodeEditor.CodeEditor.CurrentEditor.SyncAll();
            }
            
            Debug.Log("ReGenerateProjectFiles finished.");
        }

        
#if ENABLE_CODES
        [MenuItem("ET/ChangeDefine/Remove ENABLE_CODES")]
        public static void RemoveEnableCodes()
        {
            EnableCodes(false);
        }
#else
        [MenuItem("ET/ChangeDefine/Add ENABLE_CODES")]
        public static void AddEnableCodes()
        {
            EnableCodes(true);
        }
#endif
        private static void EnableCodes(bool enable)
        {
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var ss = defines.Split(';').ToList();
            if (enable)
            {
                if (ss.Contains("ENABLE_CODES"))
                {
                    return;
                }
                ss.Add("ENABLE_CODES");
            }
            else
            {
                if (!ss.Contains("ENABLE_CODES"))
                {
                    return;
                }
                ss.Remove("ENABLE_CODES");
            }
            defines = string.Join(";", ss);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defines);
            AssetDatabase.SaveAssets();
        }
        
#if ENABLE_VIEW
        [MenuItem("ET/ChangeDefine/Remove ENABLE_VIEW")]
        public static void RemoveEnableView()
        {
            EnableView(false);
        }
#else
        [MenuItem("ET/ChangeDefine/Add ENABLE_VIEW")]
        public static void AddEnableView()
        {
            EnableView(true);
        }
#endif
        private static void EnableView(bool enable)
        {
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var ss = defines.Split(';').ToList();
            if (enable)
            {
                if (ss.Contains("ENABLE_VIEW"))
                {
                    return;
                }
                ss.Add("ENABLE_VIEW");
            }
            else
            {
                if (!ss.Contains("ENABLE_VIEW"))
                {
                    return;
                }
                ss.Remove("ENABLE_VIEW");
            }
            
            defines = string.Join(";", ss);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defines);
            AssetDatabase.SaveAssets();
        }

        public static BuildTarget GetBuildTarget(PlatformType type) => type switch
        {
            PlatformType.PC => BuildTarget.StandaloneWindows64,
            PlatformType.Android => BuildTarget.Android,
            PlatformType.IOS => BuildTarget.iOS,
            PlatformType.MacOS => BuildTarget.StandaloneOSX,
            _ => throw new System.Exception(),
        };

        public static void Build(PlatformType type, BuildAssetBundleOptions buildAssetBundleOptions, BuildOptions buildOptions, bool isBuildExe, bool isContainAB, bool clearFolder)
        {
            BuildTarget buildTarget = BuildTarget.StandaloneWindows;
            string programName = "ET";
            string exeName = programName;
            switch (type)
            {
                case PlatformType.PC:
                    buildTarget = BuildTarget.StandaloneWindows64;
                    exeName += ".exe";
                    break;
                case PlatformType.Android:
                    buildTarget = BuildTarget.Android;
                    exeName += ".apk";
                    break;
                case PlatformType.IOS:
                    buildTarget = BuildTarget.iOS;
                    break;
                case PlatformType.MacOS:
                    buildTarget = BuildTarget.StandaloneOSX;
                    break;
            }

            string fold = string.Format(BuildFolder, type);

            if (clearFolder && Directory.Exists(fold))
            {
                Directory.Delete(fold, true);
            }
            Directory.CreateDirectory(fold);

            if (isBuildExe)
            {
                AssetDatabase.Refresh();
                string[] levels = {
                    "Assets/Scenes/Init.unity",
                };
                UnityEngine.Debug.Log("start build exe");
                BuildPipeline.BuildPlayer(levels, $"{relativeDirPrefix}/{exeName}", buildTarget, buildOptions);
                UnityEngine.Debug.Log("finish build exe");
            }


            var aotsPath = HybridCLR.Editor.SettingsUtil.GetAssembliesPostIl2CppStripDir(buildTarget);
            var aotBundlePath = "Assets/Bundles/AOTS";
            if (Directory.Exists(aotBundlePath))
            {
                Directory.Delete(aotBundlePath, true);
            }
            Directory.CreateDirectory(aotBundlePath);
            
            foreach(var aotName in CodeLoader.AOTS)
            {
                var src = Path.Join(aotsPath, aotName);
                if(!File.Exists(src))
                    {
                    Debug.LogError($"ab中添加AOT补充元数据dll:{src} 时发生错误,文件不存在。裁剪后的AOT dll在BuildPlayer时才能生成，因此需要你先构建一次游戏App后再打包。");
                    continue;
                }
                var target = Path.Join(aotBundlePath, aotName + ".bytes");
                File.Copy(src, target, true);
            }

            AssetDatabase.Refresh();

            UnityEngine.Debug.Log("start build assetbundle");
            BuildPipeline.BuildAssetBundles(fold, buildAssetBundleOptions, buildTarget);
            UnityEngine.Debug.Log("finish build assetbundle");
            
            if (isContainAB)
            {
                FileHelper.CleanDirectory("Assets/StreamingAssets/");
                FileHelper.CopyDirectory(fold, "Assets/StreamingAssets/");
            }

            if (!isBuildExe && isContainAB && type == PlatformType.PC)
            {
                string targetPath = Path.Combine(relativeDirPrefix, $"{programName}_Data/StreamingAssets/");
                FileHelper.CleanDirectory(targetPath);
                Debug.Log($"src dir: {fold}    target: {targetPath}");
                FileHelper.CopyDirectory(fold, targetPath);
            }
        }
    }
}
