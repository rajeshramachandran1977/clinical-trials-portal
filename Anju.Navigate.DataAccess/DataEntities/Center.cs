using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Center : EntityBase
    {
        [Key]
        public int CenterId { get; set; }
        public int StudyId { get; set; }
        public string Institution { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class Center_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string Institution { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }      
    }
}
