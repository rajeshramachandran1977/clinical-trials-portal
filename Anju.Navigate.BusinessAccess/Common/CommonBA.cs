using Anju.Navigate.DataAccess;
using System.Collections.Generic;

namespace Anju.Navigate.BusinessAccess
{   
    public class CommonBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public CommonBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods 

        /// <summary>
        /// Get Gender
        /// </summary>
        /// <returns></returns>
        public List<Data.SysCodeValues> GetGender()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("Gender");
        }

        /// <summary>
        /// Get Email address
        /// </summary>
        /// <returns></returns>
        public string GetHelpEmailAddress()
        {
            return unitOfWork.SysCodeValues.GetHelpEmailAddress();
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <returns></returns>
        public bool SendMail(string body,string tomail,string subject, List<string> lsparameter,int studyId,string ccMail)
        {
            CommonRepository cmnRep = new CommonRepository();
            return cmnRep.SendMail(body, tomail, subject,lsparameter,studyId, ccMail);
        }

        #endregion
    }
}
