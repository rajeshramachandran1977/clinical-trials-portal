using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class NewStudy
    {
        [Key]
        public int StudyId { get; set; }
        public string StudyType { get; set; }
        public string TitleofTrial { get; set; }
        public string Treatmentarms { get; set; }
        public string SampleSizeJustificationandStatisticalAnalysis { get; set; }
        public string ClinicalPharmacology { get; set; }
        public string EnrollmentHistoryforOtherRelatedStudies { get; set; }
        public bool? IsCompetingStudies { get; set; }
        public string CompetingStudies { get; set; }
        public bool? IsIndsubmission { get; set; }
        public string RationaleforINDExemption { get; set; }
        public bool? IsIrbregistrationRequirement { get; set; }
        public string KeyReferences { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string MedicalSpecialty { get; set; }
        public string BoardCertification { get; set; }
        public string MedicalLicense { get; set; }
        public bool? IsCompanySponsoredtrial { get; set; }
        public string DrugName { get; set; }
        public string ProtocolNumber { get; set; }
        public string TrialParticipation { get; set; }
        public bool? IsOtherTrainingsReceived { get; set; }
        public string LastTrainingDetails { get; set; }
        public string TypeOfTraining { get; set; }
        public string TrialExperiences { get; set; }
        public string NumberOfOngoingTrials { get; set; }
        public bool? IsSiteInspectedByHealthAuthority { get; set; }
        public string NameOfHealthAuthority { get; set; }
        public DateTime? DateOflastInspection { get; set; }
        public bool? IsSiteInspectedByFda { get; set; }
        public DateTime? DateOfFdainspection { get; set; }
        public bool? Isfda483formIssued { get; set; }
        public string DetailsOfObservation { get; set; }
        public bool? IsCooperativeGroupStudy { get; set; }
        public string CooperativeGroupName { get; set; }
        public bool? IsPhysicianNetworkStudy { get; set; }
        public string PhysicianNetworkName { get; set; }
        public bool? IsGovernmentSupportProvided { get; set; }
        public string SupportDescription { get; set; }
        public bool? IsSupportProvidedByOtherSources { get; set; }
        public string SupportSources { get; set; }

        /*Start RequestSupport*/
        public bool? IsRequestedForDrugSupply { get; set; }
        public bool? IsRequestedForFinancialSupport { get; set; }
        public int? BudgetRequestedForTrial { get; set; }

        /*End RequestSupport*/

        public string Stage { get; set; }
        public string State { get; set; }
        public string TaskStatus { get; set; }
        public string PITaskStatus { get; set; }
        public string TaskName { get; set; }
        public string InvestigationalSiteProtocolNumber { get; set; }
        public DateTime? StudyActivationDate { get; set; }
        public string ANJU_AddedBy { get; set; }

        public DateTime? ANJU_AddDate { get; set; }

        [StringLength(63)]
        public string ANJU_ChangedBy { get; set; }

        public DateTime? ANJU_ChangeDate { get; set; }

    }
}
