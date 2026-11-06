using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class CorrelativeScienceStudies
    {
        public CorrelativeScienceStudies()
        {
            NewStudy = new HashSet<NewStudy>();
        }

        public int CorrelativeScienceStudiesId { get; set; }
        public int StudyId { get; set; }
        public bool? IsincludeCorrelativeScience { get; set; }
        public string BiomarkerStudiesperformedatStudySite { get; set; }
        public string BiomarkerStudiesperformedatCompanySite { get; set; }
        public string BiomarkerSamplingDetails { get; set; }

        public virtual ICollection<NewStudy> NewStudy { get; set; }
    }
}
