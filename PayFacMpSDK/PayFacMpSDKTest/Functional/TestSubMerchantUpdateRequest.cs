using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestSubMerchantUpdateRequest
    {
        private string legalEntityId;
        private string subMerchantId;
        private subMerchantUpdateRequest request;
        private response response;

        [OneTimeSetUp]
        public void setUp()
        {

        }


        [Test]
        public void TestPutSubMerchantUpdateRequestSimple()
        {
            legalEntityId = "201003";
            subMerchantId = "9";

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
                disable = true,
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
                },
                subMerchantFunding = new subMerchantFunding
                {
                    enabled = true,

                },
                merchantCategoryTypes = new merchantCategoryTypes
                {
                    categoryType = "GC",

                },
                methodOfPayments = new methodOfPayments
                {
                    method = new paymentMethod
                    {
                        paymentType = "VISA",
                        selectedTransactionType = "NONE",


                    }

                }  
            };

            response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
            Assert.NotNull(response.transactionId);
        }

        [Test]
        public void TestPutSubMerchantUpdateRequestErrorResponse400()
        {
            legalEntityId = "201400";
            subMerchantId = "9";

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
            try
            {
                response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
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
        public void TestPutSubMerchantUpdateRequestErrorResponse401()
        {
            legalEntityId = "201401";
            subMerchantId = "9";

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
            try
            {
                response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
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
        public void TestPutSubMerchantUpdateRequestErrorResponse500()
        {
            legalEntityId = "201500";
            subMerchantId = "9";

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
            try
            {
                response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
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
        public void TestPutSubMerchantUpdateRequestErrorResponse503()
        {
            legalEntityId = "201503";
            subMerchantId = "9";

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
            try
            {
                response = request.PutSubMerchantUpdateRequest(legalEntityId, subMerchantId);
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