using PayFacMpSDK;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using PayFacMpSDK.Properties;
using System.Globalization;

namespace PayFacMpSDKTest.Functional
{
    [TestFixture]
    internal class TestMCCRetrievalRequest
    {

        [SetUp]
        public void setUp()
        {

        }

        [Test]
        public void GetMCCRequest()
        {
            approvedMccResponse response = new MCCRetrievalRequest().GetMCCRequest();

            Assert.AreEqual("5967", response.approvedMccs[0]);
            Assert.AreEqual("5970", response.approvedMccs[1]);
            Assert.NotNull(response.transactionId);
        }

       
    }

}