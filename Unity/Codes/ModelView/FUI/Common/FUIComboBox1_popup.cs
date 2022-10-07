/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUIComboBox1_popup : Entity, IAwake
    {
        private UIFUIComboBox1_popup _ui;

        public UIFUIComboBox1_popup UI => _ui ?? (UIFUIComboBox1_popup)this.GetParent<FUIEntity>().GComponent;
    }
}
}