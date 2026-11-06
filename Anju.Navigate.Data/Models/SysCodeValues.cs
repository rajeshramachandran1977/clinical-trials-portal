using System;

namespace Anju.Navigate.Data
{
    public partial class SysCodeValues : BaseResponseModel
    {
        public int CodeId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsDisplay { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }       
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }

}

