using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class CorrelativeScienceStudies : EntityBase
    {
        [Key]
        public int CorrelativeScienceStudiesId { get; set; }
        public int StudyId { get; set; }
        public bool? IsincludeCorrelativeScience { get; set; }
        public string BiomarkerStudiesperformedatStudySite { get; set; }
        public string BiomarkerStudiesperformedatCompanySite { get; set; }
        public string BiomarkerSamplingDetails { get; set; }
    }
    public partial class CorrelativeScienceStudies_H : HistoryEntityBase
    {

        public int StudyId { get; set; }
        public bool? IsincludeCorrelativeScience { get; set; }
        public string BiomarkerStudiesperformedatStudySite { get; set; }
        public string BiomarkerStudiesperformedatCompanySite { get; set; }
        public string BiomarkerSamplingDetails { get; set; }
    }
}
