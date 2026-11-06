using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public partial class StudyTask:BaseResponseModel
    {
        public int TaskId { get; set; }
        public int StudyId { get; set; }
        public int MsluserId { get; set; }
        public int PluserId { get; set; }
        public string UpcomingTask { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual NewStudy Study { get; set; }
    }
}
