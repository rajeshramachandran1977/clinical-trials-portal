using System;
using System.ComponentModel;

namespace Anju.Navigate.Utilities
{
    public enum DocumentTypeEnum
    {
        [Description("Regulatory")]
        Regulatory = 0,
        [Description("Budget")]
        Budget = 1,
        [Description("Submission Support")]
        SubmissionSupport = 2,
        [Description("Protocol Support")]
        ProtocolSupport = 3,
        [Description("Document Milestone")]
        DocumentMilestone = 4
    }
    public enum DocumentStatusEnum
    {
        [Description("Pending Review")]
        PendingReview = 0,
        [Description("Approved")]
        Approved = 1,
        [Description("HelpDocuments")]
        HelpDocuments=2,
    }
    public enum DocumentSubTypeEnum
    {
        [Description("CV")]
        CV = 0,
        [Description("Draft")]
        Draft = 1,
        [Description("Additional Documents")]
        AdditionalDocuments = 2,
        [Description("Protocol")]
        Protocol = 3,
        [Description("ICF")]
        ICF = 4,
        [Description("HelpDocuments")]
        HelpDocuments=5,
    }

 

    public class Messages
    {
        //General or Common Messages
        public const string SOMETHNGWENTWRONG = "Something went wrong, please try again.If the issue persists please contact the administrator";

        /*Account Creation messages,Login,Change and Forget Password etc */
        public const string PASSWORDMISMATCH = "New and Confirm new Passwords do not match";
        public const string PASSWORDCHANGESUCCESSFULL = "You will now be redirected to the Login page. Login with your new credentials.";
        public const string NEWPASSWORDCANNOTBESAMEASOLDPASSWORD = "New password cannot be the same as your old password";
        public const string PASSWORDFORMATIONCRITERIA = "Password requirements criteria not satisfied,please refer below for requirements";
        public const string PASSWORDEXPIRED = "Your Password has expired,you will be directed to the Change Password Page.Please reset your password";
        public const string UserAccountHasBeenLocked = "User account has been locked";
        public const string EmailNotExists = "User Name and/or Email does not exist";
        public const string FROMEMAILNOTCONFIGUREDINGLOBALSETTINGS = "There is a problem with configured email in globalsettings,please contact your administrator";
        public const string PasswordChangedSuccessfully = "Password changed successfully. ";
        public const string ChangePasswordFailed = "Password change failed to update";
        public const string GeneratePassword = "Instructions on how to generate a new password have been sent to your registered email";
        public const string AccountLocked = "Your account has been locked for security reasons please contact your administrator.";
        public const string INVALIDUSERNAMEPASSWORD = "Invalid User Name or Password";
        public const string FORGOTTENUSERNAMESUBJECT = "Forgot User Name";
        public const string USERNAMEREQUIRED = "User Name is required";
        public const string EMAILADDRESSEREQUIRED = "Email Address is required";
        public const string PASSWORDEREQUIRED = "Password is required";

        public const string TITLEOFTRIALREQUIRED = "Title of Trial is required";
        public const string PRIMARYCOMPOUND = "Primary[Company Name] Compound is required";
        public const string INDICATIONREQUIRED = "Indication is required";
        public const string RATIONALEFORTRIALREQUIRED = "Rationale for Trial is required";
        public const string TRIALDESIGNREQUIRED = "Trial Design is required";
        public const string BLINDINGREQUIRED = "Blinding is required";
        public const string STRUCTUREREQUIRED = "Structure is required";
        public const string RANDOMIZEDREQUIRED = "Randomized is required";
        public const string GENDERREQUIRED = "Gender is required";
        public const string MINIMUMAGEREQUIRED = "Minimum Age is required";
        public const string MAXIMUMAGEREQUIRED = "Maximum Age is required";
        public const string PATIENTPOPULATIONREQUIRED = "Patient Population is required";
        public const string KEYINCLUSIONCRITERIAREQUIRED = "Key Inclusion Criteria is required";
        public const string KEYEXCLUSIONCRITERIAREQUIRED = "Key Exclusion Criteria is required";
        public const string HOWMANYTREATMENTARMSAPPLYTOTHISTRIALREQUIRED = "How many treatment arms apply to this trial is required";

