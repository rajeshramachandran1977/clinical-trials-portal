using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class PlannedTrialMilestoneDatesandEnrollment : EntityBase
    {
        [Key]
        public int PlannedTrialMilestoneDatesandEnrollmentId { get; set; }
        public int StudyId { get; set; }
        public DateTime? TrialStart { get; set; }
        public DateTime? RecruitmentEnd { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? CompletionofTrialReport { get; set; }
        public DateTime? PrimaryPublicationDate { get; set; }
        public int? TotalPlannedNumberofPatients { get; set; }
        public int? PlannedNumberofCenters { get; set; }

    }

    public partial class PlannedTrialMilestoneDatesandEnrollment_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public DateTime? TrialStart { get; set; }
        public DateTime? RecruitmentEnd { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? CompletionofTrialReport { get; set; }
        public DateTime? PrimaryPublicationDate { get; set; }
        public int? TotalPlannedNumberofPatients { get; set; }
        public int? PlannedNumberofCenters { get; set; }

    }
}
