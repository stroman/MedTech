using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Membership;

namespace MedTech.Application.Services.Membership
{
    public class MembershipService
    {
        /// <summary>
        /// Membership service
        /// </summary>
        #region Fields

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        #endregion

        #region Ctor
        public MembershipService(IRepository<User> userRepository, IRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        #endregion

        #region Methods
        
        #endregion

        #region Helper methods
       
        #endregion
    }
}
