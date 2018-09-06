using Moq;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestSubMerchantUpdateRequest
    {
        private subMerchantUpdateRequest request;
        private response response;
        private string legalEntityId;
        private string subMerchantId;

        [SetUp]
        public void SetUp()
        {
            request = new subMerchantUpdateRequest
            {
                amexMid = "1234567890",
                discoverConveyedMid = "123456789012345",
                url = "http://merchantUrl",
                customerServiceNumber = "8407809000",
                hardCodedBillingDescriptor = "Descriptor",
                maxTransactionAmount = 8400,
                bankRoutingNumber = "840123124",
                bankAccountNumber = "84012312415",
                pspMerchantId = "785412365",
                purchaseCurrency = "USD",
                address = new addressUpdatable
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "City",
                    stateProvince = "MA",
                    postalCode = "01970"
                },
                primaryContact = new subMerchantPrimaryContactUpdatable
                {
                    firstName = "John",
                    lastName = "Doe",
                    phone = "9785552222"
                },
                fraud = new subMerchantFraudFeature()
                {
                    enabled = true
                },
                amexAcquired = new subMerchantAmexAcquiredFeature
                {
                    enabled = true
                },
                eCheck = new subMerchantECheckFeature
                {
                    enabled = true,
                    eCheckBillingDescriptor = "9785552222",
                }
            };
        }

        [Test]
        public void PutSubMerchantUpdateRequest()
        {
            legalEntityId = "201003";
            subMerchantId = "9";

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                         "<subMerchantUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                         "<amexMid>1234567890</amexMid>" +
                         "<discoverConveyedMid>123456789012345</discoverConveyedMid>" +
                         "<url>http://merchantUrl</url>" +
                         "<customerServiceNumber>8407809000</customerServiceNumber>" +
                         "<hardCodedBillingDescriptor>Descriptor</hardCodedBillingDescriptor>" +
                         "<maxTransactionAmount>8400</maxTransactionAmount>" +
                         "<bankRoutingNumber>840123124</bankRoutingNumber>" +
                         "<bankAccountNumber>84012312415</bankAccountNumber>" +
                         "<pspMerchantId>785412365</pspMerchantId>" +
                         "<purchaseCurrency>USD</purchaseCurrency>" +
                         "<address>" +
                         "<streetAddress1>Street Address 1</streetAddress1>" +
                         "<streetAddress2>Street Address 2</streetAddress2>" +
                         "<city>City</city>" +
                         "<stateProvince>MA</stateProvince>" +
                         "<postalCode>01970</postalCode>" +
                         "</address>" +
                         "<primaryContact>" +
                         "<firstName>John</firstName>" +
                         "<lastName>Doe</lastName>" +
                         "<phone>9785552222</phone>" +
                         "</primaryContact>" +
                         "<fraud enabled=\"true\"></fraud>" +
                         "<amexAcquired enabled=\"true\"></amexAcquired>" +
                         "<eCheck enabled=\"true\">" +
                         "<eCheckBillingDescriptor>9785552222</eCheckBillingDescriptor>" +
                         "</eCheck>" +
                         "</subMerchantUpdateRequest>";

            var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                                   "<response xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                                   "    <transactionId>9766925103</transactionId>" +
                                   "</response>";
            
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Put("/legalentity/201003/submerchant/9", xmlReq)).Returns(expectedResponse);

            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
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