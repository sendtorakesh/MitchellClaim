using MitchellClaim.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.DataAccessLayer.Factory
{
    public class MitchellClaimDataAccessLayerFactory
    {
        public static IMitchellClaimDAL GetMitchellClaimDALFactory()
        {
            IMitchellClaimDAL objMitchellClaimDAL = new MitchellClaimDAL();
            return objMitchellClaimDAL;
        }
    }
}
