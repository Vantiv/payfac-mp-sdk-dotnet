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
	        var xmlReq = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
	                     "<legalEntityUpdateRequest xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
	                     "<address>\n" +
	                     "<streetAddress1>LE Street Address 1</streetAddress1>\n" +
	                     "<streetAddress2>LE Street Address 2</streetAddress2>\n" +
	                     "<city>LE City</city>\n" +
	                     "<stateProvince>MA</stateProvince>\n" +
	                     "<postalCode>01730</postalCode>\n" +
	                     "<countryCode>USA</countryCode>\n" +
	                     "</address>\n" +
	                     "<contactPhone>9785550101</contactPhone>\n" +
	                     "<doingBusinessAs>Other Name Co.</doingBusinessAs>\n" +
	                     "<annualCreditCardSalesVolume>10000000</annualCreditCardSalesVolume>\n" +
	                     "<hasAcceptedCreditCards>true</hasAcceptedCreditCards>\n" +
	                     "<principal>\n" +
	                     "<principalId>9</principalId>\n" +
	                     "<title>CEO</title>\n" +
	                     "<emailAddress>jdoe@mail.net</emailAddress>\n" +
	                     "<contactPhone>9785551234</contactPhone>\n" +
	                     "<address>\n" +
	                     "<streetAddress1>p street address 1</streetAddress1>\n" +
	                     "<streetAddress2>p street address 2</streetAddress2>\n" +
	                     "<city>Boston</city>\n" +
	                     "<stateProvince>MA</stateProvince>\n" +
	                     "<postalCode>01890</postalCode>\n" +
	                     "<countryCode>USA</countryCode>\n" +
	                     "</address>\n" +
	                     "<backgroundCheckFields>\n" +
	                     "<firstName>p first</firstName>\n" +
	                     "<lastName>p last</lastName>\n" +
	                     "<ssn>123459876</ssn>\n" +
	                     "<dateOfBirth>1980-10-12</dateOfBirth>\n" +
	                     "<driversLicense>892327409832</driversLicense>\n" +
	                     "<driversLicenseState>MA</driversLicenseState>\n" +
	                     "</backgroundCheckFields>\n" +
	                     "</principal>\n" +
	                     "<backgroundCheckFields>\n" +
	                     "<legalEntityName>Company Name</legalEntityName>\n" +
	                     "<legalEntityType>INDIVIDUAL_SOLE_PROPRIETORSHIP</legalEntityType>\n" +
	                     "<taxId>123456789</taxId>\n" +
	                     "</backgroundCheckFields>\n" +
	                     "<legalEntityOwnershipType>PUBLIC</legalEntityOwnershipType>\n" +
	                     "<yearsInBusiness>10</yearsInBusiness>\n" +
	                     "</legalEntityUpdateRequest>";
	        var expectedRequest = xmlReq.Replace("\n", "\r\n");
	        Assert.AreEqual(expectedRequest, request.Serialize());
	        var expectedResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
	                               "<legalEntityResponse xmlns=\"http://payfac.vantivcnp.com/api/merchant/onboard\">\n" +
	                               "    <transactionId>6370382523</transactionId>\n" +
	                               "    <legalEntityId>201003</legalEntityId>\n" +
	                               "    <responseCode>10</responseCode>\n" +
	                               "    <responseDescription>Approved</responseDescription>\n" +
	                               "</legalEntityResponse>";
	        
	        var mock = new Mock<Communication>();
	        mock.Setup(Communication => Communication.Put("/legalentity/201003", expectedRequest)).Returns(expectedResponse);

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