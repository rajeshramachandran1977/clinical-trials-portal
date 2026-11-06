using System;

namespace Anju.Navigate.Data
{
    public partial class LoginAttempts : BaseResponseModel
    {
        public int LoginattemptId { get; set; }
        public string UserID { get; set; }
        public string IPv4Address { get; set; }
        public string IPv6Address { get; set; }
        public DateTime? DateTime { get; set; }
        public string LoginAttemptStatus { get; set; }
    }
}
