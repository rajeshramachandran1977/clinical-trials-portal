using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class SysCodeValues : EntityBase
    {

        [Key]
        public int CodeId { get; set; }

        [StringLength(255)]
        public string TableName { get; set; }

        [StringLength(255)]
        public string ColumnName { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? SortOrder { get; set; }
        public bool? IsDisplay { get; set; }
        public bool? IsDefault { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }

       

    public partial class SysCodeValues_H : HistoryEntityBase
    {

        [StringLength(255)]
        public string TableName { get; set; }

        [StringLength(255)]
        public string ColumnName { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? SortOrder { get; set; }
        public bool? IsDisplay { get; set; }
        public bool? IsDefault { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

    }
}
