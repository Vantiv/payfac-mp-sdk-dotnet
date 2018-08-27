using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestMCCRetrievalRequest
    {
        private MCCRetrievalRequest request;
        private approvedMccResponse response;

        [SetUp]
        public void setUp()
        {
            request = new MCCRetrievalRequest();
        }

        [Test]
        public void TestGetMCCRequest()
        {
            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"+
                "<approvedMccResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">"+
                    "<transactionId>0190924847</transactionId>"+
                    "<approvedMccs>"+
                    "<approvedMcc>5967</approvedMcc>"+
                    "<approvedMcc>5970</approvedMcc>"+
                    "</approvedMccs>"+
                "</approvedMccResponse>";
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Get("/mcc")).Returns(expectedResposne);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.GetMCCRequest();
            Assert.AreEqual("5967", response.approvedMccs[0]);
            Assert.AreEqual("5970", response.approvedMccs[1]);
            Assert.AreEqual(190924847, response.transactionId);
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