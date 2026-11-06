using System;

namespace Anju.Navigate.Data
{
    public partial class Milestones : BaseResponseModel
    {
        public int MilestoneId { get; set; }
        public int StudyId { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phase { get; set; }
        public string Parameters { get; set; }
        public int? Dependency { get; set; }
        public DateTime? Milestonecompletiondate { get; set; }
        public DateTime? Estimatedcompletiondate { get; set; }
        public string MilestoneStatus { get; set; }
        public DateTime? Remindersentdate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
