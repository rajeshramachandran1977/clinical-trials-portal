using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class CohortLevels : BaseResponseModel
    {      
        public int CohortId { get; set; }
        public int StudyId { get; set; }
        public int? NoofPatients { get; set; }
        public string Cohortlevel { get; set; }
        public string DoseandFrequencyDrugA { get; set; }
        public string DoseandFrequencyDrugB { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }       
    }
}
