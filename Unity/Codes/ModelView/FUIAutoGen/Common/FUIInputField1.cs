/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Common
{
    public partial class UIFUIInputField1 : GComponent
    {
        public GTextInput Input;
        public GTextField simpleText;
        public GRichTextField richText;
        public const string URL = "ui://f2boiu4iab9e2";

        public static FUIInputField1 CreateInstance()
        {
            return (FUIInputField1)UIPackage.CreateObject("Common", "InputField1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Input = (GTextInput)GetChildAt(1);
            simpleText = (GTextField)GetChildAt(2);
            richText = (GRichTextField)GetChildAt(3);
        }
    }
}