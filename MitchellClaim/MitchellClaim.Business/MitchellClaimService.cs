using System;
using System.Collections.Generic;
using MitchellClaim.Model;
using MitchellClaim.Common;


namespace MitchellClaim.Business
{
    public class MitchellClaimService: IMitchellClaimService 
    {
        IMitchellClaimDAL _mitchellClaimDAL;
        public MitchellClaimService(IMitchellClaimDAL claimDal)
        {
            _mitchellClaimDAL = claimDal;
        }
       
        public List<MitchellClaimType> GetClaims()
        {
            return _mitchellClaimDAL.GetClaims();
        }

        public MitchellClaimType FindClaimByClaimNumber(string id)
        {
            throw new NotImplementedException();
        }

        public List<MitchellClaimType> FindByLossDateBetween(DateTime lossDateFrom, DateTime lossDateTo)
        {
            return _mitchellClaimDAL.FindByLossDateBetween(lossDateFrom, lossDateTo);
        }              

        public int SaveClaim(MitchellClaimType claim)
        {
           return _mitchellClaimDAL.SaveClaim(claim);
        }
        public void DeleteClaim(string claimNumber)
        {
            _mitchellClaimDAL.DeleteClaim(claimNumber);
        }

        public void UpdateClaim(MitchellClaimType claimType)
        {
            _mitchellClaimDAL.UpdateClaim(claimType);
        }

      
    }
}
