using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StudyProtocolRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor

        public StudyProtocolRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  
        /// <summary>
        /// Get Study Protocols
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyProtocol> GetStudyProtocols(int studyId)
        {
            var lstStudyprotocol = dbContextNavigate.StudyProtocol.Where(x => x.StudyId == studyId && x.IsActive)
                                                         .Select(x => new Data.StudyProtocol
                                                         {
                                                             StudyProtocolId = x.StudyProtocolId,
                                                             Organization = x.Organization,
                                                             StudyProtocolnos = x.StudyProtocolnos,
                                                             StudyId = x.StudyId

                                                         }).ToList();
            return lstStudyprotocol;
        }


        /// <summary>
        /// Create/Update Protocols nos
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateStudyprotocolnos(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                CommonRepository cmnRep = new CommonRepository();
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isstudyprotocolnosrestricted = false;
                bool isorganizationrestricted = false;

                var studyprotocolresult = dbContextNavigate.StudyProtocol.Where(x => x.StudyId == newStudy.StudyId && x.StudyProtocolId == newStudy.StudyProtocolId).SingleOrDefault();
                if (studyprotocolresult != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.STUDYPROTOCOLNUMBERS:
                                studyprotocolresult.StudyProtocolnos = newStudy.StudyProtocolnos ?? studyprotocolresult.StudyProtocolnos;
                                isstudyprotocolnosrestricted = true;
                                break;
                            case ConstDefaultValue.ORGANIZATION:
                                studyprotocolresult.Organization = newStudy.Organization ?? studyprotocolresult.Organization;
                                isorganizationrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isstudyprotocolnosrestricted == false)
                        studyprotocolresult.StudyProtocolnos = newStudy.StudyProtocolnos.Trim();
                    if (isorganizationrestricted == false)
                        studyprotocolresult.Organization = newStudy.Organization;
                    
                    studyprotocolresult.IsActive = true;
                    studyprotocolresult.IsDeleted = false;
                    studyprotocolresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    studyprotocolresult.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(studyprotocolresult, new StudyProtocol_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    if(retVal > 0)
                    {
                        var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId && studyprotocolresult.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL).FirstOrDefault();
                        if(result != null)
                        {
                            if (result.InvestigationalSiteProtocolNumber.ToUpper().Trim() != newStudy.StudyProtocolnos.Trim().ToUpper().Trim())
                            {
                                result.InvestigationalSiteProtocolNumber = newStudy.StudyProtocolnos?.Trim();
                                result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                result.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), result.ANJU_ChangedBy, eAuditChangeType.Update);
                            }
                        }
                    }
                }
                else
                {
                    DataAccess.StudyProtocol objStudyProtocols = new DataAccess.StudyProtocol()
                    {
                        StudyId = newStudy.StudyId,
                        StudyProtocolnos = newStudy.StudyProtocolnos,
                        Organization = newStudy.Organization,
                        Module=ConstDefaultValue.EDITSTUDY,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow,
                    };                   
                    retVal = dbContextNavigate.SaveChanges(objStudyProtocols, new StudyProtocol_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                    if(retVal > 0)
                    {
                        var Studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if(Studyresult != null && string.IsNullOrWhiteSpace(Studyresult.InvestigationalSiteProtocolNumber))
                        {
                            Studyresult.InvestigationalSiteProtocolNumber = newStudy.StudyProtocolnos;
                            Studyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(Studyresult, new NewStudy_H(), Studyresult.ANJU_ChangedBy, eAuditChangeType.Update);
                            if(retVal > 0)
                            {
                                var protocol = dbContextNavigate.StudyProtocol.Where(x => x.StudyProtocolId == objStudyProtocols.StudyProtocolId && x.StudyId == newStudy.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                if(protocol != null)
                                {
                                    protocol.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                    protocol.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                    protocol.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(protocol, new StudyProtocol_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Protocols
        /// </summary>
        /// <param name="indications"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudyProtocols(Data.StudyProtocol studyprotocol, string userName)
        {
            int retVal = default(int);
            if (studyprotocol != null)
            {
                var result = dbContextNavigate.StudyProtocol.Where(x => x.StudyProtocolId == studyprotocol.StudyProtocolId).SingleOrDefault();
                if (result != null)
                {
                    result.StudyProtocolId = studyprotocol.StudyProtocolId;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new StudyProtocol_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    if(result.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL)
                    {
                        var Studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyprotocol.StudyId).FirstOrDefault();
                        if(Studyresult != null)
                        {
                            Studyresult.InvestigationalSiteProtocolNumber = string.Empty;
                            Studyresult.ANJU_ChangedBy = userName;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                        }
                    }
                    if (retVal > 0)
                    {
                        var Studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyprotocol.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if(string.IsNullOrEmpty(Studyresult.InvestigationalSiteProtocolNumber)  )
                        {
                            Studyresult.InvestigationalSiteProtocolNumber = dbContextNavigate.StudyProtocol.Where(x => x.StudyId == studyprotocol.StudyId && x.Organization == ConstDefaultValue.SPONSORPROTOCOLNUMBER && x.IsActive == true && x.IsDeleted == false).Select(y => y.StudyProtocolnos).FirstOrDefault();
                            Studyresult.ANJU_ChangedBy = userName;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                            if(retVal > 0)
                                 return true;
                        }
                        
                    }
                      
                }
                  
            }
            return false;
        }

        #endregion
    }
}
