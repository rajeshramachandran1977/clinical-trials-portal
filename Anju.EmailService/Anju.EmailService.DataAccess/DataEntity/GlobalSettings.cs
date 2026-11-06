using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class GlobalSettings
    {
        [Key]
        public int GlobalId { get; set; }
        public string GlobalKey { get; set; }
        public string GlobalValue { get; set; }
        public string Remarks { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