        public const string MAXIMUMAGECANNOTBELESSTHANMINIMUMAGE = "Maximum Age cannot be less than Minimum Age";
        public const string EmailSentSuccessfully = "Email Sent successfully";
        public const string EmailFailedToSend = "Email failed to send";
        
       
        public const string INVALIDEMAILADDRESS = "Invalid Email Address,please enter a valid Email Address";
        public const string UsernameAlreadyExists = "User Name already exists, please try with another User Name";
        public const string PrimaryEmailAlreadyExists = "Primary Email already exists, please try with another email";
        public const string UserSuccessfullyCreated = "New User Created successfully";
        public const string UserSuccessfullyUpdated = "User Updated successfully";
        public const string PreviousPasswordsUsed = "Your Password cannot be the same as previous Passwords";
        public const string InValidOldPassWord = "Invalid old Password";
        public const string ProblemInCreation = "Unable to save the record,please try again else if issue persists please contact your Administrator";
        public const string ProblemInDeletion = "Unable to delete the record,please try again else if issue persists please contact your Administrator";
        public const string ProblemInUpdation = "Unable to update the record,please try again else if issue persists please contact your Administrator";
        public const string ProblemInUpload = "Unable to upload the file,please try again else if issue persists please contact your Administrator";
        public const string ProblemInRemoval = "Unable to remove the file,please try again else if issue persists please contact your Administrator";
        public const string ProblemInDownload = "Unable to download the file,please try again else if issue persists please contact your Administrator";
        public const string ERRORSINTHEPAGE = "There are errors on the page. Please correct them to continue.";
        public const string CHARACTERSLEFTTOENTER = " Characters left to enter";
        public const string CONTACTADMINISTRATORONERROR = "There appears to be an error, please retry or contact Administrator if issue persists.";

        public const string COHORTLEVELSREQUIRED = "Cohort levels for dose escalation trials only is required.";
        public const string OBJECTIVETYPEANDOBJECTIVENAMEISREQUIRED = "An Objective type of Primary is required along with Objective Name.";
        public const string OBJECTIVETYPEISREQUIRED = "Objective Type is required.";
        public const string OBJECTIVENAMEISREQUIRED = "Objective Name is required.";
        public const string GRIDDATANOTSAVED = "Grid data has not been saved";

        public const string adminEmail = "Admin@Novartis.in";
        public const string SuccessStatus = "Success";
        public const string FailedStatus = "Failed";
        public const string ErrorStatus = "Error";
        public const string FetchError = "Unable to fetch the data from database,please contact your administrator.";
        public const string FileNotFound = "files not present";
        public const string PersonalandResearchSites = "PersonalandResearchSites";        
        public const string BackgroundUpload = "BackgroundUpload";
        public const string BannerUpload = "BannerUpload";
        public const string RequestedSupport = "RequestedSupport";
        public const string RequestedSupportAdditionalDocuments = "RequestedSupportAdditionalDocuments";
        public const string RequestedSupportProtocolDocuments = "RequestedSupportProtocolDocuments";
        public const string CommonDocuments = "CommonDocuments";

        public const string LocalMRCSupportDocuments = "LocalMRCSupportDocuments";
        public const string LMRCRejectedSupportDocuments = "LMRCRejectedSupportDocuments";
        public const string LMRCWithdrawalSupportDocuments = "LMRCWithdrawalSupportDocuments";

        public const string GlobalMRCSupportDocuments = "GlobalMRCSupportDocuments";
     
        public const string ATTRIBUTEUPDATEDSUCCESSFULLY = "Attribute updated successfully";

        /*Work flow Tasks*/
        public const string MSLANDPLASSIGNMENT = "MSL and PL Assignment";
        public const string MSLLOIREVIEW = "MSL LOI Review";
        public const string PENDINGMANUALMSLANDPLASSIGNMENT = "Pending Manual MSL and PL Assignment";
        public const string ASSIGNMSLANDPL = "Assign MSL and Program Leader to new submission";
        /*MSL Workflow*/
        public const string DECISIONRESUBMIT = "Resubmit";
        public const string DECISIONACCEPTED = "Accepted";
        public const string MSLPLASSIGNEMENTCOMPLETE = "MSL / Program Leader Assignment Complete";
        public const string PENDINGMSLCONCEPTREVIEW = "Pending MSL Concept Review";
        public const string CONCEPTSUBMITTED = "Concept Submitted";
        public const string CONCEPTRESUBMITTED = "Concept Resubmitted";

        public const string RESUBMITPROPOSAL = "Re-submit Proposal";
        public const string PENDINGRESUBMISSION = "Pending Resubmission";
        public const string MSLREQUESTEDRESUBMISSION = "MSL has Requested Resubmission";
        public const string RESUBMITPROPOSALCOMPLETE = "Concept Resubmission Complete";

