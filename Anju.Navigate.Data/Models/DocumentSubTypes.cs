using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public partial class DocumentSubTypes:BaseResponseModel
    {
        public int DocumentSubTypeId { get; set; }
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
