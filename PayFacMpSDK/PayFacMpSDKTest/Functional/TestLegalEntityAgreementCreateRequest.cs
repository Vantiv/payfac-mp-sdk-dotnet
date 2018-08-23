using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestLegalEntityAgreementCreateRequest
    {
        private string legalEntityId;
        private legalEntityAgreementCreateRequest request;
        private legalEntityAgreementCreateResponse response;
        
        [SetUp]
        public void setUp()
        {

        }


        [Test]
        public void TestPostLegalEntityCreateRequestSimple()
        {
            legalEntityId = "201003";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
            Assert.NotNull(response.transactionId);
        }
        
        
        [Test]
        public void TestPostLegalEntityCreateRequestDuplicate()
        {
            legalEntityId = "201000";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
            Assert.AreEqual(true, response.duplicate);
            Assert.NotNull(response.transactionId);
        }


        [Test]
        public void TestPostLegalEntityCreateRequestErrorResponse400()
        {
            legalEntityId = "201400";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            try
            {
                response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
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
        public void TestGetLegalEntityRetrievalRequestErrorResponse401()
        {
            legalEntityId = "201401";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            try
            {
                response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
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
        public void TestGetLegalEntityRetrievalRequestErrorResponse500()
        {
            legalEntityId = "201500";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            try
            {
                response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
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
        public void TestGetLegalEntityRetrievalRequestErrorResponse503()
        {
            legalEntityId = "201503";
            request = new legalEntityAgreementCreateRequest
            {
                legalEntityAgreement = new legalEntityAgreement
                {
                    legalEntityAgreementType = legalEntityAgreementType.MERCHANT_AGREEMENT,
                    agreementVersion = "Version1",
                    userFullName = "FullName",
                    userSystemName = "systemUserName",
                    userIPAddress = "127.0.0.1",
                    manuallyEntered = true,
                    acceptanceDateTime = DateTime.Now
                }
            };
            try
            {
                response = request.PostLegalEntityAgreementCreateRequest(legalEntityId);
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