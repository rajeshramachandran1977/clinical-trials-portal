using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class Age : BaseResponseModel
    {
        public int AgeId { get; set; }
        public int Age1 { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
