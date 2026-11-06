using System;
using System.Collections.Generic;

namespace Anju.Navigate.DataAccess.DataEntities
{
    public partial class Operation
    {
        public Operation()
        {
            OperationWorkflowLog = new HashSet<OperationWorkflowLog>();
        }

        public Guid Id { get; set; }
        public int OperationId { get; set; }
        public string WorkflowName { get; set; }
        public string UserName { get; set; }
        public string ProxyUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<OperationWorkflowLog> OperationWorkflowLog { get; set; }
    }
    public partial class OperationWorkflowLog
    {
        public int Id { get; set; }
        public Guid ProcessId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string ProxyUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Operation Process { get; set; }
    }
}
