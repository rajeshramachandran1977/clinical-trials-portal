using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StateRepository
    {

        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public StateRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get the list of States
        /// </summary>
        /// <returns>lstCountries</returns>
        public List<Data.State> GetStates()
        {
            var lstStates = dbContextNavigate.State.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.State
                                                         {
                                                             StateId = x.StateId,
                                                             CountryId =x.CountryId,
                                                             CountryName = x.Country.Name,
                                                             Name = x.Name,
                                                             Code = x.Code,
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstStates;
        }

        /// <summary>
        /// Create State
        /// </summary>
        /// <param name="State"></param>
        /// <returns>true/false</returns>
        public bool CreateState(Data.State state,string userName)
        {
            int retVal = default(int);
            if (state != null)
            {
                DataAccess.State objState = new DataAccess.State()
                {
                    Name = state.Name,
                    Code = state.Code,
                    CountryId = state.CountryId,                   
                    IsActive = state.IsActive,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow
                };               
                retVal = dbContextNavigate.SaveChanges(objState, new State_H(), userName, eAuditChangeType.Insert);
                if (retVal > 0)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Update State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>true/false</returns>
        public bool UpdateState(Data.State state,string userName)
        {
            int retVal = default(int);
            if (state != null)
            {
                DataAccess.State objState = new DataAccess.State()
                {
                    StateId = state.StateId,
                    CountryId = state.CountryId,
                    Name = state.Name,
                    Code = state.Code,
                    IsActive = state.IsActive,
                    IsDeleted = false,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };              
                retVal = dbContextNavigate.SaveChanges(objState, new State_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>true/false</returns>
        public bool DeleteState(Data.State state, string userName)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            int retVal = default(int);
            if (state != null)
            {
                DataAccess.State objState = new DataAccess.State()
                {
                    StateId = state.StateId,
                    CountryId = state.CountryId,
                    Name = state.Name,
                    Code = state.Code,
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objState, new State_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
