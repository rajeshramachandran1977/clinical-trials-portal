using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class PrincipalInvestigator : EntityBase
    {
        [Key]
        public int PrincipalInvestigatorId { get; set; }
        public int StudyId { get; set; }
        public int? CategoryID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public string Npinumber { get; set; }
        public string Institution { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string PostalCode { get; set; }
        public string SiteIndex { get; set; }
        public string ContactType { get; set; }
        public string ContactTypeDetails { get; set; }
        public string TaxID { get; set; }
        public string Region { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }    

        public virtual NewStudy Study { get; set; }
    }

    public partial class PrincipalInvestigator_H : HistoryEntityBase
    {       
        public int StudyId { get; set; }
        public int? CategoryID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public string Npinumber { get; set; }
        public string Institution { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string PostalCode { get; set; }
        public string SiteIndex { get; set; }
        public string ContactType { get; set; }
        public string ContactTypeDetails { get; set; }
        public string TaxID { get; set; }
        public string Region { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual NewStudy Study { get; set; }

    }
}
