using Anju.Navigate.Utilities;
using System;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class DrugorCompounddetailsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public DrugorCompounddetailsRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Methods    

        /// <summary>
        /// Enter Drug or Compounddetails
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="drugorCompounddetails"></param>
        /// <param name="mode"></param>
        public void CreateUpdaterDrugorCompounddetails(int StudyID, Data.DrugorCompounddetails drugorCompounddetails, string userName)
        {
            int retVal = default(int);
            string type = string.Empty;
            string CompoundType = string.Empty;
            if (drugorCompounddetails != null)
            {
                var result = dbContextNavigate.DrugorCompounddetails.Where(x => x.StudyId == StudyID && x.IsActive == true && x.IsDeleted == false).SingleOrDefault();
                if (result != null)
                {
                    result.Primarydrug = drugorCompounddetails.Primarydrug;
                    result.Secondarydrug = drugorCompounddetails.Secondarydrug;
                    result.Tertiarydrug = drugorCompounddetails.Tertiarydrug;
                    result.SecondaryType = drugorCompounddetails.SecondaryType;
                    result.TertiaryaryType = drugorCompounddetails.TertiaryaryType;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;

                    retVal = dbContextNavigate.SaveChanges(result, new DrugorCompounddetails_H(), userName, eAuditChangeType.Update);

                    if (retVal > 0)
                    {
                        if (!string.IsNullOrEmpty(result.Primarydrug))
                        {
                            type = ConstDefaultValue.PRIMARYCOMPONENT;
                            var resultProtocol = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == StudyID && x.ANJU_AddedBy == result.ANJU_AddedBy && x.CompoundType.Contains(type) && x.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (resultProtocol != null)
                            {
                                resultProtocol.CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code.Trim()).FirstOrDefault();
                                resultProtocol.CompanyCompound = result.Primarydrug;
                                resultProtocol.ANJU_ChangedBy = userName;
                                resultProtocol.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(resultProtocol, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                            }
                            else
                            {
                                type = ConstDefaultValue.PRIMARYCOMPONENT;
                                CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                                if (CompoundType != null)
                                {
                                    DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                    {
                                        StudyId = StudyID,
                                        CompoundType = CompoundType,
                                        CompanyCompound = drugorCompounddetails.Primarydrug,
                                        //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                        //CompoundCategory = studyCompounds.CompoundCategory,
                                        IsActive = true,
                                        IsDeleted = false,
                                        Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                        ANJU_AddedBy = userName,
                                        ANJU_AddDate = DateTime.UtcNow

                                    };
                                    retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);

                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(result.Secondarydrug))
                        {
                            type = ConstDefaultValue.SECONDARYCOMPONENT;
                            var resultProtocol = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == StudyID && x.ANJU_AddedBy == result.ANJU_AddedBy && x.CompoundType.Contains(type) && x.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (resultProtocol != null)
                            {
                                resultProtocol.CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code.Trim()).FirstOrDefault();
                                resultProtocol.CompanyCompound = result.Secondarydrug;
                                resultProtocol.CompoundCategory = result.SecondaryType;
                                resultProtocol.ANJU_ChangedBy = userName;
                                resultProtocol.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(resultProtocol, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                            }
                            else
                            {
                                type = ConstDefaultValue.SECONDARYCOMPONENT;
                                CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                                if (CompoundType != null)
                                {
                                    DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                    {
                                        StudyId = StudyID,
                                        CompoundType = CompoundType,
                                        CompanyCompound = drugorCompounddetails.Secondarydrug,
                                        //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                        CompoundCategory = drugorCompounddetails.SecondaryType,
                                        Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = userName,
                                        ANJU_AddDate = DateTime.UtcNow

                                    };
                                    retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);
                                }
                            }

                        }
                        if (!string.IsNullOrEmpty(result.Tertiarydrug))
                        {
                            type = ConstDefaultValue.TERTIARYCOMPONENT;
                            var resultProtocol = dbContextNavigate.StudyCompounds.Where(x => x.StudyId == StudyID && x.ANJU_AddedBy == result.ANJU_AddedBy && x.CompoundType.Contains(type) && x.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (resultProtocol != null)
                            {
                                resultProtocol.CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code.Trim()).FirstOrDefault();
                                resultProtocol.CompanyCompound = result.Tertiarydrug;
                                resultProtocol.CompoundCategory = result.TertiaryaryType;
                                resultProtocol.ANJU_ChangedBy = userName;
                                resultProtocol.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(resultProtocol, new StudyCompounds_H(), userName, eAuditChangeType.Update);
                            }
                            else
                            {
                                type = ConstDefaultValue.TERTIARYCOMPONENT;
                                CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                                if (CompoundType != null)
                                {
                                    DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                    {
                                        StudyId = StudyID,
                                        CompoundType = CompoundType,
                                        CompanyCompound = drugorCompounddetails.Tertiarydrug,
                                        //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                        CompoundCategory = drugorCompounddetails.TertiaryaryType,
                                        Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = userName,
                                        ANJU_AddDate = DateTime.UtcNow

                                    };
                                    retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);

                                }
                            }
                        }

                    }
                }
                else
                {
                    DataAccess.DrugorCompounddetails objDrugorCompounddetails = new DataAccess.DrugorCompounddetails()
                    {
                        StudyId = StudyID,
                        Primarydrug = drugorCompounddetails.Primarydrug,
                        Secondarydrug = drugorCompounddetails.Secondarydrug,
                        Tertiarydrug = drugorCompounddetails.Tertiarydrug,
                        SecondaryType = drugorCompounddetails.SecondaryType,
                        TertiaryaryType = drugorCompounddetails.TertiaryaryType,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objDrugorCompounddetails, new DrugorCompounddetails_H(), userName, eAuditChangeType.Insert);

                    if (retVal > 0)
                    {
                        if (!string.IsNullOrEmpty(drugorCompounddetails.Primarydrug))
                        {
                            type = ConstDefaultValue.PRIMARYCOMPONENT;
                            CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                            if (CompoundType != null)
                            {
                                DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                {
                                    StudyId = StudyID,
                                    CompoundType = CompoundType,
                                    CompanyCompound = drugorCompounddetails.Primarydrug,
                                    //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                    //CompoundCategory = studyCompounds.CompoundCategory,
                                    IsActive = true,
                                    IsDeleted = false,
                                    Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                    ANJU_AddedBy = userName,
                                    ANJU_AddDate = DateTime.UtcNow

                                };
                                retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);

                            }
                        }
                        if (!string.IsNullOrEmpty(drugorCompounddetails.Secondarydrug))
                        {
                            type = ConstDefaultValue.SECONDARYCOMPONENT;
                            CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                            if (CompoundType != null)
                            {
                                DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                {
                                    StudyId = StudyID,
                                    CompoundType = CompoundType,
                                    CompanyCompound = drugorCompounddetails.Secondarydrug,
                                    //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                    CompoundCategory = drugorCompounddetails.SecondaryType,
                                    Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = userName,
                                    ANJU_AddDate = DateTime.UtcNow

                                };
                                retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);
                            }

                        }
                        if (!string.IsNullOrEmpty(drugorCompounddetails.Tertiarydrug))
                        {
                            type = ConstDefaultValue.TERTIARYCOMPONENT;
                            CompoundType = dbContextNavigate.SysCodeValues.Where(y => y.ColumnName == ConstDefaultValue.COMPOUNDTYPE && y.IsActive == true && y.IsDeleted == false && y.Code.Contains(type)).Select(w => w.Code).FirstOrDefault();
                            if (CompoundType != null)
                            {
                                DataAccess.StudyCompounds objstudyCompounds = new DataAccess.StudyCompounds()
                                {
                                    StudyId = StudyID,
                                    CompoundType = CompoundType,
                                    CompanyCompound = drugorCompounddetails.Tertiarydrug,
                                    //NonCompanyCompound = studyCompounds.NonCompanyCompound,
                                    CompoundCategory = drugorCompounddetails.TertiaryaryType,
                                    Module = ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = userName,
                                    ANJU_AddDate = DateTime.UtcNow

                                };
                                retVal = dbContextNavigate.SaveChanges(objstudyCompounds, new StudyCompounds_H(), userName, eAuditChangeType.Insert);

                            }

                        }
                    }
                }
            }
            

        }

        #endregion

    }
}
       
