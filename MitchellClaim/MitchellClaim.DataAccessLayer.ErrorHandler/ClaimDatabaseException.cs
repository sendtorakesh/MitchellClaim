using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.DataAccessLayer.ErrorHandler
{
    public class ClaimDatabaseException : IClaimDatabaseException
    {
        public void ExceptionHandler(string exceptionString)
        {
            string logFileName = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            System.IO.File.WriteAllText( string.Format("{0}\\{1}",logFileName, "MichelClaimError.text"), exceptionString);
        }
    }
}
