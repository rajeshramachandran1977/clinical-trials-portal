using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            Users = new HashSet<Users>();
        }

        public int StateId { get; set; }

        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
