using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Web.Models;
using MedTech.Application.Services.Membership;
using Newtonsoft.Json;

namespace MedTech.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService _membershipService;
        public AccountController(IUserService membershipService)
        {
            _membershipService = membershipService;
        }

        public bool Login(object account)
        {
            var strAccount = account.ToString();
            var model = JsonConvert.DeserializeObject<LoginViewModel>(strAccount); ;

            if (model != null)
            {
                if (_membershipService.ValidateUser(model.Email, model.Password))
                {
                    return true;
                }
            }            
            return false;
        }

        #region Helpers
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}
        //private void SignIn(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}

        #endregion
    }
}