using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    class MCCRetrievalRequest
    {
        private static Communication _communication = new Communication();
        private static Configuration _configuration = new Configuration();

        public Configuration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }

        public Communication Communication
        {
            get { return _communication; }
            set { _communication = value; }
        }

        private const string ServiceRoute = "/mcc";

        public approvedMccResponse GetMccResponse()
        {
            var xmlResponse = SendRetrievalRequest(ServiceRoute);
            return PayFacUtils.DeserializeResponse<approvedMccResponse>(xmlResponse);
        }

        private string SendRetrievalRequest(string urlRoute)
        {
            try
            {
                ConfigureCommunication();
                var xmlResponse = _communication.Get(urlRoute);
                PayFacUtils.PrintXml(xmlResponse, _configuration.Get("printXml"), _configuration.Get("neuterAccountNums"));
                return xmlResponse;
            }
            catch (WebException we)
            {
                throw new Exception();
                // TODO throw pay fac exception
            }
        }

        private void ConfigureCommunication()
        {
            _communication.SetHost(_configuration.Get("url"));
            _communication.SetAuth(_configuration.Get("username"), _configuration.Get("password"));
            _communication.SetContentType(_configuration.Get("contentType"));
            _communication.SetAccept(_configuration.Get("accept"));
        } 
    }
}
