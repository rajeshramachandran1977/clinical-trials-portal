using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class State:EntityBase
    {
        public State()
        {
            City = new HashSet<City>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int StateId { get; set; }

        public int CountryId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }       
        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }

    public partial class State_H : HistoryEntityBase
    {
        public int CountryId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }
       
    }
}
