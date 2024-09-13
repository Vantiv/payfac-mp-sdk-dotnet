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

        [OneTimeSetUp]
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
            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                         "<legalEntityPrincipalCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                         "<principal>" +
                         "<title>Mr.</title>" +
                         "<firstName>Jon</firstName>" +
                         "<lastName>Snow</lastName>" +
                         "<emailAddress>abc@email.com</emailAddress>" +
                         "<ssn>123450015</ssn>" +
                         "<dateOfBirth>1980-10-12</dateOfBirth>" +
                         "<address>" +
                         "<streetAddress1>p2 street address 1</streetAddress1>" +
                         "<streetAddress2>p2 street address 2</streetAddress2>" +
                         "<city>Boston</city>" +
                         "<stateProvince>MA</stateProvince>" +
                         "<postalCode>01892</postalCode>" +
                         "<countryCode>USA</countryCode>" +
                         "</address>" +
                         "<stakePercent>31</stakePercent>" +
                         "</principal>" +
                         "<sdkVersion>" + Versions.SDK_VERSION + "</sdkVersion>" +
                         "<language>" + Versions.LANGUAGE + "</language>" +
                         "</legalEntityPrincipalCreateRequest>";
            
            var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                                   "<principalCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                                   "    <legalEntityId>2018</legalEntityId>" +
                                   "    <principal>" +
                                   "        <principalId>8</principalId>" +
                                   "        <firstName>Jon</firstName>" +
                                   "        <lastName>Snow</lastName>" +
                                   "        <responseCode>10</responseCode>" +
                                   "        <responseDescription>Approved</responseDescription>" +
                                   "    </principal>" +
                                   "    <transactionId>9251158686</transactionId>" +
                                   "</principalCreateResponse>";
            
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/2018/principal", xmlReq)).Returns(expectedResponse);

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