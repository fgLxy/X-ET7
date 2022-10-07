namespace ET.Server
{
    public static class RoomSystem
    {
        [ObjectSystem]
        public class RoomAwakeSystem : AwakeSystem<Room, uint>
        {
            protected override void Awake(Room self, uint gameMode)
            {
                self.gameMode = gameMode;
                self.waitingFlag = true;
            }
        }

        public static bool IsPlaying(this Room self)
        {
            return !self.waitingFlag;
        }

        public static bool CanStartGame(this Room self)
        {
            return false;
        }

        public static void JoinRoom(this Room self, Player player)
        {
            self.idPlayers.Add(player.Id);
            var message = new G2C_PlayerJoinRoomNotify
            {
                PlayerId = player.Id,
                UnitId = player.UnitId,
            };
            var players = self.DomainScene().GetComponent<PlayerComponent>();
            foreach(var id in self.idPlayers)
            {
                ActorMessageSenderComponent.Instance.Send(players.Get(id).UnitId, message);
            }
        }

        public static async ETTask StartGame(this Room self)
        {
            if (!self.CanStartGame())
            {
                return;
            }
            var message = new G2C_GameStartNotify
            {

            };
            var players = self.DomainScene().GetComponent<PlayerComponent>();
            foreach (var id in self.idPlayers)
            {
                ActorMessageSenderComponent.Instance.Send(players.Get(id).UnitId, message);
            }
        }
    }
}