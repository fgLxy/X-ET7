/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Lobby
{
    public partial class UIFUILobbyPanel : GComponent
    {
        public GImage background;
        public GButton Entry1V1;
        public const string URL = "ui://ti3ka994t52l0";

        public static FUILobbyPanel CreateInstance()
        {
            return (FUILobbyPanel)UIPackage.CreateObject("Lobby", "LobbyPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            background = (GImage)GetChildAt(0);
            Entry1V1 = (GButton)GetChildAt(1);
        }
    }
}