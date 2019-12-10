using System;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Certification
{
    [TestFixture]
    [Ignore("Added for reference")]
    public class TestCertificationChargebackApi
    {

        private legalEntityCreateRequest legalEntityCreateRequest;
        private Configuration config;
        private Communication comm;
        private String streetAdrss1ForTest1;
        private String streetAdrss1ForTest2;
        private String streetAdrss1ForTest3;
        //Canada Test
        //private String streetAdrss1ForTestC1_1;
        //private String streetAdrss1ForTestC1_2;
        //private String streetAdrss1ForTestC1_3;
        private Random rand;
        private address CanadaAddress;
        private addressUpdatable addressUpdatable;
        private legalEntityUpdateRequest legalEntityUpdateRequest;
        private principalAddress principalAddress;
        private legalEntityPrincipalUpdatable legalEntityPrincipalUpdatable;
        private legalEntityBackgroundCheckFields legalEntityBackgroundCheckFields;
        private subMerchantCreateRequest subMerchantCreateRequest;
        private subMerchantFunding subMerchantFunding;
        private address address;
        private subMerchantUpdateRequest subMerchantUpdateRequest;
        private subMerchantPrimaryContactUpdatable subMerchantPrimaryContactUpdatable;

       [OneTimeSetUp]
       [Ignore("Added for reference")]
        public void SetUp()
        {
            config = new Configuration();
            config.Set("url", "https://payfac.vantivprelive.com");
            config.Set("username", "SDKMPAPI");
            config.Set("password", "Q2m9X4y6");
            comm = new Communication();

            rand = new Random();

            streetAdrss1ForTest1 = "900 Chelmsford St";
            streetAdrss1ForTest2 = "912 Chelmsford St";
            streetAdrss1ForTest3 = "914 Chelmsford St";
            //Canada Test
            //streetAdrss1ForTestC1_1 = "900 Chelmsford St";
            //streetAdrss1ForTestC1_2 = "900 Chelmsford St";
            //streetAdrss1ForTestC1_3 = "912 Chelmsford St";

            address = new address
            {
                streetAddress1 = "Street Address 1",
                streetAddress2 = "Street Address 2",
                city = "City",
                stateProvince = "MA",
                postalCode = "01970",
                countryCode = "USA"
            };

            CanadaAddress = new address
            {
                streetAddress1 =null,
                streetAddress2 = "Street Address 2",
                city = "City",
                stateProvince = "AB",
                postalCode = "K1A0B1",
                countryCode = "CAN"
            };

            legalEntityCreateRequest = new legalEntityCreateRequest
            {
                legalEntityName = "test legalentity",
                legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                legalEntityOwnershipType = legalEntityOwnershipType.PRIVATE,
                doingBusinessAs = "Alternate Business Name",
                taxId = (100000000 + 900000) + "",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "500000",
                hasAcceptedCreditCards = true,
                address = address,
                principal = new legalEntityPrincipal
                {
                    title = "Chief Financial Officer",
                    firstName = "p first",
                    lastName = "p last",
                    emailAddress = "abc@email.com",
                    ssn = "123459876",
                    contactPhone = "7817659800",
                    dateOfBirth = new DateTime(1980, 10, 12),
                    driversLicense = "892327409832",
                    address = new principalAddress
                    {
                        streetAddress1 = "Street Address 1",
                        streetAddress2 = "Street Address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 100
                },
                yearsInBusiness = "12"
            };

            legalEntityCreateRequest.Configuration = config;
            legalEntityCreateRequest.Communication = comm;

            addressUpdatable = new addressUpdatable
            {
                streetAddress1 = "Street Address 1",
                streetAddress2 = "Street Address 2",
                city = "City",
                stateProvince = "MA",
                postalCode = "01970",
                countryCode = "USA"
            };

            principalAddress = new principalAddress
            {
                streetAddress1 = "Street Address 1",
                streetAddress2 = "Street Address 2",
                city = "City",
                stateProvince = "MA",
                postalCode = "01970",
                countryCode = "USA"
            };

            legalEntityUpdateRequest = new legalEntityUpdateRequest
            {
                address = addressUpdatable,
                contactPhone = "77",
                doingBusinessAs = "Alternate Business Name",
                annualCreditCardSalesVolume = 100000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    title = "CEO",
                    principalId = 1,
                    emailAddress = "abc@gmail.com",
                    contactPhone = "11",
                    address = principalAddress
                }
            };

            legalEntityUpdateRequest.Configuration = config;
            legalEntityUpdateRequest.Communication = comm;

            legalEntityPrincipalUpdatable = new legalEntityPrincipalUpdatable
            {
                title = "CEO",
                principalId = 1,
                emailAddress = "abc@gmail.com",
                contactPhone = "11",
                address = principalAddress
            };

            legalEntityBackgroundCheckFields = new legalEntityBackgroundCheckFields
            {
                legalEntityName = "Company Name",
                legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                taxId = "123456789"
            };

            subMerchantFunding = new subMerchantFunding
            {
                fundingSubmerchantId = "AUTO_GENERATE",
                enabled = true
            };

            subMerchantCreateRequest = new subMerchantCreateRequest
            {
                subMerchantFunding = subMerchantFunding,
                merchantName = "name",
                url = "url",
                customerServiceNumber = "1234567894",
                hardCodedBillingDescriptor = "SDK*",
                maxTransactionAmount = 123,
                merchantCategoryCode = "5137",
                bankRoutingNumber = "211370545",
                bankAccountNumber = "84012312415",
                pspMerchantId = (100 + rand.Next(900)) + "",
                settlementCurrency = "USD",
                address = address,

            };
            subMerchantCreateRequest.Communication = comm;
            subMerchantCreateRequest.Configuration = config;

            subMerchantPrimaryContactUpdatable = new subMerchantPrimaryContactUpdatable
            {
                firstName = "John",
                lastName = "Doe",
                phone = "9785552222"
            };

            subMerchantUpdateRequest = new subMerchantUpdateRequest
            {
                amexMid = "1234567890",
                discoverConveyedMid = "123456789012345",
                url = "http://merchantUrl",
                customerServiceNumber = "8407809000",
                hardCodedBillingDescriptor = "SDK*",
                maxTransactionAmount = 84001,
                bankRoutingNumber = "211370545",
                bankAccountNumber = "84012312415",
                pspMerchantId = (100 + rand.Next(900)) + "",
                purchaseCurrency = "USD",
                address = addressUpdatable,
                primaryContact = subMerchantPrimaryContactUpdatable
            };

        }




        [Test]
        public void test1()
        {

            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();

            Assert.AreEqual(10, response.responseCode);
            Assert.AreEqual("Approved", response.responseDescription);
        }

        [Test]
        public void test2()
        {
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) +100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            Assert.AreEqual(20, response.responseCode);
        }

        [Test]
        public void test2and2a()
        {
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest2 = response.legalEntityId;
            LegalEntityRetrievalRequest reqReq = new LegalEntityRetrievalRequest();
            reqReq.Configuration = config;
            reqReq.Communication = comm;
            legalEntityRetrievalResponse reqResponse = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntityIdFromTest2);
        }

        // Wait a minimum of two hours after submitting Test #2
        [Test]
        public void test2and2b()
        {
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest2 = response.legalEntityId;
            LegalEntityRetrievalRequest reqReq = new LegalEntityRetrievalRequest();
            reqReq.Configuration = config;
            reqReq.Communication = comm;
            legalEntityRetrievalResponse reqResponse = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntityIdFromTest2);
            Assert.AreEqual(10, reqResponse.responseCode);
            Assert.AreEqual("Approved", reqResponse.responseDescription);
        }

        [Test]
        public void test3()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.LIMITED_LIABILITY_COMPANY;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest3;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            
            Assert.AreEqual(10, response.responseCode);
            Assert.AreEqual("Approved", response.responseDescription);
        }

        //Canada Test

        //[Test]
        //public void testC1_1()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;
        //    legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
        //    legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();

        //    Assert.AreEqual(10, response.responseCode);
        //    Assert.AreEqual("Approved", response.responseDescription);
        //}

        //[Test]
        //public void testC1_2()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_2;
        //    legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
        //    legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();

        //    Assert.AreEqual(10, response.responseCode);
        //    Assert.AreEqual("Approved", response.responseDescription);
        //}

        //[Test]
        //public void testC1_3()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.GENERAL_PARTNERSHIP;
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_3;
        //    legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
        //    legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();

        //    Assert.AreEqual(20, response.responseCode);
        //}

        [Test]
        public void test1and4()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = response.legalEntityId;

            legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTest1);
        }

        [Test]
        public void test5()
        {
            try
            {
                legalEntityUpdateRequest.PutLegalEntityUpdateRequest("0");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Request failed - HTTP 400 ErrorError in request: Could not find requested object.", ex.Message);

            }
        }

        //Canada Test

        //[Test]
        //public void testC1_1andC2_2_1()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;


        //    legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = response.legalEntityId;

        //    legalEntityUpdateRequest.doingBusinessAs = "Canada A";
        //    legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_1);

        //}

        //[Test]
        //public void testC1_1andC2_2_2()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;


        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    principalAddress.stateProvince = "XX";
        //    legalEntityPrincipalUpdatable.address = principalAddress;
        //    legalEntityUpdateRequest.principal = legalEntityPrincipalUpdatable;

        //    try
        //    {
        //        legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_1);
        //    } catch (Exception ex)
        //    {
        //        Assert.AreEqual("Postal Code is not valid for country “CAN”.", ex.Message);

        //    }

        //}


        //[Test]
        //public void testC1_1andC2_2_3()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;


        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    principalAddress.postalCode = "01730";
        //    legalEntityPrincipalUpdatable.address = principalAddress;
        //    legalEntityUpdateRequest.principal = legalEntityPrincipalUpdatable;

        //    try
        //    {
        //        legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Postal Code is not valid for country “CAN”.", ex.Message);

        //    }

        //}

        //[Test]
        //public void testC1_3andC2_2_4()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.GENERAL_PARTNERSHIP;
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_3;


        //    legalEntityCreateResponse responseFromTestC1_3 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_3 = responseFromTestC1_3.legalEntityId;

        //    principalAddress.postalCode = "01730";
        //    legalEntityPrincipalUpdatable.address = principalAddress;
        //    legalEntityUpdateRequest.principal = legalEntityPrincipalUpdatable;

        //    try
        //    {
        //        legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_3);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Postal Code “01730” is not valid for country “CAN”.", ex.Message);

        //    }

        //}

        //[Test]
        //public void testC1_1andC2_2_5()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_3;


        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    legalEntityUpdateRequest.doingBusinessAs = "Canada Cert Test C - Update";

        //    try
        //    {
        //        legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Due to its current status, requested Legal Entity is not updatable", ex.Message);

        //    }

        //}

        //[Test]
        //public void testC1_1andC2_2_6()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_3;


        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    legalEntityBackgroundCheckFields.taxId = "123456789";
        //    legalEntityUpdateRequest.backgroundCheckFields = legalEntityBackgroundCheckFields;

        //    try
        //    {
        //        legalEntityUpdateRequest.PutLegalEntityUpdateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Background check fields cannot be updated after background check.", ex.Message);

        //    }

        //}

        [Test]
        public void test2and6()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest2 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest2 = responseFromTest2.legalEntityId;

            LegalEntityRetrievalRequest legalEntityRetrievalResponseObj = new LegalEntityRetrievalRequest();
            legalEntityRetrievalResponseObj.Communication = comm;
            legalEntityRetrievalResponseObj.Configuration = config;

            legalEntityRetrievalResponse response = legalEntityRetrievalResponseObj.GetLegalEntityRequest(legalEntityIdFromTest2);

            Assert.AreEqual(20, response.responseCode);

        }

        [Test]
        public void test7()
        {
            try
            {
                LegalEntityRetrievalRequest legalEntityRetrievalResponseObj = new LegalEntityRetrievalRequest();
                legalEntityRetrievalResponseObj.Communication = comm;
                legalEntityRetrievalResponseObj.Configuration = config;

                legalEntityRetrievalResponse response = legalEntityRetrievalResponseObj.GetLegalEntityRequest("0");
            } catch(Exception ex)
            {
                Assert.AreEqual("Request failed - HTTP 400 ErrorError in request: Could not find requested object.", ex.Message);

            }
        }

        //Canada Test

        //[Test]
        //public void testC1_2andC3_1()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_2;

        //    legalEntityCreateResponse responseFromTestC1_2 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_2 = responseFromTestC1_2.legalEntityId;

        //    LegalEntityRetrievalRequest legalEntityRetrievalRequest = new LegalEntityRetrievalRequest();
        //    legalEntityRetrievalRequest.Communication = comm;
        //    legalEntityRetrievalRequest.Configuration = config;

        //    legalEntityRetrievalResponse response = legalEntityRetrievalRequest.GetLegalEntityRequest(legalEntityIdFromTestC1_2);

        //    Assert.AreEqual(10, response.responseCode);
        //    Assert.AreEqual("Approved", response.responseDescription);
        //}

        //[Test]
        //public void testC3_2()
        //{
        //    try
        //    {
        //        LegalEntityRetrievalRequest legalEntityRetrievalRequest = new LegalEntityRetrievalRequest();
        //        legalEntityRetrievalRequest.Communication = comm;
        //        legalEntityRetrievalRequest.Configuration = config;

        //        legalEntityRetrievalResponse response = legalEntityRetrievalRequest.GetLegalEntityRequest("0");
        //    } catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
        //    }
         
        //}


        //==========================================================================================
        //                             Submerchant certification Tests
        //==========================================================================================


        [Test]
        public void test1and8()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;

            subMerchantCreateResponse response = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);

        }

        [Test]
        public void test9()
        {
            try
            {
                subMerchantCreateResponse response = subMerchantCreateRequest.PostSubMerchantCreateRequest("0");
            } catch(Exception ex)
            {
                Assert.AreEqual("Request failed - HTTP 400 ErrorError in request: Could not find requested object.", ex.Message);
            }
        }

        [Test]
        public void test2and10()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest2 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest2 = responseFromTest2.legalEntityId;

            try
            {
                subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest2);
            } catch (Exception ex)
            {
                Assert.AreEqual("Request failed - HTTP 400 ErrorLegal Entity is in inactive state. You cannot add/update a submerchant.", ex.Message);
            }
        }

        //Canada Test

        //[Test]
        //public void testC1_1andC4_1()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    subMerchantCreateResponse response = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //}

        //[Test]
        //public void testC1_1andC4_2()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    subMerchantCreateRequest.purchaseCurrency = "USD";
        //    subMerchantCreateRequest.settlementCurrency = "CAD";

        //    try
        //    {
        //        subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: No processing group defined with purchaseCurrencyCode <840> and settlementCurrencyCode <124>", ex.Message);
        //    }
        //}

        //[Test]
        //public void testC1_1andC4_3()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    subMerchantCreateRequest.purchaseCurrency = "USD";
        //    subMerchantCreateRequest.address = address;

        //    try
        //    {
        //        subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: Submerchant country code “USA” does not match Legal Entity country code “CAN”", ex.Message);
        //    }
        //}

        //[Test]
        //public void testC1_3andC4_4()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.GENERAL_PARTNERSHIP;
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_3;

        //    legalEntityCreateResponse responseFromTestC1_3 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_3 = responseFromTestC1_3.legalEntityId;

        //    try
        //    {
        //        subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_3);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: Legal Entity “Legal Entity Name” has not been approved", ex.Message);
        //    }
        //}

        //[Test]
        //public void testC1_1andC4_5()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    address.postalCode = "01970";
        //    subMerchantCreateRequest.address = address;
        //    try
        //    {
        //        subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Postal Code “01970” is not valid for country “CAN”.", ex.Message);
        //    }
        //}

        [Test]
        public void test1and8and11()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;


            subMerchantCreateResponse responseFromTest8 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);
            string submerchantIdFromTest8 = responseFromTest8.subMerchantId;

            subMerchantUpdateRequest.PutSubMerchantUpdateRequest(legalEntityIdFromTest1, submerchantIdFromTest8);
        }

        [Test]
        public void test8and12()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;


            subMerchantCreateResponse responseFromTest8 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);
            string submerchantIdFromTest8 = responseFromTest8.subMerchantId;

            try
            {
                subMerchantUpdateRequest.PutSubMerchantUpdateRequest("0", submerchantIdFromTest8);
            } catch (Exception ex)
            {
                Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
            }
        }

        [Test]
        public void test1and13()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;


            subMerchantCreateResponse responseFromTest8 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);
            string submerchantIdFromTest8 = responseFromTest8.subMerchantId;

            try
            {
                subMerchantUpdateRequest.PutSubMerchantUpdateRequest(legalEntityIdFromTest1, "0");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
            }
        }

        //Canada Test

        //[Test]
        //public void testC1_1andC4_1andC5_1()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    subMerchantCreateResponse responseFromTestC4_1 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //    string submerchantIdFromTestC4_1 = responseFromTestC4_1.subMerchantId;

        //    subMerchantUpdateRequest.PutSubMerchantUpdateRequest(legalEntityIdFromTestC1_1, submerchantIdFromTestC4_1);
        //}

        //[Test]
        //public void testC5_2()
        //{
        //    try
        //    {
        //        subMerchantUpdateRequest.PutSubMerchantUpdateRequest("0", "0");
        //    } catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
        //    }
        //}

        //[Test]
        //public void testC1_1andC5_3()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    try
        //    {
        //        subMerchantUpdateRequest.PutSubMerchantUpdateRequest(legalEntityIdFromTestC1_1, "0");
        //    } catch (Exception ex)
        //    {
        //        Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
        //    }
        //}

        [Test]
        public void test1and8and14()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;


            subMerchantCreateResponse responseFromTest8 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);
            string submerchantIdFromTest8 = responseFromTest8.subMerchantId;

            SubMerchantRetrievalRequest subMerchantRetrievalRequest = new SubMerchantRetrievalRequest();
            subMerchantRetrievalRequest.Communication = comm;
            subMerchantRetrievalRequest.Configuration = config;

            subMerchantRetrievalRequest.GetSubMerchantRequest(legalEntityIdFromTest1, submerchantIdFromTest8);
        }


        [Test]
        public void test8and15()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;


            subMerchantCreateResponse responseFromTest8 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTest1);
            string submerchantIdFromTest8 = responseFromTest8.subMerchantId;

            SubMerchantRetrievalRequest subMerchantRetrievalRequest = new SubMerchantRetrievalRequest();
            subMerchantRetrievalRequest.Communication = comm;
            subMerchantRetrievalRequest.Configuration = config;

            try
            {
                subMerchantRetrievalRequest.GetSubMerchantRequest("0", submerchantIdFromTest8);
            } catch (Exception ex)
            {
                Assert.AreEqual("Error in request: Could not find requested object.", ex.Message);
            }
            
        }


        [Test]
        public void test1and16()
        {
            legalEntityCreateRequest.legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP;
            legalEntityCreateRequest.address = address;
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse responseFromTest1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            string legalEntityIdFromTest1 = responseFromTest1.legalEntityId;

            SubMerchantRetrievalRequest subMerchantRetrievalRequest = new SubMerchantRetrievalRequest();
            subMerchantRetrievalRequest.Communication = comm;
            subMerchantRetrievalRequest.Configuration = config;

            try
            {
                subMerchantRetrievalRequest.GetSubMerchantRequest(legalEntityIdFromTest1, "0");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Request failed - HTTP 400 ErrorError in request: Could not find requested object.", ex.Message);
            }
        }

        //Canada Test

        //[Test]
        //public void testC1_1andC4_1and14_2()
        //{
        //    legalEntityCreateRequest.legalEntityType = legalEntityType.CORPORATION;
        //    legalEntityCreateRequest.doingBusinessAs = "Canada Cert Test Legal Entity A";
        //    legalEntityCreateRequest.address = CanadaAddress;
        //    legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTestC1_1;

        //    legalEntityCreateResponse responseFromTestC1_1 = legalEntityCreateRequest.PostLegalEntityCreateRequest();
        //    string legalEntityIdFromTestC1_1 = responseFromTestC1_1.legalEntityId;

        //    subMerchantCreateResponse responseFromTestC4_1 = subMerchantCreateRequest.PostSubMerchantCreateRequest(legalEntityIdFromTestC1_1);
        //    string submerchantIdFromTestC4_1 = responseFromTestC4_1.subMerchantId;

        //    SubMerchantRetrievalRequest subMerchantRetrievalRequest = new SubMerchantRetrievalRequest();
        //    subMerchantRetrievalRequest.Communication = comm;
        //    subMerchantRetrievalRequest.Configuration = config;

        //    subMerchantRetrievalRequest.GetSubMerchantRequest(legalEntityIdFromTestC1_1, submerchantIdFromTestC4_1);

        //}

    }
}