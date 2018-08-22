using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public class principalDeleteRequest
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

        private const string ServiceRoute = "/legalentity/{0}/principal/{1}";

        public principalDeleteResponse PrincipalDeleteRequest (string legalEntityId, string principalId)
        {
            var xmlResponse = PayFacUtils.SendDeleteRequest(String.Format(ServiceRoute, legalEntityId, principalId), _communication, _configuration);
            return PayFacUtils.DeserializeResponse<principalDeleteResponse>(xmlResponse);
        }
    }
}
