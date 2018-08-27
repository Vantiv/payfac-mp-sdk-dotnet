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

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<legalEntityCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "<legalEntityName>Legal Entity Name</legalEntityName>\n" +
        "<legalEntityType>CORPORATION</legalEntityType>\n" +
        "<legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>\n" +
        "<doingBusinessAs>Alternate Business Name</doingBusinessAs>\n" +
        "<taxId>123456789</taxId>\n" +
        "<contactPhone>7817659800</contactPhone>\n" +
        "<annualCreditCardSalesVolume>80000000</annualCreditCardSalesVolume>\n" +
        "<hasAcceptedCreditCards>true</hasAcceptedCreditCards>\n" +
        "<address>\n" +
        "<streetAddress1>Street Address 1</streetAddress1>\n" +
        "<streetAddress2>Street Address 2</streetAddress2>\n" +
        "<city>Boston</city>\n" +
        "<stateProvince>MA</stateProvince>\n" +
        "<postalCode>01730</postalCode>\n" +
        "<countryCode>USA</countryCode>\n" +
        "</address>\n" +
        "<principal>\n" +
        "<title>Chief Financial Officer</title>\n" +
        "<firstName>p first</firstName>\n" +
        "<lastName>p last</lastName>\n" +
        "<emailAddress>abc@email.com</emailAddress>\n" +
        "<ssn>123459876</ssn>\n" +
        "<contactPhone>7817659800</contactPhone>\n" +
        "<dateOfBirth>1980-10-12</dateOfBirth>\n" +
        "<driversLicense>892327409832</driversLicense>\n" +
        "<address>\n" +
        "<streetAddress1>p street address 1</streetAddress1>\n" +
        "<streetAddress2>p street address 2</streetAddress2>\n" +
        "<city>Boston</city>\n" +
        "<stateProvince>MA</stateProvince>\n" +
        "<postalCode>01890</postalCode>\n" +
        "<countryCode>USA</countryCode>\n" +
        "</address>\n" +
        "<stakePercent>33</stakePercent>\n" +
        "</principal>\n" +
        "<yearsInBusiness>12</yearsInBusiness>\n" +
        "</legalEntityCreateRequest>";

            var expectedRequest = xmlReq.Replace("\n", "\r\n");

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<legalEntityCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "    <transactionId>2985335872</transactionId>\n" +
        "    <legalEntityId>21201</legalEntityId>\n" +
        "    <responseCode>10</responseCode>\n" +
        "    <responseDescription>Approved</responseDescription>\n" +
        "    <backgroundCheckResults>\n" +
        "        <business>\n" +
        "            <verificationResult>\n" +
        "                <overallScore>\n" +
        "                    <score>40</score>\n" +
        "                    <description>Business identity is confirmed at the input address</description>\n" +
        "                </overallScore>\n" +
        "                <nameAddressTaxIdAssociation>\n" +
        "                    <code>NAME_ADDRESS_TAX_ID</code>\n" +
        "                    <description>Name, address, and Tax Id verified.</description>\n" +
        "                </nameAddressTaxIdAssociation>\n" +
        "                <nameAddressPhoneAssociation>\n" +
        "                    <code>NAME_ADDRESS_PHONE</code>\n" +
        "                    <description>Name, address, and phone verified.</description>\n" +
        "                </nameAddressPhoneAssociation>\n" +
        "                <verificationIndicators>\n" +
        "                    <nameVerified>true</nameVerified>\n" +
        "                    <addressVerified>true</addressVerified>\n" +
        "                    <cityVerified>true</cityVerified>\n" +
        "                    <stateVerified>true</stateVerified>\n" +
        "                    <zipVerified>true</zipVerified>\n" +
        "                    <phoneVerified>true</phoneVerified>\n" +
        "                    <taxIdVerified>true</taxIdVerified>\n" +
        "                </verificationIndicators>\n" +
        "                <riskIndicators>\n" +
        "                    <riskIndicator>\n" +
        "                        <code>PHONE_NUMBER_MOBILE</code>\n" +
        "                        <description>The submitted phone number is a mobile number.</description>\n" +
        "                    </riskIndicator>\n" +
        "                    <riskIndicator>\n" +
        "                        <code>PHONE_NUMBER_MOBILE</code>\n" +
        "                        <description>The submitted phone number is a mobile number.</description>\n" +
        "                    </riskIndicator>\n" +
        "                </riskIndicators>\n" +
        "            </verificationResult>\n" +
        "        </business>\n" +
        "        <principal>\n" +
        "            <verificationResult>\n" +
        "                <overallScore>\n" +
        "                    <score>50</score>\n" +
        "                    <description>Full name, address, phone, and SSN verified.</description>\n" +
        "                </overallScore>\n" +
        "                <nameAddressSsnAssociation>\n" +
        "                    <code>FIRST_LAST_ADDRESS_SSN</code>\n" +
        "                    <description>First name, last name, address, and SSN verified.</description>\n" +
        "                </nameAddressSsnAssociation>\n" +
        "                <nameAddressPhoneAssociation>\n" +
        "                    <code>LAST_ADDRESS_PHONE</code>\n" +
        "                    <description>Last name, address, and phone number verified.</description>\n" +
        "                </nameAddressPhoneAssociation>\n" +
        "                <verificationIndicators>\n" +
        "                    <nameVerified>true</nameVerified>\n" +
        "                    <addressVerified>true</addressVerified>\n" +
        "                    <phoneVerified>true</phoneVerified>\n" +
        "                    <ssnVerified>true</ssnVerified>\n" +
        "                    <dobVerified>true</dobVerified>\n" +
        "                </verificationIndicators>\n" +
        "                <riskIndicators>\n" +
        "                    <riskIndicator>\n" +
        "                        <code>PHONE_NUMBER_MOBILE</code>\n" +
        "                        <description>The submitted phone number is a mobile number.</description>\n" +
        "                    </riskIndicator>\n" +
        "                    <riskIndicator>\n" +
        "                        <code>PHONE_NUMBER_MOBILE</code>\n" +
        "                        <description>The submitted phone number is a mobile number.</description>\n" +
        "                    </riskIndicator>\n" +
        "                </riskIndicators>\n" +
        "            </verificationResult>\n" +
        "        </principal>\n" +
        "        <businessToPrincipalAssociation>\n" +
        "            <score>20</score>\n" +
        "            <description>Principal’s verified address matches input Business address.</description>\n" +
        "        </businessToPrincipalAssociation>\n" +
        "        <backgroundCheckDecisionNotes>M45UhpWmualMjGMx3PZH</backgroundCheckDecisionNotes>\n" +
        "        <bankruptcyData>\n" +
        "            <bankruptcyType>XrVwb</bankruptcyType>\n" +
        "            <bankruptcyCount>5</bankruptcyCount>\n" +
        "            <companyName>Company Name</companyName>\n" +
        "            <streetAddress1>100 Main Street</streetAddress1>\n" +
        "            <streetAddress2>Suite 2</streetAddress2>\n" +
        "            <city>Boston</city>\n" +
        "            <state>MA</state>\n" +
        "            <zip>01150</zip>\n" +
        "            <zip4>2202</zip4>\n" +
        "            <filingDate>2018-08-27</filingDate>\n" +
        "        </bankruptcyData>\n" +
        "        <lienResult>\n" +
        "            <lienType>0jQyxTbIErx3JmJ</lienType>\n" +
        "            <releasedCount>7</releasedCount>\n" +
        "            <unreleasedCount>3</unreleasedCount>\n" +
        "            <companyName>Company Name</companyName>\n" +
        "            <streetAddress1>100 Main Street</streetAddress1>\n" +
        "            <streetAddress2>Suite 2</streetAddress2>\n" +
        "            <city>Boston</city>\n" +
        "            <state>MA</state>\n" +
        "            <zip>01150</zip>\n" +
        "            <zip4>2202</zip4>\n" +
        "            <filingDate>2018-08-27</filingDate>\n" +
        "        </lienResult>\n" +
        "    </backgroundCheckResults>\n" +
        "    <principal>\n" +
        "        <principalId>59217</principalId>\n" +
        "        <firstName>p_first</firstName>\n" +
        "        <lastName>p_last</lastName>\n" +
        "    </principal>\n" +
        "</legalEntityCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity", expectedRequest)).Returns(expectedResposne);
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