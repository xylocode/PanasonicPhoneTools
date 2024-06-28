using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;
using XyloCode.PanasonicPhoneTools.XmlModels;

namespace XyloCode.PanasonicPhoneTools
{
    public class PanasonicClient
    {
        private readonly XmlSerializerNamespaces xmlns;
        private readonly HttpClient httpClient;
        public PanasonicClient(
            string username,
            string password,
            string uri)
        {
            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(username, password)
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(uri),
            };
        }

        public string Trigger(string uri)
        {
            var obj = new PanasonicPhoneTrigger(uri);
            return Post(obj);
        }

        public string Post<T>(T obj)
            where T : class
        {
            var s = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            s.Serialize(ms, obj, xmlns);
            var xml = Encoding.UTF8.GetString(ms.ToArray());
            //Console.WriteLine(xml);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/Request.cgi")
            {
                Content = new StringContent(xml, Encoding.UTF8, new MediaTypeHeaderValue("text/xml"))
            };

            var httpResult = httpClient.Send(requestMessage);
            return httpResult
                .Content
                .ReadAsStringAsync()
                .Result;
        }
    }
}
