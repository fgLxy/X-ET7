namespace ET.Client
{
    public class FsmDonwloadWebFiles: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            var errorCode = await ResComponent.Instance.DonwloadWebFilesAsync(OnDownloadProgress, OnDownloadError);
            
            if (errorCode != ResComponent.ReturnCode.Success)
            {
                Log.Error("ResourceComponent.FsmDonwloadWebFiles 出错！{0}".Fmt(errorCode));
                return;
            }

            sm.Transition(nameof(FsmPatchDone));
        }
        
        private static void OnDownloadError(string fileName, string error)
        {
            
        }

        private static void OnDownloadProgress(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes, long currentDownloadBytes)
        {
            
        }
    }
}