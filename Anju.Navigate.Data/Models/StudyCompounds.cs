using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class StudyCompounds
    {
        public int StudyComponentId { get; set; }
        public int StudyId { get; set; }
        public string CompoundType { get; set; }
        public string CompanyCompound { get; set; }
        public string NonCompanyCompound { get; set; }
        public string CompoundCategory { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
