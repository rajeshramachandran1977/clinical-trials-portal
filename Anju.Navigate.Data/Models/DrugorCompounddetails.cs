using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class DrugorCompounddetails
    {
        public int DrugorCompounddetailsId { get; set; }
        public int StudyId { get; set; }
        public string Primarydrug { get; set; }
        public string Secondarydrug { get; set; }
        public string Tertiarydrug { get; set; }
        public string SecondaryType { get; set; }
        public string TertiaryaryType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
