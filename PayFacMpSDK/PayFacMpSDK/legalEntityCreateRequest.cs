using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class legalEntityCreateRequest 
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

        public legalEntityCreateResponse PostLegalEntityCreateRequest()
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPostRequest(ServiceRoute, requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<legalEntityCreateResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<legalEntityCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.AppendLine("<legalEntityName>" + legalEntityName + "</legalEntityName>");
            xmlBuilder.AppendLine("<legalEntityType>" + legalEntityType + "</legalEntityType>");
            xmlBuilder.AppendLine("<legalEntityOwnershipType>" + legalEntityType + "</legalEntityOwnershipType>");
            if (doingBusinessAs != null) xmlBuilder.AppendLine("<doingBusinessAs>" + doingBusinessAs + "</doingBusinessAs>");
            if (taxId != null) xmlBuilder.AppendLine("<taxId>" + taxId + "</taxId>");
            if (contactPhone != null) xmlBuilder.AppendLine("<contactPhone>" + contactPhone + "</contactPhone>");
            xmlBuilder.AppendLine("<annualCreditCardSalesVolume>" + annualCreditCardSalesVolume + "</annualCreditCardSalesVolume>");
            xmlBuilder.AppendLine("<hasAcceptedCreditCards>" + hasAcceptedCreditCards + "</hasAcceptedCreditCards>");
            xmlBuilder.AppendLine("<address>");
            address.Serialize(xmlBuilder);
            xmlBuilder.AppendLine("</address>");
            xmlBuilder.AppendLine("<principal>");
            principal.Serialize(xmlBuilder);
            xmlBuilder.AppendLine("</principal>");
            if(yearsInBusiness != null) xmlBuilder.AppendLine("<yearsInBusiness>" + yearsInBusiness + "</yearsInBusiness>");
            xmlBuilder.Append("</legalEntityCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }

    }
}
