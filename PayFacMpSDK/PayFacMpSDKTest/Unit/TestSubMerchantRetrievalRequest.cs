using Moq;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;
namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestSubMerchantRetrievalRequest
    {
        private SubMerchantRetrievalRequest request;
        private subMerchantRetrievalResponse response;

        [OneTimeSetUp]
        public void setUp()
        {
            request = new SubMerchantRetrievalRequest();
        }

        [Test]
        public void TestGetSubMerchantRequest()
        {
	        var expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
	                               "<subMerchantRetrievalResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
	                               "    <merchantName>Merchant Name</merchantName>\n" +
	                               "    <amexMid>1234567890</amexMid>\n" +
	                               "    <discoverConveyedMid>123456789012345</discoverConveyedMid>\n" +
	                               "    <url>http://merchantUrl.com</url>\n" +
	                               "    <customerServiceNumber>8407809000</customerServiceNumber>\n" +
	                               "    <hardCodedBillingDescriptor>billingDescriptor</hardCodedBillingDescriptor>\n" +
	                               "    <maxTransactionAmount>100000</maxTransactionAmount>\n" +
	                               "    <purchaseCurrency>USD</purchaseCurrency>\n" +
	                               "    <merchantCategoryCode>5964</merchantCategoryCode>\n" +
	                               "    <bankRoutingNumber>840123124</bankRoutingNumber>\n" +
	                               "    <bankAccountNumber>XXXXX-3124</bankAccountNumber>\n" +
	                               "    <pspMerchantId>123456</pspMerchantId>\n" +
	                               "    <fraud enabled=\"false\" />\n" +
	                               "    <address>\n" +
	                               "        <streetAddress1>Street Address 1</streetAddress1>\n" +
	                               "        <streetAddress2>Street Address 2</streetAddress2>\n" +
	                               "        <city>City</city>\n" +
	                               "        <stateProvince>MA</stateProvince>\n" +
	                               "        <postalCode>01970</postalCode>\n" +
	                               "        <countryCode>USA</countryCode>\n" +
	                               "    </address>\n" +
	                               "    <primaryContact>\n" +
	                               "        <firstName>John</firstName>\n" +
	                               "        <lastName>Doe</lastName>\n" +
	                               "        <emailAddress>John.Doe@company.com</emailAddress>\n" +
	                               "        <phone>9785552222</phone>\n" +
	                               "    </primaryContact>\n" +
	                               "    <eCheck enabled=\"true\">\n" +
	                               "        <eCheckCompanyName>Company Name</eCheckCompanyName>\n" +
	                               "        <eCheckBillingDescriptor>9785552222</eCheckBillingDescriptor>\n" +
	                               "    </eCheck>\n" +
	                               "    <subMerchantFunding enabled=\"true\">\n" +
	                               "        <fundingSubmerchantId>12345678901234</fundingSubmerchantId>\n" +
	                               "    </subMerchantFunding>\n" +
	                               "    <settlementCurrency>USD</settlementCurrency>\n" +
	                               "    <subMerchantId>123456</subMerchantId>\n" +
	                               "    <amexSellerId>12345678901234</amexSellerId>\n" +
	                               "    <disabled>true</disabled>\n" +
	                               "    <transactionId>8245606698</transactionId>\n" +
	                               "    <merchantIdentString>011000022</merchantIdentString>\n" +
	                               "    <credentials>\n" +
	                               "        <username>Username</username>\n" +
	                               "        <password>Password</password>\n" +
	                               "        <passwordExpirationDate>2017-10-03T11:18:23.127-04:00</passwordExpirationDate>\n" +
	                               "    </credentials>\n" +
	                               "    <paypageCredentials>\n" +
	                               "        <paypageCredential>\n" +
	                               "            <username>PSPxm1V8</username>\n" +
	                               "            <paypageId>Asd23thI974Jpk32</paypageId>\n" +
	                               "        </paypageCredential>\n" +
	                               "        <paypageCredential>\n" +
	                               "            <username>PSPxm1V8Two</username>\n" +
	                               "            <paypageId>odzhgcbQX3e3EaKV</paypageId>\n" +
	                               "        </paypageCredential>\n" +
	                               "        <paypageCredential>\n" +
	                               "            <username>PSPxm1V8Three</username>\n" +
	                               "            <paypageId>qmnpUBM6G47YJAcq</paypageId>\n" +
	                               "        </paypageCredential>\n" +
	                               "    </paypageCredentials>\n" +
	                               "    <updateDate>2017-09-30T11:18:23.127-04:00</updateDate>\n" +
	                               "</subMerchantRetrievalResponse>";
	        
	        var mock = new Mock<Communication>();
	        mock.Setup(Communication => Communication.Get("/legalentity/2018/submerchant/123456")).Returns(expectedResposne);

	        Communication communicationMock = mock.Object;
	        request.Communication = communicationMock;

	        response = request.GetSubMerchantRequest("2018", "123456");
	        Assert.NotNull(response.transactionId);
	        Assert.AreEqual("123456", response.subMerchantId);
	        Assert.NotNull(response.credentials);
	        Assert.NotNull(response.paypageCredentials);
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