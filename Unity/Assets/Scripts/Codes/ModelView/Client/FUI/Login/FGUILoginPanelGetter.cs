/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUILoginPanelGetter : Entity, IAwake
    {
        private FGUILoginPanel _ui;

        public FGUILoginPanel UI => _ui ?? (FGUILoginPanel)this.GetParent<FUIEntity>().GComponent;
    }
}