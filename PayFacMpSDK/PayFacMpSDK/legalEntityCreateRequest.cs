using PayFacMpSDK.Properties;
using System;
using System.Text;

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
            string requestBody = this.Serialize();
            var xmlResponse = PayFacUtils.SendPostRequest(ServiceRoute, requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<legalEntityCreateResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.Append("<legalEntityCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.Append("<legalEntityName>" + legalEntityName + "</legalEntityName>");
            xmlBuilder.Append("<legalEntityType>" + legalEntityType + "</legalEntityType>");
            xmlBuilder.Append("<legalEntityOwnershipType>" + legalEntityOwnershipType + "</legalEntityOwnershipType>");
            if (doingBusinessAs != null) xmlBuilder.Append("<doingBusinessAs>" + doingBusinessAs + "</doingBusinessAs>");
            if (taxId != null) xmlBuilder.Append("<taxId>" + taxId + "</taxId>");
            if (contactPhone != null) xmlBuilder.Append("<contactPhone>" + contactPhone + "</contactPhone>");
            xmlBuilder.Append("<annualCreditCardSalesVolume>" + annualCreditCardSalesVolume + "</annualCreditCardSalesVolume>");
            xmlBuilder.Append("<hasAcceptedCreditCards>" + hasAcceptedCreditCards.ToString().ToLower() + "</hasAcceptedCreditCards>");
            xmlBuilder.Append("<address>");
            address.Serialize(xmlBuilder);
            xmlBuilder.Append("</address>");
            xmlBuilder.Append("<principal>");
            principal.Serialize(xmlBuilder);
            xmlBuilder.Append("</principal>");
            if(yearsInBusiness != null) xmlBuilder.Append("<yearsInBusiness>" + yearsInBusiness + "</yearsInBusiness>");
            xmlBuilder.Append("<sdkVersion>" + Versions.SDK_VERSION + "</sdkVersion>");
            xmlBuilder.Append("<language>" + Versions.LANGUAGE + "</language>");
            xmlBuilder.Append("</legalEntityCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }

    }
}
