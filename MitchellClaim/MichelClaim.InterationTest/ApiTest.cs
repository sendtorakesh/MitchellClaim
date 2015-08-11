using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.IO;

namespace MichelClaim.InterationTest
{
    [TestClass]
    public class ApiTest
    {
        public string ServiceUrl { get; set; }
        [TestInitialize]
        public void Setup()
        {

            ServiceUrl = "http://localhost:50072/api/mitchellclaim";
        }

        [TestMethod]
        public void Verify_Claim_Can_Be_Created()
        {

        }

        [TestMethod]
        public void Verify_Claim_List_Can_Be_Retrieved()
        {
            //returns json response by default
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(ServiceUrl).Result;

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Assert.IsNotNull(responseContent);
            }

            //returns xml as well
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                var response = client.GetAsync(ServiceUrl).Result;

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Assert.IsNotNull(responseContent);
            }
        }

        [TestMethod]
        public void Verify_claim_can_be_created_JSON()
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(ServiceUrl, new StringContent(Payload.ClaimDataJson, Encoding.UTF8, "application/json")).Result;
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                var result = response.Content.ReadAsStringAsync().Result;
                Assert.IsNotNull(result);
            }
        }


        //xml povided doesnt serialize properly with serilized contract
        //need more investigation why that is not working
        [TestMethod]
        public void Verify_claim_can_be_created_XML()
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader inputQueryReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\create-claim.xml"))
            {
                sb.Append(inputQueryReader.ReadToEnd());
            }

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders
                var response = client.PostAsync(ServiceUrl, new StringContent(sb.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                var result = response.Content.ReadAsStringAsync().Result;
                Assert.IsNotNull(result);
            }
        }
    }

    public class Payload
    {
        public const string ClaimDataJson = 
            @"{""claimNumberField"": ""22c9c23bac142856018ce14a26b6c299"",
    ""claimantFirstNameField"": ""George"",
    ""claimantLastNameField"": ""Washington"",
    ""statusField"": 0,
    ""statusFieldSpecified"": false,
    ""lossDateField"": ""2015-08-11T01:04:10.6688628-07:00"",
    ""lossDateFieldSpecified"": false,
    ""lossInfoField"": {
      ""causeOfLossField"": 0,
      ""causeOfLossFieldSpecified"": false,
      ""reportedDateField"": ""2015-08-11T01:04:10.6693619-07:00"",
      ""reportedDateFieldSpecified"": false,
      ""lossDescriptionField"": ""Crashed into an apple tree"",
      ""<ID>k__BackingField"": 0
    },
    ""assignedAdjusterIDField"": 12345,
    ""assignedAdjusterIDFieldSpecified"": false,
    ""vehiclesField"": [
      {
        ""modelYearField"": 2015,
        ""makeDescriptionField"": ""Ford"",
        ""modelDescriptionField"": ""Mustang"",
        ""engineDescriptionField"": ""EcoBoost"",
        ""exteriorColorField"": ""Deep Impact Blue"",
        ""vinField"": ""1M8GDM9AXKP042788"",
        ""licPlateField"": ""N01PRES"",
        ""licPlateStateField"": ""CA"",
        ""licPlateExpDateField"": ""2015-08-11T01:04:10.6698619-07:00"",
        ""licPlateExpDateFieldSpecified"": false,
        ""damageDescriptionField"": ""Front end smashed"",
        ""mileageField"": 1776,
        ""mileageFieldSpecified"": false,
        ""<ID>k__BackingField"": 0
      }
    ],
    ""<ID>k__BackingField"": 0
  }";
            
        
        
    }
}
