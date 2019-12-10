using NUnit.Framework;
using Moq;
using PayFacMpSDK;
using PayFacMpSDK.Properties;
using System.Text;
using System.Linq;
using System;
using System.IO;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestPayFacUtils
    {

        private static Communication _communication = new Communication();
        private static Configuration _configuration = new Configuration();


        [OneTimeSetUp]
        public void setUp()
        {
             
        }

        [TestCase("@Hello World!")]
        [TestCase("0123456789")]
        [TestCase("empty        spaces")]
        public void TestBytesToString(string testString)
        {
            var bytes = Encoding.ASCII.GetBytes(testString).ToList();
            var result = PayFacUtils.BytesToString(bytes);
            Assert.AreEqual(testString, result);
        }

        [Test]
        public void TestStringToBytes()
        {
            const string helloWorld = "@Hello World!";
            var bytes = Encoding.ASCII.GetBytes(helloWorld).ToList();
            var resultBytes = PayFacUtils.StringToBytes(helloWorld);
            for (var i = 0; i < bytes.Count; i++)
            {
                Assert.AreEqual(bytes[i], resultBytes[i]);
            }
        }

        [Test]
        public void TestEncode64()
        {
            string testInput = "TestPassword";
            string testEncodong = "utf-8";
            string result = Convert.ToBase64String(System.Text.Encoding.GetEncoding(testEncodong).GetBytes(testInput));
            string output = PayFacUtils.Encode64(testInput, testEncodong);

            Assert.AreEqual(result, output);
        }


        [Test]
        public void TestDeserializeResponse()
        {

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
            principalCreateResponse testOutput = PayFacUtils.DeserializeResponse<principalCreateResponse>(expectedResponse);

            Assert.AreEqual(testOutput.transactionId, 9251158686);
            Assert.AreEqual(testOutput.legalEntityId, "2018");
        }

        [Test]
        public void TestSendRetrievalRequest()
        {
             
        var expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<legalEntityAgreementRetrievalResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "  <legalEntityId>2010001</legalEntityId>" +
        "  <transactionId>8805390913</transactionId>" +
        "  <agreements>" +
        "    <legalEntityAgreement>" +
        "      <legalEntityAgreementType>MERCHANT_AGREEMENT</legalEntityAgreementType>" +
        "      <agreementVersion>agreementVersion1</agreementVersion>" +
        "      <userFullName>userFullName1</userFullName>" +
        "      <userSystemName>userSystemName1</userSystemName>" +
        "      <userIPAddress>196.198.100.100</userIPAddress>" +
        "      <manuallyEntered>false</manuallyEntered>" +
        "      <acceptanceDateTime>2017-06-11T13:00:00-05:00</acceptanceDateTime>" +
        "    </legalEntityAgreement>" +
        "  </agreements>" +
        "</legalEntityAgreementRetrievalResponse>";
            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Get("/legalentity/2010001/agreement")).Returns(expectedResposne);
            Communication communicationMock = mock.Object;
            string result = PayFacUtils.SendRetrievalRequest("/legalentity/2010001/agreement", _communication, _configuration);
            legalEntityAgreementRetrievalResponse resultObj = PayFacUtils.DeserializeResponse<legalEntityAgreementRetrievalResponse>(result);

            Assert.AreEqual(resultObj.legalEntityId, "2010001");
        }

        [Test]
        public void TestSendDeleteRequest()
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
            string result = PayFacUtils.SendDeleteRequest("/legalentity/2018/principal/9", _communication, _configuration);
            principalDeleteResponse resultObj = PayFacUtils.DeserializeResponse<principalDeleteResponse>(result);

            Assert.AreEqual(resultObj.legalEntityId, "2018");
            Assert.AreEqual(resultObj.principalId, 9);
        }


        [Test]
        public void TestSendPostRequest()
        {

            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<legalEntityAgreementCreateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
        "<legalEntityAgreement>" +
        "<legalEntityAgreementType>MERCHANT_AGREEMENT</legalEntityAgreementType>" +
        "<agreementVersion>Version1</agreementVersion>" +
        "<userFullName>FullName</userFullName>" +
        "<userSystemName>systemUserName</userSystemName>" +
        "<userIPAddress>127.0.0.1</userIPAddress>" +
        "<manuallyEntered>true</manuallyEntered>" +
        "<acceptanceDateTime>" + DateTime.Now.ToString("yyyy-MM-ddThh:mm:sszzz") + "</acceptanceDateTime>" +
        "</legalEntityAgreement>" +
        "</legalEntityAgreementCreateRequest>";

            string expectedResposne = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
        "<legalEntityAgreementCreateResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\" duplicate=\"true\">" +
        "    <transactionId>3529958067</transactionId>" +
        "</legalEntityAgreementCreateResponse>";


            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Post("/legalentity/201000/agreement", xmlReq)).Returns(expectedResposne);
            Communication communicationMock = mock.Object;
            string result = PayFacUtils.SendPostRequest("/legalentity/201000/agreement", xmlReq, _communication, _configuration);
            legalEntityAgreementCreateResponse resultObj = PayFacUtils.DeserializeResponse<legalEntityAgreementCreateResponse>(result);

            Assert.NotNull(resultObj.transactionId);
        }

        [Test]
        public void TestSendPutRequest()
        {

            string legalEntityId = "201003";
            var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                         "<legalEntityUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                         "<address>" +
                         "<streetAddress1>LE Street Address 1</streetAddress1>" +
                         "<streetAddress2>LE Street Address 2</streetAddress2>" +
                         "<city>LE City</city>" +
                         "<stateProvince>MA</stateProvince>" +
                         "<postalCode>01730</postalCode>" +
                         "<countryCode>USA</countryCode>" +
                         "</address>" +
                         "<contactPhone>9785550101</contactPhone>" +
                         "<doingBusinessAs>Other Name Co.</doingBusinessAs>" +
                         "<annualCreditCardSalesVolume>10000000</annualCreditCardSalesVolume>" +
                         "<hasAcceptedCreditCards>true</hasAcceptedCreditCards>" +
                         "<principal>" +
                         "<principalId>9</principalId>" +
                         "<title>CEO</title>" +
                         "<emailAddress>jdoe@mail.net</emailAddress>" +
                         "<contactPhone>9785551234</contactPhone>" +
                         "<address>" +
                         "<streetAddress1>p street address 1</streetAddress1>" +
                         "<streetAddress2>p street address 2</streetAddress2>" +
                         "<city>Boston</city>" +
                         "<stateProvince>MA</stateProvince>" +
                         "<postalCode>01890</postalCode>" +
                         "<countryCode>USA</countryCode>" +
                         "</address>" +
                         "<backgroundCheckFields>" +
                         "<firstName>p first</firstName>" +
                         "<lastName>p last</lastName>" +
                         "<ssn>123459876</ssn>" +
                         "<dateOfBirth>1980-10-12</dateOfBirth>" +
                         "<driversLicense>892327409832</driversLicense>" +
                         "<driversLicenseState>MA</driversLicenseState>" +
                         "</backgroundCheckFields>" +
                         "</principal>" +
                         "<backgroundCheckFields>" +
                         "<legalEntityName>Company Name</legalEntityName>" +
                         "<legalEntityType>INDIVIDUAL_SOLE_PROPRIETORSHIP</legalEntityType>" +
                         "<taxId>123456789</taxId>" +
                         "</backgroundCheckFields>" +
                         "<legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>" +
                         "<yearsInBusiness>10</yearsInBusiness>" +
                         "</legalEntityUpdateRequest>";
            var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                                   "<legalEntityResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
                                   "    <transactionId>6370382523</transactionId>" +
                                   "    <legalEntityId>201003</legalEntityId>" +
                                   "    <responseCode>10</responseCode>" +
                                   "    <responseDescription>Approved</responseDescription>" +
                                   "</legalEntityResponse>";

            var mock = new Mock<Communication>();
            mock.Setup(Communication => Communication.Put("/legalentity/201003", xmlReq)).Returns(expectedResponse);

            Communication communicationMock = mock.Object;
            string result = PayFacUtils.SendPutRequest("/legalentity/201003", xmlReq, _communication, _configuration);
            legalEntityResponse resultObj = PayFacUtils.DeserializeResponse<legalEntityResponse>(result);

            Assert.AreEqual(resultObj.legalEntityId, legalEntityId);
        }

    }
}