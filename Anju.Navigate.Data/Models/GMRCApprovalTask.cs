using System;

namespace Anju.Navigate.Data
{
    public partial class GMRCApprovalTask:BaseResponseModel
    {        
        public int GMRCApprovalTaskId { get; set; }
        public int StudyId { get; set; }
        public string TaskName { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }
        public bool? IsTaskCompleted { get; set; }
        public bool? IsGearTaskCompleted { get; set; }
        public string ContractType { get; set; }
        public string ContractStatus { get; set; }
        public string CurrentLocation { get; set; }
        public string ContactName { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }        
        public string Decision { get; set; }
        public string StudyStatus { get; set; }
        public string StatusChangeReason { get; set; }
        public bool? IsClosureActivitiesCompleted { get; set; }
        public string Version { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        
    }
}
