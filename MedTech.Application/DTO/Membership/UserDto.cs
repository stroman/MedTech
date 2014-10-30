using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.DTO.Membership
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public string Email { get; set; }        
        public string Password { get; set; }        
        public string Salt { get; set; }        
        public string Phone { get; set; }        
        public Nullable<System.DateTime> LastLoginDate { get; set; }        
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
