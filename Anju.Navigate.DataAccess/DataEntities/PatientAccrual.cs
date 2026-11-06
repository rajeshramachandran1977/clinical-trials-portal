using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class PatientAccrual : EntityBase
    {
        [Key]
        public int PatientaccrualId { get; set; }
        public int StudyId { get; set; }
        public int? Year { get; set; }
        public string MonthYear { get; set; }
        public int? TreatedPatients { get; set; }
        public int? CurrentPatients { get; set; }
        public int? WithdrawnPatients { get; set; }
        public int? CompletedPatients { get; set; }
        public DateTime? FirstPatientFirstVisit { get; set; }
        public bool? PatientEnrollment { get; set; }
        public DateTime? LastPatientFirstVisit { get; set; }
        public DateTime? LastPatientLastTreatment { get; set; }
        public DateTime? LastPatientLastVisit { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }     
        public virtual NewStudy Study { get; set; }
    }

    public partial class PatientAccrual_H : HistoryEntityBase
    {   
        public int StudyId { get; set; }
        public int? Year { get; set; }
        public string MonthYear { get; set; }
        public int? TreatedPatients { get; set; }
        public int? CurrentPatients { get; set; }
        public int? WithdrawnPatients { get; set; }
        public int? CompletedPatients { get; set; }
        public DateTime? FirstPatientFirstVisit { get; set; }
        public bool? PatientEnrollment { get; set; }
        public DateTime? LastPatientFirstVisit { get; set; }
        public DateTime? LastPatientLastTreatment { get; set; }
        public DateTime? LastPatientLastVisit { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }    
        public virtual NewStudy Study { get; set; }
    }
}
