using ET.Client;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using YooAsset;

namespace ET
{
    public class ResComponent: Singleton<ResComponent>, ISingletonUpdate
    {
        public enum ReturnCode
        {
            Success,
            ERR_ResourceUpdateVersionError,
            ERR_ResourceUpdateManifestError,
            ERR_ResourceUpdateDownloadError,
        }
        public int ResourceVersion { get; set; }
        public PatchDownloaderOperation Downloader { get; set; }

        public Dictionary<string, AssetOperationHandle> AssetsOperationHandles = new Dictionary<string, AssetOperationHandle>(100);

        public Dictionary<string, SubAssetsOperationHandle> SubAssetsOperationHandles = new Dictionary<string, SubAssetsOperationHandle>();

        public Dictionary<string, SceneOperationHandle> SceneOperationHandles = new Dictionary<string, SceneOperationHandle>();

        public Dictionary<string, RawFileOperation> RawFileOperationHandles = new Dictionary<string, RawFileOperation>(100);

        public Dictionary<OperationHandleBase, Action<float>> HandleProgresses = new Dictionary<OperationHandleBase, Action<float>>();

        public Queue<OperationHandleBase> DoneHandleQueue = new Queue<OperationHandleBase>();

        public async ETTask<bool> InitAsync()
        {
            YooAssets.EPlayMode playMode = Define.IsAsync ? YooAssets.EPlayMode.HostPlayMode : YooAssets.EPlayMode.EditorSimulateMode;

            ILocationServices locationServices = new AddressLocationServices();

            string cdnUrl = YooAssetHelper.GetCdnUrl();

            YooAssets.InitializeParameters parameters = playMode switch
            {
                YooAssets.EPlayMode.EditorSimulateMode => new YooAssets.EditorSimulateModeParameters()
                {
                    LocationServices = locationServices
                },
                YooAssets.EPlayMode.OfflinePlayMode => new YooAssets.OfflinePlayModeParameters()
                {
                    LocationServices = locationServices
                },
                YooAssets.EPlayMode.HostPlayMode => new YooAssets.HostPlayModeParameters()
                {
                    LocationServices = locationServices,
                    DecryptionServices = null,
                    ClearCacheWhenDirty = false,
                    DefaultHostServer = cdnUrl,
                    FallbackHostServer = cdnUrl
                },
                _ => throw new ArgumentOutOfRangeException(nameof(playMode), playMode, null)
            };
            UnityEngine.Debug.Log("Init YooAssets");
            InitializationOperation initOperation = YooAssets.InitializeAsync(parameters);
            await initOperation.GetAwaiter();
            UnityEngine.Debug.Log("Init YooAssets Finish");
            if (initOperation.Status != EOperationStatus.Succeed)
            {
                return false;
            }
            await InitResourceAsync().GetAwaiter();
            UnityEngine.Debug.Log("Update Resouces Finish");
            return true;
        }


        public  ETTask InitResourceAsync()
        {
            ETTask task = ETTask.Create(true);
            var sm = new StateMachine();
            sm.Awake(task);

            sm.AddNodeHandler(new FsmResourceInit());
            sm.AddNodeHandler(new FsmUpdateStaticVersion());
            sm.AddNodeHandler(new FsmUpdateManifest());
            sm.AddNodeHandler(new FsmCreateDownloader());
            sm.AddNodeHandler(new FsmDonwloadWebFiles());
            sm.AddNodeHandler(new FsmPatchDone());

            sm.Run(nameof(FsmResourceInit));

            return task;
        }

        public  void Update()
        {
            foreach (var kv in this.HandleProgresses)
            {
                OperationHandleBase handle = kv.Key;
                Action<float> progress = kv.Value;

                if (!handle.IsValid)
                {
                    continue;
                }

                if (handle.IsDone)
                {
                    this.DoneHandleQueue.Enqueue(handle);
                    progress?.Invoke(1);
                    continue;
                }

                progress?.Invoke(handle.Progress);
            }

            while (this.DoneHandleQueue.Count > 0)
            {
                var handle = this.DoneHandleQueue.Dequeue();
                this.HandleProgresses.Remove(handle);
            }
        }


        #region 热更相关

        public  async ETTask<ReturnCode> UpdateStaticVersionAsync(int timeout = 30)
        {
            var operation = YooAssets.UpdateStaticVersionAsync(timeout);
            await operation.GetAwaiter();

            if (operation.Status != EOperationStatus.Succeed)
            {
                return ReturnCode.ERR_ResourceUpdateVersionError;
            }

            this.ResourceVersion = operation.ResourceVersion;
            return ReturnCode.Success;
        }

