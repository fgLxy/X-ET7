namespace ET.Client
{
    public static class LoginPanelSystem
    {
        public static void OnRegisterUIEvent(this FGUILoginPanelGetter self)
        {
            self.UI.EnterGame.AddListnerAsync(self.Login);
        }

        private static async ETTask Login(this FGUILoginPanelGetter self)
        {
            var loginCom = self.GetComponent<LoginComponent>();
            loginCom.Account = string.Empty;
            loginCom.Password = string.Empty;
            await loginCom.Login(self.DomainScene());
        }

        public static void OnShow(this FGUILoginPanelGetter self)
        {
        }

        public static void OnHide(this FGUILoginPanelGetter self)
        {
        }

        public static void BeforeUnload(this FGUILoginPanelGetter self)
        {
        }
    }
}