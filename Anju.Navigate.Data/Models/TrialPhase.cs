using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class TrialPhase
    {
        public TrialPhase()
        {
            NewStudy = new HashSet<NewStudy>();
        }

        public int TrialPhaseId { get; set; }
        public int? StudyId { get; set; }
        public bool? PhaseI { get; set; }
        public bool? PhaseII { get; set; }
        public bool? PhaseIII { get; set; }
        public bool? PhaseIV { get; set; }

        public virtual ICollection<NewStudy> NewStudy { get; set; }
    }
}
