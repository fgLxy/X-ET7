/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUILoginPanel : Entity, IAwake
    {
        private UIFUILoginPanel _ui;

        public UIFUILoginPanel UI => _ui ?? (UIFUILoginPanel)this.GetParent<FUIEntity>().GComponent;
    }
}
}