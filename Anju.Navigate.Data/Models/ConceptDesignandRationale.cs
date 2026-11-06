namespace Anju.Navigate.Data
{
    public partial class ConceptDesignandRationale
    {
        public int ConceptDesignandRationaleId { get; set; }
        public int StudyId { get; set; }
        public string Indication { get; set; }
        public string RationaleforTrial { get; set; }
        public string TrialDesign { get; set; }
        public string Binding { get; set; }
        public string Structure { get; set; }
        public string Randomized { get; set; }
        public string Gender { get; set; }
        public string MinimumAge { get; set; }
        public string MaximumAge { get; set; }
        public string PatientPopulation { get; set; }
        public string KeyInclusionCriteria { get; set; }
        public string KeyExclusionCriteria { get; set; }
    }
}
