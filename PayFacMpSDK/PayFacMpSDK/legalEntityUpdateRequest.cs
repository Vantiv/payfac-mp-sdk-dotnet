using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class legalEntityUpdateRequest
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

        private const string ServiceRoute = "/legalentity/{0}";

        public legalEntityResponse PutLegalEntityUpdateRequest(string legalEntityId)
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPutRequest(String.Format(ServiceRoute,legalEntityId), requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<legalEntityResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.Append("<legalEntityUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            if(address != null)
            {
                xmlBuilder.Append("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.Append("</address>");
            }
            if(contactPhone != null) xmlBuilder.Append("<contactPhone>" + contactPhone + "</contactPhone>");
            if(doingBusinessAs != null) xmlBuilder.Append("<doingBusinessAs>" + doingBusinessAs + "</doingBusinessAs>");
            if(annualCreditCardSalesVolumeSpecified) xmlBuilder.Append("<annualCreditCardSalesVolume>" + annualCreditCardSalesVolume + "</annualCreditCardSalesVolume>");
            if(hasAcceptedCreditCardsSpecified) xmlBuilder.Append("<hasAcceptedCreditCards>" + hasAcceptedCreditCards.ToString().ToLower() + "</hasAcceptedCreditCards>");
            if(principal != null)
            {
                xmlBuilder.Append("<principal>");
                principal.Serialize(xmlBuilder);
                xmlBuilder.Append("</principal>");
            }
            if(backgroundCheckFields != null)
            {
                xmlBuilder.Append("<backgroundCheckFields>");
                backgroundCheckFields.Serialize(xmlBuilder);
                xmlBuilder.Append("</backgroundCheckFields>");
            }
            if(legalEntityOwnershipTypeSpecified) xmlBuilder.Append("<legalEntityOwnershipType>" + legalEntityOwnershipType + "</legalEntityOwnershipType>");
            if(yearsInBusiness != null) xmlBuilder.Append("<yearsInBusiness>" + yearsInBusiness + "</yearsInBusiness>");
            xmlBuilder.Append("<pciLevel>" + pciLevel + "</pciLevel>");

            xmlBuilder.Append("</legalEntityUpdateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
