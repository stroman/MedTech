using MedTech.Core.Domain.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.Security;

namespace MedTech.Application.Services.Authentication
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly TimeSpan _expirationTimeSpan;
        private User _cachedUser;
        public AuthenticationService()
        {
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void SignIn(User user, bool remember)
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
            _cachedUser = user;

        }
    }
}
