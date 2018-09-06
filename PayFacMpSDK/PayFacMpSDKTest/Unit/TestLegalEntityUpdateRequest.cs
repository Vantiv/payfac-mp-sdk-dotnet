using System;
using Moq;
using NUnit.Framework;
using PayFacMpSDK;
using PayFacMpSDK.Properties;

namespace PayFacMpSDKTest.Unit
{
    [TestFixture]
    public class TestLegalEntityUpdateRequest
    {
        private legalEntityUpdateRequest request;
        private legalEntityResponse response;
        private string legalEntityId;

        [SetUp]
        public void SetUp()
        {
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
        }
        
        [Test]
        public void TestPutLegalEntityUpdateRequest()
        {
            legalEntityId = "201003";
	        var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
	                     "<legalEntityUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
	                     "<address>" +
	                     "<streetAddress1>LE Street Address 1</streetAddress1>" +
	                     "<streetAddress2>LE Street Address 2</streetAddress2>" +
	                     "<city>LE City</city>" +
	                     "<stateProvince>MA</stateProvince>" +
	                     "<postalCode>01730</postalCode>" +
	                     "<countryCode>USA</countryCode>" +
	                     "</address>" +
	                     "<contactPhone>9785550101</contactPhone>" +
	                     "<doingBusinessAs>Other Name Co.</doingBusinessAs>" +
	                     "<annualCreditCardSalesVolume>10000000</annualCreditCardSalesVolume>" +
	                     "<hasAcceptedCreditCards>true</hasAcceptedCreditCards>" +
	                     "<principal>" +
	                     "<principalId>9</principalId>" +
	                     "<title>CEO</title>" +
	                     "<emailAddress>jdoe@mail.net</emailAddress>" +
	                     "<contactPhone>9785551234</contactPhone>" +
	                     "<address>" +
	                     "<streetAddress1>p street address 1</streetAddress1>" +
	                     "<streetAddress2>p street address 2</streetAddress2>" +
	                     "<city>Boston</city>" +
	                     "<stateProvince>MA</stateProvince>" +
	                     "<postalCode>01890</postalCode>" +
	                     "<countryCode>USA</countryCode>" +
	                     "</address>" +
	                     "<backgroundCheckFields>" +
	                     "<firstName>p first</firstName>" +
	                     "<lastName>p last</lastName>" +
	                     "<ssn>123459876</ssn>" +
	                     "<dateOfBirth>1980-10-12</dateOfBirth>" +
	                     "<driversLicense>892327409832</driversLicense>" +
	                     "<driversLicenseState>MA</driversLicenseState>" +
	                     "</backgroundCheckFields>" +
	                     "</principal>" +
	                     "<backgroundCheckFields>" +
	                     "<legalEntityName>Company Name</legalEntityName>" +
	                     "<legalEntityType>INDIVIDUAL_SOLE_PROPRIETORSHIP</legalEntityType>" +
	                     "<taxId>123456789</taxId>" +
	                     "</backgroundCheckFields>" +
	                     "<legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>" +
	                     "<yearsInBusiness>10</yearsInBusiness>" +
	                     "</legalEntityUpdateRequest>";
	        Assert.AreEqual(xmlReq, request.Serialize());
	        var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
	                               "<legalEntityResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">" +
	                               "    <transactionId>6370382523</transactionId>" +
	                               "    <legalEntityId>201003</legalEntityId>" +
	                               "    <responseCode>10</responseCode>" +
	                               "    <responseDescription>Approved</responseDescription>" +
	                               "</legalEntityResponse>";
	        
	        var mock = new Mock<Communication>();
	        mock.Setup(Communication => Communication.Put("/legalentity/201003", xmlReq)).Returns(expectedResponse);

	        Communication communicationMock = mock.Object;
	        request.Communication = communicationMock;
	        response = request.PutLegalEntityUpdateRequest(legalEntityId);
	        
	        Assert.AreEqual(10, response.responseCode);
	        Assert.AreEqual("Approved", response.responseDescription);
	        Assert.AreEqual(legalEntityId, response.legalEntityId);
	        Assert.NotNull(response.transactionId);
        }
	    
	    [Test]
	    public void TestGettersAndSetters()
	    {
            
		    // Configuration
		    var config = new Configuration();
		    request.Configuration = config;
		    Assert.AreSame(config, request.Configuration);
            
		    // Communication
		    var comm = new Communication();
		    request.Communication = comm;
		    Assert.AreSame(comm, request.Communication);
	    }
    }
}