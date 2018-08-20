using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace PayFacMpSDK

{

    public class PayFacUtils
    {

        public static string BytesToString(List<byte> bytes)
        {
            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public static byte[] StringToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string Encode64(string s, string encode)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(encode)
                .GetBytes(s));
        }

        public static void PrintXml(string xml, string printXml, string neuterXml)
        {
            if (bool.Parse(printXml))
            {
                if (bool.Parse(neuterXml))
                {
                    xml = NeuterXml(xml);
                }
                Console.WriteLine("\nXml : \n" + xml + "\n\n");
            }
        }

        private static string NeuterXml(string xml)
        {
            return xml;
        }

        public static T DeserializeResponse<T>(string xmlResponse)
        {
            return (T) (new XmlSerializer(typeof(T))).Deserialize(new StringReader(xmlResponse));
        }
    }
}