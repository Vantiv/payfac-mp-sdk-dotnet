using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestLegalEntityRetrievalRequest
    {
        private LegalEntityRetrievalRequest request;
        private legalEntityRetrievalResponse response;

        [OneTimeSetUp]
        public void setUp()
        {
            request = new LegalEntityRetrievalRequest();
        }

        [Test]
        public void TestGetMCCRequest()
        {
            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
            "<legalEntityRetrievalResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\" overallStatus=\"Approved\">\n" +
            "    <legalEntityName>Legal Entity Name</legalEntityName>\n" +
            "    <legalEntityType>CORPORATION</legalEntityType>\n" +
            "    <legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>\n" +
            "    <doingBusinessAs>Alternate Name</doingBusinessAs>\n" +
            "    <taxId>123456789</taxId>\n" +
            "    <contactPhone>7817659800</contactPhone>\n" +
            "    <annualCreditCardSalesVolume>80</annualCreditCardSalesVolume>\n" +
            "    <hasAcceptedCreditCards>true</hasAcceptedCreditCards>\n" +
            "    <address>\n" +
            "        <streetAddress1>12 Norton St</streetAddress1>\n" +
            "        <city>City</city>\n" +
            "        <stateProvince>NH</stateProvince>\n" +
            "        <postalCode>03064</postalCode>\n" +
            "        <countryCode>USA</countryCode>\n" +
            "    </address>\n" +
            "    <principal>\n" +
            "        <principalId>1</principalId>\n" +
            "        <title>CEO</title>\n" +
            "        <firstName>p first</firstName>\n" +
            "        <lastName>p last</lastName>\n" +
            "        <emailAddress>emailAddress</emailAddress>\n" +
            "        <ssn>XXXXX-9876</ssn>\n" +
            "        <contactPhone>7817659800</contactPhone>\n" +
            "        <dateOfBirth>1980-10-12</dateOfBirth>\n" +
            "        <driversLicense>XXXXXXXX-9832</driversLicense>\n" +
            "        <driversLicenseState>MA</driversLicenseState>\n" +
            "        <address>\n" +
            "            <streetAddress1>p street address 1</streetAddress1>\n" +
            "            <streetAddress2>p street address 2</streetAddress2>\n" +
            "            <city>Boston</city>\n" +
            "            <stateProvince>MA</stateProvince>\n" +
            "            <postalCode>01890</postalCode>\n" +
            "            <countryCode>USA</countryCode>\n" +
            "        </address>\n" +
            "        <stakePercent>0</stakePercent>\n" +
            "    </principal>\n" +
            "    <legalEntityId>1000293</legalEntityId>\n" +
            "    <responseCode>10</responseCode>\n" +
            "    <responseDescription>Approved</responseDescription>\n" +
            "    <backgroundCheckResults>\n" +
            "        <business>\n" +
            "            <verificationResult>\n" +
            "                <overallScore>\n" +
            "                    <score>10</score>\n" +
            "                    <description>Significant contradictory findings</description>\n" +
            "                </overallScore>\n" +
            "                <nameAddressTaxIdAssociation>\n" +
            "                    <code>NAME_OR_ADDRESS</code>\n" +
            "                    <description>The name or the address is verified.</description>\n" +
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
            "                        <code>UNKNOWN</code>\n" +
            "                        <description>Supplied information could not be not verified.</description>\n" +
            "                    </riskIndicator>\n" +
            "                </riskIndicators>\n" +
            "            </verificationResult>\n" +
            "        </business>\n" +
            "        <principal>\n" +
            "            <verificationResult>\n" +
            "                <overallScore>\n" +
            "                    <score>10</score>\n" +
            "                    <description>OFAC matches</description>\n" +
            "                </overallScore>\n" +
            "                <nameAddressSsnAssociation>\n" +
            "                    <code>NOTHING</code>\n" +
            "                    <description>Supplied information could not be not verified.</description>\n" +
            "                </nameAddressSsnAssociation>\n" +
            "                <nameAddressPhoneAssociation>\n" +
            "                    <code>WRONG_PHONE</code>\n" +
            "                    <description>Supplied Phone number is wrong.</description>\n" +
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
            "                        <code>UNKNOWN</code>\n" +
            "                        <description>Supplied information could not be not verified.</description>\n" +
            "                    </riskIndicator>\n" +
            "                </riskIndicators>\n" +
            "            </verificationResult>\n" +
            "        </principal>\n" +
            "        <businessToPrincipalAssociation>\n" +
            "            <score>10</score>\n" +
            "            <description>Principal’s verified name partially matches input Business name.</description>\n" +
            "        </businessToPrincipalAssociation>\n" +
            "        <backgroundCheckDecisionNotes>Additional Info About Decision</backgroundCheckDecisionNotes>\n" +
            "        <bankruptcyData>\n" +
            "            <bankruptcyType>none</bankruptcyType>\n" +
            "            <bankruptcyCount>1</bankruptcyCount>\n" +
            "            <companyName>Company Name</companyName>\n" +
            "            <streetAddress1>100 Main Street</streetAddress1>\n" +
            "            <streetAddress2>Suite 2</streetAddress2>\n" +
            "            <city>Boston</city>\n" +
            "            <state>MA</state>\n" +
            "            <zip>01150</zip>\n" +
            "            <zip4>2202</zip4>\n" +
            "            <filingDate>2011-05-13</filingDate>\n" +
            "        </bankruptcyData>\n" +
            "        <lienResult>\n" +
            "            <lienType>Subtype of Lien</lienType>\n" +
            "            <releasedCount>2</releasedCount>\n" +
            "            <unreleasedCount>1</unreleasedCount>\n" +
            "            <companyName>Company Name</companyName>\n" +
            "            <streetAddress1>100 Main Street</streetAddress1>\n" +
            "            <streetAddress2>Suite 2</streetAddress2>\n" +
            "            <city>Boston</city>\n" +
            "            <state>MA</state>\n" +
            "            <zip>01150</zip>\n" +
            "            <zip4>2202</zip4>\n" +
            "            <filingDate>2011-05-13</filingDate>\n" +
            "        </lienResult>\n" +
            "    </backgroundCheckResults>\n" +
            "    <transactionId>82820200338801030</transactionId>\n" +
            "    <tinValidationStatus>Approved</tinValidationStatus>\n" +
            "    <sub_merchant_processing_status>true</sub_merchant_processing_status>\n" +
            "</legalEntityRetrievalResponse>";
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Get("/legalentity/1000293")).Returns(expectedResposne);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.GetLegalEntityRequest("1000293");
            Assert.AreEqual("82820200338801030", response.transactionId);
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