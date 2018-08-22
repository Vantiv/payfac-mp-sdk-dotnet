

using System.Text;

namespace PayFacMpSDK
{

     public partial class legalEntityAgreement
    {

        public void Serialize(StringBuilder xmlBuilder)
        {

            xmlBuilder.AppendLine("<legalEntityAgreementType>" + legalEntityAgreementType + "</legalEntityAgreementType>");
            xmlBuilder.AppendLine("<agreementVersion>" + agreementVersion + "</agreementVersion>");
            xmlBuilder.AppendLine("<userFullName>" + userFullName + "</userFullName>");
            xmlBuilder.AppendLine("<userSystemName>" + userSystemName + "</userSystemName>");
            xmlBuilder.AppendLine("<userIPAddress>" + userIPAddress + "</userIPAddress>");
            if (manuallyEnteredSpecified) xmlBuilder.AppendLine("<manuallyEntered>" + manuallyEntered + "</manuallyEntered>");
            xmlBuilder.AppendLine("<acceptanceDateTime>" + acceptanceDateTime.ToString("yyyy-mm-ddThh:mm:sszzz") + "</acceptanceDateTime>");
        }
    }


    public partial class subMerchantECheckFeature
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.AppendLine("<eCheckCompanyName>" + eCheckCompanyName + "</eCheckCompanyName>");
            if(eCheckBillingDescriptor != null) xmlBuilder.AppendLine("<eCheckBillingDescriptor>" + eCheckBillingDescriptor + "</eCheckBillingDescriptor>");
        }
    }


      public partial class subMerchantFunding
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if(feeProfile != null) xmlBuilder.AppendLine("<feeProfile>" + feeProfile + "</feeProfile>");
            if(fundingSubmerchantId != null) xmlBuilder.AppendLine("<fundingSubmerchantId>" + fundingSubmerchantId + "</fundingSubmerchantId>");
        }
    }


    public partial class addressUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (streetAddress1 != null) xmlBuilder.AppendLine("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if (streetAddress2 != null) xmlBuilder.AppendLine("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            if (city != null) xmlBuilder.AppendLine("<city>" + city + "</city>");
            if (stateProvince != null) xmlBuilder.AppendLine("<stateProvince>" + stateProvince + "</stateProvince>");
            if (postalCode != null) xmlBuilder.AppendLine("<postalCode>" + postalCode + "</postalCode>");
            if (countryCode != null) xmlBuilder.AppendLine("<countryCode>" + countryCode + "</countryCode>");
        }
    }


    public partial class legalEntityPrincipalUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.AppendLine("<principalId>" + principalId + "</principalId>");
            if (title != null) xmlBuilder.AppendLine("<title>" + title + "</title>");
            if (emailAddress != null) xmlBuilder.AppendLine("<emailAddress>" + emailAddress + "</emailAddress>");
            if (contactPhone != null) xmlBuilder.AppendLine("<contactPhone>" + contactPhone + "</contactPhone>");
            if (address != null)
            {
                xmlBuilder.AppendLine("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</address>");
            }
            if (stakePercentSpecified) xmlBuilder.AppendLine("<stakePercent>" + stakePercent + "</stakePercent>");
            if (backgroundCheckFields != null)
            {
                xmlBuilder.AppendLine("<backgroundCheckFields>");
                backgroundCheckFields.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</backgroundCheckFields>");
            }
        }
    }


    public partial class principalBackgroundCheckFields
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (firstName != null) xmlBuilder.AppendLine("<firstName>" + firstName + "</firstName>");
            if (lastName != null) xmlBuilder.AppendLine("<lastName>" + lastName + "</lastName>");
            if (ssn != null) xmlBuilder.AppendLine("<ssn>" + ssn + "</ssn>");
            if (dateOfBirthSpecified) xmlBuilder.AppendLine("<dateOfBirth>" + dateOfBirth.ToString("yyyy-mm-dd") + "</dateOfBirth>");
            if (driversLicenseState != null) xmlBuilder.AppendLine("<driversLicenseState>" + driversLicenseState + "</driversLicenseState>");
        }
    }

    public partial class legalEntityBackgroundCheckFields
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (legalEntityName != null) xmlBuilder.AppendLine("<legalEntityName>" + legalEntityName + "</legalEntityName>");
            if (legalEntityTypeSpecified) xmlBuilder.AppendLine("<legalEntityType>" + legalEntityType + "</legalEntityType>");
            if (taxId != null) xmlBuilder.AppendLine("<taxId>" + taxId + "</taxId>");
        }
    }

    public partial class subMerchantPrimaryContactUpdatable
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (firstName != null) xmlBuilder.AppendLine("<firstName>" + firstName + "</firstName>");
            if (lastName != null) xmlBuilder.AppendLine("<lastName>" + lastName + "</lastName>");
            if (emailAddress != null) xmlBuilder.AppendLine("<emailAddress>" + emailAddress + "</emailAddress>");
            if (phone != null) xmlBuilder.AppendLine("<phone>" + phone + "</phone>");
        }
    }


    
    public partial class subMerchantPrimaryContact
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.AppendLine("<firstName>" + firstName + "</firstName>");
            xmlBuilder.AppendLine("<lastName>" + lastName + "</lastName>");
            xmlBuilder.AppendLine("<emailAddress>" + emailAddress + "</emailAddress>");
            xmlBuilder.AppendLine("<phone>" + phone + "</phone>");

        }
    }

    public partial class address
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.AppendLine("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if(streetAddress2 != null) xmlBuilder.AppendLine("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            xmlBuilder.AppendLine("<city>" + city + "</city>");
            xmlBuilder.AppendLine("<stateProvince>" + city + "</stateProvince>");
            xmlBuilder.AppendLine("<postalCode>" + city + "</postalCode>");
            xmlBuilder.AppendLine("<countryCode>" + city + "</countryCode>");
        }
    }

    public partial class principalAddress
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (streetAddress1 != null) xmlBuilder.AppendLine("<streetAddress1>" + streetAddress1 + "</streetAddress1>");
            if (streetAddress2 != null) xmlBuilder.AppendLine("<streetAddress2>" + streetAddress2 + "</streetAddress2>");
            if (city != null) xmlBuilder.AppendLine("<city>" + city + "</city>");
            if (stateProvince != null) xmlBuilder.AppendLine("<stateProvince>" + stateProvince + "</stateProvince>");
            if (postalCode != null) xmlBuilder.AppendLine("<postalCode>" + postalCode + "</postalCode>");
            if (countryCode != null) xmlBuilder.AppendLine("<countryCode>" + countryCode + "</countryCode>");
        }
    }


    public partial class legalEntityPrincipal
    {

        public void Serialize(StringBuilder xmlBuilder)
        {
            if(principalIdSpecified) xmlBuilder.AppendLine("<principalId>" + principalId + "</principalId>");
            if(title != null) xmlBuilder.AppendLine("<title>" + title + "</title>");
            xmlBuilder.AppendLine("<firstName>" + firstName + "</firstName>");
            xmlBuilder.AppendLine("<lastName>" + lastName + "</lastName>");
            if(emailAddress != null) xmlBuilder.AppendLine("<emailAddress>" + emailAddress + "</emailAddress>");
            if(ssn != null) xmlBuilder.AppendLine("<ssn>" + ssn + "</ssn>");
            if(contactPhone != null) xmlBuilder.AppendLine("<contactPhone>" + contactPhone + "</contactPhone>");
            xmlBuilder.AppendLine("<dateOfBirth>" + dateOfBirth.ToString("yyyy-mm-dd") + "</dateOfBirth>");
            if(driversLicense != null) xmlBuilder.AppendLine("<driversLicense>" + driversLicense + "</driversLicense>");
            if(driversLicenseState != null) xmlBuilder.AppendLine("<driversLicenseState>" + driversLicenseState + "</driversLicenseState>");
            if (address != null)
            {
                xmlBuilder.AppendLine("<address>");
                address.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</address>");
            }
            xmlBuilder.AppendLine("<stakePercent>" + stakePercent + "</stakePercent>");
            if (principal != null)
            {
                xmlBuilder.AppendLine("<principal>");
                principal.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</principal>");
            }
        }

    }

    public partial class principalResult
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (verificationResult != null)
            {
                xmlBuilder.AppendLine("<verificationResult>");
                verificationResult.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</verificationResult>");
            }
            if (backgroundCheckDecisionNotes != null) xmlBuilder.AppendLine("<backgroundCheckDecisionNotes>" + backgroundCheckDecisionNotes + "</backgroundCheckDecisionNotes>");
        }
    }


    public partial class principalVerificationResult
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (overallScore != null)
            {
                xmlBuilder.AppendLine("<overallScore>");
                overallScore.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</overallScore>");
            }

            if (nameAddressSsnAssociation != null)
            {
                xmlBuilder.AppendLine("<nameAddressSsnAssociation>");
                nameAddressSsnAssociation.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</nameAddressSsnAssociation>");
            }

            if (nameAddressPhoneAssociation != null)
            {
                xmlBuilder.AppendLine("<nameAddressPhoneAssociation>");
                nameAddressPhoneAssociation.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</nameAddressPhoneAssociation>");
            }

            if (verificationIndicators != null)
            {
                xmlBuilder.AppendLine("<verificationIndicators>");
                verificationIndicators.Serialize(xmlBuilder);
                xmlBuilder.AppendLine("</verificationIndicators>");
            }

            if (riskIndicators != null)
            {
                foreach(var riskIndicator in riskIndicators)
                {
                    xmlBuilder.AppendLine("<riskIndicator>");
                    riskIndicator.Serialize(xmlBuilder);
                    xmlBuilder.AppendLine("</riskIndicator>");
                }
            }
        }
    }


    public partial class principalScore
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (scoreSpecified) xmlBuilder.AppendLine("<score>" + score + "</score>");
            if (description != null) xmlBuilder.AppendLine("<description>" + description + "</description>");
        }
    }

    public partial class nameAddressSsnAssociation
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.AppendLine("<code>" + code + "</code>");

            if (description != null) xmlBuilder.AppendLine("<description>" + description + "</description>");
        }
    }

    public partial class principalNameAddressPhoneAssociation
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.AppendLine("<code>" + code + "</code>");

            if (description != null) xmlBuilder.AppendLine("<description>" + description + "</description>");
        }
    }

    public partial class potentialRiskIndicator
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            if (codeSpecified) xmlBuilder.AppendLine("<code>" + code + "</code>");
            if (description != null) xmlBuilder.AppendLine("<description>" + description + "</description>");
        }
    }

    public partial class principalVerificationIndicators
    {
        public void Serialize(StringBuilder xmlBuilder)
        {
            xmlBuilder.AppendLine("<nameVerified>" + nameVerified + "</nameVerified>");
            xmlBuilder.AppendLine("<addressVerified>" + addressVerified + "</addressVerified>");
            xmlBuilder.AppendLine("<phoneVerified>" + phoneVerified + "</phoneVerified>");
            xmlBuilder.AppendLine("<ssnVerified>" + ssnVerified + "</ssnVerified>");
            xmlBuilder.AppendLine("<dobVerified>" + dobVerified + "</dobVerified>");
        }
    }
}
