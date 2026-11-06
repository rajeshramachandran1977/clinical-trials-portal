using System;

namespace Anju.Navigate.Data
{
    public partial class StudyProtocol : BaseResponseModel
    {
        public int StudyProtocolId { get; set; }
        public int StudyId { get; set; }
        public string StudyProtocolnos { get; set; }
        public string Organization { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
