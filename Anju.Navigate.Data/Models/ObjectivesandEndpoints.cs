using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class ObjectivesandEndpoints : BaseResponseModel
    {      
        public int ObjandEndPointsId { get; set; }
        public int StudyId { get; set; }
        public string ObjectiveType { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
        public string EndpointDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
