using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class CohortLevels : EntityBase
    {
        [Key]
        public int CohortId { get; set; }
        public int StudyId { get; set; }
        public int? NoofPatients { get; set; }
        public string Cohortlevel { get; set; }
        public string DoseandFrequencyDrugA { get; set; }
        public string DoseandFrequencyDrugB { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }        
    }

    public partial class CohortLevels_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public int? NoofPatients { get; set; }
        public string Cohortlevel { get; set; }
        public string DoseandFrequencyDrugA { get; set; }
        public string DoseandFrequencyDrugB { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }
}
