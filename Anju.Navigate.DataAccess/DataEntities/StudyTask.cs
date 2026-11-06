using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudyTask : EntityBase
    {
        [Key]
        public int TaskId { get; set; }
        public int StudyId { get; set; }
        public int MsluserId { get; set; }
        public int PluserId { get; set; }
        public string UpcomingTask { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }     

        public virtual NewStudy Study { get; set; }
    }

    public partial class StudyTask_H : HistoryEntityBase
    {       
        public int StudyId { get; set; }
        public int MsluserId { get; set; }
        public int PluserId { get; set; }
        public string UpcomingTask { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual NewStudy Study { get; set; }
    }
}