        public const string PENDINGPLCONCEPTREVIEW = "Pending Program Leader Review";
        public const string PLREVIEW = "Program Leader Review";
        public const string STATEMSLACCEPTED = "MSL Accepted Concept";
        /*PL Resubmission*/
        public const string RETURNRESUBMITPROPOSAL = "Return to PI for Resubmission";
        public const string PENDINGRESUBMITPROPOSAL = "Pending PI For Resubmission";

        public const string PLRESUBMITSTATE = "Program Leader Review Requested Resubmission";
        public const string PLRESUBMITSTATUS = "Pending MSL Review of the decision with the PI";
        /*PL Accepted*/
        public const string PLACCEPTEDSTATE = "Scheduled for LMRC Meeting";
        public const string PLACCEPTEDSTATUS = "Pending LMRC Review Results";
        public const string PLTASKNAME = "Record Local MRC Results";

        /*Local MRC*/
        /* Decision Rejected*/
        public const string DECISIONREJECTED = "Rejected";
        public const string LMRCDECISIONREJECTEDSTATE = "LMRC Rejected";
        public const string LMRCDECISIONREJECTEDSTATUS = "Pending MSL review of decision with PI";
        public const string LMRCDECISIONREJECTEDTASKNAME = "Review Rejection";

        /*Rejection Confirmed*/
        public const string LMRCDECISIONREJECTEDCONFIRMEDSTATE = "Review Rejection Confirmed";
        public const string LMRCDECISIONREJECTEDCONFIRMEDSTATUS = " Pending creation of notification letter by Trial Leader";
        public const string LMRCDECISIONREJECTEDCONFIRMEDTASKNAME = "Create/Deliver Rejection Letter";
        public const string GMRCDECISIONREJECTEDCONFIRMEDTASKNAME = "Create/Deliver Rejection Letter";

        public const string LMRCDECISIONREJECTEDSTAGE = "Rejected";
        public const string LMRCDECISIONREJECTEDSTATECONFIRMED = "Study Rejected";
        public const string LMRCDECISIONREJECTEDSTATUSCONFIRMED = "Notification letter has been sent to PI";
        public const string LMRCFINALREJECTEDDOCUMENT = "LMRCFinalRejectedDocument";
        public const string GMRCFINALREJECTEDDOCUMENT = "GMRCFinalRejectedDocument";
        public const string GMRCMACDDOCUMENT = "GMRCMACDDocument";
        public const string REDLINEDICFDOCUMENT = "RedlinedICFDocument";
        public const string GMRCADDITIONALAPPROVALDOCUMENTS = "GMRCAdditionalApprovalDocuments";
        public const string GMRCREJECTEDSUPPORTDOCUMENTS = "GMRCRejectedSupportDocuments";
        public const string GMRCWITHDRAWALSUPPORTDOCUMENTS = "GMRCWithdrawalSupportDocuments";
        


        /* Decision Withdrawn*/
        public const string DECISIONWITHDRAWN = "Withdrawn";
        public const string LMRCDECISIONWITHDRAWNSTATE = "LMRC Withdrawn";
        public const string LMRCDECISIONWITHDRAWNSTATUS = "Pending Creation of notification letter by Trial Leader";
        public const string LMRCDECISIONWITHDRAWNTASKNAME = "Create/Deliver Withdrawal Letter";
        public const string GMRCDECISIONWITHDRAWNTASKNAME = "Create/Deliver Withdrawal Letter";

        public const string LMRCFINALWITHDRAWALDDOCUMENT = "LMRCFinalWithdrawalDocument";
        public const string GMRCFINALWITHDRAWALDDOCUMENT = "GMRCFinalWithdrawalDocument";

        /*Withdrawn Confirmed*/
        public const string LMRCDECISIONWITHDRAWNCONFIRMEDSTATE = "Request Withdrawn";
        public const string LMRCDECISIONWITHDRAWNCONFIRMEDSTATUS = " Investigator withdrew request";
        /* Decision Tabled*/
        public const string DECISIONTABLED = "Tabled";
        public const string LMRCDECISIONTABLEDSTATE = "LMRC Tabled";
        public const string LMRCDECISIONTABLEDSTATUS = "Pending LMRC rescheduling";
        public const string LMRCDECISIONTABLEDTASKNAME = "";
        public const string LMRCRESUMEMETTING = "Resume Meeting";

