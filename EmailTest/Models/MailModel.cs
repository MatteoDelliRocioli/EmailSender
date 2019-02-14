using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailTest.Models
{
    public class MailModel
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public MailModel( string mailTo, string subject, string message)
        {
            MailTo = mailTo;
            Subject = subject;
            Message = message;
        }
    }
}
