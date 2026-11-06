using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class Documents:BaseResponseModel
    {
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
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsSubmit { get; set; }
        public bool? IsActivated { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? Anju_AddedDate { get; set; }
        public DateTime? OriginalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        ///Added below properties for Model view

        public int DocumentTypeId { get; set; }



    }
    public class ListOfDocuments
    {
        public List<Documents> LatestCV { get; set; }
            = new List<Documents>();
        public List<Documents> TrialBudgetDocuments{ get; set; }
            = new List<Documents>();
        public List<Documents> AdditionalDocuments { get; set; }
           = new List<Documents>();
        public List<Documents> ProtocolDocuments { get; set; }
           = new List<Documents>();
        public List<Documents> Documents { get; set; }
           = new List<Documents>();
    }

}
