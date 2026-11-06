using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Anju.Navigate.DataAccess
{
    public abstract class ReadOnlyEntityBase
    {
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(63)]
        public string ANJU_AddedBy { get; set; }

        public DateTime? ANJU_AddDate { get; set; }
    }

    public abstract class HistoryReadOnlyEntityBase : ReadOnlyEntityBase
    {
        [Key]
        public int PsuedoKey { get; set; }

        public int ANJU_ChangeType { get; set; }

        public DateTime? ANJU_HistoryDate { get; set; }
    }

    public abstract class EntityBase
    {
        [StringLength(63)]
        public string ANJU_AddedBy { get; set; }

        public DateTime? ANJU_AddDate { get; set; }

        [StringLength(63)]
        public string ANJU_ChangedBy { get; set; }

        public DateTime? ANJU_ChangeDate { get; set; }
        
    }

    public abstract class HistoryEntityBase : EntityBase
    {
        [Key]
        public int PsuedoKey { get; set; }

        public int ANJU_ChangeType { get; set; }

        public DateTime? ANJU_HistoryDate { get; set; }
    }
}
