/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUIInputField1Getter : Entity, IAwake
    {
        private FGUIInputField1 _ui;

        public FGUIInputField1 UI => _ui ?? (FGUIInputField1)this.GetParent<FUIEntity>().GComponent;
    }
}