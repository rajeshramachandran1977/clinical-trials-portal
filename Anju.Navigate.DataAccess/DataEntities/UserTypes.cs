using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class UserTypes
    {
        [Key]
        public long UserTypeId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(63)]
        public string ANJU_AddedBy { get; set; }

        public DateTime? ANJU_AddDate { get; set; }

        [StringLength(63)]
        public string ANJU_ChangedBy { get; set; }

        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
