/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Common
{
    public partial class UIFUIComboBox1_popup : GComponent
    {
        public GList list;
        public const string URL = "ui://f2boiu4iab9ei";

        public static FUIComboBox1_popup CreateInstance()
        {
            return (FUIComboBox1_popup)UIPackage.CreateObject("Common", "ComboBox1_popup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChildAt(1);
        }
    }
}