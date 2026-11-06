using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public class AttributeSearchResult : BaseResponseModel
    {
        public int StudyID { get; set; }
        public string Description { get; set; }
        public string AttributeName { get; set; }
    }
}
