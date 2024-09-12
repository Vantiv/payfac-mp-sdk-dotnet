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
            xmlBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.Append("<legalEntityAgreementCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.Append("<legalEntityAgreement>");
            legalEntityAgreement.Serialize(xmlBuilder);
            xmlBuilder.Append("</legalEntityAgreement>");
            xmlBuilder.Append("<sdkVersion>" + Versions.SDK_VERSION + "</sdkVersion>");
            xmlBuilder.Append("<language>" + Versions.LANGUAGE + "</language>");
            xmlBuilder.Append("</legalEntityAgreementCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }

    }
}
