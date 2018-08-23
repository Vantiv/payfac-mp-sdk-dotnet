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
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<legalEntityUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            if(address != null)
            {
                xmlBuilder.AppendLine("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</address>");
            }
            if(contactPhone != null) xmlBuilder.AppendLine("<contactPhone>" + contactPhone + "</contactPhone>");
            if(doingBusinessAs != null) xmlBuilder.AppendLine("<doingBusinessAs>" + doingBusinessAs + "</doingBusinessAs>");
            if(annualCreditCardSalesVolumeSpecified) xmlBuilder.AppendLine("<annualCreditCardSalesVolume>" + annualCreditCardSalesVolume + "</annualCreditCardSalesVolume>");
            if(hasAcceptedCreditCardsSpecified) xmlBuilder.AppendLine("<hasAcceptedCreditCards>" + hasAcceptedCreditCards.ToString().ToLower() + "</hasAcceptedCreditCards>");
            if(principal != null)
            {
                xmlBuilder.AppendLine("<principal>");
                principal.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</principal>");
            }
            if(backgroundCheckFields != null)
            {
                xmlBuilder.AppendLine("<backgroundCheckFields>");
                backgroundCheckFields.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</backgroundCheckFields>");
            }
            if(legalEntityOwnershipTypeSpecified) xmlBuilder.AppendLine("<legalEntityOwnershipType>" + legalEntityOwnershipType + "</legalEntityOwnershipType>");
            if(yearsInBusiness != null) xmlBuilder.AppendLine("<yearsInBusiness>" + yearsInBusiness + "</yearsInBusiness>");
            
            xmlBuilder.Append("</legalEntityUpdateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
