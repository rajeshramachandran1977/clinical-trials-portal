using Anju.Navigate.DataAccess;
using System.Collections.Generic;

namespace Anju.Navigate.BusinessAccess
{
    public class GlobalSettingsBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public GlobalSettingsBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the password policy set by the administrator
        /// </summary>
        /// <returns></returns>
        public List<Data.GlobalSettings> GetPwdPolicydetails()
        {
            return unitOfWork.GlobalSettings.GetPwdPolicydetails();
        }
        #endregion
    }
}
