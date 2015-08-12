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
            return _mitchellClaimService.GetClaims();
        }

        // GET api/mitchellclaim/id
        public MitchellClaimType Get(string claimNumer)
        {
            return _mitchellClaimService.FindClaimByClaimNumber(claimNumer);            
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
