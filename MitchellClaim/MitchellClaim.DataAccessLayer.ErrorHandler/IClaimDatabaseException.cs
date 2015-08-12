using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.DataAccessLayer.ErrorHandler
{
    public interface IClaimDatabaseException
    {
        void ExceptionHandler(string exceptionString);
    }
}
