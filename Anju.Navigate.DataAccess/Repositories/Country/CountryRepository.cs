using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
   public class CountryRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;        
        #endregion

        #region Constructor

        public CountryRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get the list of Countries
        /// </summary>
        /// <returns>lstCountries</returns>
        public List<Data.Country> GetCountries()
        {
            var lstCountries = dbContextNavigate.Country.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.Country
                                                         {
                                                             CountryId = x.CountryId,
                                                             Name = x.Name,                                                          
                                                             Code = x.Code,                                                             
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstCountries;
        }

        /// <summary>
        /// Create Country
        /// </summary>
        /// <param name="Country"></param>
        /// <returns>true/false</returns>
        public bool CreateCountry(Data.Country country,string userName)
        {
            int retVal = default(int);
            if (country != null)
            {
                DataAccess.Country objcountry = new DataAccess.Country()
                {
                    Name = country.Name,                   
                    Code = country.Code,                    
                    IsActive = country.IsActive,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow
                };             
                retVal = dbContextNavigate.SaveChanges(objcountry, new Country_H(), userName, eAuditChangeType.Insert);
                if (retVal > 0)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Update Country
        /// </summary>
        /// <param name="Country"></param>
        /// <returns>true/false</returns>
        public bool UpdateCountry(Data.Country country,string userName)
        {
            int retVal = default(int);
            if (country != null)
            {
                DataAccess.Country objCountry = new DataAccess.Country()
                {
                    CountryId = country.CountryId,
                    Name = country.Name,                   
                    Code = country.Code,                  
                    IsActive = country.IsActive,
                    IsDeleted = false,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };               
                retVal = dbContextNavigate.SaveChanges(objCountry, new Country_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>true/false</returns>
        public bool DeleteCountry(Data.Country country,string userName)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            int retVal = default(int);
            if (country != null)
            {
                DataAccess.Country objCountry = new DataAccess.Country()
                {
                    CountryId = country.CountryId,
                    Name = country.Name,             
                    Code = country.Code,              
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objCountry, new Country_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
