/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.CardCommon;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUIOval : Entity, IAwake
    {
        private UIFUIOval _ui;

        public UIFUIOval UI => _ui ?? (UIFUIOval)this.GetParent<FUIEntity>().GComponent;
    }
}
}