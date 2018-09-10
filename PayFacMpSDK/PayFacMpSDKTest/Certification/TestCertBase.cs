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
        private String streetAdrss1ForTestC1_1;
        private String streetAdrss1ForTestC1_2;
        private String streetAdrss1ForTestC1_3;
        private Random rand;

        [TestFixtureSetUp]
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
            streetAdrss1ForTestC1_1 = "900 Chelmsford St";
            streetAdrss1ForTestC1_2 = "900 Chelmsford St";
            streetAdrss1ForTestC1_3 = "912 Chelmsford St";


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
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "City",
                    stateProvince = "MA",
                    postalCode = "01970",
                    countryCode = "USA"
                },
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
        }


        [Test]
        [Ignore("Added for reference")]
        public void test1()
        {

            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest1;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) + 100000000 + "";

            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();

            Assert.AreEqual(10, response.responseCode);
            Assert.AreEqual("Approved", response.responseDescription);
        }

        [Test]
        [Ignore("Added for reference")]
        public void test2()
        {
            legalEntityCreateRequest.address.streetAddress1 = streetAdrss1ForTest2;
            legalEntityCreateRequest.taxId = (rand.NextDouble() * 9000000000) +100000000 + "";
            legalEntityCreateResponse response = legalEntityCreateRequest.PostLegalEntityCreateRequest();
            Assert.AreEqual(20, response.responseCode);
        }

        [Test]
        [Ignore("Added for reference")]
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


    }
}