using System;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class IISAdmindetails : EntityBase
    {
        [Key]
        public int IISAdmindetailsid { get; set; }
        public int StudyId { get; set; }
        public string Studydescriptors { get; set; }
        public string InvestigationalDrugandReferenceTherapy { get; set; }
        public string PatientType { get; set; }
        public string Safetycriteria { get; set; }
        public string Othercompanycompound { get; set; }
        public bool? IsPlacebocontrolled { get; set; }
        public string Studydesign { get; set; }
        public string Rationaleforstudy { get; set; }
        public string Basisforsamplesize { get; set; }
        public string Riskfactors { get; set; }
        public string GenomicProfile { get; set; }
        public string Lineoftherapy { get; set; }
        public string Disease { get; set; }
        public string Diseasepaatientpopulation { get; set; }
        public string DiseaseStage { get; set; }
        public string TreatmentSegment { get; set; }
        public string LineofTreatment { get; set; }
        public string Qualityoflife { get; set; }
        public string Indicationforsciencemain { get; set; }
        public string Studyduration { get; set; }
        public string Noofpatientspertreatmentgroup { get; set; }
        public int? Enrollmentrate { get; set; }
        public string FinalINDStatus { get; set; }
        public string INDNumber { get; set; }
        public string Credentials { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Interventionaltrialdatacollection { get; set; }
        public string NonInterventionaltrialdatacollection { get; set; }
        public string StudySponsor { get; set; }
        public string StudyDrugSource { get; set; }
        public string OtherCooperativeGroup { get; set; }
        public bool? Isrequestingacompanystudycompound { get; set; }
        public string Othersupportdescription { get; set; }
        public bool? Isrequestingsupportfromcompanyotherthandrugorfunding { get; set; }
        public int? Globalfundingrequested { get; set; }
        public bool? Isamendmentrequestincludesachangeintheprimaryinvestigator { get; set; }
        public bool? Isautoproxyenabled { get; set; }
        public string Leadorganization { get; set; }
        public bool? Isconditionalapproval { get; set; }
        public string Conditionsofapproval { get; set; }
        public string ICFReview { get; set; }
        public string Amendmentstatus { get; set; }
        public string Amendmenttype { get; set; }
        public string Contractamendmentrequired { get; set; }
        public bool? Ipistudyssponsor { get; set; }
        //public bool? ExecutionDate { get; set; }
        public DateTime? Migrationdate { get; set; }
        public string Conversionstatus { get; set; }
        public int? Milestoneupdatefrequencydays { get; set; }
        public int? Accrualmilestoneupdatefrequencydays { get; set; }
        public DateTime? Lastsendemail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class IISAdmindetails_H : HistoryEntityBase
    {
        public int StudyId { get; set; }
        public string Studydescriptors { get; set; }
        public string InvestigationalDrugandReferenceTherapy { get; set; }
        public string PatientType { get; set; }
        public string Safetycriteria { get; set; }
        public string Othercompanycompound { get; set; }
        public bool? IsPlacebocontrolled { get; set; }
        public string Studydesign { get; set; }
        public string Rationaleforstudy { get; set; }
        public string Basisforsamplesize { get; set; }
        public string Riskfactors { get; set; }
        public string GenomicProfile { get; set; }
        public string Lineoftherapy { get; set; }
        public string Disease { get; set; }
        public string Diseasepaatientpopulation { get; set; }
        public string DiseaseStage { get; set; }
        public string TreatmentSegment { get; set; }
        public string LineofTreatment { get; set; }
        public string Qualityoflife { get; set; }
        public string Indicationforsciencemain { get; set; }
        public string Studyduration { get; set; }
        public string Noofpatientspertreatmentgroup { get; set; }
        public int? Enrollmentrate { get; set; }
        public string FinalINDStatus { get; set; }
        public string INDNumber { get; set; }
        public string Credentials { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Interventionaltrialdatacollection { get; set; }
        public string NonInterventionaltrialdatacollection { get; set; }
        public string StudySponsor { get; set; }
        public string StudyDrugSource { get; set; }
        public string OtherCooperativeGroup { get; set; }
        public bool? Isrequestingacompanystudycompound { get; set; }
        public string Othersupportdescription { get; set; }
        public bool? Isrequestingsupportfromcompanyotherthandrugorfunding { get; set; }
        public int? Globalfundingrequested { get; set; }
        public bool Isamendmentrequestincludesachangeintheprimaryinvestigator { get; set; }
        public bool Isautoproxyenabled { get; set; }
        public string Leadorganization { get; set; }
        public bool Isconditionalapproval { get; set; }
        public string Conditionsofapproval { get; set; }
        public string ICFReview { get; set; }
        public string Amendmentstatus { get; set; }
        public string Amendmenttype { get; set; }
        public string Contractamendmentrequired { get; set; }
        public bool Ipistudyssponsor { get; set; }
        public DateTime? Migrationdate { get; set; }
        public string Conversionstatus { get; set; }
        public int? Milestoneupdatefrequencydays { get; set; }
        public int? Accrualmilestoneupdatefrequencydays { get; set; }
        public DateTime? Lastsendemail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }       
    }
}
