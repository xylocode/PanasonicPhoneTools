using System.Collections.Generic;
using System.Xml.Serialization;

namespace XyloCode.PanasonicPhoneTools
{
    [XmlRoot("ppxml", Namespace = "http://panasonic/sip_screen")]
    public class PanasonicPhoneLabel
    {
        public PanasonicPhoneLabel() { }
        public PanasonicPhoneLabel(string text)
        {
            Screen = new();
            var label = new ElementScreen.ElementLabel(text);
            Screen.Components.Add(label);
        }

        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; } = "http://panasonic/sip_screen sip_screen.xsd";

        [XmlElement]
        public ElementScreen Screen { get; set; } = new();


        public class ElementScreen
        {

            [XmlAttribute("version")]
            public string Version { get; set; } = "2.0";

            [XmlArray("Components")]
            [XmlArrayItem("Label", typeof(ElementLabel))]
            public List<object> Components { get; set; } = [];

            public class ElementLabel
            {
                public enum TextAlignmentType { Left, Center, Right }
                public ElementLabel() { }
                public ElementLabel(string text)
                {
                    Name = "Label1";
                    Text = text;
                    Line = 3;
                    TextAlignment = TextAlignmentType.Center;
                }

                [XmlAttribute("area")]
                public string Area { get; set; } = "Phone";

                [XmlAttribute("name")]
                public string Name { get; set; }

                [XmlAttribute("line")]
                public int Line { get; set; }

                [XmlAttribute("text")]
                public string Text { get; set; }

                [XmlAttribute("textAlignment")]
                public TextAlignmentType TextAlignment { get; set; }

                [XmlAttribute("showDateTime")]
                public bool ShowDateTime { get; set; } = false;

                [XmlAttribute("refreshDateTime")]
                public int RefreshDateTime { get; set; } = 0;
            }
        }
    }
}
