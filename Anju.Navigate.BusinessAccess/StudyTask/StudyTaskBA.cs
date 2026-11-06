using Anju.Navigate.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.BusinessAccess
{
    public class StudyTaskBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public StudyTaskBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Save MSL and PLTaskv Details
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateAndUpdateTaskDetails(Data.StudyTask studyTask, string userName,string taskStatus)
        {
            return unitOfWork.StudyTask.CreateUpdateTaskDetails(studyTask, userName, taskStatus);
        }

        /// <summary>
        /// Get MSL Review Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of StudyReviews</returns>
        public List<Data.StudyReview> GetMSLReviewDetailsByStudyId(int studyId)
        {
            return unitOfWork.StudyTask.GetStudyReviewDetails(studyId);
        }

        /// <summary>
        /// Save MSLReview
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateMSLReview(Data.StudyReview studyReview)
        {
            return unitOfWork.StudyTask.CreateUpdateMSLReview(studyReview);
        }

        /// <summary>
        /// Get DocumentSubtype by TypeID
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>list of states</returns>
        public List<Data.DocumentSubTypes> GetDocumentSubtypeByTypeID(int DocumentTypeId)
        {
            return unitOfWork.StudyTask.GetDocumentSubtypeByTypeID(DocumentTypeId);
        }
        /// <summary>
        /// Update Document details 
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdateDocumentDetails(Data.Documents documents)
        {
            return unitOfWork.StudyTask.UpdateDocumentDetails(documents);
        }    
      
        /// <summary>
        /// Get Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentDetails()
        {
            return unitOfWork.StudyTask.GetDocumentDetails();
        }

        /// <summary>
        /// Get Document by name 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentbyName(string documentname, int studyid)
        {
            return unitOfWork.StudyTask.GetDocumentbyName(documentname,studyid);
        }

        /// <summary>
        /// Get DrugorCompounddetails Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of drugs</returns>
        public List<Data.NewStudy> GetDrugorCompounddetailsDetailsByStudyId(int studyId)
        {
            return unitOfWork.StudyTask.GetDrugorCompounddetailsDetailsByStudyId(studyId);
        }

        /// <summary>
        /// Get PL Review Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of PLStudyReviews</returns>
        public List<Data.PLStudyReview> GetPLReviewDetailsByStudyId(int studyId)
        {
            return unitOfWork.StudyTask.GetPLStudyReviewDetails(studyId);
        }

        /// <summary>
        /// Save PLReview
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdatePLReview(Data.PLStudyReview plStudyReview)
        {
            return unitOfWork.StudyTask.CreateUpdatePLReview(plStudyReview);
        }

        /// <summary>
        /// Update PI Resubmission
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdatePIResubmission(Data.NewStudy newStudy)
        {
            return unitOfWork.StudyTask.UpdatePIResubmission(newStudy);
        }

        /// <summary>
        /// Get MRC Budget Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of budget</returns>
        public List<Data.MRCStudyReview> GetMRCBudgetDetails(int studyId)
        {
            return unitOfWork.StudyTask.GetMRCBudgetDetails(studyId);
        }

        /// <summary>
        /// Get MRC  Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of budget</returns>
        public List<Data.MRCStudyReview> GetMRCDetails(int studyId)
        {
            return unitOfWork.StudyTask.GetMRCDetails(studyId);
        }

        /// <summary>
        /// Save LocalMRCReview details
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateUpdateMRCReview(Data.MRCStudyReview mrcStudyReview)
        {
            return unitOfWork.StudyTask.CreateUpdateMRCStudyReview(mrcStudyReview);
        }

        /// <summary>
        /// Save Rejected MRCReview details
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateRejectedMRCStudyReview(Data.MRCStudyReview mrcStudyReview)
        {
            return unitOfWork.StudyTask.CreateRejectedMRCStudyReview(mrcStudyReview);
        }

        /// <summary>
        /// Save withdrawal MRCReview details
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreateWithdrawalMRCStudyReview(Data.MRCStudyReview mrcStudyReview)
        {
            return unitOfWork.StudyTask.CreateWithdrawalMRCStudyReview(mrcStudyReview);
        } 
        
        /// <summary>
        /// Update MRCReview details
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdateMRCStudyReview(Data.MRCStudyReview mrcStudyReview,string piUserName)
        {
            return unitOfWork.StudyTask.UpdateMRCStudyReview(mrcStudyReview, piUserName);
        }
        
        /// <summary>
        /// Update GMRC ConditionalApproval Details
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns>true/false</returns>
        public bool UpdateGMRCConditionalApprovalDetails(Data.MRCStudyReview mrcStudyReview)
        {
            return unitOfWork.StudyTask.UpdateGMRCConditionalApprovalDetails(mrcStudyReview);
        }

        /// <summary>
        /// Get Review Activation Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewActivationDocuments(int studyId)
        {
            return unitOfWork.StudyTask.GetReviewActivationDocuments(studyId);
        }

        /// <summary>
        /// Get Review Updated Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewUpdatedDocuments(int studyId)
        {
            return unitOfWork.StudyTask.GetReviewUpdatedDocuments(studyId);
        }
        

        /// <summary>
        /// Get Review Amendment Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewAmendmentDocuments(int studyId)
        {
            return unitOfWork.StudyTask.GetReviewAmendmentDocuments(studyId);
        }
        /// <summary>
        /// Get Activated Activation Document details 
        /// </summary>
        /// <returns>List</returns>
        public bool ActivateActivationDocuments(int studyId, string documentname, string status,string loginuser)
        {
            return unitOfWork.StudyTask.ActivateActivationDocuments(studyId,documentname,status, loginuser);
        }

        /// <summary>
        /// Get Activated Updated Document details 
        /// </summary>
        /// <returns>List</returns>
        public bool ActivateUpdatedDocuments(int studyId, string documentname, string status, string loginuser)
        {
            return unitOfWork.StudyTask.ActivateUpdatedDocuments(studyId, documentname, status, loginuser);
        }
        /// <summary>
        /// Get Rejected Activation Document details 
        /// </summary>
        /// <returns>List</returns>
        public bool AddRejectedActivationDocument(int studyId, string studyowner,string loginuser,string comment)
        {
            return unitOfWork.StudyTask.AddRejectedActivationDocument(studyId, studyowner, loginuser,comment);
        }

        /// <summary>
        /// Get Rejected Updated Document details 
        /// </summary>
        /// <returns>List</returns>
        public bool AddRejectedUpdatedDocument(int studyId, string studyowner, string loginuser, string comment)
        {
            return unitOfWork.StudyTask.AddRejectedUpdatedDocument(studyId, studyowner, loginuser, comment);
        }

        /// <summary>
        /// Get Activated Activation Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetActivatedActivationdocument(int studyId)
        {
            return unitOfWork.StudyTask.GetActivatedActivationdocument(studyId);
        }

        /// <summary>
        /// Get Activated update Document details 
        /// </summary>
        /// <returns>List</returns>
        public List<Data.Documents> GetActivatedUpdatedocument(int studyId)
        {
            return unitOfWork.StudyTask.GetActivatedUpdatedocument(studyId);
        }
        #endregion
    }
}