        /* Decision Approved*/
        public const string DECISIONAPPROVED = "Approved";
        public const string LMRCDECISIONAPPROVEDSTATE = "Scheduled for GMRC Meeting";
        public const string LMRCDECISIONAPPROVEDSTATUS = "Pending GMRC Review Results";
        public const string LMRCDECISIONAPPROVEDTASKNAME = "Record Global MRC Results";

        /*Decision Conditional Approved*/
        public const string DECISIONCONDITIONALAPPROVAL = "Conditionally Approved - Resubmission required";
        public const string LMRCDECISIONCONDITIONALAPPROVALSTATE = "LMRC Resubmission Required";
        public const string LMRCREQUESTEDRESUBMISSION = "LMRC Requested Resubmission";
        public const string PENDINGRESUBMISSIONBYPI = "Pending Resubmission by PI";
        public const string REJECTEDLMRCRESUBMISSION = "Rejection following MSL discussion with PI RE: LMRC resubmission";

        /*Record Types*/
        public const string LocalMRC = "LocalMRC";
        public const string GlobalMRC = "GlobalMRC";

        /*GMRC Decision Rejected*/
        public const string GMRCDECISIONREJECTEDSTATE = "GMRC Rejected";

        /* GMRC Decision Withdrawn*/
        public const string GMRCDECISIONWITHDRAWNSTATE = "GMRC Withdrawn";

        /**GMRC Decision Tabled*/
        public const string GMRCDECISIONTABLEDSTATE = "GMRC Tabled";
        public const string GMRCDECISIONTABLEDSTATUS = "Pending GMRC rescheduling";

        /*Dialog boxes*/
        public const string YES = "Yes";
        public const string NO = "No";
        public const string DELETEMESSAGE = "Are you sure you want to delete";
        public const string DELETEMESSAGETITLEBOX = "Delete Confirmation";
        /* GMRC Decision Conditional Approval Resubmission Required*/
        public const string GMRCDECISIONCONDITIONALAPPROVALSTATE = "GMRC Conditionally Approved";
        public const string GMRCCONTINGENCY = "MSL Clear Global MRC Contingency";
        public const string REJECTEDGMRCRESUBMISSION = "Rejection following MSL discussion with PI RE: GMRC resubmission";

        public const string GMRCDECISIONCONDITIONALAPPROVALRESUBIMISSIONSTATE = "GMRC Resubmission Required";
        public const string RETURNRESUBMITPROPOSALTOGMRC = "Return to PI for Resubmission to Global MRC";
        public const string GMRCREQUESTEDRESUBMISSION = "GMRC Requested Resubmission";
        public const string GMRCPENDINGMSLCONCEPTREVIEW = "Pending MSL Concept Review of GMRC - requested resubmission";
        public const string GMRCMSLREVIEW = "Resubmitted LOI for Review";

        /* GMRC Decision Conditionally Approved */
        public const string CONDITIONALLYAPPROVED = "Conditionally Approved";
        public const string CONDITIONALLYAPPROVEDTASKNAME = "MSL Clear Global MRC Contingency";
        public const string CONDITIONALLYAPPROVEDSTATE = "GMRC Conditionally Approved";

        /*GMRC Decision Approved*/

        public const string GMRCAPPROVEDTASKNAME = "Create/Deliver Approval Letter";
        public const string GMRCAPPROVEDSTATE = "GMRC Approved";
        public const string GMRCAPPROVEDSTATUS = "Pending creation of notification letter by Trial Leader";
        public const string GMRCAPPROVALFINALDOCUMENT = "GMRCApprovalFinalDocument";
        public const string GMRCPREACTIVITIESINPROGRESS = "Pre-activation activities in Progress";
        public const string GMRCPENDINGSUBMISSIONOFDRUGSUPPLYACTIVITIES = "Pending submission of Drug Supply Activities task";
        public const string GMRCPENDINGSUBMISSIONOFFMVACTIVITIES = "Pending Upload of FMV Analysis";

        public const string GMRCAPPROVALTASKS = "GMRCApprovalTasks";
        public const string PIAPPROVALTASKS = "PIApprovalTasks";
        public const string FAIRMARKETDOCUMENT = "Upload Fair Market Value Analysis Document";
        public const string DRUGACTIVITIES = "Drug Activities";
        public const string MANAGECONTRACTSTATUS = "Manage Contract Status";

