using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public partial class StudyReview 
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
}
