using static ET.Server.SessionPlayerComponent;

namespace ET.Server
{
	[ComponentOf(typeof(Session))]
	public class SessionPlayerComponent : Entity, IAwake<long, PlayerState>, IDestroy
	{
		public enum PlayerState
        {
			Idle = 0, //空闲
			Matching, //匹配中
			InGame, //游戏中
			InGameDisconnect, //游戏中断线
        }
		public long PlayerId { get; set; }

		public PlayerState State;
	}
}