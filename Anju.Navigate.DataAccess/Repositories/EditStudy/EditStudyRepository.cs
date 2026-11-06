using Anju.Navigate.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class EditStudyRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public EditStudyRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods 
        /// <summary>
        /// Get Attribute Values
        /// </summary>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> GetAttributeValues(int attributeid)
        {
            var lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.SubChildID == attributeid && x.IsActive == true && x.IsDeleted == false)
                                                        .Select(x => new Data.EditStudyAttributes
                                                        {
                                                           Name = x.Name.Trim(),                                         
                                                           Description = x.Description.Trim(),
                                                           FieldType = x.FieldType.Trim(),
                                                           HelpText = x.HelpText.Trim(),
                                                           Type = x.Type.Trim(),
                                                           Size = x.Size.Trim(),                                                           
                                                           IsMandatory = x.IsMandatory,
                                                           IsViewable = x.IsViewable,
                                                           IsSearchable = x.IsSearchable,
                                                           DisplayOrder = x.DisplayOrder,
                                                           ColumnWidth = x.ColumnWidth,
                                                           RegexExpression = x.RegexExpression.Trim(),
                                                           ValidationMessage = x.ValidationMessage.Trim(),
                                                           RestrictCreateUser = x.RestrictCreateUser,
                                                           RestrictViewUser = x.RestrictViewUser,
                                                           RestrictEditUser = x.RestrictEditUser,
                                                           RestrictDeleteUser = x.RestrictDeleteUser

                                                        }).ToList();
            return lstAttributeValues;
        }


        /// <summary>
        /// Get Tab Titles for Edit Study
        /// </summary>
        /// <param name="tabtype"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> GetTabTitles(string tabtype,string category)
        {
            List<Data.EditStudyAttributes> lstAttributeValues = null;
            if (category == null)
            {
                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.Type == tabtype && x.IsActive == true && x.IsDeleted == false)
                                                            .Select(x => new Data.EditStudyAttributes
                                                            {
                                                                Name = x.Name.Trim(),
                                                                Description = x.Description.Trim(),
                                                                FieldType = x.FieldType.Trim(),
                                                                HelpText = x.HelpText.Trim(),
                                                                Type = x.Type.Trim(),
                                                                Size = x.Size.Trim(),
                                                                IsMandatory = x.IsMandatory,
                                                                IsViewable = x.IsViewable,
                                                                IsSearchable = x.IsSearchable,
                                                                DisplayOrder = x.DisplayOrder,
                                                                ColumnWidth = x.ColumnWidth,
                                                                RegexExpression = x.RegexExpression.Trim(),
                                                                ValidationMessage = x.ValidationMessage.Trim(),
                                                                RestrictCreateUser = x.RestrictCreateUser,
                                                                RestrictViewUser = x.RestrictViewUser,
                                                                RestrictEditUser = x.RestrictEditUser,
                                                                RestrictDeleteUser = x.RestrictDeleteUser

                                                            }).ToList();
            }
            else
            {

                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.Type == tabtype && x.ChildName == category && x.IsActive == true && x.IsDeleted == false).OrderBy(x => x.DisplayOrder)
                                                                       .Select(x => new Data.EditStudyAttributes
                                                                       {
                                                                           Name = x.Name.Trim(),
                                                                           Description = x.Description.Trim(),
                                                                           FieldType = x.FieldType.Trim(),
                                                                           HelpText = x.HelpText.Trim(),
                                                                           Type = x.Type.Trim(),
                                                                           Size = x.Size.Trim(),
                                                                           IsMandatory = x.IsMandatory,
                                                                           IsViewable = x.IsViewable,
                                                                           IsSearchable = x.IsSearchable,
                                                                           DisplayOrder = x.DisplayOrder,
                                                                           ColumnWidth = x.ColumnWidth,
                                                                           RegexExpression = x.RegexExpression.Trim(),
                                                                           ValidationMessage = x.ValidationMessage.Trim(),
                                                                           RestrictCreateUser = x.RestrictCreateUser,
                                                                           RestrictViewUser = x.RestrictViewUser,
                                                                           RestrictEditUser = x.RestrictEditUser,
                                                                           RestrictDeleteUser = x.RestrictDeleteUser
                                                                       }).ToList();
            }
            return lstAttributeValues;
        }


        /// <summary>
        /// Get  Edit Study Attribute Values
        /// </summary>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> GetAttributesList(String name, int checkId)
        {
            var lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && name == x.Name && x.GrandChildId==checkId)
                                                        .Select(x => new Data.EditStudyAttributes
                                                        {
                                                            EditstudyattributeId = x.EditstudyattributeId,
                                                            Name = x.Name.Trim(),
                                                            Description = x.Description.Trim(),
                                                            FieldType = x.FieldType.Trim(),
                                                            HelpText = x.HelpText.Trim(),
                                                            Type = x.Type.Trim(),
                                                            Size = x.Size.Trim(),
                                                            ParentID = x.ParentID,
                                                            ChildId = x.ChildId,
                                                            SubChildID = x.SubChildID,
                                                            GrandChildId = x.GrandChildId,
                                                            IsMandatory = x.IsMandatory,
                                                            IsViewable = x.IsViewable,
                                                            IsSearchable = x.IsSearchable,
                                                            DisplayOrder = x.DisplayOrder,
                                                            ColumnWidth = x.ColumnWidth,
                                                            RegexExpression = x.RegexExpression.Trim(),
                                                            ValidationMessage = x.ValidationMessage.Trim(),
                                                            RestrictCreateUser = x.RestrictCreateUser,
                                                            RestrictViewUser = x.RestrictViewUser,
                                                            RestrictEditUser = x.RestrictEditUser,
                                                            RestrictDeleteUser = x.RestrictDeleteUser
                                                        }).ToList(); ;
            if (checkId == 1)
            {
                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && name == x.Name && checkId == x.ParentID)
                                                        .Select(x => new Data.EditStudyAttributes
                                                        {
                                                            EditstudyattributeId = x.EditstudyattributeId,
                                                            Name = x.Name.Trim(),
                                                            Description = x.Description.Trim(),
                                                            FieldType = x.FieldType.Trim(),
                                                            HelpText = x.HelpText.Trim(),
                                                            Type = x.Type.Trim(),
                                                            Size = x.Size.Trim(),
                                                            ParentID = x.ParentID,
                                                            ChildId = x.ChildId,
                                                            SubChildID = x.SubChildID,
                                                            GrandChildId = x.GrandChildId,
                                                            IsMandatory = x.IsMandatory,
                                                            IsViewable = x.IsViewable,
                                                            IsSearchable = x.IsSearchable,
                                                            DisplayOrder = x.DisplayOrder,
                                                            ColumnWidth = x.ColumnWidth,
                                                            RegexExpression = x.RegexExpression.Trim(),
                                                            ValidationMessage = x.ValidationMessage.Trim(),
                                                            RestrictCreateUser = x.RestrictCreateUser,
                                                            RestrictViewUser = x.RestrictViewUser,
                                                            RestrictEditUser = x.RestrictEditUser,
                                                            RestrictDeleteUser = x.RestrictDeleteUser
                                                        }).ToList();                
            }
            else if (checkId > 100 && checkId < 1000) {
                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && name == x.Name && checkId == x.ChildId && checkId == x.SubChildID && checkId == x.GrandChildId)
                                                           .Select(x => new Data.EditStudyAttributes
                                                           {
                                                               EditstudyattributeId = x.EditstudyattributeId,
                                                               Name = x.Name.Trim(),
                                                               Description = x.Description.Trim(),
                                                               FieldType = x.FieldType.Trim(),
                                                               HelpText = x.HelpText.Trim(),
                                                               Type = x.Type.Trim(),
                                                               Size = x.Size.Trim(),
                                                               ParentID = x.ParentID,
                                                               ChildId = x.ChildId,
                                                               SubChildID = x.SubChildID,
                                                               GrandChildId = x.GrandChildId,
                                                               IsMandatory = x.IsMandatory,
                                                               IsViewable = x.IsViewable,
                                                               IsSearchable = x.IsSearchable,
                                                               DisplayOrder = x.DisplayOrder,
                                                               ColumnWidth = x.ColumnWidth,
                                                               RegexExpression = x.RegexExpression.Trim(),
                                                               ValidationMessage = x.ValidationMessage.Trim(),
                                                               RestrictCreateUser = x.RestrictCreateUser,
                                                               RestrictViewUser = x.RestrictViewUser,
                                                               RestrictEditUser = x.RestrictEditUser,
                                                               RestrictDeleteUser = x.RestrictDeleteUser
                                                           }).ToList();
                
            }
            else if (checkId > 10000 && checkId < 100000)
            {
                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && name == x.Name && checkId == x.SubChildID && checkId==x.GrandChildId)
                                                           .Select(x => new Data.EditStudyAttributes
                                                           {
                                                               EditstudyattributeId = x.EditstudyattributeId,
                                                               Name = x.Name.Trim(),
                                                               Description = x.Description.Trim(),
                                                               FieldType = x.FieldType.Trim(),
                                                               HelpText = x.HelpText.Trim(),
                                                               Type = x.Type.Trim(),
                                                               Size = x.Size.Trim(),
                                                               ParentID = x.ParentID,
                                                               ChildId = x.ChildId,
                                                               SubChildID = x.SubChildID,
                                                               GrandChildId = x.GrandChildId,
                                                               IsMandatory = x.IsMandatory,
                                                               IsViewable = x.IsViewable,
                                                               IsSearchable = x.IsSearchable,
                                                               DisplayOrder = x.DisplayOrder,
                                                               ColumnWidth = x.ColumnWidth,
                                                               RegexExpression = x.RegexExpression.Trim(),
                                                               ValidationMessage = x.ValidationMessage.Trim(),
                                                               RestrictCreateUser = x.RestrictCreateUser,
                                                               RestrictViewUser = x.RestrictViewUser,
                                                               RestrictEditUser = x.RestrictEditUser,
                                                               RestrictDeleteUser = x.RestrictDeleteUser
                                                           }).ToList();
                
            }
            else if (checkId > 1000000 && checkId < 10000000)
            {
                lstAttributeValues = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && name == x.Name && checkId == x.GrandChildId)
                                                           .Select(x => new Data.EditStudyAttributes
                                                           {
                                                               EditstudyattributeId = x.EditstudyattributeId,
                                                               Name = x.Name.Trim(),
                                                               Description = x.Description.Trim(),
                                                               FieldType = x.FieldType.Trim(),
                                                               HelpText = x.HelpText.Trim(),
                                                               Type = x.Type.Trim(),
                                                               Size = x.Size.Trim(),
                                                               ParentID = x.ParentID,
                                                               ChildId = x.ChildId,
                                                               SubChildID = x.SubChildID,
                                                               GrandChildId = x.GrandChildId,
                                                               IsMandatory = x.IsMandatory,
                                                               IsViewable = x.IsViewable,
                                                               IsSearchable = x.IsSearchable,
                                                               DisplayOrder = x.DisplayOrder,
                                                               ColumnWidth = x.ColumnWidth,
                                                               RegexExpression = x.RegexExpression.Trim(),
                                                               ValidationMessage = x.ValidationMessage.Trim(),
                                                               RestrictCreateUser = x.RestrictCreateUser,
                                                               RestrictViewUser = x.RestrictViewUser,
                                                               RestrictEditUser = x.RestrictEditUser,
                                                               RestrictDeleteUser = x.RestrictDeleteUser
                                                           }).ToList();
                
            }
            return lstAttributeValues;

        }


        /// <summary>
        /// Get  Edit Study Attribute Values for Meta data
        /// </summary>
        /// <returns></returns>
        public List<Data.MetaData> GetAttributes(int id)
        {
            List<Data.MetaData> lstMetdat = null;
            if (id == 0)
            {
                 lstMetdat = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && x.ParentID > 0 && x.IsFieldViewableInMetaData == true)
                                                              .Select(x => new Data.MetaData
                                                              {
                                                                  id = x.ParentID,
                                                                  Name = x.ParentName,
                                                                  hasChildren = true
                                                              }).Distinct().ToList();
                
            }
            else if(id == 1)
            {
                lstMetdat = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && x.ParentID== id && x.ChildId > x.ParentID && x.IsFieldViewableInMetaData == true)
                                                              .Select(x => new Data.MetaData
                                                              {
                                                                  id = x.ChildId,
                                                                  Name = x.ChildName,
                                                                  hasChildren = true
                                                              }).Distinct().ToList();
            }

            else if (id >= 100 && id < 1000)
            {
                lstMetdat = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && x.ChildId == id && x.SubChildID > x.ChildId && x.IsFieldViewableInMetaData == true)
                                                              .Select(x => new Data.MetaData
                                                              {
                                                                  id = x.SubChildID,
                                                                  Name = x.SubChildName,
                                                                  hasChildren = true
                                                              }).Distinct().ToList();
            }
            else if (id >= 10000 && id < 100000)
            {
                lstMetdat = dbContextNavigate.EditStudyAttributes.Where(x => x.IsActive == true && x.IsDeleted == false && x.SubChildID == id && x.GrandChildId > x.SubChildID && x.IsFieldViewableInMetaData == true)
                                                              .Select(x => new Data.MetaData
                                                              {
                                                                  id = x.GrandChildId,
                                                                  Name = x.GrandChildName,
                                                                  hasChildren = false
                                                              }).Distinct().ToList();
            }           
            return lstMetdat;
        }



        /// <summary>
        ///  Create Update Edit Study Sttributes
        /// </summary>
        /// <param name="editStudyAttributes"></param>      
        /// <param name="studyId"></param>
        /// <returns></returns>
        public bool CreateUpdateEditStudyAttribute(Data.EditStudyAttributes editStudyAttributes,string userName)
        {
            int retVal = default(int);
            if (editStudyAttributes != null)
            {
                var result = dbContextNavigate.EditStudyAttributes.Where(x => x.EditstudyattributeId == editStudyAttributes.EditstudyattributeId).SingleOrDefault();
                if (result != null)
                {
                    result.EditstudyattributeId = editStudyAttributes.EditstudyattributeId;
                    result.Name = editStudyAttributes.Name;
                    if (editStudyAttributes.ParentName != null)
                    {
                        result.ParentName = editStudyAttributes.ParentName;
                    }
                    if (editStudyAttributes.ChildName != null)
                    {
                        result.ChildName = editStudyAttributes.ChildName;
                    }
                    if (editStudyAttributes.SubChildName != null)
                    {
                        result.SubChildName = editStudyAttributes.SubChildName;
                    }
                    if (editStudyAttributes.GrandChildName != null)
                    {
                        result.GrandChildName = editStudyAttributes.GrandChildName;
                    }
                    result.ParentName = editStudyAttributes.ParentName;
                    result.ChildName = editStudyAttributes.ChildName;
                    result.SubChildName = editStudyAttributes.SubChildName;
                    result.GrandChildName = editStudyAttributes.GrandChildName;
                    result.Description = editStudyAttributes.Description;
                    result.Type = editStudyAttributes.Type;
                    result.FieldType = editStudyAttributes.FieldType;
                    result.HelpText = editStudyAttributes.HelpText;
                    result.Size = editStudyAttributes.Size;
                    result.IsMandatory = editStudyAttributes.IsMandatory;
                    result.IsViewable = editStudyAttributes.IsViewable;
                    result.IsSearchable = editStudyAttributes.IsSearchable;
                    result.DisplayOrder = editStudyAttributes.DisplayOrder;
                    result.ColumnWidth = editStudyAttributes.ColumnWidth;
                    result.RegexExpression = editStudyAttributes.RegexExpression;
                    result.ValidationMessage = editStudyAttributes.ValidationMessage;
                    result.GroupPermissionsId = editStudyAttributes.GroupPermissionsId;
                    result.RestrictCreateUser = editStudyAttributes.RestrictCreateUser;
                    result.RestrictViewUser = editStudyAttributes.RestrictViewUser;
                    result.RestrictEditUser = editStudyAttributes.RestrictEditUser;
                    result.RestrictDeleteUser = editStudyAttributes.RestrictDeleteUser;
                    result.IsFieldViewableInMetaData = true;
                    result.IsActive = editStudyAttributes.IsActive;
                    result.IsDeleted = editStudyAttributes.IsDeleted;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                    if (retVal > 0) {
                        if (editStudyAttributes.ParentID == editStudyAttributes.ChildId && editStudyAttributes.ChildId == editStudyAttributes.SubChildID && editStudyAttributes.SubChildID == editStudyAttributes.GrandChildId) {
                            
                            var parentUpdate = dbContextNavigate.EditStudyAttributes.Where(x => x.ParentID == editStudyAttributes.ParentID && x.ParentName != editStudyAttributes.ParentName &&  x.IsActive == true).ToList();
                            if (parentUpdate.Count > 0) {
                                foreach (var item in parentUpdate) {
                                    item.ParentName = editStudyAttributes.ParentName;
                                    retVal = dbContextNavigate.SaveChanges(item, new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                                }
                            }
                        }
                        else if (editStudyAttributes.ParentID != editStudyAttributes.ChildId && editStudyAttributes.ChildId == editStudyAttributes.SubChildID && editStudyAttributes.SubChildID == editStudyAttributes.GrandChildId)
                        {
                            var parentUpdate = dbContextNavigate.EditStudyAttributes.Where(x => x.ChildId == editStudyAttributes.ChildId && x.ChildName != editStudyAttributes.ChildName && x.IsActive == true).ToList();
                            if (parentUpdate.Count > 0)
                            {
                                foreach (var item in parentUpdate)
                                {
                                    item.ChildName = editStudyAttributes.ChildName;
                                    retVal = dbContextNavigate.SaveChanges(item, new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                                }
                            }
                        }
                        if (editStudyAttributes.ParentID != editStudyAttributes.ChildId && editStudyAttributes.ChildId != editStudyAttributes.SubChildID && editStudyAttributes.SubChildID == editStudyAttributes.GrandChildId)
                        {
                            var parentUpdate = dbContextNavigate.EditStudyAttributes.Where(x => x.SubChildID == editStudyAttributes.SubChildID && x.SubChildName != editStudyAttributes.SubChildName && x.IsActive == true).ToList();
                            if (parentUpdate.Count > 0)
                            {
                                foreach (var item in parentUpdate)
                                {
                                    item.SubChildName = editStudyAttributes.SubChildName;
                                    retVal = dbContextNavigate.SaveChanges(item, new EditStudyAttributes_H(), userName, eAuditChangeType.Update);
                                }
                            }
                        }
                    }
                }
                else {
                    if (editStudyAttributes.ChildId == 0)
                    {
                        int childId = dbContextNavigate.EditStudyAttributes.Max(u => u.ChildId);
                        childId = childId + 1;
                        DataAccess.EditStudyAttributes objEditStudyAttributes = new DataAccess.EditStudyAttributes()
                        {
                            Name = editStudyAttributes.Name,
                            ParentID = editStudyAttributes.ParentID,
                            ParentName = editStudyAttributes.ParentName,
                            ChildId = childId,
                            ChildName = editStudyAttributes.ChildName,
                            SubChildID = childId,
                            SubChildName = editStudyAttributes.SubChildName,
                            GrandChildId = childId,
                            GrandChildName = editStudyAttributes.GrandChildName,
                            Description = editStudyAttributes.Description,
                            Type = editStudyAttributes.Type,
                            FieldType = editStudyAttributes.FieldType,
                            IsFieldViewableInMetaData = true,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddedBy = userName,
                            ANJU_AddDate = DateTime.UtcNow
                        };
                        retVal = dbContextNavigate.SaveChanges(objEditStudyAttributes, new EditStudyAttributes_H(), userName, eAuditChangeType.Insert);
                    }
                    else if (editStudyAttributes.SubChildID == 0)
                    {
                        int subChildID = dbContextNavigate.EditStudyAttributes.Max(u => u.SubChildID);
                        subChildID = subChildID + 1;
                        DataAccess.EditStudyAttributes objEditStudyAttributes = new DataAccess.EditStudyAttributes()
                        {
                            Name = editStudyAttributes.Name,
                            ParentID = editStudyAttributes.ParentID,
                            ParentName = editStudyAttributes.ParentName,
                            ChildId = editStudyAttributes.ChildId,
                            ChildName = editStudyAttributes.ChildName,
                            SubChildID = subChildID,
                            SubChildName = editStudyAttributes.SubChildName,
                            GrandChildId = subChildID,
                            GrandChildName = editStudyAttributes.GrandChildName,
                            Description = editStudyAttributes.Description,
                            Type = editStudyAttributes.Type,
                            FieldType = editStudyAttributes.FieldType,
                            Size = editStudyAttributes.Size,
                            IsMandatory = editStudyAttributes.IsMandatory,
                            IsViewable = editStudyAttributes.IsViewable,
                            IsSearchable = editStudyAttributes.IsSearchable,
                            DisplayOrder = editStudyAttributes.DisplayOrder,
                            ColumnWidth = editStudyAttributes.ColumnWidth,
                            RegexExpression = editStudyAttributes.RegexExpression,
                            ValidationMessage = editStudyAttributes.ValidationMessage,
                            GroupPermissionsId = editStudyAttributes.GroupPermissionsId,
                            RestrictCreateUser = editStudyAttributes.RestrictCreateUser,
                            RestrictViewUser = editStudyAttributes.RestrictViewUser,
                            RestrictEditUser = editStudyAttributes.RestrictEditUser,
                            RestrictDeleteUser = editStudyAttributes.RestrictDeleteUser,
                            IsFieldViewableInMetaData = true,
                            IsActive = editStudyAttributes.IsActive,
                            IsDeleted = editStudyAttributes.IsDeleted,
                            ANJU_AddedBy = userName,
                            ANJU_AddDate = DateTime.UtcNow
                        };
                        retVal = dbContextNavigate.SaveChanges(objEditStudyAttributes, new EditStudyAttributes_H(), userName, eAuditChangeType.Insert);
                    }
                    else if (editStudyAttributes.GrandChildId == 0) {
                        int grandChildId = dbContextNavigate.EditStudyAttributes.Max(u => u.GrandChildId);
                        grandChildId = grandChildId + 1;
                        DataAccess.EditStudyAttributes objEditStudyAttributes = new DataAccess.EditStudyAttributes()
                        {
                            Name = editStudyAttributes.Name,
                            ParentID = editStudyAttributes.ParentID,
                            ParentName = editStudyAttributes.ParentName,
                            ChildId = editStudyAttributes.ChildId,
                            ChildName = editStudyAttributes.ChildName,
                            SubChildID = editStudyAttributes.SubChildID,
                            SubChildName = editStudyAttributes.SubChildName,
                            GrandChildId = grandChildId,
                            GrandChildName = editStudyAttributes.GrandChildName,
                            Description = editStudyAttributes.Description,
                            Type = editStudyAttributes.Type,
                            FieldType = editStudyAttributes.FieldType,
                            Size = editStudyAttributes.Size,
                            IsMandatory = editStudyAttributes.IsMandatory,
                            IsViewable = editStudyAttributes.IsViewable,
                            IsSearchable = editStudyAttributes.IsSearchable,
                            DisplayOrder = editStudyAttributes.DisplayOrder,
                            ColumnWidth = editStudyAttributes.ColumnWidth,
                            RegexExpression = editStudyAttributes.RegexExpression,
                            ValidationMessage = editStudyAttributes.ValidationMessage,
                            GroupPermissionsId = editStudyAttributes.GroupPermissionsId,
                            RestrictCreateUser = editStudyAttributes.RestrictCreateUser,
                            RestrictViewUser = editStudyAttributes.RestrictViewUser,
                            RestrictEditUser = editStudyAttributes.RestrictEditUser,
                            RestrictDeleteUser = editStudyAttributes.RestrictDeleteUser,
                            IsFieldViewableInMetaData = true,
                            IsActive = editStudyAttributes.IsActive,
                            IsDeleted = editStudyAttributes.IsDeleted,
                            ANJU_AddedBy = userName,
                            ANJU_AddDate = DateTime.UtcNow
                        };
                        retVal = dbContextNavigate.SaveChanges(objEditStudyAttributes, new EditStudyAttributes_H(), userName, eAuditChangeType.Insert);
                    }
                }              

                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
