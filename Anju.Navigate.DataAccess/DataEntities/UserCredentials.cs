using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class UserCredentials:EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CredentialId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }     

        public virtual Users User { get; set; }
    }

    public partial class UserCredentials_H:HistoryEntityBase
    {
     
       
        public int? UserId { get; set; }
        public int? CredentialId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }      

        public virtual Users User { get; set; }
    }
}
