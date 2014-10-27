using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.Services.Membership
{
    public interface IMembershipService
    {
        bool ValidateUser(string email, string password);
    }
}
