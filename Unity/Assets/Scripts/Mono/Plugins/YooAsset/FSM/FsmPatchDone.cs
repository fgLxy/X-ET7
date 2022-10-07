namespace ET.Client
{
    public class FsmPatchDone: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            sm.Destroy();
            await ETTask.CompletedTask;
        }
    }
}