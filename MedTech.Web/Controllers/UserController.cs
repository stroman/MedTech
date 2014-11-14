﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Application.Services.Membership;
using MedTech.Application.DTO.Membership;
using Newtonsoft.Json;
using MedTech.Core.Helpers;
using MedTech.Web.Models;
using System.Collections;
using MedTech.Web.Mailer;
using System.Net.Configuration;
using System.Configuration;

namespace MedTech.Web.Controllers
{
    public class UserController : ApiController
    {
        #region Fields

        private readonly IMembershipService _membershipService;
        private readonly ISendMailer _sendMailer;

        #endregion

        #region Ctor
        public UserController(IMembershipService membershipService, ISendMailer sendMailer)
        {
            _membershipService = membershipService;
            _sendMailer = sendMailer;
        }
        #endregion

        #region Methods CRUD
        [HttpPut]
        public ResponseModel GetUsers(object filter)
        {
            var filterModel = JsonConvert.DeserializeObject<RequestFilter>(filter.ToString());
            int totalCount;
            var users = _membershipService.GetAllUsers(filterModel, out totalCount) ;
            var responseModel = new ResponseModel
            {
                TotalCount = totalCount,
                Rows = users
            };
            return responseModel;           
        }
        [HttpPost]
        public void DoUser(int id, object user)
        {
            var userModel = JsonConvert.DeserializeObject<UserDto>(user.ToString());
            var sendPass = userModel.Password;
            if (id == 0 && userModel.Id == 0)
            {
                _membershipService.CreateUser(userModel);
                var smtp = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                var m = new MailerModel
                {
                    UserName = userModel.FirstName + " " + userModel.LastName,
                    Password = sendPass,
                    FromEmail = smtp.From,
                    Subject = "Добро пожаловать в MedTech",
                    ToEmail = userModel.Email
                };
                _sendMailer.CreateUser(m).Send();
            }
            else
            {
                _membershipService.UpdateUser(userModel);
            }
        }
        [HttpDelete]
        public void DeleteUser(long id)
        {
            _membershipService.DeleteUser(id);
        }

        [HttpPost]
        public bool CheckEmail(object email)
        {
            var emailModel = JsonConvert.DeserializeObject<EmailModel>(email.ToString());
            return _membershipService.IsEmailExists(emailModel.Email);
        }
        #endregion

        #region Helper methods
        #endregion
    }
}
