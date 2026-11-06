using Anju.Navigate.Utilities;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class PlannedTrialMilestoneDatesandEnrollmentRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;        
        #endregion

        #region Constructor

        public PlannedTrialMilestoneDatesandEnrollmentRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods    
        /// <summary>
        /// Create/Update Planned Trial Milestone Dates and Enrollment
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="plannedTrialMilestoneDatesandEnrollmentng"></param>
        /// <param name="mode"></param>
        public void CreateUpdatePlannedTrialMilestoneDatesandEnrollment(int StudyID, Data.PlannedTrialMilestoneDatesandEnrollment plannedTrialMilestoneDatesandEnrollmentng,string username)
        {
            if (plannedTrialMilestoneDatesandEnrollmentng != null)
            {
                var checkIfrecordexist = dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.Where(x => x.StudyId == StudyID)
                                                         .Select(x => new Data.PlannedTrialMilestoneDatesandEnrollment
                                                         {
                                                             StudyId = x.StudyId
                                                         }).ToList();
                if (checkIfrecordexist.Count == 0) //Create if record doesn't exist
                {
                    DataAccess.PlannedTrialMilestoneDatesandEnrollment objPlannedTrialMilestoneDatesandEnrollment = new DataAccess.PlannedTrialMilestoneDatesandEnrollment()
                    {
                        StudyId = StudyID,
                        TrialStart = plannedTrialMilestoneDatesandEnrollmentng.TrialStart,
                        TrialEnd = plannedTrialMilestoneDatesandEnrollmentng.TrialEnd,
                        PrimaryPublicationDate = plannedTrialMilestoneDatesandEnrollmentng.PrimaryPublicationDate,
                        RecruitmentEnd = plannedTrialMilestoneDatesandEnrollmentng.RecruitmentEnd,
                        TotalPlannedNumberofPatients = plannedTrialMilestoneDatesandEnrollmentng.TotalPlannedNumberofPatients,
                        CompletionofTrialReport = plannedTrialMilestoneDatesandEnrollmentng.CompletionofTrialReport,
                        PlannedNumberofCenters = plannedTrialMilestoneDatesandEnrollmentng.PlannedNumberofCenters

                    };                    
                    dbContextNavigate.SaveChanges(objPlannedTrialMilestoneDatesandEnrollment, new PlannedTrialMilestoneDatesandEnrollment_H(), username, eAuditChangeType.Insert);
                }
                else
                {
                    var result = dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.Where(x => x.StudyId == StudyID).FirstOrDefault();
                    if (result != null)
                    {
                        result.TrialStart = plannedTrialMilestoneDatesandEnrollmentng.TrialStart;
                        result.TrialEnd = plannedTrialMilestoneDatesandEnrollmentng.TrialEnd;
                        result.PrimaryPublicationDate = plannedTrialMilestoneDatesandEnrollmentng.PrimaryPublicationDate;
                        result.RecruitmentEnd = plannedTrialMilestoneDatesandEnrollmentng.RecruitmentEnd;
                        result.TotalPlannedNumberofPatients = plannedTrialMilestoneDatesandEnrollmentng.TotalPlannedNumberofPatients;
                        result.CompletionofTrialReport = plannedTrialMilestoneDatesandEnrollmentng.CompletionofTrialReport;
                        result.PlannedNumberofCenters = plannedTrialMilestoneDatesandEnrollmentng.PlannedNumberofCenters;                        
                        dbContextNavigate.SaveChanges(result, new PlannedTrialMilestoneDatesandEnrollment_H(), username, eAuditChangeType.Update);
                    }
                }
            }
        }
        #endregion
    }
}
