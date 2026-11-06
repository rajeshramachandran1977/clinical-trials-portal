using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Contracttimelines : EntityBase
    {
        [Key]
        public int ContractId { get; set; }
        public int StudyId { get; set; }
        public string Contracttype { get; set; }
        public string Contracttimelinestatus { get; set; }
        public string Contractversion { get; set; }
        public string Currentlocation { get; set; }
        public string Contactname { get; set; }
        public DateTime? Statuschange { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class Contracttimelines_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string Contracttype { get; set; }
        public string Contracttimelinestatus { get; set; }
        public string Contractversion { get; set; }
        public string Currentlocation { get; set; }
        public string Contactname { get; set; }
        public DateTime? Statuschange { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
