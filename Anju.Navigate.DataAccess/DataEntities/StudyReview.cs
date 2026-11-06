using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudyReview : EntityBase
    {
        [Key]
        public int ReviewId { get; set; }
        public int StudyId { get; set; }
        public int? MsluserId { get; set; }
        public string Franchise { get; set; }
        public string PrimaryIndication { get; set; }
        public string SecondaryIndication { get; set; }
        public string Institution { get; set; }
        public string Decision { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }  
        public virtual NewStudy Study { get; set; }
    }

    public partial class StudyReview_H: HistoryEntityBase
    {       
        public int StudyId { get; set; }
        public int? MsluserId { get; set; }
        public string Franchise { get; set; }
        public string PrimaryIndication { get; set; }
        public string SecondaryIndication { get; set; }
        public string Institution { get; set; }
        public string Decision { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }     
        public virtual NewStudy Study { get; set; }
    }
}
