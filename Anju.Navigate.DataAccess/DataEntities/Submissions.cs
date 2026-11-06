using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Submissions : EntityBase
    {
        [Key]
        public int SubmissionId { get; set; }
        public int StudyId { get; set; }
        public string Submissiontype { get; set; }
        public string Submissionversion { get; set; }
        public DateTime? Studyeligibilitydate { get; set; }
        public DateTime? Submissiondate { get; set; }
        public string Submissiondetails { get; set; }
        public int DocumentSize { get; set; }
        public string DocumentExtension { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }

    public partial class Submissions_H : HistoryEntityBase
    {        
        public int StudyId { get; set; }
        public string Submissiontype { get; set; }
        public string Version { get; set; }
        public DateTime? Studyeligibilitydate { get; set; }
        public DateTime? Submissiondate { get; set; }
        public string Submissiondetails { get; set; }
        public int DocumentSize { get; set; }
        public string DocumentExtension { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
