using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public class ReviewsandNotes : EntityBase
    {
        [Key]
        public int ReviewsandNotesId { get; set; }
        public int StudyId { get; set; }
        public DateTime? Reviewdate { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Reviewstep { get; set; }
        public string Submissioncomments { get; set; }
        public string Decision { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }

    public class ReviewsandNotes_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public DateTime? Reviewdate { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Reviewstep { get; set; }
        public string Submissioncomments { get; set; }
        public string Decision { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }
}
