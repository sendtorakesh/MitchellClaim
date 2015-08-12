﻿using System;
using System.Collections.Generic;
using System.Linq;
using MitchellClaim.Model;
using MitchellClaim.Common;
using MitchellClaim.DataAccessLayer.ErrorHandler;

namespace MitchellClaim.DataAccessLayer
{
    public class MitchellClaimDAL : IMitchellClaimDAL
    {
        private DatabaseContext _entity;
        IClaimDatabaseException _claimDatabaseException;

        public MitchellClaimDAL()
        {
            _entity = new DatabaseContext();
            _claimDatabaseException = new ClaimDatabaseException();
        }
        
        //Not sure why objMitchellClaimType.Vehicles object is not able to hold any value
        //Throwing exception object is null
        public List<MitchellClaimType> GetClaims()
        {
            List<MitchellClaimType> claimList = new List<MitchellClaimType>();
            try
            {
               //claimList =  _entity.MitchellClaimTypes.ToList<MitchellClaimType>();
                MitchellClaimType objMitchellClaimType = new MitchellClaimType();
                foreach (MitchellClaimType tempMitchellClaimType in _entity.MitchellClaimTypes.ToList<MitchellClaimType>())
                {
                    objMitchellClaimType = tempMitchellClaimType;
                    objMitchellClaimType.LossInfo = _entity.LossInfoTypes.ToList<LossInfoType>().Where(x => x.ID == tempMitchellClaimType.ID).ToList<LossInfoType>()[0];
                    //objMitchellClaimType.Vehicles = new VehicleInfoType[1];
                   //_entity.VehicleInfoTypes.ToList<VehicleInfoType>().CopyTo(objMitchellClaimType.Vehicles);
                    claimList.Add(objMitchellClaimType);
                }
          
            }catch(Exception ex)
            {
                _claimDatabaseException.ExceptionHandler(ex.Message);
            }
            return claimList;
        }

        public MitchellClaimType FindClaimByClaimNumber(string claimNumber)
        {
            MitchellClaimType objMitchellClaimType = new MitchellClaimType();
            try
            {
                objMitchellClaimType = _entity.MitchellClaimTypes.ToList<MitchellClaimType>().Find(x => x.ClaimNumber == claimNumber);
                
            }
            catch (Exception ex)
            {
                _claimDatabaseException.ExceptionHandler(ex.Message);
            }
            return objMitchellClaimType;
        }

        public List<MitchellClaimType> FindByLossDateBetween(DateTime lossDateFrom, DateTime lossDateTo)
        {
            List<MitchellClaimType> claimList = new List<MitchellClaimType>();
            try
            {
                claimList = _entity.MitchellClaimTypes.ToList<MitchellClaimType>().FindAll(x => x.LossDate > lossDateFrom && x.LossDate < lossDateTo);

            }
            catch (Exception ex)
            {
                _claimDatabaseException.ExceptionHandler(ex.Message);
            }
            return claimList;            
        }

        public int SaveClaim(MitchellClaimType claim)
        {
            int responseStatus = -1;
            MitchellClaimType claimTypeResponse = new MitchellClaimType(); 
            try
            {
                claimTypeResponse = _entity.MitchellClaimTypes.Add(claim);
                _entity.SaveChanges();

            }
            catch (Exception ex)
            {
                _claimDatabaseException.ExceptionHandler(ex.Message);
            }
            if (claimTypeResponse != null)
            {
                responseStatus = 1;
            }
            return responseStatus;
        }
    
        public void DeleteClaim(string claimNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateClaim(MitchellClaimType claimNumber)
        {
            throw new NotImplementedException();
        }

       

        #region Commented Code

        //XmlSerializer serializer = new XmlSerializer(typeof(MitchellClaimType));
        //FileStream stream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "\\create-claim.xml", FileMode.Open);
        //MitchellClaimType mitchellClaimType = (MitchellClaimType)serializer.Deserialize(stream);
        //using (DatabaseContext ent1 = new DatabaseContext())
        //{
        //    ent1.MitchellClaimTypes.Add(mitchellClaimType);
        //    ent1.SaveChanges();
        //}
        //stream.Close();
        #endregion




       
    }
}
