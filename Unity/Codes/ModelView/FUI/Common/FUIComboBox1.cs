/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUIComboBox1 : Entity, IAwake
    {
        private UIFUIComboBox1 _ui;

        public UIFUIComboBox1 UI => _ui ?? (UIFUIComboBox1)this.GetParent<FUIEntity>().GComponent;
    }
}
}