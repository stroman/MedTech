using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Domain.Membership
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets primary email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the salt
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Gets or sets the phome
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the date of last login
        /// </summary>
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        /// <summary>
        /// Gets or sets role identifier
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// Gets or sets roles
        /// </summary>        
        public virtual Role Role { get; set; }


        
    }
}
