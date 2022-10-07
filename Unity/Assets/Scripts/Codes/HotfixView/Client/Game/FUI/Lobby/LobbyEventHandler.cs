namespace ET.Client
{
    [FUIEvent(PanelId.LobbyPanel, "Lobby", "LobbyPanel")]
    public class LobbyEventHandler : IFUIEventHandler
    {
        public void OnInitPanelCoreData(FUIEntity fuiEntity)
        {
            fuiEntity.PanelCoreData.panelType = UIPanelType.Normal;
        }

        public void OnInitComponent(FUIEntity fuiEntity)
        {
            fuiEntity.AddComponent<FGUILobbyPanelGetter>();
        }

        public void OnRegisterUIEvent(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILobbyPanelGetter>().OnRegisterUIEvent();
        }

        public void OnShow(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILobbyPanelGetter>().OnShow();
        }

        public void OnHide(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILobbyPanelGetter>().OnHide();
        }

        public void BeforeUnload(FUIEntity fuiEntity)
        {
            fuiEntity.GetComponent<FGUILobbyPanelGetter>().BeforeUnload();
        }

        
    }
}