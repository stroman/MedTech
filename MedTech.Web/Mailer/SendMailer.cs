using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;

namespace MedTech.Web.Mailer
{
    public class SendMailer : MailerBase, ISendMailer
    {
        public SendMailer()
        {
            MasterName = "_Layout";
        }
        public MvcMailMessage PasswordReset(MailerModel model)
        {            
            ViewBag.UserName = model.UserName;
            ViewBag.Password = model.Password;

            return Populate(x =>
            {
                x.Subject = model.Subject;
                x.ViewName = "PasswordReset";
                x.To.Add(model.ToEmail);
                x.IsBodyHtml = true;
            });
        }
        public MvcMailMessage CreateUser(MailerModel model)
        {
            ViewBag.UserName = model.UserName;
            ViewBag.Login = model.ToEmail;
            ViewBag.Password = model.Password;

            return Populate(x =>
            {
                x.Subject = model.Subject;
                x.ViewName = "CreateUser";
                x.To.Add(model.ToEmail);
                x.IsBodyHtml = true;
            });
        }        
    }
}