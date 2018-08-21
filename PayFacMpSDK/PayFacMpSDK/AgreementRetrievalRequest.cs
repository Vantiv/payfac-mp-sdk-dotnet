using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    class AgreementRetrievalRequest
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

        private const string ServiceRoute = "/legalentity";

        public legalEntityAgreementRetrievalResponse GetAgreementResponse(string legalEntityId)
        {
            var xmlResponse = PayFacUtils.SendRetrievalRequest(ServiceRoute + "/" + legalEntityId + "/agreement", _communication, _configuration);
            return PayFacUtils.DeserializeResponse<legalEntityAgreementRetrievalResponse>(xmlResponse);
        }


    }
}
