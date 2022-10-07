/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Login
{
    public partial class FGUILoginPanel : GComponent
    {
        public GImage background;
        public GButton EnterGame;
        public const string URL = "ui://rgfb0w498omm0";

        public static FGUILoginPanel CreateInstance()
        {
            return (FGUILoginPanel)UIPackage.CreateObject("Login", "LoginPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            background = (GImage)GetChildAt(0);
            EnterGame = (GButton)GetChildAt(1);
        }
    }
}