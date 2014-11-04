using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Web.Models;
using MedTech.Application.Services.Membership;
using MedTech.Application.Services.Authentication;
using Newtonsoft.Json;

namespace MedTech.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IMembershipService membershipService, IAuthenticationService authenticationService)
        {
            _membershipService = membershipService;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public object getLoggedStatus ()
        {
            var AccountInfo = new { IsLogged = User.Identity.IsAuthenticated, Email = User.Identity.Name};
            return AccountInfo;
        }
        [HttpPost]
        public bool Login(object account)
        {            
            var model = JsonConvert.DeserializeObject<LoginViewModel>(account.ToString()); ;

            if (model != null)
            {
                if (_membershipService.ValidateUser(model.Email, model.Password))
                {
                    var user = _membershipService.GetUserByEmail(model.Email);
                    _authenticationService.SignIn(user, model.Remember);
                    return true;
                }
            }            
            return false;
        }
        [HttpDelete]
        public void Logout()
        {
            _authenticationService.SignOut();
        }

        #region Helpers
        #endregion
    }
}