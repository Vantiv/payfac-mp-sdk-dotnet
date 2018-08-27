using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class subMerchantCreateRequest
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

        private const string ServiceRoute = "/legalentity/{0}/submerchant";

        public subMerchantCreateResponse PostSubMerchantCreateRequest(string legalEntityId)
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPostRequest(String.Format(ServiceRoute,legalEntityId), requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<subMerchantCreateResponse>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<subMerchantCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.AppendLine("<merchantName>" + merchantName + "</merchantName>");
            if(amexMid != null) xmlBuilder.AppendLine("<amexMid>" + amexMid + "</amexMid>");
            if(discoverConveyedMid != null) xmlBuilder.AppendLine("<discoverConveyedMid>" + discoverConveyedMid + "</discoverConveyedMid>");
            xmlBuilder.AppendLine("<url>" + url + "</url>");
            xmlBuilder.AppendLine("<customerServiceNumber>" + customerServiceNumber + "</customerServiceNumber>");
            xmlBuilder.AppendLine("<hardCodedBillingDescriptor>" + hardCodedBillingDescriptor + "</hardCodedBillingDescriptor>");
            xmlBuilder.AppendLine("<maxTransactionAmount>" + maxTransactionAmount + "</maxTransactionAmount>");
            if(purchaseCurrency != null) xmlBuilder.AppendLine("<purchaseCurrency>" + purchaseCurrency + "</purchaseCurrency>");
            xmlBuilder.AppendLine("<merchantCategoryCode>" + merchantCategoryCode + "</merchantCategoryCode>");
            if(taxAuthority != null) xmlBuilder.AppendLine("<taxAuthority>" + taxAuthority + "</taxAuthority>");
            if(taxAuthorityState != null) xmlBuilder.AppendLine("<taxAuthorityState>" + taxAuthorityState + "</taxAuthorityState>");
            xmlBuilder.AppendLine("<bankRoutingNumber>" + bankRoutingNumber + "</bankRoutingNumber>");
            xmlBuilder.AppendLine("<bankAccountNumber>" + bankAccountNumber + "</bankAccountNumber>");
            xmlBuilder.AppendLine("<pspMerchantId>" + pspMerchantId + "</pspMerchantId>");
            if(fraud != null) xmlBuilder.AppendLine("<fraud enabled=\"" + fraud.enabled.ToString().ToLower() + "\"></fraud>");
            if(amexAcquired != null) xmlBuilder.AppendLine("<amexAcquired enabled=\"" + amexAcquired.enabled.ToString().ToLower() + "\"></amexAcquired>");
            if(address != null)
            {
                xmlBuilder.AppendLine("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</address>");
            }
            if(primaryContact != null)
            {
                xmlBuilder.AppendLine("<primaryContact>");
                primaryContact.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</primaryContact>");
            }
            if(createCredentialsSpecified) xmlBuilder.AppendLine("<createCredentials>" + createCredentials.ToString().ToLower() + "</createCredentials>");
            if(eCheck != null)
            {
                xmlBuilder.AppendLine("<eCheck enabled =\"" + eCheck.enabled.ToString().ToLower() + "\">");
                eCheck.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</eCheck>");
            }
            if(subMerchantFunding != null)
            {
                xmlBuilder.AppendLine("<subMerchantFunding enabled =\"" + subMerchantFunding.enabled.ToString().ToLower() + "\">");
                subMerchantFunding.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</subMerchantFunding>");
            }
            xmlBuilder.AppendLine("<settlementCurrency>" + settlementCurrency + "</settlementCurrency>");
            xmlBuilder.Append("</subMerchantCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
