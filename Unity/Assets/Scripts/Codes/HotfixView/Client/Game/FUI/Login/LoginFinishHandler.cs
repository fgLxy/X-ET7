using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class LoginFinish_CreateLobbyUI: AEvent<EventType.LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish evt)
        {
            FUIComponent fuiComponent = scene.GetComponent<FUIComponent>();
            fuiComponent.ClosePanel(PanelId.LoginPanel);
            await fuiComponent.ShowPanelAsync(PanelId.LobbyPanel);
        }
    }
}

