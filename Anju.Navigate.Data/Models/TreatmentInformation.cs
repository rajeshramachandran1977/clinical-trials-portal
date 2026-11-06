using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class TreatmentInformation : BaseResponseModel
    {
        public int TreatmentInfoId { get; set; }
        public int StudyId { get; set; }
        public string TreatmentArm { get; set; }
        public string NoofPatientsPlanned { get; set; }
        public string TypeofTrialDrug { get; set; }
        public string Compound { get; set; }
        public string Mindosage { get; set; }
        public string Maxdosage { get; set; }
        public string Frequency { get; set; }
        public string AdminRoute { get; set; }
        public bool? GenericAcceptable { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
