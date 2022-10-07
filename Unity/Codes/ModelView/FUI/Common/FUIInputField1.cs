/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Common;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FUIInputField1 : Entity, IAwake
    {
        private UIFUIInputField1 _ui;

        public UIFUIInputField1 UI => _ui ?? (UIFUIInputField1)this.GetParent<FUIEntity>().GComponent;
    }
}
}