using MedTech.Application.Services.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MedTech.Web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {       
       
        public override string ApplicationName 
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override void AddUsersToRoles(string[] emails, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string emailToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return DependencyResolver.Current.GetService<IMembershipService>().GetAllRoles();
        }

        public override string[] GetRolesForUser(string email)
        {
            string[] role = new string[1];
            var user = DependencyResolver.Current.GetService<IMembershipService>().GetUserByEmail(email);
            if( user != null)
            {
                role[0] = user.RoleName;
            }
            return  role;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            bool flag = false;
            var user = DependencyResolver.Current.GetService<IMembershipService>().GetUserByEmail(email);
            if( user != null && user.RoleName == roleName)
            {
                flag = true;
            }
            return flag;
        }

        public override void RemoveUsersFromRoles(string[] emails, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}