        /*Submit Activation Document*/
        public const string IDENTIFYACTIVATIONDOCUMENTS = "Identify Activation Documents";
        public const string SUBMITACTIVATIONDOCUMENTS = "Submit Activation Documents";
        public const string RESUBMITACTIVATIONDOCUMENTS = "Resubmit Activation Documents";
        public const string REVIEWACTIVATIONDOCUMENTS = "Review Activation Documents";
        public const string PENDINGREVIEW = "Pending Review";
        public const string REGULATORYDOCUMENT = "Regulatory";
        public const string REGULATORYSUBTYPE = "VDR";

        /*Drug Activities completed*/
        public const string DRUGACTIVITIESCOMPLETED = "Drug Supply Activities Complete";

        /* Fair Market Value Analysis completed*/
        public const string FAIRMARKETDOCUMENTCOMPLETED = "FMV Analysis Upload Complete";

        /*Manage Contract Completed */
        public const string MANAGECONTRACTSTATUSCOMPLETED = "Contract Fully-Executed";

        /*FMV Upload*/
        public const string FMVDOCUMENT = "FMVDocument";

        /*ExecutedContractDocument Upload*/
        public const string EXECUTEDCONTRACTDOCUMENT = "ExecutedContractDocument";

        /*Submit ICF Document*/
        public const string SUBMITREQUIREDICFDOCUMENT = "Submit Required ICF Document";
        public const string REVIEWICF = "Review ICF";
        public const string ICFDocument = "ICFDocument";
        public const string PENDINGREVIEWOFICF = "Pending Review of ICF";
        public const string PENDINGRESUBMISSIONOFICF = "Pending resubmission of ICF";
        public const string REVIEWICFDECISION = "Redlined";
        public const string ICFAPPROVED = "ICF has been approved";
        public const string ICFRESUBMISSIONREQUIRED = "ICF Resubmission Required";

        /*Icons*/
        public const string PRINTERICON = "Printer Friendly Format";

        /*New Proposal*/
        public const string NEWSUBMISSION = "New Proposal Submission";

        /*submit Protocol*/
        public const string PROTOCOLSUBMISSIONCOMPLETED = "Protocol submission complete; Pending review by Trial Leader";
        public const string SUBMITPROTOCOL = "Submit Protocol";

        /*Review Protocol*/
        public const string REVIEWPROTOCOL = "Review Protocol";
        public const string REDLINEDREVIEWPROTOCOLDOCUMENT = "RedlinedReviewProtocolDocument";
        public const string REVIEWPROTOCOLDECISION = "Resubmit";
        public const string RESUBMITPROTOCOL = "Resubmit Protocol";
        public const string PENDINGPROTOCOLRESUBMISSION = "Changes Required; Pending Protocol re-submission";
        public const string PROTOCOLAPPROVED = "Protocol Submission approved for IRB review";

        /*Modify Status*/
        public const string MODIFYSTATUSSUPPORTDOCUMENTS = "ModifyStatusSupportDocuments";
        public const string MODIFYSTATUSCANCELLEDSTATE = "Pending Trial Leader to specify applicable closeout milestones";
        public const string MODIFYSTATUSCANCELLEDSTATUS = "Initiating Study Closeout";
        public const string MODIFYSTATUSCANCELLEDTASKNAME = "Create / Deliver Cancelled Study Notification Letter";
        public const string MODIFYSTATUSCANCELLEDSTAGE = "Cancelled";

        /*Review Updated Documents*/
        public const string UPDATEDDOCUMENTS = "Update Document(s)";
        public const string REVIEWUPDATEDDOCUMENTS = "Review Updated Document(s)";

        /*UserTypes*/
        public const string MSL = "MSL";
        public const string PROGRAMLEADER = "ProgramLeader";
        public const string TRIALLEADER = "TrialLeader";
        public const string IISADMIN = "IISAdmin";

        /*Final Activation Review*/
        public const string FINALACTIVATIONREVIEW = "Final Activation Review";
        public const string STUDYCHECKLIST = "StudyCheckListDocument";
        public const string FINALACTIVATIONREVIEWCOMPLETED = "Final Activation Review Complete";

        /*Create/Deliver Activation Letter*/
        public const string ACTIVATIONLETTER = "Create/Deliver Activation Letter";
        public const string PENDINGACTIVATIONLETTER = "Pending Activation Letter";
        public const string STUDYACTIVATIONADDITIONALDOCUMENTS = "StudyActivationAdditionalDocuments";
        public const string STUDYACTIVATIONDOCUMENT = "StudyActivationDocument";
        public const string STUDYACTIVE = "Active";
        public const string STUDYACTIVESTATE = "Activation Notification Complete";
        public const string STUDYACTIVESTATUS = "Study Activated";

