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

        [OneTimeSetUp]
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
                settlementCurrency = "USD",
                merchantCategoryTypes = new merchantCategoryTypes
                {
                    categoryTypeField = new System.Collections.Generic.List<string>()
                },
                countryOfOrigin= "USA",
                revenueBoost = new subMerchantRevenueBoostFeature { 
                enabled = true,
                },
                complianceProducts = new complianceProducts
                {
                    productField = new System.Collections.Generic.List<complianceProductsList>()
                }
            };


            var newProduct = new complianceProductsList();
            newProduct.code = complianceProductCode.SAFERPAYMENT;
            newProduct.name = "Doe";
            newProduct.active = true;
            newProduct.activationDate = DateTime.Now;
            newProduct.deActivationDate = DateTime.Now;


            var categoryType = new string("GC");
            var categoryType1 = new string("SM");

            request.complianceProducts.productField.Add(newProduct);

            request.merchantCategoryTypes.categoryTypeField.Add(categoryType);
           // request.merchantCategoryTypes.categoryTypeField.Add(categoryType1);

        }

        [Test]
        public void TestPostSubMerchantCreateRequest()
        {

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<subMerchantCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "<merchantName>Merchant Name</merchantName>" +
        "<amexMid>12345</amexMid>" +
        "<discoverConveyedMid>123456789012345</discoverConveyedMid>" +
        "<url>http://merchantUrl</url>" +
        "<customerServiceNumber>8407809000</customerServiceNumber>" +
        "<hardCodedBillingDescriptor>billing Descriptor</hardCodedBillingDescriptor>" +
        "<maxTransactionAmount>8400</maxTransactionAmount>" +
        "<purchaseCurrency>USD</purchaseCurrency>" +
        "<merchantCategoryCode>5964</merchantCategoryCode>" +
        "<bankRoutingNumber>840123124</bankRoutingNumber>" +
        "<bankAccountNumber>84012312415</bankAccountNumber>" +
        "<pspMerchantId>123456</pspMerchantId>" +
        "<fraud enabled=\"true\"></fraud>" +
        "<amexAcquired enabled=\"false\"></amexAcquired>" +
        "<address>" +
        "<streetAddress1>Street Address 1</streetAddress1>" +
        "<streetAddress2>Street Address 2</streetAddress2>" +
        "<city>City</city>" +
        "<stateProvince>MA</stateProvince>" +
        "<postalCode>01970</postalCode>" +
        "<countryCode>USA</countryCode>" +
        "</address>" +
        "<primaryContact>" +
        "<firstName>Josh</firstName>" +
        "<lastName>Doe</lastName>" +
        "<emailAddress>John.Doe@company.com</emailAddress>" +
        "<phone>9785552222</phone>" +
        "</primaryContact>" +
        "<createCredentials>true</createCredentials>" +
        "<eCheck enabled =\"true\">" +
        "<eCheckCompanyName>Company Name</eCheckCompanyName>" +
        "<eCheckBillingDescriptor>9785552222</eCheckBillingDescriptor>" +
        "</eCheck>" +
        "<subMerchantFunding enabled =\"false\">" +
        "</subMerchantFunding>" +
        "<settlementCurrency>USD</settlementCurrency>" + 
        "<merchantCategoryTypes>" +
        "<categoryType>GC</categoryType>" +
        // "<categoryType>SM</categoryType>" +
        "</merchantCategoryTypes>" +
        "<countryOfOrigin>USA</countryOfOrigin>"+
        "<revenueBoost enabled =\"true\"></revenueBoost>"+
        "<complianceProducts>"+
        "<product>"+
            "<code>SAFERPAYMENT</code>"+
            "<name>Doe</name>"+
            "<active>true</active>"+
            "<activationDate>2025-04-01</activationDate>"+
            "<deActivationDate>2025-04-01</deActivationDate>" +
        "</product>" +
    "</complianceProducts>"+
        "<sdkVersion>" + Versions.SDK_VERSION + "</sdkVersion>" +
        "<language>" + Versions.LANGUAGE + "</language>" +
        "</subMerchantCreateRequest>";

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<subMerchantCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "    <transactionId>6939508653</transactionId>" +
        "    <subMerchantId>12271</subMerchantId>" +
        "    <merchantIdentString>G1XN3lxPIA</merchantIdentString>" +
        "    <credentials>" +
        "        <username>JDoe123</username>" +
        "        <password>MyPassword</password>" +
        "        <passwordExpirationDate>2016-06-30T23:59:59-05:00</passwordExpirationDate>" +
        "    </credentials>" +
        "    <paypageCredentials>" +
        "        <paypageCredential>" +
        "            <username>JDoe123</username>" +
        "            <paypageId>1234567890123456</paypageId>" +
        "        </paypageCredential>" +
        "        <paypageCredential>" +
        "            <username>JDoe123</username>" +
        "            <paypageId>1234567890123456</paypageId>" +
        "        </paypageCredential>" +
        "    </paypageCredentials>" +
        "    <amexSellerId>12345</amexSellerId>" +
        "</subMerchantCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/201003/submerchant", xmlReq)).Returns(expectedResposne);
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