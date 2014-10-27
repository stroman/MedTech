using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Membership;

namespace MedTech.Application.Services.Membership
{
    public class MembershipService : IMembershipService
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
        public bool ValidateUser(string email, string password)
        {
            var user = _userRepository.Table.First(u => u.Email == email);
            return SaltedHash.Verify(user.Salt, user.Password, password);
        }
        #endregion

        #region Helper methods
       
        #endregion
    }
}
