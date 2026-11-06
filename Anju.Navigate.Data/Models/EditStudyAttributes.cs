using System;

namespace Anju.Navigate.Data
{
    public partial class EditStudyAttributes
    {
        public int EditstudyattributeId { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string ParentName { get; set; }
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public int SubChildID { get; set; }
        public string SubChildName { get; set; }
        public int GrandChildId { get; set; }
        public string GrandChildName { get; set; }
        public string Description { get; set; }
        public string FieldType { get; set; }
        public string HelpText { get; set; }
        public string Type { get; set; }
        public int? ListofValuesId { get; set; }
        public string Size { get; set; }
        public bool? IsMandatory { get; set; }
        public bool? IsViewable { get; set; }
        public bool? IsSearchable { get; set; }
        public int? DisplayOrder { get; set; }
        public int? ColumnWidth { get; set; }
        public string RegexExpression { get; set; }
        public string ValidationMessage { get; set; }
        public int? GroupPermissionsId { get; set; }
        public string RestrictCreateUser { get; set;}
        public string RestrictViewUser { get; set; }
        public string RestrictEditUser { get; set; }
        public string RestrictDeleteUser { get; set; }
        public bool IsFieldViewableInMetaData { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
