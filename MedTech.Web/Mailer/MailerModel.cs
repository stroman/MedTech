using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedTech.Web.Mailer
{
    public class MailerModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string ToEmail { get; set; }
    }
}