
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PayFacMpSDK
{
    public class Communication
    {
        private HttpWebRequest _httpRequest;
        private WebHeaderCollection _headers;
        private WebProxy _webProxy;
        private string auth;
        private string _contentType;
        private string _accept;
        private string _host;

        public Communication()
        {
            _headers = new WebHeaderCollection();
        }

        public void AddHeader(string key, string value)
        {
            if (_headers.AllKeys.Contains(key))
            {
                _headers[key] = value;
            }
            else
            {
                _headers.Add(key, value);
            }
        }

        public void SetHost(string host)
        {
            _host = host;
        }

        public void SetProxy(string host, string port)
        {
            // TODO: throw exception if port is not an int
            _webProxy = new WebProxy(host, int.Parse(port));
        }

        public void SetContentType(string contentType)
        {
            _contentType = contentType;
        }

        public void SetAuth(string userName, string password)
        {
            string encoded = PayFacUtils.Encode64(userName + ":" + password, "utf-8");
            AddHeader("Authorization", "Basic " + encoded);
        }

        public void SetAccept(string accept)
        {
            _accept = accept;
        }

        public virtual string Get(string urlRoute)
        {
            CreateNewHttpRequest(urlRoute);
            _httpRequest.Method = "GET";
            return ReceiveResponse();
        }

        public virtual string Delete(string urlRoute)
        {
            CreateNewHttpRequest(urlRoute);
            _httpRequest.Method = "DELETE";
            return ReceiveResponse();
        }

        public virtual string Post(string urlRoute, string inputRequest)
        {
            CreateNewHttpRequest(urlRoute);
            _httpRequest.Method = "POST";
            WriteBytesToRequestStream(inputRequest);
            return ReceiveResponse();
        }

        public virtual string Put(string urlRoute, string inputRequest)
        {
            CreateNewHttpRequest(urlRoute);
            _httpRequest.Method = "PUT";
            WriteBytesToRequestStream(inputRequest);
            return ReceiveResponse();
        }

        private void WriteBytesToRequestStream(string inputRequest)
        {
            _httpRequest.ContentLength = inputRequest.Length;
            Stream inStream = _httpRequest.GetRequestStream();
            inStream.Write(Encoding.UTF8.GetBytes(inputRequest), 0, inputRequest.Length);
            inStream.Close();
        }

        private void CreateNewHttpRequest(string urlRoute)
        {
            string url = _host + urlRoute;
            Console.WriteLine("Making a request to " + url);
            // For TLS1.2.
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            _httpRequest = (HttpWebRequest)WebRequest.Create(url);
            _httpRequest.Headers.Add(_headers);
            if (_webProxy != null)
            {
                _httpRequest.Proxy = _webProxy;
            }

            if (_contentType != null)
            {
                _httpRequest.ContentType = _contentType;
            }

            if (_accept != null)
            {
                _httpRequest.Accept = _accept;
            }
        }

        private string ReceiveResponse()
        {
            var httpResponse = (HttpWebResponse)_httpRequest.GetResponse();
            var receivingbytes = new List<byte>();
            var contentType = httpResponse.ContentType;

            var responseStream = httpResponse.GetResponseStream();
            var b = responseStream.ReadByte();
            while (b != -1)
            {
                receivingbytes.Add((byte)b);
                b = responseStream.ReadByte();
            }

            responseStream.Close();
            httpResponse.Close();
            return PayFacUtils.BytesToString(receivingbytes);
        }
    }
}