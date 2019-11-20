using PayFacMpSDK;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using PayFacMpSDK.Properties;
using System.Globalization;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    internal class TestSubmerchantRetrievalRequest
    {
        private string legalEntitytId;
        private string submerchantId;

        [OneTimeSetUp]
        public void setUp()
        {

        }

        [Test]
        public void TestGetSubMerchantRequest()
        {
            legalEntitytId = "201003";
            submerchantId = "1234567";
            subMerchantRetrievalResponse response = new SubMerchantRetrievalRequest().GetSubMerchantRequest(legalEntitytId, submerchantId);
            Assert.AreEqual(submerchantId, response.subMerchantId);
        }


        [Test]
        public void TesGetSubMerchantRequestErrorResponse400()
        {
            legalEntitytId = "201400";
            submerchantId = "1234567";
            try
            {
            subMerchantRetrievalResponse response = new SubMerchantRetrievalRequest().GetSubMerchantRequest(legalEntitytId, submerchantId);
            Assert.Fail("PayfacWebException expected, None thrown");
            }
            catch (PayFacWebException ex)
            {
                errorResponse errorResponse = ex.errorResponse;
                Assert.NotNull(errorResponse.transactionId);
                Assert.AreEqual("Could not find requested object.", errorResponse.errors[0]);
            }
        }

        [Test]
        public void TestGetSubMerchantRequestErrorResponse401()
        {
            legalEntitytId = "201401";
            submerchantId = "1234567";
            try
            {
            subMerchantRetrievalResponse response = new SubMerchantRetrievalRequest().GetSubMerchantRequest(legalEntitytId, submerchantId);
            Assert.Fail("PayfacWebException expected, None thrown");
            }
            catch (PayFacWebException ex)
            {
                errorResponse errorResponse = ex.errorResponse;
                Assert.NotNull(errorResponse.transactionId);
                Assert.AreEqual("You are not authorized to access this resource. Please check your credentials.", errorResponse.errors[0]);
            }
        }

        [Test]
        public void TestGetSubMerchantRequestErrorResponse500()
        {
            legalEntitytId = "201500";
            submerchantId = "1234567";
            try
            {
            subMerchantRetrievalResponse response = new SubMerchantRetrievalRequest().GetSubMerchantRequest(legalEntitytId, submerchantId);
            Assert.Fail("PayfacWebException expected, None thrown");
            }
            catch (PayFacWebException ex)
            {
                errorResponse errorResponse = ex.errorResponse;
                Assert.NotNull(errorResponse.transactionId);
                Assert.AreEqual("Internal Error. This error has already been escalated to Vantiv for resolution. Please contact support with questions.", errorResponse.errors[0]);
            }
        }

        [Test]
        public void TestGetSubMerchantRequestErrorResponse503()
        {
            legalEntitytId = "201503";
            submerchantId = "1234567";
            try
            {
            subMerchantRetrievalResponse response = new SubMerchantRetrievalRequest().GetSubMerchantRequest(legalEntitytId, submerchantId);
            Assert.Fail("PayfacWebException expected, None thrown");
            }
            catch (PayFacWebException ex)
            {
                errorResponse errorResponse = ex.errorResponse;
                Assert.NotNull(errorResponse.transactionId);
                Assert.AreEqual("Service was unavailable.", errorResponse.errors[0]);
            }
        }
    }

}