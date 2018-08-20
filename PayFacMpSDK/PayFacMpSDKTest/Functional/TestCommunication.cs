using PayFacMpSDK;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    internal class TestCommunication
    {
        private Communication _communication;
        private Configuration _config;


        [SetUp]
        public void setUp()
        {
            _communication = new Communication();
            _config = new Configuration();
            _communication.SetAuth(_config.Get("username"), _config.Get("password"));
            _communication.SetContentType("application/com.vantivcnp.payfac-v13+xml");
            _communication.SetAccept("application/com.vantivcnp.payfac-v13+xml");
            _communication.SetHost(_config.Get("url"));
            _communication.SetProxy(_config.Get("proxyHost"), _config.Get("proxyPort"));
        }

        [Test]
        public void TestGet()
        {
            string expected = @"<.xml version=.* encoding=.* standalone=.*?>.*<approvedMccResponse xmlns=.*>.*<transactionId>.*</transactionId>.*<approvedMccs>.*<approvedMcc>5967</approvedMcc>.*<approvedMcc>5970</approvedMcc>.*</approvedMccs>.*</approvedMccResponse>.*";
            var regex = new Regex(expected, RegexOptions.Multiline);
            string xmlResponse = _communication.Get("/mcc");
            xmlResponse = Regex.Replace(xmlResponse, @"\t|\n|\r", "");
            Console.WriteLine(xmlResponse);
            Assert.True(regex.IsMatch(xmlResponse));
        }


        [Test]
        public void TestPost()
        {
            string request = 
                "<legalEntityAgreementCreateRequest" + " xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
                    "<legalEntityAgreement>\n" +
                        "<legalEntityAgreementType>MERCHANT_AGREEMENT</legalEntityAgreementType>\n" +
                        "<agreementVersion>agreementVersion1</agreementVersion>\n" +
                        "<userFullName>userFullName</userFullName>\n" +
                        "<userSystemName>systemUserName</userSystemName>\n" +
                        "<userIPAddress>196.198.100.100</userIPAddress>\n" +
                        "<manuallyEntered>false</manuallyEntered>\n" +
                        "<acceptanceDateTime>2017-02-11T12:00:00-06:00</acceptanceDateTime>\n" +
                    "</legalEntityAgreement>\n" +
                "</legalEntityAgreementCreateRequest>";
            string xmlResponse = _communication.Post("/legalentity/1234567/agreement", request);
            xmlResponse = Regex.Replace(xmlResponse, @"\t|\n|\r", "");
            string expected = @"<.xml version=.* encoding=.* standalone=.*?>.*<legalEntityAgreementCreateResponse xmlns=.*>.* <transactionId>.*</transactionId>.*</legalEntityAgreementCreateResponse>";
            var regex = new Regex(expected, RegexOptions.Multiline);
            Assert.True(regex.IsMatch(xmlResponse));
        }


        [Test]
        public void TestPut()
        {
            string request = 
               "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n"+
                    "<subMerchantUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n"+
                        "<amexMid>1234567890</amexMid>\n"+
                        "<discoverConveyedMid>123456789012345</discoverConveyedMid>\n"+
                        "<url>http://merchantUrl</url>\n"+
                        "<customerServiceNumber>8407809000</customerServiceNumber>\n"+
                        "<hardCodedBillingDescriptor>Descriptor</hardCodedBillingDescriptor>\n"+
                        "<maxTransactionAmount>8400</maxTransactionAmount>\n"+
                        "<bankRoutingNumber>840123124</bankRoutingNumber>\n"+
                        "<bankAccountNumber>84012312415</bankAccountNumber>\n"+
                        "<pspMerchantId>785412365</pspMerchantId>\n"+
                        "<purchaseCurrency>USD</purchaseCurrency>\n"+
                        "<address>\n"+
                            "<streetAddress1>Street Address 1</streetAddress1>\n"+
                            "<streetAddress2>Street Address 2</streetAddress2>\n"+
                            "<city>City</city>\n"+
                            "<stateProvince>MA</stateProvince>\n"+
                            "<postalCode>01970</postalCode>\n"+
                        "</address>\n"+
                        "<primaryContact>\n"+
                            "<firstName>John</firstName>\n"+
                            "<lastName>Doe</lastName>\n"+
                            "<phone>9785552222</phone>\n"+
                        "</primaryContact>\n"+
                        "<fraud enabled=\"true\"></fraud>\n"+
                        "<amexAcquired enabled=\"true\"></amexAcquired>\n"+
                        "<eCheck enabled=\"true\">\n"+
                        "<eCheckBillingDescriptor>9785552222</eCheckBillingDescriptor>\n"+
                        "</eCheck>\n"+
                    "</subMerchantUpdateRequest>";
            string xmlResponse = _communication.Put("/legalentity/2018/submerchant/123456", request);
            xmlResponse = Regex.Replace(xmlResponse, @"\t|\n|\r", "");
            string expected = @"<.xml version=.* encoding=.* standalone=.*?>.*<response xmlns=.*>.*<transactionId>.*</transactionId>.*</response>";
            var regex = new Regex(expected, RegexOptions.Multiline);
            Assert.True(regex.IsMatch(xmlResponse));
        }

        [Test]
        public void TestDelete()
        {
            string expected = @"<.xml version=.* encoding=.* standalone=.*?>.*<principalDeleteResponse xmlns=.*>.*<transactionId>.*</transactionId>.*<legalEntityId>2018</legalEntityId>.*<principalId>9</principalId>.*<responseDescription>Legal Entity Principal successfully deleted</responseDescription>.*</principalDeleteResponse>";
            var regex = new Regex(expected, RegexOptions.Multiline);
            string xmlResponse = _communication.Delete("/legalentity/2018/principal/9");
            xmlResponse = Regex.Replace(xmlResponse, @"\t|\n|\r", "");
            Console.WriteLine(xmlResponse);
            Assert.True(regex.IsMatch(xmlResponse));
        }
    }

}