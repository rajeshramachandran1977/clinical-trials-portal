using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class PharmacovigilanceRequirements : EntityBase
    {
        [Key]
        public int PharmacovigilanceRequirementsId { get; set; }
        public int StudyId { get; set; }
        public string TrialType { get; set; }
        public bool? IsAllnonseriousAes { get; set; }
        public bool? IsAllreportsdescribingtheoccurrenceofotherspecialscenarios { get; set; }
        public string Safetydata { get; set; }
        public string AdverseEventsExemptfromCollection { get; set; }
    }

    public partial class PharmacovigilanceRequirements_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string TrialType { get; set; }
        public bool? IsAllnonseriousAes { get; set; }
        public bool? IsAllreportsdescribingtheoccurrenceofotherspecialscenarios { get; set; }
        public string Safetydata { get; set; }
        public string AdverseEventsExemptfromCollection { get; set; }
    }
}
