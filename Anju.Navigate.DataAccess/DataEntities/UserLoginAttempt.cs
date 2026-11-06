using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public partial class ProxyUserDetails:EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string ProxyUserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
       
    }

    public partial class ProxyUserDetails_H : HistoryEntityBase
    {   
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string ProxyUserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
