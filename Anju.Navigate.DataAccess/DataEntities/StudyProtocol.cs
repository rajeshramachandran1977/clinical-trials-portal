using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudyProtocol : EntityBase
    {
        [Key]
        public int StudyProtocolId { get; set; }
        public int StudyId { get; set; }
        public string StudyProtocolnos { get; set; }
        public string Organization { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }        
    }

    public partial class StudyProtocol_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string StudyProtocolnos { get; set; }
        public string Organization { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
