using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClaim.Model;
using System.Collections.Generic;
using MitchellClaim.Common;
using MitchellClaim.DataAccessLayer;

namespace MitchellClaim.Business.Tests
{
    [TestClass]
    public class BusinessIntegrationTest
    {
        IMitchellClaimDAL _dal;
        IMitchellClaimService _claimService;
        MitchellClaimType _claimType;

        [TestInitialize]
        public void SetUp()
        {
            _dal = new MitchellClaimDAL();
            _claimService = new MitchellClaimService(_dal);

            _claimType = new MitchellClaimType()
            {
                ClaimNumber = "22c9c23bac142856018ce14a26b6c299",
                ClaimantFirstName = "George",
                ClaimantLastName = "Washington",
                Status = (StatusCode)Enum.Parse(typeof(StatusCode), "OPEN"),
                LossDate = Convert.ToDateTime("2014-07-09T17:19:13.631-07:00"),
                AssignedAdjusterID = Convert.ToInt64("12345"),
                LossInfo = new LossInfoType()
                {
                    CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), "Collision"),
                    ReportedDate = Convert.ToDateTime("2014-07-10T17:19:13.676-07:00"),
                    LossDescription = "Crashed into an apple tree."
                },
                Vehicles = new VehicleInfoType[1]{ 
                    new VehicleInfoType(){
                            Vin = "1M8GDM9AXKP042788",
                            ModelYear = Convert.ToInt32("2015"),
                            MakeDescription = "Ford",
                            ModelDescription = "Mustang",
                            EngineDescription = "EcoBoost",
                            ExteriorColor = "Deep Impact Blue",
                            LicPlate = "NO1PRES",
                            LicPlateState = "VA",
                            LicPlateExpDate = Convert.ToDateTime("2015-03-10-07:00"),
                            DamageDescription = "Front end smashed in. Apple dents in roof.",
                            Mileage = Convert.ToInt32("1776")
                    }
                },
            };
        }
       
       private const string CLAIM_NUMBER = "22c9c23bac142856018ce14a26b6c299";

       [TestMethod]
       public void SaveClaim()
       {
           if (_claimService.SaveClaim(_claimType) == 1)
           {
               Assert.IsTrue(true);
           }
           else
           {
               Assert.IsTrue(false);
           }

           DeleteClaimHelper(CLAIM_NUMBER);
       }

       [TestMethod]
       public void GetAllClaims()
       {
           _claimService.SaveClaim(_claimType);
           List<MitchellClaimType> listOfClaims = _claimService.GetClaims();
           if (listOfClaims.Count > 0)
           {
               MitchellClaimType claimType = listOfClaims.Find(x => x.ClaimNumber == CLAIM_NUMBER);
               if (claimType != null)
               {
                   Assert.IsTrue(true);
               }
               else
               {
                   Assert.IsTrue(false);
               }
           }
       }

       [TestMethod]
       public void GetClaimByDateRange()
       {
           DateTime dateFrom = DateTime.Now.AddDays(-2);
           DateTime dateTo = DateTime.Now;
           List<MitchellClaimType> listOfClaims = _claimService.GetClaims();
           if (listOfClaims.Count > 0)
           {
               List<MitchellClaimType> claimTypeList = listOfClaims.FindAll(x => x.LossDate > dateFrom && x.LossDate < dateTo);
               if (claimTypeList.Count > 0)
               {
                   Assert.IsTrue(true);
               }
               else
               {
                   Assert.IsTrue(false);
               }
           }
       }


       [TestMethod]
       public void UpdateClaim()
       {
           throw NotImplementedException();
       }


       [TestMethod]
       public void DeleteClaim()
       {
           DeleteClaimHelper(CLAIM_NUMBER);
       }

       #region Helper Classes

       private void DeleteClaimHelper(string claimNumber)
       {
           throw NotImplementedException();
       }

       private Exception NotImplementedException()
       {
           throw new NotImplementedException();
       }
       #endregion 

    }
}
