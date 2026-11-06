using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class ObjectivesandEndpointsRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;          
        #endregion

        #region Constructor
       
        public ObjectivesandEndpointsRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        ///  Create Update Objectives and Endpoints
        /// </summary>
        /// <param name="objectivesEndpoints"></param>
        /// <param name="mode"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public bool CreateUpdateObjectivesandEndpoints(Data.ObjectivesandEndpoints objectivesEndpoints, string mode, int studyId, string userName)
        {
            int retVal = default(int);
            if (objectivesEndpoints != null)
            {                
                    var result = dbContextNavigate.ObjectivesandEndpoints.Where(x => x.ObjandEndPointsId == objectivesEndpoints.ObjandEndPointsId).SingleOrDefault();
                    if (result != null)
                    {
                        result.ObjectiveType = objectivesEndpoints.ObjectiveType;
                        result.ObjectiveName = objectivesEndpoints.ObjectiveName;
                        result.ObjectiveDescription = objectivesEndpoints.ObjectiveDescription;
                        result.EndpointDescription = objectivesEndpoints.EndpointDescription;
                        result.ANJU_ChangedBy = userName;
                        result.ANJU_ChangeDate = DateTime.UtcNow;                        
                        retVal = dbContextNavigate.SaveChanges(result, new ObjectivesandEndpoints_H(), userName, eAuditChangeType.Update);
                }
                    else
                    {
                        DataAccess.ObjectivesandEndpoints objObjectivesEndpoints = new DataAccess.ObjectivesandEndpoints()
                        {
                            StudyId = studyId,
                            ObjectiveType = objectivesEndpoints.ObjectiveType,
                            ObjectiveName = objectivesEndpoints.ObjectiveName,
                            ObjectiveDescription = objectivesEndpoints.ObjectiveDescription,
                            EndpointDescription = objectivesEndpoints.EndpointDescription,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddedBy = userName,
                            ANJU_AddDate = DateTime.UtcNow

                        };                        
                        retVal = dbContextNavigate.SaveChanges(objObjectivesEndpoints, new ObjectivesandEndpoints_H(), userName, eAuditChangeType.Insert);
                }
               
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get Objectives and Endpoints 
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of ObjectivesandEndpoints </returns>
        public List<Data.ObjectivesandEndpoints> GetObjectivesandEndpoints(int studyId)
        {
            var lstObjectivesandEndpoints = dbContextNavigate.ObjectivesandEndpoints.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.ObjectivesandEndpoints
                                                         {
                                                             ObjandEndPointsId = x.ObjandEndPointsId,                                                             
                                                             ObjectiveType = x.ObjectiveType,
                                                             ObjectiveName = x.ObjectiveName,
                                                             ObjectiveDescription = x.ObjectiveDescription,
                                                             EndpointDescription = x.EndpointDescription
                                                         }).ToList();
            return lstObjectivesandEndpoints;
        }
        /// <summary>
        /// Delete Objectives and Endpoints
        /// </summary>
        /// <param name="objectivesandEndpoints"></param>
        /// <returns></returns>
        public bool DeleteObjectivesandEndpoints(Data.ObjectivesandEndpoints objectivesandEndpoints,string userName)
        {
            int retVal = default(int);
            if (objectivesandEndpoints != null)
            {
                var result = dbContextNavigate.ObjectivesandEndpoints.Where(x => x.ObjandEndPointsId == objectivesandEndpoints.ObjandEndPointsId).SingleOrDefault();
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };               
                retVal = dbContextNavigate.SaveChanges(result, new ObjectivesandEndpoints_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
