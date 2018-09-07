using PayFacMpSDK;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using PayFacMpSDK.Properties;
using System.Globalization;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    internal class TestAgreementRetrievalRequest
    {
        private string legalEntitytId;

        [SetUp]
        public void setUp()
        {

        }

        [Test]
        public void TestGetLegalEntityAgreementRequestSimple()
        {
            legalEntitytId = "201003";
            legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
            Assert.AreEqual(3, response.agreements.Length);
            Assert.AreEqual(legalEntitytId, response.legalEntityId);
            Assert.NotNull(response.transactionId);
        }


        [Test]
        public void TestGetLegalEntityAgreementRequestNoAgreement()
        {
            legalEntitytId = "201000";
            legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
            Assert.AreEqual(0, response.agreements.Length);
            Assert.AreEqual(legalEntitytId, response.legalEntityId);
            Assert.NotNull(response.transactionId);
        }


        [Test]
        public void TestGetLegalEntityAgreementRequestDefaultAgreement()
        {
            legalEntitytId = "201010";
            legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
            Assert.AreEqual(1, response.agreements.Length);
            Assert.AreEqual(legalEntitytId, response.legalEntityId);
            Assert.NotNull(response.transactionId);
        }


        [Test]
        public void TestGetLegalEntityAgreementRequestErrorResponse400()
        {
            legalEntitytId = "201400";
            try
            {
                legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
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
        public void TestGetLegalEntityAgreementRequestErrorResponse401()
        {
            legalEntitytId = "201401";
            try
            {
                legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
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
        public void TestGetLegalEntityAgreementRequestErrorResponse500()
        {
            legalEntitytId = "201500";
            try
            {
                legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
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
        public void TestGetLegalEntityAgreementRequestErrorResponse503()
        {
            legalEntitytId = "201503";
            try
            {
                legalEntityAgreementRetrievalResponse response = new AgreementRetrievalRequest().GetLegalEntityAgreementRequest(legalEntitytId);
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