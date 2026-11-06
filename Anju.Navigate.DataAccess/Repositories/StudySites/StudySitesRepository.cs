using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StudySitesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor

        public StudySitesRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Variables
        CommonRepository cmnRep = new CommonRepository();
        #endregion

        #region Methods  
        /// <summary>
        /// Get Study Protocols
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudySites> GetStudySites(int studyId)
        {
            var lstStudysites = dbContextNavigate.StudySites.Where(x => x.StudyId == studyId && x.IsActive)
                                                         .Select(x => new Data.StudySites
                                                         {
                                                             StudyId = x.StudyId,
                                                             SiteId = x.SiteId,
                                                             SiteInstitution = x.SiteInstitution,
                                                             InstitutionInternal = x.InstitutionInternal,
                                                             IsDrugShippedtoSite = x.IsDrugShippedtoSite,
                                                             IsContractdirectwithSite = x.IsContractdirectwithSite,
                                                             SiteCountry = x.SiteCountry                                                             
                                                         }).ToList();
            return lstStudysites;
        }


        /// <summary>
        /// Save/Update Study sites
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateStudysites(Data.NewStudy newStudy,string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isSiteInstitutionrestricted = false;
                bool isSiteCountryrestricted = false;
                bool isInstitutionInternalrestricted = false;
                bool isDrugShippedtoSiterestricted = false;
                bool isContractdirectwithSiterestricted = false;

                var studysitesresult = dbContextNavigate.StudySites.Where(x => x.StudyId == newStudy.StudyId && x.SiteId == newStudy.SiteId).SingleOrDefault();
                if (studysitesresult != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.SITEINSTITUTION:
                                studysitesresult.SiteInstitution = newStudy.SiteInstitution ?? studysitesresult.SiteInstitution;
                                isSiteInstitutionrestricted = true;
                                break;
                            case ConstDefaultValue.COUNTRY:
                                studysitesresult.SiteCountry = newStudy.SiteCountry ?? studysitesresult.SiteCountry;
                                isSiteCountryrestricted = true;
                                break;
                            case ConstDefaultValue.INSTITUTIONINTERNAL:
                                studysitesresult.InstitutionInternal = newStudy.InstitutionInternal ?? studysitesresult.InstitutionInternal;
                                isInstitutionInternalrestricted = true;
                                break;
                            case ConstDefaultValue.ISDRUGSHIPPEDTOSITE:
                                studysitesresult.IsDrugShippedtoSite = newStudy.IsDrugShippedtoSite ?? studysitesresult.IsDrugShippedtoSite;
                                isDrugShippedtoSiterestricted = true;
                                break;
                            case ConstDefaultValue.ISCONTRACTDIRECTWITHSITE:
                                studysitesresult.IsContractdirectwithSite = newStudy.IsContractdirectwithSite ?? studysitesresult.IsContractdirectwithSite;
                                isContractdirectwithSiterestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isSiteInstitutionrestricted == false)
                        studysitesresult.SiteInstitution = newStudy.SiteInstitution.Trim();
                    if (isSiteCountryrestricted == false)
                        studysitesresult.SiteCountry = newStudy.SiteCountry;
                    if (isInstitutionInternalrestricted == false)
                        studysitesresult.InstitutionInternal = newStudy.InstitutionInternal;
                    if (isDrugShippedtoSiterestricted == false)
                        studysitesresult.IsDrugShippedtoSite = newStudy.IsDrugShippedtoSite;
                    if (isContractdirectwithSiterestricted == false)
                        studysitesresult.IsContractdirectwithSite = newStudy.IsContractdirectwithSite;

                    studysitesresult.IsActive = true;
                    studysitesresult.IsDeleted = false;
                    studysitesresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    studysitesresult.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(studysitesresult, new StudySites_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.StudySites objStudySites = new DataAccess.StudySites()
                    {
                        StudyId = newStudy.StudyId,
                        SiteInstitution = newStudy.SiteInstitution,
                        InstitutionInternal = newStudy.InstitutionInternal,
                        SiteCountry = newStudy.SiteCountry,
                        IsDrugShippedtoSite = newStudy.IsDrugShippedtoSite,
                        IsContractdirectwithSite = newStudy.IsContractdirectwithSite,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow,

                    };                   
                    retVal = dbContextNavigate.SaveChanges(objStudySites, new StudySites_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Study Sites
        /// </summary>
        /// <param name="studysites"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudySites(Data.StudySites studysites, string userName)
        {
            int retVal = default(int);
            if (studysites != null)
            {
                var result = dbContextNavigate.StudySites.Where(x => x.SiteId == studysites.SiteId 
                                                             && x.StudyId == studysites.StudyId).SingleOrDefault();
                if (result != null)
                {           
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };               
                retVal = dbContextNavigate.SaveChanges(result, new StudySites_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
