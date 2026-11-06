using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Anju.Navigate.DataAccess
{
    public class ReviewsandNotesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        public ReviewsandNotesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }


        /// <summary>
        /// Get Reviews and Notes
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.ReviewsandNotes> GetReviewsandNotes(int studyId)
        {
            var lstReviewsandnotes = dbContextNavigate.ReviewsandNotes.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.ReviewsandNotes
                                                         {
                                                             ReviewsandNotesId = x.ReviewsandNotesId,
                                                             StudyId = x.StudyId,
                                                             Reviewdate = x.Reviewdate,
                                                             Username = x.Username,
                                                             Role = x.Role,
                                                             Reviewstep = x.Reviewstep,
                                                             Decision = x.Decision,
                                                             Submissioncomments = x.Submissioncomments,                                         
                                                         }).ToList();
            return lstReviewsandnotes;
        }


        /// <summary>
        /// Create/Update Reviews and Notes
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateReviewsandNotes(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objreviewsandnotesdetails = dbContextNavigate.ReviewsandNotes.Where(x => x.ReviewsandNotesId == newStudy.ReviewsandNotesId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objreviewsandnotesdetails != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();


                bool isreviewdaterestricted = false;
                bool isusernamerestricted = false;
                bool isrolerestricted = false;
                bool isreviewrestricted = false;
                bool issubmissioncommentsrestricted = false;
                bool isdecisionrestricted = false;

                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.REVIEWDATE:
                            objreviewsandnotesdetails.Reviewdate = newStudy.Reviewdate ?? objreviewsandnotesdetails.Reviewdate;
                            isreviewdaterestricted = true;
                            break;
                        case ConstDefaultValue.USERNAME:
                            objreviewsandnotesdetails.Username = newStudy.Username ?? objreviewsandnotesdetails.Username;
                            isusernamerestricted = true;
                            break;
                        case ConstDefaultValue.ROLEFORGENERALDETAILS:
                            objreviewsandnotesdetails.Role = newStudy.Role ?? objreviewsandnotesdetails.Role;
                            isrolerestricted = true;
                            break;
                        case ConstDefaultValue.REVIEWSTEP:
                            objreviewsandnotesdetails.Reviewstep = newStudy.Reviewstep ?? objreviewsandnotesdetails.Reviewstep;
                            isreviewrestricted = true;
                            break;
                        case ConstDefaultValue.SUBMISSIONCOMMENTS:
                            objreviewsandnotesdetails.Submissioncomments = newStudy.Submissioncomments ?? objreviewsandnotesdetails.Submissioncomments;
                            issubmissioncommentsrestricted = true;
                            break;
                        case ConstDefaultValue.REVIEWDECISIONFORGENERALDETAILS:
                            objreviewsandnotesdetails.Decision = newStudy.Decision ?? objreviewsandnotesdetails.Decision;
                            isdecisionrestricted = true;
                            break;

                        default:
                            break;
                    }
                }
                if (isreviewdaterestricted == false)
                    objreviewsandnotesdetails.Reviewdate = newStudy.Reviewdate;
                if (isusernamerestricted == false)
                    objreviewsandnotesdetails.Username = newStudy.Username;
                if (isrolerestricted == false)
                    objreviewsandnotesdetails.Role = newStudy.Role;
                if (isreviewrestricted == false)
                    objreviewsandnotesdetails.Reviewstep = newStudy.Reviewstep;
                if (issubmissioncommentsrestricted == false)
                    objreviewsandnotesdetails.Submissioncomments = newStudy.Submissioncomments;
                if (isdecisionrestricted == false)
                    objreviewsandnotesdetails.Decision = newStudy.Decision;

                objreviewsandnotesdetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objreviewsandnotesdetails.ANJU_ChangeDate = DateTime.UtcNow;
              
                retVal = dbContextNavigate.SaveChanges(objreviewsandnotesdetails, new ReviewsandNotes_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.ReviewsandNotes reviewsandnotes = new DataAccess.ReviewsandNotes()
                {
                    StudyId = newStudy.StudyId,
                    Reviewdate = newStudy.Reviewdate,
                    Role = newStudy.Role,
                    Username = newStudy.Username,
                    Reviewstep = newStudy.Reviewstep,
                    Submissioncomments = newStudy.Submissioncomments,
                    Decision = newStudy.Decision,
                    
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };                
                retVal = dbContextNavigate.SaveChanges(reviewsandnotes, new ReviewsandNotes_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Reviews and Notes
        /// </summary>
        /// <param name="reviewsandnotes"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteReviewsandNotes(Data.ReviewsandNotes reviewsandnotes, string username)
        {
            int retVal = default(int);
            if (reviewsandnotes != null)
            {
                var result = dbContextNavigate.ReviewsandNotes.Where(x => x.ReviewsandNotesId == reviewsandnotes.ReviewsandNotesId
                                                                        && x.StudyId == reviewsandnotes.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = username;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new ReviewsandNotes_H(), username, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
    }
}
