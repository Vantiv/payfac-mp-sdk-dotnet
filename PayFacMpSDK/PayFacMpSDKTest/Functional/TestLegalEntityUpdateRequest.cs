using System;
using NUnit.Framework;
using PayFacMpSDK;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    public class TestLegalEntityUpdateRequest
    {
        private string legalEntityId;
        private legalEntityUpdateRequest request;
        private legalEntityResponse response;

        [SetUp]
        public void setUp()
        {

        }


        [Test]
        public void TestPutLegalEntityUpdateRequestSimple()
        {
            legalEntityId = "201003";
            request = new legalEntityUpdateRequest
            {
                address = new addressUpdatable
                {
                    streetAddress1 = "LE Street Address 1",
                    streetAddress2 = "LE Street Address 2",
                    city = "LE City",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA",
                },
                contactPhone = "9785550101",
                doingBusinessAs = "Other Name Co.",
                annualCreditCardSalesVolume = 10000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    principalId = 9,
                    title = "CEO",
                    emailAddress = "jdoe@mail.net",
                    contactPhone = "9785551234",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA",
                    },
                    backgroundCheckFields = new principalBackgroundCheckFields
                    {
                        firstName = "p first",
                        lastName = "p last",
                        ssn = "123459876",
                        dateOfBirth = new DateTime(1980, 10, 12),
                        driversLicense = "892327409832",
                        driversLicenseState = "MA"
                    },
                },
                backgroundCheckFields = new legalEntityBackgroundCheckFields
                {
                    legalEntityName = "Company Name",
                    legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                    taxId = "123456789"
                },
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                yearsInBusiness = "10"
            };

            response = request.PutLegalEntityUpdateRequest(legalEntityId);
            Assert.NotNull(response.transactionId);
            Assert.AreEqual(10,response.responseCode);
            Assert.AreEqual("Approved", response.responseDescription);
            Assert.AreEqual("201003", response.legalEntityId);

        }

        [Test]
        public void TestPutLegalEntityUpdateRequestErrorResponse400()
        {
            legalEntityId = "201400";
            request = new legalEntityUpdateRequest
            {
                address = new addressUpdatable
                {
                    streetAddress1 = "LE Street Address 1",
                    streetAddress2 = "LE Street Address 2",
                    city = "LE City",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA",
                },
                contactPhone = "9785550101",
                doingBusinessAs = "Other Name Co.",
                annualCreditCardSalesVolume = 10000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    principalId = 9,
                    title = "CEO",
                    emailAddress = "jdoe@mail.net",
                    contactPhone = "9785551234",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA",
                    },
                    backgroundCheckFields = new principalBackgroundCheckFields
                    {
                        firstName = "p first",
                        lastName = "p last",
                        ssn = "123459876",
                        dateOfBirth = new DateTime(1980, 10, 12),
                        driversLicense = "892327409832",
                        driversLicenseState = "MA"
                    },
                },
                backgroundCheckFields = new legalEntityBackgroundCheckFields
                {
                    legalEntityName = "Company Name",
                    legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                    taxId = "123456789"
                },
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                yearsInBusiness = "10"
            };
            try
            {
                response = request.PutLegalEntityUpdateRequest(legalEntityId);
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
        public void TestPutLegalEntityUpdateRequestErrorResponse401()
        {
            legalEntityId = "201401";
            request = new legalEntityUpdateRequest
            {
                address = new addressUpdatable
                {
                    streetAddress1 = "LE Street Address 1",
                    streetAddress2 = "LE Street Address 2",
                    city = "LE City",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA",
                },
                contactPhone = "9785550101",
                doingBusinessAs = "Other Name Co.",
                annualCreditCardSalesVolume = 10000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    principalId = 9,
                    title = "CEO",
                    emailAddress = "jdoe@mail.net",
                    contactPhone = "9785551234",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA",
                    },
                    backgroundCheckFields = new principalBackgroundCheckFields
                    {
                        firstName = "p first",
                        lastName = "p last",
                        ssn = "123459876",
                        dateOfBirth = new DateTime(1980, 10, 12),
                        driversLicense = "892327409832",
                        driversLicenseState = "MA"
                    },
                },
                backgroundCheckFields = new legalEntityBackgroundCheckFields
                {
                    legalEntityName = "Company Name",
                    legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                    taxId = "123456789"
                },
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                yearsInBusiness = "10"
            };
            try
            {
                response = request.PutLegalEntityUpdateRequest(legalEntityId);
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
        public void TestPutLegalEntityUpdateRequestErrorResponse500()
        {
            legalEntityId = "201500";
            request = new legalEntityUpdateRequest
            {
                address = new addressUpdatable
                {
                    streetAddress1 = "LE Street Address 1",
                    streetAddress2 = "LE Street Address 2",
                    city = "LE City",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA",
                },
                contactPhone = "9785550101",
                doingBusinessAs = "Other Name Co.",
                annualCreditCardSalesVolume = 10000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    principalId = 9,
                    title = "CEO",
                    emailAddress = "jdoe@mail.net",
                    contactPhone = "9785551234",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA",
                    },
                    backgroundCheckFields = new principalBackgroundCheckFields
                    {
                        firstName = "p first",
                        lastName = "p last",
                        ssn = "123459876",
                        dateOfBirth = new DateTime(1980, 10, 12),
                        driversLicense = "892327409832",
                        driversLicenseState = "MA"
                    },
                },
                backgroundCheckFields = new legalEntityBackgroundCheckFields
                {
                    legalEntityName = "Company Name",
                    legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                    taxId = "123456789"
                },
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                yearsInBusiness = "10"
            };
            try
            {
                response = request.PutLegalEntityUpdateRequest(legalEntityId);
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
        public void TestPutLegalEntityUpdateRequestErrorResponse503()
        {
            legalEntityId = "201503";
            request = new legalEntityUpdateRequest
            {
                address = new addressUpdatable
                {
                    streetAddress1 = "LE Street Address 1",
                    streetAddress2 = "LE Street Address 2",
                    city = "LE City",
                    stateProvince = "MA",
                    postalCode = "01730",
                    countryCode = "USA",
                },
                contactPhone = "9785550101",
                doingBusinessAs = "Other Name Co.",
                annualCreditCardSalesVolume = 10000000,
                hasAcceptedCreditCards = true,
                principal = new legalEntityPrincipalUpdatable
                {
                    principalId = 9,
                    title = "CEO",
                    emailAddress = "jdoe@mail.net",
                    contactPhone = "9785551234",
                    address = new principalAddress
                    {
                        streetAddress1 = "p street address 1",
                        streetAddress2 = "p street address 2",
                        city = "Boston",
                        stateProvince = "MA",
                        postalCode = "01890",
                        countryCode = "USA",
                    },
                    backgroundCheckFields = new principalBackgroundCheckFields
                    {
                        firstName = "p first",
                        lastName = "p last",
                        ssn = "123459876",
                        dateOfBirth = new DateTime(1980, 10, 12),
                        driversLicense = "892327409832",
                        driversLicenseState = "MA"
                    },
                },
                backgroundCheckFields = new legalEntityBackgroundCheckFields
                {
                    legalEntityName = "Company Name",
                    legalEntityType = legalEntityType.INDIVIDUAL_SOLE_PROPRIETORSHIP,
                    taxId = "123456789"
                },
                legalEntityOwnershipType = legalEntityOwnershipType.PUBLIC,
                yearsInBusiness = "10"
            };
            try
            {
                response = request.PutLegalEntityUpdateRequest(legalEntityId);
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