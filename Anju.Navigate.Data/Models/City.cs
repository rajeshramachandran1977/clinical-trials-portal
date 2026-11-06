using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<Users>();
        }

        public int CityId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
