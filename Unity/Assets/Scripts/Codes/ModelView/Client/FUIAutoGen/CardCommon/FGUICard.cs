/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.CardCommon
{
    public partial class FGUICard : GComponent
    {
        public GLoader Background;
        public GImage contentBackground;
        public GLoader Image;
        public GImage titleBackground;
        public FGUIOval cardType;
        public GTextField CardTitle;
        public GTextField CardContent;
        public GLoader CardTypeIcon;
        public const string URL = "ui://fmn4js1pg9qx1s";

        public static FGUICard CreateInstance()
        {
            return (FGUICard)UIPackage.CreateObject("CardCommon", "Card");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Background = (GLoader)GetChildAt(0);
            contentBackground = (GImage)GetChildAt(1);
            Image = (GLoader)GetChildAt(2);
            titleBackground = (GImage)GetChildAt(3);
            cardType = (FGUIOval)GetChildAt(4);
            CardTitle = (GTextField)GetChildAt(5);
            CardContent = (GTextField)GetChildAt(6);
            CardTypeIcon = (GLoader)GetChildAt(7);
        }
    }
}