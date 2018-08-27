using Moq;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestAgreementRetrievalRequest
    {
        private AgreementRetrievalRequest request;
        private legalEntityAgreementRetrievalResponse response;

        [SetUp]
        public void setUp()
        {
            request = new AgreementRetrievalRequest();
        }

        [Test]
        public void TestGetLegalEntityAgreementRequest()
        {
            var expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
                                   "<legalEntityAgreementRetrievalResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
                                   "    <legalEntityId>2010001</legalEntityId>\n" +
                                   "    <transactionId>3187832775</transactionId>\n" +
                                   "    <agreements>\n" +
                                   "        <legalEntityAgreement>\n" +
                                   "            <legalEntityAgreementType>MERCHANT_AGREEMENT</legalEntityAgreementType>\n" +
                                   "            <agreementVersion>agreementVersion1</agreementVersion>\n" +
                                   "            <userFullName>userFullName1</userFullName>\n" +
                                   "            <userSystemName>userSystemName1</userSystemName>\n" +
                                   "            <userIPAddress>196.198.100.100</userIPAddress>\n" +
                                   "            <manuallyEntered>false</manuallyEntered>\n" +
                                   "            <acceptanceDateTime>2017-06-11T13:00:00-05:00</acceptanceDateTime>\n" +
                                   "        </legalEntityAgreement>\n" +
                                   "    </agreements>\n" +
                                   "</legalEntityAgreementRetrievalResponse>";
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Get("/legalentity/2010001/agreement")).Returns(expectedResposne);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;

            response = request.GetLegalEntityAgreementRequest("2010001");
            Assert.AreEqual("2010001", response.legalEntityId);
            Assert.NotNull(response.transactionId);
            Assert.AreEqual(1, response.agreements.Length);
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