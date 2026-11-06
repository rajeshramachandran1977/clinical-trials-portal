using Anju.Navigate.DataAccess;
using System.Collections.Generic;

namespace Anju.Navigate.BusinessAccess
{
    public class AdministrationBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public AdministrationBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get User roles
        /// </summary>
        /// <returns>List of user roles</returns>
        public List<Data.UserRoles> GetUserRoles()
        {
            return unitOfWork.UserRoles.GetUserRoles();
        }

        /// <summary>
        /// Create User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CreateUserRoles(Data.UserRoles userRoles, out string message,string userName)
        {
            bool isUserRoleCreated = unitOfWork.UserRoles.CreateUserRoles(userRoles, userName);
            if (isUserRoleCreated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInCreation;
                return false;
            }
        }

        /// <summary>
        /// Update User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateUserRoles(Data.UserRoles userRoles, out string message,string userName)
        {
            bool isUserRoleUpdated = unitOfWork.UserRoles.UpdateUserRoles(userRoles, userName);
            if (isUserRoleUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        /// <summary>
        /// Delete User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteUserRoles(Data.UserRoles userRoles, out string message,string userName)
        {
            bool isUserRoleDeleted = unitOfWork.UserRoles.DeleteUserRoles(userRoles, userName);
            if (isUserRoleDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get SysCodeValues       
        /// </summary>
        /// <returns></returns>
        public List<Data.SysCodeValues> GetSysCodeValues()
        {
            return unitOfWork.SysCodeValues.GetSysCodes();
        }

        /// <summary>        
        /// GetSysCodeColumnValues
        /// </summary>
        /// <returns></returns>
        public List<Data.SysCodeValues> GetSysCodeColumnValues()
        {
            return unitOfWork.SysCodeValues.GetSysCodeColumn();
        }

        /// <summary>
        /// Create SysCodeValues
        /// </summary>
        /// <param name="SysCodeValues"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        /// 
        /// <summary>        
        /// GetSysCodeColumnValues
        /// </summary>
        /// <returns></returns>
        public List<Data.SysCodeValues> GetSysCodeColumnValuesbyName(string columnName)
        {
            return unitOfWork.SysCodeValues.GetSysCodeColumnbyName(columnName);
        }

        /// <summary>
        /// Create SysCodeValues
        /// </summary>
        /// <param name="SysCodeValues"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CreateSysCodeValues(Data.SysCodeValues sysCodeValues, out string message, string value, string tableName,string userName)
        {
            bool isSysCodeCreated = unitOfWork.SysCodeValues.CreateSysCodeValues(sysCodeValues, value, tableName, userName);
            if (isSysCodeCreated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInCreation;
                return false;
            }
        }

        /// <summary>
        /// Update SysCodeValues
        /// </summary>
        /// <param name="sysCodeValues"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateSysCodeValues(Data.SysCodeValues sysCodeValues, out string message,string userName)
        {
            bool isSysCodeUpdated = unitOfWork.SysCodeValues.UpdateSysCodeValues(sysCodeValues, userName);
            if (isSysCodeUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        /// <summary>
        /// Update SysCodeValuesOrder
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="codeID"></param>
        /// <returns>true/false</returns>
        public bool UpdateSysCodeValuesOrder(int codeId, int sortOrder, string codeName,string userName)
        {
            return unitOfWork.SysCodeValues.UpdateSysCodeValuesOrder(codeId, sortOrder, codeName,userName);
        }

        /// <summary>
        /// Delete SysCodeValues
        /// </summary>
        /// <param name="sysCodeValues"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteSysCodeValues(Data.SysCodeValues sysCodeValues, out string message,string userName)
        {
            bool isSysCodeDeleted = unitOfWork.SysCodeValues.DeleteSysCodeValues(sysCodeValues, userName);
            if (isSysCodeDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get Countries
        /// </summary>
        /// <returns></returns>
        public List<Data.Country> GetCountries()
        {
            return unitOfWork.Country.GetCountries();
        }

        /// <summary>
        /// Create Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CreateCountry(Data.Country country, out string message,string userName)
        {
            bool isCountryCreated = unitOfWork.Country.CreateCountry(country, userName);
            if (isCountryCreated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInCreation;
                return false;
            }
        }

        /// <summary>
        /// Update Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateCountry(Data.Country country, out string message,string userName)
        {
            bool isCountryUpdated = unitOfWork.Country.UpdateCountry(country, userName);
            if (isCountryUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteCountry(Data.Country country, out string message,string userName)
        {
            bool isCountryDeleted = unitOfWork.Country.DeleteCountry(country, userName);
            if (isCountryDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get Global Settings
        /// </summary>
        /// <returns></returns>
        public List<Data.GlobalSettings> GetGlobalSettings()
        {
            return unitOfWork.GlobalSettings.GetGlobalSettings();
        }

        /// <summary>
        /// Get the list of GlobalSettings Values by GlobalKey
        /// </summary>
        /// <returns>lstGlobalSettings</returns>
        public List<Data.GlobalSettings> GetGlobalSettingsByGlobalKey(string globalKey)
        {
            return unitOfWork.GlobalSettings.GetGlobalSettingsByGlobalKey(globalKey);
        }
        /// <summary>
        /// Update Global Settings
        /// </summary>
        /// <param name="globalSettings"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateGlobalSettings(Data.GlobalSettings globalSettings, out string message,string userName)
        {
            bool isGlobalSettingsUpdated = unitOfWork.GlobalSettings.UpdateGlobalSettings(globalSettings, userName);
            if (isGlobalSettingsUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        ///// <summary>
        ///// Delete Global Settings
        ///// </summary>
        ///// <param name="country"></param>
        ///// <param name="message"></param>
        ///// <returns>true/false</returns>
        //public bool DeleteGlobalSettings(Data.GlobalSettings globalSettings, out string message)
        //{
        //    bool isGlobalSettingsDeleted = unitOfWork.GlobalSettings.DeleteGlobalSettings(globalSettings);
        //    if (isGlobalSettingsDeleted == true)
        //    {
        //        message = string.Empty;
        //        return true;
        //    }
        //    else
        //    {
        //        message = Utilities.Messages.ProblemInDeletion;
        //        return false;
        //    }
        //}

        /// <summary>
        /// Delete GlobalSettings By GlobalKey
        /// </summary>
        /// <param name="globalSettings"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteGlobalSettingsByGlobalKey(string globalKey, string userName)
        {
            bool isGlobalSettingsDeleted = unitOfWork.GlobalSettings.DeleteGlobalSettingsByGlobalKey(globalKey, userName);
            return isGlobalSettingsDeleted;
        }

        /// <summary>
        /// Get States
        /// </summary>
        /// <returns>list of states</returns>
        public List<Data.State> GetStates()
        {
            return unitOfWork.State.GetStates();
        }

        /// <summary>
        /// Create State
        /// </summary>
        /// <param name="city"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CreateState(Data.State state, out string message,string userName)
        {
            bool isStateCreated = unitOfWork.State.CreateState(state, userName);
            if (isStateCreated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInCreation;
                return false;
            }
        }

        /// <summary>
        /// Update State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateState(Data.State state, out string message,string userName)
        {
            bool isStateUpdated = unitOfWork.State.UpdateState(state, userName);
            if (isStateUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        /// <summary>
        /// Delete State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteState(Data.State state, out string message,string userName)
        {
            bool isStateDeleted = unitOfWork.State.DeleteState(state, userName);
            if (isStateDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get Cities
        /// </summary>
        /// <returns>list of cities</returns>
        public List<Data.City> GetCities()
        {
            return unitOfWork.City.GetCities();
        }

        /// <summary>
        /// Create City
        /// </summary>
        /// <param name="city"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CreateCity(Data.City city, out string message,string userName)
        {
            bool isCityCreated = unitOfWork.City.CreateCity(city, userName);
            if (isCityCreated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInCreation;
                return false;
            }
        }

        /// <summary>
        /// Update City
        /// </summary>
        /// <param name="city"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateCity(Data.City city, out string message,string userName)
        {
            bool isCityUpdated = unitOfWork.City.UpdateCity(city, userName);
            if (isCityUpdated == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInUpdation;
                return false;
            }
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="city"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteCity(Data.City city, out string message,string userName)
        {
            bool isCityDeleted = unitOfWork.City.DeleteCity(city, userName);
            if (isCityDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get Meta data
        /// </summary>       
        /// <returns>Tree view value</returns>
        public List<Data.MetaData> GetMetaData(int id)
        {
            return unitOfWork.EditStudy.GetAttributes(id);
        }

        /// <summary>
        /// Create Proxy User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public string CreateProxyUser(string userName, string loginUser)
        {
            unitOfWork.UserRoles.DeleteProxyUser(userName, loginUser);
            bool result;
            if (!string.IsNullOrEmpty(userName))
            {
                string[] users = userName.Split(',');
                foreach (string str in users)
                {
                    if (str.ToLower() == loginUser.ToLower())
                        return "You cannot designate yourself as a proxy user.";
                    result = unitOfWork.UserRoles.CreateProxyUser(str, loginUser);
                    if (result == false)
                        return "The specified username " + str + " is not valid";
                }
            }
            return Utilities.Messages.SuccessStatus; ;
        }

        /// <summary>
        /// Get Proxy User
        /// </summary>       
        /// <returns>proxy user</returns>
        public string GetProxyUser(string loginuser)
        {
            return unitOfWork.UserRoles.GetProxyUser(loginuser);

        }

        /// <summary>
        /// Get Proxy User
        /// </summary>       
        /// <returns>proxy user</returns>
        public List<Data.ProxyUserDetails> GetSwitchUsers(string userName, string selectedUser)
        {
            return unitOfWork.UserRoles.GetSwitchUsers(userName, selectedUser);
        }

        #endregion
    }
}
