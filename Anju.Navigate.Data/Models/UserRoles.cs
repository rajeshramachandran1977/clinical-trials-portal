using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class UserRoles : BaseResponseModel
    {
        public UserRoles()
        {
            Users = new HashSet<Users>();
        }

        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
