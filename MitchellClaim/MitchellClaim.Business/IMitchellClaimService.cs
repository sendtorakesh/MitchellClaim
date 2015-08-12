using MitchellClaim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.Business.Interfaces    
{
    public interface IMitchellClaimService
    {
        IEnumerable<MitchellClaimType> GetClaims();
        int PostClain(MitchellClaimType claim);
    }
}
