/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Lobby;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUILobbyPanelGetter : Entity, IAwake
    {
        private FGUILobbyPanel _ui;

        public FGUILobbyPanel UI => _ui ?? (FGUILobbyPanel)this.GetParent<FUIEntity>().GComponent;
    }
}