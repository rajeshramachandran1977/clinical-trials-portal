using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class ObjectivesandEndpoints : EntityBase
    {
        [Key]
        public int ObjandEndPointsId { get; set; }
        public int StudyId { get; set; }
        public string ObjectiveType { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
        public string EndpointDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }    
    }

    public partial class ObjectivesandEndpoints_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string ObjectiveType { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
        public string EndpointDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
