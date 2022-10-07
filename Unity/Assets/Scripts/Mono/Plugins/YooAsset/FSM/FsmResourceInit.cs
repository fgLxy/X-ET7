namespace ET.Client
{
    public class FsmResourceInit: AStateNodeHandler
    {
        public override async ETTask OnEnter(StateMachine sm)
        {
            sm.Transition(nameof(FsmUpdateStaticVersion));
            await ETTask.CompletedTask;
        }
    }
}