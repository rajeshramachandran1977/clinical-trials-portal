using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    
   public class UnitOfWork
    {
        private readonly EmailServiceContext dbContextEmailService;
        public EmailServiceRepository Milestones
        {
            get { return new EmailServiceRepository(dbContextEmailService); }
        }

    }
}
