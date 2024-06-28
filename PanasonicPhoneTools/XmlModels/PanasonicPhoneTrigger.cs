using System.Xml.Serialization;

namespace XyloCode.PanasonicPhoneTools.XmlModels
{
    [XmlRoot("ppxml", Namespace = "http://panasonic/sip_menu")]
    public class PanasonicPhoneTrigger
    {
        public PanasonicPhoneTrigger() { }
        public PanasonicPhoneTrigger(string url)
        {
            Trigger = new()
            {
                Source = url,
            };
        }

        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; } = "http://panasonic/sip_menu sip_menu.xsd";


        [XmlElement]
        public ElementTrigger Trigger { get; set; }

        public class ElementTrigger
        {
            [XmlAttribute("version")]
            public string Version { get; set; } = "2.0";

            [XmlElement]
            public string Source { get; set; }
        }
    }
}
