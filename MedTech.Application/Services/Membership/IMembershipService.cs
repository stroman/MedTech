using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Application.DTO.Membership;

namespace MedTech.Application.Services.Membership
{
    public interface IMembershipService
    {
        UserDto GetUserByEmail(string email);
        List<UserDto> GetAllUsers();
        void CreateUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(long id);
        bool ValidateUser(string email, string password);
        string[] GetAllRoles();

    }
}
