using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class DrugorCompounddetails : EntityBase
    {
        [Key]
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

    public partial class DrugorCompounddetails_H : HistoryEntityBase
    {
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
