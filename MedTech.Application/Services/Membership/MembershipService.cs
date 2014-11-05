using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Membership;
using MedTech.Application.DTO.Membership;
using MedTech.Application.Mapping;
using MedTech.Core.Helpers;

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

        public void CreateUser(UserDto user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            
            var saltedHash = new SaltedHash(user.Password);
            user.Password = saltedHash.Hash;
            user.Salt = saltedHash.Salt;
            
            _userRepository.Insert(user.ToEntity());
        }
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
        public void DeleteUser(long id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new ArgumentNullException("user entity");
            _userRepository.Delete(user);
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
            return _userRepository.Table;
        }

        private User GetActualUserByEmail(string email)
        {
            return _userRepository.Table.FirstOrDefault(u => u.Email == email);
        }

        private static IEnumerable<User> SortUsers(IEnumerable<User> users, RequestFilter filter)
        {
            var field =  filter.Sorting.First().Key;
            var type = filter.Sorting.First().Value;
            if(field == "lastLoginDate" )
            {
                return type == "asc" ? users.OrderBy(u => u.LastLoginDate) : users.OrderByDescending(u => u.LastLoginDate);
            }
            Func<User, string> orderingFunction = (c => field == "firstName" ? c.FirstName
                                                      : field == "lastName" ? c.LastName
                                                      : field == "email" ? c.Email
                                                      : field == "phone" ? c.Phone
                                                      : field == "role" ? c.Role.Name : "");
            return type  == "asc" ? users.OrderBy(orderingFunction) : users.OrderByDescending(orderingFunction);
        }

        private static IEnumerable<User> SearchUsers(IEnumerable<User> users, RequestFilter filter)
        {
            return users;
        }
        #endregion
    }
}