        /*SAE Final Reconciliation Report Confirmation*/
        public const string SAEFINALRECONCILIATIONREPORTCONFIRMATION = "SAE Final Reconciliation Report Confirmation";
        public const string ACTIVE = "Active";
        public const string ENROLLMENTPROGRESSSTATE = "Enrollment in Progress";
        public const string PATIENTACCRUALSUBMITTED = "Patient Accural update has been submitted";
        public const string ENROLLMENTCLOSEDSTATE = "Enrollment Closed";
        public const string STUDYCLOSEOUTPENDING = "No patients are on treatment; initiate study closeout pending"; 
        public const string STOPENROLLING = "The study is no longer enrolling new patients";
        public const string SAEPENDING = "No patients are on treatment; SAE Reporting confirmation pending";        

        /*Amendment protocol/budget */
        public const string AMENDMENTMANDATORYDOCUMENTS = "AmendmentMandatoryDocuments";
        public const string AMENDMENTADDITIONALDOCUMENTS = "AmendmentAdditionalDocuments";
        public const string SUBMISSIONSUPPORT = "SubmissionSupport";
        public const string REVIEWFORAMENDMENT = "Review for Amendment";
        public const string RESUBMITAMENEDMENTREQUEST = "Resubmit Amendment Request";
        public const string STUDYPROFILEUPDATESFORAMENDMENT = "Study Profile Updates for Amendment";
        public const string REVIEWREJECTIONFORAMENDMENT = "Review Rejection for Amendment";
        /*Study CloseOut*/
        public const string INITIATESTUDYCLOSEOUT = "Initiate Study Closeout";

        public const string TPSRRECONCILIATION = "TPSR Reconciliation";
        public const string DRUGRECONCILIATION = "Drug Reconciliation";
        public const string BUDGETRECONCILIATION = "Budget Reconciliation";
        public const string POCLOSEOUTREQUESTED = "PO Closeout Requested";

        public const string FINALSTUDYDATAREPORT = "Final Study Data/Report";
        public const string TLACTIVATIONTASKS = "TLActivationTasks";
        public const string PIACTIVATIONTASKS = "PIActivationTasks";


        public const string STUDYCLOSEOUTINITIATED = "Study Closeout Initiated";
        public const string CLOSEOUTACTIVITIESINPROGRESS = "Closeout activities in Progress";
        public const string INITIATESTUDYCLOSEOUTACTIONINITIATED = "Initiate Study Closeout action initiated";

        /*Final study Report*/
        public const string FINALSTUDYREPORT = "FinalStudyReport";
        public const string FINALSTUDYTASK = "Final Study Data/Report";
        public const string DOCUMENTSUBMISSIONREVIEW = "Document Submission Review";
        public const string RESUBMITFINALSTUDYREPORT = "Resubmit Final Study Data / Report";
        public const string RESUBMITFINALSTUDYREPORTSTATUS = "Review Document Task requires resubmission";
        public const string RESUBMITFINALSTUDYREPORTAPPROVALSTATUS = "Requested Document has been accepted";
        public const string DOCUMENTRESUBMISSIONCOMPLETE = "Document resubmission complete";

        /*Close Study*/
        public const string CLOSESTUDY = "Close Study";
        public const string CLOSESTUDYDOCUMENT = "CloseStudyDocument";
        public const string CLOSEDSTUDYSTAGE = "Closed";
        public const string CLOSEDSTUDYSTATE= "Study Closed";

        /*Users */
        public const string USERDISABLEERRORMESSAGE = "Your account has been disabled,please contact your administrator.";

        /*Header,Sub-Header,Certain field labels*/
        public const string FORGOTPASSWORDHEADER = "Forgot Password";
        public const string FORGOTPASSWORDINFO = "Please enter your username, and the e-mail address you provided when you registered. We will send you an email with instructions to reset your password.";
        public const string FORGOTPASSWORDPAGETITLE = "Forget Password";

        /*Help Documents*/
        public const string HELPDOCUMENTS = "HelpDocuments";
        public const string externalDocuments = "externalDocuments";
        public const string internalDocuments = "internalDocuments";

        /*Milestone*/
        public const string MILESTONESTATUS = "Complete";
        public const string MILESTONEPENDINGSTATUS = "Pending";
    }
}