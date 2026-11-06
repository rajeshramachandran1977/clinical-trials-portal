using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class SysCodeValuesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public SysCodeValuesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get syscode values By Column Name
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>list of syscodes</returns>
        public List<Data.SysCodeValues> GetSysCodeValuesByColumnName(string columnName)
        {
            var lstSysCodes = dbContextNavigate.SysCodeValues.Where(x => (x.ColumnName.ToUpper().Trim() == columnName.ToUpper().Trim()) && (x.IsActive == true) && (x.IsDeleted == false)).OrderBy(x => x.SortOrder)
                                                               .Select(x => new Data.SysCodeValues
                                                               {
                                                                   CodeId = x.CodeId,
                                                                   Code = x.Code.Trim(),
                                                                   Description = x.Description.Trim()
                                                               }).ToList();
            return lstSysCodes;
        }

        /// <summary>
        /// Get the list of SysCode Values
        /// </summary>
        /// <returns>lstSysCodes</returns>
        public List<Data.SysCodeValues> GetSysCodes()
        {
            var lstSysCodes = dbContextNavigate.SysCodeValues.Where(x => x.IsActive == true && x.IsDeleted == false && x.IsDisplay == true).OrderBy(x => x.SortOrder)
                                                         .Select(x => new Data.SysCodeValues
                                                         {
                                                             CodeId = x.CodeId,
                                                             TableName = x.TableName,
                                                             ColumnName = x.ColumnName,
                                                             Code = x.Code,
                                                             Description = x.Description,
                                                             SortOrder = x.SortOrder,
                                                             IsDefault = x.IsDefault,
                                                             IsDisplay = x.IsDisplay,
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstSysCodes;
        }

        /// <summary>
        /// Get the list of SysCode Column Values
        /// </summary>
        /// <returns>lstSysCodeColumn</returns>
        public List<Data.SysCodeValues> GetSysCodeColumn()
        {
            var lstSysCodeColumn = dbContextNavigate.SysCodeValues.Where(x => x.IsActive == true && x.IsDeleted == false && x.IsDisplay == true)
                                                         .Select(x => new Data.SysCodeValues
                                                         {
                                                             ColumnName = x.ColumnName
                                                         }).Distinct().ToList();
            return lstSysCodeColumn;
        }

        /// <summary>
        /// Get the list of SysCode Column Values
        /// </summary>
        /// <returns>lstSysCodeColumn</returns>
        public List<Data.SysCodeValues> GetSysCodeColumnbyName(string columnName)
        {
            var lstSysCodeColumn = dbContextNavigate.SysCodeValues.Where(x => x.IsActive == true && x.IsDeleted == false && x.ColumnName == columnName)
                                                         .Select(x => new Data.SysCodeValues
                                                         {
                                                             ColumnName = x.ColumnName,
                                                             TableName = x.TableName,
                                                             Code = x.Code,
                                                             CodeId = x.CodeId
                                                         }).Distinct().ToList();
            return lstSysCodeColumn;
        }

        /// <summary>
        /// Create Sys Codes
        /// </summary>
        /// <param name="sysCodes"></param>
        /// <returns>true/false</returns>
        public bool CreateSysCodeValues(Data.SysCodeValues sysCodeValues, string value, string tableName,string userName)
        {
            long retVal = default(long);
            if (sysCodeValues != null)
            {
                if (value != null)
                {
                    DataAccess.SysCodeValues objsyscodes = new DataAccess.SysCodeValues()
                    {
                        TableName = tableName,
                        ColumnName = value,
                        Code = sysCodeValues.Code,
                        SortOrder = sysCodeValues.SortOrder,
                        Description = sysCodeValues.Description,
                        IsDefault = sysCodeValues.IsDefault,
                        IsDisplay = true,
                        IsActive = sysCodeValues.IsActive,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    dbContextNavigate.SaveChanges(objsyscodes, new SysCodeValues_H(), userName, eAuditChangeType.Insert);
                    retVal = objsyscodes.CodeId;
                    sysCodeValues.CodeId = objsyscodes.CodeId;
                    if (retVal > 0)
                        return true;
                }
                else
                {
                    DataAccess.SysCodeValues objsyscodes = new DataAccess.SysCodeValues()
                    {
                        TableName = sysCodeValues.TableName,
                        ColumnName = sysCodeValues.ColumnName,
                        Code = sysCodeValues.Code,
                        SortOrder = sysCodeValues.SortOrder,
                        Description = sysCodeValues.Description,
                        IsActive = sysCodeValues.IsActive,
                        IsDefault = sysCodeValues.IsDefault,
                        IsDisplay = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    dbContextNavigate.SaveChanges(objsyscodes, new SysCodeValues_H(), userName, eAuditChangeType.Insert);
                    retVal = objsyscodes.CodeId;
                    sysCodeValues.CodeId = objsyscodes.CodeId;
                    if (retVal > 0)
                        return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Update SysCodeValues
        /// </summary>
        /// <param name="SysCodeValues"></param>
        /// <returns>true/false</returns>
        public bool UpdateSysCodeValues(Data.SysCodeValues sysCodeValues,string userName)
        {
            int retVal = default(int);
            if (sysCodeValues != null)
            {
                var result = dbContextNavigate.SysCodeValues.Where(x => x.CodeId == sysCodeValues.CodeId && x.TableName == sysCodeValues.TableName && x.ColumnName == sysCodeValues.ColumnName && x.IsActive == true && x.IsDeleted == false).ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].TableName = sysCodeValues.TableName;
                    result[i].ColumnName = sysCodeValues.ColumnName;
                    result[i].Code = sysCodeValues.Code;
                    result[i].Description = sysCodeValues.Description;
                    result[i].SortOrder = sysCodeValues.SortOrder;
                    result[i].IsDefault = sysCodeValues.IsDefault;
                    result[i].IsDisplay = true;
                    result[i].IsActive = sysCodeValues.IsActive;
                    result[i].IsDeleted = false;
                    result[i].ANJU_ChangedBy = userName;
                    result[i].ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result[i], new SysCodeValues_H(), userName, eAuditChangeType.Update);
                }
                if (retVal > 0)
                {
                    var resultDefault = dbContextNavigate.SysCodeValues.Where(x => x.TableName == sysCodeValues.TableName && x.ColumnName == sysCodeValues.ColumnName && x.IsActive == true && x.IsDeleted == false && x.IsDefault == true).FirstOrDefault();
                    if (resultDefault != null)
                    {
                        resultDefault.SortOrder = 0;
                        retVal = dbContextNavigate.SaveChanges(resultDefault, new SysCodeValues_H(), userName, eAuditChangeType.Update);
                    }
                    if (retVal > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// Update SysCodeValuesOrder
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="codeID"></param>
        /// <returns>true/false</returns>
        public bool UpdateSysCodeValuesOrder(int codeId, int sortOrder, String codeName,string userName)
        {
            int retVal = default(int);
            var result = dbContextNavigate.SysCodeValues.Where(x => x.IsActive == true && x.IsDeleted == false && x.Code == codeName && x.CodeId == codeId).SingleOrDefault();
            if (result != null)
            {
                result.SortOrder = sortOrder;
                retVal = dbContextNavigate.SaveChanges(result, new SysCodeValues_H(), userName, eAuditChangeType.Update);

            }
            if (retVal > 0)
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Delete SysCodeValues
        /// </summary>
        /// <param name="SysCodeValues"></param>
        /// <returns>true/false</returns>
        public bool DeleteSysCodeValues(Data.SysCodeValues sysCodeValues,string userName)
        {
            if (sysCodeValues == null)
            {
                throw new ArgumentNullException(nameof(sysCodeValues));
            }

            int retVal = default(int);
            if (sysCodeValues != null)
            {
                DataAccess.SysCodeValues objsysCodeValues = new DataAccess.SysCodeValues()
                {
                    CodeId = sysCodeValues.CodeId,
                    TableName = sysCodeValues.TableName,
                    ColumnName = sysCodeValues.ColumnName,
                    Code = sysCodeValues.Code,
                    SortOrder = sysCodeValues.SortOrder,
                    Description = sysCodeValues.Description,
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objsysCodeValues, new SysCodeValues_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        public string GetHelpEmailAddress()
        {
            var emailAddress = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == Utilities.ConstDefaultValue.EMAIL_DEFAULT_POSTBOX).Select(x => x.GlobalValue).FirstOrDefault();
            return emailAddress;
        }
        #endregion
    }
}
