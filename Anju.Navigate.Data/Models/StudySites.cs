using System;

namespace Anju.Navigate.Data
{
    public partial class StudySites : BaseResponseModel
    {
        public int SiteId { get; set; }
        public int StudyId { get; set; }
        public string SiteInstitution { get; set; }
        public string InstitutionInternal { get; set; }
        public string SiteCountry { get; set; }
        public bool? IsDrugShippedtoSite { get; set; }
        public bool? IsContractdirectwithSite { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
