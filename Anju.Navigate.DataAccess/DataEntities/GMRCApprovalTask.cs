using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess{
    public partial class GMRCApprovalTask:EntityBase
    {
        [Key]
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
        public virtual NewStudy Study { get; set; }
    }

    public partial class GMRCApprovalTask_H : HistoryEntityBase
    {

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
        public virtual NewStudy Study { get; set; }
    }
}
