using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudySites : EntityBase
    {
        [Key]
        public int SiteId { get; set; }
        public int StudyId { get; set; }
        public string SiteInstitution { get; set; }
        public string InstitutionInternal { get; set; }
        public string SiteCountry { get; set; }
        public bool? IsDrugShippedtoSite { get; set; }
        public bool? IsContractdirectwithSite { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class StudySites_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string SiteInstitution { get; set; }
        public string InstitutionInternal { get; set; }
        public string SiteCountry { get; set; }
        public bool? IsDrugShippedtoSite { get; set; }
        public bool? IsContractdirectwithSite { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }      
    }
}
