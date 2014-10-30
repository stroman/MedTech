using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Application.Services.Membership;
using MedTech.Application.DTO.Membership;


namespace MedTech.Web.Controllers
{
    public class UserController : ApiController
    {
        #region Fields

        private readonly IMembershipService _membershipService;

        #endregion

        #region Ctor
        public UserController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        #endregion

        #region Methods CRUD
        [HttpGet]
        public List<UserDto> GetUsers()
        {
            return _membershipService.GetAllUsers();           
        }

        #endregion

        #region Helper methods
        #endregion
    }
}
