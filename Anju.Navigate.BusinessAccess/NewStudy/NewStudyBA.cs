using Anju.Navigate.DataAccess;
using Anju.Navigate.Utilities;
using System.Collections.Generic;

namespace Anju.Navigate.BusinessAccess
{
    public class NewStudyBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public NewStudyBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods 

        /// <summary>
        /// Read all Drop down values from Sys Code table,drop downs are differentiated by types
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List</returns>        
        public List<Data.SysCodeValues> GetSysCodeValues(string type)
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName(type);
        }

        public List<Data.SysCodeValues> GetInterventionStatus()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("InterventionStatus");
        }

        /// <summary>
        /// Get the Ages
        /// </summary>
        /// <returns>lstAge</returns>
        public List<Data.SysCodeValues> GetAge(string agerange)
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName(agerange);
        }

        /// <summary>
        /// Get Study Descriptors
        /// </summary>
        /// <returns>lstSysCodes</returns>
        public List<Data.SysCodeValues> GetStudyDescriptors()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("StudyDescriptors");
        }

        /// <summary>
        /// Get Patient Type
        /// </summary>
        /// <returns>lstSysCodes</returns>
        public List<Data.SysCodeValues> GetPatientType()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("PatientType");
        }

        /// <summary>
        /// Get the Objectives and Endpoints
        /// </summary>
        /// <returns>lstAge</returns>
        public List<Data.ObjectivesandEndpoints> GetObjectivesandEndpoints(int studyId)
        {
            return unitOfWork.ObjectivesandEndpoints.GetObjectivesandEndpoints(studyId);
        }


        /// <summary>
        /// Get Milestones
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Milestones> GetMilestones(int studyId)
        {
            return unitOfWork.Milestones.GetMilestones(studyId);
        }



        /// <summary>
        /// Get Patient Accrual
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.PatientAccrual> GetPatientAccrual(int studyId)
        {
            return unitOfWork.PatientAccrual.GetPatientAccrual(studyId);
        }


        /// <summary>
        /// Get Invoices details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Invoicedetails> GetInvoicesdetails(int studyId)
        {
            return unitOfWork.Invoicesdeatils.GetInvoicesdetails(studyId);
        }



        /// <summary>
        /// Get Contracts Timeline
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Contracttimelines> GetContractsTimeline(int studyId)
        {
            return unitOfWork.ContractTimelines.GetContractsTimeline(studyId);
        }



        /// <summary>
        /// Get Status 
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Status> GetStatusdetails(int studyId)
        {
            return unitOfWork.status.GetStatusdetails(studyId);
        }


        /// <summary>
        /// Get Reviews and Notes
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.ReviewsandNotes> GetReviewsandNotes(int studyId)
        {
            return unitOfWork.Reviewsandnotes.GetReviewsandNotes(studyId);
        }



        /// <summary>
        /// create/update the Objectives and Endpoints
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateObjectivesandEndpoints(Data.ObjectivesandEndpoints objectivesandEndpoints, string mode, int studyId, string userName)
        {
            return unitOfWork.ObjectivesandEndpoints.CreateUpdateObjectivesandEndpoints(objectivesandEndpoints, mode, studyId, userName);

        }


        /// <summary>
        /// create/update the default milestones
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone,string userName)
        {
            return unitOfWork.Milestones.CreateUpdateDefaultMilestoneDetails(defaultMileStone, userName);

        }

        /// <summary>
        /// Delete default milestones
        /// </summary>
        /// <param name="defaultMileStone"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone, string userName)
        {
            return unitOfWork.Milestones.DeleteDefaultMilestoneDetails(defaultMileStone, userName);
        }

        /// <summary>
        /// create/update the EditStudyAttributes
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateEditStudyAttribute(Data.EditStudyAttributes editStudyAttributes,string userName)
        {
            return unitOfWork.EditStudy.CreateUpdateEditStudyAttribute(editStudyAttributes, userName);

        }

        /// <summary>
        /// Delete Objectives and End points
        /// </summary>
        /// <param name="objectivesandEndpoints"></param>
        /// <returns>true/false</returns>
        public bool DeleteObjectivesandEndpoints(Data.ObjectivesandEndpoints objectivesandEndpoints, string userName)
        {
            return unitOfWork.ObjectivesandEndpoints.DeleteObjectivesandEndpoints(objectivesandEndpoints, userName);
        }


        /// <summary>
        /// Delete Milestones
        /// </summary>
        /// <param name="milestones"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteMilestones(Data.Milestones milestones, string userName)
        {
            return unitOfWork.Milestones.DeleteMilestones(milestones, userName);
        }

        /// <summary>
        /// Delete submissions
        /// </summary>
        /// <param name="submissions"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteSubmissions(Data.Submissions submissions, string userName)
        {
            return unitOfWork.Submissions.DeleteSubmissions(submissions, userName);
        }

        /// <summary>
        /// Delete Patient Accrual
        /// </summary>
        /// <param name="patientaccrual"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeletePatientAccrual(Data.PatientAccrual patientaccrual, string userName)
        {
            return unitOfWork.PatientAccrual.DeletePatientAccrual(patientaccrual, userName);
        }



        /// <summary>
        /// Delete Contacts
        /// </summary>
        /// <param name="principalInvestigator"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteContacts(Data.PrincipalInvestigator principalInvestigator, string userName)
        {
            return unitOfWork.NewStudy.DeleteContacts(principalInvestigator, userName);
        }




        /// <summary>
        /// Create/Update Cohort Levels
        /// </summary>
        /// <param name="cohortLevels"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateCohortLevels(Data.CohortLevels cohortLevels, string mode, int studyId, string userName)
        {
            bool result = unitOfWork.CohortLevels.CreateUpdateCohortLevels(cohortLevels,studyId, userName);
            return result;
        }

        /// <summary>
        /// Get the CohortLevels
        /// </summary>
        /// <returns>List</returns>
        public List<Data.CohortLevels> GetCohortLevels(int studyId)
        {
            return unitOfWork.CohortLevels.GetCohortLevels(studyId);
        }

        /// <summary>
        /// Delete Cohort Levels
        /// </summary>
        /// <param name="cohortLevels"></param>
        /// <returns>true/false</returns>
        public bool DeleteCohortLevels(Data.CohortLevels cohortLevels, string userName)
        {
            return unitOfWork.CohortLevels.DeleteCohortLevels(cohortLevels, userName);
        }


        /// <summary>
        /// Delete Study Indications
        /// </summary>
        /// <param name="indications"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudyIndications(Data.StudyIndication indications, string userName)
        {
            return unitOfWork.StudyIndication.DeleteStudyIndications(indications, userName);
        }


        /// <summary>
        /// Delete Study Protocols
        /// </summary>
        /// <param name="studyprotocol"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudyProtocols(Data.StudyProtocol studyprotocol, string userName)
        {
            return unitOfWork.StudyProtocol.DeleteStudyProtocols(studyprotocol, userName);
        }


        /// <summary>
        /// Get Objective Types
        /// </summary>
        /// <returns>List</returns>
        public List<Data.SysCodeValues> GetObjectiveTypes()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName(ConstDefaultValue.OBJECTIVETYPES);
        }

        /// <summary>
        /// Get Objective Name
        /// </summary>
        /// <returns>List</returns>
        public List<Data.SysCodeValues> GetObjectiveName()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName(ConstDefaultValue.OBJECTIVENAMES);
        }

        /// <summary>
        /// Get the Type of trial drug
        /// </summary>
        /// <returns>List</returns>
        public List<Data.SysCodeValues> GetTypeoftrialdrug()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("Typeoftrialdrug");
        }


        /// <summary>
        ///  Get Investigator Qualifications Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetInvestigatorQualificationsData(int studyId)
        {
            return unitOfWork.NewStudy.GetInvestigatorQualificationsData(studyId);
        }

        /// <summary>
        /// Get Science Main Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetScienceMainData(int studyId)
        {
            return unitOfWork.NewStudy.GetScienceMainData(studyId);
        }


        /// <summary>
        /// Get Diseases Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetDiseasesData(int studyId)
        {
            return unitOfWork.NewStudy.GetDiseasesData(studyId);
        }


        /// <summary>
        /// Get Correlative Sciences Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetCorrelativeSciencesData(int studyId)
        {
            return unitOfWork.NewStudy.GetCorrelativeSciencesData(studyId);
        }


        /// <summary>
        /// Get Pharmacovigilance Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetPharmacovigilanceData(int studyId)
        {
            return unitOfWork.NewStudy.GetPharmacovigilanceData(studyId);
        }


        /// <summary>
        /// Get Study Enrollment and Timelines Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetStudyEnrollmentandTimelinesData(int studyId)
        {
            return unitOfWork.NewStudy.GetStudyEnrollmentandTimelinesData(studyId);
        }



        /// <summary>
        /// Get Pandemic preparedness trial categorization Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetPandemicpreparednesstrialcategorizationData(int studyId)
        {
            return unitOfWork.NewStudy.GetPandemicpreparednesstrialcategorizationData(studyId);
        }


        /// <summary>
        /// Get IRB Requirement Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetIRBRequirementData(int studyId)
        {
            return unitOfWork.NewStudy.GetIRBRequirementData(studyId);
        }


        /// <summary>
        /// Get key references Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetkeyreferencesData(int studyId)
        {
            return unitOfWork.NewStudy.GetkeyreferencesData(studyId);
        }


        public List<Data.NewStudy> GetoriginalfinancialrequestData(int studyId)
        {
            return unitOfWork.NewStudy.GetoriginalfinancialrequestData(studyId);
        }



        /// <summary>
        /// Get Regulatory requirements Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetRegulatoryrequirementsData(int studyId)
        {
            return unitOfWork.NewStudy.GetRegulatoryrequirementsData(studyId);
        }


        /// <summary>
        /// Get Research Group Description Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetResearchGroupDescriptionData(int studyId)
        {
            return unitOfWork.NewStudy.GetResearchGroupDescriptionData(studyId);
        }



        /// <summary>
        /// Create/Update Treatment Information
        /// </summary>
        /// <param name="treatmentInformation"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateTreatmentInformation(Data.TreatmentInformation treatmentInformation, string mode, int studyId, string userName)
        {
            return unitOfWork.TreatmentInformation.CreateUpdateTreatmentInformation(treatmentInformation, mode, studyId, userName);
        }

        /// <summary>
        /// </summary>
        /// Get the Treatment Information
        /// <returns>List</returns>
        public List<Data.TreatmentInformation> GetTreatmentInformation(int studyId)
        {
            return unitOfWork.TreatmentInformation.GetTreatmentInformation(studyId);
        }

        /// <summary>
        /// Delete the Treatment Informations
        /// </summary>
        /// <param name="treatmentInformation"></param>
        /// <returns>true/false</returns>
        public bool DeleteTreatmentInformations(Data.TreatmentInformation treatmentInformation, string userName)
        {
            return unitOfWork.TreatmentInformation.DeleteTreatmentInformations(treatmentInformation, userName);
        }

        /// <summary>
        /// Get the New Study ID
        /// </summary>
        /// <returns>StudyID</returns>
        public int GetNewStudyID()
        {
            return unitOfWork.NewStudy.GetNewStudyID();
        }

        /// <summary>
        /// Create/Update Scientific Rationale I
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="newStudy"></param>
        /// <param name="trialPhase"></param>
        /// <param name="drugorCompoundDetails"></param>
        /// <param name="conceptDesignandRationale"></param>
        /// <param name="userName"></param>
        /// <param name="gender"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateScientificRationaleI(int studyId, Data.NewStudy newStudy,
                                                  Data.TrialPhase trialPhase, Data.DrugorCompounddetails drugorCompoundDetails,
                                                  Data.ConceptDesignandRationale conceptDesignandRationale, string userName, string[] gender, string mode)
        {
            bool result = false;
            if (newStudy.StudyType == "Interventional")
                unitOfWork.TrialPhase.CreateUpdateTrialPhase(studyId, trialPhase, mode, userName);
            unitOfWork.DrugorCompounddetails.CreateUpdaterDrugorCompounddetails(studyId, drugorCompoundDetails,userName);
            unitOfWork.ConceptDesignandRationale.CreateUpdateConceptDesignandRationale(studyId, conceptDesignandRationale, gender, mode,userName);

            result = unitOfWork.NewStudy.CreateUpdateNewStudyForScientificRationaleI(newStudy, userName);

            return result;
        }

        /// <summary>
        ///  Create/Update Scientific Rationale II
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="newStudy"></param>
        /// <param name="CorrelativeScienceStudies"></param>
        /// <param name="plannedTrialMilestoneDatesandEnrollment"></param>
        /// <param name="pharmacovigilanceRequirements"></param>
        /// <param name="userName"></param>
        /// <returns>result</returns>
        public bool CreateUpdateScientificRationaleII(int studyId, Data.NewStudy newStudy,
                                                 Data.CorrelativeScienceStudies CorrelativeScienceStudies,
                                                 Data.PlannedTrialMilestoneDatesandEnrollment plannedTrialMilestoneDatesandEnrollment,
                                                 Data.PharmacovigilanceRequirements pharmacovigilanceRequirements,
                                                 string userName)
        {
            bool result = false;


            unitOfWork.CorrelativeScienceStudies.CreateUpdaterCorrelativeScienceStudies(studyId, CorrelativeScienceStudies,userName);
            unitOfWork.PlannedTrialMilestoneDatesandEnrollment.CreateUpdatePlannedTrialMilestoneDatesandEnrollment(studyId, plannedTrialMilestoneDatesandEnrollment, userName);
            unitOfWork.PharmacovigilanceRequirements.CreateUpdatePharmacovigilanceRequirements(studyId, pharmacovigilanceRequirements, userName);

            result = unitOfWork.NewStudy.CreateUpdateNewStudyForScientificRationaleII(studyId, newStudy, userName);

            return result;
        }

        /// <summary>
        /// Get the Last Entered Study Id
        /// </summary>
        /// <returns>int</returns>
        public int GetLastEnteredStudyId()
        {
            return unitOfWork.NewStudy.GetLastEnteredStudyId();
        }

        /// <summary>
        /// Get Scientific Rationale I Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetScientificRationaleIDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetScientificRationaleIDetails(studyId);
        }

        /// <summary>
        /// Get Scientific Rationale II Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetScientificRationaleIIDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetScientificRationaleIIDetails(studyId);
        }

        /// <summary>
        ///Get the Personal and Research Site Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetPersonalandResearchSiteDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetPersonalandResearchSiteDetails(studyId);
        }

        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.NewStudy> GetContacts(int studyId)
        {
            return unitOfWork.NewStudy.GetContacts(studyId);
        }


        /// <summary>
        /// Get Study Sites
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudySites> GetStudySites(int studyId)
        {
            return unitOfWork.StudySites.GetStudySites(studyId);
        }



        /// <summary>
        /// Get Study Id For PI
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetStudyIdForPI(string userName,string typeOfGrid)
        {
            return unitOfWork.NewStudy.GetStudyIdForPI(userName, typeOfGrid);
        }

        /// <summary>
        /// Get Study Id For IISAdmin
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetStudyDetails(string userType, string loginUserName)
        {
            return unitOfWork.NewStudy.GetStudyDetails(userType, loginUserName);
        }

        /// <summary>
        /// Get Study owner details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public string GetStudyOwnerDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetStudyOwnerDetails(studyId);
        }
        /// <summary>
        /// Get Task details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetTaskDetails(string userName, string userType)
        {
            return unitOfWork.NewStudy.GetTaskDetails(userName, userType);
        }

        /// <summary>
        /// Get milestone details
        /// </summary>       
        /// <returns>List</returns>
        public List<Data.DefaultMileStone> GetDefaultMilestoneDetails()
        {
            return unitOfWork.NewStudy.GetDefaultMilestoneDetails();
        }

        /// <summary>
        /// Get the EmailList
        /// </summary>
        /// <param name="StudyID"></param>
        /// <returns>list of EmailList</returns>
        public List<Data.EmailList> GetEmailList(int studyId)
        {
            return unitOfWork.NewStudy.GetEmailList(studyId);
        }

        /// <summary>
        /// Get the Documents
        /// </summary>
        /// <param name="StudyID"></param>
        /// <returns>list of documents</returns>
        public List<Data.Documents> GetDocumentList(int studyId)
        {
            return unitOfWork.NewStudy.GetDocumentList(studyId);
        }

        /// <summary>
        /// Get the Documents types
        /// </summary>       
        /// <returns>list of documents</returns>
        public List<Data.Documents> GetdocumentType()
        {
            return unitOfWork.NewStudy.GetDocumentTypes();
        }

        /// <summary>
        /// Get the PI Documents
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="userName"></param>
        /// <returns>list of documents</returns>
        public List<Data.Documents> GetPIDocumentList(int studyId, string userName)
        {
            return unitOfWork.NewStudy.GetPIDocumentList(studyId, userName);
        }
        /// <summary>
        /// Get the CooperativeGroupName
        /// </summary>
        /// <returns>List</returns>
        public List<Data.SysCodeValues> GetCooperativeGroupName()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("CooperativeGroupName");
        }

        /// <summary>
        ///This method is used to Create,Update and Delete EmailList
        /// </summary>
        /// <param name="emailList"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <returns>EmailList </returns>
        public Data.EmailList CreateUpdateAndDeleteEmailList(Data.EmailList emailList, string mode, int studyId, string userName)
        {
            return unitOfWork.NewStudy.CreateUpdateAndDeleteEmailList(emailList, mode, studyId, userName);
        }

        /// <summary>
        /// Create/Update Personal and Research details
        /// </summary>
        /// <param name="principalInvestigator"></param>
        /// <param name="newProposalSubmission"></param>
        /// <param name="studyId"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdatePersonalResearchdetails(List<Data.PrincipalInvestigator> lsPrincipalInvestigator, Data.NewStudy newProposalSubmission, int studyId, string mode, string userName)
        {
            return unitOfWork.NewStudy.CreateUpdatePersonalResearchdetails(studyId, lsPrincipalInvestigator,  newProposalSubmission, mode, userName);
        }

        /// <summary>
        /// Get Center
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Center> GetCenter(int studyId)
        {
            return unitOfWork.Center.GetCenter(studyId);
        }

        /// <summary>
        /// Create Update Center
        /// </summary>
        /// <param name="objCenter"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CreateUpdateCenter(Data.Center objCenter, string mode, int studyId, string userName)
        {
            return unitOfWork.Center.CreateUpdateCenter(objCenter,studyId, userName);
        }

        /// <summary>
        /// Delete Center
        /// </summary>
        /// <param name="objCenter"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteCenter(Data.Center objCenter, string userName)
        {
            return unitOfWork.Center.DeleteCenter(objCenter, userName);
        }

        /// <summary>
        /// File upload
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool Fileupload(Data.Documents documents)
        {
            return unitOfWork.NewStudy.createDocument(documents);
        }


        /// <summary>
        /// Create/Update Manual Type Documents
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public bool CreateUpdateManualTypeDocuments(Data.Documents documents)
        {
            return unitOfWork.NewStudy.CreateUpdateManualTypeDocuments(documents);
        }


        /// <summary>
        /// Create/Update Submissions in Ad dMode
        /// </summary>
        /// <param name="submissions"></param>
        /// <returns>submissions</returns>
        public bool CreateUpdateSubmissionsAddMode(Data.Submissions submissions)
        {
            return unitOfWork.Submissions.CreateUpdateSubmissionsAddMode(submissions);
        }




        /// <summary>
        /// Delete Uploaded File
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <param name="subModuleName"></param>
        /// <returns>true/false</returns>
        public bool DeleteUploadedFile(int studyId, string userName, string subModuleName, string documentName)
        {
            return unitOfWork.NewStudy.DeleteUploadedFile(studyId, userName, subModuleName, documentName);
        }




        /// <summary>
        /// Verify wheather document name is unique or not
        /// </summary>
        /// <param name="documentsName"></param>
        /// <param name="studyId"></param>
        /// <returns>true/false</returns>
        public bool IsDocumentNameIsUnique(string documentsName, int studyId, string moduleName)
        {
            return unitOfWork.NewStudy.IsDocumentNameIsUnique(documentsName, studyId, moduleName);
        }


        /// <summary>
        /// Delete Documents By StudyId Or SubModuleName
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="documentId"></param>
        /// <param name="userName"></param>
        /// <param name="subModuleName"></param>
        /// <returns></returns>
        public bool DeleteDocuments(Data.Documents documents)
        {
            return unitOfWork.NewStudy.DeleteDocuments(documents);
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
            return unitOfWork.NewStudy.UndeleteDocuments(docid, studyid, username);
        }




        /// <summary>
        /// Get Documents By StudyID and subModuleName
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentsByStudyID(int studyId, string subModuleName)
        {
            if(subModuleName==Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT || subModuleName == Utilities.Messages.UPDATEDDOCUMENTS) 
                return unitOfWork.NewStudy.GetActivationDocumentsByStudyID(studyId, subModuleName);
            else
                return unitOfWork.NewStudy.GetDocumentsByStudyID(studyId, subModuleName);
        }



        /// <summary>
        /// Get Specific Documents By StudyID for a document from grid
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="docid"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetSpecificDocumentsByStudyID(int studyId,int docid)
        {
             return unitOfWork.NewStudy.GetSpecificDocumentsByStudyID(studyId, docid);
        }


        /// <summary>
        /// Get Submissions By Study ID
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="docid"></param>
        /// <returns>List</returns>
        public List<Data.Submissions> GetSubmissionsByStudyID(int studyId)
        {
                return unitOfWork.Submissions.GetSubmissionsByStudyID(studyId);
        }


        /// <summary>
        /// Get Specific Submissions By Study ID
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="docid"></param>
        /// <returns>List</returns>
        public List<Data.Submissions> GetSpecificSubmissionsByStudyID(int studyId, int docid)
        {
            return unitOfWork.Submissions.GetSpecificSubmissionsByStudyID(studyId, docid);
        }



        /// <summary>
        ///Get Requested Support Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetRequestedSupportDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetRequestedSupportDetails(studyId);
        }

        /// <summary>
        /// Create and Update Requested Support Details
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateRequestedSupportDetails(int studyId, Data.NewStudy newStudy, string userName, Data.Documents objDocument)
        {
            return unitOfWork.NewStudy.CreateUpdateRequestedSupportDetails(studyId, newStudy, userName,objDocument);
        }


        /// <summary>
        /// Delete Study Sites
        /// </summary>
        /// <param name="studySites"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudySites(Data.StudySites studySites, string userName)
        {
            return unitOfWork.StudySites.DeleteStudySites(studySites, userName);
        }



        /// <summary>
        /// Delete Study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="username"></param>
        public void DeleteStudy(int studyId, string username)
        {
            unitOfWork.NewStudy.DeleteStudy(studyId, username);
        }


        /// <summary>
        /// Delete Invoice details
        /// </summary>
        /// <param name="invoicedetails"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteInvoicedetails(Data.Invoicedetails invoicedetails, string username)
        {
            return unitOfWork.Invoicesdeatils.DeleteInvoicedetails(invoicedetails, username);
        }



        /// <summary>
        /// Delete Contracts Timeline
        /// </summary>
        /// <param name="gmrcapprovaltask"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteContractsTimeline(Data.Contracttimelines contracttimelines, string username)
        {
            return unitOfWork.ContractTimelines.DeleteContractsTimelinedetails(contracttimelines, username);
        }


        /// <summary>
        /// Delete Status
        /// </summary>
        /// <param name="statusdetails"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteStatusdetails(Data.Status statusdetails, string username)
        {
            return unitOfWork.status.DeleteStatusdetails(statusdetails, username);
        }



        /// <summary>
        /// Delete Reviews and Notes
        /// </summary>
        /// <param name="reviewsandnotes"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteReviewsandNotes(Data.ReviewsandNotes reviewsandnotes, string username)
        {
            return unitOfWork.Reviewsandnotes.DeleteReviewsandNotes(reviewsandnotes, username);
        }


        /// <summary>
        /// Update Confirmation Details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateConfirmationDetails(Data.NewStudy newStudy)
        {
            return unitOfWork.NewStudy.UpdateConfirmationDetails(newStudy);
        }

        /// <summary>
        /// Get username By studyId and usertype
        /// </summary>
        /// <param name="studyId"></param>       
        /// <param name="userType"></param>       
        /// <returns>InstituteName</returns>
        public string GetUserNameByUserTypeAndStudyId(int studyId,string userType)
        {
            return unitOfWork.NewStudy.GetUserNameByUserTypeAndStudyId(studyId, userType);
        }


        /// <summary>
        /// Get Other Attributes Data
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetOtherAttributesData(int studyId)
        {
            return unitOfWork.NewStudy.GetOtherAttributesData(studyId);
        }




        /// <summary>
        /// Get Institute By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>InstituteName</returns>
        public string GetMSLChangedInstituteBystudyId(int studyId)
        {
            return unitOfWork.NewStudy.GetMSLChangedInstituteBystudyId(studyId);
        }

        /// <summary>
        /// Get Institute By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>InstituteName</returns>
        public string GetPIInstituteByStudyID(int studyId)
        {
            return unitOfWork.NewStudy.GetPIInstituteByStudyID(studyId);
        }

        /// <summary>
        /// Get Indication By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>Indication</returns>
        public string GetPIIndicationByStudyID(int studyId)
        {
            return unitOfWork.NewStudy.GetPIIndicationByStudyID(studyId);
        }

        /// <summary>
        /// Get title of trial By StudyID
        /// </summary>
        /// <param name="studyId"></param>       
        /// <returns>Indication</returns>
        public string GetPITitleOfTrialByStudyID(int studyId)
        {
            return unitOfWork.NewStudy.GetPITitleOfTrialByStudyID(studyId);
        }

        /// <summary>
        /// Get Attribute Values
        /// </summary>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> GetAttributeValues(int attributeid)
        {
            return unitOfWork.EditStudy.GetAttributeValues(attributeid);
        }



        public List<Data.EditStudyAttributes> GetTabTitles(string tabtype,string category)
        {
            return unitOfWork.EditStudy.GetTabTitles(tabtype, category);
        }



        /// <summary>
        /// Get Study Task Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of Study</returns>
        public List<Data.NewStudy> GetStudyTaskDetails(int studyId)
        {
            return unitOfWork.NewStudy.GetStudyTaskDetails(studyId);
        }

            /// <summary>
            /// Get Attributes
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public List<Data.EditStudyAttributes> GetAttributes(string name, int checkId)
        {
            return unitOfWork.EditStudy.GetAttributesList(name, checkId);
        }

        /// <summary>
        /// Create Update Study Compounds
        /// </summary>
        /// <param name="cohortLevels"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CreateUpdateStudyCompounds(Data.StudyCompounds studyCompounds, string mode, int studyId, string userName)
        {
            bool result = unitOfWork.StudyCompounds.CreateUpdateStudyCompounds(studyCompounds,studyId, userName);
            return result;
        }

        /// <summary>
        /// Get Study Compounds
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyCompounds> GetStudyCompounds(int studyId)
        {
            return unitOfWork.StudyCompounds.GetStudyCompounds(studyId);
        }


        /// <summary>
        /// Get Study Indications
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyIndication> GetIndications(int studyId)
        {
            return unitOfWork.StudyIndication.GetIndications(studyId);
        }


        /// <summary>
        /// Get Study Protocols
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.StudyProtocol> GetStudyProtocols(int studyId)
        {
            return unitOfWork.StudyProtocol.GetStudyProtocols(studyId);
        }


        /// <summary>
        /// Delete Study Compounds
        /// </summary>
        /// <param name="studyCompounds"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteStudyCompounds(Data.StudyCompounds studyCompounds, string userName)
        {
            return unitOfWork.StudyCompounds.DeleteStudyCompounds(studyCompounds, userName);
        }


        /// <summary>
        /// Save/Update Edit details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool SaveUpdateEditdetails(Data.NewStudy newStudy, int type,string usertype, string mode,string userName)
        {
            bool result = false;
            switch (type)
            {
                case 1:
                    result = unitOfWork.NewStudy.CreateUpdateScienceMaindetails(newStudy, usertype,userName);
                    break;
                case 2:
                    result = unitOfWork.NewStudy.CreateUpdateDiseasedetails(newStudy, usertype);
                    break;
                case 3:
                    result = unitOfWork.CorrelativeScienceStudies.CreateUpdateCorrelativeScienceStudies(newStudy, usertype);
                    break;
                case 4:
                    result = unitOfWork.StudyIndication.CreateUpdateIndications(newStudy, usertype);
                    break;
                case 5:
                    result = unitOfWork.PharmacovigilanceRequirements.CreateUpdatePharmacovigilanceRequirements(newStudy, usertype,userName);
                    break;
                case 6:
                    result = unitOfWork.NewStudy.CreateUpdateEnrollmentandTimelines(newStudy, usertype,userName);
                    break;
                case 7:
                    result = unitOfWork.NewStudy.CreateUpdateIRBRegistrationRequirement(newStudy, usertype);
                    break;
                case 8:
                    result = unitOfWork.NewStudy.CreateUpdatePandemicpreparednesstrial(newStudy, usertype);
                    break;
                case 9:
                    result = unitOfWork.NewStudy.CreateUpdateRegulatoryRequirements(newStudy, usertype);
                    break;
                case 10:
                    result = unitOfWork.NewStudy.CreateUpdateKeyreferences(newStudy, usertype);
                    break;
                case 11:
                    result = unitOfWork.NewStudy.CreateUpdateContacts(newStudy, usertype);
                    break;
                case 13:
                    result = unitOfWork.NewStudy.CreateUpdateInvestigatorQualifications(newStudy, usertype);
                    break;
                case 14:
                    Data.CohortLevels objcohort = new Data.CohortLevels();
                    objcohort.CohortId = newStudy.CohortId;
                    objcohort.NoofPatients = newStudy.NoofPatients;
                    objcohort.Cohortlevel = newStudy.Cohortlevel;
                    objcohort.DoseandFrequencyDrugA = newStudy.DoseandFrequencyDrugA;
                    objcohort.DoseandFrequencyDrugB = newStudy.DoseandFrequencyDrugB;
                    if (mode == "Create")
                        result = unitOfWork.CohortLevels.CreateUpdateCohortLevels(objcohort,newStudy.StudyId, newStudy.ANJU_AddedBy);
                    else
                        result = unitOfWork.CohortLevels.CreateUpdateCohortLevels(objcohort,newStudy.StudyId, newStudy.ANJU_ChangedBy);
                    break;
                case 15:
                    Data.TreatmentInformation objtreatmentInformation = new Data.TreatmentInformation();
                    objtreatmentInformation.TreatmentInfoId = newStudy.TreatmentInfoId;
                    objtreatmentInformation.TreatmentArm = newStudy.TreatmentArm;
                    objtreatmentInformation.NoofPatientsPlanned = newStudy.NoofPatientsPlanned;
                    objtreatmentInformation.TypeofTrialDrug = newStudy.TypeofTrialDrug;
                    objtreatmentInformation.Compound = newStudy.Compound;
                    objtreatmentInformation.Mindosage = newStudy.Mindosage;
                    objtreatmentInformation.Maxdosage = newStudy.Maxdosage;
                    objtreatmentInformation.Frequency = newStudy.Frequency;
                    objtreatmentInformation.AdminRoute = newStudy.AdminRoute;
                    objtreatmentInformation.GenericAcceptable = newStudy.GenericAcceptable;
                    if (mode == "Create")
                        result = unitOfWork.TreatmentInformation.CreateUpdateTreatmentInformation(objtreatmentInformation, mode, newStudy.StudyId, newStudy.ANJU_AddedBy);
                    else
                        result = unitOfWork.TreatmentInformation.CreateUpdateTreatmentInformation(objtreatmentInformation, mode, newStudy.StudyId, newStudy.ANJU_ChangedBy);
                    break;
                case 16:
                    Data.StudyCompounds objstudycompounds = new Data.StudyCompounds();
                    objstudycompounds.StudyComponentId = newStudy.StudyComponentId;
                    objstudycompounds.CompoundType = newStudy.CompoundType;
                    objstudycompounds.CompoundCategory = newStudy.CompoundCategory;
                    objstudycompounds.CompanyCompound = newStudy.CompanyCompound;
                    objstudycompounds.NonCompanyCompound = newStudy.NonCompanyCompound;
                    if (mode == "Create")
                        result = unitOfWork.StudyCompounds.CreateUpdateStudyCompounds(objstudycompounds,newStudy.StudyId, newStudy.ANJU_AddedBy);
                    else
                        result = unitOfWork.StudyCompounds.CreateUpdateStudyCompounds(objstudycompounds,newStudy.StudyId, newStudy.ANJU_ChangedBy);
                    break;
                case 17:
                    Data.ObjectivesandEndpoints objectivesandEndpoints = new Data.ObjectivesandEndpoints();
                    objectivesandEndpoints.ObjandEndPointsId = newStudy.ObjandEndPointsId;
                    objectivesandEndpoints.ObjectiveName = newStudy.ObjectiveName;
                    objectivesandEndpoints.ObjectiveType = newStudy.ObjectiveType;
                    objectivesandEndpoints.ObjectiveDescription = newStudy.ObjectiveDescription;
                    objectivesandEndpoints.EndpointDescription = newStudy.EndpointDescription;
                    if (mode == "Create")
                        result = unitOfWork.ObjectivesandEndpoints.CreateUpdateObjectivesandEndpoints(objectivesandEndpoints, usertype, newStudy.StudyId, newStudy.ANJU_AddedBy);
                    else
                        result = unitOfWork.ObjectivesandEndpoints.CreateUpdateObjectivesandEndpoints(objectivesandEndpoints, mode, newStudy.StudyId, newStudy.ANJU_ChangedBy);
                    break;
                case 18:
                    result = unitOfWork.StudyProtocol.CreateUpdateStudyprotocolnos(newStudy, usertype);
                    break;
                case 19:
                    result = unitOfWork.StudySites.CreateUpdateStudysites(newStudy, usertype);
                    break;
                case 20:
                    result = unitOfWork.NewStudy.CreateUpdateResearchGroupDescription(newStudy, usertype);
                    break;
                case 21:
                    result = unitOfWork.NewStudy.CreateUpdateOriginalFinancialRequest(newStudy, usertype);
                    break;
                case 22:
                    result = unitOfWork.NewStudy.CreateUpdateEmailLists(newStudy, usertype);
                    break;
                case 23:
                    result = unitOfWork.Milestones.CreateUpdateMilestones(newStudy, usertype);
                    break;
                case 24:
                    result = unitOfWork.PatientAccrual.CreateUpdatePatientAccrual(newStudy, usertype);
                    break;
                case 25:
                    result = unitOfWork.Invoicesdeatils.CreateUpdateInvoices(newStudy, usertype);
                    break;
                case 26:
                    result = unitOfWork.GMRCApprovalTask.CreateUpdateGMRCApprovalTask(newStudy, usertype, userName);
                    break;
                case 27:
                    result = unitOfWork.status.CreateUpdateStatus(newStudy, usertype);
                    break;
                case 28:
                    result = unitOfWork.Reviewsandnotes.CreateUpdateReviewsandNotes(newStudy, usertype);
                    break;
                case 29:
                    result = unitOfWork.Submissions.CreateUpdateSubmissions(newStudy, usertype);
                    break;
                case 30:
                    result = unitOfWork.NewStudy.CreateUpdateOtherAttributesdetails(newStudy, usertype, userName);
                    break;
                case 31:
                    result = unitOfWork.UserRoles.CreateUpdateRoles(newStudy, usertype, userName);
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Get banner details
        /// </summary>        
        /// <returns></returns>
        public List<Data.Documents> GetBannerDetails()
        {
            return unitOfWork.NewStudy.GetBannerDetails();
        }

        /// <summary>
        /// Get Login Background details
        /// </summary>        
        /// <returns></returns>
        public List<Data.Documents> GetLoginBckgndDetails()
        {
            return unitOfWork.NewStudy.GetLoginBckgndDetails();
        }

        /// <summary>
        ///Save Identification Activation documents
        /// </summary>
        /// <param name="lsDocuments"></param>        
        /// <returns></returns>
        public bool SaveIdentificationActivationDocuments(List<Data.Documents> lsDocuments,string LogedinUserName,string studyowner)
        {
            return unitOfWork.NewStudy.SaveIdentificationActivationDocuments(lsDocuments, LogedinUserName, studyowner);
        }


        /// <summary>
        ///Save Identification Activation documents
        /// </summary>
        /// <param name="lsDocuments"></param>        
        /// <returns></returns>
        public bool SaveUpdateDocuments(List<Data.Documents> lsDocuments, string LogedinUserName, string studyowner)
        {
            return unitOfWork.NewStudy.SaveUpdateDocuments(lsDocuments, LogedinUserName, studyowner);
        }

        /// <summary>
        ///Save Amendment protocol
        /// </summary>
        /// <param name="lsDocuments"></param>        
        /// <returns></returns>
        public bool SaveAmendmentProtocol(int StudyId, string LogedinUserName, string decision,string studyOwner)
        {
            return unitOfWork.NewStudy.SaveAmendmentProtocol(StudyId, LogedinUserName,decision, studyOwner);
        }
        /// <summary>
        /// Submit document
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool SubmitActivationdocument(Data.Documents documents)
        {
            return unitOfWork.NewStudy.SubmitActivationDocument(documents);
        }

        /// <summary>
        /// Submit document
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool SubmitUpdateddocuments(Data.Documents documents)
        {
            return unitOfWork.NewStudy.SubmitUpdatedDocument(documents); 
        }

        /// <summary>
        /// Submit document
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool SubmitAmedmentProtocolDocument(Data.Documents documents)
        {
            return unitOfWork.NewStudy.SubmitAmedmentProtocolDocument(documents);
        }

        /// <summary>
        /// Submit document
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool AddTask(int studyid,string studyOwner)
        {
            return unitOfWork.NewStudy.AddTAsk(studyid, studyOwner);
        }

        /// <summary>
        /// Create Amendment protocol task
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public bool AddAmendmentTask(int studyid,string studyOwner)
        {
            return unitOfWork.NewStudy.AddAmendmentTask(studyid, studyOwner);
        }

        /// <summary>
        /// Get Study Information
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="studyID"></param>
        /// <returns>true/false</returns>
        public Data.NewStudy GetStudyInformation(int studyid)
        {
            return unitOfWork.NewStudy.GetStudyInformation(studyid);
        }

        #endregion
    }
}

