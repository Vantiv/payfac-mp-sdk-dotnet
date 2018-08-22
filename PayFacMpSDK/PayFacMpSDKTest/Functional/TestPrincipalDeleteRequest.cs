//using PayFacMpSDK;
//using NUnit.Framework;
//using System;
//using System.Text.RegularExpressions;
//using PayFacMpSDK.Properties;
//using System.Globalization;

//namespace PayFacMpSDKTest.Functional
//{
//    [TestFixture]
//    internal class TestPrincipalDeleteRequest
//    {
//        private Communication _communication;
//        private Configuration _config;
//        private string legalEntitytId;
//        private string principalId;

//        [SetUp]
//        public void setUp()
//        {

//        }

//        [Test]
//        public void TestPrincipalDeleteRequestSimple()
//        {
//            legalEntitytId = "201003";
//            principalId = "9";
//            principalDeleteResponse response = new principalDeleteRequest().PrincipalDeleteRequest(legalEntitytId, principalId);
//            Assert.NotNull(response.transactionId);
//            Assert.AreEqual(legalEntitytId, response.legalEntityId);
//            Assert.AreEqual(principalId, response.principalId);
//            Assert.AreEqual("Legal Entity Principal successfully deleted", response.responseDescription);
//        }


//        //[Test]
//        //public void TestGetLegalEntityRetrievalRequestManualReview()
//        //{
//        //    legalEntitytId = "201020";
//        //     legalEntityRetrievalResponse response = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntitytId);
//        //    Assert.AreEqual(legalEntitytId, response.legalEntityId);
//        //    Assert.AreEqual(20, response.responseCode);
//        //    Assert.AreEqual("Manual Review", response.responseDescription);
//        //}





//        //[Test]
//        //public void TestGetLegalEntityRetrievalRequestErrorResponse400()
//        //{
//        //    legalEntitytId = "201400";
//        //    try
//        //    {
//        //        legalEntityRetrievalResponse response = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntitytId);
//        //        Assert.Fail("PayfacWebException expected, None thrown");
//        //    }
//        //    catch (PayFacWebException ex)
//        //    {
//        //        errorResponse errorResponse = ex.errorResponse;
//        //        Assert.NotNull(errorResponse.transactionId);
//        //        Assert.AreEqual("Could not find requested object.", errorResponse.errors[0]);
//        //    }
//        //}

//        //[Test]
//        //public void TestGetLegalEntityRetrievalRequestErrorResponse401()
//        //{
//        //    legalEntitytId = "201401";
//        //    try
//        //    {
//        //        legalEntityRetrievalResponse response = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntitytId);
//        //        Assert.Fail("PayfacWebException expected, None thrown");
//        //    }
//        //    catch (PayFacWebException ex)
//        //    {
//        //        errorResponse errorResponse = ex.errorResponse;
//        //        Assert.NotNull(errorResponse.transactionId);
//        //        Assert.AreEqual("You are not authorized to access this resource. Please check your credentials.", errorResponse.errors[0]);
//        //    }
//        //}

//        //[Test]
//        //public void TestGetLegalEntityRetrievalRequestErrorResponse500()
//        //{
//        //    legalEntitytId = "201500";
//        //    try
//        //    {
//        //        legalEntityRetrievalResponse response = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntitytId);
//        //        Assert.Fail("PayfacWebException expected, None thrown");
//        //    }
//        //    catch (PayFacWebException ex)
//        //    {
//        //        errorResponse errorResponse = ex.errorResponse;
//        //        Assert.NotNull(errorResponse.transactionId);
//        //        Assert.AreEqual("Internal Error. This error has already been escalated to Vantiv for resolution. Please contact support with questions.", errorResponse.errors[0]);
//        //    }
//        //}

//        //[Test]
//        //public void TestGetLegalEntityRetrievalRequestErrorResponse503()
//        //{
//        //    legalEntitytId = "201503";
//        //    try
//        //    {
//        //        legalEntityRetrievalResponse response = new LegalEntityRetrievalRequest().GetLegalEntityRequest(legalEntitytId);
//        //    }
//        //    catch (PayFacWebException ex)
//        //    {
//        //        errorResponse errorResponse = ex.errorResponse;
//        //        Assert.NotNull(errorResponse.transactionId);
//        //        Assert.AreEqual("Service was unavailable.", errorResponse.errors[0]);
//        //    }
//        //}
//    }

//}