using static ET.ResComponent;

namespace ET.Client
{
    public class FsmCreateDownloader: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            var errorCode = ResComponent.Instance.CreateDownloader();
            
            if (errorCode != ReturnCode.Success)
            {
                Log.Error("ResourceComponent.FsmCreateDownloader 出错！{0}".Fmt(errorCode));
                return;
            }
            
            if (ResComponent.Instance.Downloader != null)
            {
                Log.Info("Count: {0}, Bytes: {1}", ResComponent.Instance.Downloader.TotalDownloadCount, ResComponent.Instance.Downloader.TotalDownloadBytes);
                sm.Transition(nameof(FsmDonwloadWebFiles));
            }
            else
            {
                sm.Transition(nameof(FsmPatchDone));
            }
            
            await ETTask.CompletedTask;
        }
    }
}