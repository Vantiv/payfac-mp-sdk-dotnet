

using System;
using System.Text;

namespace PayFacMpSDK
{

     public partial class legalEntityAgreement
    {

        public void Serialize(StringBuilder xmlBuilder)
        {

            xmlBuilder.Append("<legalEntityAgreementType>" + legalEntityAgreementType + "</legalEntityAgreementType>");
            xmlBuilder.Append("<agreementVersion>" + agreementVersion + "</agreementVersion>");
            xmlBuilder.Append("<userFullName>" + userFullName + "</userFullName>");
            xmlBuilder.Append("<userSystemName>" + userSystemName + "</userSystemName>");
            xmlBuilder.Append("<userIPAddress>" + userIPAddress + "</userIPAddress>");
            if (manuallyEnteredSpecified) xmlBuilder.Append("<manuallyEntered>" + manuallyEntered.ToString().ToLower() + "</manuallyEntered>");
            xmlBuilder.Append("<acceptanceDateTime>" + acceptanceDateTime.ToString("yyyy-MM-ddThh:mm:sszzz") + "</acceptanceDateTime>");
        }
    }


    public partial class subMerchantECheckFeature
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if(eCheckCompanyName != null) xmlBuilder.Append("<eCheckCompanyName>" + eCheckCompanyName + "</eCheckCompanyName>");
            if(eCheckBillingDescriptor != null) xmlBuilder.Append("<eCheckBillingDescriptor>" + eCheckBillingDescriptor + "</eCheckBillingDescriptor>");
        }
    }


      public partial class subMerchantFunding
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if(feeProfile != null) xmlBuilder.Append("<feeProfile>" + feeProfile + "</feeProfile>");
            if(fundingSubmerchantId != null) xmlBuilder.Append("<fundingSubmerchantId>" + fundingSubmerchantId + "</fundingSubmerchantId>");
        }
    }


    public partial class addressUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (streetAddress1 != null) xmlBuilder.Append("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if (streetAddress2 != null) xmlBuilder.Append("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            if (city != null) xmlBuilder.Append("<city>" + city + "</city>");
            if (stateProvince != null) xmlBuilder.Append("<stateProvince>" + stateProvince + "</stateProvince>");
            if (postalCode != null) xmlBuilder.Append("<postalCode>" + postalCode + "</postalCode>");
            if (countryCode != null) xmlBuilder.Append("<countryCode>" + countryCode + "</countryCode>");
        }
    }


    public partial class legalEntityPrincipalUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.Append("<principalId>" + principalId + "</principalId>");
            if (title != null) xmlBuilder.Append("<title>" + title + "</title>");
            if (emailAddress != null) xmlBuilder.Append("<emailAddress>" + emailAddress + "</emailAddress>");
            if (contactPhone != null) xmlBuilder.Append("<contactPhone>" + contactPhone + "</contactPhone>");
            if (address != null)
            {
                xmlBuilder.Append("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.Append("</address>");
            }
            if (stakePercentSpecified) xmlBuilder.Append("<stakePercent>" + stakePercent + "</stakePercent>");
            if (backgroundCheckFields != null)
            {
                xmlBuilder.Append("<backgroundCheckFields>");
                backgroundCheckFields.Serialize(xmlBuilder);
                xmlBuilder.Append("</backgroundCheckFields>");
            }
        }
    }


    public partial class principalBackgroundCheckFields
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (firstName != null) xmlBuilder.Append("<firstName>" + firstName + "</firstName>");
            if (lastName != null) xmlBuilder.Append("<lastName>" + lastName + "</lastName>");
            if (ssn != null) xmlBuilder.Append("<ssn>" + ssn + "</ssn>");
            if (dateOfBirthSpecified) xmlBuilder.Append("<dateOfBirth>" + dateOfBirth.ToString("yyyy-MM-dd") + "</dateOfBirth>");
            if (driversLicense != null) xmlBuilder.Append("<driversLicense>" + driversLicense + "</driversLicense>");
            if (driversLicenseState != null) xmlBuilder.Append("<driversLicenseState>" + driversLicenseState + "</driversLicenseState>");
        }
    }

    public partial class legalEntityBackgroundCheckFields
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (legalEntityName != null) xmlBuilder.Append("<legalEntityName>" + legalEntityName + "</legalEntityName>");
            if (legalEntityTypeSpecified) xmlBuilder.Append("<legalEntityType>" + legalEntityType + "</legalEntityType>");
            if (taxId != null) xmlBuilder.Append("<taxId>" + taxId + "</taxId>");
        }
    }

    public partial class subMerchantPrimaryContactUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (firstName != null) xmlBuilder.Append("<firstName>" + firstName + "</firstName>");
            if (lastName != null) xmlBuilder.Append("<lastName>" + lastName + "</lastName>");
            if (emailAddress != null) xmlBuilder.Append("<emailAddress>" + emailAddress + "</emailAddress>");
            if (phone != null) xmlBuilder.Append("<phone>" + phone + "</phone>");
        }
    }


    
    public partial class subMerchantPrimaryContact
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.Append("<firstName>" + firstName + "</firstName>");
            xmlBuilder.Append("<lastName>" + lastName + "</lastName>");
            xmlBuilder.Append("<emailAddress>" + emailAddress + "</emailAddress>");
            xmlBuilder.Append("<phone>" + phone + "</phone>");

        }
    }

    public partial class merchantCategoryTypes
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            //  if (categoryType != null) xmlBuilder.Append("<categoryType>" + categoryType + "</categoryType>");
            foreach (var categoryType in categoryTypeField)
            {
                xmlBuilder.Append("<categoryType>" + categoryType + "</categoryType>");
            }
        }
    }

    public partial class methodOfPayments
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            foreach (var newMethod in methodField)
            {
                xmlBuilder.Append("<method>");
                newMethod.Serialize(xmlBuilder);
                xmlBuilder.Append("</method>");
            }
        }
    }

    public partial class paymentMethod
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if (paymentType != null) xmlBuilder.Append("<paymentType>" + paymentType + "</paymentType>");
            if (selectedTransactionType != null) xmlBuilder.Append("<selectedTransactionType>" + selectedTransactionType + "</selectedTransactionType>");
            if (allowedTransactionTypes != null) xmlBuilder.Append("<allowedTransactionTypes>" + allowedTransactionTypes + "</allowedTransactionTypes>");
        }
    }


    public partial class address
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.Append("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if(streetAddress2 != null) xmlBuilder.Append("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            xmlBuilder.Append("<city>" + city + "</city>");
            xmlBuilder.Append("<stateProvince>" + stateProvince + "</stateProvince>");
            xmlBuilder.Append("<postalCode>" + postalCode + "</postalCode>");
            xmlBuilder.Append("<countryCode>" + countryCode + "</countryCode>");
        }
    }

    public partial class principalAddress
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (streetAddress1 != null) xmlBuilder.Append("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if (streetAddress2 != null) xmlBuilder.Append("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            if (city != null) xmlBuilder.Append("<city>" + city + "</city>");
            if (stateProvince != null) xmlBuilder.Append("<stateProvince>" + stateProvince + "</stateProvince>");
            if (postalCode != null) xmlBuilder.Append("<postalCode>" + postalCode + "</postalCode>");
            if (countryCode != null) xmlBuilder.Append("<countryCode>" + countryCode + "</countryCode>");
        }
    }


    public partial class legalEntityPrincipal
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if(principalIdSpecified) xmlBuilder.Append("<principalId>" + principalId + "</principalId>");
            if(title != null) xmlBuilder.Append("<title>" + title + "</title>");
            xmlBuilder.Append("<firstName>" + firstName + "</firstName>");
            xmlBuilder.Append("<lastName>" + lastName + "</lastName>");
            if(emailAddress != null) xmlBuilder.Append("<emailAddress>" + emailAddress + "</emailAddress>");
            if(ssn != null) xmlBuilder.Append("<ssn>" + ssn + "</ssn>");
            if(contactPhone != null) xmlBuilder.Append("<contactPhone>" + contactPhone + "</contactPhone>");
            xmlBuilder.Append("<dateOfBirth>" + dateOfBirth.ToString("yyyy-MM-dd") + "</dateOfBirth>");
            if(driversLicense != null) xmlBuilder.Append("<driversLicense>" + driversLicense + "</driversLicense>");
            if(driversLicenseState != null) xmlBuilder.Append("<driversLicenseState>" + driversLicenseState + "</driversLicenseState>");
            if (address != null)
            {
                xmlBuilder.Append("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.Append("</address>");
            }
            xmlBuilder.Append("<stakePercent>" + stakePercent + "</stakePercent>");
            if (principal != null)
            {
                xmlBuilder.Append("<principal>");
                principal.Serialize(xmlBuilder);
                xmlBuilder.Append("</principal>");
            }
        }

    }

    public partial class principalResult
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (verificationResult != null)
            {
                xmlBuilder.Append("<verificationResult>");
                verificationResult.Serialize(xmlBuilder);
                xmlBuilder.Append("</verificationResult>");
            }
            if (backgroundCheckDecisionNotes != null) xmlBuilder.Append("<backgroundCheckDecisionNotes>" + backgroundCheckDecisionNotes + "</backgroundCheckDecisionNotes>");
        }
    }


    public partial class principalVerificationResult
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (overallScore != null)
            {
                xmlBuilder.Append("<overallScore>");
                overallScore.Serialize(xmlBuilder);
                xmlBuilder.Append("</overallScore>");
            }

            if (nameAddressSsnAssociation != null)
            {
                xmlBuilder.Append("<nameAddressSsnAssociation>");
                nameAddressSsnAssociation.Serialize(xmlBuilder);
                xmlBuilder.Append("</nameAddressSsnAssociation>");
            }

            if (nameAddressPhoneAssociation != null)
            {
                xmlBuilder.Append("<nameAddressPhoneAssociation>");
                nameAddressPhoneAssociation.Serialize(xmlBuilder);
                xmlBuilder.Append("</nameAddressPhoneAssociation>");
            }

            if (verificationIndicators != null)
            {
                xmlBuilder.Append("<verificationIndicators>");
                verificationIndicators.Serialize(xmlBuilder);
                xmlBuilder.Append("</verificationIndicators>");
            }

            if (riskIndicators != null)
            {
                foreach(var riskIndicator in riskIndicators)
                {
                    xmlBuilder.Append("<riskIndicator>");
                    riskIndicator.Serialize(xmlBuilder);
                    xmlBuilder.Append("</riskIndicator>");
                }
            }
        }
    }


    public partial class principalScore
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (scoreSpecified) xmlBuilder.Append("<score>" + score + "</score>");
            if (description != null) xmlBuilder.Append("<description>" + description + "</description>");
        }
    }

    public partial class nameAddressSsnAssociation
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.Append("<code>" + code + "</code>");

            if (description != null) xmlBuilder.Append("<description>" + description + "</description>");
        }
    }

    public partial class principalNameAddressPhoneAssociation
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.Append("<code>" + code + "</code>");

            if (description != null) xmlBuilder.Append("<description>" + description + "</description>");
        }
    }

    public partial class potentialRiskIndicator
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.Append("<code>" + code + "</code>");
            if (description != null) xmlBuilder.Append("<description>" + description + "</description>");
        }
    }

    public partial class principalVerificationIndicators
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.Append("<nameVerified>" + nameVerified + "</nameVerified>");
            xmlBuilder.Append("<addressVerified>" + addressVerified + "</addressVerified>");
            xmlBuilder.Append("<phoneVerified>" + phoneVerified + "</phoneVerified>");
            xmlBuilder.Append("<ssnVerified>" + ssnVerified + "</ssnVerified>");
            xmlBuilder.Append("<dobVerified>" + dobVerified + "</dobVerified>");
        }
    }
}
