using Unity.Build;
using Unity.Build.Classic.Private;
public class ETBuildPipeline : ClassicNonIncrementalPipelineBase
{
    private Platform _currentPlatform;
    public override Platform Platform { get => _currentPlatform; }

    public void SetPlatform(Platform platform)
    {
        _currentPlatform = platform;
    }

    private BuildStepCollection _steps;
    public override BuildStepCollection BuildSteps { get => _steps; }
    public ETBuildPipeline()
    {
        var asm = typeof(ClassicNonIncrementalPipelineBase).Assembly;
        _steps = new[]
        {
                asm.GetType("Unity.Build.Classic.Private.SaveScenesAndAssetsStep"),
                asm.GetType("Unity.Build.Classic.Private.ApplyUnitySettingsStep"),
                asm.GetType("Unity.Build.Classic.Private.CopyAdditionallyProvidedFilesStepBeforeBuild"),
                typeof(BuildEXE),
                typeof(BuildAssetBundles),
        };
    }

    protected override RunResult OnRun(RunContext context)
    {
        throw new System.NotImplementedException();
    }
}