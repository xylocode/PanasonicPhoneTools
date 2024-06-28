using XyloCode.PanasonicPhoneTools;
using XyloCode.PanasonicPhoneTools.XmlModels;

namespace PanasonicPhoneConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string res;
            var client = new PanasonicClient("xmltester", "aZ9fB4qZ5uI2iS8c", @"http://192.168.0.10:6666");

            //res = client.Trigger(@"http://example.net/Panasonic/KX-TGP600RU/label.xml");
            //Console.WriteLine(res);

            //res = client.Trigger(@"http://example.net/Panasonic/KX-TGP600RU/phones.xml");
            //Console.WriteLine(res);

            var label = new PanasonicPhoneLabel("Hello, World!"); // error 0301 // Error 01A3
            //res = client.Post(label);
            //Console.WriteLine(res);

            var phoneBook = new PanasonicPhoneBook();
            int id = 1;
            phoneBook.Screen.PhoneBook.Items = [
                new (id++, "Emergency 112"){Numbers = [new ("112", PhoneNumType.company)]},
                new (id++, "Panasonic JP"){Numbers = [new ("0081669081551", PhoneNumType.company)]},
                new (id++, "NYC"){Numbers = [new ("0012125551212", PhoneNumType.company)]},
                new (id++, "John Smith"){
                    Ruby = "Susan Constant",
                    Numbers = [
                        new ("555", PhoneNumType.ext),
                        new ("5550123"),
                        new ("0012125550123", PhoneNumType.etc),
                        ]
                    }
                ];
            //res = client.Post(phoneBook);
            //Console.WriteLine(res);

            Console.Beep();
            Console.ReadLine();
        }
    }
}
