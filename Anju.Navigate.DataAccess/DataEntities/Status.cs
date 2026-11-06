using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public class Status : EntityBase
    {
        [Key]
        public int StatusId { get; set; }
        public int StudyId { get; set; }
        public string Stage { get; set; }
        public string State { get; set; }
        public string StudyStatus { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Status_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string Stage { get; set; }
        public string State { get; set; }
        public string StudyStatus { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

}
