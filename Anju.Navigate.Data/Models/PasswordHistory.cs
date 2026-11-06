using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class PasswordHistory
    {
        public int PasswordId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Previouspassword { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
    }
}
