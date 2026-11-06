using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class TrialPhase : EntityBase
    {
        [Key]
        public int TrialPhaseId { get; set; }
        public int? StudyId { get; set; }
        public bool? PhaseI { get; set; }
        public bool? PhaseII { get; set; }
        public bool? PhaseIII { get; set; }
        public bool? PhaseIV { get; set; }
    }

    public partial class TrialPhase_H : HistoryEntityBase
    {
        public int? StudyId { get; set; }
        public bool? PhaseI { get; set; }
        public bool? PhaseII { get; set; }
        public bool? PhaseIII { get; set; }
        public bool? PhaseIV { get; set; }
    }
}
