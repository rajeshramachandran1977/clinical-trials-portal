using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class GlobalSettingsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public GlobalSettingsRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     
        /// <summary>
        /// Get Password Policy details
        /// </summary>
        /// <returns></returns>
        public List<Data.GlobalSettings> GetPwdPolicydetails()
        {
            var userInfo = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == "EnforcePasswordLength".ToUpper()
            || x.GlobalKey.ToUpper() == "EnforceOneUpperandOneLowerCaseCharacter".ToUpper())
            || x.GlobalKey.ToUpper() == "EnforceOneNumber".ToUpper()
            || x.GlobalKey.ToUpper() == "EnforceSpecialChar".ToUpper()).Select(x => new Data.GlobalSettings
            {
                GlobalKey = x.GlobalKey,
                GlobalValue = x.GlobalValue

            }).ToList();

            return userInfo;
        }

        /// <summary>
        /// Get the list of GlobalSettings Values
        /// </summary>
        /// <returns>lstGlobalSettings</returns>
        public List<Data.GlobalSettings> GetGlobalSettings()
        {
            var lstGlobalSettings = dbContextNavigate.GlobalSettings.Where(x => x.IsActive == true && x.IsDeleted == false).OrderBy(x => x.SortOrder)
                                                         .Select(x => new Data.GlobalSettings
                                                         {
                                                             GlobalId = x.GlobalId,
                                                             GlobalKey = x.GlobalKey,
                                                             GlobalValue = x.GlobalValue,
                                                             Remarks = x.Remarks,
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstGlobalSettings;
        }

        /// <summary>
        /// Get the list of GlobalSettings Values by GlobalKey
        /// </summary>
        /// <returns>lstGlobalSettings</returns>
        public List<Data.GlobalSettings> GetGlobalSettingsByGlobalKey(string globalKey)
        {
            var lstGlobalSettings = dbContextNavigate.GlobalSettings.Where(x => x.IsActive == true && x.IsDeleted == false && x.GlobalKey == globalKey.Trim())
                                                         .Select(x => new Data.GlobalSettings
                                                         {
                                                             GlobalValue = x.GlobalValue

                                                         }).ToList();
            return lstGlobalSettings;
        }

        /// <summary>
        /// Update GlobalSettings
        /// </summary>
        /// <param name="globalSettings"></param>
        /// <returns>true/false</returns>
        public bool UpdateGlobalSettings(Data.GlobalSettings globalSettings, string userName)
        {
            int retVal = default(int);
            if (globalSettings != null)
            {
                var isCompanyNameChanged = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == Utilities.ConstDefaultValue.APPNAME && globalSettings.GlobalKey == Utilities.ConstDefaultValue.APPNAME).FirstOrDefault();

                if (!string.IsNullOrEmpty(isCompanyNameChanged?.GlobalKey))
                {
                    var oldCompanyName = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == Utilities.ConstDefaultValue.APPNAME).Select(x => x.GlobalValue).FirstOrDefault();
                    if (oldCompanyName != Utilities.ConstDefaultValue.COMPANY)
                    {
                        var result1 = dbContextNavigate.SysCodeValues.Where(x => x.Code.Contains(oldCompanyName)).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            string str = result1[i].Code;
                            String str1 = str.Replace(oldCompanyName, globalSettings.GlobalValue);
                            result1[i].Code = str1;
                            result1[i].Description = str1;
                            retVal = dbContextNavigate.SaveChanges(result1[i], new SysCodeValues_H(), userName, eAuditChangeType.Update);
                        }
                        var result2 = dbContextNavigate.EditStudyAttributes.Where(x => x.Name.Contains(oldCompanyName)).ToList();
                        for (int i = 0; i < result2.Count; i++)
                        {
                            string str = result2[i].Name;
                            String str1 = str.Replace(oldCompanyName, globalSettings.GlobalValue);
                            result2[i].Name = str1;
                            result2[i].GrandChildName = str1;
                            result2[i].Description = str1;
                            retVal = dbContextNavigate.SaveChanges(result2[i], new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                        }
                    }
                    else if (oldCompanyName == Utilities.ConstDefaultValue.COMPANY)
                    {
                        var result1 = dbContextNavigate.SysCodeValues.Where(x => x.Code.Contains("[Company]")).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            string str = result1[i].Code;
                            String str1 = str.Replace("[Company]", globalSettings.GlobalValue);
                            result1[i].Code = str1;
                            result1[i].Description = str1;
                            retVal = dbContextNavigate.SaveChanges(result1[i], new SysCodeValues_H(), userName, eAuditChangeType.Update);
                        }
                        var result2 = dbContextNavigate.EditStudyAttributes.Where(x => x.Name.Contains("[Company]")).ToList();
                        for (int i = 0; i < result2.Count; i++)
                        {
                            string str = result2[i].Name;
                            String str1 = str.Replace("[Company]", globalSettings.GlobalValue);
                            result2[i].Name = str1;
                            result2[i].GrandChildName = str1;
                            result2[i].Description = str1;
                            retVal = dbContextNavigate.SaveChanges(result2[i], new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                        }
                    }
                    Utilities.ConfigValues.appName = globalSettings.GlobalValue;
                }

                var result = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == globalSettings.GlobalKey && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                {
                    result.GlobalKey = globalSettings.GlobalKey;
                    result.GlobalValue = globalSettings.GlobalValue;
                    result.Remarks = globalSettings.Remarks;
                    result.IsDeleted = false;
                    result.IsActive = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                retVal = dbContextNavigate.SaveChanges(result, new GlobalSettings_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// Delete globalSettings
        ///// </summary>
        ///// <param name="globalSettings"></param>
        ///// <returns>true/false</returns>
        //public bool DeleteGlobalSettings(Data.GlobalSettings globalSettings)
        //{
        //    if (globalSettings == null)
        //    {
        //        throw new ArgumentNullException(nameof(globalSettings));
        //    }

        //    int retVal = default(int);
        //    if (globalSettings != null)
        //    {
        //        DataAccess.GlobalSettings objglobalSettings = new DataAccess.GlobalSettings()
        //        {
        //            GlobalId = globalSettings.GlobalId,
        //            GlobalKey = globalSettings.GlobalKey,
        //            GlobalValue = globalSettings.GlobalValue,
        //            IsActive = false,
        //            IsDeleted = true,
        //            ANJU_ChangedBy = "Administrator",
        //            ANJU_ChangeDate = DateTime.UtcNow
        //        };
        //        dbContextNavigate.GlobalSettings.Update(objglobalSettings);
        //        retVal = dbContextNavigate.SaveChanges();
        //        if (retVal > 0)
        //            return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Delete GlobalSettings By GlobalKey
        /// </summary>
        /// <param name="globalSettings"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteGlobalSettingsByGlobalKey(string globalKey, string userName)
        {
            if (string.IsNullOrEmpty(globalKey))
            {
                throw new ArgumentNullException(nameof(globalKey));
            }
            if (globalKey != null)
            {
                using (var db = new Navigate30Context())
                {
                    db.GlobalSettings
                     .Where(x => x.GlobalKey == globalKey && x.IsActive == true && x.IsDeleted == false).ToList()
                     .ForEach(x => { x.ANJU_ChangedBy = userName; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = true; x.IsActive = false; });

                    int val = db.SaveChanges();
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        #endregion
    }
}
