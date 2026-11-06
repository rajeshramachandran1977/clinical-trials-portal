using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class MRCStudyReview
    {
        [Key]
        public int MRCReviewId { get; set; }
        public int StudyId { get; set; }
        public string RecordType { get; set; }
        public string LocalMrcdecision { get; set; }
        public string LocalMrcdecisionComments { get; set; }
        public DateTime? LocalMrcdateOfDecision { get; set; }
        public string LocalMrcdecisionMadeBy { get; set; }
        public string SaereconciliationFrequency { get; set; }
        public string GlobalMrcdecision { get; set; }
        public DateTime? GlobalMrcdecisionDate { get; set; }
        public string Macsnumber { get; set; }
        public string StudyNumber { get; set; }
        public string MRCDecisionRejectedBy { get; set; }
        public string MRCRejectedDeliveryMethod { get; set; }
        public string MRCDecisionWithdrawalBy { get; set; }
        public string MRCWithdrawalDeliveryMethod { get; set; }
        public string CAResubmissionDecision { get; set; }
        public string CAResubmissionComments { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual NewStudy Study { get; set; }
    }
}
