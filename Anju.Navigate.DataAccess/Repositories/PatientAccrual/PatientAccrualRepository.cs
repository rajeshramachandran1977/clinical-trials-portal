using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class PatientAccrualRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public PatientAccrualRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods 
        /// <summary>
        /// Get Patient Enrollment Details
        /// </summary>
        /// <returns>Patient Enrollment Details</returns>
        public List<Data.PatientAccrual> GetPatientEnrollmentDetails(int studyId)
        {

            var lstPatientEnrollmentDetails = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId &&x.IsActive == true && x.IsDeleted == false)
                                                   .Select(x => new Data.PatientAccrual
                                                   {
                                                       StudyId = x.StudyId,
                                                       PatientaccrualId = x.PatientaccrualId,
                                                       MonthYear = x.MonthYear,
                                                       Year = x.Year,
                                                       TreatedPatients = x.TreatedPatients,
                                                       CurrentPatients = x.CurrentPatients,
                                                       WithdrawnPatients = x.WithdrawnPatients,
                                                       CompletedPatients = x.CompletedPatients,
                                                       FirstPatientFirstVisit = x.FirstPatientFirstVisit,
                                                       PatientEnrollment = x.PatientEnrollment,
                                                       LastPatientFirstVisit = x.LastPatientFirstVisit,
                                                       LastPatientLastTreatment = x.LastPatientLastTreatment,
                                                       LastPatientLastVisit = x.LastPatientLastVisit
                                                   }).ToList();
            return lstPatientEnrollmentDetails;

        }

        /// <summary>
        ///  Create PatientEnrollmentDetails
        /// </summary>
        /// <param name="patientAccrual"></param> 
        /// <returns></returns>
        public bool CreatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual)
        {
            int retVal = default(int);
            if (patientAccrual != null)
            {
                DataAccess.PatientAccrual objPatientAccrual = new DataAccess.PatientAccrual()
                {
                    StudyId = patientAccrual.StudyId,
                    MonthYear = patientAccrual.MonthYear,
                    Year = patientAccrual.Year,
                    TreatedPatients = patientAccrual.TreatedPatients,
                    CurrentPatients = patientAccrual.CompletedPatients,
                    WithdrawnPatients = patientAccrual.WithdrawnPatients,
                    CompletedPatients = patientAccrual.CompletedPatients,
                    FirstPatientFirstVisit = patientAccrual.FirstPatientFirstVisit,
                    PatientEnrollment = patientAccrual.PatientEnrollment,
                    LastPatientFirstVisit = patientAccrual.LastPatientFirstVisit,
                    LastPatientLastTreatment = patientAccrual.LastPatientLastTreatment,
                    LastPatientLastVisit = patientAccrual.LastPatientLastVisit,
                    IsActive = patientAccrual.IsActive,
                    IsDeleted = patientAccrual.IsDeleted,
                    ANJU_AddedBy = patientAccrual.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,
                    ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy,
                    ANJU_ChangeDate = patientAccrual.ANJU_ChangeDate
                };                
                retVal = dbContextNavigate.SaveChanges(objPatientAccrual, new PatientAccrual_H(), patientAccrual.ANJU_AddedBy, eAuditChangeType.Insert);

                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  Update PatientEnrollmentDetails
        /// </summary>
        /// <param name="patientAccrual"></param>      
        /// <param name="studyId"></param>
        /// <returns></returns>
        public bool UpdatePatientEnrollmentDates(Data.PatientAccrual patientAccrual, int studyId)
        {
            int retVal = default(int);
            DateTime taskDate;
            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);

            var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId).ToList();
            if (result.Count > 0) {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].FirstPatientFirstVisit = patientAccrual.FirstPatientFirstVisit;
                    result[i].PatientEnrollment = patientAccrual.PatientEnrollment;
                    result[i].LastPatientFirstVisit = patientAccrual.LastPatientFirstVisit;
                    result[i].LastPatientLastTreatment = patientAccrual.LastPatientLastTreatment;
                    result[i].LastPatientLastVisit = patientAccrual.LastPatientLastVisit;
                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                    result[i].ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;                    
                    retVal = dbContextNavigate.SaveChanges(result[i], new PatientAccrual_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                if (retVal > 0)
                {
                    
                    if (patientAccrual.LastPatientLastVisit != null)
                    {
                        taskDate = (DateTime)patientAccrual?.LastPatientLastVisit;                        
                        bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(studyId, "Last Patient Last Visit (LPLV)", taskDate, patientAccrual.ANJU_ChangedBy);
                        if (taskcompletion)
                            retVal = 1;
                        if(retVal > 0) {
                            string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                     .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                     (pl, u) => new { pl, u })
                                                     .Where(x => x.pl.StudyId == studyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                     .Select(x => x.u.UserName).FirstOrDefault();
                            DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask();
                            objGMRCApprovalTask.StudyId = studyId;
                            objGMRCApprovalTask.TaskName = Utilities.Messages.SAEFINALRECONCILIATIONREPORTCONFIRMATION;
                            objGMRCApprovalTask.AssignedTo = TlUserName;
                            objGMRCApprovalTask.IsTaskCompleted = false;
                            objGMRCApprovalTask.IsActive = true;
                            objGMRCApprovalTask.IsDeleted = false;
                            objGMRCApprovalTask.ANJU_AddedBy = patientAccrual.ANJU_ChangedBy;
                            objGMRCApprovalTask.ANJU_AddDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Insert);

                            if (retVal > 0)
                            {
                                var newStudyResult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.Stage == Utilities.Messages.ACTIVE).SingleOrDefault();

                                if (newStudyResult != null)
                                {
                                    newStudyResult.State = Utilities.Messages.ENROLLMENTCLOSEDSTATE;
                                    newStudyResult.TaskStatus = Utilities.Messages.STUDYCLOSEOUTPENDING;
                                    newStudyResult.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;
                                    newStudyResult.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(newStudyResult, new NewStudy_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                                    if (retVal > 0)
                                        return true;
                                    else
                                        return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }                       
                    }                 
                    else if (patientAccrual.LastPatientFirstVisit != null && patientAccrual.PatientEnrollment == true)
                    {

                        taskDate = (DateTime)patientAccrual.LastPatientFirstVisit;                       
                        bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(studyId, "Last Patient First Visit - Enrollment Complete", taskDate, patientAccrual.ANJU_ChangedBy);
                        if (taskcompletion)
                        {
                            if (patientAccrual.LastPatientLastTreatment != null)
                            {
                                taskDate = (DateTime)patientAccrual.LastPatientLastTreatment;
                                taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(studyId, "Last Patient Last Treatment -- the date the last patient receives their last dose of study drug", taskDate, patientAccrual.ANJU_ChangedBy);
                                if (taskcompletion) {
                                    var newStudyResults = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.Stage == Utilities.Messages.ACTIVE).SingleOrDefault();
                                    if (newStudyResults != null)
                                    {
                                        newStudyResults.State = Utilities.Messages.ENROLLMENTCLOSEDSTATE;
                                        newStudyResults.TaskStatus = Utilities.Messages.SAEPENDING;
                                        newStudyResults.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;
                                        newStudyResults.ANJU_ChangeDate = DateTime.UtcNow;
                                        retVal = dbContextNavigate.SaveChanges(newStudyResults, new NewStudy_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                                        if (retVal > 0)
                                            return true;
                                        else
                                            return false;
                                    }
                                }
                                                              
                            }
                            else
                                retVal = 1;
                        }
                        var newStudyResult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.Stage == Utilities.Messages.ACTIVE).SingleOrDefault();

                        if (newStudyResult != null)
                        {
                            newStudyResult.State = Utilities.Messages.ENROLLMENTCLOSEDSTATE;
                            newStudyResult.TaskStatus = Utilities.Messages.STOPENROLLING;
                            newStudyResult.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;
                            newStudyResult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyResult, new NewStudy_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                            if (retVal > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                    else if (patientAccrual.LastPatientLastTreatment != null)
                    {
                        taskDate = (DateTime)patientAccrual.LastPatientLastTreatment;                       
                        bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(studyId, "Last Patient Last Treatment -- the date the last patient receives their last dose of study drug", taskDate, patientAccrual.ANJU_ChangedBy);
                        if (taskcompletion)
                            retVal = 1;
                        var newStudyResult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.Stage == Utilities.Messages.ACTIVE).SingleOrDefault();

                        if (newStudyResult != null)
                        {
                            newStudyResult.State = Utilities.Messages.ENROLLMENTCLOSEDSTATE;
                            newStudyResult.TaskStatus = Utilities.Messages.SAEPENDING;
                            newStudyResult.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;
                            newStudyResult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyResult, new NewStudy_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                            if (retVal > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                    else if (patientAccrual.FirstPatientFirstVisit != null)
                    {
                        taskDate = (DateTime)patientAccrual.FirstPatientFirstVisit;                      
                        bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(studyId, "First Patient First Visit - the date the first patient received study drug", taskDate, patientAccrual.ANJU_ChangedBy);
                        if (taskcompletion)
                            retVal = 1;
                        var newStudyResult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.Stage == Utilities.Messages.ACTIVE).SingleOrDefault();

                        if (newStudyResult != null)
                        {
                            newStudyResult.State = Utilities.Messages.ENROLLMENTPROGRESSSTATE;
                            newStudyResult.TaskStatus = Utilities.Messages.PATIENTACCRUALSUBMITTED;
                            newStudyResult.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;
                            newStudyResult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyResult, new NewStudy_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                            if (retVal > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                    if (retVal > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


        /// <summary>
        ///  Update PatientEnrollmentDetails
        /// </summary>
        /// <param name="patientAccrual"></param>      
        /// <param name="studyId"></param>
        /// <returns></returns>
        public bool UpdatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual, int studyId)
        {
            int retVal = default(int);

            var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId && x.MonthYear == patientAccrual.MonthYear && x.IsActive == true && x.PatientaccrualId==patientAccrual.PatientaccrualId).SingleOrDefault();
            if (result != null)
            {
                result.TreatedPatients = patientAccrual.TreatedPatients;
                result.CurrentPatients = patientAccrual.CurrentPatients;
                result.WithdrawnPatients = patientAccrual.WithdrawnPatients;
                result.CompletedPatients = patientAccrual.CompletedPatients;
                result.ANJU_ChangeDate = DateTime.UtcNow;
                result.ANJU_ChangedBy = patientAccrual.ANJU_ChangedBy;                
                retVal = dbContextNavigate.SaveChanges(result, new PatientAccrual_H(), patientAccrual.ANJU_ChangedBy, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Create/Update Patient Accrual
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdatePatientAccrual(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objPatientAccrual = dbContextNavigate.PatientAccrual.Where(x => x.PatientaccrualId == newStudy.PatientaccrualId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objPatientAccrual != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool ismonthyearrestricted = false;
                bool istreatedpatientsrestricted = false;
                bool iscurrentpatientsrestricted = false;
                bool iswithdrawnpatientsrestricted = false;
                bool iscompletedpatientsrestricted = false;
               
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.MONTHANDYEAROFACCRUAL:
                             objPatientAccrual.MonthYear = newStudy.MonthYear ?? objPatientAccrual.MonthYear;
                             ismonthyearrestricted = true;
                             break;
                        case ConstDefaultValue.NUMBEROFNEWPATIENTSTREATEDTHISMONTH:
                            objPatientAccrual.TreatedPatients = newStudy.TreatedPatients ?? objPatientAccrual.TreatedPatients;
                            istreatedpatientsrestricted = true;
                            break;
                        case ConstDefaultValue.TOTALNOOFPATIENTSCURRENTLYONTREATMENT:
                            objPatientAccrual.CurrentPatients = newStudy.CurrentPatients ?? objPatientAccrual.CurrentPatients;
                            iscurrentpatientsrestricted = true;
                            break;
                        case ConstDefaultValue.TOTALNOOFPATIENTSWITHDRAWNFROMTREATMENT:
                            objPatientAccrual.WithdrawnPatients = newStudy.WithdrawnPatients ?? objPatientAccrual.WithdrawnPatients;
                            iswithdrawnpatientsrestricted = true;
                            break;
                        case ConstDefaultValue.TOTALNOOFPATIENTSCOMPLETEDTREATMENT:
                            objPatientAccrual.CompletedPatients = newStudy.CompletedPatients ?? objPatientAccrual.CompletedPatients;
                            iscompletedpatientsrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (ismonthyearrestricted == false)
                    objPatientAccrual.Year = newStudy.Year;
                    objPatientAccrual.MonthYear = newStudy.MonthYear;
                if (istreatedpatientsrestricted == false)
                    objPatientAccrual.TreatedPatients = newStudy.TreatedPatients;
                if (iscurrentpatientsrestricted == false)
                    objPatientAccrual.CurrentPatients = newStudy.CurrentPatients;
                if (iswithdrawnpatientsrestricted == false)
                    objPatientAccrual.WithdrawnPatients = newStudy.WithdrawnPatients;
                if (iscompletedpatientsrestricted == false)
                    objPatientAccrual.CompletedPatients = newStudy.CompletedPatients;

                objPatientAccrual.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objPatientAccrual.ANJU_ChangeDate = DateTime.UtcNow;                
                retVal = dbContextNavigate.SaveChanges(objPatientAccrual, new PatientAccrual_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.PatientAccrual patientaccrual = new DataAccess.PatientAccrual()
                {
                    StudyId = newStudy.StudyId,
                    Year = newStudy.Year,
                    MonthYear = newStudy.MonthYear,
                    TreatedPatients = newStudy.TreatedPatients,
                    CurrentPatients = newStudy.CurrentPatients,
                    WithdrawnPatients = newStudy.WithdrawnPatients,
                    CompletedPatients = newStudy.CompletedPatients,

                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };                
                retVal = dbContextNavigate.SaveChanges(patientaccrual, new PatientAccrual_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Get Patient Accrual
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.PatientAccrual> GetPatientAccrual(int studyId)
        {
            var lstPatientaccrual = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId
                                                            && x.IsActive == true)
                                                         .Select(x => new Data.PatientAccrual
                                                         {
                                                             PatientaccrualId = x.PatientaccrualId,
                                                             StudyId = x.StudyId,
                                                             MonthYear = x.MonthYear,
                                                             TreatedPatients = x.TreatedPatients,
                                                             CurrentPatients = x.CurrentPatients,
                                                             WithdrawnPatients = x.WithdrawnPatients,
                                                             CompletedPatients = x.CompletedPatients,
                                                         }).ToList();
            return lstPatientaccrual;
        }


        /// <summary>
        /// Delete Patient Accrual
        /// </summary>
        /// <param name="patientaccrual"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeletePatientAccrual(Data.PatientAccrual patientaccrual, string userName)
        {
            int retVal = default(int);
            if (patientaccrual != null)
            {
                var result = dbContextNavigate.PatientAccrual.Where(x => x.PatientaccrualId == patientaccrual.PatientaccrualId
                                                                        && x.StudyId == patientaccrual.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new PatientAccrual_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get Activation Date
        /// </summary>
        /// <returns>Activation Date</returns>
        public List<Data.NewStudy> GetActivationDate(int studyId)
        {

            var lstActivationDate = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false)
                                                   .Select(x => new Data.NewStudy
                                                   {
                                                       StudyId = x.StudyId,
                                                       StudyActivationDate = x.StudyActivationDate
                                                   }).ToList();
            return lstActivationDate;

        }

        #endregion
    }
}
