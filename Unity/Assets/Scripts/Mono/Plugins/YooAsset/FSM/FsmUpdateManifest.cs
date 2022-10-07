namespace ET.Client
{
    public class FsmUpdateManifest: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            var errorCode = await ResComponent.Instance.UpdateManifestAsync();
            
            if (errorCode != ResComponent.ReturnCode.Success)
            {
                Log.Error("ResourceComponent.UpdateManifest 出错！{0}".Fmt(errorCode));
                return;
            }
            
            sm.Transition(nameof(FsmCreateDownloader));
        }
    }
}