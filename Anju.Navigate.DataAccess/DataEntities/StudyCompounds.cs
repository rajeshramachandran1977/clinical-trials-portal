using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudyCompounds : EntityBase
    {
        [Key]
        public int StudyComponentId { get; set; }
        public int StudyId { get; set; }
        public string CompoundType { get; set; }
        public string CompanyCompound { get; set; }
        public string NonCompanyCompound { get; set; }
        public string CompoundCategory { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class StudyCompounds_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string CompoundType { get; set; }
        public string CompanyCompound { get; set; }
        public string NonCompanyCompound { get; set; }
        public string CompoundCategory { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
