namespace ET.Client
{
    public static class LobbyPanelSystem
    {
        public static void OnRegisterUIEvent(this FGUILobbyPanelGetter self)
        {
            self.UI.Entry1V1.AddListnerAsync(self.Enter1V1);
        }

        private static async ETTask Enter1V1(this FGUILobbyPanelGetter self)
        {
            var task = ETTask.Create();

            var session = self.DomainScene().GetComponent<SessionComponent>().Session;
            var response = (G2C_EnterGamePlay) await session.Call(new C2G_EnterGamePlay()
            {
                Mode = 1,
            });

            await task;
        }

        public static void OnShow(this FGUILobbyPanelGetter self)
        {
        }

        public static void OnHide(this FGUILobbyPanelGetter self)
        {
        }

        public static void BeforeUnload(this FGUILobbyPanelGetter self)
        {
        }
    }
}