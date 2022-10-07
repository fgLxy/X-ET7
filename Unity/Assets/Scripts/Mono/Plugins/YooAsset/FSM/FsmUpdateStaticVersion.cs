namespace ET.Client
{
    public class FsmUpdateStaticVersion: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            var errorCode = await ResComponent.Instance.UpdateStaticVersionAsync();
            
            if (errorCode != ResComponent.ReturnCode.Success)
            {
                Log.Error("FsmUpdateStaticVersion 出错！{0}".Fmt(errorCode));
                return;
            }
            
            sm.Transition(nameof(FsmUpdateManifest));
        }
    }
}