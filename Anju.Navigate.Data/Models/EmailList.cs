using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public partial class EmailList:BaseResponseModel
    {
        public int Id { get; set; }
        public int StudyId { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
