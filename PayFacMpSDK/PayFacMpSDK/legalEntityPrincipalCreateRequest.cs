using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class legalEntityPrincipalCreateRequest 
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

        private const string ServiceRoute = "/legalentity/{0}/principal";

        public principalCreateResponse PostLegalEntityPrincipalCreateRequest(string legalentityId)
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPostRequest(String.Format(ServiceRoute,legalentityId), requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<principalCreateResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<legalEntityPrincipalCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.AppendLine("<principal>");
            principal.Serialize(xmlBuilder);
            xmlBuilder.AppendLine("</principal>");
            xmlBuilder.Append("</legalEntityPrincipalCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }

    }
}
