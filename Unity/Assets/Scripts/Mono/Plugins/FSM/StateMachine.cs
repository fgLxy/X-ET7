using System;
using System.Collections.Generic;

namespace ET
{
    public class StateMachine
    {
        private readonly Dictionary<string, AStateNodeHandler> NodeHandlers = new Dictionary<string, AStateNodeHandler>();

        private AStateNodeHandler CurNodeHandler;

        private AStateNodeHandler PreNodeHandler;

        private ETTask DoneTask;

        /// <summary>
        /// 当前运行的节点名称
        /// </summary>
        public string CurrentNodeHandlerName
        {
            get { return this.CurNodeHandler != null ? nameof(this.CurNodeHandler) : string.Empty; }
        }

        /// <summary>
        /// 之前运行的节点名称
        /// </summary>
        public string PreviousNodeHandlerName
        {
            get { return this.PreNodeHandler != null ? nameof(this.PreNodeHandler) : string.Empty; }
        }


        /// <summary>
        /// 启动状态机
        /// </summary>
        /// <param name="this"></param>
        /// <param name="entryNode">入口节点</param>
        public void Awake(ETTask task)
        {
            this.DoneTask = task;
        }

        /// <summary>
        /// 更新状态机
        /// </summary>
        public void Update()
        {
            if (this.CurNodeHandler != null)
                this.CurNodeHandler.OnUpdate(this);
        }

        public void Destroy()
        {
            this.NodeHandlers.Clear();
            this.CurNodeHandler = null;
            this.PreNodeHandler = null;

            this.DoneTask.SetResult();
        }

        /// <summary>
        /// 加入一个节点
        /// </summary>
        public void AddNodeHandler(AStateNodeHandler handler)
        {
            var nodeHandlerName = handler.Name;
            if (this.NodeHandlers.ContainsKey(nodeHandlerName) == false)
            {
                this.NodeHandlers.Add(nodeHandlerName, handler);
            }
            else
            {
                Log.Warning("Node {0} already existed".Fmt(handler.Name));
            }
        }

        public void Run(string entryNodeHandlerName)
        {
            this.CurNodeHandler = this.GetNodeHandler(entryNodeHandlerName);
            this.PreNodeHandler = this.CurNodeHandler;

            if (this.CurNodeHandler != null)
                this.CurNodeHandler.OnEnter(this).Coroutine();
            else
                Log.Error("Not found entry node: {0}".Fmt(entryNodeHandlerName));
        }

        /// <summary>
        /// 转换节点
        /// </summary>
        public void Transition(string nodeHandlerName)
        {
            if (string.IsNullOrEmpty(nodeHandlerName))
                throw new ArgumentNullException();

            AStateNodeHandler nodeHandler = this.GetNodeHandler(nodeHandlerName);
            if (nodeHandler == null)
            {
                Log.Error("not found FsmNode: {0}".Fmt(nodeHandlerName));
                return;
            }

            Log.Info("FSM change {0} to {1}".Fmt(this.CurNodeHandler.Name, nodeHandler.Name));
            this.PreNodeHandler = this.CurNodeHandler;
            this.CurNodeHandler.OnExit(this);
            this.CurNodeHandler = nodeHandler;
            this.CurNodeHandler.OnEnter(this).Coroutine();
        }

        /// <summary>
        /// 返回到之前的节点
        /// </summary>
        public void RevertToPreviousNodeHandler()
        {
            this.Transition(this.PreviousNodeHandlerName);
        }

        private bool IsContains(string nodeName)
        {
            return this.NodeHandlers.ContainsKey(nodeName);
        }

        private AStateNodeHandler GetNodeHandler(string nodeName)
        {
            this.NodeHandlers.TryGetValue(nodeName, out AStateNodeHandler ret);
            return ret;
        }
    }

}