using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Membership;
using MedTech.Application.DTO.Membership;
using MedTech.Application.Mapping;

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

        public UserDto GetUserByEmail(string email)
        {
            return _userRepository.Table.FirstOrDefault(u => u.Email == email).ToDto();
        }

        //public void InsertUser(User user)
        //{
        //    if (user == null)
        //        throw new ArgumentNullException("user");

        //    _userRepository.Insert(user);
        //}
        public void UpdateUser(UserDto user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var entity = _userRepository.GetById(user.Id);

            if(entity == null)
                throw new ArgumentNullException("user entity");

            entity = user.ToEntity();
            _userRepository.Update(entity);
        }
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
