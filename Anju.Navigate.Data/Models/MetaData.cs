namespace Anju.Navigate.Data
{
    public class MetaData : BaseResponseModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool hasChildren { get; set; }       
    }
   
}
