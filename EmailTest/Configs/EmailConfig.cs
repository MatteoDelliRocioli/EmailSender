using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailTest.Configs
{
    public class EmailConfig
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }

        public string LocalDomain { get; set; }

        public string MailServerAddress { get; set; }
        public string MailServerPort { get; set; }
    }
}
