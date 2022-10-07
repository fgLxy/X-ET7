/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Lobby;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUILobbyPanel : Entity, IAwake
    {
        private UIFUILobbyPanel _ui;

        public UIFUILobbyPanel UI => _ui ?? (UIFUILobbyPanel)this.GetParent<FUIEntity>().GComponent;
    }
}
}