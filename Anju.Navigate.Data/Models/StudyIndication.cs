using System;

namespace Anju.Navigate.Data
{
    public partial class StudyIndication : BaseResponseModel
    {
        public int IndicationId { get; set; }
        public int StudyId { get; set; }
        public string IndicationType { get; set; }
        public string IndicationCauses { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
