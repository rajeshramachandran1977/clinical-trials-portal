using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class StudyIndication : EntityBase
    {
        [Key]
        public int IndicationId { get; set; }
        public int StudyId { get; set; }
        public string IndicationType { get; set; }
        public string IndicationCauses { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }

    public partial class StudyIndication_H : HistoryEntityBase
    {       
        public int StudyId { get; set; }
        public string IndicationType { get; set; }
        public string IndicationCauses { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }      
    }
}
