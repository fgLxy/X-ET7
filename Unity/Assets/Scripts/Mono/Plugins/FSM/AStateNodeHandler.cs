namespace ET
{
    public class AStateNodeHandler
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name => this.GetType().Name;

        public virtual async ETTask OnEnter(StateMachine sm)
        {
            await ETTask.CompletedTask;
        }

        public virtual void OnUpdate(StateMachine sm)
        {
        }

        public virtual void OnExit(StateMachine sm)
        {

        }
    }
}