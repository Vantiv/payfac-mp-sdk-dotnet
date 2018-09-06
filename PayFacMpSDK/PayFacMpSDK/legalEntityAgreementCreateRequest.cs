using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class legalEntityAgreementCreateRequest
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

        private const string ServiceRoute = "/legalentity/{0}/agreement";

        public legalEntityAgreementCreateResponse PostLegalEntityAgreementCreateRequest(string legalEntityId)
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPostRequest(String.Format(ServiceRoute, legalEntityId), requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<legalEntityAgreementCreateResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<legalEntityAgreementCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.AppendLine("<legalEntityAgreement>");
            legalEntityAgreement.Serialize(xmlBuilder);
            xmlBuilder.AppendLine("</legalEntityAgreement>");
            xmlBuilder.Append("</legalEntityAgreementCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }

    }
}