        public  async ETTask<ReturnCode> UpdateManifestAsync()
        {
            UpdateManifestOperation operation = YooAssets.UpdateManifestAsync(this.ResourceVersion, 30);
            await operation.GetAwaiter();

            if (operation.Status != EOperationStatus.Succeed)
            {
                return ReturnCode.ERR_ResourceUpdateManifestError;
            }

            return ReturnCode.Success;
        }

        public ReturnCode CreateDownloader()
        {
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            PatchDownloaderOperation downloader = YooAssets.CreatePatchDownloader(downloadingMaxNum, failedTryAgain);
            if (downloader.TotalDownloadCount == 0)
            {
                Log.Info("没有发现需要下载的资源");
            }
            else
            {
                Log.Info("一共发现了{0}个资源需要更新下载。".Fmt(downloader.TotalDownloadCount));
                this.Downloader = downloader;
            }

            return ReturnCode.Success;
        }

        public async ETTask<ReturnCode> DonwloadWebFilesAsync(DownloaderOperation.OnDownloadProgress onDownloadProgress = null, DownloaderOperation.OnDownloadError onDownloadError = null)
        {
            if (this.Downloader == null)
            {
                return ReturnCode.Success;
            }

            // 注册下载回调
            this.Downloader.OnDownloadProgressCallback = onDownloadProgress;
            this.Downloader.OnDownloadErrorCallback = onDownloadError;
            this.Downloader.BeginDownload();
            await this.Downloader.GetAwaiter();

            // 检测下载结果
            if (this.Downloader.Status != EOperationStatus.Succeed)
            {
                return ReturnCode.ERR_ResourceUpdateDownloadError;
            }

            return ReturnCode.Success;
        }

        #endregion

        #region 卸载

        public void UnloadUnusedAssets()
        {
            YooAssets.UnloadUnusedAssets();
        }

        public void ForceUnloadAllAssets()
        {
            YooAssets.ForceUnloadAllAssets();
        }

        public void UnloadAsset(string location)
        {
            this.AssetsOperationHandles.TryGetValue(location, out AssetOperationHandle handle);
            handle.Release();
        }

        #endregion

        #region 异步加载

        public async ETTask<T> LoadAssetAsync<T>(string location) where T : UnityEngine.Object
        {
            this.AssetsOperationHandles.TryGetValue(location, out AssetOperationHandle handle);

            if (handle == null)
            {
                handle = YooAssets.LoadAssetAsync<T>(location);
                this.AssetsOperationHandles[location] = handle;
            }

            await handle;

            return handle.GetAssetObject<T>();
        }

        public async ETTask<UnityEngine.Object> LoadAssetAsync(string location, Type type)
        {
            if (!this.AssetsOperationHandles.TryGetValue(location, out AssetOperationHandle handle))
            {
                handle = YooAssets.LoadAssetAsync(location, type);
                this.AssetsOperationHandles[location] = handle;
            }

            await handle;

            return handle.AssetObject;
        }

        public async ETTask<UnityEngine.SceneManagement.Scene> LoadSceneAsync(string location, Action<float> progressCallback = null, LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool activateOnLoad = true, int priority = 100)
        {
            if (!this.SceneOperationHandles.TryGetValue(location, out SceneOperationHandle handle))
            {
                handle = YooAssets.LoadSceneAsync(location, loadSceneMode, activateOnLoad, priority);
                this.SceneOperationHandles[location] = handle;
            }

            if (progressCallback != null)
            {
                this.HandleProgresses.Add(handle, progressCallback);
            }

            await handle;

            return handle.SceneObject;
        }

        public async ETTask<byte[]> LoadRawFileDataAsync(string location, string copyPath = null)
        {
            RawFileOperation handle = YooAssets.GetRawFileAsync(location, copyPath);
            await handle;
            return handle.LoadFileData();
        }

        public async ETTask<string> LoadRawFileTextAsync(string location, string copyPath)
        {
            RawFileOperation handle = YooAssets.GetRawFileAsync(location, copyPath);
            await handle;
            return handle.LoadFileText();
        }

        #endregion

        #region 同步加载

        public T LoadAsset<T>(string location) where T : UnityEngine.Object
        {
            this.AssetsOperationHandles.TryGetValue(location, out AssetOperationHandle handle);

            if (handle == null)
            {
                handle = YooAssets.LoadAssetSync<T>(location);
                this.AssetsOperationHandles[location] = handle;
            }

            return handle.AssetObject as T;
        }

        public UnityEngine.Object LoadAsset(string location, Type type)
        {
            this.AssetsOperationHandles.TryGetValue(location, out AssetOperationHandle handle);

            if (handle == null)
            {
                handle = YooAssets.LoadAssetSync(location, type);
                this.AssetsOperationHandles[location] = handle;
            }

            return handle.AssetObject;
        }

        #endregion
    }
}
