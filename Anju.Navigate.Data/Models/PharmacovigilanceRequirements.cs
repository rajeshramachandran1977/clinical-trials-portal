namespace Anju.Navigate.Data
{
    public partial class PharmacovigilanceRequirements
    {
        public int PharmacovigilanceRequirementsId { get; set; }
        public int StudyId { get; set; }
        public string TrialType { get; set; }
        public bool? IsAllnonseriousAes { get; set; }
        public bool? IsAllreportsdescribingtheoccurrenceofotherspecialscenarios { get; set; }
        public string Safetydata { get; set; }
        public string AdverseEventsExemptfromCollection { get; set; }
    }
}
