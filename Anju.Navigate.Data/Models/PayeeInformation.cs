using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public class PayeeInformation : BaseResponseModel
    {
        public int? PayeeInformationID { get; set; }        
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }       
        public string Institution { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
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
    }
}
