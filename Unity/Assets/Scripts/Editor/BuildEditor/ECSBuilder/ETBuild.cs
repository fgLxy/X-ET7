using ET;
using System;
using System.Collections.Generic;
using Unity.Build;
using Unity.Properties;
using UnityEditor;
using UnityEditor.Compilation;
using YooAsset.Editor;

public class ETBuild : IBuildPipelineComponent
{
    public enum EXERunMode
    {
        Client,
        Server,
        ClientServer,
    }

    /// <summary>
    /// 可执行文件运行模式
    /// </summary>
    public CodeMode RunMode;
    /// <summary>
    /// 构建方式
    /// </summary>
    public EBuildMode Mode;
    /// <summary>
    /// 是否开启YooAssets寻址
    /// </summary>
    public bool EnableAddressable;
    /// <summary>
    /// 首包标签
    /// </summary>
    public string MainPackageBuildTags;
    /// <summary>
    /// 资源压缩模式
    /// </summary>
    public ECompressOption CompressOption;
    /// <summary>
    /// 名字规格
    /// </summary>
    public EOutputNameStyle OutputNameStyle;
    /// <summary>
    /// 资源版本号
    /// </summary>
    public int ResourceVersion;

    public CodeOptimization Optimization;
    /// <summary>
    /// 构建模式
    /// </summary>
    [CreateProperty]
    public Unity.Build.BuildType Configuration { get; set; } = Unity.Build.BuildType.Develop;
    /// <summary>
    /// AB资源打包目录
    /// </summary>
    public string AssetBundleOutputPath;

    private ETBuildPipeline _pipeline = new ETBuildPipeline();
    public BuildPipelineBase Pipeline { get => _pipeline; set => throw new System.NotImplementedException(); }
    [CreateProperty]
    public Platform Platform { 
    
        get
        {
            BuildTarget buildTarget;
            if (_pipeline.Platform != null && Enum.TryParse(_pipeline.Platform.Name, out buildTarget))
            {
                return _pipeline.Platform;
            }
            buildTarget = UnityEditor.EditorUserBuildSettings.activeBuildTarget;
            _pipeline.SetPlatform(buildTarget.GetPlatform());
            return _pipeline.Platform;
        }
        set
        {
            BuildTarget buildTarget;
            if (Enum.TryParse(value.Name, out buildTarget))
            {
                _pipeline.SetPlatform(value);
            }
        }
    }

    internal IEncryptionServices CreateEncryptionServicesInstance()
    {
        throw new NotImplementedException();
    }

    public int SortingIndex => throw new System.NotImplementedException();


    public bool SetupEnvironment()
    {
        throw new System.NotImplementedException();
    }
}