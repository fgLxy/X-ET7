/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUIComboBox1Getter : Entity, IAwake
    {
        private FGUIComboBox1 _ui;

        public FGUIComboBox1 UI => _ui ?? (FGUIComboBox1)this.GetParent<FUIEntity>().GComponent;
    }
}