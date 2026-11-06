using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Anju.Navigate.Utilities;

namespace Anju.Navigate.DataAccess
{
    public class NewStudyRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public NewStudyRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Variables
        CommonRepository cmnRep = new CommonRepository();
        #endregion

        #region Methods 
        /// <summary>
        /// Get New Study Id
        /// </summary>
        /// <returns>StudyId</returns>
        public int GetNewStudyID()
        {

            var result = dbContextNavigate.NewStudy.OrderByDescending(x => x.StudyId).Take(1)
                                                         .Select(x => new Data.NewStudy
                                                         {
                                                             StudyId = x.StudyId

                                                         }).FirstOrDefault();
            if (result == null)
                return 1;
            else
                return result.StudyId += 1;
        }

        /// <summary>
        /// Get Last Entered StudyId
        /// </summary>
        /// <returns>Last StudyId</returns>
        public int GetLastEnteredStudyId()
        {
            var result = dbContextNavigate.NewStudy.OrderByDescending(x => x.StudyId).Take(1)
                                                         .Select(x => new Data.NewStudy
                                                         {
                                                             StudyId = x.StudyId

                                                         }).FirstOrDefault();
            return result.StudyId;
        }

        /// <summary>
        /// Create/Update NewStudy For ScientificRationale I
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateNewStudyForScientificRationaleI(Data.NewStudy newStudy, string userName)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.TitleofTrial = newStudy.TitleofTrial?.Trim();
                    result.Treatmentarms = newStudy.Treatmentarms?.Trim();
                    result.IsActive = true;
                    result.IsDeleted = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.NewStudy objNewStudy = new DataAccess.NewStudy()
                    {
                        TitleofTrial = newStudy.TitleofTrial?.Trim(),
                        StudyType = newStudy.StudyType?.Trim(),
                        Treatmentarms = newStudy.Treatmentarms?.Trim(),
                        PITaskStatus = Utilities.Messages.NEWSUBMISSION,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };                   
                    retVal = dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), userName, eAuditChangeType.Insert);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Create/Update NewStudy For ScientificRationale II
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateNewStudyForScientificRationaleII(int StudyId, Data.NewStudy newStudy, string userName)
        {
            int retVal = default(int);           

            if (newStudy != null)
            {
                var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == StudyId).FirstOrDefault();
                if (result != null)
                {
                    result.SampleSizeJustificationandStatisticalAnalysis = newStudy.SampleSizeJustificationandStatisticalAnalysis?.Trim();
                    result.ClinicalPharmacology = newStudy.ClinicalPharmacology?.Trim();
                    result.EnrollmentHistoryforOtherRelatedStudies = newStudy.EnrollmentHistoryforOtherRelatedStudies?.Trim();
                    result.IsCompetingStudies = newStudy.IsCompetingStudies;
                    if (result.IsCompetingStudies == false)
                        result.CompetingStudies = null;
                    else
                        result.CompetingStudies = newStudy.CompetingStudies?.Trim();
                    result.IsIndsubmission = newStudy.IsIndsubmission;
                    if (result.IsIndsubmission == true)
                        result.RationaleforINDExemption = null;
                    else
                        result.RationaleforINDExemption = newStudy.RationaleforINDExemption?.Trim();
                    result.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement;
                    result.KeyReferences = newStudy.KeyReferences?.Trim();
                    result.InvestigationalSiteProtocolNumber = newStudy.InvestigationalSiteProtocolNumber?.Trim();
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                    if (retVal > 0 && (result.PITaskStatus != Messages.NEWSUBMISSION) && (result.PITaskStatus != Messages.RESUBMITPROPOSAL))
                    {
                         var resultProtocol = dbContextNavigate.StudyProtocol.Where(x => x.StudyId == StudyId && x.ANJU_AddedBy == result.ANJU_AddedBy && x.IsActive== true && x.IsDeleted == false && x.Module == ConstDefaultValue.SUBMITRESUBMITPROTOCOL).FirstOrDefault();
                        if (resultProtocol != null)
                        {
                            resultProtocol.StudyProtocolnos = result.InvestigationalSiteProtocolNumber;
                            if (!string.IsNullOrEmpty(result.InvestigationalSiteProtocolNumber))
                            {
                                resultProtocol.IsActive = true;
                                resultProtocol.IsDeleted = false;
                            }
                            else
                            {
                                resultProtocol.IsActive = false;
                                resultProtocol.IsDeleted = true;

                            }
                            resultProtocol.ANJU_ChangedBy = userName;
                            resultProtocol.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(result, new StudyProtocol_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(result.InvestigationalSiteProtocolNumber))
                            {
                                DataAccess.StudyProtocol objStudyProtocols = new DataAccess.StudyProtocol()
                                {
                                    StudyId = StudyId,
                                    StudyProtocolnos = result.InvestigationalSiteProtocolNumber,
                                    Organization = ConstDefaultValue.SPONSORPROTOCOLNUMBER,
                                    Module= ConstDefaultValue.SUBMITRESUBMITPROTOCOL,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = userName,
                                    ANJU_AddDate = DateTime.UtcNow,
                                };
                                retVal = dbContextNavigate.SaveChanges(objStudyProtocols, new StudyProtocol_H(), objStudyProtocols.ANJU_AddedBy, eAuditChangeType.Insert);
                            } 
                        }
                    }
                }           
                if (retVal > 0)
                    return true;
                else
                    return false;
            }               
            else
                return false;
        }

        /// <summary>
        /// Get Study Task Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of Study</returns>
        public List<Data.NewStudy> GetStudyTaskDetails(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();

            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Where(w => w.StudyId == studyId && w.IsActive == true && w.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       TaskName = x.TaskName,
                                       TitleofTrial = x.TitleofTrial,
                                       TaskStatus = x.TaskStatus,
                                       PITaskStatus = x.PITaskStatus,
                                       Stage = x.Stage,
                                       State = x.State                                    

                                   }).ToList();

                return searchResult;
            }
            return lstNewProposalData;


        }

        /// <summary>
        /// Get Scientific Rationale I Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult/lstNewProposalData</returns>
        public List<Data.NewStudy> GetScientificRationaleIDetails(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.TrialPhase.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                  .GroupJoin(dbContextNavigate.DrugorCompounddetails.AsEnumerable(), t => t.Ns.StudyId, dc => dc.StudyId,
                                   (t, dc) => new { t.Ns, t.Tp, dc }).ToList()
                                   .GroupJoin(dbContextNavigate.ConceptDesignandRationale.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                   (p, cdr) => new { p.Ns, p.Tp, p.dc, cdr }).ToList()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                   (p, iis) => new { p.Ns, p.Tp, p.dc, p.cdr, iis }).ToList()
                                   .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(), p => p.Ns.StudyId, stdrev => stdrev.StudyId,
                                   (p, stdrev) => new { p.Ns, p.Tp, p.dc, p.cdr, p.iis, stdrev }).ToList()
                                   .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false )
                                   .Select(x => new Data.NewStudy
                                   {
                                       StudyType = x.Ns.StudyType,
                                       TitleofTrial = x.Ns.TitleofTrial,
                                       TrialPhaseId = x.Tp.Select(c => (int)c.TrialPhaseId).FirstOrDefault(),
                                       PhaseI = x.Tp?.Select(c => (bool)c?.PhaseI).FirstOrDefault(),
                                       PhaseII = x.Tp?.Select(c => (bool)c?.PhaseII).FirstOrDefault(),
                                       PhaseIII = x.Tp?.Select(c => (bool)c?.PhaseIII).FirstOrDefault(),
                                       PhaseIV = x.Tp?.Select(c => (bool)c?.PhaseIV).FirstOrDefault(),
                                       DrugorCompounddetailsId = x.dc.Where(dc=>dc.IsActive == true && dc.IsDeleted == false).Select(c => (int)c.DrugorCompounddetailsId).FirstOrDefault(),
                                       Primarydrug = x.dc?.Where(dc => dc.IsActive == true && dc.IsDeleted == false).Select(c => c.Primarydrug).FirstOrDefault() ?? null,
                                       Secondarydrug = x.dc?.Where(dc => dc.IsActive == true && dc.IsDeleted == false).Select(c => c.Secondarydrug).FirstOrDefault() ?? null,
                                       Tertiarydrug = x.dc?.Where(dc => dc.IsActive == true && dc.IsDeleted == false).Select(c => c.Tertiarydrug).FirstOrDefault() ?? null,
                                       SecondaryType = x.dc?.Where(dc => dc.IsActive == true && dc.IsDeleted == false).Select(c => c.SecondaryType).FirstOrDefault() ?? null,
                                       TertiaryaryType = x.dc?.Where(dc => dc.IsActive == true && dc.IsDeleted == false).Select(c => c.TertiaryaryType).FirstOrDefault() ?? null,
                                       ConceptDesignandRationaleId = x.cdr.Select(c => (int)c.ConceptDesignandRationaleId).FirstOrDefault(),
                                       Indication = x.cdr?.Select(c => c.Indication).FirstOrDefault() ?? null,
                                       RationaleforTrial = x.cdr?.Select(c => c.RationaleforTrial).FirstOrDefault() ?? null,
                                       TrialDesign = x.cdr?.Select(c => c.TrialDesign).FirstOrDefault() ?? null,
                                       Binding = x.cdr?.Select(c => c.Binding).FirstOrDefault() ?? null,
                                       Structure = x.cdr?.Select(c => c.Structure).FirstOrDefault() ?? null,
                                       Randomized = x.cdr?.Select(c => c.Randomized).FirstOrDefault() ?? null,
                                       Gender = x.cdr?.Select(c => c.Gender).FirstOrDefault() ?? null,
                                       MinimumAge = x.cdr?.Select(c => c.MinimumAge).FirstOrDefault() ?? null,
                                       MaximumAge = x.cdr?.Select(c => c.MaximumAge).FirstOrDefault() ?? null,
                                       Treatmentarms = x.Ns.Treatmentarms,
                                       PatientPopulation = x.cdr?.Select(c => c.PatientPopulation).FirstOrDefault() ?? null,
                                       KeyInclusionCriteria = x.cdr?.Select(c => c.KeyInclusionCriteria).FirstOrDefault() ?? null,
                                       KeyExclusionCriteria = x.cdr.Select(c => c.KeyExclusionCriteria).FirstOrDefault() ?? null,

                                   }).ToList();

                return searchResult;
            }
            return lstNewProposalData;
        }

        /// <summary>
        /// Get Scientific Rationale II Details
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns>searchResult/lstNewProposalData</returns>        
        public List<Data.NewStudy> GetScientificRationaleIIDetails(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.CorrelativeScienceStudies.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                    .GroupJoin(dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.AsEnumerable(), t => t.Ns.StudyId, dc => dc.StudyId,
                                     (t, dc) => new { t.Ns, t.Tp, dc }).ToList()
                                     .GroupJoin(dbContextNavigate.PharmacovigilanceRequirements.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                     (p, cdr) => new { p.Ns, p.Tp, p.dc, cdr }).ToList()
                                     .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                     (p, iis) => new { p.Ns, p.Tp, p.dc, p.cdr, iis }).ToList()
                                     .GroupJoin(dbContextNavigate.PLStudyReview.AsEnumerable(), p => p.Ns.StudyId, pls => pls.StudyId,
                                     (p, pls) => new { p.Ns, p.Tp, p.dc, p.cdr, p.iis, pls })
                                    .Where(w => w.Ns.StudyId == StudyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        StudyType = x.Ns.StudyType,
                                        SampleSizeJustificationandStatisticalAnalysis = x.Ns?.SampleSizeJustificationandStatisticalAnalysis ?? null,
                                        InvestigationalSiteProtocolNumber = x.Ns?.InvestigationalSiteProtocolNumber ?? null,
                                        ClinicalPharmacology = x.Ns?.ClinicalPharmacology ?? null,
                                        CorrelativeScienceStudiesId = x.Tp.Select(c => c.CorrelativeScienceStudiesId).FirstOrDefault(),
                                        IsincludeCorrelativeScience = x.Tp?.Select(c => c.IsincludeCorrelativeScience).FirstOrDefault() ?? null,
                                        BiomarkerStudiesperformedatStudySite = x.Tp?.Select(c => c.BiomarkerStudiesperformedatStudySite).FirstOrDefault() ?? null,
                                        BiomarkerStudiesperformedatCompanySite = x.Tp?.Select(c => c.BiomarkerStudiesperformedatCompanySite).FirstOrDefault() ?? null,
                                        BiomarkerSamplingDetails = x.Tp?.Select(c => c.BiomarkerSamplingDetails).FirstOrDefault() ?? null,
                                        PlannedTrialMilestoneDatesandEnrollmentId = x.dc.Select(c => c.PlannedTrialMilestoneDatesandEnrollmentId).FirstOrDefault(),
                                        TrialStart = x.dc?.Select(c => c.TrialStart).FirstOrDefault() ?? null,
                                        RecruitmentEnd = x.dc?.Select(c => c.RecruitmentEnd).FirstOrDefault() ?? null,
                                        TrialEnd = x.dc?.Select(c => c.TrialEnd).FirstOrDefault() ?? null,
                                        CompletionofTrialReport = x.dc?.Select(c => c.CompletionofTrialReport).FirstOrDefault() ?? null,
                                        PrimaryPublicationDate = x.dc?.Select(c => c.PrimaryPublicationDate).FirstOrDefault() ?? null,
                                        TotalPlannedNumberofPatients = x.dc?.Select(c => c.TotalPlannedNumberofPatients).FirstOrDefault() ?? null,
                                        PlannedNumberofCenters = x.dc?.Select(c => c.PlannedNumberofCenters).FirstOrDefault() ?? null,
                                        EnrollmentHistoryforOtherRelatedStudies = x.Ns.EnrollmentHistoryforOtherRelatedStudies ?? null,
                                        IsCompetingStudies = x.Ns.IsCompetingStudies ?? null,
                                        CompetingStudies = x.Ns.CompetingStudies ?? null,
                                        IsIndsubmission = x.Ns.IsIndsubmission ?? null,
                                        RationaleforINDExemption = x.Ns.RationaleforINDExemption ?? null,
                                        FinalINDStatus = x.iis?.Select(c => c.FinalINDStatus).FirstOrDefault() ?? null,
                                        INDNumber = x.iis?.Select(c => c.INDNumber).FirstOrDefault() ?? null,
                                        IsIrbregistrationRequirement = x.Ns.IsIrbregistrationRequirement ?? null,
                                        PharmacovigilanceRequirementsId = x.cdr.Select(c => (int)c.PharmacovigilanceRequirementsId).FirstOrDefault(),
                                        TrialType = x.cdr?.Select(c => c.TrialType).FirstOrDefault() ?? null,
                                        IsAllnonseriousAes = x.cdr?.Select(c => c.IsAllnonseriousAes).FirstOrDefault() ?? null,
                                        IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = x.cdr?.Select(c => c.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios).FirstOrDefault() ?? null,
                                        Safetydata = x.cdr?.Select(c => c.Safetydata).FirstOrDefault() ?? null,
                                        AdverseEventsExemptfromCollection = x.cdr?.Select(c => c.AdverseEventsExemptfromCollection).FirstOrDefault() ?? null,
                                        KeyReferences = x.Ns.KeyReferences ?? null,
                                        Studyduration = x.iis?.Select(c => c.Studyduration).FirstOrDefault() ?? null,
                                        Enrollmentrate = x.iis?.Select(c => c.Enrollmentrate).FirstOrDefault() ?? null,
                                        Interventionaltrialdatacollection = x.iis?.Select(c => c.Interventionaltrialdatacollection).FirstOrDefault() ?? null,
                                        NonInterventionaltrialdatacollection = x.iis?.Select(c => c.NonInterventionaltrialdatacollection).FirstOrDefault() ?? null,
                                        Noofpatientspertreatmentgroup = x.iis?.Select(c => c.Noofpatientspertreatmentgroup).FirstOrDefault() ?? null,
                                        TrialCategorization = x.pls?.Select(c => c.TrialCategorization).FirstOrDefault() ?? null,
                                        MonitoringInterval = x.pls?.Select(c => c.MonitoringInterval).FirstOrDefault() ?? null,
                                        MaximumAllowableVists = x.pls?.Select(c => c.MaximumAllowableVists).FirstOrDefault() ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        ///  Get the Personal and Research Site Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult</returns>        
        public List<Data.NewStudy> GetPersonalandResearchSiteDetails(int studyId)
        {

            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .Join(dbContextNavigate.PrincipalInvestigator.AsEnumerable(), Ns => Ns.StudyId, Pi => Pi.StudyId,
                                   (Ns, pi) => new { Ns, pi })
                                   .GroupJoin(dbContextNavigate.Country.AsEnumerable(), t => t.pi.CountryId, c => c.CountryId,
                                   (t, c) => new { t, c = c.FirstOrDefault() }).ToList()
                                   .GroupJoin(dbContextNavigate.State.AsEnumerable(), r => r.t.pi.StateId, s => s.StateId,
                                   (r, s) => new { r, s = s.FirstOrDefault() }).ToList()
                                   .GroupJoin(dbContextNavigate.City.AsEnumerable(), q => q.r.t.pi.CityId, ci => ci.CityId,
                                   (q, ci) => new { q, ci = ci.FirstOrDefault() }).ToList()
                                   .Where(w => w.q.r.t.Ns.StudyId == studyId && w.q.r.t.Ns.IsActive == true && w.q.r.t.Ns.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       /* Principal Investigator*/
                                       SiteIndex = x.q.r.t.pi.SiteIndex ?? null,
                                       ContactType = x.q.r.t.pi.ContactType ?? null,
                                       ContactTypeDetails = x.q.r.t.pi.ContactTypeDetails ?? null,
                                       TaxID = x.q.r.t.pi.TaxID ?? null,
                                       CategoryID = x?.q?.r?.t?.pi?.CategoryID ?? null,
                                       Salutation = x.q.r.t.pi.Salutation ?? null,
                                       FirstName = x.q.r.t.pi.FirstName ?? null,
                                       LastName = x.q.r.t.pi.LastName ?? null,
                                       Suffix = x.q.r.t.pi.Suffix ?? null,
                                       Title = x.q.r.t.pi.Title ?? null,
                                       Degree = x.q.r.t.pi.Degree ?? null,
                                       Npinumber = x.q.r.t.pi.Npinumber ?? null,
                                       Institution = x.q.r.t.pi.Institution ?? null,
                                       CountryId = x?.q?.r?.c?.CountryId,
                                       CountryName = x?.q?.r?.c?.Name ?? null,
                                       StateId = x?.q?.s?.StateId,
                                       StateName = x?.q?.s?.Name ?? null,
                                       CityId = x?.ci?.CityId,
                                       CityName = x?.ci?.Name ?? null,
                                       Address1 = x.q.r.t.pi.Address1 ?? null,
                                       Address2 = x.q.r.t.pi.Address2 ?? null,
                                       Address3 = x.q.r.t.pi.Address3 ?? null,
                                       Phone = x.q.r.t.pi.Phone ?? null,
                                       Fax = x.q.r.t.pi.Fax ?? null,
                                       PrimaryEmailId = x.q.r.t.pi.PrimaryEmailId ?? null,
                                       PostalCode = x.q.r.t.pi.PostalCode ?? null,
                                       MedicalSpecialty = x.q.r.t.Ns.MedicalSpecialty ?? null,
                                       BoardCertification = x.q.r.t.Ns.BoardCertification ?? null,
                                       MedicalLicense = x.q.r.t.Ns.MedicalLicense ?? null,
                                       IsCompanySponsoredtrial = x?.q?.r?.t?.Ns?.IsCompanySponsoredtrial ?? null,
                                       DrugName = x.q.r.t.Ns.DrugName ?? null,
                                       ProtocolNumber = x.q.r.t.Ns.ProtocolNumber ?? null,
                                       TrialParticipation = x.q.r.t.Ns.TrialParticipation ?? null,
                                       IsOtherTrainingsReceived = x?.q?.r?.t?.Ns?.IsOtherTrainingsReceived ?? null,
                                       LastTrainingDetails = x.q.r.t.Ns.LastTrainingDetails ?? null,
                                       TypeOfTraining = x.q.r.t.Ns.TypeOfTraining ?? null,
                                       TrialExperiences = x.q.r.t.Ns.TrialExperiences ?? null,
                                       NumberOfOngoingTrials = x.q.r.t.Ns.NumberOfOngoingTrials ?? null,
                                       IsSiteInspectedByHealthAuthority = x?.q?.r?.t?.Ns?.IsSiteInspectedByHealthAuthority ?? null,
                                       NameOfHealthAuthority = x.q.r.t.Ns.NameOfHealthAuthority ?? null,
                                       DateOflastInspection = x?.q?.r?.t?.Ns?.DateOflastInspection ?? null,
                                       IsSiteInspectedByFda = x?.q?.r?.t?.Ns?.IsSiteInspectedByFda ?? null,
                                       DateOfFdainspection = x?.q?.r?.t?.Ns?.DateOfFdainspection ?? null,
                                       Isfda483formIssued = x?.q?.r?.t?.Ns?.Isfda483formIssued ?? null,
                                       DetailsOfObservation = x.q.r.t.Ns.DetailsOfObservation ?? null,
                                       IsCooperativeGroupStudy = x?.q?.r?.t?.Ns?.IsCooperativeGroupStudy ?? null,
                                       CooperativeGroupName = x.q.r.t.Ns.CooperativeGroupName ?? null,
                                       IsPhysicianNetworkStudy = x?.q?.r?.t?.Ns?.IsPhysicianNetworkStudy ?? null,
                                       PhysicianNetworkName = x.q.r.t.Ns.PhysicianNetworkName ?? null,
                                       IsGovernmentSupportProvided = x?.q?.r?.t?.Ns?.IsGovernmentSupportProvided ?? null,
                                       SupportDescription = x.q.r.t.Ns.SupportDescription ?? null,
                                       IsSupportProvidedByOtherSources = x?.q?.r?.t?.Ns?.IsSupportProvidedByOtherSources ?? null,
                                       SupportSources = x.q.r.t.Ns.SupportSources ?? null

                                   }).ToList();

                return searchResult;

            }
            return lstNewProposalData;
        }
        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>        
        public List<Data.NewStudy> GetContacts(int studyId)
        {

            List<Data.NewStudy> lstgetContacts = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .Join(dbContextNavigate.PrincipalInvestigator.AsEnumerable(), Ns => Ns.StudyId, Pi => Pi.StudyId,
                                   (Ns, pi) => new { Ns, pi }).ToList()
                                   .GroupJoin(dbContextNavigate.Country.AsEnumerable(), t => t.pi.CountryId, c => c.CountryId,
                                   (t, c) => new { t, c = c.FirstOrDefault() }).ToList()
                                   .GroupJoin(dbContextNavigate.State.AsEnumerable(), r => r.t.pi.StateId, s => s.StateId,
                                   (r, s) => new { r, s = s.FirstOrDefault() }).ToList()
                                   .GroupJoin(dbContextNavigate.City.AsEnumerable(), q => q.r.t.pi.CityId, ci => ci.CityId,
                                   (q, ci) => new { q, ci = ci.FirstOrDefault() }).ToList()
                                   .Where(w => w.q.r.t.Ns.StudyId == studyId &&
                                               w.q.r.t.Ns.IsActive == true &&
                                               w.q.r.t.pi.StudyId == studyId &&
                                               w.q.r.t.pi.IsActive == true)
                                   .Select(x => new Data.NewStudy
                                   {
                                       /* Principal Investigator*/
                                       StudyId = x.q.r.t.pi.StudyId,
                                       PrincipalInvestigatorId = x.q.r.t.pi.PrincipalInvestigatorId,
                                       SiteIndex = x.q.r.t.pi.SiteIndex ?? null,
                                       ContactType = x.q.r.t.pi.ContactType ?? null,
                                       ContactTypeDetails = x.q.r.t.pi.ContactTypeDetails ?? null,
                                       TaxID = x.q.r.t.pi.TaxID ?? null,
                                       Salutation = x.q.r.t.pi.Salutation ?? null,
                                       FirstName = x.q.r.t.pi.FirstName ?? null,
                                       LastName = x.q.r.t.pi.LastName ?? null,
                                       Suffix = x.q.r.t.pi.Suffix ?? null,
                                       Title = x.q.r.t.pi.Title ?? null,
                                       Degree = x.q.r.t.pi.Degree ?? null,
                                       Npinumber = x.q.r.t.pi.Npinumber ?? null,
                                       Institution = x.q.r.t.pi.Institution ?? null,
                                       CountryId = x?.q?.r?.c?.CountryId,
                                       CountryName = x?.q?.r?.c?.Name ?? null,
                                       StateId = x?.q?.s?.StateId,
                                       StateName = x?.q?.s?.Name ?? null,
                                       CityId = x?.ci?.CityId,
                                       CityName = x?.ci?.Name ?? null,
                                       Address1 = x.q.r.t.pi.Address1 ?? null,
                                       Address2 = x.q.r.t.pi.Address2 ?? null,
                                       Address3 = x.q.r.t.pi.Address3 ?? null,
                                       Phone = x.q.r.t.pi.Phone ?? null,
                                       Fax = x.q.r.t.pi.Fax ?? null,
                                       PrimaryEmailId = x.q.r.t.pi.PrimaryEmailId ?? null,
                                       PostalCode = x.q.r.t.pi.PostalCode ?? null,
                                       Region = x.q.r.t.pi.Region ?? null,
                                   }).ToList();

                return searchResult;

            }
            return lstgetContacts;
        }
        /// <summary>
        /// Get Study Id For PI
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>lstStudyIdForPI</returns>        
        public List<Data.NewStudy> GetStudyIdForPI(string userName, string typeOfGrid)
        {
            List<string> taskName = new List<string>();

            if (typeOfGrid == Utilities.ConstDefaultValue.TASK)
            {
                taskName.Add(Utilities.Messages.NEWSUBMISSION);
                taskName.Add(Utilities.Messages.SUBMITPROTOCOL);
                taskName.Add(Utilities.Messages.SUBMITREQUIREDICFDOCUMENT);
                taskName.Add(Utilities.Messages.RESUBMITPROPOSAL);
                taskName.Add(Utilities.Messages.SUBMITACTIVATIONDOCUMENTS);
                taskName.Add(Utilities.Messages.RESUBMITACTIVATIONDOCUMENTS);
                taskName.Add(Utilities.Messages.ICFRESUBMISSIONREQUIRED);
                var lstStudyIdForPI = dbContextNavigate.NewStudy.AsEnumerable()
                                    .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                          Ns => new { StudyId = Ns.StudyId.ToString() },
                                                          Sr => new { StudyId = Sr.StudyId.ToString() },
                                                          (Ns, Sr) => new { Ns, Sr }).ToList()
                                    .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                p => new { StudyId = p.Ns.StudyId.ToString() },
                                                Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                (p, Mrc) => new { p.Ns, p.Sr, Mrc }).ToList()
                                      .Where(w => w.Ns.ANJU_AddedBy == userName && w.Ns.IsActive == true && w.Ns.IsDeleted == false &&
                                             w.Ns.Stage != Utilities.Messages.DECISIONAPPROVED && taskName.Contains(w.Ns.PITaskStatus))
                                       .OrderByDescending(x => x.Ns.StudyId)
                                                           .Select(x => new Data.NewStudy
                                                           {
                                                               StudyId = x.Ns.StudyId,
                                                               StudyType = x.Ns.StudyType,
                                                               TitleofTrial = x.Ns.TitleofTrial ?? null,
                                                               ANJU_AddedBy = x.Ns.ANJU_AddedBy,
                                                               ANJU_AddDate = x.Ns.ANJU_AddDate,
                                                               TaskStatus = x.Ns.TaskStatus,
                                                               PITaskStatus = x.Ns.PITaskStatus ?? " ",
                                                               Stage = x.Ns.Stage,
                                                               State = x.Ns.State,
                                                               //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault()+":"+ x.Ns.TitleofTrial : x.Ns.StudyId + ":" + x.Ns.TitleofTrial,
                                                               StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Ns.StudyId + ": " + x.Ns.TitleofTrial,
                                                               Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null,
                                                               StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,                                                               
                                                               Franchise = x.Sr.Select(c => c.Franchise).FirstOrDefault() ?? null,
                                                               ANJU_ChangeDate = dbContextNavigate.NewStudy.AsEnumerable().Where(y => x.Ns.StudyId == y.StudyId && y.ANJU_AddedBy == userName && y.IsActive == true &&
                                                                                                y.IsDeleted == false && y.TaskStatus == Utilities.Messages.PENDINGMANUALMSLANDPLASSIGNMENT).Select(m => m.ANJU_ChangeDate).FirstOrDefault()
                                                           }).Union(dbContextNavigate.GMRCApprovalTask.AsEnumerable()
                                                        .Join(dbContextNavigate.NewStudy.AsEnumerable(), AD => AD.StudyId, Ns => Ns.StudyId,
                                                         (AD, Ns) => new { AD, Ns })
                                                      .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                      t => new { StudyId = t.AD.StudyId.ToString() },
                                                      Sr => new { StudyId = Sr.StudyId.ToString() },
                                                      (t, Sr) => new { t.Ns, t.AD, Sr = Sr.FirstOrDefault() }).ToList()
                                                        .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Ns.AD, Mrc }).ToList()
                                                      .Where(w => w.AD.AssignedTo == userName && w.AD.IsTaskCompleted == false && w.AD.IsActive == true && w.AD.IsDeleted == false && w.AD.StudyStatus == null && w.AD.IsGearTaskCompleted == null)
                                                      .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                    .Select(y => new Data.NewStudy
                                                    {
                                                        StudyId = y.Ns.Ns.StudyId,
                                                        TitleofTrial = y.Ns.Ns.TitleofTrial,
                                                        StudyType = y.Ns.Ns.StudyType,
                                                        ANJU_AddedBy = y.Ns.Ns.ANJU_AddedBy,
                                                        ANJU_AddDate = y.Ns.AD.ANJU_AddDate,
                                                        PITaskStatus = y.Ns.AD.TaskName,
                                                        State = y.Ns.Ns.State,
                                                        TaskName = y.Ns.AD.TaskName,
                                                        Franchise = y.Ns.Sr.Franchise ?? null,
                                                        //StudyName = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + y.Ns.Ns.TitleofTrial : y.Ns.Ns.StudyId + ":" + y.Ns.Ns.TitleofTrial,
                                                        StudyName = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + y.Ns.Ns.TitleofTrial : y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + y.Ns.Ns.TitleofTrial : y.Ns.Ns.StudyId + ": " + y.Ns.Ns.TitleofTrial,
                                                        ANJU_ChangeDate = y.Ns.Ns.ANJU_ChangeDate,
                                                        LocalMRCDecision = null,
                                                        GlobalMRCDecision = null,
                                                        Institution = y.Sr?.Institution ?? null,
                                                        StudyNumber = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                    })).ToList();
                return lstStudyIdForPI;
            }
            else
            {
                var lstStudyIdForPI = dbContextNavigate.NewStudy.AsEnumerable()
                                  .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                        Ns => new { StudyId = Ns.StudyId.ToString() },
                                                        Sr => new { StudyId = Sr.StudyId.ToString() },
                                                        (Ns, Sr) => new { Ns, Sr }).ToList()
                                  .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                w => new { StudyId = w.Ns.StudyId.ToString() },
                                                Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                (w, Mrc) => new { w.Ns, w.Sr, Mrc }).ToList()
                                   .GroupJoin(dbContextNavigate.GMRCApprovalTask.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Gmrc => new { StudyId = Gmrc.StudyId.ToString() },
                                                     (Ns, Gmrc) => new { Ns, Ns.Sr,Ns.Mrc,Gmrc }).ToList()
                                    .Where(w => w.Ns.Ns.ANJU_AddedBy == userName && w.Ns.Ns.IsActive == true && w.Ns.Ns.IsDeleted == false)
                                     .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                         .Select(x => new Data.NewStudy
                                                         {
                                                             StudyId = x.Ns.Ns.StudyId,
                                                             StudyType = x.Ns.Ns.StudyType,
                                                             TitleofTrial = x.Ns.Ns.TitleofTrial ?? null,
                                                             ANJU_AddedBy = x.Ns.Ns.ANJU_AddedBy,
                                                             ANJU_AddDate = x.Ns.Ns.ANJU_AddDate,
                                                             TaskStatus = x.Ns.Ns.TaskStatus,
                                                             PITaskStatus = x.Ns.Ns.PITaskStatus ?? " ",
                                                             Stage = x.Ns.Ns.Stage,
                                                             State = x.Ns.Ns.State,
                                                             //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ":" + x.Ns.Ns.TitleofTrial,
                                                             StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ": " + x.Ns.Ns.TitleofTrial,
                                                             Franchise = x.Sr.Select(c => c.Franchise).FirstOrDefault() ?? null,
                                                             Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null,
                                                             StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                             ISInitiateStudyCloseoutTaskCompleted = x.Gmrc?.Where(y => y?.TaskName == Utilities.Messages.INITIATESTUDYCLOSEOUT).Select(r => r.IsTaskCompleted).FirstOrDefault() ?? null,
                                                             IsallTaskCompleted = dbContextNavigate.GMRCApprovalTask.Where(y => y.IsTaskCompleted == false && y.StudyId == x.Ns.Ns.StudyId && y.AssignedTo == userName).Select(y => y.TaskName).ToList().Count(),
                                                             ANJU_ChangeDate = dbContextNavigate.NewStudy.AsEnumerable().Where(y => x.Ns.Ns.StudyId == y.StudyId && y.ANJU_AddedBy == userName && y.IsActive == true &&
                                                                                         y.IsDeleted == false && y.TaskStatus == Utilities.Messages.PENDINGMANUALMSLANDPLASSIGNMENT).Select(m => m.ANJU_ChangeDate).FirstOrDefault() ?? x.Ns.Ns.ANJU_AddDate
                                                         }).ToList();
                return lstStudyIdForPI;
            }
        }

        /// <summary>
        /// Get Study owner Details by userType
        /// </summary>       
        /// <returns>lstStudyDetails</returns>
        public string GetStudyOwnerDetails(int studyid)
        {
            return dbContextNavigate.NewStudy.Single(x => x.StudyId == studyid).ANJU_AddedBy;
        }

        /// <summary>
        /// Get Study Details by userType
        /// </summary>       
        /// <returns>lstStudyDetails</returns>
        public List<Data.NewStudy> GetStudyDetails(string userType, string loginuserName)
        {
            List<string> taskName = new List<string>();

            if (userType == Utilities.ConstDefaultValue.IISADMIN)
            {
                taskName.Add(Utilities.Messages.ASSIGNMSLANDPL);
            }
            else if (userType == Utilities.ConstDefaultValue.MSL)
            {
                taskName.Add(Utilities.Messages.MSLLOIREVIEW);
                taskName.Add(Utilities.Messages.RETURNRESUBMITPROPOSAL);
                taskName.Add(Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME);
                taskName.Add(Utilities.Messages.RETURNRESUBMITPROPOSALTOGMRC);
                taskName.Add(Utilities.Messages.GMRCMSLREVIEW);
                taskName.Add(Utilities.Messages.CONDITIONALLYAPPROVEDTASKNAME);

                var LoggedInUser = dbContextNavigate.Users.Where(x => x.UserName == loginuserName).FirstOrDefault();
                var MSLStudyDetails = dbContextNavigate.NewStudy.AsEnumerable()
                                .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.StudyId.ToString() },
                                                     Sr => new { StudyId = Sr.StudyId.ToString() },
                                                     (Ns, Sr) => new { Ns, Sr }).ToList()
                                  .GroupJoin(dbContextNavigate.StudyTask.AsEnumerable(),
                                                     t => new { StudyId = t.Ns.StudyId.ToString() },
                                                     St => new { StudyId = St.StudyId.ToString() },
                                                     (t, St) => new { t.Ns, t.Sr, St }).ToList()
                                 .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                w => new { StudyId = w.Ns.StudyId.ToString() },
                                                Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                (w, Mrc) => new { w.Ns, w.Sr, w.St, Mrc }).ToList()
                               .Where(x => taskName.Contains(x.Ns.TaskName) && x.Ns.IsActive == true && x.Ns.IsDeleted == false && x.St.Any(y => y.MsluserId == LoggedInUser.UserId))
                                .OrderByDescending(x => x.Ns.StudyId)
                                                       .Select(x => new Data.NewStudy
                                                       {
                                                           StudyId = x.Ns.StudyId,
                                                           TitleofTrial = x.Ns.TitleofTrial,
                                                           StudyType = x.Ns.StudyType,
                                                           ANJU_AddedBy = x.Ns.ANJU_AddedBy,
                                                           ANJU_AddDate = x.Ns.ANJU_AddDate,
                                                           TaskStatus = x.Ns.TaskStatus,
                                                           TaskName = x.Ns.TaskName,
                                                           Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null,
                                                           // StudyName= x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.TitleofTrial : x.Ns.StudyId + ":" + x.Ns.TitleofTrial,
                                                           StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Ns.StudyId + ": " + x.Ns.TitleofTrial,
                                                           StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                           State = x.Ns.State,
                                                           Franchise = x.Sr?.Select(c => c?.Franchise).FirstOrDefault() ?? null,
                                                           ANJU_ChangeDate = x.Ns.ANJU_ChangeDate,

                                                       }).ToList();
                return MSLStudyDetails;
            }
            else if (userType == Utilities.ConstDefaultValue.PROGRAMLEADER)
            {
                taskName.Add(Utilities.Messages.PLREVIEW);
                var LoggedInUser = dbContextNavigate.Users.Where(x => x.UserName == loginuserName).Select(y => y.UserId).ToList();
                var PLStudyDetails = dbContextNavigate.NewStudy.AsEnumerable()
                                .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.StudyId.ToString() },
                                                     Sr => new { StudyId = Sr.StudyId.ToString() },
                                                     (Ns, Sr) => new { Ns, Sr }).ToList()
                                 .GroupJoin(dbContextNavigate.StudyTask.AsEnumerable(),
                                                     t => new { StudyId = t.Ns.StudyId.ToString() },
                                                     St => new { StudyId = St.StudyId.ToString() },
                                                     (t, St) => new { t.Ns, t.Sr, St }).ToList()
                                 .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                w => new { StudyId = w.Ns.StudyId.ToString() },
                                                Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                (w, Mrc) => new { w.Ns, w.Sr, w.St, Mrc }).ToList()
                                 .Where(x => taskName.Contains(x.Ns.TaskName) && x.Ns.IsActive == true && x.Ns.IsDeleted == false && x.St.Any(e => LoggedInUser.Contains(e.PluserId)))
                                 .OrderByDescending(x => x.Ns.StudyId)
                                                       .Select(x => new Data.NewStudy
                                                       {
                                                           StudyId = x.Ns.StudyId,
                                                           TitleofTrial = x.Ns.TitleofTrial,
                                                           StudyType = x.Ns.StudyType,
                                                           ANJU_AddedBy = x.Ns.ANJU_AddedBy,
                                                           ANJU_AddDate = x.Ns.ANJU_AddDate,
                                                           TaskStatus = x.Ns.TaskStatus,
                                                           TaskName = x.Ns.TaskName,
                                                           State = x.Ns.State,
                                                           //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.TitleofTrial : x.Ns.StudyId + ":" + x.Ns.TitleofTrial,
                                                           StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.TitleofTrial : x.Ns.StudyId + ": " + x.Ns.TitleofTrial,
                                                           Franchise = x.Sr?.Select(c => c.Franchise).FirstOrDefault() ?? null,
                                                           ANJU_ChangeDate = x.Ns.ANJU_ChangeDate,
                                                           Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null
                                                       }).ToList();
                return PLStudyDetails;
            }
            else if (userType == Utilities.ConstDefaultValue.TRIALLEADER)
            {
                taskName.Add(Utilities.Messages.PLTASKNAME);
                taskName.Add(Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME);
                taskName.Add(Utilities.Messages.LMRCDECISIONAPPROVEDTASKNAME);
                taskName.Add(Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME);
                taskName.Add(Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME);
                taskName.Add(Utilities.Messages.GMRCAPPROVEDTASKNAME);
                taskName.Add(Utilities.Messages.SAEFINALRECONCILIATIONREPORTCONFIRMATION);
                taskName.Add(Utilities.Messages.DOCUMENTSUBMISSIONREVIEW);

                var LoggedInUser = dbContextNavigate.Users.Where(x => x.UserName == loginuserName).Select(y => y.UserId).ToList();
                var TLStudyDetails = dbContextNavigate.NewStudy.AsEnumerable()
                                .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.StudyId.ToString() },
                                                     Sr => new { StudyId = Sr.StudyId.ToString() },
                                                     (Ns, Sr) => new { Ns, Sr }).ToList()
                                 .GroupJoin(dbContextNavigate.PLStudyReview.AsEnumerable(),
                                                     t => new { StudyId = t.Ns.StudyId.ToString() },
                                                     PL => new { StudyId = PL.StudyId.ToString() },
                                                     (t, PL) => new { t.Ns, t.Sr, PL }).ToList()
                                   .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Ns.PL, Mrc }).ToList()
                               .Where(x => taskName.Contains(x.Ns.Ns.TaskName) && x.Ns.Ns.IsActive == true && x.Ns.Ns.IsDeleted == false && x.PL.Any(e => LoggedInUser.Contains(e.TluserId)))
                               .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                       .Select(x => new Data.NewStudy
                                                       {
                                                           StudyId = x.Ns.Ns.StudyId,
                                                           TitleofTrial = x.Ns.Ns.TitleofTrial,
                                                           StudyType = x.Ns.Ns.StudyType,
                                                           ANJU_AddedBy = x.Ns.Ns.ANJU_AddedBy,
                                                           ANJU_AddDate = x.Ns.Ns.ANJU_AddDate,
                                                           TaskStatus = x.Ns.Ns.TaskStatus,
                                                           State = x.Ns.Ns.State,
                                                           TaskName = x.Ns.Ns.TaskName,
                                                           StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ": " + x.Ns.Ns.TitleofTrial,
                                                           StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                           Franchise = x.Sr?.Select(c => c?.Franchise).FirstOrDefault() ?? null,
                                                           Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null,
                                                           ANJU_ChangeDate = x.Ns.Ns.ANJU_ChangeDate,
                                                           LocalMRCDecision = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.LocalMRC).Select(r => r?.LocalMrcdecision).FirstOrDefault() ?? null,
                                                           GlobalMRCDecision = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.GlobalMrcdecision).FirstOrDefault() ?? null,

                                                       }).Union(dbContextNavigate.GMRCApprovalTask.AsEnumerable()
                                                          .Join(dbContextNavigate.NewStudy.AsEnumerable(), AD => AD.StudyId, Ns => Ns.StudyId,
                                                           (AD, Ns) => new { AD, Ns })
                                                        .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                        t => new { StudyId = t.AD.StudyId.ToString() },
                                                        Sr => new { StudyId = Sr.StudyId.ToString() },
                                                        (t, Sr) => new { t.Ns, t.AD, Sr = Sr.FirstOrDefault() }).ToList()
                                                        .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Ns.AD, Mrc }).ToList()
                                                        .Where(w => w.AD.AssignedTo == loginuserName && w.AD.IsTaskCompleted == false && w.AD.StudyStatus == null && w.AD.IsGearTaskCompleted == null)
                                                         .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                      .Select(y => new Data.NewStudy
                                                      {
                                                          StudyId = y.Ns.Ns.StudyId,
                                                          TitleofTrial = y.Ns.Ns.TitleofTrial,
                                                          StudyType = y.Ns.Ns.StudyType,
                                                          ANJU_AddedBy = y.Ns.Ns.ANJU_AddedBy,
                                                          ANJU_AddDate = y.AD.ANJU_AddDate,
                                                          TaskStatus = y.Ns.Ns.TaskStatus,
                                                          State = y.Ns.Ns.State,
                                                          TaskName = y.AD?.TaskName,
                                                          Franchise = y.Sr?.Franchise ?? null,
                                                          ANJU_ChangeDate = y.Ns.Ns.ANJU_ChangeDate,
                                                          LocalMRCDecision = null,
                                                          Institution = y.Sr?.Institution ?? null,
                                                          //StudyName = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + y.Ns.Ns.TitleofTrial : y.Ns.Ns.StudyId + ":" + y.Ns.Ns.TitleofTrial,
                                                          StudyName = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + y.Ns.Ns.TitleofTrial : y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + y.Ns.Ns.TitleofTrial : y.Ns.Ns.StudyId + ": " + y.Ns.Ns.TitleofTrial,
                                                          StudyNumber = y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? y.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                          GlobalMRCDecision = null,
                                                      })).ToList();
                return TLStudyDetails;
            }
            var lstStudyDetails = dbContextNavigate.NewStudy.AsEnumerable()
                                    .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                         Ns => new { StudyId = Ns.StudyId.ToString() },
                                                         Sr => new { StudyId = Sr.StudyId.ToString() },
                                                         (Ns, Sr) => new { Ns, Sr }).ToList()
                                     .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Mrc }).ToList()
                                   .Where(x => taskName.Contains(x.Ns.Ns.TaskName) && x.Ns.Ns.IsActive == true && x.Ns.Ns.IsDeleted == false)
                                   .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                           .Select(x => new Data.NewStudy
                                                           {
                                                               StudyId = x.Ns.Ns.StudyId,
                                                               TitleofTrial = x.Ns.Ns.TitleofTrial,
                                                               StudyType = x.Ns.Ns.StudyType,
                                                               ANJU_AddedBy = x.Ns.Ns.ANJU_AddedBy,
                                                               ANJU_AddDate = x.Ns.Ns.ANJU_AddDate,
                                                               TaskStatus = x.Ns.Ns.TaskStatus,
                                                               TaskName = x.Ns.Ns.TaskName,
                                                               State = x.Ns.Ns.State,
                                                               Franchise = x.Sr?.Select(c => c?.Franchise).FirstOrDefault() ?? null,
                                                               ANJU_ChangeDate = x.Ns.Ns.ANJU_ChangeDate,
                                                               //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ":" + x.Ns.Ns.TitleofTrial,
                                                               StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ": " + x.Ns.Ns.TitleofTrial,
                                                               StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                               Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null

                                                           }).ToList();
            return lstStudyDetails;

        }

        /// <summary>
        /// Get TaskDetails by UserName
        /// </summary>       
        /// <returns>lstStudyDetails</returns>
        public List<Data.NewStudy> GetTaskDetails(string userName, string userType)

        {
            List<Data.NewStudy> newStudies = new List<Data.NewStudy>();
            if (userType == Utilities.ConstDefaultValue.MSL)
            {
                var lstStudyDetails = dbContextNavigate.NewStudy.AsEnumerable().ToList()
                               .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                                   Sr => new { StudyId = Sr.StudyId.ToString() },
                                                   (Ns, Sr) => new { Ns, Sr = Sr.FirstOrDefault() }).ToList()
                               .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Mrc }).ToList()
                               .Where(w => w.Ns.Ns.IsActive == true && w.Ns.Ns.IsDeleted == false)
                               .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                    .Select(x => new Data.NewStudy
                                                    {
                                                        StudyId = x.Ns.Ns.StudyId,
                                                        StudyType = x.Ns.Ns.StudyType,
                                                        TitleofTrial = x.Ns.Ns.TitleofTrial ?? null,
                                                        ANJU_AddedBy = x.Ns.Ns.ANJU_AddedBy,
                                                        ANJU_AddDate = x.Ns.Ns.ANJU_AddDate,
                                                        TaskStatus = x.Ns.Ns.TaskStatus ?? null,
                                                        TaskName = x.Ns.Ns.TaskName ?? null,
                                                        Stage = x.Ns.Ns.Stage ?? null,
                                                        State = x.Ns.Ns.State?? null,
                                                        Franchise = x.Sr?.Franchise ?? null,
                                                        //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ":" + x.Ns.Ns.TitleofTrial,                 
                                                        StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ": " + x.Ns.Ns.TitleofTrial,
                                                        StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                    }).ToList();
                return lstStudyDetails;
            }
            else if (userType == Utilities.ConstDefaultValue.PROGRAMLEADER)
            {

                var lstStudyDetails = dbContextNavigate.NewStudy.AsEnumerable().ToList()
                               .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                                   Sr => new { StudyId = Sr.StudyId.ToString() },
                                                   (Ns, Sr) => new { Ns, Sr = Sr.FirstOrDefault() }).ToList()
                                .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Mrc }).ToList()
                              .Where(w => w.Ns.Ns.IsActive == true && w.Ns.Ns.IsDeleted == false)
                               .OrderByDescending(x => x.Ns.Ns.StudyId)
                                                    .Select(x => new Data.NewStudy
                                                    {
                                                        StudyId = x.Ns.Ns.StudyId,
                                                        StudyType = x.Ns.Ns.StudyType,
                                                        TitleofTrial = x.Ns.Ns.TitleofTrial ?? null,
                                                        ANJU_AddedBy = x.Ns.Ns.ANJU_AddedBy,
                                                        ANJU_AddDate = x.Ns.Ns.ANJU_AddDate,
                                                        TaskStatus = x.Ns.Ns.TaskStatus,
                                                        TaskName = x.Ns.Ns.TaskName,
                                                        Stage = x.Ns.Ns.Stage,
                                                        State = x.Ns.Ns.State,
                                                        Franchise = x.Sr?.Franchise ?? null,
                                                        //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ":" + x.Ns.Ns.TitleofTrial,
                                                        StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.TitleofTrial : x.Ns.Ns.StudyId + ": " + x.Ns.Ns.TitleofTrial,
                                                        StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                    }).ToList();
                return lstStudyDetails;
            }
            else if (userType == Utilities.ConstDefaultValue.TRIALLEADER)
            {
                var lstStudyDetails = dbContextNavigate.NewStudy.AsEnumerable()
                                 .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.StudyId.ToString() },
                                                     Sr => new { StudyId = Sr.StudyId.ToString() },
                                                     (Ns, Sr) => new { Ns, Sr }).ToList()
                                  .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(),
                                                     Ns => new { StudyId = Ns.Ns.StudyId.ToString() },
                                                     Mrc => new { StudyId = Mrc.StudyId.ToString() },
                                                     (Ns, Mrc) => new { Ns, Ns.Sr, Mrc }).ToList()
                                  .GroupJoin(dbContextNavigate.GMRCApprovalTask.AsEnumerable(),
                                                      Ns => new { StudyId = Ns.Ns.Ns.StudyId.ToString() },
                                                      Gmrc => new { StudyId = Gmrc.StudyId.ToString() },
                                                      (Ns, Gmrc) => new { Ns, Ns.Sr, Ns.Mrc, Gmrc }).ToList()
                                 .Where(w => w.Ns.Ns.Ns.IsActive == true && w.Ns.Ns.Ns.IsDeleted == false)
                                 .OrderByDescending(x => x.Ns.Ns.Ns.StudyId)
                                                      .Select(x => new Data.NewStudy
                                                      {
                                                          StudyId = x.Ns.Ns.Ns.StudyId,
                                                          StudyType = x.Ns.Ns.Ns.StudyType,
                                                          TitleofTrial = x.Ns.Ns.Ns.TitleofTrial ?? null,
                                                          ANJU_AddedBy = x.Ns.Ns.Ns.ANJU_AddedBy,
                                                          ANJU_AddDate = x.Ns.Ns.Ns.ANJU_AddDate,
                                                          TaskStatus = x.Ns.Ns.Ns.TaskStatus,
                                                          TaskName = x.Ns.Ns.Ns.TaskName,
                                                          Stage = x.Ns.Ns.Ns.Stage,
                                                          State = x.Ns.Ns.Ns.State,
                                                          Institution = x.Sr?.Select(c => c?.Institution).FirstOrDefault() ?? null,
                                                          //StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ":" + x.Ns.Ns.Ns.TitleofTrial : x.Ns.Ns.Ns.StudyId + ":" + x.Ns.Ns.Ns.TitleofTrial,
                                                          StudyName = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() + ": " + x.Ns.Ns.Ns.TitleofTrial : x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() != null ? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() + ": " + x.Ns.Ns.Ns.TitleofTrial : x.Ns.Ns.Ns.StudyId + ": " + x.Ns.Ns.Ns.TitleofTrial,
                                                          StudyNumber = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.StudyNumber).FirstOrDefault() ?? x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r?.Macsnumber).FirstOrDefault() ?? null,
                                                          LocalMRCDecision = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.LocalMRC).Select(r => r.LocalMrcdecision).FirstOrDefault() ?? null,
                                                          GlobalMRCDecision = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC).Select(r => r.GlobalMrcdecision).FirstOrDefault() ?? null,
                                                          LocalMRCRecordType = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.LocalMRC && y.LocalMrcdecision == "Tabled").Select(r => r.RecordType).FirstOrDefault() ?? null,
                                                          GlobalMRCRecordType = x.Mrc?.Where(y => y?.RecordType == Utilities.Messages.GlobalMRC && y.GlobalMrcdecision == "Tabled").Select(r => r.RecordType).FirstOrDefault() ?? null,
                                                          Franchise = x.Sr?.Select(c => c?.Franchise).FirstOrDefault() ?? null,
                                                          GMRCTaskCompleted = x.Gmrc?.Where(y => y?.TaskName == Utilities.Messages.SAEFINALRECONCILIATIONREPORTCONFIRMATION  ).Select(r => r.IsTaskCompleted).FirstOrDefault() ?? null,
                                                          GMRCGearTaskCompleted = x.Gmrc?.Where(y => y?.TaskName == Utilities.Messages.SAEFINALRECONCILIATIONREPORTCONFIRMATION).Select(r => r.IsGearTaskCompleted).FirstOrDefault() ?? null,
                                                          GMRCTaskName = x.Gmrc?.Where(y => y?.TaskName == Utilities.Messages.SAEFINALRECONCILIATIONREPORTCONFIRMATION).Select(r => r.TaskName).FirstOrDefault() ?? null,
                                                          NoOfGearTask = dbContextNavigate.GMRCApprovalTask.Where(y => y.IsGearTaskCompleted == false && y.StudyId == x.Ns.Ns.Ns.StudyId && y.AssignedTo == userName).Select(y => y.TaskName).ToList().Count(),
                                                          IsallTaskCompleted = dbContextNavigate.GMRCApprovalTask.Where(y => y.IsTaskCompleted == false && y.StudyId == x.Ns.Ns.Ns.StudyId && y.AssignedTo == userName).Select(y => y.TaskName).ToList().Count(),
                                                          EnableCloseStudy = dbContextNavigate.GMRCApprovalTask.Where(y => y.IsTaskCompleted == false && y.StudyId == x.Ns.Ns.Ns.StudyId && y.AssignedTo == userName && y.TaskName == Utilities.Messages.CLOSESTUDY && y.IsGearTaskCompleted == false).Select(y => y.TaskName).ToList().Count(),
                                                          IsIconVisible = dbContextNavigate.GMRCApprovalTask.Where(y => y.IsGearTaskCompleted == true && y.StudyId == x.Ns.Ns.Ns.StudyId && y.AssignedTo == userName).Select(y => y.TaskName).ToList().Count(),
                                                          //ANJU_ChangeDate = dbContextNavigate.NewStudy.Where(y => x.Ns.StudyId == y.StudyId && y.ANJU_AddedBy == userName && y.IsActive == true &&
                                                          //y.IsDeleted == false && y.TaskStatus == Utilities.Messages.PENDINGMANUALMSLANDPLASSIGNMENT).Select(m => m.ANJU_ChangeDate).FirstOrDefault()
                                                      }).ToList();
                return lstStudyDetails;
            }

            return newStudies;

        }

        /// <summary>
        /// Get TaskDetails by UserName
        /// </summary>       
        /// <returns>lstStudyDetails</returns>
        public List<Data.DefaultMileStone> GetDefaultMilestoneDetails()

        {
            List<Data.DefaultMileStone> result = new List<Data.DefaultMileStone>();

           result = dbContextNavigate.DefaultMileStone.AsEnumerable().Where(x=>x.IsActive == true && x.IsDeleted == false) 
                                                     .Select(x => new Data.DefaultMileStone
                                                     {
                                                         DefaultMilestoneId = x.DefaultMilestoneId,
                                                         MilestoneName =x.MilestoneName,
                                                         MilestoneType = x.MilestoneType,
                                                         BusinessDays = x.BusinessDays,
                                                         Dependency = x.Dependency,
                                                         StudyPhase = x.StudyPhase,
                                                         Comments = x.Comments
                                                     }).ToList();
            return result;


        }
        

        /// <summary>
        /// Get the Email list
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.EmailList> GetEmailList(int studyId)
        {
            var lstStudyIdForPI = dbContextNavigate.EmailList.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false)
                                                        .Select(x => new Data.EmailList
                                                        {
                                                            Id = x.Id,
                                                            StudyId = x.StudyId,
                                                            Email = x.Email
                                                        }).ToList();
            return lstStudyIdForPI;
        }

        /// <summary>
        /// Get the BannerDetails
        /// </summary>        
        /// <returns>List</returns>
        public List<Data.Documents> GetBannerDetails()
        {
            var lstBannerDocuments = dbContextNavigate.Documents.Where(x => x.SubModuleName == "BannerUpload" && x.IsActive == true && x.IsDeleted == false)
                                                        .Select(x => new Data.Documents
                                                        {
                                                            DocumentName = x.DocumentName,
                                                            Path = x.Path
                                                        }).ToList();
            return lstBannerDocuments;
        }
        /// <summary>
        /// Get the BannerDetails
        /// </summary>        
        /// <returns>List</returns>
        public List<Data.Documents> GetLoginBckgndDetails()
        {
            var lstBackgroundDocuments = dbContextNavigate.Documents.Where(x => x.SubModuleName == "BackgroundUpload" && x.IsActive == true && x.IsDeleted == false)
                                                        .Select(x => new Data.Documents
                                                        {
                                                            DocumentName = x.DocumentName,
                                                            Path = x.Path
                                                        }).ToList();
            return lstBackgroundDocuments;
        }

        /// <summary>
        /// Get the Document list
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentList(int studyId)
        {
            var lstStudyDocuments = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false)
                                                        .GroupJoin(dbContextNavigate.SysCodeValues.AsEnumerable(),
                                                       D => new { DocumentType = D.DocumentType.ToString() },
                                                       Sy => new { DocumentType = Sy.Code.ToString() },
                                                       (D, Sy) => new { D, Sy }).ToList()
                                                        .Select(x => new Data.Documents
                                                        {
                                                            DocumentId = x.D.DocumentId,
                                                            DocumentName = x.D.DocumentName,
                                                            DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                                            DocumentStatus = x.D.DocumentStatus,
                                                            DocumentType = x.D.DocumentType,
                                                            DocumentSubType = x.D.DocumentSubType,
                                                            DocumentVersion = x.D.DocumentVersion,
                                                            SubModuleName = x.D.SubModuleName,
                                                            DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault(),
                                                            StudyId = x.D.StudyId,
                                                            OriginalDate = x.D.OriginalDate,
                                                            ExpirationDate = x.D.ExpirationDate,
                                                            Path = x.D.Path

                                                        }).ToList();
            return lstStudyDocuments;
        }

        /// <summary>
        /// Get the Document list
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="UserName"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetPIDocumentList(int studyId, string UserName)
        {
            var lstStudyDocuments = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false && x.ANJU_AddedBy == UserName)
                                                        .GroupJoin(dbContextNavigate.SysCodeValues.AsEnumerable(),
                                                       D => new { DocumentType = D.DocumentType.ToString() },
                                                       Sy => new { DocumentType = Sy.Code.ToString() },
                                                       (D, Sy) => new { D, Sy }).ToList()
                                                        .Select(x => new Data.Documents
                                                        {
                                                            DocumentId = x.D.DocumentId,
                                                            DocumentName = x.D.DocumentName,
                                                            DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                                            DocumentExtension = x.D.DocumentExtension,
                                                            DocumentStatus = x.D.DocumentStatus,
                                                            DocumentType = x.D.DocumentType,
                                                            DocumentSubType = x.D.DocumentSubType,
                                                            DocumentVersion = x.D.DocumentVersion,
                                                            SubModuleName = x.D.SubModuleName,
                                                            DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault(),
                                                            StudyId = x.D.StudyId,
                                                            OriginalDate = x.D.OriginalDate,
                                                            ExpirationDate = x.D.ExpirationDate,
                                                            Path = x.D.Path

                                                        }).ToList();
            return lstStudyDocuments;
        }


        /// <summary>
        /// Get Investigator Qualifications Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetInvestigatorQualificationsData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                .Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false)
                .Select(x => new Data.NewStudy
                {
                    MedicalSpecialty = x.MedicalSpecialty?.Trim() ?? null,
                    BoardCertification = x.BoardCertification?.Trim() ?? null,
                    MedicalLicense = x.MedicalLicense?.Trim() ?? null,
                    IsOtherTrainingsReceived = x.IsOtherTrainingsReceived ?? null,
                    LastTrainingDetails = x.LastTrainingDetails?.Trim() ?? null,
                    TypeOfTraining = x.TypeOfTraining?.Trim() ?? null,
                    TrialExperiences = x.TrialExperiences?.Trim() ?? null,
                    IsCompanySponsoredtrial = x.IsCompanySponsoredtrial ?? null,
                    TrialParticipation = x.TrialParticipation?.Trim() ?? null,
                    DrugName = x.DrugName?.Trim() ?? null,
                    ProtocolNumber = x.ProtocolNumber?.Trim() ?? null,
                    NumberOfOngoingTrials = x.NumberOfOngoingTrials?.Trim() ?? null,
                    IsSiteInspectedByHealthAuthority = x.IsSiteInspectedByHealthAuthority ?? null,
                    NameOfHealthAuthority = x.NameOfHealthAuthority?.Trim() ?? null,
                    DateOflastInspection = x.DateOflastInspection ?? null,
                    IsSiteInspectedByFda = x.IsSiteInspectedByFda ?? null,
                    DateOfFdainspection = x.DateOfFdainspection ?? null,
                    Isfda483formIssued = x.Isfda483formIssued ?? null,
                    DetailsOfObservation = x.DetailsOfObservation?.Trim() ?? null,
                }).ToList();

                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get Science Main Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetScienceMainData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.TrialPhase.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                   .GroupJoin(dbContextNavigate.ConceptDesignandRationale.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                   (p, cdr) => new { p.Ns, p.Tp, cdr }).ToList()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                   (p, iis) => new { p.Ns, p.Tp, p.cdr, iis }).ToList()
                                   .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       StudyType = x.Ns.StudyType,
                                       TitleofTrial = x.Ns.TitleofTrial,
                                       Studydescriptors = x.iis?.Select(c => c.Studydescriptors).FirstOrDefault() ?? null,
                                       TrialPhaseId = x.Tp.Select(c => (int)c.TrialPhaseId).FirstOrDefault(),
                                       PhaseI = x.Tp?.Select(c => (bool)c?.PhaseI).FirstOrDefault(),
                                       PhaseII = x.Tp?.Select(c => (bool)c?.PhaseII).FirstOrDefault(),
                                       PhaseIII = x.Tp?.Select(c => (bool)c?.PhaseIII).FirstOrDefault(),
                                       PhaseIV = x.Tp?.Select(c => (bool)c?.PhaseIV).FirstOrDefault(),
                                       ConceptDesignandRationaleId = x.cdr.Select(c => (int)c.ConceptDesignandRationaleId).FirstOrDefault(),
                                       Indicationforsciencemain = x.iis?.Select(c => c.Indicationforsciencemain).FirstOrDefault() ?? null,
                                       Rationaleforstudy = x.iis?.Select(c => c.Rationaleforstudy).FirstOrDefault() ?? null,
                                       InvestigationalDrugandReferenceTherapy = x.iis?.Select(c => c.InvestigationalDrugandReferenceTherapy).FirstOrDefault() ?? null,
                                       IsPlacebocontrolled = x.iis.Select(c => c.IsPlacebocontrolled).FirstOrDefault() ?? null,
                                       RationaleforTrial = x.cdr?.Select(c => c.RationaleforTrial).FirstOrDefault() ?? null,
                                       Studydesign = x.iis?.Select(c => c.Studydesign).FirstOrDefault() ?? null,
                                       Gender = x.cdr?.Select(c => c.Gender).FirstOrDefault() ?? null,
                                       PatientType = x.iis.Select(c => c.PatientType).FirstOrDefault() ?? null,
                                       MinimumAge = x.cdr?.Select(c => c.MinimumAge).FirstOrDefault() ?? null,
                                       MaximumAge = x.cdr?.Select(c => c.MaximumAge).FirstOrDefault() ?? null,
                                       Treatmentarms = x.Ns.Treatmentarms,
                                       ClinicalPharmacology = x.Ns?.ClinicalPharmacology ?? null,
                                       PatientPopulation = x.cdr?.Select(c => c.PatientPopulation).FirstOrDefault() ?? null,
                                       KeyInclusionCriteria = x.cdr?.Select(c => c.KeyInclusionCriteria).FirstOrDefault() ?? null,
                                       KeyExclusionCriteria = x.cdr.Select(c => c.KeyExclusionCriteria).FirstOrDefault() ?? null,
                                       Safetycriteria = x.iis.Select(c => c.Safetycriteria).FirstOrDefault() ?? null,
                                       Basisforsamplesize = x.iis?.Select(c => c.Basisforsamplesize).FirstOrDefault() ?? null,
                                       Othercompanycompound = x.iis.Select(c => c.Othercompanycompound).FirstOrDefault() ?? null,
                                   }).ToList();

                return searchResult;
            }
            return lstNewProposalData;
        }



        /// <summary>
        /// Get Diseases Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetDiseasesData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.TrialPhase.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                   .GroupJoin(dbContextNavigate.ConceptDesignandRationale.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                   (p, cdr) => new { p.Ns, p.Tp, cdr }).ToList()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                   (p, iis) => new { p.Ns, p.Tp, p.cdr, iis }).ToList()
                                   .GroupJoin(dbContextNavigate.StudyReview.AsEnumerable(), p => p.Ns.StudyId, stdrev => stdrev.StudyId,
                                   (p, stdrev) => new { p.Ns, p.Tp, p.cdr, p.iis, stdrev }).ToList()
                                   .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       Franchise = x.stdrev?.Select(c => c.Franchise).FirstOrDefault() ?? null,
                                       Binding = x.cdr?.Select(c => c.Binding).FirstOrDefault() ?? null,
                                       GenomicProfile = x.iis?.Select(c => c.GenomicProfile).FirstOrDefault() ?? null,
                                       Lineoftherapy = x.iis?.Select(c => c.Lineoftherapy).FirstOrDefault() ?? null,
                                       Disease = x.iis?.Select(c => c.Disease).FirstOrDefault() ?? null,
                                       Structure = x.cdr?.Select(c => c.Structure).FirstOrDefault() ?? null,
                                       Diseasepaatientpopulation = x.iis?.Select(c => c.Diseasepaatientpopulation).FirstOrDefault() ?? null,
                                       DiseaseStage = x.iis?.Select(c => c.DiseaseStage).FirstOrDefault() ?? null,
                                       TreatmentSegment = x.iis?.Select(c => c.TreatmentSegment).FirstOrDefault() ?? null,
                                       Qualityoflife = x.iis?.Select(c => c.Qualityoflife).FirstOrDefault() ?? null,
                                       Riskfactors = x.iis?.Select(c => c.Riskfactors).FirstOrDefault() ?? null,
                                       LineofTreatment = x.iis?.Select(c => c.LineofTreatment).FirstOrDefault() ?? null,
                                       Randomized = x.cdr?.Select(c => c.Randomized).FirstOrDefault() ?? null,
                                       PatientPopulation = x.cdr?.Select(c => c.PatientPopulation).FirstOrDefault() ?? null,

                                   }).ToList();

                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get Correlative Sciences Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetCorrelativeSciencesData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.CorrelativeScienceStudies.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                    .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        CorrelativeScienceStudiesId = x.Tp.Select(c => c.CorrelativeScienceStudiesId).FirstOrDefault(),
                                        IsincludeCorrelativeScience = x.Tp?.Select(c => c.IsincludeCorrelativeScience).FirstOrDefault() ?? null,
                                        BiomarkerStudiesperformedatStudySite = x.Tp?.Select(c => c.BiomarkerStudiesperformedatStudySite).FirstOrDefault() ?? null,
                                        BiomarkerStudiesperformedatCompanySite = x.Tp?.Select(c => c.BiomarkerStudiesperformedatCompanySite).FirstOrDefault() ?? null,
                                        BiomarkerSamplingDetails = x.Tp?.Select(c => c.BiomarkerSamplingDetails).FirstOrDefault() ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get Pharmacovigilance Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetPharmacovigilanceData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.CorrelativeScienceStudies.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                     .GroupJoin(dbContextNavigate.PharmacovigilanceRequirements.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                     (p, cdr) => new { p.Ns, p.Tp, cdr }).ToList()
                                     .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                     (p, iis) => new { p.Ns, p.Tp, p.cdr, iis }).ToList()
                                    .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        IsAllnonseriousAes = x.cdr?.Select(c => c.IsAllnonseriousAes).FirstOrDefault() ?? null,
                                        IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = x.cdr?.Select(c => c.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios).FirstOrDefault() ?? null,
                                        Safetydata = x.cdr?.Select(c => c.Safetydata).FirstOrDefault() ?? null,
                                        AdverseEventsExemptfromCollection = x.cdr?.Select(c => c.AdverseEventsExemptfromCollection).FirstOrDefault() ?? null,
                                        Enrollmentrate = x.iis?.Select(c => c.Enrollmentrate).FirstOrDefault() ?? null,
                                        Interventionaltrialdatacollection = x.iis?.Select(c => c.Interventionaltrialdatacollection).FirstOrDefault() ?? null,
                                        NonInterventionaltrialdatacollection = x.iis?.Select(c => c.NonInterventionaltrialdatacollection).FirstOrDefault() ?? null,

                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get Study Enrollment and Timelines Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetStudyEnrollmentandTimelinesData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.CorrelativeScienceStudies.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                    .GroupJoin(dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.AsEnumerable(), t => t.Ns.StudyId, dc => dc.StudyId,
                                     (t, dc) => new { t.Ns, t.Tp, dc }).ToList()
                                     .GroupJoin(dbContextNavigate.PharmacovigilanceRequirements.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                     (p, cdr) => new { p.Ns, p.Tp, p.dc, cdr }).ToList()
                                     .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                     (p, iis) => new { p.Ns, p.Tp, p.dc, p.cdr, iis }).ToList()
                                     .GroupJoin(dbContextNavigate.PLStudyReview.AsEnumerable(), p => p.Ns.StudyId, pls => pls.StudyId,
                                     (p, pls) => new { p.Ns, p.Tp, p.dc, p.cdr, p.iis, pls })
                                    .Where(w => w.Ns.StudyId == StudyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        TrialStart = x.dc?.Select(c => c.TrialStart).FirstOrDefault() ?? null,
                                        RecruitmentEnd = x.dc?.Select(c => c.RecruitmentEnd).FirstOrDefault() ?? null,
                                        TrialEnd = x.dc?.Select(c => c.TrialEnd).FirstOrDefault() ?? null,
                                        CompletionofTrialReport = x.dc?.Select(c => c.CompletionofTrialReport).FirstOrDefault() ?? null,
                                        PrimaryPublicationDate = x.dc?.Select(c => c.PrimaryPublicationDate).FirstOrDefault() ?? null,
                                        TotalPlannedNumberofPatients = x.dc?.Select(c => c.TotalPlannedNumberofPatients).FirstOrDefault() ?? null,
                                        PlannedNumberofCenters = x.dc?.Select(c => c.PlannedNumberofCenters).FirstOrDefault() ?? null,
                                        EnrollmentHistoryforOtherRelatedStudies = x.Ns.EnrollmentHistoryforOtherRelatedStudies ?? null,
                                        IsCompetingStudies = x.Ns.IsCompetingStudies ?? null,
                                        CompetingStudies = x.Ns.CompetingStudies ?? null,
                                        Studyduration = x.iis?.Select(c => c.Studyduration).FirstOrDefault() ?? null,
                                        Enrollmentrate = x.iis?.Select(c => c.Enrollmentrate).FirstOrDefault() ?? null,
                                        Noofpatientspertreatmentgroup = x.iis?.Select(c => c.Noofpatientspertreatmentgroup).FirstOrDefault() ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }



        /// <summary>
        /// Get IRB Requirement Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetIRBRequirementData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                    .Where(w => w.StudyId == StudyId && w.IsActive == true && w.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        IsIrbregistrationRequirement = x.IsIrbregistrationRequirement ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get key references Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetkeyreferencesData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                    .Where(w => w.StudyId == StudyId && w.IsActive == true && w.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        KeyReferences = x.KeyReferences ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get original financial request Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetoriginalfinancialrequestData(int studyId)
        {
            List<Data.NewStudy> lstData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Iis => new { StudyId = Iis.StudyId.ToString() },
                                   (Ns, Iis) => new { Ns, Iis }).ToList()
                                    .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        IsRequestedForFinancialSupport = x.Ns.IsRequestedForFinancialSupport,
                                        IsSupportProvidedByOtherSources = x?.Ns?.IsSupportProvidedByOtherSources,
                                        IsGovernmentSupportProvided = x.Ns.IsGovernmentSupportProvided ?? null,
                                        BudgetRequestedForTrial = x.Ns.BudgetRequestedForTrial ?? null,
                                        SupportDescription = x.Ns.SupportDescription ?? null,
                                        SupportSources = x.Ns.SupportSources ?? null,
                                        Isrequestingacompanystudycompound = x.Iis?.Select(c => c.Isrequestingacompanystudycompound).FirstOrDefault() ?? null,
                                        Othersupportdescription = x.Iis?.Select(c => c.Othersupportdescription).FirstOrDefault() ?? null,
                                        Isrequestingsupportfromcompanyotherthandrugorfunding = x.Iis?.Select(c => c.Isrequestingsupportfromcompanyotherthandrugorfunding).FirstOrDefault() ?? null,
                                        Globalfundingrequested = x.Iis?.Select(c => c.Globalfundingrequested).FirstOrDefault() ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstData;
        }



        /// <summary>
        /// Get Pandemic preparedness trial categorization Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetPandemicpreparednesstrialcategorizationData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.PLStudyReview.AsEnumerable()
                                   .Where(w => w.StudyId == StudyId && w.IsActive == true && w.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       TrialCategorization = x?.TrialCategorization ?? null,
                                       MonitoringInterval = x?.MonitoringInterval ?? null,
                                       MaximumAllowableVists = x?.MaximumAllowableVists ?? null,
                                   }
                                )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }


        /// <summary>
        /// Get Regulatory requirements Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetRegulatoryrequirementsData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Tp => new { StudyId = Tp.StudyId.ToString() },
                                   (Ns, Tp) => new { Ns, Tp }).ToList()
                                    .Where(w => w.Ns.StudyId == StudyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        IsIndsubmission = x.Ns.IsIndsubmission ?? null,
                                        RationaleforINDExemption = x.Ns.RationaleforINDExemption ?? null,
                                        FinalINDStatus = x.Tp?.Select(c => c.FinalINDStatus).FirstOrDefault() ?? null,
                                        INDNumber = x.Tp?.Select(c => c.INDNumber).FirstOrDefault() ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }



        /// <summary>
        /// Get Research Group Description Data
        /// </summary>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetResearchGroupDescriptionData(int StudyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (StudyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                   .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(),
                                   Ns => new { StudyId = Ns.StudyId.ToString() },
                                   Iis => new { StudyId = Iis.StudyId.ToString() },
                                   (Ns, Iis) => new { Ns, Iis }).ToList()
                                    .Where(w => w.Ns.StudyId == StudyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                    .Select(x => new Data.NewStudy
                                    {
                                        StudySponsor = x.Iis?.Select(c => c.StudySponsor).FirstOrDefault() ?? null,
                                        StudyDrugSource = x.Iis?.Select(c => c.StudyDrugSource).FirstOrDefault() ?? null,
                                        OtherCooperativeGroup = x.Iis?.Select(c => c.OtherCooperativeGroup).FirstOrDefault() ?? null,
                                        IsCooperativeGroupStudy = x.Ns.IsCooperativeGroupStudy ?? null,
                                        CooperativeGroupName = x.Ns.CooperativeGroupName ?? null,
                                        IsPhysicianNetworkStudy = x.Ns.IsPhysicianNetworkStudy ?? null,
                                        PhysicianNetworkName = x.Ns.PhysicianNetworkName ?? null,
                                    }
                                   )
                                   .ToList();
                return searchResult;
            }
            return lstNewProposalData;
        }




        /// <summary>
        /// This method is used to Create,Update and Delete EmailList
        /// </summary>
        /// <param name="email"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public Data.EmailList CreateUpdateAndDeleteEmailList(Data.EmailList email, string mode, int studyId, string userName)
        {

            if (mode == "Create")
            {
                DataAccess.EmailList objEmailList = new DataAccess.EmailList()
                {
                    StudyId = studyId,
                    Email = email.Email.Trim(),
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow

                };              
                dbContextNavigate.SaveChanges(objEmailList, new EmailList_H(), userName, eAuditChangeType.Insert);
                email.Id = objEmailList.Id;
                return email;
            }
            else if (mode == "Update")
            {
                DataAccess.EmailList objEmailList = new DataAccess.EmailList()
                {
                    Id = email.Id,
                    StudyId = studyId,
                    Email = email.Email.Trim(),
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow

                };                
                dbContextNavigate.SaveChanges(objEmailList, new EmailList_H(), userName, eAuditChangeType.Update);
                email.Id = objEmailList.Id;
                return email;

            }

            else
            {
                DataAccess.EmailList objEmailList = new DataAccess.EmailList()
                {
                    Id = email.Id,
                    StudyId = studyId,
                    Email = email.Email.Trim(),
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow

                };               
                dbContextNavigate.SaveChanges(objEmailList, new EmailList_H(), userName, eAuditChangeType.Delete);
                email.Id = objEmailList.Id;
                return email;
            }
        }
        /// <summary>
        /// Create and Update Personal and Research details
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="NewStudy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// 
        public bool CreateUpdatePersonalResearchdetails(int studyId, List<Data.PrincipalInvestigator> lsprincipalInvestigator, Data.NewStudy NewStudy, string mode, string userName)
        {
            int retVal = default(int);

            var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId).Include(p => p.PrincipalInvestigator).SingleOrDefault();
            if (result != null)
            {
                result.MedicalSpecialty = NewStudy.MedicalSpecialty?.Trim();
                result.BoardCertification = NewStudy.BoardCertification?.Trim();
                result.MedicalLicense = NewStudy.MedicalLicense?.Trim();
                result.IsCompanySponsoredtrial = NewStudy.IsCompanySponsoredtrial;
                result.DrugName = NewStudy.DrugName?.Trim();
                result.ProtocolNumber = NewStudy.ProtocolNumber?.Trim();
                result.TrialParticipation = NewStudy.TrialParticipation?.Trim();
                result.IsOtherTrainingsReceived = NewStudy.IsOtherTrainingsReceived;
                result.LastTrainingDetails = NewStudy.LastTrainingDetails?.Trim();
                result.TypeOfTraining = NewStudy.TypeOfTraining?.Trim();
                result.TrialExperiences = NewStudy.TrialExperiences?.Trim();
                result.NumberOfOngoingTrials = NewStudy.NumberOfOngoingTrials?.Trim();
                result.IsSiteInspectedByHealthAuthority = NewStudy.IsSiteInspectedByHealthAuthority;
                result.NameOfHealthAuthority = NewStudy.NameOfHealthAuthority?.Trim();
                result.DateOflastInspection = NewStudy.DateOflastInspection.HasValue ? NewStudy.DateOflastInspection : null;
                result.IsSiteInspectedByFda = NewStudy.IsSiteInspectedByFda;
                result.DateOfFdainspection = NewStudy.DateOfFdainspection.HasValue ? NewStudy.DateOfFdainspection : null;
                result.Isfda483formIssued = NewStudy.Isfda483formIssued;
                result.DetailsOfObservation = NewStudy.DetailsOfObservation?.Trim();
                result.IsCooperativeGroupStudy = NewStudy.IsCooperativeGroupStudy;
                result.CooperativeGroupName = NewStudy.CooperativeGroupName?.Trim();
                result.IsPhysicianNetworkStudy = NewStudy.IsPhysicianNetworkStudy;
                result.PhysicianNetworkName = NewStudy.PhysicianNetworkName?.Trim();
                result.IsGovernmentSupportProvided = NewStudy.IsGovernmentSupportProvided;
                result.SupportDescription = NewStudy.SupportDescription?.Trim();
                result.IsSupportProvidedByOtherSources = NewStudy.IsSupportProvidedByOtherSources;
                result.SupportSources = NewStudy.SupportSources?.Trim();
                result.ANJU_ChangedBy = userName;
                result.ANJU_ChangeDate = DateTime.UtcNow;



                if (result.PrincipalInvestigator.Count > 0)
                {
                    foreach (Data.PrincipalInvestigator items in lsprincipalInvestigator)
                    {
                        var information = result.PrincipalInvestigator.Where(x => x.CategoryID == items.CategoryID).SingleOrDefault();
                        if (information != null)
                        {
                            information.CategoryID = items.CategoryID;
                            information.Salutation = items.Salutation?.Trim();
                            information.FirstName = items.FirstName?.Trim();
                            information.LastName = items.LastName?.Trim();
                            information.Suffix = items.Suffix?.Trim();
                            information.Title = items.Title?.Trim();
                            information.Degree = items.Degree?.Trim();
                            information.Npinumber = items.Npinumber?.Trim();
                            information.Institution = items.Institution?.Trim();
                            information.CountryId = items.CountryId;
                            information.StateId = items.StateId;
                            information.CityId = items.CityId;
                            information.Address1 = items.Address1?.Trim();
                            information.Address2 = items.Address2?.Trim();
                            information.Phone = items.Phone?.Trim();
                            information.Fax = items.Fax?.Trim();
                            information.PrimaryEmailId = items.PrimaryEmailId?.Trim();
                            information.PostalCode = items.PostalCode?.Trim();
                            information.TaxID = items.TaxID?.Trim();
                            information.IsActive = true;
                            information.IsDeleted = false;
                            information.ANJU_ChangedBy = userName;
                            information.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(information, new PrincipalInvestigator_H(), userName, eAuditChangeType.Update);
                            if (retVal < 1)
                                return false;
                        }
                        else
                        {
                            DataAccess.PrincipalInvestigator objPrincipalInvestigator = new DataAccess.PrincipalInvestigator()
                            {
                                StudyId= studyId,
                                CategoryID = items.CategoryID,
                                Salutation = items.Salutation?.Trim(),
                                FirstName = items.FirstName?.Trim(),
                                LastName = items.LastName?.Trim(),
                                Suffix = items.Suffix?.Trim(),
                                Title = items.Title?.Trim(),
                                Degree = items.Degree?.Trim(),
                                Npinumber = items.Npinumber?.Trim(),
                                Institution = items.Institution?.Trim(),
                                CountryId = items.CountryId,
                                StateId = items.StateId,
                                CityId = items.CityId,
                                Address1 = items.Address1?.Trim(),
                                Address2 = items.Address2?.Trim(),
                                Phone = items.Phone?.Trim(),
                                Fax = items.Fax?.Trim(),
                                PrimaryEmailId = items.PrimaryEmailId?.Trim(),
                                PostalCode = items.PostalCode?.Trim(),
                                TaxID = items.TaxID?.Trim(),
                                IsActive =true,
                                IsDeleted = false,
                                ANJU_AddedBy = userName,
                                ANJU_AddDate = DateTime.UtcNow
                            };
                            retVal = dbContextNavigate.SaveChanges(objPrincipalInvestigator, new PrincipalInvestigator_H(), userName, eAuditChangeType.Insert);
                            if (retVal < 1)
                                return false;
                        }
                    }

                }
                else
                {
                    Data.PrincipalInvestigator principalInvestigator = lsprincipalInvestigator.FirstOrDefault();
                    DataAccess.PrincipalInvestigator objPrincipalInvestigator = new DataAccess.PrincipalInvestigator()
                    {
                        StudyId= studyId,
                        CategoryID = principalInvestigator.CategoryID,
                        Salutation = principalInvestigator.Salutation?.Trim(),
                        FirstName = principalInvestigator.FirstName?.Trim(),
                        LastName = principalInvestigator.LastName?.Trim(),
                        Suffix = principalInvestigator.Suffix?.Trim(),
                        Title = principalInvestigator.Title?.Trim(),
                        Degree = principalInvestigator.Degree?.Trim(),
                        Npinumber = principalInvestigator.Npinumber?.Trim(),
                        Institution = principalInvestigator.Institution?.Trim(),
                        CountryId = principalInvestigator.CountryId,
                        StateId = principalInvestigator.StateId,
                        CityId = principalInvestigator.CityId,
                        Address1 = principalInvestigator.Address1?.Trim(),
                        Address2 = principalInvestigator.Address2?.Trim(),
                        Phone = principalInvestigator.Phone?.Trim(),
                        Fax = principalInvestigator.Fax?.Trim(),
                        PrimaryEmailId = principalInvestigator.PrimaryEmailId?.Trim(),
                        PostalCode = principalInvestigator.PostalCode?.Trim(),
                        TaxID = principalInvestigator.TaxID?.Trim(),
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };                    
                    retVal = dbContextNavigate.SaveChanges(objPrincipalInvestigator, new PrincipalInvestigator_H(), userName, eAuditChangeType.Insert);
                    if (retVal < 1)
                        return false;
                }
                retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                {

                    Data.Documents documents = new Data.Documents()
                    {
                        SubModuleId = retVal,
                        ANJU_AddedBy = userName,
                        StudyId = studyId
                    };
                    UpdatePrincipalInvestigatorDocumentDetails(documents);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// create Document
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool createDocument(Data.Documents documents)
        {
            bool result = true;
            List<string> lstdocuments = new List<string>();
            lstdocuments.Add(Utilities.Messages.GMRCMACDDOCUMENT);
            lstdocuments.Add(Messages.LMRCFINALWITHDRAWALDDOCUMENT);
            lstdocuments.Add(Messages.GMRCAPPROVALFINALDOCUMENT);
            lstdocuments.Add(Messages.EXECUTEDCONTRACTDOCUMENT);
            lstdocuments.Add(Messages.STUDYACTIVATIONDOCUMENT);
            lstdocuments.Add(Utilities.Messages.FINALSTUDYREPORT);

            DataAccess.Documents objDocuments = new DataAccess.Documents()
            {
                DocumentName = documents.DocumentName,
                DocumentSize = documents.DocumentSize,
                DocumentExtension = documents.DocumentExtension,
                DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension,
                SubModuleName = documents.SubModuleName,
                StudyId = documents.StudyId,
                Path = documents.Path,
                DocumentStatus = documents.DocumentStatus,
                DocumentType = documents.DocumentType,
                DocumentSubType = documents.DocumentSubType,
                DocumentVersion = documents.DocumentVersion,
                OriginalDate = documents.OriginalDate,
                ExpirationDate = documents.ExpirationDate,
                IsActivated = documents.IsActivated,
                IsSubmit = documents.IsSubmit,
                IsActive = documents.IsActive,
                IsDeleted = documents.IsDeleted,
                ANJU_AddedBy = documents.ANJU_AddedBy,
                ANJU_AddDate = DateTime.UtcNow

            };

            var docresult = dbContextNavigate.Documents.Where(x => lstdocuments.Contains(x.SubModuleName) && x.StudyId == documents.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (docresult?.DocumentId > 0)
            {
                result = DeleteUploadedFile(docresult.StudyId, documents.ANJU_AddedBy, docresult.SubModuleName, docresult.DocumentName);
            }
            if (result)
            {                
                dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
                documents.DocumentId = objDocuments.DocumentId;
                if (documents.DocumentId > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }



        /// <summary>
        /// Create 'Manual' Type Documents
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool CreateManualTypeDocuments(Data.Documents documents)
        {           
            DataAccess.Documents objDocuments = new DataAccess.Documents()
            {
                DocumentName = documents.DocumentName,
                DocumentSize = documents.DocumentSize,
                DocumentExtension = documents.DocumentExtension,
                DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension,
                SubModuleName = documents.SubModuleName,
                StudyId = documents.StudyId,
                Path = documents.Path,
                DocumentStatus = documents.DocumentStatus,
                DocumentType = documents.DocumentType,
                DocumentSubType = documents.DocumentSubType,
                DocumentVersion = documents.DocumentVersion,
                OriginalDate = documents.OriginalDate,
                ExpirationDate = documents.ExpirationDate,
                IsActivated = documents.IsActivated,
                IsSubmit = documents.IsSubmit,
                IsActive = documents.IsActive,
                IsDeleted = documents.IsDeleted,
                ANJU_AddedBy = documents.ANJU_AddedBy,
                ANJU_AddDate = DateTime.UtcNow

            };
           
            dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
            documents.DocumentId = objDocuments.DocumentId;
            if (documents.DocumentId > 0)
                return true;
            else
                return false;            
        }

        /// <summary>
        /// Create/Update Manual Type Documents
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>retVal</returns>
        public bool CreateUpdateManualTypeDocuments(Data.Documents documents)
        {
            int retVal = default(int);
            var objDocs = dbContextNavigate.Documents.Where(x => x.StudyId == documents.StudyId && x.DocumentId == documents.DocumentId).SingleOrDefault();
            if (objDocs != null)
            {                
                objDocs.DocumentName = documents.DocumentName;
                objDocs.DocumentSize = documents.DocumentSize;
                objDocs.DocumentExtension = documents.DocumentExtension;
                objDocs.DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension;
                objDocs.SubModuleName = documents.SubModuleName;
                objDocs.StudyId = documents.StudyId;
                objDocs.Path = documents.Path;
                objDocs.DocumentStatus = documents.DocumentStatus;
                objDocs.DocumentType = documents.DocumentType;
                objDocs.DocumentSubType = documents.DocumentSubType;
                objDocs.DocumentVersion = documents.DocumentVersion;
                objDocs.OriginalDate = documents.OriginalDate;
                objDocs.ExpirationDate = documents.ExpirationDate;
                objDocs.IsActivated = documents.IsActivated;
                objDocs.IsSubmit = documents.IsSubmit;
                objDocs.IsActive = documents.IsActive;
                objDocs.IsDeleted = documents.IsDeleted;
                objDocs.ANJU_AddedBy = documents.ANJU_AddedBy;
                objDocs.ANJU_AddDate = DateTime.UtcNow;

                retVal = dbContextNavigate.SaveChanges(objDocs, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.Documents objDocuments = new DataAccess.Documents()
                {
                    DocumentName = documents.DocumentName,
                    DocumentSize = documents.DocumentSize,
                    DocumentExtension = documents.DocumentExtension,
                    DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension,
                    SubModuleName = documents.SubModuleName,
                    StudyId = documents.StudyId,
                    Path = documents.Path,
                    DocumentStatus = documents.DocumentStatus,
                    DocumentType = documents.DocumentType,
                    DocumentSubType = documents.DocumentSubType,
                    DocumentVersion = documents.DocumentVersion,
                    OriginalDate = documents.OriginalDate,
                    ExpirationDate = documents.ExpirationDate,
                    IsActivated = documents.IsActivated,
                    IsSubmit = documents.IsSubmit,
                    IsActive = documents.IsActive,
                    IsDeleted = documents.IsDeleted,
                    ANJU_AddedBy = documents.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow

                };
                retVal = dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
            }
           
            if (retVal > 0)
                return true;
            else
                return false;            
        }

        /// <summary>
        /// Delete  UploadedFile
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteUploadedFile(int studyId, string userName, string subModuleName, string documentName)
        {
            if (studyId > 0)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == studyId && x.SubModuleName == subModuleName && x.DocumentName == documentName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    int val = dbContextNavigate.SaveChanges(result, new Documents_H(), userName, eAuditChangeType.Delete);
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else if (!string.IsNullOrEmpty(subModuleName))
            {
                var result = dbContextNavigate.Documents.Where(x => x.SubModuleName == subModuleName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    using (var db = new Navigate30Context())
                    {
                        db.Documents
                         .Where(x => x.SubModuleName == subModuleName && x.IsActive == true && x.IsDeleted == false).ToList()
                         .ForEach(x => { x.ANJU_ChangedBy = userName; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = true; x.IsActive = false; });

                        int val = db.SaveChanges();
                        if (val > 0)
                            return true;
                        else
                            return false;
                    }
                }
                else
                    return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Delete Documents
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public bool DeleteDocuments(Data.Documents documents)
        {
            if (documents.DocumentId > 0)
            {
                var result = dbContextNavigate.Documents.Where(x => x.DocumentId == documents.DocumentId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = documents.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    int val = dbContextNavigate.SaveChanges(result, new Documents_H(), documents.ANJU_ChangedBy, eAuditChangeType.Delete);
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else if (!string.IsNullOrEmpty(documents.SubModuleName) && documents.StudyId > 0)
            {
                using (var db = new Navigate30Context())
                {
                    db.Documents
                      .Where(x => x.StudyId == documents.StudyId && x.SubModuleName == documents.SubModuleName && x.IsActive == true && x.IsDeleted == false).ToList()
                      .ForEach(x => { x.ANJU_ChangedBy = documents.ANJU_ChangedBy; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = true; x.IsActive = false; });

                    int val = db.SaveChanges();
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }


        /// <summary>
        /// Undelete Documents
        /// </summary>
        /// <param name="docid"></param>
        /// <param name="studyid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UndeleteDocuments(int docid, int studyid,string username)
        {
            if (docid > 0)
            {
                var result = dbContextNavigate.Documents.Where(x =>x.StudyId == studyid && x.DocumentId == docid && x.IsActive == false && x.IsDeleted == true).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = true;
                    result.IsDeleted = false;
                    result.ANJU_ChangedBy = username;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    int val = dbContextNavigate.SaveChanges(result, new Documents_H(), username, eAuditChangeType.Delete);
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }            
            else
                return false;
        }





        /// <summary>
        /// Verify wheather document name is unique or not
        /// </summary>
        /// <param name="documentsName"></param>
        /// <param name="studyId"></param>
        /// <returns>true/false</returns>
        public bool IsDocumentNameIsUnique(string documentsName, int studyId,string moduleName)
        {
            if (!string.IsNullOrEmpty(documentsName) && studyId > 0 && moduleName != Messages.IDENTIFYACTIVATIONDOCUMENTS)
            {
                var result = dbContextNavigate.Documents.Where(x => x.DocumentName == documentsName && x.IsActive == true && x.IsDeleted == false && x.StudyId == studyId).FirstOrDefault();
                if (result != null)                               
                     return false;
                else
                    return true;
            }
            else if(moduleName == Messages.IDENTIFYACTIVATIONDOCUMENTS && !string.IsNullOrEmpty(documentsName) && studyId > 0 )
            {
                var result = dbContextNavigate.Documents.Where(x => x.DocumentName == documentsName && x.IsActive == true && x.IsDeleted == false && x.StudyId == studyId && x.SubModuleName == "IdentifyActivationDocuments").ToList().Count();
                if(result > 1 )
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Get PrincipalInvestigator Documents By StudyID
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="subModuleName"></param>
        /// <returns>List of documents</returns>
        public List<Data.Documents> GetDocumentsByStudyID(int studyId, string subModuleName)
        {
            var result = new List<Data.Documents>();
            if (studyId > 0)
            {

                if (subModuleName == null)
                {
                    result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId)
                                  .GroupJoin(dbContextNavigate.SysCodeValues,
                                                            D => new { DocumentType = D.DocumentType?.ToString() },
                                                            Sy => new { DocumentType = Sy.Code?.ToString() },
                                                            (D, Sy) => new { D, Sy }).ToList()
                                 .Select(x => new Data.Documents
                                 {
                                     DocumentId = x.D.DocumentId,
                                     DocumentName = x.D.DocumentName,
                                     DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                     StudyId = x.D.StudyId,
                                     SubModuleId = x.D.SubModuleId,
                                     SubModuleName = x.D.SubModuleName,
                                     DocumentSize = x.D.DocumentSize,
                                     DocumentExtension = x.D.DocumentExtension,
                                     Path = x.D.Path,
                                     DocumentStatus = x.D.DocumentStatus,
                                     DocumentType = x.D.DocumentType,
                                     DocumentSubType = x.D.DocumentSubType,
                                     IsActive = x.D.IsActive,
                                     IsDeleted = x.D.IsDeleted,
                                     ANJU_AddedBy = x.D.ANJU_AddedBy,
                                     Anju_AddedDate = x.D.ANJU_AddDate,
                                     DocumentVersion = x.D.DocumentVersion,
                                     OriginalDate = x.D.OriginalDate,
                                     ExpirationDate = x.D.ExpirationDate,
                                     DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                                 }).ToList();

                    return result;
                }
                else
                {
                    result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.SubModuleName == subModuleName && x.IsActive == true && x.IsDeleted == false)
                                  .GroupJoin(dbContextNavigate.SysCodeValues,
                                                            D => new { DocumentType = D.DocumentType?.ToString() },
                                                            Sy => new { DocumentType = Sy.Code?.ToString() },
                                                            (D, Sy) => new { D, Sy }).ToList()
                                 .Select(x => new Data.Documents
                                 {
                                     DocumentId = x.D.DocumentId,
                                     DocumentName = x.D.DocumentName,
                                     DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                     StudyId = x.D.StudyId,
                                     SubModuleId = x.D.SubModuleId,
                                     SubModuleName = x.D.SubModuleName,
                                     DocumentSize = x.D.DocumentSize,
                                     DocumentExtension = x.D.DocumentExtension,
                                     Path = x.D.Path,
                                     DocumentStatus = x.D.DocumentStatus,
                                     DocumentType = x.D.DocumentType,
                                     DocumentSubType = x.D.DocumentSubType,
                                     DocumentVersion = x.D.DocumentVersion,
                                     OriginalDate = x.D.OriginalDate,
                                     ExpirationDate = x.D.ExpirationDate,
                                     DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                                 }).ToList();

                    return result;
                }
            }
            else
            {
                if (subModuleName == null)
                {
                    result = dbContextNavigate.Documents.AsEnumerable()
                          .GroupJoin(dbContextNavigate.SysCodeValues,
                                                    D => new { DocumentType = D.DocumentType?.ToString() },
                                                    Sy => new { DocumentType = Sy.Code?.ToString() },
                                                    (D, Sy) => new { D, Sy }).ToList()
                         .Select(x => new Data.Documents
                         {
                             DocumentId = x.D.DocumentId,
                             DocumentName = x.D.DocumentName,
                             DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                             StudyId = x.D.StudyId,
                             SubModuleId = x.D.SubModuleId,
                             SubModuleName = x.D.SubModuleName,
                             DocumentSize = x.D.DocumentSize,
                             DocumentExtension = x.D.DocumentExtension,
                             Path = x.D.Path,
                             DocumentStatus = x.D.DocumentStatus,
                             DocumentType = x.D.DocumentType,
                             DocumentSubType = x.D.DocumentSubType,
                             IsActive = x.D.IsActive,
                             IsDeleted = x.D.IsDeleted,
                             ANJU_AddedBy = x.D.ANJU_AddedBy,
                             Anju_AddedDate = x.D.ANJU_AddDate,
                             DocumentVersion = x.D.DocumentVersion,
                             OriginalDate = x.D.OriginalDate,
                             ExpirationDate = x.D.ExpirationDate,
                             DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                         }).ToList();

                    return result;
                }
                else
                {
                    result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.SubModuleName == subModuleName && x.IsActive == true && x.IsDeleted == false)
                          .GroupJoin(dbContextNavigate.SysCodeValues,
                                                    D => new { DocumentType = D.DocumentType?.ToString() },
                                                    Sy => new { DocumentType = Sy.Code?.ToString() },
                                                    (D, Sy) => new { D, Sy }).ToList()
                         .Select(x => new Data.Documents
                         {
                             DocumentId = x.D.DocumentId,
                             DocumentName = x.D.DocumentName,
                             DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                             StudyId = x.D.StudyId,
                             SubModuleId = x.D.SubModuleId,
                             SubModuleName = x.D.SubModuleName,
                             DocumentSize = x.D.DocumentSize,
                             DocumentExtension = x.D.DocumentExtension,
                             Path = x.D.Path,
                             DocumentStatus = x.D.DocumentStatus,
                             DocumentType = x.D.DocumentType,
                             DocumentSubType = x.D.DocumentSubType,
                             DocumentVersion = x.D.DocumentVersion,
                             OriginalDate = x.D.OriginalDate,
                             ExpirationDate = x.D.ExpirationDate,
                             DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                         }).ToList();
                    if (result != null && result.Count != 0)
                        return result;


                }
            }
            return new List<Data.Documents>();
        }



        /// <summary>
        /// Get Specific Documents By StudyID for a document
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="docid"></param>
        /// <returns>List<Data.Documents></returns>
        public List<Data.Documents> GetSpecificDocumentsByStudyID(int studyId, int docid)
        {
            var result = new List<Data.Documents>();
            if (studyId > 0)
            {
                    result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.DocumentId == docid)
                                  .GroupJoin(dbContextNavigate.SysCodeValues,
                                                            D => new { DocumentType = D.DocumentType?.ToString() },
                                                            Sy => new { DocumentType = Sy.Code?.ToString() },
                                                            (D, Sy) => new { D, Sy }).ToList()
                                 .Select(x => new Data.Documents
                                 {
                                     DocumentId = x.D.DocumentId,
                                     DocumentName = x.D.DocumentName,
                                     DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                     StudyId = x.D.StudyId,
                                     SubModuleId = x.D.SubModuleId,
                                     SubModuleName = x.D.SubModuleName,
                                     DocumentSize = x.D.DocumentSize,
                                     DocumentExtension = x.D.DocumentExtension,
                                     Path = x.D.Path,
                                     DocumentStatus = x.D.DocumentStatus,
                                     DocumentType = x.D.DocumentType,
                                     DocumentSubType = x.D.DocumentSubType,
                                     ANJU_AddedBy = x.D.ANJU_AddedBy,
                                     Anju_AddedDate = x.D.ANJU_AddDate,
                                     DocumentVersion = x.D.DocumentVersion,
                                     OriginalDate = x.D.OriginalDate,
                                     ExpirationDate = x.D.ExpirationDate,
                                     DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                                 }).ToList();

                    return result;          
            }           
            return new List<Data.Documents>();
        }





        /// <summary>
        /// Update PrincipalInvestigator Document Details
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool UpdatePrincipalInvestigatorDocumentDetails(Data.Documents documents)
        {
            if (documents != null)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == documents.StudyId && x.SubModuleName == Utilities.Messages.PersonalandResearchSites && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = true;
                    result.IsDeleted = false;
                    result.SubModuleId = documents.SubModuleId;
                    result.ANJU_ChangedBy = documents.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    int val = dbContextNavigate.SaveChanges(result, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Update);
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }

        /// <summary>
        ///  Get the Requested Support Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>lstNewProposalData</returns>
        public List<Data.NewStudy> GetRequestedSupportDetails(int studyId)
        {

            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Where(w => w.StudyId == studyId && w.IsActive == true && w.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       /*  Requested Support*/
                                       IsRequestedForDrugSupply = x.IsRequestedForDrugSupply ?? null,
                                       IsRequestedForFinancialSupport = x.IsRequestedForFinancialSupport ?? null,
                                       BudgetRequestedForTrial = x.BudgetRequestedForTrial ?? 0


                                   }).ToList();

                return searchResult;

            }
            return lstNewProposalData;
        }

        /// <summary>
        /// Create and Update Requested Support Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="newStudy"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateRequestedSupportDetails(int studyId, Data.NewStudy newStudy, string userName, Data.Documents objDocument)
        {
            var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (result != null)
            {
                result.IsRequestedForDrugSupply = newStudy.IsRequestedForDrugSupply;
                result.IsRequestedForFinancialSupport = newStudy.IsRequestedForFinancialSupport;
                result.BudgetRequestedForTrial = newStudy.BudgetRequestedForTrial;
                result.ANJU_ChangedBy = userName;
                result.ANJU_ChangeDate = DateTime.UtcNow;
                int val = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                if (val > 0)
                {
                    if (newStudy.TaskName == Utilities.ConstDefaultValue.RESUBMITPROTOCOL)
                    {

                        var Protocolresult = dbContextNavigate.Documents.Where(x => x.StudyId == newStudy.StudyId && x.SubModuleName == Utilities.Messages.REDLINEDREVIEWPROTOCOLDOCUMENT && x.IsSubmit == null
                                                             && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (Protocolresult != null)
                        {
                            Protocolresult.IsActive = false;
                            Protocolresult.IsDeleted = true;
                            Protocolresult.IsSubmit = null;
                            Protocolresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                            Protocolresult.ANJU_ChangeDate = DateTime.UtcNow;                           
                            val = dbContextNavigate.SaveChanges(Protocolresult, new Documents_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Delete);
                        }
                        if (val > 0)
                        {
                            var ReUploadProtocolresult = dbContextNavigate.Documents.Where(x => x.StudyId == newStudy.StudyId && x.SubModuleName == Utilities.Messages.RequestedSupportProtocolDocuments && x.DocumentName == objDocument.DocumentName && x.IsSubmit == true
                                                           ).FirstOrDefault();
                            if (ReUploadProtocolresult != null)
                            {
                                ReUploadProtocolresult.IsActive = objDocument.IsActive;
                                ReUploadProtocolresult.IsDeleted = objDocument.IsDeleted;
                                ReUploadProtocolresult.IsSubmit = null;
                                ReUploadProtocolresult.ANJU_ChangedBy = objDocument.ANJU_ChangedBy;
                                ReUploadProtocolresult.ANJU_ChangeDate = DateTime.UtcNow;                                
                                val = dbContextNavigate.SaveChanges(ReUploadProtocolresult, new Documents_H(), objDocument.ANJU_ChangedBy, eAuditChangeType.Delete);
                            }
                        }
                        else
                            return false;
                    }
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
       
        /// <summary>
        /// Delete Study table and dependent tables
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="username"></param>
        public void DeleteStudy(int studyId, string username)
        {
            var objCohortLevels = dbContextNavigate.CohortLevels.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objCohortLevels != null)
            {
                objCohortLevels.IsActive = false;
                objCohortLevels.IsDeleted = true;
                objCohortLevels.ANJU_ChangedBy = username;
                objCohortLevels.ANJU_ChangeDate = DateTime.UtcNow;
                dbContextNavigate.SaveChanges(objCohortLevels, new CohortLevels_H(), username, eAuditChangeType.Delete);
            }

            var objObjectivesandEndpoints = dbContextNavigate.ObjectivesandEndpoints.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objObjectivesandEndpoints != null)
            {
                objObjectivesandEndpoints.IsActive = false;
                objObjectivesandEndpoints.IsDeleted = true;
                objObjectivesandEndpoints.ANJU_ChangedBy = username;
                objObjectivesandEndpoints.ANJU_ChangeDate = DateTime.UtcNow;               
                dbContextNavigate.SaveChanges(objObjectivesandEndpoints, new ObjectivesandEndpoints_H(), username, eAuditChangeType.Delete);
            }

            var objTreatmentInformation = dbContextNavigate.TreatmentInformation.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objTreatmentInformation != null)
            {
                objTreatmentInformation.IsActive = false;
                objTreatmentInformation.IsDeleted = true;
                objTreatmentInformation.ANJU_ChangedBy = username;
                objTreatmentInformation.ANJU_ChangeDate = DateTime.UtcNow;
                dbContextNavigate.SaveChanges(objTreatmentInformation, new TreatmentInformation_H(), username, eAuditChangeType.Delete);//NKG to verify
            }

            var objCenter = dbContextNavigate.Center.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objCenter != null)
            {
                objCenter.IsActive = false;
                objCenter.IsDeleted = true;
                objCenter.ANJU_ChangedBy = username;
                objCenter.ANJU_ChangeDate = DateTime.UtcNow;           
                dbContextNavigate.SaveChanges(objCenter, new Center_H(), username, eAuditChangeType.Delete);
            }

            var objEmailList = dbContextNavigate.EmailList.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objEmailList != null)
            {
                objEmailList.IsActive = false;
                objEmailList.IsDeleted = true;
                objEmailList.ANJU_ChangedBy = username;
                objEmailList.ANJU_ChangeDate = DateTime.UtcNow;               
                dbContextNavigate.SaveChanges(objEmailList, new EmailList_H(), username, eAuditChangeType.Delete);
            }

            var objDocuments = dbContextNavigate.Documents.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objDocuments != null)
            {
                objDocuments.IsActive = false;
                objDocuments.IsDeleted = true;
                objDocuments.ANJU_ChangedBy = username;
                objDocuments.ANJU_ChangeDate = DateTime.UtcNow;               
                dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), username, eAuditChangeType.Delete);
            }

            var objNewStudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId).FirstOrDefault();
            if (objNewStudy != null)
            {
                objNewStudy.IsActive = false;
                objNewStudy.IsDeleted = true;
                objNewStudy.ANJU_ChangedBy = username;
                objNewStudy.ANJU_ChangeDate = DateTime.UtcNow;
                dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), username, eAuditChangeType.Delete);

            }
        }


        /// <summary>
        /// Delete Contacts
        /// </summary>
        /// <param name="principalInvestigator"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteContacts(Data.PrincipalInvestigator principalInvestigator, string userName)
        {
            int retVal = default(int);
            if (principalInvestigator != null)
            {
                var result = dbContextNavigate.PrincipalInvestigator.Where(x => x.PrincipalInvestigatorId == principalInvestigator.PrincipalInvestigatorId
                                                                        && x.StudyId == principalInvestigator.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new PrincipalInvestigator_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }



        /// <summary>
        ///  Update Confirmation Details
        /// </summary>        
        /// <param name="NewStudy"></param>
        /// <returns>true/false</returns>
        public bool UpdateConfirmationDetails(Data.NewStudy newStudy)
        {
            var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).FirstOrDefault();
            if (newStudy.PITaskStatus?.ToUpper() == ConstDefaultValue.SUBMITPROTOCOL.ToUpper())
            {
                if (result != null)
                {
                    result.Stage = newStudy.Stage ?? result.Stage;
                    result.State = newStudy.State ?? result.State;
                    result.TaskStatus = newStudy.TaskStatus ?? result.TaskStatus;
                    result.PITaskStatus = "";
                    result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    int val = dbContextNavigate.SaveChanges(result, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (val > 0)
                    {
                        StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                        bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(result.StudyId, "Draft Protocol", DateTime.UtcNow, result.ANJU_ChangedBy);
                        if (taskcompletion) {
                            var resultGMRCApproval = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == newStudy.StudyId && x.TaskName == newStudy.TaskName
                                                          && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (resultGMRCApproval != null)
                            {
                                resultGMRCApproval.IsTaskCompleted = true;
                                resultGMRCApproval.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                resultGMRCApproval.ANJU_ChangeDate = DateTime.UtcNow;
                                val = dbContextNavigate.SaveChanges(resultGMRCApproval, new GMRCApprovalTask_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                            }
                            if (val > 0)
                            {
                                var IsReviewProtocolExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == newStudy.StudyId && x.TaskName == Utilities.Messages.REVIEWPROTOCOL
                                                                    && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                if (IsReviewProtocolExists == null)
                                {
                                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                        .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                        (pl, u) => new { pl, u })
                                                        .Where(x => x.pl.StudyId == newStudy.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                        .Select(x => x.u.UserName).FirstOrDefault();
                                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = newStudy.StudyId,
                                        TaskName = Utilities.Messages.REVIEWPROTOCOL,
                                        IsTaskCompleted = false,
                                        AssignedTo = TlUserName,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = newStudy.ANJU_ChangedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };
                                    val = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Insert);
                                }
                                else
                                {
                                    IsReviewProtocolExists.IsTaskCompleted = false;
                                    IsReviewProtocolExists.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                    IsReviewProtocolExists.ANJU_ChangeDate = DateTime.UtcNow;
                                    val = dbContextNavigate.SaveChanges(IsReviewProtocolExists, new GMRCApprovalTask_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }

                    }
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
            }
            else if (newStudy.TaskName?.ToUpper() == ConstDefaultValue.RESUBMITPROTOCOL.ToUpper())
            {
                if (result != null)
                {
                    result.Stage = newStudy.Stage ?? result.Stage;
                    result.State = newStudy.State ?? result.State;
                    result.TaskStatus = newStudy.TaskStatus ?? result.TaskStatus;
                    result.PITaskStatus = "";
                    result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    int val = dbContextNavigate.SaveChanges(result, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (val > 0)
                    {
                        if (newStudy.TaskName == Utilities.ConstDefaultValue.RESUBMITPROTOCOL)
                        {                            
                            var resultGMRCApproval = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == newStudy.StudyId && x.TaskName == newStudy.TaskName
                                                                && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (resultGMRCApproval != null)
                            {
                                resultGMRCApproval.IsTaskCompleted = true;
                                resultGMRCApproval.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                resultGMRCApproval.ANJU_ChangeDate = DateTime.UtcNow;                               
                                val = dbContextNavigate.SaveChanges(resultGMRCApproval, new GMRCApprovalTask_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                                if (val > 0)
                                {
                                    var Reviewresult = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == newStudy.StudyId && x.TaskName == Utilities.Messages.REVIEWPROTOCOL).FirstOrDefault();
                                    if (Reviewresult != null)
                                    {
                                        Reviewresult.IsTaskCompleted = false;                                        
                                        val = dbContextNavigate.SaveChanges(Reviewresult, new GMRCApprovalTask_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);

                                    }
                                }
                            }
                        }
                        if (val > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            else
            {
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(result.PITaskStatus))
                    {
                        if (result.PITaskStatus == Utilities.Messages.NEWSUBMISSION)
                        {
                            result.State = Utilities.Messages.CONCEPTSUBMITTED;
                            result.TaskName = Utilities.Messages.ASSIGNMSLANDPL;
                            result.TaskStatus = Utilities.Messages.PENDINGMANUALMSLANDPLASSIGNMENT;
                            result.Stage = newStudy.Stage;
                            result.PITaskStatus = "";
                        }
                        else
                        {
                            result.Stage = newStudy.Stage ?? result.Stage;
                            result.State = newStudy.State ?? result.State;
                            result.TaskName = newStudy.TaskName ?? result.TaskName;
                            result.TaskStatus = newStudy.TaskStatus ?? result.TaskStatus;
                            result.PITaskStatus = newStudy.PITaskStatus ?? result.PITaskStatus;
                        }
                    }
                    else
                    {
                        result.Stage = newStudy.Stage ?? result.Stage;
                        result.State = newStudy.State ?? result.State;
                        result.TaskName = newStudy.TaskName ?? result.TaskName;
                        result.TaskStatus = newStudy.TaskStatus ?? result.TaskStatus;
                        result.PITaskStatus = newStudy.PITaskStatus ?? result.PITaskStatus;
                    }
                    result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    int val = dbContextNavigate.SaveChanges(result, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (val > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Get PIInstitute By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>InstituteName</returns>
        public string GetPIInstituteByStudyID(int studyId)
        {

            if (studyId > 0)
            {
                var PiInstitute = dbContextNavigate.PrincipalInvestigator.Where(x => x.StudyId == studyId).FirstOrDefault();
                return PiInstitute.Institution;
            }
            return string.Empty;
        }

        /// <summary>
        /// Get Institute By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>InstituteName</returns>
        public string GetMSLChangedInstituteBystudyId(int studyId)
        {
            if (studyId > 0)
            {
                var MSLInstitute = dbContextNavigate.StudyReview.Where(x => x.StudyId == studyId).FirstOrDefault();
                return MSLInstitute.Institution;
            }
            return string.Empty;
        }


        /// <summary>
        ///  Get username By studyId and usertype
        /// </summary>
        /// <param name="studyId"></param>       
        /// <param name="userType"></param>       
        /// <returns>InstituteName</returns>
        public string GetUserNameByUserTypeAndStudyId(int studyId,string userType)
        {
            if (!(string.IsNullOrEmpty(userType)) && studyId > 0)
            {
                if(userType == Messages.MSL)
                {
                    var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                  .Join(dbContextNavigate.StudyTask, Ns => Ns.StudyId, St => St.StudyId,
                                  (Ns, St) => new { Ns, St }).ToList()
                                  .Join(dbContextNavigate.Users, t => t.St.MsluserId, u => u.UserId,
                                  (t, u) => new { t, u }).ToList()
                                  .Where(w => w.t.Ns.StudyId == studyId && w.t.Ns.IsActive == true && w.t.Ns.IsDeleted == false).Select(x => x.u.UserName).FirstOrDefault();

                    return searchResult;

                }
                else if(userType == Messages.PROGRAMLEADER)
                {
                    var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                  .Join(dbContextNavigate.StudyTask, Ns => Ns.StudyId, St => St.StudyId,
                                  (Ns, St) => new { Ns, St }).ToList()
                                  .Join(dbContextNavigate.Users, t => t.St.PluserId, u => u.UserId,
                                  (t, u) => new { t, u }).ToList()
                                  .Where(w => w.t.Ns.StudyId == studyId && w.t.Ns.IsActive == true && w.t.Ns.IsDeleted == false).Select(x => x.u.UserName).FirstOrDefault();

                    return searchResult;

                }
                else if(userType == Messages.TRIALLEADER)
                {
                    var searchResult = dbContextNavigate.PLStudyReview.AsEnumerable()
                                      .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                      (pl, u) => new { pl, u })
                                      .Where(x => x.pl.StudyId == studyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                      .Select(x => x.u.UserName).FirstOrDefault();
                    return searchResult;
                }
                
            }
            return string.Empty;
        }


        /// <summary>
        /// Get Other Attributes Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetOtherAttributesData(int studyId)
        {
            List<Data.NewStudy> lstNewProposalData = new List<Data.NewStudy>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                  .GroupJoin(dbContextNavigate.GMRCApprovalTask.AsEnumerable(),
                                  Ns => new { StudyId = Ns.StudyId.ToString() },
                                  Tp => new { StudyId = Tp.StudyId.ToString() },
                                  (Ns, Tp) => new { Ns, Tp }).ToList()
                                  .GroupJoin(dbContextNavigate.MRCStudyReview.AsEnumerable(), p => p.Ns.StudyId, cdr => cdr.StudyId,
                                  (p, cdr) => new { p.Ns, p.Tp, cdr }).ToList()
                                  .GroupJoin(dbContextNavigate.IISAdmindetails.AsEnumerable(), p => p.Ns.StudyId, iis => iis.StudyId,
                                  (p, iis) => new { p.Ns, p.Tp, p.cdr, iis }).ToList()
                                  .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                  .Select(x => new Data.NewStudy
                                  {
                                      Isamendmentrequestincludesachangeintheprimaryinvestigator = x.iis?.Select(c => c.Isamendmentrequestincludesachangeintheprimaryinvestigator).FirstOrDefault() ?? null,
                                      Isautoproxyenabled = x.iis?.Select(c => c.Isautoproxyenabled).FirstOrDefault() ?? null,
                                      Leadorganization = x.iis?.Select(c => c.Leadorganization).FirstOrDefault() ?? null,
                                      Isconditionalapproval = x.iis?.Select(c => c.Isconditionalapproval).FirstOrDefault() ?? null,
                                      Conditionsofapproval = x.iis?.Select(c => c.Conditionsofapproval).FirstOrDefault() ?? null,
                                      ICFReview = x.iis?.Select(c => c.ICFReview).FirstOrDefault() ?? null,
                                      Amendmentstatus = x.iis?.Select(c => c.Amendmentstatus).FirstOrDefault() ?? null,
                                      Amendmenttype = x.iis?.Select(c => c.Amendmenttype).FirstOrDefault() ?? null,
                                      Contractamendmentrequired = x.iis?.Select(c => c.Contractamendmentrequired).FirstOrDefault() ?? null,
                                      Ipistudyssponsor = x.iis?.Select(c => c.Ipistudyssponsor).FirstOrDefault() ?? null,
                                      Migrationdate = x.iis?.Select(c => c.Migrationdate).FirstOrDefault() ?? null,
                                      Conversionstatus = x.iis?.Select(c => c.Conversionstatus).FirstOrDefault() ?? null,
                                      Milestoneupdatefrequencydays = x.iis?.Select(c => c.Milestoneupdatefrequencydays).FirstOrDefault() ?? null,
                                      Accrualmilestoneupdatefrequencydays = x.iis?.Select(c => c.Accrualmilestoneupdatefrequencydays).FirstOrDefault() ?? null,
                                      Lastsendemail = x.iis?.Select(c => c.Lastsendemail).FirstOrDefault() ?? null,                                       
                                       ExecutionDate = x.Tp.Select(c => c.ExecutionDate).FirstOrDefault() ?? null,
                                       SaereconciliationFrequency = x.cdr.Select(c => c.SaereconciliationFrequency).FirstOrDefault() ?? null,                                       
                                   }).ToList();

                return searchResult;
            }
            return lstNewProposalData;
        }





        /// <summary>
        /// Get PIIndication By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>Indication</returns>
        public string GetPIIndicationByStudyID(int studyId)
        {

            if (studyId > 0)
            {
                var PiIndication = dbContextNavigate.ConceptDesignandRationale.Where(x => x.StudyId == studyId).FirstOrDefault();
                return PiIndication.Indication;
            }
            return string.Empty;
        }

        /// <summary>
        /// Get PITitleOfTrial By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>Indication</returns>
        public string GetPITitleOfTrialByStudyID(int studyId)
        {

            if (studyId > 0)
            {
                var PiTitleOfTrial = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyId).FirstOrDefault();
                return PiTitleOfTrial.TitleofTrial;
            }
            return string.Empty;
        }

        /// <summary>
        /// Create/Update Science Main details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateScienceMaindetails(Data.NewStudy newStudy, string usertype,string userName)
        {
            int retVal = default(int);
            var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
            var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
            var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

            if (newStudy != null)
            {
                var newstudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newstudyresult != null)
                {
                    bool istitleoftrialrestricted = false;
                    bool isclinicalpharmacologyrestricted = false;
                    bool isstudytyperestricted = false;
                    bool istreatmentarmsrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.TITLE:
                                newstudyresult.TitleofTrial = newStudy.TitleofTrial ?? newstudyresult.TitleofTrial;
                                istitleoftrialrestricted = true;
                                break;
                            case ConstDefaultValue.CLINICALPHARMACOLOGY:
                                newstudyresult.ClinicalPharmacology = newStudy.ClinicalPharmacology ?? newstudyresult.ClinicalPharmacology;
                                isclinicalpharmacologyrestricted = true;
                                break;
                            case ConstDefaultValue.STUDYTYPEINTERVENTIONAL:
                                newstudyresult.StudyType = newStudy.StudyType ?? newstudyresult.StudyType;
                                isstudytyperestricted = true;
                                break;
                            case ConstDefaultValue.TREATMENTARM:
                                newstudyresult.Treatmentarms = newStudy.Treatmentarms ?? newstudyresult.Treatmentarms;
                                istreatmentarmsrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (istitleoftrialrestricted == false)
                        newstudyresult.TitleofTrial = newStudy.TitleofTrial;
                    if (isclinicalpharmacologyrestricted == false)
                        newstudyresult.ClinicalPharmacology = newStudy.ClinicalPharmacology;
                    if (isstudytyperestricted == false)
                        newstudyresult.StudyType = newStudy.StudyType;
                    if (istreatmentarmsrestricted == false)
                        newstudyresult.Treatmentarms = newStudy.Treatmentarms;
                    newstudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(newstudyresult, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
            {
                var newconceptresult = dbContextNavigate.ConceptDesignandRationale.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newconceptresult != null)
                {
                    bool ismaximumagerestricted = false;
                    bool iskeyexclusioncriteriarestricted = false;
                    bool ispatientpopulationrestricted = false;
                    bool isindicationrestricted = false;
                    bool isgenderrestricted = false;
                    bool isminimumagerestricted = false;
                    bool iskeyinclusioncriteriarestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.MAXIMUMAGE:
                                newconceptresult.MaximumAge = newStudy.MaximumAge ?? newconceptresult.MaximumAge;
                                ismaximumagerestricted = true;
                                break;
                            case ConstDefaultValue.EXCLUSIONCRITERIA:
                                newconceptresult.KeyExclusionCriteria = newStudy.KeyExclusionCriteria ?? newconceptresult.KeyExclusionCriteria;
                                iskeyexclusioncriteriarestricted = true;
                                break;
                            case ConstDefaultValue.INDICATION:
                                newconceptresult.Indication = newStudy.Indication ?? newconceptresult.Indication;
                                isindicationrestricted = true;
                                break;
                            case ConstDefaultValue.PATIENTPOPULATION:
                                newconceptresult.PatientPopulation = newStudy.PatientPopulation ?? newconceptresult.PatientPopulation;
                                ispatientpopulationrestricted = true;
                                break;
                            case ConstDefaultValue.GENDER:
                                newconceptresult.Gender = newStudy.Gender ?? newconceptresult.Gender;
                                isgenderrestricted = true;
                                break;
                            case ConstDefaultValue.MINIMUMAGE:
                                newconceptresult.MinimumAge = newStudy.MinimumAge ?? newconceptresult.MinimumAge;
                                isminimumagerestricted = true;
                                break;
                            case ConstDefaultValue.INCLUSIONCRITERIA:
                                newconceptresult.KeyInclusionCriteria = newStudy.KeyInclusionCriteria ?? newconceptresult.KeyInclusionCriteria;
                                iskeyinclusioncriteriarestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (ismaximumagerestricted == false)
                        newconceptresult.MaximumAge = newStudy.MaximumAge;
                    if (iskeyexclusioncriteriarestricted == false)
                        newconceptresult.KeyExclusionCriteria = newStudy.KeyExclusionCriteria;
                    if (isindicationrestricted == false)
                        newconceptresult.Indication = newStudy.Indication;
                    if (ispatientpopulationrestricted == false)
                        newconceptresult.PatientPopulation = newStudy.PatientPopulation;
                    if (isgenderrestricted == false)
                        newconceptresult.Gender = newStudy.Gender;
                    if (isminimumagerestricted == false)
                        newconceptresult.MinimumAge = newStudy.MinimumAge;
                    if (iskeyinclusioncriteriarestricted == false)
                        newconceptresult.KeyInclusionCriteria = newStudy.KeyInclusionCriteria;                   
                    retVal = dbContextNavigate.SaveChanges(newconceptresult, new ConceptDesignandRationale_H(), userName, eAuditChangeType.Update);
                }
            }

            if (retVal > 0)
            {
                var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisadminresult == null)
                {
                    DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                    {
                        StudyId = newStudy.StudyId,
                        InvestigationalDrugandReferenceTherapy = newStudy.InvestigationalDrugandReferenceTherapy?.Trim(),
                        Studydescriptors = newStudy.Studydescriptors?.Trim(),
                        PatientType = newStudy.PatientType?.Trim(),
                        Safetycriteria = newStudy.Safetycriteria?.Trim(),
                        Othercompanycompound = newStudy.Othercompanycompound,
                        IsPlacebocontrolled = newStudy.IsPlacebocontrolled,
                        Studydesign = newStudy.Studydesign?.Trim(),
                        Rationaleforstudy = newStudy.Rationaleforstudy?.Trim(),
                        Basisforsamplesize = newStudy.Basisforsamplesize?.Trim(),
                        ANJU_ChangedBy = newStudy.ANJU_AddedBy,
                        ANJU_ChangeDate = DateTime.UtcNow
                    };                   
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
                else
                {
                    bool isinvestigationaldrugandreferencetherapyrestricted = false;
                    bool isstudydescriptorsrestricted = false;
                    bool ispatienttypesrestricted = false;
                    bool issafetycriteriarestricted = false;
                    bool isothercompanycompoundrestricted = false;
                    bool isplacebocontrolledrestricted = false;
                    bool isstudydesignrestricted = false;
                    bool isrationaleforstudyrestricted = false;
                    bool isbasisforsamplesizerestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.INVESTIGATIONALDRUGANDREFERENCETHERAPY:
                                iisadminresult.InvestigationalDrugandReferenceTherapy = newStudy.InvestigationalDrugandReferenceTherapy ?? iisadminresult.InvestigationalDrugandReferenceTherapy;
                                isinvestigationaldrugandreferencetherapyrestricted = true;
                                break;
                            case ConstDefaultValue.STUDYDESCRIPTORS:
                                iisadminresult.Studydescriptors = newStudy.Studydescriptors ?? iisadminresult.Studydescriptors;
                                isstudydescriptorsrestricted = true;
                                break;
                            case ConstDefaultValue.PATIENTTYPE:
                                iisadminresult.PatientType = newStudy.PatientType ?? iisadminresult.PatientType;
                                ispatienttypesrestricted = true;
                                break;
                            case ConstDefaultValue.SAFETYCRITERIA:
                                iisadminresult.Safetycriteria = newStudy.Safetycriteria ?? iisadminresult.Safetycriteria;
                                issafetycriteriarestricted = true;
                                break;
                            case ConstDefaultValue.OTHERCOMPOUND:
                                iisadminresult.Othercompanycompound = newStudy.Othercompanycompound ?? iisadminresult.Othercompanycompound;
                                isothercompanycompoundrestricted = true;
                                break;
                            case ConstDefaultValue.PLACEBOCONTROLLED:
                                iisadminresult.IsPlacebocontrolled = newStudy.IsPlacebocontrolled ?? iisadminresult.IsPlacebocontrolled;
                                isplacebocontrolledrestricted = true;
                                break;
                            case ConstDefaultValue.STUDYDESIGN:
                                iisadminresult.Studydesign = newStudy.Studydesign ?? iisadminresult.Studydesign;
                                isstudydesignrestricted = true;
                                break;
                            case ConstDefaultValue.RATIONALEFORSTUDY:
                                iisadminresult.Rationaleforstudy = newStudy.Rationaleforstudy ?? iisadminresult.Rationaleforstudy;
                                isrationaleforstudyrestricted = true;
                                break;
                            case ConstDefaultValue.BASISFORSAMPLESIZE:
                                iisadminresult.Basisforsamplesize = newStudy.Basisforsamplesize ?? iisadminresult.Basisforsamplesize;
                                isbasisforsamplesizerestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isinvestigationaldrugandreferencetherapyrestricted == false)
                        iisadminresult.InvestigationalDrugandReferenceTherapy = newStudy.InvestigationalDrugandReferenceTherapy;
                    if (isstudydescriptorsrestricted == false)
                        iisadminresult.Studydescriptors = newStudy.Studydescriptors;
                    if (ispatienttypesrestricted == false)
                        iisadminresult.PatientType = newStudy.PatientType;
                    if (issafetycriteriarestricted == false)
                        iisadminresult.Safetycriteria = newStudy.Safetycriteria;
                    if (isothercompanycompoundrestricted == false)
                        iisadminresult.Othercompanycompound = newStudy.Othercompanycompound;
                    if (isplacebocontrolledrestricted == false)
                        iisadminresult.IsPlacebocontrolled = newStudy.IsPlacebocontrolled;
                    if (isstudydesignrestricted == false)
                        iisadminresult.Studydesign = newStudy.Studydesign;
                    if (isrationaleforstudyrestricted == false)
                        iisadminresult.Rationaleforstudy = newStudy.Rationaleforstudy;
                    if (isbasisforsamplesizerestricted == false)
                        iisadminresult.Basisforsamplesize = newStudy.Basisforsamplesize;

                    iisadminresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    iisadminresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
            }

            if (retVal > 0)
            {
                var iisphasesresult = dbContextNavigate.TrialPhase.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisphasesresult != null)
                {
                    bool isphaseIrestricted = false;
                    bool isphaseIIrestricted = false;
                    bool isphaseIIIrestricted = false;
                    bool isphaseIVrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.PHASEI:
                                iisphasesresult.PhaseI = newStudy.PhaseI ?? iisphasesresult.PhaseI;
                                isphaseIrestricted = true;
                                break;
                            case ConstDefaultValue.PHASEII:
                                iisphasesresult.PhaseII = newStudy.PhaseII ?? iisphasesresult.PhaseII;
                                isphaseIIrestricted = true;
                                break;
                            case ConstDefaultValue.PHASEIII:
                                iisphasesresult.PhaseIII = newStudy.PhaseIII ?? iisphasesresult.PhaseIII;
                                isphaseIIIrestricted = true;
                                break;
                            case ConstDefaultValue.PHASEIV:
                                iisphasesresult.PhaseIV = newStudy.PhaseIV ?? iisphasesresult.PhaseIV;
                                isphaseIVrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isphaseIrestricted == false)
                        iisphasesresult.PhaseI = newStudy.PhaseI ?? iisphasesresult.PhaseI;
                    if (isphaseIIrestricted == false)
                        iisphasesresult.PhaseII = newStudy.PhaseII ?? iisphasesresult.PhaseII;
                    if (isphaseIIIrestricted == false)
                        iisphasesresult.PhaseIII = newStudy.PhaseIII ?? iisphasesresult.PhaseIII;
                    if (isphaseIVrestricted == false)
                        iisphasesresult.PhaseI = newStudy.PhaseIV ?? iisphasesresult.PhaseIV;
                    
                    retVal = dbContextNavigate.SaveChanges(iisphasesresult, new TrialPhase_H(), userName, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Create/Update Other Attributes details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateOtherAttributesdetails(Data.NewStudy newStudy, string usertype, string userName)
        {
            int retVal = default(int);
            var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
            var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
            var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

            if (newStudy != null)
            {
                var gmrcapprovaltaskresult = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == newStudy.StudyId && x.TaskName == Messages.MANAGECONTRACTSTATUS).SingleOrDefault();
                if (gmrcapprovaltaskresult != null)
                {
                    bool isexecutiondaterestricted = false;


                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.CONTRACTEXECUTIONDATE:
                                gmrcapprovaltaskresult.ExecutionDate = newStudy.ExecutionDate ?? gmrcapprovaltaskresult.ExecutionDate;
                                isexecutiondaterestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isexecutiondaterestricted == false)
                    {
                        gmrcapprovaltaskresult.ExecutionDate = newStudy.ExecutionDate;
                        gmrcapprovaltaskresult.ANJU_ChangedBy= userName;
                        gmrcapprovaltaskresult.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(gmrcapprovaltaskresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    }
                }
              
                var newmrcstudyreviewresult = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newmrcstudyreviewresult != null)
                {
                    bool issaerestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.SAEFREQUENCY:
                                newmrcstudyreviewresult.SaereconciliationFrequency = newStudy.SaereconciliationFrequency ?? newmrcstudyreviewresult.SaereconciliationFrequency;
                                issaerestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (issaerestricted == false)
                    {
                        newmrcstudyreviewresult.SaereconciliationFrequency = newStudy.SaereconciliationFrequency;
                        newmrcstudyreviewresult.ANJU_ChangedBy = userName;
                        newmrcstudyreviewresult.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(newmrcstudyreviewresult, new IISAdmindetails_H(), userName, eAuditChangeType.Update);
                    }
                }
                
                var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisadminresult == null)
                {
                    DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                    {
                        StudyId = newStudy.StudyId,
                        Isamendmentrequestincludesachangeintheprimaryinvestigator = newStudy.Isamendmentrequestincludesachangeintheprimaryinvestigator,
                        Isautoproxyenabled = newStudy.Isautoproxyenabled,
                        Leadorganization = newStudy.Leadorganization?.Trim(),
                        Isconditionalapproval = newStudy.Isconditionalapproval,
                        Conditionsofapproval = newStudy.Conditionsofapproval?.Trim(),
                        ICFReview = newStudy.ICFReview?.Trim(),
                        Amendmentstatus = newStudy.Amendmentstatus?.Trim(),
                        Amendmenttype = newStudy.Amendmenttype?.Trim(),
                        Contractamendmentrequired = newStudy.Contractamendmentrequired?.Trim(),
                        Migrationdate = newStudy.Migrationdate,
                        Conversionstatus = newStudy.Conversionstatus?.Trim(),
                        Milestoneupdatefrequencydays = newStudy.Milestoneupdatefrequencydays,
                        Accrualmilestoneupdatefrequencydays = newStudy.Accrualmilestoneupdatefrequencydays,
                        Lastsendemail = newStudy.Lastsendemail,

                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
                else
                {
                    bool isamendmentrequestincludesachangeintheprimaryinvestigatorrestricted = false;
                    bool isautoproxyenabledrestricted = false;
                    bool isleadorganizationrestricted = false;
                    bool isconditionalapprovalrestricted = false;
                    bool isconditionsofapprovalrestricted = false;
                    bool isICFReviewrestricted = false;
                    bool isamendmentstatusrestricted = false;
                    bool isamendmenttyperestricted = false;
                    bool iscontractamendmentrequiredrestricted = false;
                    bool isipistudyssponsorrestricted = false;
                    bool ismigrationdaterestricted = false;
                    bool isconversionstatusrestricted = false;
                    bool ismilestoneupdatefrequencydaysrestricted = false;
                    bool isaccrualmilestoneupdatefrequencydaysrestricted = false;
                    bool islastsendemailrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.AMENDMENTREQUESTINCLUDESACHANGEINTHEPRIMARYINVESTIGATOR:
                                iisadminresult.Isamendmentrequestincludesachangeintheprimaryinvestigator = newStudy.Isamendmentrequestincludesachangeintheprimaryinvestigator ?? iisadminresult.Isamendmentrequestincludesachangeintheprimaryinvestigator;
                                isamendmentrequestincludesachangeintheprimaryinvestigatorrestricted = true;
                                break;
                            case ConstDefaultValue.AUTOPROXYENABLED:
                                iisadminresult.Isautoproxyenabled = newStudy.Isautoproxyenabled ?? iisadminresult.Isautoproxyenabled;
                                isautoproxyenabledrestricted = true;
                                break;
                            case ConstDefaultValue.LEADORGANIZATION:
                                iisadminresult.Leadorganization = newStudy.Leadorganization ?? iisadminresult.Leadorganization;
                                isleadorganizationrestricted = true;
                                break;
                            case ConstDefaultValue.CONDITIONALAPPROVAL:
                                iisadminresult.Isconditionalapproval = newStudy.Isconditionalapproval ?? iisadminresult.Isconditionalapproval;
                                isconditionalapprovalrestricted = true;
                                break;
                            case ConstDefaultValue.CONDITIONSOFAPPROVAL:
                                iisadminresult.Conditionsofapproval = newStudy.Conditionsofapproval ?? iisadminresult.Conditionsofapproval;
                                isconditionsofapprovalrestricted = true;
                                break;
                            case ConstDefaultValue.ICFREVIEW:
                                iisadminresult.ICFReview = newStudy.ICFReview ?? iisadminresult.ICFReview;
                                isICFReviewrestricted = true;
                                break;
                            case ConstDefaultValue.AMENDMENTSTATUS:
                                iisadminresult.Amendmentstatus = newStudy.Amendmentstatus ?? iisadminresult.Amendmentstatus;
                                isamendmentstatusrestricted = true;
                                break;
                            case ConstDefaultValue.AMENDMENTTYPE:
                                iisadminresult.Amendmenttype = newStudy.Amendmenttype ?? iisadminresult.Amendmenttype;
                                isamendmenttyperestricted = true;
                                break;
                            case ConstDefaultValue.CONTRACTAMENDMENTREQUIRED:
                                iisadminresult.Contractamendmentrequired = newStudy.Contractamendmentrequired ?? iisadminresult.Contractamendmentrequired;
                                iscontractamendmentrequiredrestricted = true;
                                break;
                            case ConstDefaultValue.ISPISTUDYSPONSOR:
                                iisadminresult.Ipistudyssponsor = newStudy.Ipistudyssponsor ?? iisadminresult.Ipistudyssponsor;
                                isipistudyssponsorrestricted = true;
                                break;
                            case ConstDefaultValue.MIGRATIONDATE:
                                iisadminresult.Migrationdate = newStudy.Migrationdate ?? iisadminresult.Migrationdate;
                                ismigrationdaterestricted = true;
                                break;
                            case ConstDefaultValue.CONVERSIONSTATUS:
                                iisadminresult.Conversionstatus = newStudy.Conversionstatus ?? iisadminresult.Conversionstatus;
                                isconversionstatusrestricted = true;
                                break;
                            case ConstDefaultValue.MILESTONEUPDATEFREQUENCYDAYS:
                                iisadminresult.Milestoneupdatefrequencydays = newStudy.Milestoneupdatefrequencydays ?? iisadminresult.Milestoneupdatefrequencydays;
                                ismilestoneupdatefrequencydaysrestricted = true;
                                break;
                            case ConstDefaultValue.ACCRUALMILESTONEUPDATEFREQUENCYDAYS:
                                iisadminresult.Accrualmilestoneupdatefrequencydays = newStudy.Accrualmilestoneupdatefrequencydays ?? iisadminresult.Accrualmilestoneupdatefrequencydays;
                                isaccrualmilestoneupdatefrequencydaysrestricted = true;
                                break;
                            case ConstDefaultValue.LASTSENDEMAIL:
                                iisadminresult.Lastsendemail = newStudy.Lastsendemail ?? iisadminresult.Lastsendemail;
                                islastsendemailrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isamendmentrequestincludesachangeintheprimaryinvestigatorrestricted == false)
                        iisadminresult.Isamendmentrequestincludesachangeintheprimaryinvestigator = newStudy.Isamendmentrequestincludesachangeintheprimaryinvestigator;
                    if (isautoproxyenabledrestricted == false)
                        iisadminresult.Isautoproxyenabled = newStudy.Isautoproxyenabled;
                    if (isleadorganizationrestricted == false)
                        iisadminresult.Leadorganization = newStudy.Leadorganization;
                    if (isconditionalapprovalrestricted == false)
                        iisadminresult.Isconditionalapproval = newStudy.Isconditionalapproval;
                    if (isconditionsofapprovalrestricted == false)
                        iisadminresult.Conditionsofapproval = newStudy.Conditionsofapproval;
                    if (isICFReviewrestricted == false)
                        iisadminresult.ICFReview = newStudy.ICFReview;
                    if (isamendmentstatusrestricted == false)
                        iisadminresult.Amendmentstatus = newStudy.Amendmentstatus;
                    if (isamendmenttyperestricted == false)
                        iisadminresult.Amendmenttype = newStudy.Amendmenttype;
                    if (iscontractamendmentrequiredrestricted == false)
                        iisadminresult.Contractamendmentrequired = newStudy.Contractamendmentrequired;
                    if (isipistudyssponsorrestricted == false)
                        iisadminresult.Ipistudyssponsor = newStudy.Ipistudyssponsor;
                    if (isipistudyssponsorrestricted == false)
                        iisadminresult.Basisforsamplesize = newStudy.Basisforsamplesize;
                    if (ismigrationdaterestricted == false)
                        iisadminresult.Migrationdate = newStudy.Migrationdate;
                    if (isconversionstatusrestricted == false)
                        iisadminresult.Conversionstatus = newStudy.Conversionstatus;
                    if (ismilestoneupdatefrequencydaysrestricted == false)
                        iisadminresult.Milestoneupdatefrequencydays = newStudy.Milestoneupdatefrequencydays;
                    if (isaccrualmilestoneupdatefrequencydaysrestricted == false)
                        iisadminresult.Accrualmilestoneupdatefrequencydays = newStudy.Accrualmilestoneupdatefrequencydays;
                    if (islastsendemailrestricted == false)
                        iisadminresult.Lastsendemail = newStudy.Lastsendemail;

                    iisadminresult.IsActive = true;
                    iisadminresult.IsDeleted = true;

                    iisadminresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    iisadminresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }                
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Create/Update Research Group Description
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateResearchGroupDescription(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isCooperativeGroupStudyrestricted = false;
                bool CooperativeGroupnamerestricted = false;
                bool isPhysicianNetworkStudyrestricted = false;
                bool isPhysicianNetworkNamerestricted = false;
                bool isStudySponsorrestricted = false;
                bool isStudyDrugSourcerestricted = false;
                bool isOtherCooperativeGrouprestricted = false;

                var newstudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newstudyresult != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.ISCOOPERATIVEGROUPSTUDY:
                                newstudyresult.IsCooperativeGroupStudy = newStudy.IsCooperativeGroupStudy ?? newstudyresult.IsCooperativeGroupStudy;
                                isCooperativeGroupStudyrestricted = true;
                                break;
                            case ConstDefaultValue.COOPERATIVEGROUPNAME:
                                newstudyresult.IsCooperativeGroupStudy = newStudy.IsCooperativeGroupStudy ?? newstudyresult.IsCooperativeGroupStudy;
                                CooperativeGroupnamerestricted = true;
                                break;
                            case ConstDefaultValue.ISPHYSICIANNETWORKSTUDY:
                                newstudyresult.IsPhysicianNetworkStudy = newStudy.IsPhysicianNetworkStudy ?? newstudyresult.IsPhysicianNetworkStudy;
                                isPhysicianNetworkStudyrestricted = true;
                                break;
                            case ConstDefaultValue.PHYSICIANNETWORKNAMES:
                                newstudyresult.PhysicianNetworkName = newStudy.PhysicianNetworkName?.Trim() ?? newstudyresult.PhysicianNetworkName.Trim();
                                isPhysicianNetworkNamerestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isCooperativeGroupStudyrestricted == false)
                        newstudyresult.IsCooperativeGroupStudy = newStudy.IsCooperativeGroupStudy;
                    if (CooperativeGroupnamerestricted == false)
                        newstudyresult.CooperativeGroupName = newStudy.CooperativeGroupName.Trim();
                    if (isPhysicianNetworkStudyrestricted == false)
                        newstudyresult.IsCooperativeGroupStudy = newStudy.IsPhysicianNetworkStudy;
                    if (isPhysicianNetworkNamerestricted == false)
                        newstudyresult.PhysicianNetworkName = newStudy.PhysicianNetworkName.Trim();

                    newstudyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    newstudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(newstudyresult, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisadminresult == null)
                {
                    DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                    {
                        StudySponsor = newStudy.StudySponsor,
                        StudyDrugSource = newStudy.StudyDrugSource,
                        OtherCooperativeGroup = newStudy.OtherCooperativeGroup,
                        ANJU_ChangedBy = newStudy.ANJU_AddedBy,
                        ANJU_ChangeDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
                else
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.STUDYSPONSOR:
                                iisadminresult.StudySponsor = newStudy.StudySponsor?.Trim() ?? iisadminresult.StudySponsor.Trim();
                                isStudySponsorrestricted = true;
                                break;
                            case ConstDefaultValue.STUDYDRUGSOURCE:
                                iisadminresult.StudyDrugSource = newStudy.StudyDrugSource?.Trim() ?? iisadminresult.StudyDrugSource.Trim();
                                isStudyDrugSourcerestricted = true;
                                break;
                            case ConstDefaultValue.ISPHYSICIANNETWORKSTUDY:
                                newstudyresult.IsPhysicianNetworkStudy = newStudy.IsPhysicianNetworkStudy ?? newstudyresult.IsPhysicianNetworkStudy;
                                isPhysicianNetworkStudyrestricted = true;
                                break;
                            case ConstDefaultValue.PHYSICIANNETWORKNAMES:
                                newstudyresult.PhysicianNetworkName = newStudy.PhysicianNetworkName?.Trim() ?? newstudyresult.PhysicianNetworkName.Trim();
                                isPhysicianNetworkNamerestricted = true;
                                break;
                            case ConstDefaultValue.COOPERATIVEGROUPNAMEOTHER:
                                iisadminresult.OtherCooperativeGroup = newStudy.OtherCooperativeGroup?.Trim() ?? iisadminresult.OtherCooperativeGroup.Trim();
                                isOtherCooperativeGrouprestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isStudySponsorrestricted == false)
                        iisadminresult.StudySponsor = newStudy.StudySponsor?.Trim();
                    if (isStudyDrugSourcerestricted == false)
                        iisadminresult.StudyDrugSource = newStudy.StudyDrugSource?.Trim();
                    if (isPhysicianNetworkStudyrestricted == false)
                        newstudyresult.IsPhysicianNetworkStudy = newStudy.IsPhysicianNetworkStudy;
                    if (isPhysicianNetworkNamerestricted == false)
                        newstudyresult.PhysicianNetworkName = newStudy.PhysicianNetworkName?.Trim();
                    if (isOtherCooperativeGrouprestricted == false)
                        iisadminresult.OtherCooperativeGroup = newStudy.OtherCooperativeGroup?.Trim();

                    iisadminresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    iisadminresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Original Financial Request
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateOriginalFinancialRequest(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isrequestedforfinancialsupportrestricted = false;
                bool issupportprovidedbyothersourcesrestricted = false;
                bool isgovernmentsupportorovidedrestricted = false;
                bool isbudgetrequestedfortrialrestricted = false;
                bool issupportdescriptionrestricted = false;
                bool issupportsourcesrestricted = false;

                var newstudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newstudyresult != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.ISREQUESTINGSTUDYFUNDING:
                                newstudyresult.IsRequestedForFinancialSupport = newStudy.IsRequestedForFinancialSupport ?? newstudyresult.IsRequestedForFinancialSupport;
                                isrequestedforfinancialsupportrestricted = true;
                                break;
                            case ConstDefaultValue.ISSUPPORTBEPROVIDEDFROMOTHERSOURCES:
                                newstudyresult.IsSupportProvidedByOtherSources = newStudy.IsSupportProvidedByOtherSources ?? newstudyresult.IsSupportProvidedByOtherSources;
                                issupportprovidedbyothersourcesrestricted = true;
                                break;
                            case ConstDefaultValue.ISGOVERNMENTSUPPORTBEPROVIDED:
                                newstudyresult.IsGovernmentSupportProvided = newStudy.IsGovernmentSupportProvided ?? newstudyresult.IsGovernmentSupportProvided;
                                isgovernmentsupportorovidedrestricted = true;
                                break;
                            case ConstDefaultValue.ORIGINALREQUESTEDSTUDYAMOUNT:
                                newstudyresult.BudgetRequestedForTrial = newStudy.BudgetRequestedForTrial ?? newstudyresult.BudgetRequestedForTrial;
                                isbudgetrequestedfortrialrestricted = true;
                                break;
                            case ConstDefaultValue.GOVERNMENTSUPPORTDESCRIPTION:
                                newstudyresult.SupportDescription = newStudy.SupportDescription ?? newstudyresult.SupportDescription;
                                issupportdescriptionrestricted = true;
                                break;
                            case ConstDefaultValue.NONCOMPANYSUPPORTSOURCES:
                                newstudyresult.SupportSources = newStudy.SupportSources ?? newstudyresult.SupportSources;
                                issupportsourcesrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isrequestedforfinancialsupportrestricted == false)
                        newstudyresult.IsRequestedForFinancialSupport = newStudy.IsRequestedForFinancialSupport;
                    if (issupportprovidedbyothersourcesrestricted == false)
                        newstudyresult.IsSupportProvidedByOtherSources = newStudy.IsSupportProvidedByOtherSources;
                    if (isgovernmentsupportorovidedrestricted == false)
                        newstudyresult.IsGovernmentSupportProvided = newStudy.IsGovernmentSupportProvided;
                    if (isbudgetrequestedfortrialrestricted == false)
                        newstudyresult.BudgetRequestedForTrial = newStudy.BudgetRequestedForTrial;
                    if (issupportdescriptionrestricted == false)
                        newstudyresult.SupportDescription = newStudy.SupportDescription;
                    if (issupportsourcesrestricted == false)
                        newstudyresult.SupportSources = newStudy.SupportSources;

                    newstudyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    newstudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(newstudyresult, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisadminresult == null)
                {
                    DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                    {
                        Isrequestingacompanystudycompound = newStudy.Isrequestingacompanystudycompound,
                        Othersupportdescription = newStudy.Othersupportdescription,
                        Isrequestingsupportfromcompanyotherthandrugorfunding = newStudy.Isrequestingsupportfromcompanyotherthandrugorfunding,
                        Globalfundingrequested = newStudy.Globalfundingrequested,

                        ANJU_ChangedBy = newStudy.ANJU_AddedBy,
                        ANJU_ChangeDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
                else
                {
                    bool isrequestingacompanystudycompoundrestricted = false;
                    bool isothersupportdescriptionrestricted = false;
                    bool isrequestingsupportfromcompanyotherthandrugorfundingrestricted = false;
                    bool isglobalfundingrequestedrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.ISREQUESTINGACOMPANYSTUDYCOMPOUND:
                                iisadminresult.Isrequestingacompanystudycompound = newStudy.Isrequestingacompanystudycompound ?? iisadminresult.Isrequestingacompanystudycompound;
                                isrequestingacompanystudycompoundrestricted = true;
                                break;
                            case ConstDefaultValue.OTHERSUPPORTDESCRIPTION:
                                iisadminresult.Othersupportdescription = newStudy.Othersupportdescription ?? iisadminresult.Othersupportdescription ?? newStudy.Othersupportdescription;
                                isothersupportdescriptionrestricted = true;
                                break;
                            case ConstDefaultValue.ISREQUESTINGSUPPORTFROMCOMPANYOTHERTHANDRUGORFUNDING:
                                iisadminresult.Isrequestingsupportfromcompanyotherthandrugorfunding = iisadminresult.Isrequestingsupportfromcompanyotherthandrugorfunding ?? newStudy.Isrequestingsupportfromcompanyotherthandrugorfunding;
                                isrequestingsupportfromcompanyotherthandrugorfundingrestricted = true;
                                break;
                            case ConstDefaultValue.GLOBALFUNDINGREQUESTED:
                                iisadminresult.Globalfundingrequested = iisadminresult.Globalfundingrequested ?? newStudy.Globalfundingrequested;
                                isglobalfundingrequestedrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isrequestingacompanystudycompoundrestricted == false)
                        iisadminresult.Isrequestingacompanystudycompound = newStudy.Isrequestingacompanystudycompound;
                    if (isothersupportdescriptionrestricted == false)
                        iisadminresult.Othersupportdescription = newStudy.Othersupportdescription;
                    if (isrequestingsupportfromcompanyotherthandrugorfundingrestricted == false)
                        iisadminresult.Isrequestingsupportfromcompanyotherthandrugorfunding = newStudy.Isrequestingsupportfromcompanyotherthandrugorfunding;
                    if (isglobalfundingrequestedrestricted == false)
                        iisadminresult.Globalfundingrequested = newStudy.Globalfundingrequested;

                    iisadminresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    iisadminresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Create/Update Disease details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateDiseasedetails(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
            var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
            var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

            if (newStudy != null)
            {
                var newstudyresult = dbContextNavigate.StudyReview.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newstudyresult != null)
                {
                    bool isfranchiserestricted = false;
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.FRANCHISE:
                                newstudyresult.Franchise = newStudy.Franchise ?? newstudyresult.Franchise;
                                isfranchiserestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isfranchiserestricted == false)
                        newstudyresult.Franchise = newStudy.Franchise;

                    newstudyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    newstudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                   
                    retVal = dbContextNavigate.SaveChanges(newstudyresult, new StudyReview_H(), newstudyresult.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.StudyReview objStudyReview = new DataAccess.StudyReview()
                    {
                        StudyId = newStudy.StudyId,
                        Franchise = newStudy.Franchise,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    //dbContextNavigate.StudyReview.Add(objStudyReview);
                    retVal = dbContextNavigate.SaveChanges(objStudyReview, new StudyReview_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }



                var newconceptresult = dbContextNavigate.ConceptDesignandRationale.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newconceptresult != null)
                {
                    bool isBindingrestricted = false;
                    bool isstructurerestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.BLINDING:
                                newconceptresult.Binding = newStudy.Binding ?? newconceptresult.Binding;
                                isBindingrestricted = true;
                                break;
                            case ConstDefaultValue.STRUCTURE:
                                newconceptresult.Structure = newStudy.Structure ?? newconceptresult.Structure;
                                isstructurerestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isBindingrestricted == false)
                        newconceptresult.Binding = newStudy.Binding;
                    if (isstructurerestricted == false)
                        newconceptresult.Structure = newStudy.Structure;                    
                    retVal = dbContextNavigate.SaveChanges(newconceptresult, new ConceptDesignandRationale_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Update);
                }

                var iisadminresult = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (iisadminresult == null)
                {
                    DataAccess.IISAdmindetails objIISAdmindetails = new DataAccess.IISAdmindetails()
                    {
                        StudyId = newStudy.StudyId,
                        GenomicProfile = newStudy.GenomicProfile,
                        Lineoftherapy = newStudy.Lineoftherapy,
                        Disease = newStudy.Disease,
                        Diseasepaatientpopulation = newStudy.Diseasepaatientpopulation,
                        DiseaseStage = newStudy.DiseaseStage,
                        TreatmentSegment = newStudy.TreatmentSegment,
                        Qualityoflife = newStudy.Qualityoflife,
                        Riskfactors = newStudy.Riskfactors,
                        LineofTreatment = newStudy.LineofTreatment,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
                else
                {
                    bool isgenomicprofilerestricted = false;
                    bool isgenomiclineoftherapyrestricted = false;
                    bool isdiseaserestricted = false;
                    bool isdiseasepaatientpopulationrestricted = false;
                    bool isdiseasestagerestricted = false;
                    bool isreatmentsegmentrestricted = false;
                    bool isqualityofliferestricted = false;
                    bool isriskfactorsrestricted = false;
                    bool islineoftreatmentsrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.GENOMICPROFILE:
                                iisadminresult.GenomicProfile = newStudy.GenomicProfile ?? iisadminresult.GenomicProfile;
                                isgenomicprofilerestricted = true;
                                break;
                            case ConstDefaultValue.LINEOFTHERAPY:
                                iisadminresult.Lineoftherapy = newStudy.Lineoftherapy ?? iisadminresult.Lineoftherapy;
                                isgenomiclineoftherapyrestricted = true;
                                break;
                            case ConstDefaultValue.DISEASE:
                                iisadminresult.Disease = newStudy.Disease ?? iisadminresult.Disease;
                                isdiseaserestricted = true;
                                break;
                            case ConstDefaultValue.DISEASEFORPATIENTPOPULATION:
                                iisadminresult.Diseasepaatientpopulation = newStudy.Diseasepaatientpopulation ?? iisadminresult.Diseasepaatientpopulation;
                                isdiseasepaatientpopulationrestricted = true;
                                break;
                            case ConstDefaultValue.STAGE:
                                iisadminresult.DiseaseStage = newStudy.DiseaseStage ?? iisadminresult.DiseaseStage;
                                isdiseasestagerestricted = true;
                                break;
                            case ConstDefaultValue.TREATMENTSEGMENT:
                                iisadminresult.TreatmentSegment = newStudy.TreatmentSegment ?? iisadminresult.TreatmentSegment;
                                isreatmentsegmentrestricted = true;
                                break;
                            case ConstDefaultValue.QUALITYOFLIFE:
                                iisadminresult.Qualityoflife = newStudy.Qualityoflife ?? iisadminresult.Qualityoflife;
                                isqualityofliferestricted = true;
                                break;
                            case ConstDefaultValue.RISKFACTORS:
                                iisadminresult.Riskfactors = newStudy.Riskfactors ?? iisadminresult.Riskfactors;
                                isriskfactorsrestricted = true;
                                break;
                            case ConstDefaultValue.LINEOFTREATMENT:
                                iisadminresult.LineofTreatment = newStudy.LineofTreatment ?? iisadminresult.LineofTreatment;
                                islineoftreatmentsrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isgenomicprofilerestricted == false)
                        iisadminresult.GenomicProfile = newStudy.GenomicProfile;
                    if (isgenomiclineoftherapyrestricted == false)
                        iisadminresult.Lineoftherapy = newStudy.Lineoftherapy;
                    if (isdiseaserestricted == false)
                        iisadminresult.Disease = newStudy.Disease;
                    if (isdiseasepaatientpopulationrestricted == false)
                        iisadminresult.Diseasepaatientpopulation = newStudy.Diseasepaatientpopulation;
                    if (isdiseasestagerestricted == false)
                        iisadminresult.DiseaseStage = newStudy.DiseaseStage;
                    if (isreatmentsegmentrestricted == false)
                        iisadminresult.TreatmentSegment = newStudy.TreatmentSegment;
                    if (isqualityofliferestricted == false)
                        iisadminresult.Qualityoflife = newStudy.Qualityoflife;
                    if (isriskfactorsrestricted == false)
                        iisadminresult.Riskfactors = newStudy.Riskfactors;
                    if (islineoftreatmentsrestricted == false)
                        iisadminresult.LineofTreatment = newStudy.LineofTreatment;

                    iisadminresult.IsActive = true;
                    iisadminresult.IsDeleted = false;
                    iisadminresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    iisadminresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(iisadminresult, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Enrollment and Timelines
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateEnrollmentandTimelines(Data.NewStudy newStudy, string usertype,string username)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isstudystartrestricted = false;
                bool istotalnoofpatientsrestricted = false;
                bool isrecruitmentendrestricted = false;
                bool iscompletionoffinalstudyreportrestricted = false;
                bool istrialendrestricted = false;
                bool isprimarypublicationdaterestricted = false;

                var objPlannedTrialMilestoneDatesandEnrollment = dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (objPlannedTrialMilestoneDatesandEnrollment != null)
                {
                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.STUDYSTART:
                                objPlannedTrialMilestoneDatesandEnrollment.TrialStart = newStudy.TrialStart ?? objPlannedTrialMilestoneDatesandEnrollment.TrialStart;
                                isstudystartrestricted = true;
                                break;
                            case ConstDefaultValue.TOTALNOOFPATIENTS:
                                objPlannedTrialMilestoneDatesandEnrollment.TotalPlannedNumberofPatients = newStudy.TotalPlannedNumberofPatients ?? objPlannedTrialMilestoneDatesandEnrollment.TotalPlannedNumberofPatients;
                                istotalnoofpatientsrestricted = true;
                                break;
                            case ConstDefaultValue.RECRUITMENTEND:
                                objPlannedTrialMilestoneDatesandEnrollment.RecruitmentEnd = newStudy.RecruitmentEnd ?? objPlannedTrialMilestoneDatesandEnrollment.RecruitmentEnd;
                                isrecruitmentendrestricted = true;
                                break;
                            case ConstDefaultValue.COMPLETIONOFFINALSTUDYREPORT:
                                objPlannedTrialMilestoneDatesandEnrollment.CompletionofTrialReport = newStudy.CompletionofTrialReport ?? objPlannedTrialMilestoneDatesandEnrollment.CompletionofTrialReport;
                                iscompletionoffinalstudyreportrestricted = true;
                                break;
                            case ConstDefaultValue.TRIALEND:
                                objPlannedTrialMilestoneDatesandEnrollment.TrialEnd = newStudy.TrialEnd ?? objPlannedTrialMilestoneDatesandEnrollment.TrialEnd;
                                istrialendrestricted = true;
                                break;
                            case ConstDefaultValue.PRIMARYPUBLICATIONDATE:
                                objPlannedTrialMilestoneDatesandEnrollment.PrimaryPublicationDate = newStudy.PrimaryPublicationDate ?? objPlannedTrialMilestoneDatesandEnrollment.PrimaryPublicationDate;
                                isprimarypublicationdaterestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isstudystartrestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.TrialStart = newStudy.TrialStart;
                    if (istotalnoofpatientsrestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.TotalPlannedNumberofPatients = newStudy.TotalPlannedNumberofPatients;
                    if (isrecruitmentendrestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.RecruitmentEnd = newStudy.RecruitmentEnd;
                    if (iscompletionoffinalstudyreportrestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.CompletionofTrialReport = newStudy.CompletionofTrialReport;
                    if (istrialendrestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.TrialEnd = newStudy.TrialEnd;
                    if (isprimarypublicationdaterestricted == false)
                        objPlannedTrialMilestoneDatesandEnrollment.PrimaryPublicationDate = newStudy.PrimaryPublicationDate;
                   
                    retVal = dbContextNavigate.SaveChanges(objPlannedTrialMilestoneDatesandEnrollment, new PlannedTrialMilestoneDatesandEnrollment_H(), username, eAuditChangeType.Update);
                }
                if (retVal > 0)
                {
                    var objIISAdmindetails = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                    if (objIISAdmindetails != null)
                    {
                        bool isstudydurationrestricted = false;
                        bool isnoofpatientspertreatmentgrouprestricted = false;

                        foreach (var item in lstfields)
                        {
                            switch (item.FieldType)
                            {
                                case ConstDefaultValue.STUDYDURATION:
                                    objIISAdmindetails.Studyduration = newStudy.Studyduration ?? objIISAdmindetails.Studyduration;
                                    isstudydurationrestricted = true;
                                    break;
                                case ConstDefaultValue.NOOFPATIENTSPERTREATMENTGROUP:
                                    objIISAdmindetails.Noofpatientspertreatmentgroup = newStudy.Noofpatientspertreatmentgroup ?? objIISAdmindetails.Noofpatientspertreatmentgroup;
                                    isnoofpatientspertreatmentgrouprestricted = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (isstudydurationrestricted == false)
                            objIISAdmindetails.Studyduration = newStudy.Studyduration;
                        if (isnoofpatientspertreatmentgrouprestricted == false)
                            objIISAdmindetails.Noofpatientspertreatmentgroup = newStudy.Noofpatientspertreatmentgroup;
                                        
                        objIISAdmindetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                        objIISAdmindetails.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    }
                }
                if (retVal > 0)
                {
                    var objNewstudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                    if (objNewstudy != null)
                    {
                        bool iscompetingStudiesrestricted = false;
                        bool isimpactpatientaccrualfortheproposedstudyrestricted = false;
                        bool isenrollmenthistoryforotherrelatedstudiesrestricted = false;
                        bool isirbregistrationrequirementrestricted = false;

                        foreach (var item in lstfields)
                        {
                            switch (item.FieldType)
                            {
                                case ConstDefaultValue.COMPETINGSTUDIESATINSTITUTION:
                                    objNewstudy.IsCompetingStudies = newStudy.IsCompetingStudies ?? objNewstudy.IsCompetingStudies;
                                    iscompetingStudiesrestricted = true;
                                    break;
                                case ConstDefaultValue.IMPACTPATIENTACCRUALFORTHEPROPOSEDSTUDY:
                                    objNewstudy.CompetingStudies = newStudy.CompetingStudies ?? objNewstudy.CompetingStudies;
                                    isimpactpatientaccrualfortheproposedstudyrestricted = true;
                                    break;
                                case ConstDefaultValue.ENROLLMENTHISTORYFOROTHERRELATEDSTUDIES:
                                    objNewstudy.EnrollmentHistoryforOtherRelatedStudies = newStudy.EnrollmentHistoryforOtherRelatedStudies ?? objNewstudy.EnrollmentHistoryforOtherRelatedStudies;
                                    isenrollmenthistoryforotherrelatedstudiesrestricted = true;
                                    break;
                                case ConstDefaultValue.ISIRBREGISTRATIONREQUIREMENT:
                                    objNewstudy.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement ?? objNewstudy.IsIrbregistrationRequirement;
                                    isirbregistrationrequirementrestricted = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (iscompetingStudiesrestricted == false)
                            objNewstudy.IsCompetingStudies = newStudy.IsCompetingStudies;
                        if (isimpactpatientaccrualfortheproposedstudyrestricted == false)
                            objNewstudy.CompetingStudies = newStudy.CompetingStudies;
                        if (isenrollmenthistoryforotherrelatedstudiesrestricted == false)
                            objNewstudy.EnrollmentHistoryforOtherRelatedStudies = newStudy.EnrollmentHistoryforOtherRelatedStudies;
                        if (isirbregistrationrequirementrestricted == false)
                            objNewstudy.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement;

                        objNewstudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                        objNewstudy.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(objNewstudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update IRB Registration Requirement
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateIRBRegistrationRequirement(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var objNewstudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objNewstudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isirbregistrationRequirementrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.ISIRBREGISTRATIONREQUIREMENT:
                            objNewstudy.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement ?? objNewstudy.IsIrbregistrationRequirement;
                            isirbregistrationRequirementrestricted = true;
                            break;
                        default:
                            break;
                    }
                }

                if (isirbregistrationRequirementrestricted == false)
                    objNewstudy.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement;

                objNewstudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objNewstudy.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(objNewstudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Pandemic preparedness trial
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdatePandemicpreparednesstrial(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var objPLStudyReview = dbContextNavigate.PLStudyReview.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objPLStudyReview != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool istrialcategorizationrestricted = false;
                bool ismonitoringintervalrestricted = false;
                bool ismaximumallowablevistsrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.PANADEMICPREPAREDNESSTRIALCATEGORIZATION:
                            objPLStudyReview.TrialCategorization = newStudy.TrialCategorization ?? objPLStudyReview.TrialCategorization;
                            istrialcategorizationrestricted = true;
                            break;
                        case ConstDefaultValue.ISSAFETYMONITORINGINTERVAL:
                            objPLStudyReview.MonitoringInterval = newStudy.MonitoringInterval ?? objPLStudyReview.MonitoringInterval;
                            ismonitoringintervalrestricted = true;
                            break;
                        case ConstDefaultValue.MAXIMUMALLOWABLETIMEBETWEENVISITS:
                            objPLStudyReview.MaximumAllowableVists = newStudy.MaximumAllowableVists ?? objPLStudyReview.MaximumAllowableVists;
                            ismaximumallowablevistsrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (istrialcategorizationrestricted == false)
                    objPLStudyReview.TrialCategorization = newStudy.TrialCategorization;
                if (ismonitoringintervalrestricted == false)
                    objPLStudyReview.MonitoringInterval = newStudy.MonitoringInterval;
                if (ismaximumallowablevistsrestricted == false)
                    objPLStudyReview.MaximumAllowableVists = newStudy.MaximumAllowableVists;

                objPLStudyReview.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objPLStudyReview.ANJU_ChangeDate = DateTime.UtcNow;                
                retVal = dbContextNavigate.SaveChanges(objPLStudyReview, new PLStudyReview_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.PLStudyReview plstudyreview = new DataAccess.PLStudyReview()
                {
                    StudyId = newStudy.StudyId,
                    TrialCategorization = newStudy.TrialCategorization,
                    MonitoringInterval = newStudy.MonitoringInterval,
                    MaximumAllowableVists = newStudy.MaximumAllowableVists,
                    IsActive = true,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };                
                retVal = dbContextNavigate.SaveChanges(plstudyreview, new PLStudyReview_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Regulatory Requirements
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateRegulatoryRequirements(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
            var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
            var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

            var objNewStudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objNewStudy != null)
            {
                bool isindsubmissionrestricted = false;
                bool isrationaleforindexemptionrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.ISSUBMITANINDFORTHEPROPOSEDSTUDY:
                            objNewStudy.IsIndsubmission = newStudy.IsIndsubmission ?? objNewStudy.IsIndsubmission;
                            isindsubmissionrestricted = true;
                            break;
                        case ConstDefaultValue.RATIONALEFORINDEXEMPTION:
                            objNewStudy.RationaleforINDExemption = newStudy.RationaleforINDExemption ?? objNewStudy.RationaleforINDExemption;
                            isrationaleforindexemptionrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (isindsubmissionrestricted == false)
                    objNewStudy.IsIndsubmission = newStudy.IsIndsubmission;
                if (isrationaleforindexemptionrestricted == false)
                    objNewStudy.RationaleforINDExemption = newStudy.RationaleforINDExemption;

                objNewStudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objNewStudy.ANJU_ChangeDate = DateTime.UtcNow;;
                retVal = dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            if (retVal > 0)
            {
                var objIISAdmindetails = dbContextNavigate.IISAdmindetails.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (objIISAdmindetails != null)
                {
                    bool isfinalindstatusrestricted = false;
                    bool isindnumberrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.FINALINDSTATUS:
                                objIISAdmindetails.FinalINDStatus = newStudy.FinalINDStatus ?? objIISAdmindetails.FinalINDStatus;
                                isfinalindstatusrestricted = true;
                                break;
                            case ConstDefaultValue.INDNUMBER:
                                objIISAdmindetails.INDNumber = newStudy.INDNumber ?? objIISAdmindetails.INDNumber;
                                isindnumberrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isfinalindstatusrestricted == false)
                        objIISAdmindetails.FinalINDStatus = newStudy.FinalINDStatus;
                    if (isindnumberrestricted == false)
                        objIISAdmindetails.INDNumber = newStudy.INDNumber;

                    objIISAdmindetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    objIISAdmindetails.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(objIISAdmindetails, new IISAdmindetails_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.IISAdmindetails iisadmindetails = new DataAccess.IISAdmindetails()
                    {
                        StudyId = newStudy.StudyId,
                        FinalINDStatus = newStudy.FinalINDStatus,
                        INDNumber = newStudy.INDNumber,
                        ANJU_AddedBy = newStudy.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow,

                    };
                    retVal = dbContextNavigate.SaveChanges(iisadmindetails, new IISAdmindetails_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }

            }
            if (retVal > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Create/Update Email Lists
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateEmailLists(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var objEmaillist = dbContextNavigate.EmailList.Where(x => x.Id == newStudy.Id).SingleOrDefault();
            if (objEmaillist != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isemailrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.RECIPIENT:
                            objEmaillist.Email = newStudy.Email ?? objEmaillist.Email;
                            isemailrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (isemailrestricted == false)
                    objEmaillist.Email = newStudy.Email;

                objEmaillist.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objEmaillist.ANJU_ChangeDate = DateTime.UtcNow;                
                retVal = dbContextNavigate.SaveChanges(objEmaillist, new EmailList_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.EmailList emaillist = new DataAccess.EmailList()
                {
                    StudyId = newStudy.StudyId,
                    Email = newStudy.Email,
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };               
                retVal = dbContextNavigate.SaveChanges(emaillist, new EmailList_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Protocol numbers
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateProtocolnumbers(Data.NewStudy newStudy)
        {
            int retVal = default(int);
            var objNewStudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objNewStudy != null)
            {
                objNewStudy.IsIndsubmission = newStudy.IsIndsubmission;
                objNewStudy.RationaleforINDExemption = newStudy.RationaleforINDExemption;
                objNewStudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objNewStudy.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Key references
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateKeyreferences(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var objNewStudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objNewStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool iskeyreferencesrestricted = false;
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.KEYREFERENCES:
                            objNewStudy.KeyReferences = newStudy.KeyReferences ?? objNewStudy.KeyReferences;
                            iskeyreferencesrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (iskeyreferencesrestricted == false)
                    objNewStudy.KeyReferences = newStudy.KeyReferences;

                objNewStudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objNewStudy.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Investigator Qualifications
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateInvestigatorQualifications(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var objNewStudy = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objNewStudy != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool ismedicalspecialtyrestricted = false;
                bool isboardcertificationrestricted = false;
                bool ismedicallicenserestricted = false;
                bool isothertrainingsreceivedrestricted = false;
                bool islasttrainingdetailsrestricted = false;
                bool istypeOftrainingrestricted = false;
                bool istrialexperiencesrestricted = false;
                bool iscompanySponsoredtrialrestricted = false;
                bool istrialparticipationrestricted = false;
                bool isdrugnamerestricted = false;
                bool isprotocolnumberrestricted = false;
                bool isnumberOfongoingtrialsrestricted = false;
                bool issiteinspectedbyhealthauthorityrestricted = false;
                bool isnameofhealthauthorityrestricted = false;
                bool isdateOflastinspectionrestricted = false;
                bool issiteinspectedbyFdarestricted = false;
                bool isdateOfFdainspectionrestricted = false;
                bool isfda483formIssuedrestricted = false;
                bool isDetailsofobservationrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.MEDICALSPECIALTY:
                            objNewStudy.MedicalSpecialty = newStudy.MedicalSpecialty?.Trim() ?? objNewStudy.MedicalSpecialty;
                            ismedicalspecialtyrestricted = true;
                            break;
                        case ConstDefaultValue.BOARDCERTIFICATION:
                            objNewStudy.BoardCertification = newStudy.BoardCertification?.Trim() ?? objNewStudy.BoardCertification;
                            isboardcertificationrestricted = true;
                            break;
                        case ConstDefaultValue.LICENSEOREQUIVALENT:
                            objNewStudy.MedicalLicense = newStudy.MedicalLicense?.Trim() ?? objNewStudy.MedicalLicense;
                            ismedicallicenserestricted = true;
                            break;
                        case ConstDefaultValue.ISRECEIVEDGCPTRAININGTHEPAST3YEARS:
                            objNewStudy.IsOtherTrainingsReceived = newStudy.IsOtherTrainingsReceived ?? objNewStudy.IsOtherTrainingsReceived;
                            isothertrainingsreceivedrestricted = true;
                            break;
                        case ConstDefaultValue.LASTGCPTRAINING:
                            objNewStudy.LastTrainingDetails = newStudy.LastTrainingDetails?.Trim() ?? objNewStudy.LastTrainingDetails;
                            islasttrainingdetailsrestricted = true;
                            break;
                        case ConstDefaultValue.TYPEOFTRAININGRECEIVED:
                            objNewStudy.TypeOfTraining = newStudy.TypeOfTraining?.Trim() ?? objNewStudy.TypeOfTraining;
                            istypeOftrainingrestricted = true;
                            break;
                        case ConstDefaultValue.LISTTRIALEXPERIENCE:
                            objNewStudy.TrialExperiences = newStudy.TrialExperiences?.Trim() ?? objNewStudy.TrialExperiences;
                            istrialexperiencesrestricted = true;
                            break;
                        case ConstDefaultValue.ISPARTICIPATEDINACOMPANYTRIAL:
                            objNewStudy.IsCompanySponsoredtrial = newStudy.IsCompanySponsoredtrial ?? objNewStudy.IsCompanySponsoredtrial;
                            iscompanySponsoredtrialrestricted = true;
                            break;
                        case ConstDefaultValue.DATESOFTRIALPARTICIPATION:
                            objNewStudy.TrialParticipation = newStudy.TrialParticipation?.Trim() ?? objNewStudy.TrialParticipation;
                            istrialparticipationrestricted = true;
                            break;
                        case ConstDefaultValue.DRUGNAMES:
                            objNewStudy.DrugName = newStudy.DrugName?.Trim() ?? objNewStudy.DrugName;
                            isdrugnamerestricted = true;
                            break;
                        case ConstDefaultValue.PROTOCOLNUMBERS:
                            objNewStudy.ProtocolNumber = newStudy.ProtocolNumber?.Trim() ?? objNewStudy.ProtocolNumber;
                            isprotocolnumberrestricted = true;
                            break;
                        case ConstDefaultValue.NOOFONGOINGCLINICALTRIALS:
                            objNewStudy.NumberOfOngoingTrials = newStudy.NumberOfOngoingTrials?.Trim() ?? objNewStudy.NumberOfOngoingTrials;
                            isnumberOfongoingtrialsrestricted = true;
                            break;
                        case ConstDefaultValue.ISINSPECTEDBYAHEALTHAUTHORITY:
                            objNewStudy.IsSiteInspectedByHealthAuthority = newStudy.IsSiteInspectedByHealthAuthority ?? objNewStudy.IsSiteInspectedByHealthAuthority;
                            issiteinspectedbyhealthauthorityrestricted = true;
                            break;
                        case ConstDefaultValue.WHICHHEALTHAUTHORITY:
                            objNewStudy.NameOfHealthAuthority = newStudy.NameOfHealthAuthority?.Trim() ?? objNewStudy.NameOfHealthAuthority;
                            isnameofhealthauthorityrestricted = true;
                            break;
                        case ConstDefaultValue.DATEOFLASTINSPECTION:
                            objNewStudy.DateOflastInspection = newStudy.DateOflastInspection ?? objNewStudy.DateOflastInspection;
                            isdateOflastinspectionrestricted = true;
                            break;
                        case ConstDefaultValue.ISINSPECTEDBYTHEFDA:
                            objNewStudy.IsSiteInspectedByFda = newStudy.IsSiteInspectedByFda ?? objNewStudy.IsSiteInspectedByFda;
                            issiteinspectedbyFdarestricted = true;
                            break;
                        case ConstDefaultValue.DATEOFFDAINSPECTION:
                            objNewStudy.DateOfFdainspection = newStudy.DateOfFdainspection ?? objNewStudy.DateOfFdainspection;
                            isdateOfFdainspectionrestricted = true;
                            break;
                        case ConstDefaultValue.ISFDAISSUEAFDA483FORM:
                            objNewStudy.Isfda483formIssued = newStudy.Isfda483formIssued ?? objNewStudy.Isfda483formIssued;
                            isfda483formIssuedrestricted = true;
                            break;
                        case ConstDefaultValue.DETAILSOFTHEMAINOBSERVATIONS:
                            objNewStudy.DetailsOfObservation = newStudy.DetailsOfObservation?.Trim() ?? objNewStudy.DetailsOfObservation;
                            isDetailsofobservationrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (ismedicalspecialtyrestricted == false)
                    objNewStudy.MedicalSpecialty = newStudy.MedicalSpecialty?.Trim();
                if (isboardcertificationrestricted == false)
                    objNewStudy.BoardCertification = newStudy.BoardCertification?.Trim();
                if (ismedicallicenserestricted == false)
                    objNewStudy.MedicalLicense = newStudy.MedicalLicense?.Trim();
                if (isothertrainingsreceivedrestricted == false)
                    objNewStudy.IsOtherTrainingsReceived = newStudy.IsOtherTrainingsReceived;
                if (islasttrainingdetailsrestricted == false)
                    objNewStudy.LastTrainingDetails = newStudy.LastTrainingDetails?.Trim();
                if (istypeOftrainingrestricted == false)
                    objNewStudy.TypeOfTraining = newStudy.TypeOfTraining?.Trim();
                if (istrialexperiencesrestricted == false)
                    objNewStudy.TrialExperiences = newStudy.TrialExperiences?.Trim();
                if (iscompanySponsoredtrialrestricted == false)
                    objNewStudy.IsCompanySponsoredtrial = newStudy.IsCompanySponsoredtrial;
                if (istrialparticipationrestricted == false)
                    objNewStudy.TrialParticipation = newStudy.TrialParticipation?.Trim();
                if (isdrugnamerestricted == false)
                    objNewStudy.DrugName = newStudy.DrugName?.Trim();
                if (isprotocolnumberrestricted == false)
                    objNewStudy.ProtocolNumber = newStudy.ProtocolNumber?.Trim();
                if (isnumberOfongoingtrialsrestricted == false)
                    objNewStudy.NumberOfOngoingTrials = newStudy.NumberOfOngoingTrials?.Trim();
                if (issiteinspectedbyhealthauthorityrestricted == false)
                    objNewStudy.IsSiteInspectedByHealthAuthority = newStudy.IsSiteInspectedByHealthAuthority;
                if (isnameofhealthauthorityrestricted == false)
                    objNewStudy.NameOfHealthAuthority = newStudy.NameOfHealthAuthority?.Trim();
                if (isdateOflastinspectionrestricted == false)
                    objNewStudy.DateOflastInspection = newStudy.DateOflastInspection;
                if (issiteinspectedbyFdarestricted == false)
                    objNewStudy.IsSiteInspectedByFda = newStudy.IsSiteInspectedByFda;
                if (isdateOfFdainspectionrestricted == false)
                    objNewStudy.DateOfFdainspection = newStudy.DateOfFdainspection;
                if (isfda483formIssuedrestricted == false)
                    objNewStudy.Isfda483formIssued = newStudy.Isfda483formIssued;
                if (isDetailsofobservationrestricted == false)
                    objNewStudy.DetailsOfObservation = newStudy.DetailsOfObservation?.Trim();

                objNewStudy.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objNewStudy.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(objNewStudy, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Create/Update Contacts
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateContacts(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
            var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
            var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

            bool issiteindexrestricted = false;
            bool iscontacttyperestricted = false;
            bool iscontacttypedetailsrestricted = false;
            bool istaxidrestricted = false;
            bool issalutationrestricted = false;
            bool isfirstnamerestricted = false;
            bool islastnamerestricted = false;
            bool iscityrestricted = false;
            bool iscountryidrestricted = false;
            bool isstateidrestricted = false;
            bool issuffixrestricted = false;
            bool isdegreerestricted = false;
            bool istitlerestricted = false;
            bool isinstitutionrestricted = false;
            bool isaddress1restricted = false;
            bool isaddress2restricted = false;
            bool isaddress3restricted = false;
            bool ispostalcoderestricted = false;
            bool isphonerestricted = false;
            bool isfaxrestricted = false;
            bool isprimaryemailidrestricted = false;
            bool isnpirestricted = false;
            bool isregionrestricted = false;

            var objPrincipalInvestigator = dbContextNavigate.PrincipalInvestigator.Where(x => x.StudyId == newStudy.StudyId && x.PrincipalInvestigatorId == newStudy.PrincipalInvestigatorId).SingleOrDefault();
            if (objPrincipalInvestigator != null)
            {
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.SITEINDEX:
                            objPrincipalInvestigator.SiteIndex = newStudy.SiteIndex?.Trim() ?? objPrincipalInvestigator.SiteIndex?.Trim();
                            issiteindexrestricted = true;
                            break;
                        case ConstDefaultValue.CONTACTTYPE:
                            objPrincipalInvestigator.ContactType = newStudy.ContactType?.Trim() ?? objPrincipalInvestigator.ContactType.Trim();
                            iscontacttyperestricted = true;
                            break;
                        case ConstDefaultValue.CONTACTTYPEDETILS:
                            objPrincipalInvestigator.ContactTypeDetails = newStudy.ContactTypeDetails?.Trim() ?? objPrincipalInvestigator.ContactTypeDetails.Trim();
                            iscontacttypedetailsrestricted = true;
                            break;
                        case ConstDefaultValue.TAXID:
                            objPrincipalInvestigator.TaxID = newStudy.TaxID?.Trim() ?? objPrincipalInvestigator.TaxID.Trim();
                            istaxidrestricted = true;
                            break;
                        case ConstDefaultValue.SALUTATION:
                            objPrincipalInvestigator.Salutation = newStudy.Salutation?.Trim() ?? objPrincipalInvestigator.Salutation.Trim();
                            issalutationrestricted = true;
                            break;
                        case ConstDefaultValue.FIRSTNAME:
                            objPrincipalInvestigator.FirstName = newStudy.FirstName?.Trim() ?? objPrincipalInvestigator.FirstName.Trim();
                            isfirstnamerestricted = true;
                            break;
                        case ConstDefaultValue.LASTNAME:
                            objPrincipalInvestigator.LastName = newStudy.LastName?.Trim() ?? objPrincipalInvestigator.LastName.Trim();
                            islastnamerestricted = true;
                            break;
                        case ConstDefaultValue.CITY:
                            objPrincipalInvestigator.CityId = newStudy.CityId ?? objPrincipalInvestigator.CityId;
                            iscityrestricted = true;
                            break;
                        case ConstDefaultValue.COUNTRY:
                            objPrincipalInvestigator.CountryId = newStudy.CountryId ?? objPrincipalInvestigator.CountryId;
                            iscountryidrestricted = true;
                            break;
                        case ConstDefaultValue.STATE:
                            objPrincipalInvestigator.StateId = newStudy.StateId ?? objPrincipalInvestigator.StateId;
                            isstateidrestricted = true;
                            break;
                        case ConstDefaultValue.SUFFIX:
                            objPrincipalInvestigator.Suffix = newStudy.Suffix?.Trim() ?? objPrincipalInvestigator.Suffix.Trim();
                            issuffixrestricted = true;
                            break;
                        case ConstDefaultValue.CREDENTIALS:
                            objPrincipalInvestigator.Degree = newStudy.Degree?.Trim() ?? objPrincipalInvestigator.Degree;
                            isdegreerestricted = true;
                            break;
                        case ConstDefaultValue.TITLE:
                            objPrincipalInvestigator.Title = newStudy.Title?.Trim() ?? objPrincipalInvestigator.Title.Trim();
                            istitlerestricted = true;
                            break;
                        case ConstDefaultValue.INSTITUTIONINTERNAL:
                            objPrincipalInvestigator.Institution = newStudy.Institution?.Trim() ?? objPrincipalInvestigator.Institution.Trim();
                            isinstitutionrestricted = true;
                            break;
                        case ConstDefaultValue.ADDRESS1:
                            objPrincipalInvestigator.Address1 = newStudy.Address1?.Trim() ?? objPrincipalInvestigator.Address1.Trim();
                            isaddress1restricted = true;
                            break;
                        case ConstDefaultValue.ADDRESS2:
                            objPrincipalInvestigator.Address2 = newStudy.Address2?.Trim() ?? objPrincipalInvestigator.Address2.Trim();
                            isaddress2restricted = true;
                            break;
                        case ConstDefaultValue.ADDRESS3:
                            objPrincipalInvestigator.Address3 = newStudy.Address3?.Trim() ?? objPrincipalInvestigator.Address3.Trim();
                            isaddress3restricted = true;
                            break;
                        case ConstDefaultValue.POSTALCODE:
                            objPrincipalInvestigator.PostalCode = newStudy.PostalCode?.Trim() ?? objPrincipalInvestigator.PostalCode;
                            ispostalcoderestricted = true;
                            break;
                        case ConstDefaultValue.PHONE:
                            objPrincipalInvestigator.Phone = newStudy.Phone?.Trim() ?? objPrincipalInvestigator.Phone.Trim();
                            isphonerestricted = true;
                            break;
                        case ConstDefaultValue.FAX:
                            objPrincipalInvestigator.Fax = newStudy.Fax?.Trim() ?? objPrincipalInvestigator.Fax.Trim();
                            isfaxrestricted = true;
                            break;
                        case ConstDefaultValue.EMAIL:
                            objPrincipalInvestigator.PrimaryEmailId = newStudy.PrimaryEmailId?.Trim() ?? objPrincipalInvestigator.PrimaryEmailId.Trim();
                            isprimaryemailidrestricted = true;
                            break;
                        case ConstDefaultValue.NPI:
                            objPrincipalInvestigator.Npinumber = newStudy.Npinumber?.Trim() ?? objPrincipalInvestigator.Npinumber.Trim();
                            isnpirestricted = true;
                            break;
                        case ConstDefaultValue.REGION:
                            objPrincipalInvestigator.Region = newStudy.Region ?? objPrincipalInvestigator.Region;
                            isregionrestricted = true;
                            break;
                        default:
                            break;
                    }
                }
                if (issiteindexrestricted == false)
                    objPrincipalInvestigator.SiteIndex = newStudy.SiteIndex;
                if (iscontacttyperestricted == false)
                    objPrincipalInvestigator.ContactType = newStudy.ContactType;
                if (iscontacttypedetailsrestricted == false)
                    objPrincipalInvestigator.ContactTypeDetails = newStudy.ContactTypeDetails;
                if (istaxidrestricted == false)
                    objPrincipalInvestigator.TaxID = newStudy.TaxID;
                if (issalutationrestricted == false)
                    objPrincipalInvestigator.Salutation = newStudy.Salutation;
                if (isfirstnamerestricted == false)
                    objPrincipalInvestigator.FirstName = newStudy.FirstName;
                if (islastnamerestricted == false)
                    objPrincipalInvestigator.LastName = newStudy.LastName;
                if (iscityrestricted == false)
                    objPrincipalInvestigator.CityId = newStudy.CityId;
                if (iscountryidrestricted == false)
                    objPrincipalInvestigator.CountryId = newStudy.CountryId;
                if (isstateidrestricted == false)
                    objPrincipalInvestigator.StateId = newStudy.StateId;
                if (issuffixrestricted == false)
                    objPrincipalInvestigator.Suffix = newStudy.Suffix;
                if (isdegreerestricted == false)
                    objPrincipalInvestigator.Degree = newStudy.Degree;
                if (istitlerestricted == false)
                    objPrincipalInvestigator.Title = newStudy.Title;
                if (isinstitutionrestricted == false)
                    objPrincipalInvestigator.Institution = newStudy.Institution;
                if (isaddress1restricted == false)
                    objPrincipalInvestigator.Address1 = newStudy.Address1;
                if (isaddress2restricted == false)
                    objPrincipalInvestigator.Address2 = newStudy.Address2;
                if (isaddress3restricted == false)
                    objPrincipalInvestigator.Address3 = newStudy.Address3;
                if (ispostalcoderestricted == false)
                    objPrincipalInvestigator.PostalCode = newStudy.PostalCode;
                if (isphonerestricted == false)
                    objPrincipalInvestigator.Phone = newStudy.Phone;
                if (isfaxrestricted == false)
                    objPrincipalInvestigator.Fax = newStudy.Fax;
                if (isprimaryemailidrestricted == false)
                    objPrincipalInvestigator.PrimaryEmailId = newStudy.PrimaryEmailId;
                if (isnpirestricted == false)
                    objPrincipalInvestigator.Npinumber = newStudy.Npinumber;
                if (isregionrestricted == false)
                    objPrincipalInvestigator.Region = newStudy.Region;

                objPrincipalInvestigator.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objPrincipalInvestigator.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(objPrincipalInvestigator, new PrincipalInvestigator_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.PrincipalInvestigator objPrincipalinvestigator = new DataAccess.PrincipalInvestigator()
                {
                    StudyId = newStudy.StudyId,
                    SiteIndex = newStudy.SiteIndex?.Trim(),
                    ContactType = newStudy.ContactType?.Trim(),
                    ContactTypeDetails = newStudy.ContactTypeDetails?.Trim(),
                    TaxID = newStudy.TaxID?.Trim(),
                    Salutation = newStudy.Salutation?.Trim(),
                    FirstName = newStudy.FirstName?.Trim(),
                    LastName = newStudy.LastName,
                    CountryId = newStudy.CountryId,
                    StateId = newStudy.StateId,
                    CityId = newStudy.CityId,
                    Suffix = newStudy.Suffix?.Trim(),
                    Degree = newStudy.Degree?.Trim(),
                    Title = newStudy.Title?.Trim(),
                    Institution = newStudy.Institution?.Trim(),
                    Address1 = newStudy.Address1?.Trim(),
                    Address2 = newStudy.Address2,
                    Address3 = newStudy.Address3?.Trim(),
                    PostalCode = newStudy.PostalCode?.Trim(),
                    Phone = newStudy.Phone?.Trim(),
                    Fax = newStudy.Fax?.Trim(),
                    PrimaryEmailId = newStudy.PrimaryEmailId?.Trim(),
                    Npinumber = newStudy.Npinumber?.Trim(),
                    Region = newStudy.Region,

                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };               
                retVal = dbContextNavigate.SaveChanges(objPrincipalinvestigator, new PrincipalInvestigator_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);

            }

            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Get the Document list
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentTypes()
        {
            var lsDocumenttype = dbContextNavigate.DocumentSubTypes.Select(x => new Data.Documents()
            {
                DocumentType = x.Name
            }).Distinct().ToList();
            return lsDocumenttype;
        }

        /// <summary>
        /// Save Identification Activation documents
        /// </summary>
        /// <param name="lsDocuments"></param>
        /// <returns></returns>
        public bool SaveIdentificationActivationDocuments(List<Data.Documents> lsDocuments, string LogedinUserName, string studyowner)
        {
            int retVal = default(int);
            int studyid = lsDocuments.Select(x => x.StudyId).FirstOrDefault();
            Documents objdocument = new Documents();
            if (lsDocuments.Count > 0)
            {
                var results = dbContextNavigate.Documents.Where(x => x.StudyId == studyid && x.SubModuleName == ConstDefaultValue.ACTIVATIONDOCUMENT && x.IsActive == true).ToList();
                if (results.Count > 0)
                {
                    foreach (var item in results)
                    {
                       
                        item.IsActive = false;
                        item.IsDeleted = true;                  
                        retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), LogedinUserName, eAuditChangeType.Delete);

                    }
                }

                foreach (var items in lsDocuments)
                {
                    DataAccess.Documents objDocumet = new DataAccess.Documents();
                    objDocumet.DocumentName = items.DocumentName;
                    objDocumet.DocumentType = items.DocumentType;
                    objDocumet.SubModuleName = ConstDefaultValue.ACTIVATIONDOCUMENT;
                    if (items.DocumentType == Utilities.Messages.REGULATORYDOCUMENT)
                        objDocumet.DocumentSubType = Utilities.Messages.REGULATORYSUBTYPE;
                    objDocumet.StudyId = items.StudyId;
                    objDocumet.DocumentSize = 0;
                    objDocumet.DocumentExtension = ".txt";
                    objDocumet.IsActive = true;
                    objDocumet.IsDeleted = false;
                    objDocumet.IsSubmit = false;
                    objDocumet.IsActivated = false;
                    objDocumet.ANJU_AddedBy = LogedinUserName;
                    objDocumet.ANJU_AddDate = DateTime.UtcNow;                    
                    retVal= dbContextNavigate.SaveChanges(objDocumet, new Documents_H(), LogedinUserName, eAuditChangeType.Insert);

                }

                var gmrcresults = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyid && x.TaskName == Messages.IDENTIFYACTIVATIONDOCUMENTS).FirstOrDefault();
                if (gmrcresults != null)
                {
                    gmrcresults.IsTaskCompleted = true;
                    gmrcresults.IsActive = false;
                    gmrcresults.IsDeleted = true;
                    gmrcresults.ANJU_ChangedBy = LogedinUserName;
                    gmrcresults.ANJU_ChangeDate = DateTime.UtcNow;                    
                    retVal = dbContextNavigate.SaveChanges(gmrcresults, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Delete);
                }
                if (retVal > 0)
                {
                    DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask();
                    objGMRCApprovalTask.StudyId = studyid;
                    objGMRCApprovalTask.TaskName = Messages.SUBMITACTIVATIONDOCUMENTS;
                    objGMRCApprovalTask.AssignedTo = studyowner;
                    objGMRCApprovalTask.IsTaskCompleted = false;
                    objGMRCApprovalTask.IsActive = true;
                    objGMRCApprovalTask.IsDeleted = false;
                    objGMRCApprovalTask.ANJU_AddedBy = LogedinUserName;
                    objGMRCApprovalTask.ANJU_AddDate = DateTime.UtcNow;                                        
                    retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Insert);
                }

                var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == studyid && x.IsTaskCompleted == false);
                if (TaskCount == 0)
                {
                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                  .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                  (pl, u) => new { pl, u })
                                                  .Where(x => x.pl.StudyId == studyid && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                  .Select(x => x.u.UserName).FirstOrDefault();

                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                    {
                        StudyId = studyid,
                        TaskName = Utilities.Messages.FINALACTIVATIONREVIEW,
                        IsTaskCompleted = false,
                        AssignedTo = TlUserName,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = LogedinUserName,
                        ANJU_AddDate = DateTime.UtcNow
                    };                    
                    retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Insert);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Save Identification Activation documents
        /// </summary>
        /// <param name="lsDocuments"></param>
        /// <returns></returns>
        public bool SaveUpdateDocuments(List<Data.Documents> lsDocuments, string LogedinUserName, string studyowner)
        {
            int retVal = default(int);
            int studyid = lsDocuments.Select(x => x.StudyId).FirstOrDefault();
            if (lsDocuments.Count > 0)
            {
                var results = dbContextNavigate.Documents.Where(x => x.StudyId == studyid && x.SubModuleName == Messages.UPDATEDDOCUMENTS && x.IsActive == true).ToList();
                if (results.Count > 0)
                {
                    foreach (var item in results)
                    {
                        item.IsActive = false;
                        item.IsDeleted = true;                       
                        retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), LogedinUserName, eAuditChangeType.Delete);
                    }
                }

                foreach (var items in lsDocuments)
                {
                    DataAccess.Documents objDocumet = new DataAccess.Documents();
                    objDocumet.DocumentName = items.DocumentName;
                    objDocumet.DocumentType = items.DocumentType;
                    objDocumet.SubModuleName = Messages.UPDATEDDOCUMENTS;
                    if (items.DocumentType == Utilities.Messages.REGULATORYDOCUMENT)
                        objDocumet.DocumentSubType = Utilities.Messages.REGULATORYSUBTYPE;
                    objDocumet.StudyId = items.StudyId;
                    objDocumet.DocumentSize = 0;
                    objDocumet.DocumentExtension = ".txt";
                    objDocumet.IsActive = true;
                    objDocumet.IsDeleted = false;
                    objDocumet.IsSubmit = false;
                    objDocumet.IsActivated = false;
                    objDocumet.ANJU_AddedBy = LogedinUserName;
                    objDocumet.ANJU_AddDate = DateTime.UtcNow;                   
                    dbContextNavigate.SaveChanges(objDocumet, new Documents_H(), LogedinUserName, eAuditChangeType.Insert);

                }

                var gmrcresults = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyid && x.TaskName == Messages.REVIEWUPDATEDDOCUMENTS).FirstOrDefault();
                if (gmrcresults != null)
                {
                    gmrcresults.IsTaskCompleted = true;
                    gmrcresults.IsActive = false;
                    gmrcresults.IsDeleted = true;
                    gmrcresults.ANJU_ChangedBy = LogedinUserName;
                    gmrcresults.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(gmrcresults, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Delete);
                }

            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Save Amendment protocol details
        /// </summary>
        /// <param name="StudyId"></param>
        /// <param name="LogedinUserName"></param>
        /// <param name="decision"></param>
        /// <returns></returns>
        public bool SaveAmendmentProtocol(int StudyId, string LogedinUserName, string decision,string studyOwner)
        {
            int retVal = default(int);
            var results = dbContextNavigate.Documents.Where(x => x.StudyId == StudyId && x.SubModuleName == Messages.AMENDMENTMANDATORYDOCUMENTS && x.IsActive == true).ToList();
            if (results.Count > 0)
            {
                foreach (var item in results)
                {
                    item.IsActive = false;
                    item.IsDeleted = true;                   
                    retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), LogedinUserName, eAuditChangeType.Delete);
                }
            }

            var gmrcresults = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == StudyId && x.TaskName == Messages.REVIEWFORAMENDMENT && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (gmrcresults != null)
            {
                gmrcresults.IsTaskCompleted = true;
                gmrcresults.IsActive = false;
                gmrcresults.IsDeleted = true;
                gmrcresults.ANJU_ChangedBy = LogedinUserName;
                gmrcresults.ANJU_ChangeDate = DateTime.UtcNow;               
                retVal = dbContextNavigate.SaveChanges(gmrcresults, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    if (decision == "resubmit")
                    {
                        DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                        {
                            TaskName = Utilities.Messages.RESUBMITAMENEDMENTREQUEST,
                            AssignedTo = studyOwner,
                            StudyId = StudyId,
                            IsTaskCompleted = false,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddDate = DateTime.UtcNow,
                            ANJU_AddedBy = LogedinUserName

                        };                        
                        retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Insert);
                        if (retVal > 0)
                        {
                            return true;
                        }

                        else
                            return false;
                    }
                    else if (decision == "approved")
                    {
                        DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                        {
                            TaskName = Utilities.Messages.STUDYPROFILEUPDATESFORAMENDMENT,
                            AssignedTo = LogedinUserName,
                            StudyId = StudyId,
                            IsTaskCompleted = false,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddDate = DateTime.UtcNow,
                            ANJU_AddedBy = LogedinUserName
                        };                       
                        retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Insert);
                        if (retVal > 0)
                        {
                            return true;
                        }

                        else
                            return false;

                    }
                    else if (decision == "rejected")
                    {
                        DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                        {
                            TaskName = Utilities.Messages.REVIEWREJECTIONFORAMENDMENT,
                            AssignedTo = LogedinUserName,
                            StudyId = StudyId,
                            IsTaskCompleted = false,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddDate = DateTime.UtcNow,
                            ANJU_AddedBy = LogedinUserName
                        };                        
                        retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), LogedinUserName, eAuditChangeType.Insert);
                        if (retVal > 0)
                        {
                            return true;
                        }

                        else
                            return false;

                    }


                }
            }
            if (retVal > 0)
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Update SubmitActivation Document Details
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool SubmitActivationDocument(Data.Documents documents)
        {
            int pendingdocument = 1, val = 0;
            if (documents != null)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == documents.StudyId && x.SubModuleName == Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT && x.DocumentName == documents.DocumentName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsSubmit = true;
                    result.IsActivated = false;
                    result.SubModuleId = documents.SubModuleId;
                    result.DocumentStatus = Utilities.Messages.PENDINGREVIEW;
                    result.Path = documents.Path;
                    result.DocumentSize = documents.DocumentSize;
                    result.ANJU_ChangedBy = documents.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                    
                    val = dbContextNavigate.SaveChanges(result, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Update);
                    if (val > 0)
                    {
                        pendingdocument = dbContextNavigate.Documents.Count(x => x.StudyId == documents.StudyId && x.SubModuleName == Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT && x.IsSubmit == false);
                        if (pendingdocument == 0)
                        {
                            var taskrsult = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == documents.StudyId && x.IsActive == true && (x.TaskName == Utilities.Messages.SUBMITACTIVATIONDOCUMENTS || x.TaskName == Utilities.Messages.RESUBMITACTIVATIONDOCUMENTS)).FirstOrDefault();
                            if (taskrsult != null)
                            {
                                taskrsult.IsActive = false;
                                taskrsult.IsDeleted = true;
                                taskrsult.IsTaskCompleted = true;
                                taskrsult.ANJU_ChangedBy = documents.ANJU_AddedBy;
                                taskrsult.ANJU_ChangeDate = DateTime.UtcNow;                               
                                val = dbContextNavigate.SaveChanges(taskrsult, new GMRCApprovalTask_H(), documents.ANJU_AddedBy, eAuditChangeType.Delete);
                                if (val > 0)
                                {
                                    DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask();
                                    objGMRCApprovalTask.StudyId = documents.StudyId;
                                    objGMRCApprovalTask.TaskName = Messages.REVIEWACTIVATIONDOCUMENTS;
                                    objGMRCApprovalTask.AssignedTo = taskrsult.ANJU_AddedBy;
                                    objGMRCApprovalTask.IsTaskCompleted = false;
                                    objGMRCApprovalTask.IsActive = true;
                                    objGMRCApprovalTask.IsDeleted = false;
                                    objGMRCApprovalTask.ANJU_AddedBy = documents.ANJU_AddedBy;
                                    objGMRCApprovalTask.ANJU_AddDate = DateTime.UtcNow;                                    
                                    val = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
                                    if (val > 0)
                                        return true;
                                    else
                                        return false;
                                }
                                else
                                    return false;
                            }
                            else
                                return true;

                        }
                        else
                            return true;
                    }

                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }

        /// <summary>
        /// Update SubmitActivation Document Details
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool SubmitUpdatedDocument(Data.Documents documents)
        {

            if (documents != null)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == documents.StudyId && x.SubModuleName == Utilities.Messages.UPDATEDDOCUMENTS && x.DocumentName == documents.DocumentName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsSubmit = true;
                    result.IsActivated = false;
                    result.SubModuleId = documents.SubModuleId;
                    result.DocumentStatus = Utilities.Messages.PENDINGREVIEW;
                    result.Path = documents.Path;
                    result.DocumentSize = documents.DocumentSize;
                    result.ANJU_ChangedBy = documents.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                    
                    var val = dbContextNavigate.SaveChanges(result, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Update);
                    if (val > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    DataAccess.Documents objDocuments = new DataAccess.Documents()
                    {
                        DocumentName = documents.DocumentName,
                        DocumentSize = documents.DocumentSize,
                        DocumentExtension = documents.DocumentExtension,
                        DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension,
                        SubModuleName = documents.SubModuleName,
                        StudyId = documents.StudyId,
                        Path = documents.Path,
                        DocumentStatus = documents.DocumentStatus,
                        DocumentType = documents.DocumentType,
                        DocumentSubType = documents.DocumentSubType,
                        DocumentVersion = documents.DocumentVersion,
                        OriginalDate = documents.OriginalDate,
                        ExpirationDate = documents.ExpirationDate,
                        IsActivated = documents.IsActivated,
                        IsSubmit = documents.IsSubmit,
                        IsActive = documents.IsActive,
                        IsDeleted = documents.IsDeleted,
                        ANJU_AddedBy = documents.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow

                    };                  
                    documents.DocumentId = objDocuments.DocumentId;
                    var val = dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
                    if (val > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            else
                return false;

        }

        /// <summary>
        /// Update SubmitActivation Document Details
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool AddTAsk(int studyid,string studyOwner)
        {
            int val = 0;


            var IsProtocolResubmissionExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyid && x.TaskName == Messages.REVIEWUPDATEDDOCUMENTS
                                                    && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask();
            if (IsProtocolResubmissionExists == null)
            {
                int count = dbContextNavigate.GMRCApprovalTask.Count(x => x.TaskName == Messages.REVIEWUPDATEDDOCUMENTS && x.StudyId == studyid && x.IsActive == true);
                if (count < 1)
                {
                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                     .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                     (pl, u) => new { pl, u })
                                     .Where(x => x.pl.StudyId == studyid && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                     .Select(x => x.u.UserName).FirstOrDefault();

                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                    {
                        StudyId = studyid,
                        TaskName = Messages.REVIEWUPDATEDDOCUMENTS,
                        IsTaskCompleted = false,
                        AssignedTo = TlUserName,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = studyOwner,
                        ANJU_AddDate = DateTime.UtcNow
                    };                    
                    val = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), studyOwner, eAuditChangeType.Insert);
                }

            }
            else
            {
                IsProtocolResubmissionExists.IsTaskCompleted = false;
                IsProtocolResubmissionExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                IsProtocolResubmissionExists.ANJU_ChangeDate = DateTime.UtcNow;               
                val = dbContextNavigate.SaveChanges(IsProtocolResubmissionExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

            }
            return true;
        }

        /// <summary>
        /// Add Amendment task
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool AddAmendmentTask(int studyid,string studyOwner)
        {
            int val = 0;


            var IsProtocolResubmissionExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyid && x.TaskName == Messages.REVIEWFORAMENDMENT
                                                    && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask();
            if (IsProtocolResubmissionExists == null)
            {
                int count = dbContextNavigate.GMRCApprovalTask.Count(x => x.TaskName == Messages.REVIEWFORAMENDMENT && x.StudyId == studyid && x.IsActive == true);
                if (count < 1)
                {
                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                      .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                      (pl, u) => new { pl, u })
                                      .Where(x => x.pl.StudyId == studyid && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                      .Select(x => x.u.UserName).FirstOrDefault();

                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                    {
                        StudyId = studyid,
                        TaskName = Messages.REVIEWFORAMENDMENT,
                        IsTaskCompleted = false,
                        AssignedTo = TlUserName,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = studyOwner,
                        ANJU_AddDate = DateTime.UtcNow
                    };                    
                    val = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), studyOwner, eAuditChangeType.Insert);
                }

            }
            else
            {
                IsProtocolResubmissionExists.IsTaskCompleted = false;
                IsProtocolResubmissionExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                IsProtocolResubmissionExists.ANJU_ChangeDate = DateTime.UtcNow;               
                val = dbContextNavigate.SaveChanges(IsProtocolResubmissionExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

            }
            return true;
        }

        /// <summary>
        /// Update SubmitActivation Document Details
        /// </summary>
        /// <param name="documents"></param>
        /// <returns>true/false</returns>
        public bool SubmitAmedmentProtocolDocument(Data.Documents documents)
        {

            if (documents != null)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == documents.StudyId && x.SubModuleName == Utilities.Messages.AMENDMENTMANDATORYDOCUMENTS && x.DocumentName == documents.DocumentName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsSubmit = true;
                    result.IsActivated = false;
                    result.SubModuleId = documents.SubModuleId;
                    result.DocumentStatus = Utilities.Messages.PENDINGREVIEW;
                    result.DocumentType = documents.DocumentType;
                    result.Path = documents.Path;
                    result.DocumentSize = documents.DocumentSize;
                    result.ANJU_ChangedBy = documents.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;             
                    var val = dbContextNavigate.SaveChanges(result, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Update);
                    if (val > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    DataAccess.Documents objDocuments = new DataAccess.Documents()
                    {
                        DocumentName = documents.DocumentName,
                        DocumentSize = documents.DocumentSize,
                        DocumentExtension = documents.DocumentExtension,
                        DocumentNameWithOutExtension = documents.DocumentNameWithOutExtension,
                        SubModuleName = documents.SubModuleName,
                        StudyId = documents.StudyId,
                        Path = documents.Path,
                        DocumentStatus = documents.DocumentStatus,
                        DocumentType = documents.DocumentType,
                        DocumentSubType = documents.DocumentSubType,
                        DocumentVersion = documents.DocumentVersion,
                        OriginalDate = documents.OriginalDate,
                        ExpirationDate = documents.ExpirationDate,
                        IsActivated = documents.IsActivated,
                        IsSubmit = documents.IsSubmit,
                        IsActive = documents.IsActive,
                        IsDeleted = documents.IsDeleted,
                        ANJU_AddedBy = documents.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow

                    };                    
                    documents.DocumentId = objDocuments.DocumentId;
                    var val = dbContextNavigate.SaveChanges(objDocuments, new Documents_H(), documents.ANJU_AddedBy, eAuditChangeType.Insert);
                    if (val > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            else
                return false;

        }

        /// <summary>
        /// Get Activation Documents By StudyID
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="subModuleName"></param>
        /// <returns>List of documents</returns>
        public List<Data.Documents> GetActivationDocumentsByStudyID(int studyId, string subModuleName)
        {
            if (studyId > 0)
            {
                var result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.SubModuleName == subModuleName && x.IsActive == true && x.IsDeleted == false && x.IsSubmit == false && x.IsActivated == false)
                             .GroupJoin(dbContextNavigate.SysCodeValues,
                                                       D => new { DocumentType = D.DocumentType?.ToString() },
                                                       Sy => new { DocumentType = Sy.Code?.ToString() },
                                                       (D, Sy) => new { D, Sy }).ToList()
                            .Select(x => new Data.Documents
                            {
                                DocumentId = x.D.DocumentId,
                                DocumentName = x.D.DocumentName,
                                DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                StudyId = x.D.StudyId,
                                SubModuleId = x.D.SubModuleId,
                                SubModuleName = x.D.SubModuleName,
                                DocumentSize = x.D.DocumentSize,
                                DocumentExtension = x.D.DocumentExtension,
                                Path = x.D.Path,
                                DocumentStatus = x.D.DocumentStatus,
                                DocumentType = x.D.DocumentType,
                                DocumentSubType = x.D.DocumentSubType,
                                DocumentVersion = x.D.DocumentVersion,
                                OriginalDate = x.D.OriginalDate,
                                ExpirationDate = x.D.ExpirationDate,
                                ANJU_AddedBy=x.D.ANJU_AddedBy,
                                DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault()
                            }).ToList();
                if (result != null)
                    return result;
                else
                    return new List<Data.Documents>();
            }
            else
                return new List<Data.Documents>();
        }

        /// <summary>
        /// Get Activation Documents By StudyID
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="subModuleName"></param>
        public Data.NewStudy GetStudyInformation(int studyId)
        {

            var result = dbContextNavigate.NewStudy.AsEnumerable().Where(x => x.StudyId == studyId)
                        .Select(x => new Data.NewStudy
                        {
                            StudyId = x.StudyId,
                            Stage = x.Stage,
                            TaskStatus = x.TaskStatus,
                            State = x.State,
                            TitleofTrial=x.TitleofTrial,
                            ANJU_AddedBy=x.ANJU_AddedBy
                            

                        }).SingleOrDefault();
            if (result != null)
                return result;
            else
                return new Data.NewStudy();
        }

        #endregion
    }
}


