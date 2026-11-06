using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class PasswordHistory
    {
        [Key]
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
