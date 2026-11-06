using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public partial class DefaultMileStone:EntityBase
    {
        public int DefaultMilestoneId { get; set; }
        public string MilestoneType { get; set; }
        public string MilestoneName { get; set; }
        public int BusinessDays { get; set; }
        public int Dependency { get; set; }
        public string StudyPhase { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }     

    }

    public partial class DefaultMileStone_H:HistoryEntityBase
    {     
        public string MilestoneType { get; set; }
        public string MilestoneName { get; set; }
        public int BusinessDays { get; set; }
        public int Dependency { get; set; }
        public string StudyPhase { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }    

    }
}
