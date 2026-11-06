using System;
using Anju.EmailService.DataAccess;

namespace Anju.EmailService.BusinessAccess
{
    public class EmailService
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public EmailService()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion
        public bool SendMail()
        {
            return unitOfWork.Milestones.SendMail();
        }
        
    }
}
