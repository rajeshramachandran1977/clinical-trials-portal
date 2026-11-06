using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class Center : BaseResponseModel
    {
        public int CenterId { get; set; }
        public int StudyId { get; set; }
        public string Institution { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
