using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Domain.Membership
{
    public class Role : BaseEntity
    {
        private ICollection<User> _users;
        /// <summary>
        /// Gets or sets the name of role
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets users
        /// </summary>
        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set {_users = value;}
        }
    }
}
