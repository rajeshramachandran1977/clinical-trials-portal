using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class MilestonesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public MilestonesRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods

        /// <summary>
        /// Get Milestones
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Milestones> GetMilestones(int studyId)
        {
            var lstMilestones = dbContextNavigate.Milestones.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.Milestones
                                                         {
                                                            MilestoneId = x.MilestoneId,
                                                            StudyId = x.StudyId,
                                                            Name = x.Name,
                                                            Type = x.Type,
                                                            Phase = x.Phase,
                                                            Parameters = x.Parameters,
                                                            Dependency = x.Dependency,
                                                            Estimatedcompletiondate = x.Estimatedcompletiondate,
                                                            Milestonecompletiondate = x.Milestonecompletiondate,
                                                            MilestoneStatus = x.MilestoneStatus,
                                                            Remindersentdate = x.Remindersentdate
                                                         }).ToList();
            return lstMilestones;
        }


        /// <summary>
        /// Create/Update Milestones
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateMilestones(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objMilestones = dbContextNavigate.Milestones.Where(x => x.MilestoneId == newStudy.MilestoneId &&
                                                                   x.StudyId == newStudy.StudyId).FirstOrDefault();
            if (objMilestones != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isnamerestricted = false;
                bool istyperestricted = false;
                bool isphaserestricted = false;
                bool isparametersrestricted = false;
                bool isdependencyrsrestricted = false;
                bool isestimatedcompletiondaterestricted = false;
                bool ismilestonecompletiondaterestricted = false;
                bool isstatusrestricted = false;
                bool isremindersentdaterestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.MILESTONENAME:
                            objMilestones.Name = newStudy.Name ?? objMilestones.Name;
                            isnamerestricted = true;
                            break;
                        case ConstDefaultValue.MILESTONETYPE:
                            objMilestones.Type = newStudy.Type ?? objMilestones.Type;
                            istyperestricted = true;
                            break;
                        case ConstDefaultValue.MILESTONEPHASE:
                            objMilestones.Phase = newStudy.Phase ?? objMilestones.Phase;
                            isphaserestricted = true;
                            break;
                        case ConstDefaultValue.MILESTONEPARAMETERS:
                            objMilestones.Parameters = newStudy.Parameters ?? objMilestones.Parameters;
                            isparametersrestricted = true;
                            break;
                        case ConstDefaultValue.DEPENDENCY:
                            objMilestones.Dependency = newStudy.Dependency ?? objMilestones.Dependency;
                            isdependencyrsrestricted = true;
                            break;
                        case ConstDefaultValue.ESTIMATEDCOMPLETIONDATE:
                            objMilestones.Estimatedcompletiondate = newStudy.Estimatedcompletiondate ?? objMilestones.Estimatedcompletiondate;
                            isestimatedcompletiondaterestricted = true;
                            break;
                        case ConstDefaultValue.MILESTONECOMPLETIONDATE:
                            objMilestones.Milestonecompletiondate = newStudy.Milestonecompletiondate ?? objMilestones.Milestonecompletiondate;
                            ismilestonecompletiondaterestricted = true;
                            break;
                        case ConstDefaultValue.STATUS:
                            objMilestones.MilestoneStatus = newStudy.MilestoneStatus ?? objMilestones.MilestoneStatus;
                            isstatusrestricted = true;
                            break;
                        case ConstDefaultValue.REMINDERSENTDATE:
                            objMilestones.Remindersentdate = newStudy.Remindersentdate ?? objMilestones.Remindersentdate;
                            isremindersentdaterestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (isnamerestricted == false)
                    objMilestones.Name = newStudy.Name;
                if (istyperestricted == false)
                    objMilestones.Type = newStudy.Type;
                if (isphaserestricted == false)
                    objMilestones.Phase = newStudy.Phase;
                if (isparametersrestricted == false)
                    objMilestones.Parameters = newStudy.Parameters;
                if (isdependencyrsrestricted == false)
                    objMilestones.Dependency = newStudy.Dependency;
                if (isestimatedcompletiondaterestricted == false)
                    objMilestones.Estimatedcompletiondate = newStudy.Estimatedcompletiondate;
                if (ismilestonecompletiondaterestricted == false)
                    objMilestones.Milestonecompletiondate = newStudy.Milestonecompletiondate;
                if (isstatusrestricted == false)
                    objMilestones.MilestoneStatus = newStudy.MilestoneStatus;
                if (isremindersentdaterestricted == false)
                    objMilestones.Remindersentdate = newStudy.Remindersentdate;

                objMilestones.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objMilestones.ANJU_ChangeDate = DateTime.UtcNow;
              
                retVal = dbContextNavigate.SaveChanges(objMilestones, new Milestones_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.Milestones milestones = new DataAccess.Milestones()
                {
                    StudyId = newStudy.StudyId,
                    Name = newStudy.Name,
                    Type = newStudy.Type,
                    Phase = newStudy.Phase,
                    Parameters = newStudy.Parameters,
                    Dependency = newStudy.Dependency,
                    Estimatedcompletiondate = newStudy.Estimatedcompletiondate,
                    Milestonecompletiondate = newStudy.Milestonecompletiondate,
                    MilestoneStatus = newStudy.Status,
                    Remindersentdate = newStudy.Remindersentdate,

                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };                
                retVal = dbContextNavigate.SaveChanges(milestones, new Milestones_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
            {
                if (objMilestones != null)
                {
                    if (objMilestones.Name == "Activation (Drug Shipment)")
                    {
                        var studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (studyresult != null)
                        {
                            if (studyresult.StudyActivationDate != newStudy.Milestonecompletiondate)
                            {
                                studyresult.StudyActivationDate = newStudy.Milestonecompletiondate;
                                studyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(studyresult, new NewStudy_H(), studyresult.ANJU_ChangedBy, eAuditChangeType.Update);
                                if (retVal > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                    }
                    if (objMilestones.Name == "Submission Approval" && retVal > 0)
                    {
                        var Mrcresult = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == newStudy.StudyId && x.IsActive == true && x.IsDeleted == false && x.RecordType == Utilities.Messages.GlobalMRC).FirstOrDefault();
                        if (Mrcresult != null)
                        {
                            if (Mrcresult.GlobalMrcdecisionDate != newStudy.Milestonecompletiondate && newStudy.Milestonecompletiondate > Mrcresult.GlobalMrcdecisionDate)
                            {
                                Mrcresult.GlobalMrcdecisionDate = newStudy.Milestonecompletiondate;
                                Mrcresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                Mrcresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(Mrcresult, new MRCStudyReview_H(), Mrcresult.ANJU_ChangedBy, eAuditChangeType.Update);
                                if (retVal > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }

                    }
                    if (objMilestones.Name == "First Patient First Visit - the date the first patient received study drug" && retVal > 0)
                    {
                        var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == newStudy.StudyId).ToList();
                        if (result.Count > 0)
                        {
                            for (int i = 0; i < result.Count; i++)
                            {
                                if (result[i].LastPatientFirstVisit >= newStudy.Milestonecompletiondate)
                                {
                                    result[i].FirstPatientFirstVisit = newStudy.Milestonecompletiondate;
                                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                                    result[i].ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                    retVal = dbContextNavigate.SaveChanges(result[i], new PatientAccrual_H(), result[i].ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                    if (objMilestones.Name == "Last Patient First Visit - Enrollment Complete" && retVal > 0)
                    {
                        var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == newStudy.StudyId).ToList();
                        if (result.Count > 0)
                        {
                            for (int i = 0; i < result.Count; i++)
                            {
                                if (result[i].LastPatientLastTreatment >= newStudy.Milestonecompletiondate && result[i].FirstPatientFirstVisit <= newStudy.Milestonecompletiondate)
                                {
                                    result[i].LastPatientFirstVisit = newStudy.Milestonecompletiondate;
                                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                                    result[i].ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                    retVal = dbContextNavigate.SaveChanges(result[i], new PatientAccrual_H(), result[i].ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                    if (objMilestones.Name == "Last Patient Last Treatment -- the date the last patient receives their last dose of study drug" && retVal > 0)
                    {
                        var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == newStudy.StudyId).ToList();
                        if (result.Count > 0)
                        {
                            for (int i = 0; i < result.Count; i++)
                            {
                                if (result[i].LastPatientLastVisit >= newStudy.Milestonecompletiondate && result[i].LastPatientFirstVisit <= newStudy.Milestonecompletiondate)
                                {
                                    result[i].LastPatientLastTreatment = newStudy.Milestonecompletiondate;
                                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                                    result[i].ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                    retVal = dbContextNavigate.SaveChanges(result[i], new PatientAccrual_H(), result[i].ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                    if (objMilestones.Name == "Last Patient Last Visit (LPLV)" && retVal > 0)
                    {
                        var result = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == newStudy.StudyId).ToList();
                        if (result.Count > 0)
                        {
                            for (int i = 0; i < result.Count; i++)
                            {
                                if (result[i].LastPatientLastTreatment <= newStudy.Milestonecompletiondate)
                                {
                                    result[i].LastPatientLastVisit = newStudy.Milestonecompletiondate;
                                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                                    result[i].ANJU_ChangedBy = newStudy.ANJU_ChangedBy ?? newStudy.ANJU_AddedBy;
                                    retVal = dbContextNavigate.SaveChanges(result[i], new PatientAccrual_H(), result[i].ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                }
                return true;
            }               
            else
                return false;
        }

        /// <summary>
        /// Delete Milestones
        /// </summary>
        /// <param name="milestones"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteMilestones(Data.Milestones milestones, string userName)
        {
            int retVal = default(int);
            if (milestones != null)
            {
                var result = dbContextNavigate.Milestones.Where(x => x.MilestoneId == milestones.MilestoneId
                                                                        && x.StudyId == milestones.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new Milestones_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultMileStone"></param>
        /// <returns></returns>

        public bool CreateUpdateDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone, string userName)
        {
            int retVal = default(int);
            if (defaultMileStone != null)
            {
                var result = dbContextNavigate.DefaultMileStone.Where(x => x.DefaultMilestoneId == defaultMileStone.DefaultMilestoneId).FirstOrDefault();
                if (result != null)
                {
                    result.DefaultMilestoneId = defaultMileStone.DefaultMilestoneId;
                    result.MilestoneName = defaultMileStone.MilestoneName;
                    result.MilestoneType = defaultMileStone.MilestoneType;
                    result.StudyPhase = defaultMileStone.StudyPhase;
                    result.BusinessDays = defaultMileStone.BusinessDays;
                    result.Comments = defaultMileStone.Comments;
                    result.Dependency = defaultMileStone.Dependency;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new DefaultMileStone_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.DefaultMileStone objDefaultMileStone = new DataAccess.DefaultMileStone()
                    {

                        MilestoneName = defaultMileStone.MilestoneName,
                        MilestoneType = defaultMileStone.MilestoneType,
                        StudyPhase = defaultMileStone.StudyPhase,
                        BusinessDays = defaultMileStone.BusinessDays,
                        Comments = defaultMileStone.Comments,
                        Dependency = defaultMileStone.Dependency,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow

                    };
                    dbContextNavigate.SaveChanges(objDefaultMileStone, new DefaultMileStone_H(), userName, eAuditChangeType.Insert);
                    retVal = objDefaultMileStone.DefaultMilestoneId;
                    defaultMileStone.DefaultMilestoneId = objDefaultMileStone.DefaultMilestoneId;
                }

                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete Default Milestone Details
        /// </summary>
        /// <param name="defaultMileStone"></param>
        /// <returns></returns>
        public bool DeleteDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone, string userName)
        {
            int retVal = default(int);

            if (defaultMileStone == null)
            {
                throw new ArgumentNullException(nameof(defaultMileStone));
            }           
            if (defaultMileStone != null)
            {
                var result = dbContextNavigate.DefaultMileStone.Where(x => x.DefaultMilestoneId == defaultMileStone.DefaultMilestoneId).FirstOrDefault();
                if (result != null)
                {
                    result.DefaultMilestoneId = defaultMileStone.DefaultMilestoneId;
                    result.MilestoneName = defaultMileStone.MilestoneName;
                    result.MilestoneType = defaultMileStone.MilestoneType;
                    result.StudyPhase = defaultMileStone.StudyPhase;
                    result.BusinessDays = defaultMileStone.BusinessDays;
                    result.Comments = defaultMileStone.Comments;
                    result.Dependency = defaultMileStone.Dependency;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new DefaultMileStone_H(), userName, eAuditChangeType.Delete);
                }
                if (retVal > 0)
                    return true;
            }
            return false;
        }


        #endregion
    }
}
