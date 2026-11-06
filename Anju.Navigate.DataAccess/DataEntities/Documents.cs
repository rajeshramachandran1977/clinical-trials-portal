using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Documents : EntityBase
    {
        [Key]
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNameWithOutExtension { get; set; }
        public int StudyId { get; set; }
        public int? SubModuleId { get; set; }
        public string SubModuleName { get; set; }
        public int DocumentSize { get; set; }
        public string DocumentExtension { get; set; }
        public string Path { get; set; }
        public string DocumentStatus { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSubType { get; set; }
        public string DocumentVersion { get; set; }
        public DateTime? OriginalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsSubmit { get; set; }
        public bool? IsActivated { get; set; }        
    }

    public partial class Documents_H : HistoryEntityBase
    {      
        public string DocumentName { get; set; }
        public string DocumentNameWithOutExtension { get; set; }
        public int StudyId { get; set; }
        public int? SubModuleId { get; set; }
        public string SubModuleName { get; set; }
        public int DocumentSize { get; set; }
        public string DocumentExtension { get; set; }
        public string Path { get; set; }
        public string DocumentStatus { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSubType { get; set; }
        public string DocumentVersion { get; set; }
        public DateTime? OriginalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsSubmit { get; set; }
        public bool? IsActivated { get; set; }       
    }
}
