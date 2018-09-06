using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;
using System;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestLegalEntityCreateRequest
    {
        private legalEntityCreateRequest request;
        private legalEntityCreateResponse response;

        [SetUp]
        public void setUp()
        {

            request = new legalEntityCreateRequest
            {
                legalEntityName = "Legal Entity Name",
                legalEntityType = legalEntityType.CORPORATION,
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                doingBusinessAs = "Alternate Business Name",
                taxId = "123456789",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "80000000",
                hasAcceptedCreditCards = true,
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "Boston",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA"
                },
                principal = new legalEntityPrincipal
                {
                    title = "Chief Financial Officer",
                    firstName = "p first",
                    lastName = "p last",
                    emailAddress = "abc@email.com",
                    ssn = "123459876",
                    contactPhone = "7817659800",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    driversLicense = "892327409832",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 33
                },
                yearsInBusiness = "12"
            };

        }

        [Test]
        public void TestPostLegalEntityCreateRequest()
        {

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<legalEntityCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "<legalEntityName>Legal Entity Name</legalEntityName>" +
        "<legalEntityType>CORPORATION</legalEntityType>" +
        "<legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>" +
        "<doingBusinessAs>Alternate Business Name</doingBusinessAs>" +
        "<taxId>123456789</taxId>" +
        "<contactPhone>7817659800</contactPhone>" +
        "<annualCreditCardSalesVolume>80000000</annualCreditCardSalesVolume>" +
        "<hasAcceptedCreditCards>true</hasAcceptedCreditCards>" +
        "<address>" +
        "<streetAddress1>Street Address 1</streetAddress1>" +
        "<streetAddress2>Street Address 2</streetAddress2>" +
        "<city>Boston</city>" +
        "<stateProvince>MA</stateProvince>" +
        "<postalCode>01730</postalCode>" +
        "<countryCode>USA</countryCode>" +
        "</address>" +
        "<principal>" +
        "<title>Chief Financial Officer</title>" +
        "<firstName>p first</firstName>" +
        "<lastName>p last</lastName>" +
        "<emailAddress>abc@email.com</emailAddress>" +
        "<ssn>123459876</ssn>" +
        "<contactPhone>7817659800</contactPhone>" +
        "<dateOfBirth>1980-10-12</dateOfBirth>" +
        "<driversLicense>892327409832</driversLicense>" +
        "<address>" +
        "<streetAddress1>p street address 1</streetAddress1>" +
        "<streetAddress2>p street address 2</streetAddress2>" +
        "<city>Boston</city>" +
        "<stateProvince>MA</stateProvince>" +
        "<postalCode>01890</postalCode>" +
        "<countryCode>USA</countryCode>" +
        "</address>" +
        "<stakePercent>33</stakePercent>" +
        "</principal>" +
        "<yearsInBusiness>12</yearsInBusiness>" +
        "</legalEntityCreateRequest>";

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<legalEntityCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "    <transactionId>2985335872</transactionId>" +
        "    <legalEntityId>21201</legalEntityId>" +
        "    <responseCode>10</responseCode>" +
        "    <responseDescription>Approved</responseDescription>" +
        "    <backgroundCheckResults>" +
        "        <business>" +
        "            <verificationResult>" +
        "                <overallScore>" +
        "                    <score>40</score>" +
        "                    <description>Business identity is confirmed at the input address</description>" +
        "                </overallScore>" +
        "                <nameAddressTaxIdAssociation>" +
        "                    <code>NAME_ADDRESS_TAX_ID</code>" +
        "                    <description>Name, address, and Tax Id verified.</description>" +
        "                </nameAddressTaxIdAssociation>" +
        "                <nameAddressPhoneAssociation>" +
        "                    <code>NAME_ADDRESS_PHONE</code>" +
        "                    <description>Name, address, and phone verified.</description>" +
        "                </nameAddressPhoneAssociation>" +
        "                <verificationIndicators>" +
        "                    <nameVerified>true</nameVerified>" +
        "                    <addressVerified>true</addressVerified>" +
        "                    <cityVerified>true</cityVerified>" +
        "                    <stateVerified>true</stateVerified>" +
        "                    <zipVerified>true</zipVerified>" +
        "                    <phoneVerified>true</phoneVerified>" +
        "                    <taxIdVerified>true</taxIdVerified>" +
        "                </verificationIndicators>" +
        "                <riskIndicators>" +
        "                    <riskIndicator>" +
        "                        <code>PHONE_NUMBER_MOBILE</code>" +
        "                        <description>The submitted phone number is a mobile number.</description>" +
        "                    </riskIndicator>" +
        "                    <riskIndicator>" +
        "                        <code>PHONE_NUMBER_MOBILE</code>" +
        "                        <description>The submitted phone number is a mobile number.</description>" +
        "                    </riskIndicator>" +
        "                </riskIndicators>" +
        "            </verificationResult>" +
        "        </business>" +
        "        <principal>" +
        "            <verificationResult>" +
        "                <overallScore>" +
        "                    <score>50</score>" +
        "                    <description>Full name, address, phone, and SSN verified.</description>" +
        "                </overallScore>" +
        "                <nameAddressSsnAssociation>" +
        "                    <code>FIRST_LAST_ADDRESS_SSN</code>" +
        "                    <description>First name, last name, address, and SSN verified.</description>" +
        "                </nameAddressSsnAssociation>" +
        "                <nameAddressPhoneAssociation>" +
        "                    <code>LAST_ADDRESS_PHONE</code>" +
        "                    <description>Last name, address, and phone number verified.</description>" +
        "                </nameAddressPhoneAssociation>" +
        "                <verificationIndicators>" +
        "                    <nameVerified>true</nameVerified>" +
        "                    <addressVerified>true</addressVerified>" +
        "                    <phoneVerified>true</phoneVerified>" +
        "                    <ssnVerified>true</ssnVerified>" +
        "                    <dobVerified>true</dobVerified>" +
        "                </verificationIndicators>" +
        "                <riskIndicators>" +
        "                    <riskIndicator>" +
        "                        <code>PHONE_NUMBER_MOBILE</code>" +
        "                        <description>The submitted phone number is a mobile number.</description>" +
        "                    </riskIndicator>" +
        "                    <riskIndicator>" +
        "                        <code>PHONE_NUMBER_MOBILE</code>" +
        "                        <description>The submitted phone number is a mobile number.</description>" +
        "                    </riskIndicator>" +
        "                </riskIndicators>" +
        "            </verificationResult>" +
        "        </principal>" +
        "        <businessToPrincipalAssociation>" +
        "            <score>20</score>" +
        "            <description>Principal’s verified address matches input Business address.</description>" +
        "        </businessToPrincipalAssociation>" +
        "        <backgroundCheckDecisionNotes>M45UhpWmualMjGMx3PZH</backgroundCheckDecisionNotes>" +
        "        <bankruptcyData>" +
        "            <bankruptcyType>XrVwb</bankruptcyType>" +
        "            <bankruptcyCount>5</bankruptcyCount>" +
        "            <companyName>Company Name</companyName>" +
        "            <streetAddress1>100 Main Street</streetAddress1>" +
        "            <streetAddress2>Suite 2</streetAddress2>" +
        "            <city>Boston</city>" +
        "            <state>MA</state>" +
        "            <zip>01150</zip>" +
        "            <zip4>2202</zip4>" +
        "            <filingDate>2018-08-27</filingDate>" +
        "        </bankruptcyData>" +
        "        <lienResult>" +
        "            <lienType>0jQyxTbIErx3JmJ</lienType>" +
        "            <releasedCount>7</releasedCount>" +
        "            <unreleasedCount>3</unreleasedCount>" +
        "            <companyName>Company Name</companyName>" +
        "            <streetAddress1>100 Main Street</streetAddress1>" +
        "            <streetAddress2>Suite 2</streetAddress2>" +
        "            <city>Boston</city>" +
        "            <state>MA</state>" +
        "            <zip>01150</zip>" +
        "            <zip4>2202</zip4>" +
        "            <filingDate>2018-08-27</filingDate>" +
        "        </lienResult>" +
        "    </backgroundCheckResults>" +
        "    <principal>" +
        "        <principalId>59217</principalId>" +
        "        <firstName>p_first</firstName>" +
        "        <lastName>p_last</lastName>" +
        "    </principal>" +
        "</legalEntityCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity", xmlReq)).Returns(expectedResposne);
            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PostLegalEntityCreateRequest();
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.legalEntityId);
        }

        [Test]
        public void TestGettersAndSetters()
        {
            // Configuration
            var config = new Configuration();
            request.Configuration = config;
            Assert.AreSame(config, request.Configuration);

            // Communication
            var comm = new Communication();
            request.Communication = comm;
            Assert.AreSame(comm, request.Communication);
        }
    }
}