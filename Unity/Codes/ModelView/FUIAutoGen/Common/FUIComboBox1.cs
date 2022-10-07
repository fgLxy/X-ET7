/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Common
{
    public partial class UIFUIComboBox1 : GComboBox
    {
        public GLoader TestLoader;
        public const string URL = "ui://f2boiu4iab9ej";

        public static FUIComboBox1 CreateInstance()
        {
            return (FUIComboBox1)UIPackage.CreateObject("Common", "ComboBox1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            TestLoader = (GLoader)GetChildAt(4);
        }
    }
}