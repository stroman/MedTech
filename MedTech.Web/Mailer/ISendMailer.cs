using Mvc.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Web.Mailer
{
    public interface ISendMailer
    {
        MvcMailMessage PasswordReset(MailerModel model);
        MvcMailMessage CreateUser(MailerModel model);              
    }
}
