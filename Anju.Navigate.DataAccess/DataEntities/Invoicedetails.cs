using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Invoicedetails
    {
        [Key]
        public int InvoicesdetailsId { get; set; }
        public int StudyId { get; set; }
        public DateTime? Checksenttosite { get; set; }
        public string Descriptionofpayment { get; set; }
        public DateTime? Invoicedate { get; set; }
        public string Invoicenumber { get; set; }
        public string Ponumber { get; set; }
        public string Currency { get; set; }
        public string Paymentamount { get; set; }
        public string Lineitem { get; set; }
        public string Generalledgernumber { get; set; }
        public string Departmentcode { get; set; }
        public string Budgetsource { get; set; }
        public string Personnel { get; set; }
        public string Procedural { get; set; }
        public string Irbfees { get; set; }
        public string Irbannualfees { get; set; }
        public string Administrative { get; set; }
        public string Pharmacy { get; set; }
        public string Startup { get; set; }
        public string Correlative { get; set; }
        public string Other { get; set; }
        public string Organizationtype { get; set; }
        public string Natureofexpenditure { get; set; }
        public string Purposeofexpenditure { get; set; }
        public string Settingofactivity { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
