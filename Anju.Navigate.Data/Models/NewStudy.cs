using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class NewStudy : BaseResponseModel
    {
        
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

        public string PITaskStatus { get; set; }

        /* start principalInvestigator*/
        public int PrincipalInvestigatorId { get; set; }
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
        public string Address3 { get; set; }
        public string SiteIndex { get; set; }
        public string ContactType { get; set; }
        public string ContactTypeDetails { get; set; }
        public string TaxID { get; set; }
        /* End principalInvestigator*/

        /*Start RequestSupport*/
        public bool? IsRequestedForDrugSupply { get; set; }
        public bool? IsRequestedForFinancialSupport { get; set; }
        public int? BudgetRequestedForTrial { get; set; }
        public string DocumentName { get; set; }
        public string Path { get; set; }
        public string SubModuleName { get; set; }
        /*End RequestSupport*/
        public string Stage { get; set; }
        public string State { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string InvestigationalSiteProtocolNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }
        public DateTime? StudyActivationDate { get; set; }

        //Following columns have been added to hold data from cumulative tables for New Proposal Submission Wizard
        public int TrialPhaseId { get; set; }
        public bool? PhaseI { get; set; }
        public bool? PhaseII { get; set; }
        public bool? PhaseIII { get; set; }
        public bool? PhaseIV { get; set; }
        public int CodeId { get; set; }
        public string Code { get; set; }
        public int DrugorCompounddetailsId { get; set; }
        public string Primarydrug { get; set; }
        public string Secondarydrug { get; set; }
        public string Tertiarydrug { get; set; }
        public string SecondaryType { get; set; }
        public string TertiaryaryType { get; set; }
        public int ConceptDesignandRationaleId { get; set; }
        public string Indication { get; set; }
        public string RationaleforTrial { get; set; }
        public string TrialDesign { get; set; }
        public string Binding { get; set; }
        public string Structure { get; set; }
        public string Randomized { get; set; }
        public string Gender { get; set; }
        public string MinimumAge { get; set; }
        public string MaximumAge { get; set; }
        public string PatientPopulation { get; set; }
        public string KeyInclusionCriteria { get; set; }
        public string KeyExclusionCriteria { get; set; }

        //page 2
        public bool? IsincludeCorrelativeScience { get; set; }
        public int CorrelativeScienceStudiesId { get; set; }
        public string BiomarkerStudiesperformedatStudySite { get; set; }
        public string BiomarkerStudiesperformedatCompanySite { get; set; }
        public string BiomarkerSamplingDetails { get; set; }

        public int PlannedTrialMilestoneDatesandEnrollmentId { get; set; }
        public DateTime? TrialStart { get; set; }
        public DateTime? RecruitmentEnd { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? CompletionofTrialReport { get; set; }
        public DateTime? PrimaryPublicationDate { get; set; }
        public int? TotalPlannedNumberofPatients { get; set; }
        public int? PlannedNumberofCenters { get; set; }
        public int PharmacovigilanceRequirementsId { get; set; }
        public string TrialType { get; set; }
        public bool? IsAllnonseriousAes { get; set; }
        public bool? IsAllreportsdescribingtheoccurrenceofotherspecialscenarios { get; set; }
        public string Safetydata { get; set; }
        public string AdverseEventsExemptfromCollection { get; set; }
        public string Studyduration { get; set; }

        //page3

        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public string Npinumber { get; set; }
        public string Institution { get; set; }
        public int? CountryId { get; set; }
        public int? CategoryID { get; set; }
        public string CountryName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string PostalCode { get; set; }
        //WorkFlow 
        //Start
        public string Franchise { get; set; }
        public string LocalMRCDecision { get; set; }
        public string GlobalMRCDecision { get; set; }
        public string LocalMRCRecordType { get; set; }
        public string GlobalMRCRecordType { get; set; }
       
        //End

        //IISAdmin details
        //Start
        public string Studydescriptors { get; set; }
        public string PatientType { get; set; }
        public string Safetycriteria { get; set; }
        public bool? IsPlacebocontrolled { get; set; }
        public string Studydesign { get; set; }
        public string Othercompanycompound { get; set; }
        public string InvestigationalDrugandReferenceTherapy { get; set; }
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
        public string Noofpatientspertreatmentgroup { get; set; }
        public int? Enrollmentrate { get; set; }
        public string FinalINDStatus { get; set; }
        public string INDNumber { get; set; }
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
        public DateTime? Migrationdate { get; set; }
        public string Conversionstatus { get; set; }
        public int? Milestoneupdatefrequencydays { get; set; }
        public int? Accrualmilestoneupdatefrequencydays { get; set; }
        public DateTime? Lastsendemail { get; set; }
        //End
        //Start MRCStudyReview
        public string SaereconciliationFrequency { get; set; }
        //End
        public string TrialCategorization { get; set; }
        public bool? MonitoringInterval { get; set; }
        public string MaximumAllowableVists { get; set; }
        public string Credentials { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

        //Added below property for Query string issue fix
        public string mode { get; set; }
        public string RecordType { get; set; }
        public int CohortId { get; set; }
        public int? NoofPatients { get; set; }
        public string Cohortlevel { get; set; }
        public string DoseandFrequencyDrugA { get; set; }
        public string DoseandFrequencyDrugB { get; set; }
        public List<PayeeInformation> lsPayeeInformation { get; set; }

        //Treatement Information details
        //Start
        public int TreatmentInfoId { get; set; }
        public string TreatmentArm { get; set; }
        public string NoofPatientsPlanned { get; set; }
        public string TypeofTrialDrug { get; set; }
        public string Compound { get; set; }
        public string Mindosage { get; set; }
        public string Maxdosage { get; set; }
        public string Frequency { get; set; }
        public string AdminRoute { get; set; }
        public bool? GenericAcceptable { get; set; }
        //End

        //Study Compounds details
        //Start
        public int StudyComponentId { get; set; }
        public string CompoundType { get; set; }
        public string CompanyCompound { get; set; }
        public string NonCompanyCompound { get; set; }
        public string CompoundCategory { get; set; }
        //End

        //Study Indication details
        //Start
        public int IndicationId { get; set; }        
        public string IndicationType { get; set; }
        public string IndicationCauses { get; set; }
        //End

        //Study Objectives and End points
        //Start
        public int ObjandEndPointsId { get; set; }
        public string ObjectiveType { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
        public string EndpointDescription { get; set; }
        //End

        //StudyProtocol
        //Start
        public int StudyProtocolId { get; set; }
        public string StudyProtocolnos { get; set; }
        public string Organization { get; set; }
        //End

        //StudyProtocol
        //Start
        public int SiteId { get; set; }
        public string SiteInstitution { get; set; }
        public string InstitutionInternal { get; set; }
        public string SiteCountry { get; set; }
        public bool? IsDrugShippedtoSite { get; set; }
        public bool? IsContractdirectwithSite { get; set; }
        //End

        //MRC Study details
        //Start
        public string StudyNumber { get; set; }
        //End

        //Email
        //Start
        public int Id { get; set; }
        public string Email { get; set; }
        //End

        //Milestones details
        //Start
        public int MilestoneId { get; set; }        
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phase { get; set; }
        public string Parameters { get; set; }
        public int? Dependency { get; set; }
        public DateTime? Milestonecompletiondate { get; set; }
        public DateTime? Estimatedcompletiondate { get; set; }
        public string MilestoneStatus { get; set; }
        public DateTime? Remindersentdate { get; set; }
        //End

        //GMRCTask start
        public int GMRCApprovalTaskId { get; set; }
        public string GMRCTaskName { get; set; }
        public bool? GMRCTaskCompleted { get; set; }
        public bool? GMRCGearTaskCompleted { get; set; }

        public int NoOfGearTask { get; set; }
        public bool? ISInitiateStudyCloseoutTaskCompleted { get; set; }
        public int IsallTaskCompleted { get; set; }
        public int IsIconVisible { get; set; }
        public string ContractType { get; set; }
        public string ContractStatus { get; set; }
        public string Version { get; set; }
        public string CurrentLocation { get; set; }
        public string ContactName { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string Comments { get; set; }
        public DateTime? ExecutionDate { get; set; }
        //GMRCTask end

        //Patient Accrual
        //Start
        public int PatientaccrualId { get; set; }
        public int? Year { get; set; }
        public string MonthYear { get; set; }
        public int? TreatedPatients { get; set; }
        public int? CurrentPatients { get; set; }
        public int? WithdrawnPatients { get; set; }
        public int? CompletedPatients { get; set; }
        //End

        //Invoices
        //Start
        public int InvoicesdeatilsId { get; set; }
        public DateTime? Checksenttosite { get; set; }
        public string Descriptionofpayment { get; set; }
        public DateTime? Invoicedate { get; set; }
        public string Invoicenumber { get; set; }
        public string Ponumber { get; set; }
        public string Currency { get; set; }
        public string Paymentamount { get; set; }
        public string Lineitem { get; set; }
        public string Generalledgernumber { get; set; }
        public string Departmentcode { get; set; }
        public string Budgetsource { get; set; }
        public string Personnel { get; set; }
        public string Procedural { get; set; }
        public string Irbfees { get; set; }
        public string Irbannualfees { get; set; }
        public string Administrative { get; set; }
        public string Pharmacy { get; set; }
        public string Startup { get; set; }
        public string Correlative { get; set; }
        public string Other { get; set; }
        public string Organizationtype { get; set; }
        public string Natureofexpenditure { get; set; }
        public string Purposeofexpenditure { get; set; }
        public string Settingofactivity { get; set; }
        //End

        //Status
        //Start
        public int StatusId { get; set; }
        public string Time { get; set; }
        public string StudyStatus { get; set; }
        public DateTime? Date { get; set; }
        //End

        //Review and Notes
        //Start
        public int ReviewsandNotesId { get; set; }
        public DateTime? Reviewdate { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Reviewstep { get; set; }
        public string Submissioncomments { get; set; }
        public string Decision { get; set; }
        //End
        public string StudyName { get; set; }
        public int EnableCloseStudy { get; set; }

        //Submissions
        public int SubmissionId { get; set; }
        public string Submissiontype { get; set; }
        public string Submissionversion { get; set; }
        public DateTime? Studyeligibilitydate { get; set; }
        public DateTime? Submissiondate { get; set; }
        public string Submissiondetails { get; set; }
        public string DocumentExtension { get; set; }       
        public int DocumentSize { get; set; }
        //Start
        //End
        public int UserId { get; set; }

        //Contract Timelines
        public int ContractId { get; set; }       
        public string Contracttype { get; set; }
        public string Contracttimelinestatus { get; set; }
        public string Contractversion { get; set; }
        public string Currentlocation { get; set; }
        public string Contactname { get; set; }
        public DateTime? Statuschange { get; set; }
        //
    }
}
