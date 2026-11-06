using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Anju.EmailService.DataAccess
{
    public class Milestones
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
}
