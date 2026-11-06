using Anju.Navigate.Utilities;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class PharmacovigilanceRequirementsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;        
        #endregion

        #region Constructor

        public PharmacovigilanceRequirementsRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     

        /// <summary>
        /// Create/Update Pharmaco vigilance Requirements
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="plannedTrialMilestoneDatesandEnrollmentng"></param>
        public void CreateUpdatePharmacovigilanceRequirements(int StudyID, Data.PharmacovigilanceRequirements pharmacovigilanceRequirements,string userName)
        {
            if (pharmacovigilanceRequirements != null)
            {
                var checkIfrecordexist = dbContextNavigate.PharmacovigilanceRequirements.Where(x => x.StudyId == StudyID)
                                                         .Select(x => new Data.PlannedTrialMilestoneDatesandEnrollment
                                                         {
                                                             StudyId = x.StudyId
                                                         }).ToList();
                if (checkIfrecordexist.Count == 0) //Create if record doesn't exist
                {
                    if (pharmacovigilanceRequirements.TrialType == "Involving PRIMARY DATA COLLECTION WITH a "+ ConfigValues.appName +" Product of Focus")
                    {
                        DataAccess.PharmacovigilanceRequirements objPharmacovigilanceRequirements = new DataAccess.PharmacovigilanceRequirements()
                        {
                            StudyId = StudyID,
                            TrialType = pharmacovigilanceRequirements.TrialType,
                            IsAllnonseriousAes = pharmacovigilanceRequirements.IsAllnonseriousAes,
                            IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = pharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios,
                            Safetydata = pharmacovigilanceRequirements.Safetydata?.Trim(),
                            AdverseEventsExemptfromCollection = pharmacovigilanceRequirements.AdverseEventsExemptfromCollection?.Trim()


                        };                        
                        dbContextNavigate.SaveChanges(objPharmacovigilanceRequirements, new PharmacovigilanceRequirements_H(), userName, eAuditChangeType.Insert);
                    }
                    else
                    {
                        DataAccess.PharmacovigilanceRequirements objPharmacovigilanceRequirements = new DataAccess.PharmacovigilanceRequirements()
                        {
                            StudyId = StudyID,
                            TrialType = pharmacovigilanceRequirements.TrialType,
                            IsAllnonseriousAes = false,
                            IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = false,
                            Safetydata = pharmacovigilanceRequirements.Safetydata?.Trim(),
                            AdverseEventsExemptfromCollection = pharmacovigilanceRequirements.AdverseEventsExemptfromCollection?.Trim()


                        };                        
                        dbContextNavigate.SaveChanges(objPharmacovigilanceRequirements, new PharmacovigilanceRequirements_H(), userName, eAuditChangeType.Insert);
                    }                   
                    
                }
                else
                {
                    var result = dbContextNavigate.PharmacovigilanceRequirements.Where(x => x.StudyId == StudyID).SingleOrDefault();
                    if (result != null)
                    {
                        result.TrialType = pharmacovigilanceRequirements.TrialType;
                        result.IsAllnonseriousAes = pharmacovigilanceRequirements.IsAllnonseriousAes;
                        result.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = pharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios;
                        result.Safetydata = pharmacovigilanceRequirements.Safetydata?.Trim();
                        result.AdverseEventsExemptfromCollection = pharmacovigilanceRequirements.AdverseEventsExemptfromCollection?.Trim();
                        dbContextNavigate.SaveChanges(result, new PharmacovigilanceRequirements_H(), userName, eAuditChangeType.Update);
                    }
                }
            }
        }


        /// <summary>
        /// Create/Update Pharmacovigilance Requirements
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdatePharmacovigilanceRequirements(Data.NewStudy newStudy, string usertype,string userName)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                CommonRepository cmnRep = new CommonRepository();
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isallnonseriousaesrestricted = false;
                bool isallreportsdescribingtheoccurrenceofotherspecialscenariosrestricted = false;
                bool issafetydatarestricted = false;
                bool isadverseeventsexemptfromecollectionrestricted = false;

                var objPharmacovigilanceRequirements = dbContextNavigate.PharmacovigilanceRequirements.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (objPharmacovigilanceRequirements != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.ALLNONSERIOUSAES:
                                objPharmacovigilanceRequirements.IsAllnonseriousAes = newStudy.IsAllnonseriousAes ?? objPharmacovigilanceRequirements.IsAllnonseriousAes;
                                isallnonseriousaesrestricted = true;
                                break;
                            case ConstDefaultValue.OCCURRENCEOFOTHERSPECIALSCENARIOS:
                                objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = newStudy.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios ?? objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios;
                                isallreportsdescribingtheoccurrenceofotherspecialscenariosrestricted = true;
                                break;
                            case ConstDefaultValue.SAFETYDATA:
                                objPharmacovigilanceRequirements.Safetydata = newStudy.Safetydata ?? objPharmacovigilanceRequirements.Safetydata;
                                issafetydatarestricted = true;
                                break;
                            case ConstDefaultValue.ADVERSEEVENTS:
                                objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = newStudy.AdverseEventsExemptfromCollection ?? objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection;
                                isadverseeventsexemptfromecollectionrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isallnonseriousaesrestricted == false)
                        objPharmacovigilanceRequirements.IsAllnonseriousAes = newStudy.IsAllnonseriousAes;
                    if (isallreportsdescribingtheoccurrenceofotherspecialscenariosrestricted == false)
                        objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = newStudy.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios;
                    if (issafetydatarestricted == false)
                        objPharmacovigilanceRequirements.Safetydata = newStudy.Safetydata;
                    if (isadverseeventsexemptfromecollectionrestricted == false)
                        objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = newStudy.AdverseEventsExemptfromCollection;
                    retVal = dbContextNavigate.SaveChanges(objPharmacovigilanceRequirements, new PharmacovigilanceRequirements_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.PharmacovigilanceRequirements pharmacovigilanceRequirements = new DataAccess.PharmacovigilanceRequirements()
                    {
                        IsAllnonseriousAes = newStudy.IsAllnonseriousAes,
                        IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = newStudy.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios,
                        Safetydata = newStudy.Safetydata,
                        AdverseEventsExemptfromCollection = newStudy.AdverseEventsExemptfromCollection,

                    };                    
                    retVal = dbContextNavigate.SaveChanges(pharmacovigilanceRequirements, new PharmacovigilanceRequirements_H(), userName, eAuditChangeType.Insert);
                }
                if (retVal > 0)
                {
                    var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                    if (iisadminresult != null)
                    {
                        bool isinterventionaltrialdatacollectionrestricted = false;
                        bool isnonInterventionaltrialdatacollectionrestricted = false;

                        foreach (var item in lstfields)
                        {
                            switch (item.FieldType)
                            {
                                case ConstDefaultValue.DATACOLLECTIONINTERVENTIONAL:
                                    iisadminresult.Interventionaltrialdatacollection = newStudy.Interventionaltrialdatacollection ?? iisadminresult.Interventionaltrialdatacollection;
                                    isinterventionaltrialdatacollectionrestricted = true;
                                    break;
                                case ConstDefaultValue.DATACOLLECTIONNONINTERVENTIONAL:
                                    iisadminresult.NonInterventionaltrialdatacollection = newStudy.NonInterventionaltrialdatacollection ?? iisadminresult.NonInterventionaltrialdatacollection;
                                    isnonInterventionaltrialdatacollectionrestricted = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (isinterventionaltrialdatacollectionrestricted == false)
                            iisadminresult.Interventionaltrialdatacollection = newStudy.Interventionaltrialdatacollection;
                        if (isnonInterventionaltrialdatacollectionrestricted == false)
                            iisadminresult.NonInterventionaltrialdatacollection = newStudy.NonInterventionaltrialdatacollection;

                        retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), userName, eAuditChangeType.Update);
                    }
                    else
                    {
                        DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                        {
                            StudyId = newStudy.StudyId,
                            Interventionaltrialdatacollection = newStudy.Interventionaltrialdatacollection,
                            NonInterventionaltrialdatacollection = newStudy.NonInterventionaltrialdatacollection,

                        };                        
                        retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), userName, eAuditChangeType.Insert);
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
