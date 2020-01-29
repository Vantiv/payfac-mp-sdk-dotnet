using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestLegalEntityCreateRequest
    {
        private legalEntityCreateRequest request;
        private legalEntityCreateResponse response;

        [OneTimeSetUp]
        public void setUp()
        {

        }

        [Test]
        public void TestPostLegalEntityCreateRequestSimple()
        {
            request = new legalEntityCreateRequest
            {
                legalEntityName = "Legal Entity Name",
                legalEntityType = legalEntityType.CORPORATION,
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                doingBusinessAs = "Alternate Business Name",
                taxId = "123456789",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "80000000",
                hasAcceptedCreditCards = true,
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "Boston",
                    stateProvince = "MA",
                    postalCode = "01730",
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
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 33
                },
                yearsInBusiness = "12"
            };

            response = request.PostLegalEntityCreateRequest();
            Assert.NotNull(response.transactionId);
            Console.WriteLine(response.legalEntityId);
            Assert.NotNull(response.legalEntityId);
            Assert.NotNull(response.principal);
            Console.WriteLine(response.originalLegalEntityId);
            Assert.AreEqual(10, response.responseCode);
            Assert.AreEqual("Approved", response.responseDescription);
        }


        [Test]
        public void TestPostLegalEntityCreateRequestManualReview()
        {
            request = new legalEntityCreateRequest
            {
                legalEntityName = "Legal Entity Name",
                legalEntityType = legalEntityType.CORPORATION,
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                doingBusinessAs = "Alternate Business Name",
                taxId = "123456720",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "80000000",
                hasAcceptedCreditCards = true,
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "Boston",
                    stateProvince = "MA",
                    postalCode = "01730",
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
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 33
                },
                yearsInBusiness = "12"
            };

            response = request.PostLegalEntityCreateRequest();
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.legalEntityId);
            Assert.NotNull(response.principal);
            Assert.AreEqual(20, response.responseCode);
            Assert.AreEqual("Manual Review", response.responseDescription);
        }


        [Test]
        public void TestPostLegalEntityCreateRequestDuplicateSimple()
        {
            request = new legalEntityCreateRequest
            {
                legalEntityName = "Legal Entity Name",
                legalEntityType = legalEntityType.CORPORATION,
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                doingBusinessAs = "duplicate",
                taxId = "123456700",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "80000000",
                hasAcceptedCreditCards = true,
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "Boston",
                    stateProvince = "MA",
                    postalCode = "01730",
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
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 33
                },
                yearsInBusiness = "12"
            };

            response = request.PostLegalEntityCreateRequest();
            Assert.AreEqual(true, response.duplicate);
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.originalLegalEntityId);
            Assert.AreEqual("Approved", response.originalLegalEntityStatus);
        }


        [Test]
        public void TestPostLegalEntityCreateRequestDuplicateDeclined()
        {
            request = new legalEntityCreateRequest
            {
                legalEntityName = "Legal Entity Name",
                legalEntityType = legalEntityType.CORPORATION,
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                doingBusinessAs = "duplicate",
                taxId = "123456740",
                contactPhone = "7817659800",
                annualCreditCardSalesVolume = "80000000",
                hasAcceptedCreditCards = true,
                address = new address
                {
                    streetAddress1 = "Street Address 1",
                    streetAddress2 = "Street Address 2",
                    city = "Boston",
                    stateProvince = "MA",
                    postalCode = "01730",
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
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA"
                    },
                    stakePercent = 33
                },
                yearsInBusiness = "12"
            };

            response = request.PostLegalEntityCreateRequest();
            Assert.AreEqual(true, response.duplicate);
            Assert.NotNull(response.transactionId);
            Assert.NotNull(response.originalLegalEntityId);
            Assert.AreEqual("Declined", response.originalLegalEntityStatus);
        }

        [Test]
        public void testLegalEntityOriginal()
        {
            var request = new legalEntityCreateRequest
            {
                legalEntityName = "Yarrgh Pirate Co.",
                legalEntityType = legalEntityType.LIMITED_LIABILITY_COMPANY,
                legalEntityOwnershipType = legalEntityOwnershipType.PRIVATE,
                doingBusinessAs = "Jolly Roger Services",
                taxId = "551351516",
                contactPhone = "5555555555",
                annualCreditCardSalesVolume = "0",
                hasAcceptedCreditCards = false,
                address = new address()
                {
                    streetAddress1 = "2223 Executive Dr",
                    city = "Suite 104",
                    stateProvince = "DT",
                    postalCode = "48201",
                    countryCode = "USA"
                },
                principal = new legalEntityPrincipal
                {
                    firstName = "Joeya",
                    lastName = "Schmoeya",
                    emailAddress = "joe2a@example.com",
                    ssn = "111111113",
                    contactPhone = "1111111111",
                    dateOfBirth = (new DateTime(1982, 1, 31)),
                    address = new principalAddress()
                    {
                        streetAddress1 = "900 Chelmsford St",
                        streetAddress2 = "Ste 5",
                        city = "Royal Oak",
                        stateProvince = "MI",
                        postalCode = "48067",
                        countryCode = "USA"
                    },
                    stakePercent = 100
                },
                yearsInBusiness = "0",
            };
            var response = request.PostLegalEntityCreateRequest();
            if (response.legalEntityId == null)
            {
                Assert.NotNull(response.originalLegalEntityId);
                Assert.NotNull(response.originalLegalEntityStatus, null);
            }
        }
    }
}