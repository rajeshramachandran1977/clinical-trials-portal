using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class LoginAttempts
    {
        [Key]
        public int LoginattemptId { get; set; }
        public string UserID { get; set; }
        public string IPv4Address { get; set; }
        public string IPv6Address { get; set; }
        public DateTime? DateTime { get; set; }
        public string LoginAttemptStatus { get; set; }
    }
}
