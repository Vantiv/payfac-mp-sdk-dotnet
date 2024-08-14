using PayFacMpSDK.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayFacMpSDK
{
    public partial class subMerchantUpdateRequest
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

        private const string ServiceRoute = "/legalentity/{0}/submerchant/{1}";

        public response PutSubMerchantUpdateRequest(string legalEntityId, string subMerchantId)
        {
            string requestBody = Serialize();
            var xmlResponse = PayFacUtils.SendPutRequest(String.Format(ServiceRoute,legalEntityId,subMerchantId), requestBody, _communication, _configuration);
            return PayFacUtils.DeserializeResponse<response>(xmlResponse);
        }

        public string Serialize()
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.Append("<subMerchantUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            if(merchantName != null) xmlBuilder.Append("<merchantName>" + merchantName + "</merchantName>");
            if(amexMid != null) xmlBuilder.Append("<amexMid>" + amexMid + "</amexMid>");
            if(discoverConveyedMid != null) xmlBuilder.Append("<discoverConveyedMid>" + discoverConveyedMid + "</discoverConveyedMid>");
            if(url != null) xmlBuilder.Append("<url>" + url + "</url>");
            if(customerServiceNumber != null) xmlBuilder.Append("<customerServiceNumber>" + customerServiceNumber + "</customerServiceNumber>");
            if(hardCodedBillingDescriptor != null) xmlBuilder.Append("<hardCodedBillingDescriptor>" + hardCodedBillingDescriptor + "</hardCodedBillingDescriptor>");
            if(maxTransactionAmountSpecified) xmlBuilder.Append("<maxTransactionAmount>" + maxTransactionAmount + "</maxTransactionAmount>");
            if(bankRoutingNumber != null) xmlBuilder.Append("<bankRoutingNumber>" + bankRoutingNumber + "</bankRoutingNumber>");
            if(bankAccountNumber != null) xmlBuilder.Append("<bankAccountNumber>" + bankAccountNumber + "</bankAccountNumber>");
            if(pspMerchantId != null) xmlBuilder.Append("<pspMerchantId>" + pspMerchantId + "</pspMerchantId>");
            if(purchaseCurrency != null) xmlBuilder.Append("<purchaseCurrency>" + purchaseCurrency + "</purchaseCurrency>");
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
            if(disableSpecified) xmlBuilder.Append("<disable>" + disable.ToString().ToLower() + "</disable>");
            if(fraud != null) xmlBuilder.Append("<fraud enabled=\"" + fraud.enabled.ToString().ToLower() + "\"></fraud>");
            if(amexAcquired != null) xmlBuilder.Append("<amexAcquired enabled=\"" + amexAcquired.enabled.ToString().ToLower() + "\"></amexAcquired>");
            if(eCheck != null)
            {
                xmlBuilder.Append("<eCheck enabled=\"" + eCheck.enabled.ToString().ToLower() +"\">");
                eCheck.Serialize(xmlBuilder);
                xmlBuilder.Append("</eCheck>");
            }
            if(subMerchantFunding != null)
            {
                xmlBuilder.Append("<subMerchantFunding enabled =\"" + subMerchantFunding.enabled.ToString().ToLower() + "\">");
                subMerchantFunding.Serialize(xmlBuilder);
                xmlBuilder.Append("</subMerchantFunding>");
            }
            if(taxAuthority != null) xmlBuilder.Append("<taxAuthority>" + taxAuthority + "</taxAuthority>");
            if(taxAuthorityState != null) xmlBuilder.Append("<taxAuthorityState>" + taxAuthorityState + "</taxAuthorityState>");
            if (methodOfPayments != null)
            {
                xmlBuilder.Append("<methodOfPayments>");
                methodOfPayments.Serialize(xmlBuilder);
                xmlBuilder.Append("</methodOfPayments>");
            }
            xmlBuilder.Append("</subMerchantUpdateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
