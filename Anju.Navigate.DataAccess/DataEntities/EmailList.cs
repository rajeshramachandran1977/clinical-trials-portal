using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public partial class EmailList : EntityBase
    {
        public int Id { get; set; }
        public int StudyId { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class EmailList_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }       
    }
}
