

namespace ET.Server
{
	public static class SessionPlayerComponentSystem
	{
        public class SsessionPlayerComponentAwakeSystem : AwakeSystem<SessionPlayerComponent, long, SessionPlayerComponent.PlayerState>
        {
            protected override void Awake(SessionPlayerComponent self, long playerId, SessionPlayerComponent.PlayerState state)
            {
				self.PlayerId = playerId;
				self.State = state;
			}
        }

        public class SessionPlayerComponentDestroySystem: DestroySystem<SessionPlayerComponent>
		{
			protected override void Destroy(SessionPlayerComponent self)
			{
				// 发送断线消息
				ActorLocationSenderComponent.Instance?.Send(self.PlayerId, new G2M_SessionDisconnect());
				self.DomainScene().GetComponent<PlayerComponent>()?.Remove(self.PlayerId);
			}
		}

		public static Player GetPlayer(this SessionPlayerComponent self)
		{
			return self.DomainScene().GetComponent<PlayerComponent>().Get(self.PlayerId);
		}
	}
}
