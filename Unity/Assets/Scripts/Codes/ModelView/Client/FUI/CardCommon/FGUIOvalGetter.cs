/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using ET.CardCommon;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    public class FGUIOvalGetter : Entity, IAwake
    {
        private FGUIOval _ui;

        public FGUIOval UI => _ui ?? (FGUIOval)this.GetParent<FUIEntity>().GComponent;
    }
}