using System;
using System.Collections.Generic;
using System.Text;
using Anju.Navigate.DataAccess;


namespace Anju.Navigate.BusinessAccess
{
    public class SearchBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public SearchBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods 

        /// <summary>
        /// Read all Attribute Name
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List</returns>  

        public List<Data.Attribute> GetAttributeName()
        {
            return unitOfWork.Attribute.GetAttributeList();
        }

        /// <summary>
        /// Read all Search Result
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List</returns>  

        public List<Data.AttributeSearchResult> SearchResult(List<Data.AttributeSearch> lsAttribute,string matchCriteria)
        {
            return unitOfWork.Attribute.SearchResult(lsAttribute, matchCriteria);
        }

        /// <summary>
        /// Get all Quick Search Result
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List</returns>  
        public List<Data.AttributeSearchResult> QuickSearchResult( string matchCriteria)
        {
            return unitOfWork.Attribute.QuickSearchResult(matchCriteria);
        }
        #endregion
    }
}
