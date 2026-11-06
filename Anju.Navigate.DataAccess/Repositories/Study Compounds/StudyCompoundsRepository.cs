using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StudyCompoundsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public StudyCompoundsRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get Study Compounds
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyCompounds> GetStudyCompounds(int studyId)
        {
            var lstStudyCompounds = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive)
                                                         .Select(x => new Data.StudyCompounds
                                                         {
                                                             StudyComponentId = x.StudyComponentId,
                                                             CompoundType = x.CompoundType,
                                                             CompanyCompound = x.CompanyCompound,
                                                             NonCompanyCompound = x.NonCompanyCompound,
                                                             CompoundCategory = x.CompoundCategory,
                                                             StudyId = x.StudyId

                                                         }).ToList();
            return lstStudyCompounds;
        }
               
        /// <summary>
        /// Create Update Study Compounds
        /// </summary>
        /// <param name="studyCompounds"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CreateUpdateStudyCompounds(Data.StudyCompounds studyCompounds, int studyId, string userName)
        {
            int retVal = default(int);
            string type = string.Empty;

            if (studyCompounds != null)
            {               
                var result = dbContextNavigate.StudyCompounds.Where(x => x.StudyComponentId == studyCompounds.StudyComponentId).SingleOrDefault();
                if (result != null)
                {
                    result.StudyComponentId = studyCompounds.StudyComponentId;
                    result.CompoundType = studyCompounds.CompoundType;
                    result.CompanyCompound = studyCompounds.CompanyCompound;
                    result.NonCompanyCompound = studyCompounds.NonCompanyCompound;
                    result.CompoundCategory = studyCompounds.CompoundCategory;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        if (result.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL)
                        {
                            var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (Studyresult != null)
                            {
                                if (!string.IsNullOrEmpty(studyCompounds.CompoundType))
                                {
                                    type = ConstDefaultValue.PRIMARYCOMPONENT;
                                    if (studyCompounds.CompoundType.Contains(type))
                                    {
                                        Studyresult.Primarydrug = studyCompounds.CompanyCompound;
                                    }
                                    type = ConstDefaultValue.SECONDARYCOMPONENT;
                                    if (studyCompounds.CompoundType.Contains(type))
                                    {
                                        Studyresult.Secondarydrug = studyCompounds.CompanyCompound;
                                        Studyresult.SecondaryType = studyCompounds.CompoundCategory;
                                    }
                                    type = ConstDefaultValue.TERTIARYCOMPONENT;
                                    if (studyCompounds.CompoundType.Contains(type))
                                    {
                                        Studyresult.Tertiarydrug = studyCompounds.CompanyCompound;
                                        Studyresult.TertiaryaryType = studyCompounds.CompoundCategory;
                                    }

                                }
                                Studyresult.ANJU_ChangedBy = userName;
                                Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(Studyresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                            }
                        }
                        if (retVal > 0)
                            return true;
                    }

                }
                else
                {
                    DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                    {
                        StudyId = studyId,
                        CompoundType = studyCompounds.CompoundType,
                        CompanyCompound = studyCompounds.CompanyCompound,
                        NonCompanyCompound = studyCompounds.NonCompanyCompound,
                        CompoundCategory = studyCompounds.CompoundCategory,
                        Module = ConstDefaultValue.EDITSTUDY,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow

                    };
                    retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);
                    if (retVal > 0)
                    {
                        var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (Studyresult == null)
                        {
                            DataAccess.DrugorCompounddetails objDrugorCompounddetails = new DataAccess.DrugorCompounddetails()
                            {
                                StudyId = studyId,
                                Primarydrug = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.PRIMARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                Secondarydrug = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                Tertiarydrug = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                SecondaryType = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).Select(y => y.CompoundCategory).FirstOrDefault(),
                                TertiaryaryType = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                IsActive = true,
                                IsDeleted = false,
                                ANJU_AddedBy = userName,
                                ANJU_AddDate = DateTime.UtcNow
                            };
                            retVal = dbContextNavigate.SaveChanges(objDrugorCompounddetails, new DrugorCompounddetails_H(), userName, eAuditChangeType.Insert);
                            if (retVal > 0)
                            {
                                var PrimaryComponent = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.PRIMARYCOMPONENT)).FirstOrDefault();
                                if (PrimaryComponent != null)
                                {
                                    PrimaryComponent.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                    PrimaryComponent.ANJU_ChangedBy = userName;
                                    PrimaryComponent.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(PrimaryComponent, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                                }
                                var secondarycomponent = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).FirstOrDefault();
                                if (secondarycomponent != null)
                                {
                                    secondarycomponent.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                    secondarycomponent.ANJU_ChangedBy = userName;
                                    secondarycomponent.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(secondarycomponent, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                                }
                                var teritorycomponent = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).FirstOrDefault();
                                if (teritorycomponent != null)
                                {
                                    teritorycomponent.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                    teritorycomponent.ANJU_ChangedBy = userName;
                                    teritorycomponent.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(teritorycomponent, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                                }
                            }
                        }
                        else
                        {
                            var primaryresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (primaryresult == null && string.IsNullOrWhiteSpace(primaryresult.Primarydrug))
                            {
                                primaryresult.Primarydrug = studyCompounds.CompanyCompound;
                                primaryresult.ANJU_ChangedBy = userName;
                                primaryresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(primaryresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                            }
                           
                            if (primaryresult != null && string.IsNullOrWhiteSpace(primaryresult.Secondarydrug))
                            {
                                primaryresult.Secondarydrug = studyCompounds.CompanyCompound;
                                primaryresult.SecondaryType = studyCompounds.CompoundCategory;
                                primaryresult.ANJU_ChangedBy = userName;
                                primaryresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(primaryresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                                if(retVal > 0)
                                {
                                    var secondarycomponent = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).FirstOrDefault();
                                    if (secondarycomponent != null)
                                    {
                                        secondarycomponent.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                        secondarycomponent.ANJU_ChangedBy = userName;
                                        secondarycomponent.ANJU_ChangeDate = DateTime.UtcNow;
                                        retVal = dbContextNavigate.SaveChanges(secondarycomponent, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                                    }
                                }
                            }
                           
                           else if (primaryresult != null && string.IsNullOrWhiteSpace(primaryresult.Tertiarydrug))
                            {
                                primaryresult.Secondarydrug = studyCompounds.CompanyCompound;
                                primaryresult.SecondaryType = studyCompounds.CompoundCategory;
                                primaryresult.ANJU_ChangedBy = userName;
                                primaryresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(primaryresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                                if(retVal > 0)
                                {
                                    var teritorycomponent = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).FirstOrDefault();
                                    if (teritorycomponent != null)
                                    {
                                        teritorycomponent.Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL;
                                        teritorycomponent.ANJU_ChangedBy = userName;
                                        teritorycomponent.ANJU_ChangeDate = DateTime.UtcNow;
                                        retVal = dbContextNavigate.SaveChanges(teritorycomponent, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                                    }
                                }
                            }
                        }

                    }
                }
                    
                if (retVal > 0)
                    return true;
            }
            return false;
        }


        public bool DeleteStudyCompounds(Data.StudyCompounds studyCompounds, string userName)
        {
            int retVal = default(int);
            string type = string.Empty;
            if (studyCompounds != null)
            {
                var result = dbContextNavigate.StudyCompounds.Where(x => x.StudyComponentId == studyCompounds.StudyComponentId).SingleOrDefault();
                if (result != null)
                {
                    result.StudyComponentId = studyCompounds.StudyComponentId;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new StudyCompounds_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    if (result.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL)
                    {
                        type = ConstDefaultValue.PRIMARYCOMPONENT;
                        if (result.CompoundType.Contains(type))
                        {
                            var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            Studyresult.Primarydrug = string.Empty;
                            Studyresult.ANJU_ChangedBy = userName;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(Studyresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                        }
                        type = ConstDefaultValue.SECONDARYCOMPONENT;
                        if (result.CompoundType.Contains(type))
                        {
                            var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            Studyresult.Secondarydrug = string.Empty;
                            Studyresult.SecondaryType = string.Empty;
                            Studyresult.ANJU_ChangedBy = userName;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(Studyresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                        }
                        type = ConstDefaultValue.TERTIARYCOMPONENT;
                        if (result.CompoundType.Contains(type))
                        {
                            var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            Studyresult.Tertiarydrug = string.Empty;
                            Studyresult.TertiaryaryType = string.Empty;
                            Studyresult.ANJU_ChangedBy = userName;
                            Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(Studyresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);
                        }
                        if(retVal > 0)
                        {
                            var Studyresult = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if(string.IsNullOrEmpty(Studyresult.Primarydrug) && (string.IsNullOrEmpty(Studyresult.Secondarydrug) || string.IsNullOrEmpty(Studyresult.Tertiarydrug)))
                            {
                                Studyresult.IsActive = false;
                                Studyresult.IsDeleted = true;
                                Studyresult.ANJU_ChangedBy = userName;
                                Studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(Studyresult, new DrugorCompounddetails_H(), userName, eAuditChangeType.Delete);
                                if(retVal > 0)
                                {
                                    var isExist = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.PRIMARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault();
                                    if(isExist != null) {
                                        DataAccess.DrugorCompounddetails objDrugorCompounddetails = new DataAccess.DrugorCompounddetails()
                                        {
                                            StudyId = studyCompounds.StudyId,
                                            Primarydrug = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.PRIMARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                            Secondarydrug = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                            Tertiarydrug = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                            SecondaryType = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.SECONDARYCOMPONENT)).Select(y => y.CompoundCategory).FirstOrDefault(),
                                            TertiaryaryType = dbContextNavigate.StudyCompounds?.Where(x => x.StudyId == studyCompounds.StudyId && x.IsActive == true && x.IsDeleted == false && x.CompoundType.Contains(ConstDefaultValue.TERTIARYCOMPONENT)).Select(y => y.CompanyCompound).FirstOrDefault(),
                                            IsActive = true,
                                            IsDeleted = false,
                                            ANJU_AddedBy = userName,
                                            ANJU_AddDate = DateTime.UtcNow
                                        };
                                        retVal = dbContextNavigate.SaveChanges(objDrugorCompounddetails, new DrugorCompounddetails_H(), userName, eAuditChangeType.Insert);

                                    }
                                   
                                }
                            }
                        }
                        
                    }
                    if (retVal > 0)
                        return true;
                }
            }
            return false;
        }
        #endregion
    }
}
