/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.GamePlay
{
    public partial class UIFUIGamePlay : GComponent
    {
        public GList CardList;
        public const string URL = "ui://f3zbsh6rtb4x0";

        public static FUIGamePlay CreateInstance()
        {
            return (FUIGamePlay)UIPackage.CreateObject("GamePlay", "GamePlay");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            CardList = (GList)GetChildAt(0);
        }
    }
}