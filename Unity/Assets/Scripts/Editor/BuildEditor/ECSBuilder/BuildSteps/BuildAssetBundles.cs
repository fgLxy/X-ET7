using System;
using Unity.Build;
using Unity.Build.Classic.Private;
using Unity.Build.Common;
using UnityEditor;
using YooAsset.Editor;
using BuildResult = Unity.Build.BuildResult;

public class BuildAssetBundles : BuildStepBase
{
	public override Type[] UsedComponents { get; } =
	{
			typeof(GeneralSettings),
			typeof(OutputBuildDirectory),
			typeof(RunSettings),
			typeof(ETBuild),
	};

	public override BuildResult Run(Unity.Build.BuildContext context)
    {
		var shared = context.GetValue<ClassicSharedData>();
		var generalSettings = context.GetComponentOrDefault<GeneralSettings>();
		var outputBuildDirectory = context.GetComponentOrDefault<OutputBuildDirectory>();
		var runSettings = context.GetComponentOrDefault<RunSettings>();
		var etConfig = context.GetComponentOrDefault<ETBuild>();

		string defaultOutputRoot = AssetBundleBuilderHelper.GetDefaultOutputRoot();
		BuildParameters buildParameters = new BuildParameters();
		buildParameters.OutputRoot = string.IsNullOrEmpty(etConfig.AssetBundleOutputPath) ? defaultOutputRoot : etConfig.AssetBundleOutputPath;
		buildParameters.BuildTarget = shared.BuildTarget;
		buildParameters.BuildPipeline = EBuildPipeline.ScriptableBuildPipeline;
		buildParameters.BuildMode = etConfig.Mode;
		buildParameters.BuildVersion = etConfig.ResourceVersion;
		buildParameters.BuildinTags = etConfig.MainPackageBuildTags;
		buildParameters.VerifyBuildingResult = true;
		buildParameters.EnableAddressable = etConfig.EnableAddressable;
		buildParameters.CopyBuildinTagFiles = etConfig.Mode == EBuildMode.ForceRebuild;
		buildParameters.CompressOption = etConfig.CompressOption;
		buildParameters.OutputNameStyle = etConfig.OutputNameStyle;

		if (AssetBundleBuilderSettingData.Setting.BuildPipeline == EBuildPipeline.ScriptableBuildPipeline)
		{
			buildParameters.SBPParameters = new BuildParameters.SBPBuildParameters();
			buildParameters.SBPParameters.WriteLinkXML = true;
		}

		var builder = new AssetBundleBuilder();
		var buildResult = builder.Run(buildParameters);
		if (buildResult.Success)
		{
			EditorUtility.RevealInFinder($"{buildParameters.OutputRoot}/{buildParameters.BuildTarget}/{buildParameters.BuildVersion}");
		}

		return context.Success();
	}
}

