using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StudyIndicationRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor

        public StudyIndicationRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  
        /// <summary>
        /// Get Indications
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyIndication> GetIndications(int studyId)
        {
            var lstIndications = dbContextNavigate.StudyIndication.Where(x => x.StudyId == studyId && x.IsActive)
                                                         .Select(x => new Data.StudyIndication
                                                         {
                                                             IndicationId = x.IndicationId,
                                                             IndicationType = x.IndicationType,
                                                             IndicationCauses = x.IndicationCauses

                                                         }).ToList();
            return lstIndications;
        }


        /// <summary>
        /// Create/Update Indications
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateIndications(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {

                CommonRepository cmnRep = new CommonRepository();
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isindicationrestricted = false;
                bool isindicationtyperestricted = false;

                var indicationresult = dbContextNavigate.StudyIndication.Where(x => x.StudyId == newStudy.StudyId && x.IndicationId == newStudy.IndicationId).SingleOrDefault();
                if (indicationresult != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.INDICATIONTYPE:
                                indicationresult.IndicationType = newStudy.IndicationType ?? indicationresult.IndicationType;
                                isindicationrestricted = true;
                                break;
                            case ConstDefaultValue.INDICATIONFORSCIENCEMAIN:
                                indicationresult.IndicationCauses = newStudy.IndicationCauses ?? indicationresult.IndicationCauses;
                                isindicationtyperestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isindicationrestricted == false)
                        indicationresult.IndicationType = newStudy.IndicationType;
                    if (isindicationtyperestricted == false)
                        indicationresult.IndicationCauses = newStudy.IndicationCauses;

                    indicationresult.IsActive = true;
                    indicationresult.IsDeleted = false;
                    indicationresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    indicationresult.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(indicationresult, new StudyIndication_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.StudyIndication objIndications = new DataAccess.StudyIndication()
                    {
                        StudyId = newStudy.StudyId,
                        IndicationType = newStudy.IndicationType,
                        IndicationCauses = newStudy.IndicationCauses,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow,
                    };                    
                    retVal = dbContextNavigate.SaveChanges(objIndications, new StudyIndication_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Study Indications
        /// </summary>
        /// <param name="indications"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudyIndications(Data.StudyIndication indications, string userName)
        {
            int retVal = default(int);
            if (indications != null)
            {
                var result = dbContextNavigate.StudyIndication.Where(x => x.IndicationId == indications.IndicationId).SingleOrDefault();
                if (result != null)
                {
                    result.IndicationId = indications.IndicationId;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };              
                retVal = dbContextNavigate.SaveChanges(result, new StudyIndication_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
