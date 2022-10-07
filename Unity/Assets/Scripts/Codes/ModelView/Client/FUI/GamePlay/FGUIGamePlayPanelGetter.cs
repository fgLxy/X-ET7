/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.GamePlay;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUIGamePlayPanelGetter : Entity, IAwake
    {
        private FGUIGamePlayPanel _ui;

        public FGUIGamePlayPanel UI => _ui ?? (FGUIGamePlayPanel)this.GetParent<FUIEntity>().GComponent;
    }
}