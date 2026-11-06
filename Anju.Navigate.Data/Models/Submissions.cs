using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class Submissions : BaseResponseModel
    {
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
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }

    public class ListOfSubmissions
    {
        public List<Submissions> Submissions { get; set; }
          = new List<Submissions>();
    }
}