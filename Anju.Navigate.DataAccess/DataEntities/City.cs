using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class City : EntityBase
    {
        public City()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int CityId { get; set; }

        public int StateId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }       

        public virtual State State { get; set; }
        public virtual ICollection<Users> Users { get; set; }


    }

    public partial class City_H:HistoryEntityBase
    {     
        public int StateId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }       
    }
}
