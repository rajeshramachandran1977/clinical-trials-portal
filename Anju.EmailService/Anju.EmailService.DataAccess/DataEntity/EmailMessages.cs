using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Anju.EmailService.DataAccess
{
    public class EmailMessages
    {
        [Key]
        public int Id { get; set; }
        public int StudyID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? SendDate { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string CcAddress { get; set; }
        public string BccAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailPriority { get; set; }
        public int RetryCount { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
    }
}
