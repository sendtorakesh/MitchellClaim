using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClaim.Common;
using MitchellClaim.Model;

namespace MitchellClaim.Business.Tests
{
    [TestClass]
    public class BusinessUnitTests
    {
        Mock<IMitchellClaimDAL> _mockClaimDal;

        IMitchellClaimService _sut;
        [TestInitialize]
        public void Setup()
        {
            _mockClaimDal = new Mock<IMitchellClaimDAL>();
            _mockClaimDal.Setup(x => x.GetClaims()).Returns(new List<MitchellClaimType>() { new MitchellClaimType(){ID = 1234, Status = StatusCode.OPEN}});
            _mockClaimDal.Setup(x => x.SaveClaim(It.IsAny<MitchellClaimType>())).Returns(1234);
            _sut = new MitchellClaimService(_mockClaimDal.Object);
        }

        [TestMethod]
        public void Ensure_list_of_claim_is_retrievable()
        {
            var response = _sut.GetClaims();
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(1234, response[0].ID);
            Assert.AreEqual(StatusCode.OPEN, response[0].Status);
        }

        [TestMethod]
        public void Enure_claim_can_be_saved()
        {
            var response = _sut.SaveClaim(new MitchellClaimType() { ID = 1234, Status = StatusCode.CLOSED});
            Assert.AreEqual(1234, response);
        }
    }
}
