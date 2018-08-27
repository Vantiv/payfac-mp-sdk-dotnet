using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;
using System;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestSubMerchantCreateRequest
    {
        private subMerchantCreateRequest request;
        private subMerchantCreateResponse response;

        [SetUp]
        public void setUp()
        {

            request = new subMerchantCreateRequest
            {
                merchantName = "Merchant Name",
                amexMid = "12345",
                discoverConveyedMid = "123456789012345",
                url = "http://merchantUrl",
                customerServiceNumber = "8407809000",
                hardCodedBillingDescriptor = "billing Descriptor",
                maxTransactionAmount = 8400,
                purchaseCurrency = "USD",
                merchantCategoryCode = "5964",
                bankRoutingNumber = "840123124",
                bankAccountNumber = "84012312415",
                pspMerchantId = "123456",
                fraud = new subMerchantFraudFeature
                {
                    enabled = true
                },
                amexAcquired = new subMerchantAmexAcquiredFeature
                {
                    enabled = false
                },
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "City",
                    stateProvince = "MA",
                    postalCode = "01970",
                    countryCode = "USA"
                },
                primaryContact = new subMerchantPrimaryContact
                {
                    firstName = "Josh",
                    lastName = "Doe",
                    emailAddress = "John.Doe@company.com",
                    phone = "9785552222"
                },
                createCredentials = true,
                eCheck = new subMerchantECheckFeature
                {
                    enabled = true,
                    eCheckCompanyName = "Company Name",
                    eCheckBillingDescriptor = "9785552222"
                },
                subMerchantFunding = new subMerchantFunding
                {
                    enabled = false
                },
                settlementCurrency = "USD"
            };

        }

        [Test]
        public void TestPostSubMerchantCreateRequest()
        {

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<subMerchantCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "<merchantName>Merchant Name</merchantName>\n" +
        "<amexMid>12345</amexMid>\n" +
        "<discoverConveyedMid>123456789012345</discoverConveyedMid>\n" +
        "<url>http://merchantUrl</url>\n" +
        "<customerServiceNumber>8407809000</customerServiceNumber>\n" +
        "<hardCodedBillingDescriptor>billing Descriptor</hardCodedBillingDescriptor>\n" +
        "<maxTransactionAmount>8400</maxTransactionAmount>\n" +
        "<purchaseCurrency>USD</purchaseCurrency>\n" +
        "<merchantCategoryCode>5964</merchantCategoryCode>\n" +
        "<bankRoutingNumber>840123124</bankRoutingNumber>\n" +
        "<bankAccountNumber>84012312415</bankAccountNumber>\n" +
        "<pspMerchantId>123456</pspMerchantId>\n" +
        "<fraud enabled=\"true\"></fraud>\n" +
        "<amexAcquired enabled=\"false\"></amexAcquired>\n" +
        "<address>\n" +
        "<streetAddress1>Street Address 1</streetAddress1>\n" +
        "<streetAddress2>Street Address 2</streetAddress2>\n" +
        "<city>City</city>\n" +
        "<stateProvince>MA</stateProvince>\n" +
        "<postalCode>01970</postalCode>\n" +
        "<countryCode>USA</countryCode>\n" +
        "</address>\n" +
        "<primaryContact>\n" +
        "<firstName>Josh</firstName>\n" +
        "<lastName>Doe</lastName>\n" +
        "<emailAddress>John.Doe@company.com</emailAddress>\n" +
        "<phone>9785552222</phone>\n" +
        "</primaryContact>\n" +
        "<createCredentials>true</createCredentials>\n" +
        "<eCheck enabled =\"true\">\n" +
        "<eCheckCompanyName>Company Name</eCheckCompanyName>\n" +
        "<eCheckBillingDescriptor>9785552222</eCheckBillingDescriptor>\n" +
        "</eCheck>\n" +
        "<subMerchantFunding enabled =\"false\">\n" +
        "</subMerchantFunding>\n" +
        "<settlementCurrency>USD</settlementCurrency>\n" +
        "</subMerchantCreateRequest>";

            var expectedRequest = xmlReq.Replace("\n", "\r\n");

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
        "<subMerchantCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
        "    <transactionId>6939508653</transactionId>\n" +
        "    <subMerchantId>12271</subMerchantId>\n" +
        "    <merchantIdentString>G1XN3lxPIA</merchantIdentString>\n" +
        "    <credentials>\n" +
        "        <username>JDoe123</username>\n" +
        "        <password>MyPassword</password>\n" +
        "        <passwordExpirationDate>2016-06-30T23:59:59-05:00</passwordExpirationDate>\n" +
        "    </credentials>\n" +
        "    <paypageCredentials>\n" +
        "        <paypageCredential>\n" +
        "            <username>JDoe123</username>\n" +
        "            <paypageId>1234567890123456</paypageId>\n" +
        "        </paypageCredential>\n" +
        "        <paypageCredential>\n" +
        "            <username>JDoe123</username>\n" +
        "            <paypageId>1234567890123456</paypageId>\n" +
        "        </paypageCredential>\n" +
        "    </paypageCredentials>\n" +
        "    <amexSellerId>12345</amexSellerId>\n" +
        "</subMerchantCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/201003/submerchant", expectedRequest)).Returns(expectedResposne);
            Communication communicationMock = mock.Object;
            request.Communication = communicationMock;
            response = request.PostSubMerchantCreateRequest("201003");
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.subMerchantId);
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