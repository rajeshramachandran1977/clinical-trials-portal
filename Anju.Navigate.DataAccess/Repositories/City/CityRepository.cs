using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class CityRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public CityRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get the list of Cities
        /// </summary>
        /// <returns>lstCities</returns>
        public List<Data.City> GetCities()
        {
            var lstCities = dbContextNavigate.City.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.City
                                                         {
                                                             CityId = x.CityId,
                                                             StateId = x.StateId,
                                                             StateName = x.State.Name,
                                                             Name = x.Name,                                                             
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstCities;
        }

        /// <summary>
        /// Create City
        /// </summary>
        /// <param name="City"></param>
        /// <returns>true/false</returns>
        public bool CreateCity(Data.City city,string userName)
        {
            int retVal = default(int);
            if (city != null)
            {
                DataAccess.City objCity = new DataAccess.City()
                {
                    Name = city.Name,                 
                    StateId = city.StateId,
                    IsActive = city.IsActive,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow
                };                
                retVal = dbContextNavigate.SaveChanges(objCity, new City_H(), userName, eAuditChangeType.Insert);
                if (retVal > 0)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Update City
        /// </summary>
        /// <param name="city"></param>
        /// <returns>true/false</returns>
        public bool UpdateCity(Data.City city,string userName)
        {
            int retVal = default(int);
            if (city != null)
            {
                DataAccess.City objcity = new DataAccess.City()
                {
                    CityId = city.CityId,
                    StateId = city.StateId,
                    Name = city.Name,                  
                    IsActive = city.IsActive,
                    IsDeleted = false,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };                
                retVal = dbContextNavigate.SaveChanges(objcity, new City_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="city"></param>
        /// <returns>true/false</returns>
        public bool DeleteCity(Data.City city,string userName)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            int retVal = default(int);
            if (city != null)
            {
                DataAccess.City objCity = new DataAccess.City()
                {
                    CityId = city.CityId,
                    StateId =city.StateId,
                    Name = city.Name,                  
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };               
                retVal = dbContextNavigate.SaveChanges(objCity, new City_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion

    }
}
