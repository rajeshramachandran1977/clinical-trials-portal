using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class UserRoles : EntityBase
    {
        public UserRoles()
        {
            Users = new HashSet<Users>();
        }
        [Key]
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }   
        public virtual ICollection<Users> Users { get; set; }
    }

    public partial class UserRoles_H : HistoryEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
