using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestPrincipalDeleteRequest
    {
        private principalDeleteRequest request;
        private principalDeleteResponse response;

        [OneTimeSetUp]
        public void setUp()
        {
            request = new principalDeleteRequest();
        }

        [Test]
        public void TestPrincipalDeleteRequestMethod()
        {
            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<principalDeleteResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "    <transactionId>4234049185</transactionId>\n" +
        "    <legalEntityId>2018</legalEntityId>\n" +
        "    <principalId>9</principalId>\n" +
        "    <responseDescription>Legal Entity Principal successfully deleted</responseDescription>\n" +
        "</principalDeleteResponse>";
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Delete("/legalentity/2018/principal/9")).Returns(expectedResposne);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PrincipalDeleteRequest("2018", "9");
            Assert.NotNull(response.transactionId);
            Assert.AreEqual("2018", response.legalEntityId);
            Assert.AreEqual(9, response.principalId);
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