using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Application.DTO.Membership;

namespace MedTech.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(UserDto user, bool remember);
        void SignOut();
        UserDto GetAuthenticatedUser();
    }
}
