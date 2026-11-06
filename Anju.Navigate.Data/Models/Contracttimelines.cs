using System;

namespace Anju.Navigate.Data
{
    public class Contracttimelines : BaseResponseModel 
    {
        public int ContractId { get; set; }
        public int StudyId { get; set; }
        public string Contracttype { get; set; }
        public string Contracttimelinestatus { get; set; }
        public string Contractversion { get; set; }
        public string Currentlocation { get; set; }
        public string Contactname { get; set; }
        public DateTime? Statuschange { get; set; }
        public string Comments { get; set; }        
    }
}
