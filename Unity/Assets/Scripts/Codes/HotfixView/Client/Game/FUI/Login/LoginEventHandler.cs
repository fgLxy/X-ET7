namespace ET.Client
{
    [FriendOf(typeof(PanelCoreData))]
    [FriendOf(typeof(FUIEntity))]
    [FUIEvent(PanelId.LoginPanel, "Login", "LoginPanel")]
    public class LoginEventHandler : IFUIEventHandler
    {
        public void OnInitPanelCoreData(FUIEntity fuiEntity)
        {
            fuiEntity.PanelCoreData.panelType = UIPanelType.Normal;
        }

        public void OnInitComponent(FUIEntity fuiEntity)
        {
            var getter = fuiEntity.AddComponent<FGUILoginPanelGetter>();
            getter.AddComponent<LoginComponent>();
        }

        public void OnRegisterUIEvent(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILoginPanelGetter>().OnRegisterUIEvent();
        }

        public void BeforeUnload(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILoginPanelGetter>().BeforeUnload();
        }

        public void OnHide(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILoginPanelGetter>().OnHide();
        }

        public void OnShow(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILoginPanelGetter>().OnShow();
        }
    }
}