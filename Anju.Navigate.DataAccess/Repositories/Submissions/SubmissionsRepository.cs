using Anju.Navigate.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class SubmissionsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public SubmissionsRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion


        public List<Data.Submissions> GetSubmissionsByStudyID(int studyId)
        {
            var result = new List<Data.Submissions>();
            if (studyId > 0)
            {
                result = dbContextNavigate.Submissions.AsEnumerable().Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false)
                             .Select(x => new Data.Submissions
                             {
                                 SubmissionId = x.SubmissionId,
                                 Submissiontype = x.Submissiontype,
                                 Submissionversion = x.Submissionversion,
                                 Submissiondate = x.Submissiondate,
                                 Studyeligibilitydate = x.Studyeligibilitydate,
                                 Submissiondetails = x.Submissiondetails,
                                 DocumentExtension = x.DocumentExtension,
                                 DocumentSize = x.DocumentSize,
                                 StudyId = x.StudyId

                             }).ToList();

                return result;
            }
            return new List<Data.Submissions>();
        }



        public bool CreateUpdateSubmissions(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objsubmissionsdetails = dbContextNavigate.Submissions.Where(x => x.SubmissionId == newStudy.SubmissionId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objsubmissionsdetails != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();


                bool issubmissiontyperestricted = false;
                bool isversionrestricted = false;
                bool isstudyeligibilitydatestricted = false;
                bool issubmissiondaterestricted = false;
                bool issubmissiondetailsrestricted = false;
                
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.SUBMISSIONTYPE:
                            objsubmissionsdetails.Submissiontype = newStudy.Submissiontype ?? objsubmissionsdetails.Submissiontype;
                            issubmissiontyperestricted = true;
                            break;
                        case ConstDefaultValue.SUBMISSIONSVERSION:
                            objsubmissionsdetails.Submissionversion = newStudy.Submissionversion ?? objsubmissionsdetails.Submissionversion;
                            isversionrestricted = true;
                            break;
                        case ConstDefaultValue.STUDYELIGIBILITYDATE:
                            objsubmissionsdetails.Studyeligibilitydate = newStudy.Studyeligibilitydate ?? objsubmissionsdetails.Studyeligibilitydate;
                            isstudyeligibilitydatestricted = true;
                            break;
                        case ConstDefaultValue.SUBMISSIONDATE:
                            objsubmissionsdetails.Submissiondate = newStudy.Submissiondate ?? objsubmissionsdetails.Submissiondate;
                            issubmissiondaterestricted = true;
                            break;
                        case ConstDefaultValue.SUBMISSIONDETAILS:
                            objsubmissionsdetails.Submissiondetails = newStudy.Submissiondetails ?? objsubmissionsdetails.Submissiondetails;
                            issubmissiondetailsrestricted = true;
                            break;                        
                        default:
                            break;
                    }
                }
                if (issubmissiontyperestricted == false)
                    objsubmissionsdetails.Submissiontype = newStudy.Submissiontype;
                if (isversionrestricted == false)
                    objsubmissionsdetails.Submissionversion = newStudy.Submissionversion;
                if (isstudyeligibilitydatestricted == false)
                    objsubmissionsdetails.Studyeligibilitydate = newStudy.Studyeligibilitydate;
                if (issubmissiondaterestricted == false)
                    objsubmissionsdetails.Submissiondate = newStudy.Submissiondate;
                if (issubmissiondetailsrestricted == false)
                    objsubmissionsdetails.Submissiondetails = newStudy.Submissiondetails;

                objsubmissionsdetails.DocumentExtension = newStudy.DocumentExtension;
                objsubmissionsdetails.DocumentSize = newStudy.DocumentSize;
                objsubmissionsdetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objsubmissionsdetails.ANJU_ChangeDate = DateTime.UtcNow;

                retVal = dbContextNavigate.SaveChanges(objsubmissionsdetails, new Submissions_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.Submissions submissions = new DataAccess.Submissions()
                {
                    StudyId = newStudy.StudyId,
                    Submissiontype = newStudy.Submissiontype,
                    Submissionversion = newStudy.Submissionversion,
                    Studyeligibilitydate = newStudy.Studyeligibilitydate,
                    Submissiondate = newStudy.Submissiondate,
                    Submissiondetails = newStudy.Submissiondetails,
                    DocumentSize = newStudy.DocumentSize,
                    DocumentExtension = newStudy.DocumentExtension,
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };
                retVal = dbContextNavigate.SaveChanges(submissions, new Submissions_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }



        public bool CreateUpdateSubmissionsAddMode(Data.Submissions submissions)
        {
            int retVal = default(int);
            var objSubmissions = dbContextNavigate.Submissions.Where(x => x.StudyId == submissions.StudyId && x.SubmissionId == submissions.SubmissionId).SingleOrDefault();
            if (objSubmissions != null)
            {
                objSubmissions.Submissiondetails = submissions.Submissiondetails;
                objSubmissions.Studyeligibilitydate = submissions.Studyeligibilitydate;
                objSubmissions.Submissiondate = submissions.Submissiondate;
                objSubmissions.Submissiontype = submissions.Submissiontype;
                objSubmissions.Submissionversion = submissions.Submissionversion;
                objSubmissions.StudyId = submissions.StudyId;

                objSubmissions.IsActive = submissions.IsActive;
                objSubmissions.IsDeleted = submissions.IsDeleted;
                objSubmissions.ANJU_ChangedBy = submissions.ANJU_ChangedBy;
                objSubmissions.ANJU_ChangeDate = DateTime.UtcNow;

                retVal = dbContextNavigate.SaveChanges(objSubmissions, new Submissions_H(), submissions.ANJU_AddedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.Submissions objInsertsubmissions = new DataAccess.Submissions()
                {
                    Submissiondetails = submissions.Submissiondetails,
                    Studyeligibilitydate = submissions.Studyeligibilitydate,
                    Submissiondate = submissions.Submissiondate,
                    Submissiontype = submissions.Submissiontype,
                    Submissionversion = submissions.Submissionversion,
                    StudyId = submissions.StudyId,

                    IsActive = submissions.IsActive,
                    IsDeleted = submissions.IsDeleted,
                    ANJU_ChangedBy = submissions.ANJU_ChangedBy,
                    ANJU_ChangeDate = DateTime.UtcNow,
            };
                retVal = dbContextNavigate.SaveChanges(objInsertsubmissions, new Submissions_H(), submissions.ANJU_AddedBy, eAuditChangeType.Insert);
            }

            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete Contacts
        /// </summary>
        /// <param name="submissions"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteSubmissions(Data.Submissions submissions, string userName)
        {
            int retVal = default(int);
            if (submissions != null)
            {
                var result = dbContextNavigate.Submissions.Where(x => x.SubmissionId == submissions.SubmissionId
                                                                        && x.StudyId == submissions.StudyId).FirstOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                retVal = dbContextNavigate.SaveChanges(result, new Submissions_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        public List<Data.Submissions> GetSpecificSubmissionsByStudyID(int studyId, int docid)
        {
            var result = new List<Data.Submissions>();
            if (studyId > 0)
            {
                result = dbContextNavigate.Submissions.AsEnumerable().Where(x => x.StudyId == studyId && x.SubmissionId == docid && x.IsActive == true && x.IsDeleted == false)                              
                             .Select(x => new Data.Submissions
                             {
                                 SubmissionId = x.SubmissionId,
                                 Submissiontype = x.Submissiontype,
                                 Submissionversion = x.Submissionversion,
                                 Submissiondate = x.Submissiondate,
                                 Studyeligibilitydate = x.Studyeligibilitydate,
                                 Submissiondetails = x.Submissiondetails,
                                 DocumentExtension = x.DocumentExtension,
                                 DocumentSize = x.DocumentSize
                             }).ToList();

                return result;
            }
            return new List<Data.Submissions>();
        }

    }
}
