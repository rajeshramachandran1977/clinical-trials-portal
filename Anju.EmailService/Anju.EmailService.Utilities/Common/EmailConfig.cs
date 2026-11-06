using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.EmailService.Utilities
{
    public class EmailConfig
    {
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
