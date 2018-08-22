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
            xmlBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            xmlBuilder.AppendLine("<subMerchantUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">");
            if(merchantName != null) xmlBuilder.AppendLine("<merchantName>" + merchantName + "</merchantName>");
            if(amexMid != null) xmlBuilder.AppendLine("<amexMid>" + amexMid + "</amexMid>");
            if(discoverConveyedMid != null) xmlBuilder.AppendLine("<discoverConveyedMid>" + discoverConveyedMid + "</discoverConveyedMid>");
            if(url != null) xmlBuilder.AppendLine("<url>" + url + "</url>");
            if(customerServiceNumber != null) xmlBuilder.AppendLine("<customerServiceNumber>" + customerServiceNumber + "</customerServiceNumber>");
            if(hardCodedBillingDescriptor != null) xmlBuilder.AppendLine("<hardCodedBillingDescriptor>" + hardCodedBillingDescriptor + "</hardCodedBillingDescriptor>");
            if(maxTransactionAmountSpecified) xmlBuilder.AppendLine("<maxTransactionAmount>" + maxTransactionAmount + "</maxTransactionAmount>");
            if(bankRoutingNumber != null) xmlBuilder.AppendLine("<bankRoutingNumber>" + bankRoutingNumber + "</bankRoutingNumber>");
            if(bankAccountNumber != null) xmlBuilder.AppendLine("<bankAccountNumber>" + bankAccountNumber + "</bankAccountNumber>");
            if(pspMerchantId != null) xmlBuilder.AppendLine("<pspMerchantId>" + pspMerchantId + "</pspMerchantId>");
            if(purchaseCurrency != null) xmlBuilder.AppendLine("<purchaseCurrency>" + purchaseCurrency + "</purchaseCurrency>");
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
            if(disableSpecified) xmlBuilder.AppendLine("<disable>" + disable + "</disable>");
            if(fraud != null) xmlBuilder.AppendLine("<fraud enabled=\"" + fraud.enabled + "\"></fraud>");
            if(amexAcquired != null) xmlBuilder.AppendLine("<amexAcquired enabled=\"" + amexAcquired.enabled + "\"></amexAcquired>");
            if(eCheck != null)
            {
                xmlBuilder.AppendLine("<eCheck enabled =\"" + eCheck.enabled +"\">");
                eCheck.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</eCheck>");
            }
            if(subMerchantFunding != null)
            {
                xmlBuilder.AppendLine("<subMerchantFunding enabled =\"" + subMerchantFunding.enabled +"\">");
                subMerchantFunding.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</subMerchantFunding>");
            }
            if(taxAuthority != null) xmlBuilder.AppendLine("<taxAuthority>" + taxAuthority + "</taxAuthority>");
            if(taxAuthorityState != null) xmlBuilder.AppendLine("<taxAuthorityState>" + taxAuthorityState + "</taxAuthorityState>");
            xmlBuilder.Append("</subMerchantUpdateRequest>");
            Console.WriteLine(xmlBuilder.ToString());
            return xmlBuilder.ToString();
        }
    }
}
