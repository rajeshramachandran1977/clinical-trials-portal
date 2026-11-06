using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public partial class StudyReview:BaseResponseModel
    {
        public int ReviewId { get; set; }
        public int StudyId { get; set; }
        public int? MsluserId { get; set; }
        public string MsluserName{get; set; }
        public string Franchise { get; set; }
        public string PrimaryIndication { get; set; }
        public string SecondaryIndication { get; set; }
        public string Institution { get; set; }
        public string Decision { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual NewStudy Study { get; set; }
    }
}
