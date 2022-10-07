/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.CardCommon;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUICard : Entity, IAwake
    {
        private UIFUICard _ui;

        public UIFUICard UI => _ui ?? (UIFUICard)this.GetParent<FUIEntity>().GComponent;
    }
}
}