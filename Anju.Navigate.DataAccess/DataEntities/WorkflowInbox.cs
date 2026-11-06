using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.DataAccess.DataEntities
{
    public partial class WorkflowInbox
    {
        public Guid Id { get; set; }
        public Guid ProcessId { get; set; }
        public string IdentityId { get; set; }
    }
}
