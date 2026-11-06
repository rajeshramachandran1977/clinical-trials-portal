using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class LogRepository
    {
        #region Properties
        private readonly EmailServiceContext dbContextEmailService;
        #endregion

        #region constructor
        public LogRepository(EmailServiceContext dbContext)
        {
            dbContextEmailService = new EmailServiceContext();

        }
        #endregion

        #region Method
        public void LogError()
        {

        }
        #endregion
    }
}
