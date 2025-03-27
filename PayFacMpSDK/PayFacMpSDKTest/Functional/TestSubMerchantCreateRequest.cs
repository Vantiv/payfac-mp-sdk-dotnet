using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestSubMerchantCreateRequest
    {
        private string legalEntityId;
        private subMerchantCreateRequest request;
        private subMerchantCreateResponse response;

        [OneTimeSetUp]
        public void setUp()
        {

        }


        [Test]
        public void TestPostSubMerchantCreateRequestSimple()
        {
            legalEntityId = "201003";

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
                revenueBoost = new subMerchantRevenueBoostFeature
                {
                    enabled = true
                }
            };

            var categoryType = new string("GC");
            var categoryType1 = new string("SM");

            request.merchantCategoryTypes.categoryTypeField.Add(categoryType);
            request.merchantCategoryTypes.categoryTypeField.Add(categoryType1);


            response = request.PostSubMerchantCreateRequest(legalEntityId);
            Assert.NotNull(response.transactionId);
        }


        [Test]
        public void TestPostSubMerchantCreateRequestDuplicateAllMatching()
        {
            legalEntityId = "201003";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate all matching",
                amexMid = "1234567890",
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
                    firstName = "John",
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
                countryOfOrigin = "USA",
                revenueBoost = new subMerchantRevenueBoostFeature
                {
                    enabled = true
                }
            };

            response = request.PostSubMerchantCreateRequest(legalEntityId);
            Assert.AreEqual(true, response.duplicate);
            Assert.NotNull(response.transactionId);
            Assert.IsNull(response.originalSubMerchant);
        }


        [Test]
        public void TestPostSubMerchantCreateRequestDuplicateNotMatching()
        {
            legalEntityId = "201003";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate not matching",
                amexMid = "1234567890",
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
                    enabled = false,
                   // eCheckCompanyName = "Company Name",
                   // eCheckBillingDescriptor = "9785552222"
                },
                subMerchantFunding = new subMerchantFunding
                {
                    enabled = false
                },
                settlementCurrency = "USD",
                countryOfOrigin = "USA",
                revenueBoost = new subMerchantRevenueBoostFeature
                {
                    enabled = true
                },
                complianceProducts = new complianceProducts
                {
                    productField = new System.Collections.Generic.List<complianceProductsList>()
                }
            };


            var newMethod = new complianceProductsList();
            newMethod.code = complianceProductCode.SAFERPAYMENT;
            newMethod.name = "Doe";
            newMethod.active = false;
           

            request.complianceProducts.productField.Add(newMethod);

            response = request.PostSubMerchantCreateRequest(legalEntityId);
            Assert.AreEqual(true, response.duplicate);
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.originalSubMerchant);
        }

        [Test]
        public void TestPostSubMerchantCreateRequestErrorResponse400()
        {
            legalEntityId = "2010400";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate not matching",
                amexMid = "1234567890",
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

            try
            {
                response = request.PostSubMerchantCreateRequest(legalEntityId);
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
        public void TestPostSubMerchantCreateRequestErrorResponse401()
        {
            legalEntityId = "2010401";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate not matching",
                amexMid = "1234567890",
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

            try
            {
                response = request.PostSubMerchantCreateRequest(legalEntityId);
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
        public void TestPostSubMerchantCreateRequestErrorResponse500()
        {
            legalEntityId = "2010500";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate not matching",
                amexMid = "1234567890",
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

            try
            {
                response = request.PostSubMerchantCreateRequest(legalEntityId);
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
        public void TestPostSubMerchantCreateRequestErrorResponse503()
        {
            legalEntityId = "2010503";

            request = new subMerchantCreateRequest
            {
                merchantName = "duplicate not matching",
                amexMid = "1234567890",
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

            try
            {
                response = request.PostSubMerchantCreateRequest(legalEntityId);
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