using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class UserCredentials : BaseResponseModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CredentialId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual Users User { get; set; }
    }
}
