using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class GlobalSettings : EntityBase
    {
        [Key]
        public int GlobalId { get; set; }
        public string GlobalKey { get; set; }
        public string GlobalValue { get; set; }
        public string Remarks { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class GlobalSettings_H : HistoryEntityBase
    {
        public string GlobalKey { get; set; }
        public string GlobalValue { get; set; }
        public string Remarks { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
