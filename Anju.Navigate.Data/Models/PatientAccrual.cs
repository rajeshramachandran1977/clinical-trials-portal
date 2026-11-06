using System;

namespace Anju.Navigate.Data
{
    public partial class PatientAccrual : BaseResponseModel
    {
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
        public string ANJU_AddedBy { get; set; }
        public DateTime? Anju_AddedDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }       
    }
}
