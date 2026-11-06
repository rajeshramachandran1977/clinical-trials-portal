using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace Anju.Navigate.DataAccess
{
    public class AttributeRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public AttributeRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods 
        /// <summary>
        /// Get Attrbute Name
        /// </summary>
        /// <returns>attribute</returns>
        public List<Data.Attribute> GetAttributeList()
        {


            var objAttribute = dbContextNavigate.Attribute
                                .Where(x => x.IsSearchable == true)
                                .Select(x => new Data.Attribute
                                {
                                    Name = x.Name,
                                    AttributeId = x.AttributeId
                                }).ToList();
            return objAttribute;
        }

        /// <summary>
        /// Get Search Result
        /// </summary>
        /// <returns>attribute</returns>
        public List<Data.AttributeSearchResult> SearchResult(List<Data.AttributeSearch> lsAttribute,string matchCriteria)
        {            
            List<Data.AttributeSearch> lsAttributeRefrence = new List<Data.AttributeSearch>();
            Data.AttributeSearch objAttributeSearch;
            List<Data.AttributeSearchResult> lstSerchResult = new List<Data.AttributeSearchResult>();
            Data.AttributeSearchResult objSearchResult;
            string attribute = "";
            foreach (var item in lsAttribute)
            {
                objAttributeSearch = new Data.AttributeSearch();                
                objAttributeSearch.RefrenceTableName = dbContextNavigate.Attribute.Single(x => x.Name == item.AttributeName).RefrenceTableName;    
                objAttributeSearch.AttributeName = dbContextNavigate.Attribute.Single(x => x.Name == item.AttributeName).Description;
                objAttributeSearch.AttributeValue = item.AttributeValue;
                objAttributeSearch.Description = item.AttributeName;
                lsAttributeRefrence.Add(objAttributeSearch);
            }
            foreach (var item in lsAttributeRefrence)
            {
               
                var lstStudy = dbContextNavigate.SearchResult.FromSqlRaw("SELECT StudyID FROM vw_Search  WHERE " + item.AttributeName + " LIKE '%" + item.AttributeValue + "%'");
                

                if (matchCriteria== "All-Selected-Attributes" && !lstStudy.Any())
                {
                    lstSerchResult = new List<Data.AttributeSearchResult>();
                    return lstSerchResult;
                }
                foreach(var items in lstStudy)
                {
                    objSearchResult = new Data.AttributeSearchResult();
                    if (lstSerchResult.Exists(x => x.StudyID == items.StudyID))
                    {
                        objSearchResult = lstSerchResult.Find(x => x.StudyID == items.StudyID);
                        if(!objSearchResult.Description.Contains(item.Description))
                            objSearchResult.Description += ", " + item.Description;
                        lstSerchResult.RemoveAll(x => x.StudyID == items.StudyID);
                        lstSerchResult.Add(objSearchResult);
                    }
                    else
                    {
                        objSearchResult = new Data.AttributeSearchResult();
                        objSearchResult.StudyID = items.StudyID;
                        objSearchResult.Description = item.Description;
                        lstSerchResult.Add(objSearchResult);
                    }


                   
                }
            }

           var tt= lstSerchResult.Distinct().ToList();


            return lstSerchResult;
        }

        /// <summary>
        /// Get Quick Search Result
        /// </summary>
        /// <returns>attribute</returns>
        public List<Data.AttributeSearchResult> QuickSearchResult( string matchCriteria)
        {
            List<Data.AttributeSearchResult> lsAttributeSearchResult = new List<Data.AttributeSearchResult>();
            List<Data.AttributeSearch> lsAttributeRefrence = new List<Data.AttributeSearch>();
            Data.AttributeSearch objAttributeSearch;            
            Data.AttributeSearchResult objSearchResult;
            string attributes = "";
            var attributeName = dbContextNavigate.Attribute.Where(x => x.IsSearchable == true)
                                 .Select(x => new Data.Attribute
                                 {
                                     Name = x.Name
                                 }).ToList();

            
            foreach (var item in attributeName)
            {
                objAttributeSearch = new Data.AttributeSearch();
                objAttributeSearch.RefrenceTableName = dbContextNavigate.Attribute.Single(x => x.Name == item.Name).RefrenceTableName;
                objAttributeSearch.AttributeName = dbContextNavigate.Attribute.Single(x => x.Name == item.Name).Description;
                objAttributeSearch.AttributeValue = item.Name;
                objAttributeSearch.Description = item.Name;
                lsAttributeRefrence.Add(objAttributeSearch);
            }
            foreach (var item in lsAttributeRefrence)
            {
               // var lstStudy = dbContextNavigate.SearchResult.FromSql("SELECT StudyID FROM " + item.RefrenceTableName + " WHERE " + item.AttributeName + " LIKE '%" + matchCriteria + "%'");
                var lstStudy = dbContextNavigate.SearchResult.FromSqlRaw("SELECT StudyID FROM vw_Search  WHERE " + item.AttributeName + " LIKE '%" + matchCriteria + "%'");
                if(lstStudy.Count()>0)
                    attributes += item.Description + ",";
                foreach (var items in lstStudy)
                {
                   
                    objSearchResult = new Data.AttributeSearchResult();
                    if (lsAttributeSearchResult.Exists(x => x.StudyID == items.StudyID))
                    {

                        objSearchResult = lsAttributeSearchResult.Find(x => x.StudyID == items.StudyID);
                        if (!objSearchResult.Description.Contains(item.Description))
                            objSearchResult.Description += "," + item.Description;

                        objSearchResult.AttributeName = attributes;
                        lsAttributeSearchResult.RemoveAll(x => x.StudyID == items.StudyID);
                        lsAttributeSearchResult.Add(objSearchResult);
                    }
                    else
                    {
                        objSearchResult = new Data.AttributeSearchResult();
                        objSearchResult.StudyID = items.StudyID;
                        objSearchResult.Description = item.Description;
                        objSearchResult.AttributeName = attributes;
                        lsAttributeSearchResult.Add(objSearchResult);
                    }
                   
                }
            }


            return lsAttributeSearchResult;
        }

        #endregion
    }
}
