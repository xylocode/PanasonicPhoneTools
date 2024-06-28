using System.Collections.Generic;
using System.Xml.Serialization;

namespace XyloCode.PanasonicPhoneTools.XmlModels
{
    public enum PhoneNumType
    {
        ext, company, mobile, home, etc
    }

    [XmlRoot("ppxml", Namespace = @"http://panasonic/sip_phone")]
    public class PanasonicPhoneBook
    {
        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; } = "http://panasonic/sip_phone_directory sip_phone_phonebook.xsd";

        public ElementScreen Screen { get; set; } = new();

        public class ElementScreen
        {
            [XmlAttribute("version")]
            public string Version { get; set; } = "2.0";

            public ElementPhoneBook PhoneBook { get; set; } = new();


            public class ElementPhoneBook
            {
                [XmlAttribute("version")]
                public string Version { get; set; } = "2.0";

                [XmlElement("Personnel")]
                public List<ElementPersonnel> Items { get; set; } = [];



                public class ElementPersonnel
                {
                    public ElementPersonnel() { }
                    public ElementPersonnel(int id, string name)
                    {
                        Id = id;
                        Name = name;
                    }

                    [XmlAttribute("id")]
                    public int Id { get; set; }

                    [XmlElement]
                    public string Name { get; set; }

                    [XmlElement]
                    public string Ruby { get; set; }


                    [XmlArray("PhoneNums")]
                    [XmlArrayItem("PhoneNum")]
                    public List<PhoneNum> Numbers { get; set; } = [];

                    public class PhoneNum
                    {
                        public PhoneNum() { }
                        public PhoneNum(string number, PhoneNumType phoneNumType = PhoneNumType.mobile)
                        {
                            Type = phoneNumType;
                            Number = number;
                        }

                        [XmlAttribute("type")]
                        public PhoneNumType Type { get; set; }

                        [XmlText]
                        public string Number { get; set; } = null!;
                    }
                }

            }

        }
    }
}
