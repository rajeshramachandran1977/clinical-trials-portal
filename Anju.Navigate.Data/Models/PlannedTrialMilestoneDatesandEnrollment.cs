using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class PlannedTrialMilestoneDatesandEnrollment
    {
        public PlannedTrialMilestoneDatesandEnrollment()
        {
            NewStudy = new HashSet<NewStudy>();
        }

        public int PlannedTrialMilestoneDatesandEnrollmentId { get; set; }
        public int? StudyId { get; set; }
        public DateTime? TrialStart { get; set; }
        public DateTime? RecruitmentEnd { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? CompletionofTrialReport { get; set; }
        public DateTime? PrimaryPublicationDate { get; set; }
        public int? TotalPlannedNumberofPatients { get; set; }
        public int? PlannedNumberofCenters { get; set; }

        public virtual ICollection<NewStudy> NewStudy { get; set; }
    }
}
