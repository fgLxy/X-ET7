using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class EnterGamePlayHandler : AEvent<EnterGamePlayFinish>
    {
        protected override async ETTask Run(Scene scene, EnterGamePlayFinish evt)
        {
            FUIComponent fuiComponent = scene.GetComponent<FUIComponent>();
            fuiComponent.ClosePanel(PanelId.LobbyPanel);
            await fuiComponent.ShowPanelAsync(PanelId.GamePlayPanel);
        }
    }
}