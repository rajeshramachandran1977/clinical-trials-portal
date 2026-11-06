using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public partial class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsSearchable { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string RefrenceTableName { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
