# PanasonicPhoneTools

Unofficial client library for accessing Panasonic XML services on TGP600, HDV100/130/230/330/430 SIP phones.

We were unable to get any XML services to work on the KX-TGP600 SIP phone. The project was created to request official information from Panasonic.

## How to ~~use~~ test

For testing, please apply the following configuration to your phone:

```ini
XMLAPP_ENABLE="Y"
XMLAPP_USERID="xmltester"
XMLAPP_USERPASS="aZ9fB4qZ5uI2iS8c"
XML_HTTPD_PORT="6666"
```

Place the `label.xml` and `phones.xml` files on your `example.net` web server in the `/Panasonic/KX-TGP600RU/` directory.

Then, in the `PanasonicPhoneConsole` project, uncomment the lines starting with `res = client` to perform the necessary query on your phone.

```cs
string res;
var client = new PanasonicClient("xmltester", "aZ9fB4qZ5uI2iS8c", @"http://192.168.0.10:6666");

res = client.Trigger(@"http://example.net/Panasonic/KX-TGP600RU/label.xml");
Console.WriteLine(res);
```

After you make a request, errors with codes 0000, 01A3, 0301 may appear on the screen of your SIP phone.

Trying to export the phone book from your SIP phone will make it completely inoperable, including resetting it to factory settings.

## Appeal to Panasonic

No matter how good your products are, the software integration in them is bad. This needs to be fixed as soon as possible.

1. Please provide the actual XML data schemas you reference on pages 13(17), 27(31), of the "Panasonic SIP Phone TGP600, HDV 100/130/230/330/430 XML Application Developer s Guide. Revision 2.5.2":

- sip_phone_phonebook.xsd
- sip_phone.xsd
- value_restrict.xsd
- common.xsd
- Events.xsd
- ppxml_contents.xsd
- Key.xsd
- Screen_object.xsd

2. Answer the question, do the phone's XML services work only in trigger mode or can they accept any XML request according to the schemas referenced in the documentation?
3. What does error 0000 mean?
4. Please answer the question about Unicode (UTF-8 encoding) and Cyrillic support, particularly for the phone book.
5. Why does the TGP600 phone stop working after trying to export the phone book from a SIP phone?

## Appeal to Panasonic`s technical centers

Panasonic SIP phones, especially cordless phones, have proven themselves very well and have been leaders for the last 10+ years. They integrate perfectly with Asterisk software PBX and these products are really important for the consumer.

Please escalate these issues until the next line is discontinued.

## Appeal to those who figured it out

Please contact me by email ksn@ksn.name and tell me about your experience.

## License

MIT License
