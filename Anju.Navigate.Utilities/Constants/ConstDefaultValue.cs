using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Anju.Navigate.Utilities
{
    

    public class ConstDefaultValue
    {
        public enum AttributeId
        {
            [Description("Science Main")]
            ScienceMain = 10100,
            [Description("Disease States")]
            DiseaseStates = 10101,
            [Description("Correlative Science")]
            CorrelativeScience = 10104,
            [Description("Pharmacovigilance")]
            Pharmacovigilance = 10108,
            [Description("Study Compounds")]
            StudyCompounds = 10105,
            [Description("Cohort Levels")]
            CohortLevels = 10102,
            [Description("Study Enrollment & Timelines")]
            StudyEnrollmentandTimelines = 10109,
            [Description("IRB Requirement")]
            IRBRequirement = 10110,
            [Description("Pandemic Preparedness Trial Categorization")]
            PandemicPreparednessTrialCategorization = 10111,
            [Description("Regulatory Requirements")]
            RegulatoryRequirements = 10112,
            [Description("Contacts")]
            Contacts = 10400,
            [Description("Indications")]
            Indications = 10106,
            [Description("Sites")]
            Sites = 10402,
            [Description("Investigator Qualifications")]
            InvestigatorQualifications = 10401,
            [Description("Key references")]
            Keyreferences = 10114,
            [Description("Objectives")]
            Objectives = 10403,
            [Description("Study / Protocol Number(s)")]
            StudyProtocolNumbers = 10113,
            [Description("Research Group Description")]
            ResearchGroupDescription = 10404,
            [Description("Treatment Information")]
            TreatmentInformation = 10405,
            [Description("Original Financial Request")]
            OriginalFinancialRequest = 10406,
            [Description("Email List")]
            EmailList = 10407,
            [Description("Milestones")]
            Milestones = 10408,
            [Description("Patient Accrual")]
            PatientAccrual = 10409,
            [Description("Invoices")]
            Invoices = 10410,
            [Description("Contracts Timeline")]
            ContractsTimeline = 10411,
            [Description("Status")]
            Status = 10418,
            [Description("Reviews and Notes")]
            ReviewsandNotes = 10413,
            [Description("Documents")]
            Documents = 10414,
            [Description("Submissions")]
            Submissions = 10415,
            [Description("Other Attributes")]
            OtherAttributes = 10416,
            [Description("Related Users")]
            RelatedUsers = 10417,
        }

        public const string SecurityKey = "C1!uq1u$123$";
        public const string SQLDBKey = "10000000-0000-0000-0000-000000000001";
        public const string ADMINISTRATOR = "ADMINISTRATOR";
        public const string MAILFROM = "Mail.From";
        public const string PRIMARY = "DrugorCompoundPrimary";
        public const string SECONDARY = "DrugorCompoundSecondary";
        public const string TERTIARY = "Drugorcompoundtertiary";
        public const string DRUGORCOMPOUNDTYPEFORSECONDARY = "DrugorCompoundSecondaryType";
        public const string DRUGORCOMPOUNDTYPEFORTERTIARY = "DrugorCompoundTertiaryType";
        public const string BLINDING = "Blinding";
        public const string STRUCTURE = "Structure";
        public const string RANDOMIZED = "Randomized";
        public const string MINIMUMAGE = "MinimumAge";
        public const string MAXIMUMAGE = "MaximumAge";
        public const string YES = "Yes";
        public const string NO = "No";
        public const string DATACOLLECTIONINTERVENTIONAL = "Datacollectioninterventional";
        public const string DATACOLLECTIONNONINTERVENTIONAL = "Datacollectionnoninterventional";
        public const string WITHNOCompanyDRUG = "WITH NO [Company] Drug";
        public const string INVOLVINGPRIMARYDATACOLLECTIONWITHACOMPANYPRODUCTOFFOCUS = "Involving PRIMARY DATA COLLECTION WITH a [Company] Product of Focus";
        public const string INVOLVINGPRIMARYDATACOLLECTIONWITHOUTACOMPANYPRODUCTOFFOCUS = "Involving PRIMARY DATA COLLECTION WITHOUT a [Company] Product of Focus";
        public const string BASEDONSECONDARYUSEOFDATA = "BASED ON SECONDARY USE OF DATA";
        public const string INTERVENTIONAL = "Interventional";
        public const string SALUTATION = "Salutation";
        public const string CREDENTIALS = "Credentials";
        public const string USERTYPE = "UserType";
        public const string USERSTATUS = "UserStatus";
        public const string DEPARTMENT = "Department";
        public const string SUFFIX = "Suffix";
        public const string MSL = "MSL";
        public const string PI = "PI";
        public const string PROGRAMLEADER = "ProgramLeader";        
        public const string IISADMIN = "IISAdmin";
        public const string ADMIN = "Admin";
        public const string RESETPASSWORD = "ResetPassword";
        public const string EXTERNALUSER = "ExternalUser";
        public const string FRANCHISE = "Franchise";
        public const string PRIMARYINDICATION = "PrimaryIndication";
        public const string PIINSTITUTION = "PIInstitution";
        public const string DECISION = "Decision";
        public const string PATIENTPOPULATION = "PatientPopulation";
        public const string PATIENTTYPE = "PatientType";
        public const string RISKFACTORS = "RiskFactors";
        public const string GENOMICPROFILE = "GenomicProfile";
        public const string LINEOFTHERAPY = "LineOfTherapy";
        public const string COMPOUNDTYPE = "Compoundtype";
        public const string NONCOMPANYCOMPOUND = "Noncompanycompound";
        public const string INTERVENTIONSTATUS = "InterventionStatus";
        public const string INDICATIONTYPE = "IndicationType";
        public const string INDICATION = "Indication";
        public const string INDSTATUS = "Indstatus";
        public const string STUDYTITLE = "StudyTitle";
        public const string STUDYDESCRIPTORS = "StudyDescriptors";
        public const string INVESTIGATIONALDRUGANDREFERENCETHERAPY = "Investigationaldrugandreferencetherapy";
        public const string GENDER = "Gender";
        public const string EXCLUSIONCRITERIA = "ExclusionCriteria";
        public const string CLINICALPHARMACOLOGY = "ClinicalPharmacology";
        public const string PLACEBOCONTROLLED = "PlaceboControlled";
        public const string SAFETYCRITERIA = "SafetyCriteria";
        public const string OTHERCOMPOUND = "OtherCompound";
        public const string STUDYPHASE = "StudyPhase";
        public const string PHASEI = "PhaseI";
        public const string PHASEII = "PhaseII";
        public const string PHASEIII = "PhaseIII";
        public const string PHASEIV = "PhaseIV";
        public const string RATIONALEFORSTUDY = "RationaleforStudy";
        public const string STUDYDESIGN = "StudyDesign";
        public const string INCLUSIONCRITERIA = "Inclusioncriteria";
        public const string BASISFORSAMPLESIZE = "Basisforsamplesize";
        public const string TREATMENTARMSAPPLYFORTHISTRIAL = "HowmanyTreatmentArmsapplyforthistrial";
        public const string CHARACTERSLEFTTOENTER = " Characters left to enter";
        public const string DOCUMENTSTATUS = "DocumentStatus";
        public const string DOCUMENTTYPE = "DocumentType";
        public const string DOCUMENTVERSION = "DocumentVersion";
        public const string DRUGORCOMPOUNDCATEGORY = "DrugorCompoundCategory";
        public const string TYPEOFTRIALDRUG = "Typeoftrialdrug";
        public const string DRUGORCOMPOUNDTYPE = "DrugorCompoundType";
        public const string TRIALLEADER = "TrialLeader";
        public const string DISEASE = "Disease";
        public const string DISEASEFORPATIENTPOPULATION = "Diseaseforpatientpopulation";
        public const string STAGE = "Stage";
        public const string TREATMENTSEGMENT = "Treatmentsegment";
        public const string LINEOFTREATMENT = "Lineoftreatment";
        public const string QUALITYOFLIFE = "QualityofLife";
        public const string ISSTUDYINCLUDECORRELATIVESCIENCE = "Isstudyincludecorrelativescience";
        public const string CORRELATIVESCIENCESAMPLINGDETAILS = "Correlativesciencesamplingdetails";
        public const string CORRELATIVESCIENCESTUDIESPERFORMEDATSTUDYSITE = "Correlativesciencestudiesperformedatstudysite";
        public const string CORRELATIVESCIENCESTUDIESPERFORMEDATCOMPANYSITE = "Correlativesciencestudiesperformedatcompanysite";
        public const string DRUGORCOMPOUNDSECONDARYTYPE = "DrugorCompoundSecondaryType";
        public const string OCCURRENCEOFOTHERSPECIALSCENARIOS = "Occurrenceofotherspecialscenarios";
        public const string ALLNONSERIOUSAES = "Allnonseriousaes";
        public const string SAFETYDATA = "Safetydata";
        public const string ADVERSEEVENTS = "Adverseevents";
        public const string NOOFPATIENTS = "Noofpatients";
        public const string COHORTLEVEL = "Cohortlevel";
        public const string DRUGADOSEANDFREQ = "drugAdoseandfreq";
        public const string DRUGADOSEBNDFREQ = "drugBdoseandfreq";
        public const string STUDYSTART = "Studystart";
        public const string TOTALNOOFPATIENTS = "Totalnoofpatients";
        public const string STUDYDURATION = "Studyduration";
        public const string COMPETINGSTUDIESATINSTITUTION = "Iscompetingstudiesatyourinstitution";
        public const string IMPACTPATIENTACCRUALFORTHEPROPOSEDSTUDY = "Impactpatientaccrualfortheproposedstudy";
        public const string RECRUITMENTEND = "RecruitmentEnd";
        public const string COMPLETIONOFFINALSTUDYREPORT = "CompletionofFinalStudyReport";
        public const string TRIALEND = "TrialEnd";
        public const string NOOFPATIENTSPERTREATMENTGROUP = "NoofPatientsperTreatmentGroup";
        public const string ENROLLMENTHISTORYFOROTHERRELATEDSTUDIES = "EnrollmentHistoryforOtherRelatedStudies";
        public const string PRIMARYPUBLICATIONDATE = "PrimaryPublicationDate";
        public const string ISIRBREGISTRATIONREQUIREMENT = "IsIRBRegistrationRequirement";
        public const string PANADEMICPREPAREDNESSTRIALCATEGORIZATION = "PandemicPreparednessTrialCategorization";
        public const string ISSAFETYMONITORINGINTERVAL = "IsSafetyMonitoringInterval";
        public const string MAXIMUMALLOWABLETIMEBETWEENVISITS = "Maximumallowabletimebetweenvisits";
        public const string ISSUBMITANINDFORTHEPROPOSEDSTUDY = "IssubmitanINDfortheproposedstudy";
        public const string RATIONALEFORINDEXEMPTION = "RationaleforINDExemption";
        public const string FINALINDSTATUS = "FinalINDStatus";
        public const string INDNUMBER = "INDNumber";
        public const string STUDYPROTOCOLNUMBERS = "StudyProtocolNumbers";
        public const string KEYREFERENCES = "Keyreferences";
        public const string SITEINDEX = "SiteIndex";
        public const string CONTACTTYPE = "Contacttype";
        public const string CONTACTTYPEDETILS = "Contacttypedetails";
        public const string TAXID = "TaxID";
        public const string FIRSTNAME = "Firstname";
        public const string LASTNAME = "Lastname";
        public const string TITLE = "Title";
        public const string ADDRESS1 = "Address1";
        public const string ADDRESS2 = "Address2";
        public const string ADDRESS3 = "Address3";
        public const string CITY = "City";
        public const string LOCALMRCDECISION = "LocalMRCDecision";
        public const string LOCALMRC = "LocalMRC";
        public const string REJECTEDDECISIONCOMMENTS = "RejectedDecisionComments";
        public const string MD = "MD";
        public const string MSLRD ="MSL RD";
        public const string DELIVERYMETHOD = "DeliveryMethod";
        public const string GLOBALSAEFREQUENCY = "GlobalSAEFrequency";
        public const string RESUBMISSIONCOMMENTS = "ReSubmissionComments";
        public const string GLOBALMRCDECISION = "GlobalMRCDecision";
        public const string STATE = "State";
        public const string POSTALCODE = "Postalcode";
        public const string COUNTRY = "Country";
        public const string PHONE = "Phone";
        public const string FAX = "Fax";
        public const string EMAIL = "Email";
        public const string NPI = "NPI";
        public const string REGION = "Region";
        public const string INDICATIONFORSCIENCEMAIN = "Indicationforsciencemain";
        public const string ENROLLMENTRATE = "Enrollmentrate";
        public const string ORGANIZATION = "Organization";
        public const string MEDICALSPECIALTY = "Medicalspecialty";
        public const string BOARDCERTIFICATION = "BoardCertification";
        public const string LICENSEOREQUIVALENT = "LicenseorEquivalent";
        public const string ISRECEIVEDGCPTRAININGTHEPAST3YEARS = "IsreceivedGCPtrainingthepast3years";
        public const string LASTGCPTRAINING = "LastGCPtraining";
        public const string TYPEOFTRAININGRECEIVED = "Typeoftrainingreceived";
        public const string LISTTRIALEXPERIENCE = "Listtrialexperience";
        public const string ISPARTICIPATEDINACOMPANYTRIAL = "Isparticipatedinacompanytrial";
        public const string DATESOFTRIALPARTICIPATION = "Datesoftrialparticipation";
        public const string DRUGNAMES = "Drugnames";
        public const string PROTOCOLNUMBERS = "Protocolnumbers";
        public const string NOOFONGOINGCLINICALTRIALS = "Noofongoingclinicaltrials";
        public const string ISINSPECTEDBYAHEALTHAUTHORITY = "Isinspectedbyahealthauthority";
        public const string WHICHHEALTHAUTHORITY = "Whichhealthauthority";
        public const string DATEOFLASTINSPECTION = "Dateoflastinspection";
        public const string ISINSPECTEDBYTHEFDA = "IsinspectedbytheFDA";
        public const string DATEOFFDAINSPECTION = "Dateoffdainspection";
        public const string ISFDAISSUEAFDA483FORM = "IsFDAissueaFDA483form";
        public const string DETAILSOFTHEMAINOBSERVATIONS = "Detailsofthemainobservations";
        public const string ONBEHALFOF = "on behalf of ";
        public const string SWITCHTOLOGINUSER = "Continue Using my Account";
        public const string ACTIVEMODEL = "ActiveModel";
        public const string CONTRACTTYPE = "ContractType";
        public const string CONTRACTSTATUS = "ContractStatus";
        public const string CURRENTLOCATION = "CurrentLocation";
        public const string SUBMITPROTOCOL = "Submit Protocol";
        public const string RESUBMITPROTOCOL = "Resubmit Protocol";
        public const string TREATMENTARM = "Treatmentarm";
        public const string NOOFPATIENTSPLANNED = "Noofpatientsplanned";
        public const string COMPOUND = "Compound";
        public const string ADMINROUTE = "Adminroute";
        public const string GENERICACCEPTABLE = "Genericacceptable";
        public const string MINDOSAGE = "Mindosage";
        public const string MAXDOSAGE = "Maxdosage";
        public const string FREQUENCY = "Frequency";
        public const string OBJECTIVETYPES = "Objectivetypes";
        public const string OBJECTIVENAMES = "Objectivenames";
        public const string OBJECTIVEDESCRIPTION = "Objectivedescription";
        public const string ENDPOINTDESCRIPTION = "Endpointdescription";
        public const string SITEINSTITUTION = "Siteinstitution";
        public const string INSTITUTIONINTERNAL = "InstitutionInternal";
        public const string ISDRUGSHIPPEDTOSITE = "IsDrugshippedtosite";
        public const string ISCONTRACTDIRECTWITHSITE = "IsContractdirectwithsite";
        public const string REVIEWDECISION = "ReviewDecision";
        public const string STUDY = "Study";
        public const string TASK = "Task";
        public const string ACTIVATIONDOCUMENT = "IdentifyActivationDocuments";
        public const string STUDYTYPEINTERVENTIONAL = "Interventional";
        public const string SAVEANDEXIT = "SaveandExit";
        public const string SAVEANDCONTINUE = "SaveandContinue";
        public const string PARALLELGROUP = "Parallel Group";
        public const string RESUBMITPROPOSAL = "Re-Submit Proposal";
        public const string REVIEWICFDECISION = "ReviewICFDecision";
        public const string STUDYSTATUS = "StudyStatus";
        public const string STATUSCHANGEREASON = "StatusChangeReason";
        public const string ACTIVEUSERSTATUS = "Active";
        public const string DISABLEDUSERSTATUS = "Disabled";
        public const string LOCKEDUSERSTATUS = "Locked";
        public const string STUDYSPONSOR = "StudySponsor";
        public const string STUDYDRUGSOURCE = "StudyDrugSource";
        public const string ISCOOPERATIVEGROUPSTUDY = "IsCooperativeGroupStudy";
        public const string COOPERATIVEGROUPNAME = "CooperativeGroupName";
        public const string COOPERATIVEGROUPNAMEOTHER = "CooperativeGroupNameOther";
        public const string ISPHYSICIANNETWORKSTUDY = "IsPhysicianNetworkStudy";
        public const string PHYSICIANNETWORKNAMES = "PhysicianNetworkNames";
        public const string REVIEWPROTOCOLDECISION = "ReviewProtocolDecision";
        public const string UPDATEDDOCUMENT = "UpdatedDocuments";
        public const string REVIEWUPDATEDDOCUMENT = "ReviewUpdatedDocuments";
        public const string AMENDMENTDECISION = "AmendmentDecision";
        public const string ISREQUESTINGACOMPANYSTUDYCOMPOUND = "Isrequestingacompanystudycompound";
        public const string ISREQUESTINGSTUDYFUNDING = "Isrequestingstudyfunding";
        public const string ISSUPPORTBEPROVIDEDFROMOTHERSOURCES = "Issupportbeprovidedfromothersources";
        public const string OTHERSUPPORTDESCRIPTION = "Othersupportdescription";
        public const string ISGOVERNMENTSUPPORTBEPROVIDED = "Isgovernmentsupportbeprovided";
        public const string ORIGINALREQUESTEDSTUDYAMOUNT = "Originalrequestedstudyamount";
        public const string GOVERNMENTSUPPORTDESCRIPTION = "Governmentsupportdescription";
        public const string ISREQUESTINGSUPPORTFROMCOMPANYOTHERTHANDRUGORFUNDING = "Isrequestingsupportfromcompanyotherthandrugorfunding";
        public const string NONCOMPANYSUPPORTSOURCES = "Noncompanysupportsources";
        public const string GLOBALFUNDINGREQUESTED = "Globalfundingrequested";
        public const string RECIPIENT = "Recipient";
        public const string MILESTONENAME = "Milestonename";
        public const string MILESTONETYPE = "Milestonetype";
        public const string MILESTONEPHASE = "Milestonephase";
        public const string MILESTONEPARAMETERS = "Milestoneparameters";
        public const string DEPENDENCY = "Dependency";
        public const string ESTIMATEDCOMPLETIONDATE = "Estimatedcompletiondate";
        public const string MILESTONECOMPLETIONDATE = "Milestonecompletiondate";
        public const string STATUS = "Status";
        public const string REMINDERSENTDATE = "Remindersentdate";
        public const string MONTHANDYEAROFACCRUAL = "Monthandyearofaccrual";
        public const string NUMBEROFNEWPATIENTSTREATEDTHISMONTH = "Numberofnewpatientstreatedthismonth";
        public const string TOTALNOOFPATIENTSCURRENTLYONTREATMENT = "Totalnoofpatientscurrentlyontreatment";
        public const string TOTALNOOFPATIENTSWITHDRAWNFROMTREATMENT = "Totalnoofpatientswithdrawnfromtreatment";
        public const string TOTALNOOFPATIENTSCOMPLETEDTREATMENT = "Totalnoofpatientscompletedtreatment";
        public const string MILESTONESTATUS = "MilestoneStatus";
        public const string CHECKSENTTOSITE = "Checksenttosite";
        public const string DESCRIPTIONOFPAYMENT = "Descriptionofpayment";
        public const string INVOICEDATE = "Invoicedate";
        public const string INVOICENUMBER = "Invoicenumber";
        public const string PONUMBER = "PONumber";
        public const string CURRENCY = "Currency";
        public const string PAYMENTAMOUNT = "Paymentamount";
        public const string LINEITEM = "Lineitem";
        public const string GENERALLEDGERNUMBER = "Generalledgernumber";
        public const string DEPARTMENTCODE = "Departmentcode";
        public const string BUDGETSOURCE = "Budgetsource";
        public const string PERSONNELSPEND = "Personnelspend";
        public const string IRBFEES = "IRBFees";
        public const string PROCEDURAL = "Procedural";
        public const string IRBANNUALFEES = "IRBAnnualfees";
        public const string ADMINISTRATIVEPORTIONOFTHEPAYMENT = "Administrativeportionofthepayment";
        public const string PHARMACYPORTIONOFTHEPAYMENT = "Pharmacyportionofthepayment";
        public const string STARTUP = "Startup";
        public const string CORRELATIVE = "Correlative";
        public const string OTHER = "Other";
        public const string ORGANIZATIONTYPE = "Organizationtype";
        public const string NATUREOFEXPENDITURE = "Natureofexpenditure";
        public const string PURPOSEOFEXPENDITURE = "Purposeofexpenditure";
        public const string SETTINGOFACTIVITY = "Settingofactivity";
        public const string CONTACTNAME = "Contactname";
        public const string STATUSCHANGEDATE = "Statuschangedate";
        public const string COMMENTS = "Comments";
        public const string VERSION = "Version";
        public const string CONTRACTSTIMELINEVERSION = "Contractstimelineversion";
        public const string CLOSUREREASONS = "ClosureReasons";
        public const string STATUSSTAGE = "Statusstage";
        public const string STATUSSTATE = "State";
        public const string STATUSSTATUS = "Status";
        public const string DATE = "Date";
        public const string TIME = "Time";
        public const string EXTERNALUSERSHELPPAGE = "External Users Help Page";
        public const string INTERNALUSERSHELPPAGE = "Internal Users Help Page";
        public const string BANNERUPLOAD = "BannerUpload";
        public const string BACKGROUNDUPLOAD = "BackgroundUpload";
        public const string VERBIAGEFORNEWUSER = "VerbiageForNewUser";
        public const string LOGIN_PAGE_CONTENT = "LOGIN_PAGE_CONTENT";
        public const string EMAIL_DEFAULT_POSTBOX = "EMAIL_DEFAULT_POSTBOX";
        public const string USAGETERMSURL = "USAGE_TERMS_URL";
        public const string PRIVACYPOLICYURL = "PRIVACY_POLICY_URL";
        public const string FDALINK = "FDA_Link";
        public const string APPNAME = "app_name";
        public const string COMPANY = "[Company]";
        public const string REVIEWSANDNOTES = "Reviewsandnotes";
        public const string REVIEWDATE = "Reviewdate";
        public const string USERNAME = "Username";
        public const string ROLEFORGENERALDETAILS = "Role";
        public const string REVIEWSTEP = "Reviewstep";
        public const string SUBMISSIONCOMMENTS = "Submissioncomments";
        public const string REVIEWDECISIONFORGENERALDETAILS = "Reviewdecision";

        public const string DOCUMENTNAME = "Documentname";
        public const string DOCUMENT = "Document";
        public const string DOCUMENTSDOCSTATUS = "Status";
        public const string DOCUMENTAMENDMENTVERSION = "Documentamendmentversion";
        public const string ORIGINALORAMENDMENTDOCUMENTVERSION = "Originaloramendmentdocumentversion";
        public const string DOCUMENTDOCTYPE = "Documenttype";
        public const string DOCUMENTDOCSUBTYPE = "Documentsubtype";
        public const string DOCUMENTSOURCE = "Documentsource";
        public const string MANUAL = "Manual";
        public const string UPLOADEDBY = "Uploadedby";
        public const string DOCUMENTDATE = "Documentdate";
        public const string ORIGINALDATE = "Originaldate";
        public const string EXPIRATIONDATE = "Expirationdate";
        public const string MTC_ENABLE_ESTIMATION_DATE_CALCULATION = "MTC_ENABLE_ESTIMATION_DATE_CALCULATION";
        public const string HOLIDAYDATELIST = "Holiday Date List";
        public const string ENABLE_BUSINESS_DAY_CALCULATION = "ENABLE_BUSINESS_DAY_CALCULATION";
        public const string MTC_ENABLE_REALTIME_EDC = "MTC_ENABLE_REALTIME_EDC";
        public const string SEC_PASSWORD_EXPIRATION_DAYS = "SEC_PASSWORD_EXPIRATION_DAYS";
        public const string SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER = "SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER";
        public const string SMTP_PASSWORD = "SMTP_PASSWORD";
        public const string SMTP_PORT = "SMTP_PORT";
        public const string SMTP_SERVER_NAME = "SMTP_SERVER_NAME";
        public const string SMTP_TLS_SECURITY = "SMTP_TLS_SECURITY";
        public const string SMTP_USERNAME = "SMTP_USERNAME";
        public const string SUBMISSIONTYPE = "Submissiontype";
        public const string SUBMISSIONSVERSION = "Version";
        public const string STUDYELIGIBILITYDATE = "Studyeligibilitydate";
        public const string SUBMISSIONDATE = "Submissiondate";
        public const string SUBMISSIONDETAILS = "Submissiondetails";
        public const string AMENDMENTREQUESTINCLUDESACHANGEINTHEPRIMARYINVESTIGATOR = "Amendmentrequestincludesachangeintheprimaryinvestigator";
        public const string AUTOPROXYENABLED = "Autoproxyenabled";
        public const string LEADORGANIZATION = "Leadorganization";
        public const string CONDITIONALAPPROVAL = "Conditionalapproval";
        public const string CONDITIONSOFAPPROVAL = "Conditionsofapproval";
        public const string ICFREVIEW = "ICFReview";
        public const string AMENDMENTSTATUS = "Amendmentstatus";
        public const string AMENDMENTTYPE = "Amendmenttype";
        public const string CONTRACTAMENDMENTREQUIRED = "Contractamendmentrequired";
        public const string ISPISTUDYSPONSOR = "IsPIstudysponsor";
        public const string CONTRACTEXECUTIONDATE = "Contractexecutiondate";
        public const string MIGRATIONDATE = "Migrationdate";
        public const string CONVERSIONSTATUS = "Conversionstatus";
        public const string MILESTONEUPDATEFREQUENCYDAYS = "Milestoneupdatefrequencydays";
        public const string ACCRUALMILESTONEUPDATEFREQUENCYDAYS = "Accrualmilestoneupdatefrequencydays";
        public const string LASTSENDEMAIL = "Lastsendemail";
        public const string SAEFREQUENCY = "SAEFrequency";
        public const string GLOBALKEY = "app_name";
        public const string NOTAPPLICABLE = "N/A";
        public const string FULLNAME = "Fullname";
        public const string RELATEDUSERSEMAIL = "Relatedusersemail";
        public const string RELATEDUSERSPHONE = "Relatedusersphone";
        public const string RELATEDUSERSROLE = "Relatedusersrole";
        public const string RELATEDUSERSBEGINDATE = "Relatedusersbegindate";
        public const string RELATEDUSERSENDDATE = "Relatedusersenddate";
        public const string SCIENTIFICRATIONALE = "Scientific Rationale";
        public const string PERSONNELSITESANDSUPPORT = "Personnel Sites and Support";
        public const string TRACKING = "Tracking";
        public const string SCIENCEMAIN = "Science Main";
        public const string DISEASESTATES = "Disease States";
        public const string COHORTLEVELS = "Cohort Levels";
        public const string CORRELATIVESCIENCE = "Correlative Science";
        public const string STUDYCOMPOUNDS = "Study Compounds";
        public const string INDICATIONTAB = "Indicationtab";
        public const string PHARMACOVIGILANCE = "Pharmacovigilance";
        public const string STUDYENROLLMENTANDTIMELINES = "Study Enrollment and Timelines";
        public const string IRBREQUIREMENT = "IRB Requirement";
        public const string PANDEMICPREPAREDNESSTRIALCATEGORIZATION = "Pandemic Preparedness Trial Categorization";
        public const string REGULATORYREQUIREMENTS = "Regulatory Requirements";
        public const string STUDYPROTOCOLNUMBERSTAB = "StudyProtocolNumberstab";
        public const string KEYREFERENCESTAB = "Keyreferencestab";
        public const string OBJECTIVES = "Objectives";
        public const string TREATMENTINFORMATION = "Treatmentinformation";
        public const string CONTACTS = "Contacts";
        public const string INVESTIGATORQUALIFICATIONS = "Investigator Qualifications";
        public const string SITES = "Sites";
        public const string RESEARCHGROUPDESCRIPTION = "Researchgroupdescription";
        public const string ORIGINALFINANCIALREQUEST = "Originalfinancialrequest";
        public const string EMAILLIST = "EmailList";
        public const string MILESTONES = "Milestones";
        public const string PATIENTACCRUAL = "PatientAccrual";
        public const string INVOICES = "Invoices";
        public const string CONTRACTSTIMELINE = "ContractsTimeline";        
        public const string DOCUMENTSTAB = "Documentstab";
        public const string SUBMISSIONS = "Submissions";
        public const string OTHERATTRIBUTES = "Otherattributes";
        public const string RELATEDUSERS = "Relatedusers";
        public const string STATUSINEDITSTUDY = "Statusineditstudy";
        public const string GENERALDETAILS = "General Details";
        public const string SPONSORPROTOCOLNUMBER = "Sponsor Protocol Number";
        public const string MACS = "MACS";
        public const string PRIMARYCOMPONENT = "Primary";
        public const string SECONDARYCOMPONENT = "Secondary";
        public const string TERTIARYCOMPONENT = "Tertiary";
        public const string SUBMITRESUBMITPROTOCOL = "Submit/Resubmit Protocol";
        public const string RGMRC = "Record Global MRC";
        public const string EDITSTUDY = "Edit Study";
    }
}
