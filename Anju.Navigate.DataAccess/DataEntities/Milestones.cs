using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Milestones : EntityBase
    {
        [Key]
        public int MilestoneId { get; set; }
        public int StudyId { get; set; }
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
    }

    public partial class Milestones_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
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
       
    }
}
