/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUIComboBox1_popupGetter : Entity, IAwake
    {
        private FGUIComboBox1_popup _ui;

        public FGUIComboBox1_popup UI => _ui ?? (FGUIComboBox1_popup)this.GetParent<FUIEntity>().GComponent;
    }
}