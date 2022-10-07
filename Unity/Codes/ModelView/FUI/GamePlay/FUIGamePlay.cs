/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.GamePlay;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUIGamePlay : Entity, IAwake
    {
        private UIFUIGamePlay _ui;

        public UIFUIGamePlay UI => _ui ?? (UIFUIGamePlay)this.GetParent<FUIEntity>().GComponent;
    }
}
}