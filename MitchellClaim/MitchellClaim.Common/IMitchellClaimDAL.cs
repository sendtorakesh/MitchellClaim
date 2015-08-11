using MitchellClaim.Model;
using System;
using System.Collections.Generic;

namespace MitchellClaim.Common
{
    public interface IMitchellClaimDAL
    {
        List<MitchellClaimType> GetClaims();
        List<MitchellClaimType> FindByLossDateBetween(DateTime lossDateFrom, DateTime lossDateTo);
        int SaveClaim(MitchellClaimType claim);
        MitchellClaimType FindClaimByClaimNumber(string claimNumber);
        void DeleteClaim(string claimNumber);
        void UpdateClaim(MitchellClaimType claimNumber);
    }
}
