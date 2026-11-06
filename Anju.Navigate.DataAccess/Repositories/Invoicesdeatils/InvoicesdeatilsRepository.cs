using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class InvoicesdeatilsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public InvoicesdeatilsRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        public List<Data.Invoicedetails> GetInvoicesdetails(int studyId)
        {
            var lstInvoicesdetails = dbContextNavigate.Invoicedetails.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.Invoicedetails
                                                         {
                                                             InvoicesdetailsId = x.InvoicesdetailsId,
                                                             StudyId = x.StudyId,
                                                             Checksenttosite = x.Checksenttosite,
                                                             Descriptionofpayment = x.Descriptionofpayment,
                                                             Invoicedate = x.Invoicedate,
                                                             Invoicenumber = x.Invoicenumber,
                                                             Ponumber = x.Ponumber,
                                                             Currency = x.Currency,
                                                             Paymentamount = x.Paymentamount,
                                                             Lineitem = x.Lineitem,
                                                             Generalledgernumber = x.Generalledgernumber,
                                                             Departmentcode = x.Departmentcode,
                                                             Budgetsource = x.Budgetsource,
                                                             Personnel = x.Personnel,
                                                             Procedural = x.Procedural,
                                                             Irbfees = x.Irbfees,
                                                             Administrative = x.Administrative,
                                                             Pharmacy = x.Pharmacy,
                                                             Startup = x.Startup,
                                                             Other = x.Other,
                                                             Organizationtype = x.Organizationtype,
                                                             Natureofexpenditure = x.Natureofexpenditure,
                                                             Purposeofexpenditure = x.Purposeofexpenditure,
                                                             Settingofactivity = x.Settingofactivity,
                                                         }).ToList();
            return lstInvoicesdetails;
        }



        /// <summary>
        /// Create/Update Invoices
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateInvoices(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objInvoicedetails = dbContextNavigate.Invoicedetails.Where(x => x.InvoicesdetailsId == newStudy.InvoicesdeatilsId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objInvoicedetails != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool ischecksenttositerestricted = false;
                bool isdescriptionofpaymentrestricted = false;
                bool isinvoicedaterestricted = false;
                bool isinvoicenumberrestricted = false;
                bool isponumberrestricted = false;
                bool iscurrencyrestricted = false;
                bool ispaymentamountrestricted = false;
                bool islineitemrestricted = false;
                bool isgeneralledgernumberrestricted = false;
                bool isdepartmentcoderestricted = false;
                bool isbudgetsourcerestricted = false;
                bool ispersonnelrestricted = false;
                bool isproceduralrestricted = false;
                bool isirbfeesrestricted = false;
                bool isadministrativerestricted = false;
                bool ispharmacyrestricted = false;
                bool isstartuprestricted = false;
                bool isotherrestricted = false;
                bool isnatureofexpenditurerestricted = false;
                bool isorganizationtyperestricted = false;
                bool issettingofactivityrestricted = false;
                bool ispurposeofexpenditurerestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.CHECKSENTTOSITE:
                            objInvoicedetails.Checksenttosite = newStudy.Checksenttosite ?? objInvoicedetails.Checksenttosite;
                            ischecksenttositerestricted = true;
                            break;
                        case ConstDefaultValue.DESCRIPTIONOFPAYMENT:
                            objInvoicedetails.Descriptionofpayment = newStudy.Descriptionofpayment ?? objInvoicedetails.Descriptionofpayment;
                            isdescriptionofpaymentrestricted = true;
                            break;
                        case ConstDefaultValue.INVOICEDATE:
                            objInvoicedetails.Invoicedate = newStudy.Invoicedate ?? objInvoicedetails.Invoicedate;
                            isinvoicedaterestricted = true;
                            break;
                        case ConstDefaultValue.INVOICENUMBER:
                            objInvoicedetails.Invoicenumber = newStudy.Invoicenumber ?? objInvoicedetails.Invoicenumber;
                            isinvoicenumberrestricted = true;
                            break;
                        case ConstDefaultValue.PONUMBER:
                            objInvoicedetails.Ponumber = newStudy.Ponumber ?? objInvoicedetails.Ponumber;
                            isponumberrestricted = true;
                            break;
                        case ConstDefaultValue.CURRENCY:
                            objInvoicedetails.Currency = newStudy.Currency ?? objInvoicedetails.Currency;
                            iscurrencyrestricted = true;
                            break;
                        case ConstDefaultValue.PAYMENTAMOUNT:
                            objInvoicedetails.Paymentamount = newStudy.Paymentamount ?? objInvoicedetails.Paymentamount;
                            ispaymentamountrestricted = true;
                            break;
                        case ConstDefaultValue.LINEITEM:
                            objInvoicedetails.Lineitem = newStudy.Lineitem ?? objInvoicedetails.Lineitem;
                            islineitemrestricted = true;
                            break;
                        case ConstDefaultValue.GENERALLEDGERNUMBER:
                            objInvoicedetails.Generalledgernumber = newStudy.Generalledgernumber ?? objInvoicedetails.Generalledgernumber;
                            isgeneralledgernumberrestricted = true;
                            break;
                        case ConstDefaultValue.DEPARTMENTCODE:
                            objInvoicedetails.Departmentcode = newStudy.Departmentcode ?? objInvoicedetails.Departmentcode;
                            isdepartmentcoderestricted = true;
                            break;
                        case ConstDefaultValue.BUDGETSOURCE:
                            objInvoicedetails.Budgetsource = newStudy.Budgetsource ?? objInvoicedetails.Budgetsource;
                            isbudgetsourcerestricted = true;
                            break;
                        case ConstDefaultValue.PERSONNELSPEND:
                            objInvoicedetails.Personnel = newStudy.Personnel ?? objInvoicedetails.Personnel;
                            ispersonnelrestricted = true;
                            break;
                        case ConstDefaultValue.PROCEDURAL:
                            objInvoicedetails.Procedural = newStudy.Procedural ?? objInvoicedetails.Procedural;
                            isproceduralrestricted = true;
                            break;
                        case ConstDefaultValue.IRBFEES:
                            objInvoicedetails.Irbfees = newStudy.Irbfees ?? objInvoicedetails.Irbfees;
                            isirbfeesrestricted = true;
                            break;
                        case ConstDefaultValue.IRBANNUALFEES:
                            objInvoicedetails.Irbannualfees = newStudy.Irbannualfees ?? objInvoicedetails.Irbannualfees;
                            isirbfeesrestricted = true;
                            break;
                        case ConstDefaultValue.ADMINISTRATIVEPORTIONOFTHEPAYMENT:
                            objInvoicedetails.Administrative = newStudy.Administrative ?? objInvoicedetails.Administrative;
                            isadministrativerestricted = true;
                            break;
                        case ConstDefaultValue.PHARMACYPORTIONOFTHEPAYMENT:
                            objInvoicedetails.Pharmacy = newStudy.Pharmacy ?? objInvoicedetails.Pharmacy;
                            ispharmacyrestricted = true;
                            break;
                        case ConstDefaultValue.STARTUP:
                            objInvoicedetails.Startup = newStudy.Startup ?? objInvoicedetails.Startup;
                            isstartuprestricted = true;
                            break;
                        case ConstDefaultValue.CORRELATIVE:
                            objInvoicedetails.Correlative = newStudy.Correlative ?? objInvoicedetails.Correlative;
                            isstartuprestricted = true;
                            break;
                        case ConstDefaultValue.OTHER:
                            objInvoicedetails.Other = newStudy.Other ?? objInvoicedetails.Other;
                            isotherrestricted = true;
                            break;
                        case ConstDefaultValue.ORGANIZATIONTYPE:
                            objInvoicedetails.Organizationtype = newStudy.Organizationtype ?? objInvoicedetails.Organizationtype;
                            isorganizationtyperestricted = true;
                            break;
                        case ConstDefaultValue.NATUREOFEXPENDITURE:
                            objInvoicedetails.Natureofexpenditure = newStudy.Natureofexpenditure ?? objInvoicedetails.Natureofexpenditure;
                            isnatureofexpenditurerestricted = true;
                            break;
                        case ConstDefaultValue.PURPOSEOFEXPENDITURE:
                            objInvoicedetails.Purposeofexpenditure = newStudy.Purposeofexpenditure ?? objInvoicedetails.Purposeofexpenditure;
                            ispurposeofexpenditurerestricted = true;
                            break;
                        case ConstDefaultValue.SETTINGOFACTIVITY:
                            objInvoicedetails.Settingofactivity = newStudy.Settingofactivity ?? objInvoicedetails.Settingofactivity;
                            issettingofactivityrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (ischecksenttositerestricted == false)
                    objInvoicedetails.Checksenttosite = newStudy.Checksenttosite;
                if (isdescriptionofpaymentrestricted == false)
                    objInvoicedetails.Descriptionofpayment = newStudy.Descriptionofpayment;
                if (isinvoicedaterestricted == false)
                    objInvoicedetails.Invoicedate = newStudy.Invoicedate;
                if (isinvoicenumberrestricted == false)
                    objInvoicedetails.Invoicenumber = newStudy.Invoicenumber;
                if (isponumberrestricted == false)
                    objInvoicedetails.Ponumber = newStudy.Ponumber;
                if (iscurrencyrestricted == false)
                    objInvoicedetails.Currency = newStudy.Currency;
                if (ispaymentamountrestricted == false)
                    objInvoicedetails.Paymentamount = newStudy.Paymentamount;
                if (islineitemrestricted == false)
                    objInvoicedetails.Lineitem = newStudy.Lineitem;
                if (isgeneralledgernumberrestricted == false)
                    objInvoicedetails.Generalledgernumber = newStudy.Generalledgernumber;
                if (isdepartmentcoderestricted == false)
                    objInvoicedetails.Departmentcode = newStudy.Departmentcode;
                if (isbudgetsourcerestricted == false)
                    objInvoicedetails.Budgetsource = newStudy.Budgetsource;
                if (ispersonnelrestricted == false)
                    objInvoicedetails.Personnel = newStudy.Personnel;
                if (isproceduralrestricted == false)
                    objInvoicedetails.Procedural = newStudy.Procedural;
                if (isirbfeesrestricted == false)
                    objInvoicedetails.Irbfees = newStudy.Irbfees;
                if (isadministrativerestricted == false)
                    objInvoicedetails.Administrative = newStudy.Administrative;
                if (ispharmacyrestricted == false)
                    objInvoicedetails.Pharmacy = newStudy.Pharmacy;
                if (isstartuprestricted == false)
                    objInvoicedetails.Startup = newStudy.Startup;
                if (isotherrestricted == false)
                    objInvoicedetails.Other = newStudy.Other;
                if (isorganizationtyperestricted == false)
                    objInvoicedetails.Organizationtype = newStudy.Organizationtype;
                if (isnatureofexpenditurerestricted == false)
                    objInvoicedetails.Natureofexpenditure = newStudy.Natureofexpenditure;
                if (ispurposeofexpenditurerestricted == false)
                    objInvoicedetails.Purposeofexpenditure = newStudy.Purposeofexpenditure;
                if (issettingofactivityrestricted == false)
                    objInvoicedetails.Settingofactivity = newStudy.Settingofactivity;
                
                objInvoicedetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objInvoicedetails.ANJU_ChangeDate = DateTime.UtcNow;

                dbContextNavigate.Invoicedetails.Update(objInvoicedetails);
                retVal = dbContextNavigate.SaveChanges();
            }
            else
            {
                DataAccess.Invoicedetails invoicedetails = new DataAccess.Invoicedetails()
                {
                    StudyId = newStudy.StudyId,
                    Checksenttosite = newStudy.Checksenttosite,
                    Descriptionofpayment = newStudy.Descriptionofpayment,
                    Invoicedate = newStudy.Invoicedate,
                    Invoicenumber = newStudy.Invoicenumber,
                    Ponumber = newStudy.Ponumber,
                    Currency = newStudy.Currency,
                    Paymentamount = newStudy.Paymentamount,
                    Lineitem = newStudy.Lineitem,
                    Generalledgernumber = newStudy.Generalledgernumber,
                    Departmentcode = newStudy.Departmentcode,
                    Budgetsource = newStudy.Budgetsource,
                    Personnel = newStudy.Personnel,
                    Procedural = newStudy.Procedural,
                    Irbfees = newStudy.Irbfees,
                    Administrative = newStudy.Administrative,
                    Pharmacy = newStudy.Pharmacy,
                    Startup = newStudy.Startup,
                    Other = newStudy.Other,
                    Organizationtype = newStudy.Organizationtype,
                    Natureofexpenditure = newStudy.Natureofexpenditure,
                    Settingofactivity = newStudy.Settingofactivity,

                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };
                dbContextNavigate.Invoicedetails.Add(invoicedetails);
                retVal = dbContextNavigate.SaveChanges();
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Invoice details
        /// </summary>
        /// <param name="invoicedetails"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteInvoicedetails(Data.Invoicedetails invoicedetails, string username)
        {
            int retVal = default(int);
            if (invoicedetails != null)
            {
                var result = dbContextNavigate.Invoicedetails.Where(x => x.InvoicesdetailsId == invoicedetails.InvoicesdetailsId
                                                                        && x.StudyId == invoicedetails.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = username;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                dbContextNavigate.Invoicedetails.Update(result);
                retVal = dbContextNavigate.SaveChanges();
                if (retVal > 0)
                    return true;
            }
            return false;
        }




        #endregion
    }
}
