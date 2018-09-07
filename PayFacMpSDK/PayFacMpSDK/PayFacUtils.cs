using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace PayFacMpSDK

{

    public class PayFacUtils
    {

        private const string CONTENT_TYPE = "application/com.vantivcnp.payfac-v13+xml";
        private const string ACCEPT = "application/com.vantivcnp.payfac-v13+xml";

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

        public static string SendRetrievalRequest(string urlRoute, Communication communication, Configuration configuration)
        {
            try
            {
                ConfigureCommunication(communication, configuration);
                var xmlResponse = communication.Get(urlRoute);
                PayFacUtils.PrintXml(xmlResponse, configuration.Get("printXml"), configuration.Get("neuterAccountNums"));
                return xmlResponse;
            }
            catch (WebException we)
            {
                throw GetPayFacWebException(we, configuration);
            }
        }


        public static string SendDeleteRequest(string urlRoute, Communication communication, Configuration configuration)
        {
            try
            {
                ConfigureCommunication(communication, configuration);
                var xmlResponse = communication.Delete(urlRoute);
                PayFacUtils.PrintXml(xmlResponse, configuration.Get("printXml"), configuration.Get("neuterAccountNums"));
                return xmlResponse;
            }
            catch (WebException we)
            {
                throw GetPayFacWebException(we, configuration);
            }
        }


        public static string SendPostRequest(string urlRoute, string requestBody, Communication communication, Configuration configuration)
        {
            try
            {
                ConfigureCommunication(communication, configuration);
                var xmlResponse = communication.Post(urlRoute, requestBody);
                PayFacUtils.PrintXml(xmlResponse, configuration.Get("printXml"), configuration.Get("neuterAccountNums"));
                return xmlResponse;
            }
            catch (WebException we)
            {
                throw GetPayFacWebException(we, configuration);
            }
        }


        public static string SendPutRequest(string urlRoute, string requestBody, Communication communication, Configuration configuration)
        {
            try
            {
                ConfigureCommunication(communication, configuration);
                var xmlResponse = communication.Put(urlRoute, requestBody);
                PayFacUtils.PrintXml(xmlResponse, configuration.Get("printXml"), configuration.Get("neuterAccountNums"));
                return xmlResponse;
            }
            catch (WebException we)
            {
                throw GetPayFacWebException(we, configuration);
            }
        }


        private static void ConfigureCommunication(Communication communication, Configuration configuration)
        {
            communication.SetHost(configuration.Get("url"));
            communication.SetAuth(configuration.Get("username"), configuration.Get("password"));
            communication.SetContentType(CONTENT_TYPE);
            communication.SetAccept(ACCEPT);
        }
        

        private static PayFacWebException GetPayFacWebException(WebException we, Configuration config)
        {
            var webErrorResponse = (HttpWebResponse) we.Response;
            var httpStatusCode = (int) webErrorResponse.StatusCode;
            var rawResponse = GetResponseXml(webErrorResponse);
            if (!webErrorResponse.ContentType.Contains("application/com.vantivcnp.payfac-v13+xml"))
                return new PayFacWebException(string.Format("Request Failed - HTTP {0} Error", httpStatusCode)
                    , httpStatusCode, rawResponse);
            PrintXml(rawResponse, config.Get("printXml"), config.Get("neuterAccountNums"));
            var errorResponse = DeserializeResponse<errorResponse>(rawResponse);
            return new PayFacWebException(string.Format("Request failed - HTTP {0} Error", httpStatusCode), httpStatusCode, rawResponse, errorResponse);
        }
        
        private static string GetResponseXml(HttpWebResponse we)
        {
            var reader = new StreamReader(we.GetResponseStream());
            var xmlResponse = reader.ReadToEnd().Trim();
            reader.Close();
            return xmlResponse;
        }
    }
}