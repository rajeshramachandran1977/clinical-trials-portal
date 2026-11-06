using System;

namespace Anju.Navigate.Data
{
    public partial class Status : BaseResponseModel
    {
        public int StatusId { get; set; }
        public int StudyId { get; set; }        
        public string Stage { get; set; }
        public string State { get; set; }
        public string StudyStatus { get; set; }
        public DateTime? Date { get; set; }       
        public string Time { get; set; }       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
