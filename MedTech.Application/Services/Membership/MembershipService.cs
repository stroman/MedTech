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
            return GetActualUserByEmail(email).ToDto();
        }

        public List<UserDto> GetAllUsers ()
        {
            return GetActualUsers().Select(u => u.ToDto()).ToList();
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

            user.ToEntity(entity);
            _userRepository.Update(entity);
        }
        public bool ValidateUser(string email, string password)
        {
            var user = _userRepository.Table.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return SaltedHash.Verify(user.Salt, user.Password, password);
            }
            return false;
        }

        public string[] GetAllRoles()
        {
            return _roleRepository.Table.Select(r => r.Name).ToArray();
        }
        #endregion

        #region Helper methods
        private IEnumerable<User> GetActualUsers()
        {
            return _userRepository.Table.AsEnumerable();
        }

        private User GetActualUserByEmail(string email)
        {
            return _userRepository.Table.FirstOrDefault(u => u.Email == email);
        }
        #endregion
    }
}
