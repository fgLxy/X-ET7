/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.CardCommon;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUICardGetter : Entity, IAwake
    {
        private FGUICard _ui;

        public FGUICard UI => _ui ?? (FGUICard)this.GetParent<FUIEntity>().GComponent;
    }
}