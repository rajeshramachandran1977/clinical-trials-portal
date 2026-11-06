using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Data
{
    public class AttributeSearch : BaseResponseModel
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string RefrenceTableName { get; set; }
        public string Description { get; set; }
    }

   
}
