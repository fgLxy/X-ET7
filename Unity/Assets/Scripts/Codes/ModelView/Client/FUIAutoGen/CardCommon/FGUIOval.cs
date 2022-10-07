/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.CardCommon
{
    public partial class FGUIOval : GComponent
    {
        public GLoader background;
        public GLoader oval;
        public const string URL = "ui://fmn4js1pg9qx1t";

        public static FGUIOval CreateInstance()
        {
            return (FGUIOval)UIPackage.CreateObject("CardCommon", "Oval");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            background = (GLoader)GetChildAt(0);
            oval = (GLoader)GetChildAt(1);
        }
    }
}