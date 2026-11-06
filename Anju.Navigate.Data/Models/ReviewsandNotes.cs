using System;

namespace Anju.Navigate.Data
{
    public partial class ReviewsandNotes : BaseResponseModel
    {
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
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
