using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Country:EntityBase
    {
        public Country()
        {
            State = new HashSet<State>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int CountryId { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }      
        public virtual ICollection<State> State { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }

    public partial class Country_H : HistoryEntityBase
    {

        [StringLength(3)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }       
    }
}
