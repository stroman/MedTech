using MedTech.Core.Domain.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(User user, bool remember);
        void SignOut();
        User GetAuthenticatedUser();
    }
}
