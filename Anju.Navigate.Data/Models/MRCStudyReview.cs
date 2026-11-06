using System;

namespace Anju.Navigate.Data
{
    public partial class MRCStudyReview:BaseResponseModel
    {
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
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string MRCDecisionRejectedBy { get; set; }
        public string MRCRejectedDeliveryMethod { get; set; }
        public string MRCDecisionWithdrawalBy { get; set; }
        public string MRCWithdrawalDeliveryMethod { get; set; }
        public string CAResubmissionDecision { get; set; }
        public string CAResubmissionComments { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        //For view purpose below properties are created

        public int? TotalPlannedNumberofPatients { get; set; }
        public string MslUserName { get; set; }
        public int? AmountRequested { get; set; }

        public string TitleofTrial { get; set; }

    }
}
