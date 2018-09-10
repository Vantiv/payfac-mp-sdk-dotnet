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
            xmlBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.Append("<subMerchantCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            xmlBuilder.Append("<merchantName>" + merchantName + "</merchantName>");
            if(amexMid != null) xmlBuilder.Append("<amexMid>" + amexMid + "</amexMid>");
            if(discoverConveyedMid != null) xmlBuilder.Append("<discoverConveyedMid>" + discoverConveyedMid + "</discoverConveyedMid>");
            xmlBuilder.Append("<url>" + url + "</url>");
            xmlBuilder.Append("<customerServiceNumber>" + customerServiceNumber + "</customerServiceNumber>");
            xmlBuilder.Append("<hardCodedBillingDescriptor>" + hardCodedBillingDescriptor + "</hardCodedBillingDescriptor>");
            xmlBuilder.Append("<maxTransactionAmount>" + maxTransactionAmount + "</maxTransactionAmount>");
            if(purchaseCurrency != null) xmlBuilder.Append("<purchaseCurrency>" + purchaseCurrency + "</purchaseCurrency>");
            xmlBuilder.Append("<merchantCategoryCode>" + merchantCategoryCode + "</merchantCategoryCode>");
            if(taxAuthority != null) xmlBuilder.Append("<taxAuthority>" + taxAuthority + "</taxAuthority>");
            if(taxAuthorityState != null) xmlBuilder.Append("<taxAuthorityState>" + taxAuthorityState + "</taxAuthorityState>");
            xmlBuilder.Append("<bankRoutingNumber>" + bankRoutingNumber + "</bankRoutingNumber>");
            xmlBuilder.Append("<bankAccountNumber>" + bankAccountNumber + "</bankAccountNumber>");
            xmlBuilder.Append("<pspMerchantId>" + pspMerchantId + "</pspMerchantId>");
            if(fraud != null) xmlBuilder.Append("<fraud enabled=\"" + fraud.enabled.ToString().ToLower() + "\"></fraud>");
            if(amexAcquired != null) xmlBuilder.Append("<amexAcquired enabled=\"" + amexAcquired.enabled.ToString().ToLower() + "\"></amexAcquired>");
            if(address != null)
            {
                xmlBuilder.Append("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.Append("</address>");
            }
            if(primaryContact != null)
            {
                xmlBuilder.Append("<primaryContact>");
                primaryContact.Serialize(xmlBuilder);
                xmlBuilder.Append("</primaryContact>");
            }
            if(createCredentialsSpecified) xmlBuilder.Append("<createCredentials>" + createCredentials.ToString().ToLower() + "</createCredentials>");
            if(eCheck != null)
            {
                xmlBuilder.Append("<eCheck enabled =\"" + eCheck.enabled.ToString().ToLower() + "\">");
                eCheck.Serialize(xmlBuilder);
                xmlBuilder.Append("</eCheck>");
            }
            if(subMerchantFunding != null)
            {
                xmlBuilder.Append("<subMerchantFunding enabled =\"" + subMerchantFunding.enabled.ToString().ToLower() + "\">");
                subMerchantFunding.Serialize(xmlBuilder);
                xmlBuilder.Append("</subMerchantFunding>");
            }
            xmlBuilder.Append("<settlementCurrency>" + settlementCurrency + "</settlementCurrency>");
            xmlBuilder.Append("</subMerchantCreateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
