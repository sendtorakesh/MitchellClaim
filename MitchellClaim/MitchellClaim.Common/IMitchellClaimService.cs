using MitchellClaim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.Common
{
    public interface IMitchellClaimService
    {
        List<MitchellClaimType> GetClaims();
        List<MitchellClaimType> FindByLossDateBetween(DateTime lossDateFrom, DateTime lossDateTo);
        int SaveClaim(MitchellClaimType claimType);
        MitchellClaimType FindClaimByClaimNumber(string claimNumber);
        void DeleteClaim(string claimNumber);
        void UpdateClaim(MitchellClaimType claimType);
    }
}
