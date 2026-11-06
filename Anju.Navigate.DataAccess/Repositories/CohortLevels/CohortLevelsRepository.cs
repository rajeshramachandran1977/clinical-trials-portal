using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class CohortLevelsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;          
        #endregion

        #region Constructor
       
        public CohortLevelsRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get Cohort Levels
        /// </summary>
        /// <returns>lstCohortLevels</returns>
        public List<Data.CohortLevels> GetCohortLevels(int studyId)
        {
            var lstCohortLevels = dbContextNavigate.CohortLevels.Where(x => x.StudyId == studyId && x.IsActive)
                                                         .Select(x => new Data.CohortLevels
                                                         {
                                                             CohortId = x.CohortId,
                                                             NoofPatients = x.NoofPatients,
                                                             Cohortlevel = x.Cohortlevel,
                                                             DoseandFrequencyDrugA = x.DoseandFrequencyDrugA,
                                                             DoseandFrequencyDrugB = x.DoseandFrequencyDrugB
                                                             
                                                         }).ToList();
            return lstCohortLevels;
        }


        /// <summary>
        /// Get Drug Type
        /// </summary>
        /// <returns>lstDrugDetails</returns>
        public bool CreateUpdateCohortLevels(Data.CohortLevels cohortLevels,int studyId, string userName)
        {
            int retVal = default(int);
            if (cohortLevels != null)
            {                
                var result = dbContextNavigate.CohortLevels.Where(x => x.CohortId == cohortLevels.CohortId).SingleOrDefault();
                if (result != null)
                {
                    result.CohortId = cohortLevels.CohortId;
                    result.NoofPatients = cohortLevels.NoofPatients;
                    result.Cohortlevel = cohortLevels.Cohortlevel;
                    result.DoseandFrequencyDrugA = cohortLevels.DoseandFrequencyDrugA;
                    result.DoseandFrequencyDrugB = cohortLevels.DoseandFrequencyDrugB;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new CohortLevels_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.CohortLevels objcohortLevels = new DataAccess.CohortLevels()
                    {
                        StudyId = studyId,
                        NoofPatients = cohortLevels.NoofPatients,
                        Cohortlevel = cohortLevels.Cohortlevel,
                        DoseandFrequencyDrugA = cohortLevels.DoseandFrequencyDrugA,
                        DoseandFrequencyDrugB = cohortLevels.DoseandFrequencyDrugB,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow

                    };                   
                    retVal = dbContextNavigate.SaveChanges(objcohortLevels, new CohortLevels_H(), userName, eAuditChangeType.Insert);
                }              
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get Objectives and Endpoints
        /// </summary>
        /// <returns>lstAge</returns>
        public List<Data.ObjectivesandEndpoints> GetObjectivesandEndpoints()
        {
            var lstObjectivesandEndpoints = dbContextNavigate.ObjectivesandEndpoints.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.ObjectivesandEndpoints
                                                         {
                                                             ObjandEndPointsId = x.ObjandEndPointsId,
                                                             StudyId = x.StudyId,
                                                             ObjectiveType = x.ObjectiveType,
                                                             ObjectiveName = x.ObjectiveName,
                                                             ObjectiveDescription = x.ObjectiveDescription
                                                         }).ToList();
            return lstObjectivesandEndpoints;
        }
        
        /// <summary>
        /// Delete Cohort Levels
        /// </summary>
        /// <param name="cohortLevels"></param>
        /// <returns></returns>
        public bool DeleteCohortLevels(Data.CohortLevels cohortLevels,string userName)
        {
            int retVal = default(int);
            if (cohortLevels != null)
            {
                var result = dbContextNavigate.CohortLevels.Where(x => x.CohortId == cohortLevels.CohortId).SingleOrDefault();
                if (result != null)
                {
                    result.CohortId = cohortLevels.CohortId;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };                
                retVal = dbContextNavigate.SaveChanges(result, new CohortLevels_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }


        #endregion
    }
}
