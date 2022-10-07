namespace ET.Server
{
    [FriendOf(typeof(Player))]
    public static class PlayerSystem
    {
        [ObjectSystem]
        public class PlayerAwakeSystem : AwakeSystem<Player, string, long>
        {
            protected override void Awake(Player self, string account, long unitId)
            {
                self.Account = account;
                self.UnitId = unitId;
            }
        }
    }
}