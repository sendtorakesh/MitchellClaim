using MitchellClaim.Common;
using MitchellClaim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MitchellClaim.Controllers
{
    /// <summary>
    /// Manages to handle all the request 
    /// </summary>
    public class MitchellClaimController : ApiController
    {
        private readonly IMitchellClaimService _mitchellClaimService;

        public MitchellClaimController(IMitchellClaimService mitchellClaimService)
        {
            _mitchellClaimService = mitchellClaimService;
        }
        // GET api/mitchellclaim
        public List<MitchellClaimType> Get()
        {
            var testXml = new MitchellClaimType();
            testXml.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            testXml.ClaimantFirstName = "George";
            testXml.ClaimantLastName = "Washington";
            testXml.Status = Model.StatusCode.OPEN;
            testXml.LossDate = DateTime.Now;
            testXml.LossInfo = new LossInfoType()
            {
                CauseOfLoss = CauseOfLossCode.Collision,
                ReportedDate = DateTime.Now,
                LossDescription = "Crashed into an apple tree"
            };

            testXml.AssignedAdjusterID = 12345;
            testXml.Vehicles = new VehicleInfoType[]{new VehicleInfoType()
                {
                    Vin = "1M8GDM9AXKP042788",
                    ModelYear = 2015,
                    MakeDescription = "Ford",
                    ModelDescription = "Mustang",
                    EngineDescription = "EcoBoost",
                    ExteriorColor = "Deep Impact Blue",
                    LicPlate = "N01PRES",
                    LicPlateState="CA",
                    LicPlateExpDate = DateTime.Now,
                    DamageDescription="Front end smashed",
                    Mileage= 1776
                }

                };
            return new List<MitchellClaimType>() {
                testXml
            };
            //return _mitchellClaimService.GetClaims();
        }

        // GET api/mitchellclaim/id
        public IHttpActionResult Get(string claimNumer)
        {
            return Ok();
            //var testXml = new MitchellClaimType();
            //testXml.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            //testXml.ClaimantFirstName = "George";
            //testXml.ClaimantLastName = "Washington";
            //testXml.Status = Model.StatusCode.OPEN;
            //testXml.LossDate = DateTime.Now;
            //testXml.LossInfo = new LossInfoType() 
            //{
            //    CauseOfLoss = CauseOfLossCode.Collision,
            //    ReportedDate = DateTime.Now,
            //    LossDescription = "Crashed into an apple tree"
            //};

            //testXml.AssignedAdjusterID= 12345;
            //testXml.Vehicles = new VehicleInfoType[]{new VehicleInfoType()
            //{
            //    Vin = "1M8GDM9AXKP042788",
            //    ModelYear = 2015,
            //    MakeDescription = "Ford",
            //    ModelDescription = "Mustang",
            //    EngineDescription = "EcoBoost",
            //    ExteriorColor = "Deep Impact Blue",
            //    LicPlate = "N01PRES",
            //    LicPlateState="CA",
            //    LicPlateExpDate = DateTime.Now,
            //    DamageDescription="Front end smashed",
            //    Mileage= 1776
            //}

            //};
            //return Ok(testXml);
        }

        // GET api/mitchellclaim/5/4
        public List<MitchellClaimType> Get(string lossDateFrom, string lossDateTo)
        {
           return _mitchellClaimService.FindByLossDateBetween(Convert.ToDateTime(lossDateFrom), Convert.ToDateTime(lossDateTo));
        }

        // POST api/mitchellclaim
        public HttpResponseMessage Post([FromBody]MitchellClaimType value)
        {
            var response = _mitchellClaimService.SaveClaim(value);
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        // PUT api/mitchellclaim
        public void Put([FromBody]MitchellClaimType value)
        {
            _mitchellClaimService.UpdateClaim(value);
        }

        // DELETE api/mitchellclaim/5
        public void Delete(string claimNumber)
        {
            _mitchellClaimService.DeleteClaim(claimNumber);
        }
    }
}
