using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestLegalEntityPrincipalCreateRequest
    {
        private legalEntityPrincipalCreateRequest request;
        private principalCreateResponse response;
        private string legalEntityId;
        
        [SetUp]
        public void setUp()
        {

        }

        [Test]
        public void TestPostLegalEntityPrincipalCreateRequestSimple()
        {
            legalEntityId = "2018";
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
            Assert.AreEqual(legalEntityId, response.legalEntityId);
            Assert.NotNull(response.principal.principalId);
            Assert.AreEqual("Jon", response.principal.firstName);
            Assert.AreEqual("Snow", response.principal.lastName);
            Assert.AreEqual(10, response.principal.responseCode);
            Assert.AreEqual("Approved", response.principal.responseDescription);
        }
        
        
        [Test]
        public void TestPostLegalEntityPrincipalCreateRequestManualReview()
        {
            legalEntityId = "201820";
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
            Assert.AreEqual(legalEntityId, response.legalEntityId);
            Assert.NotNull(response.principal.principalId);
            Assert.AreEqual("Jon", response.principal.firstName);
            Assert.AreEqual("Snow", response.principal.lastName);
            Assert.AreEqual(20, response.principal.responseCode);
            Assert.AreEqual("Manual Review", response.principal.responseDescription);
        }


        [Test]
        public void TestPostLegalEntityPrincipalCreateRequestErrorResponse400()
        {
            legalEntityId = "201400";
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            try
            {
                response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
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
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            try
            {
                response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
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
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            try
            {
                response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
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
            request = new legalEntityPrincipalCreateRequest
            {
                principal = new legalEntityPrincipal
                {
                    title = "Mr.",
                    firstName = "Jon",
                    lastName = "Snow",
                    emailAddress = "abc@email.com",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    address = new principalAddress
                    {
                        streetAddress1 = "p2 street address 1",
                        streetAddress2 = "p2 street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01892",
                        countryCode = "USA"
                    },
                    stakePercent = 31,
                }
            };
            try
            {
                response = request.PostLegalEntityPrincipalCreateRequest(legalEntityId);
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