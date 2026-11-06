namespace Anju.Navigate.DataAccess
{
    public class UnitOfWork 
    {
        private Navigate30Context dbContext;

        
        private readonly Navigate30Context dbContextNavigate;

        public LoginRepository Login
        {
            get { return new LoginRepository(dbContextNavigate); }
        }

        public UserRolesRepository UserRoles
        {
            get { return new UserRolesRepository(dbContextNavigate); }
        }
        public SysCodeValuesRepository SysCodeValues
        {
            get { return new SysCodeValuesRepository(dbContextNavigate); }
        }
        public CountryRepository Country
        {
            get { return new CountryRepository(dbContextNavigate); }
        }

        public StateRepository State
        {
            get { return new StateRepository(dbContextNavigate); }
        }

        public CityRepository City
        {
            get { return new CityRepository(dbContextNavigate); }
        }

        public UserTypesRepository UserTypes
        {
            get { return new UserTypesRepository(dbContextNavigate); }
        }

        public UsersRepository Users
        {
            get { return new UsersRepository(dbContextNavigate); }
        }

        public GlobalSettingsRepository GlobalSettings
        {
            get { return new GlobalSettingsRepository(dbContextNavigate); }
        }            
        public ObjectivesandEndpointsRepository ObjectivesandEndpoints
        {
            get { return new ObjectivesandEndpointsRepository(dbContextNavigate); }
        }
        public CohortLevelsRepository CohortLevels
        {
            get { return new CohortLevelsRepository(dbContextNavigate); }
        }
        public TreatmentInformationRepository TreatmentInformation
        {
            get { return new TreatmentInformationRepository(dbContextNavigate); }
        }
        public NewStudyRepository NewStudy
        {
            get { return new NewStudyRepository(dbContextNavigate); }
        }

        public StudyTaskRepository StudyTask
        {
            get { return new StudyTaskRepository(dbContextNavigate); }
        }
        public CenterRepository Center
        {
            get { return new CenterRepository(dbContextNavigate); }
        }
        public PharmacovigilanceRequirementsRepository PharmacovigilanceRequirements
        {
            get { return new PharmacovigilanceRequirementsRepository(dbContextNavigate); }
        }
        public PlannedTrialMilestoneDatesandEnrollmentRepository PlannedTrialMilestoneDatesandEnrollment
        {
            get { return new PlannedTrialMilestoneDatesandEnrollmentRepository(dbContextNavigate); }
        }
        public CorrelativeScienceStudiesRepository CorrelativeScienceStudies
        {
            get { return new CorrelativeScienceStudiesRepository(dbContextNavigate); }
        }
        public ConceptDesignandRationaleRepository ConceptDesignandRationale
        {
            get { return new ConceptDesignandRationaleRepository(dbContextNavigate); }
        }
        public DrugorCompounddetailsRepository DrugorCompounddetails
        {
            get { return new DrugorCompounddetailsRepository(dbContextNavigate); }
        }
        public TrialPhaseRepository TrialPhase
        {
            get { return new TrialPhaseRepository(dbContextNavigate); }
        }
        public EditStudyRepository EditStudy
        {
            get { return new EditStudyRepository(dbContextNavigate); }
        }

        public AttributeRepository Attribute
        {
            get { return new AttributeRepository(dbContextNavigate); }
        }
        public StudyCompoundsRepository StudyCompounds
        {
            get { return new StudyCompoundsRepository(dbContextNavigate); }
        }

        public StudyIndicationRepository StudyIndication
        {
            get { return new StudyIndicationRepository(dbContextNavigate); }
        }

        public StudyProtocolRepository StudyProtocol
        {
            get { return new StudyProtocolRepository(dbContextNavigate); }
        }

        public StudySitesRepository StudySites
        {
            get { return new StudySitesRepository(dbContextNavigate); }
        }
        public PatientAccrualRepository PatientAccrual
        {
            get { return new PatientAccrualRepository(dbContextNavigate); }
        }
        public ProtocolPhaseRepository ProtocolPhase
        {
            get { return new ProtocolPhaseRepository(dbContextNavigate); }
        } 
        public GMRCApprovalTaskRepository GMRCApprovalTask
        {
            get { return new GMRCApprovalTaskRepository(dbContextNavigate); }
        }
        public MaintainanceAndMonitoringRepository MaintainanceAndMonitoring
        {
            get { return new MaintainanceAndMonitoringRepository(dbContextNavigate); }
        }
        public StudyCloseoutRepository StudyCloseout
        {
            get { return new StudyCloseoutRepository(dbContextNavigate); }
        }

        public MilestonesRepository Milestones
        {
            get { return new MilestonesRepository(dbContextNavigate); }
        }

        public CommonRepository SendMail
        {
            get { return new CommonRepository(dbContextNavigate); }
        }

        public InvoicesdeatilsRepository Invoicesdeatils
        {
            get { return new InvoicesdeatilsRepository(dbContextNavigate); }
        }

        public StatusRepository status
        {
            get { return new StatusRepository(dbContextNavigate); }
        }

        public ReviewsandNotesRepository Reviewsandnotes
        {
            get { return new ReviewsandNotesRepository(dbContextNavigate); }
        }

        public SubmissionsRepository Submissions
        {
            get { return new SubmissionsRepository(dbContextNavigate); }
        }

        public ContractTimelinesRepository ContractTimelines
        {
            get { return new ContractTimelinesRepository(dbContextNavigate); }
        }

        #region Operations       
        public void Commit()
        {
            dbContext.SaveChanges();
        }
        #endregion
    }
}
