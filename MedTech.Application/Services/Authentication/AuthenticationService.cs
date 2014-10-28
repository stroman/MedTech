using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.Security;
using MedTech.Application.Services.Membership;
using MedTech.Application.DTO.Membership;

namespace MedTech.Application.Services.Authentication
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMembershipService _membershipService;
        private readonly TimeSpan _expirationTimeSpan;
        private UserDto _cachedUser;
        public AuthenticationService(IMembershipService membershipService)
        {
            _membershipService = membershipService;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void SignIn(UserDto user, bool remember)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.Email,
                now,
                now.Add(_expirationTimeSpan),
                remember,
                user.Email,
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            // Create the cookie.
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
            user.LastLoginDate = DateTime.UtcNow;
            _membershipService.UpdateUser(user);
            _cachedUser = user;

        }

        public void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public UserDto GetAuthenticatedUser()
        {
            if (_cachedUser != null)
            {
                return _cachedUser;
            }

            if (HttpContext.Current == null ||  
                HttpContext.Current.Request == null || 
                !HttpContext.Current.Request.IsAuthenticated || 
                !(HttpContext.Current.User.Identity is FormsIdentity))                
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            var user = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);
            if (user != null)
                _cachedUser = user;
            return _cachedUser;
        }

        public UserDto GetAuthenticatedUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var email = ticket.Name;

            if (String.IsNullOrWhiteSpace(email))
                return null;
            var user = _membershipService.GetUserByEmail(email);
            return user;
        }
    }
}
