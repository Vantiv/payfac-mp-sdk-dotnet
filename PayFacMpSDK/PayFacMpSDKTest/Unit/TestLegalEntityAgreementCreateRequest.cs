using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;
using System;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestLegalEntityAgreementCreateRequest
    {
        private legalEntityAgreementCreateRequest request;
        private legalEntityAgreementCreateResponse response;

        [SetUp]
        public void setUp()
        {

            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };

        }

        [Test]
        public void TestPostLegalEntityAgreementCreateRequest()
        {

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<legalEntityAgreementCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "<legalEntityAgreement>\n" +
        "<legalEntityAgreementType>MERCHANT_AGREEMENT</legalEntityAgreementType>\n" +
        "<agreementVersion>Version1</agreementVersion>\n" +
        "<userFullName>FullName</userFullName>\n" +
        "<userSystemName>systemUserName</userSystemName>\n" +
        "<userIPAddress>127.0.0.1</userIPAddress>\n" +
        "<manuallyEntered>true</manuallyEntered>\n" +
        "<acceptanceDateTime>" + DateTime.Now.ToString("yyyy-MM-ddThh:mm:sszzz") + "</acceptanceDateTime>\n" +
        "</legalEntityAgreement>\n" +
        "</legalEntityAgreementCreateRequest>";

            var expectedRequest = xmlReq.Replace("\n", "\r\n");

            Assert.AreEqual(expectedRequest, request.Serialize());

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<legalEntityAgreementCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\" duplicate=\"true\">\n" +
        "    <transactionId>3529958067</transactionId>\n" +
        "</legalEntityAgreementCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/201000/agreement", expectedRequest)).Returns(expectedResposne);
            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PostLegalEntityAgreementCreateRequest("201000");
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