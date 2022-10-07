using System;


namespace ET.Server
{
	[MessageHandler(SceneType.Gate)]
	public class C2G_EnterGamePlayHandler : AMRpcHandler<C2G_EnterGamePlay, G2C_EnterGamePlay>
	{
		protected override async ETTask Run(Session session, C2G_EnterGamePlay request, G2C_EnterGamePlay response, Action reply)
		{
			var sessionInfo = session.GetComponent<SessionPlayerComponent>();
			if (sessionInfo.State != SessionPlayerComponent.PlayerState.Idle)
            {
				//TODO 不在Idle状态的玩家是不能重新开启匹配的
				return;
			}
			var player = sessionInfo.GetPlayer();
			sessionInfo.State = SessionPlayerComponent.PlayerState.Matching;

			var roomManager = session.DomainScene().GetComponent<RoomComponent>();
			var room = roomManager.SearchWatingRoomByGameMode(request.Mode);
			if (room == null)
            {
				room = roomManager.AddChild<Room, uint>(request.Mode);
			}
			room.JoinRoom(player);
			if (room.CanStartGame())
            {
				await room.StartGame();
            }

			/*
			// 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
			GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
			gateMapComponent.Scene = await SceneFactory.CreateServerScene(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), gateMapComponent.DomainZone(), "GateMap", SceneType.Map);

			Scene scene = gateMapComponent.Scene;
			
			// 这里可以从DB中加载Unit
			Unit unit = Server.UnitFactory.Create(scene, player.Id, UnitType.Player);
			unit.AddComponent<UnitGateComponent, long>(session.InstanceId);
			
			StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map1");
			response.MyId = player.Id;
			*/
			reply();
			
			// 开始传送
			//await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);
			
		}
    }
}