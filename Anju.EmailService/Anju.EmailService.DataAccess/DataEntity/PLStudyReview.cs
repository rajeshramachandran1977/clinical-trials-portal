using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class PLStudyReview
    {
        [Key]
        public int PLreviewId { get; set; }
        public int StudyId { get; set; }
        public int? PLuserId { get; set; }
        public string StudyDescriptors { get; set; }
        public string CompoundCategory1 { get; set; }
        public string CompoundCategory2 { get; set; }
        public string CompoundCategory3 { get; set; }
        public string CompoundType1 { get; set; }
        public string CompoundType2 { get; set; }
        public string CompoundType3 { get; set; }
        public string TrialCategorization { get; set; }
        public bool? MonitoringInterval { get; set; }
        public string MaximumAllowableVists { get; set; }
        public int TluserId { get; set; }
        public string Decision { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual NewStudy Study { get; set; }
    }
}
