using System;

namespace Anju.Navigate.Data
{
    public partial class GlobalSettings
    {
        public int GlobalId { get; set; }
        public string GlobalKey { get; set; }
        public string GlobalValue { get; set; }
        public string Remarks { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
