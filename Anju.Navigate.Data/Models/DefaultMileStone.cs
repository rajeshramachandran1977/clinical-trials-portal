using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public partial class DefaultMileStone:BaseResponseModel
    {
        public int DefaultMilestoneId { get; set; }
        public string ID { get; set; }        
        public string MilestoneType { get; set; }
        public string MilestoneName { get; set; }
        public int BusinessDays { get; set; }
        public int Dependency { get; set; }
        public string StudyPhase { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
