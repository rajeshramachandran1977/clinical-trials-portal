using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class TreatmentInformation : EntityBase
    {
        [Key]
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
    }

    public partial class TreatmentInformation_H : HistoryEntityBase
    {
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
    }
}
