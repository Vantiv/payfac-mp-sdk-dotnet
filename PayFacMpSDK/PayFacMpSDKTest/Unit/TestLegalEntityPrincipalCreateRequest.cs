using System;
using Moq;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestLegalEntityPrincipalCreateRequest
    {
        private legalEntityPrincipalCreateRequest request;
        private principalCreateResponse response;
        private string legalEntityId;

        [SetUp]
        public void setUp()
        {
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    ssn = "123450015",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
        }

        [Test]
        public void TestPostLegalEntityPrincipalCreateRequest()
        {
            legalEntityId = "2018";
            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
                         "<legalEntityPrincipalCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
                         "<principal>\n" +
                         "<title>Mr.</title>\n" +
                         "<firstName>Jon</firstName>\n" +
                         "<lastName>Snow</lastName>\n" +
                         "<emailAddress>abc@email.com</emailAddress>\n" +
                         "<ssn>123450015</ssn>\n" +
                         "<dateOfBirth>1980-10-12</dateOfBirth>\n" +
                         "<address>\n" +
                         "<streetAddress1>p2 street address 1</streetAddress1>\n" +
                         "<streetAddress2>p2 street address 2</streetAddress2>\n" +
                         "<city>Boston</city>\n" +
                         "<stateProvince>MA</stateProvince>\n" +
                         "<postalCode>01892</postalCode>\n" +
                         "<countryCode>USA</countryCode>\n" +
                         "</address>\n" +
                         "<stakePercent>31</stakePercent>\n" +
                         "</principal>\n" +
                         "</legalEntityPrincipalCreateRequest>";
            
            var expectedRequest = xmlReq.Replace("\n", "\r\n");
            
            var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
                                   "<principalCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
                                   "    <legalEntityId>2018</legalEntityId>\n" +
                                   "    <principal>\n" +
                                   "        <principalId>8</principalId>\n" +
                                   "        <firstName>Jon</firstName>\n" +
                                   "        <lastName>Snow</lastName>\n" +
                                   "        <responseCode>10</responseCode>\n" +
                                   "        <responseDescription>Approved</responseDescription>\n" +
                                   "    </principal>\n" +
                                   "    <transactionId>9251158686</transactionId>\n" +
                                   "</principalCreateResponse>";
            
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/2018/principal", expectedRequest)).Returns(expectedResponse);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
            
            Assert.AreEqual(legalEntityId, response.legalEntityId);
            Assert.NotNull(response.principal);
            Assert.NotNull(response.transactionId);
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