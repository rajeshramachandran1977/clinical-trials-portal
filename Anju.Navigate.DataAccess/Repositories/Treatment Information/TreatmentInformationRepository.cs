using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class TreatmentInformationRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;          
        #endregion

        #region Constructor
       
        public TreatmentInformationRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Create Update Treatment Information
        /// </summary>
        /// <param name="treatmentInformation"></param>
        /// <param name="mode"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateTreatmentInformation(Data.TreatmentInformation treatmentInformation, string mode,int studyId,string userName)
        {
            int retVal = default(int);
            if (treatmentInformation != null)
            {               
                    var result = dbContextNavigate.TreatmentInformation.Where(x => x.TreatmentInfoId == treatmentInformation.TreatmentInfoId).SingleOrDefault();
                    if (result != null)
                    {
                        result.TreatmentArm = treatmentInformation.TreatmentArm;
                        result.NoofPatientsPlanned = treatmentInformation.NoofPatientsPlanned;
                        result.TypeofTrialDrug = treatmentInformation.TypeofTrialDrug;
                        result.Compound = treatmentInformation.Compound;
                        result.Mindosage = treatmentInformation.Mindosage;
                        result.Maxdosage = treatmentInformation.Maxdosage;
                        result.Frequency = treatmentInformation.Frequency;
                        result.AdminRoute = treatmentInformation.AdminRoute;
                        result.GenericAcceptable = treatmentInformation.GenericAcceptable;
                        result.ANJU_ChangedBy = userName;
                        result.ANJU_ChangeDate = DateTime.UtcNow;
                      
                        retVal = dbContextNavigate.SaveChanges(result, new TreatmentInformation_H(), userName, eAuditChangeType.Update);
                }
                    else
                    {
                        DataAccess.TreatmentInformation objTreatmentInformation = new DataAccess.TreatmentInformation()
                        {
                            StudyId = studyId,
                            TreatmentArm = treatmentInformation.TreatmentArm,
                            NoofPatientsPlanned = treatmentInformation.NoofPatientsPlanned,
                            TypeofTrialDrug = treatmentInformation.TypeofTrialDrug,
                            Compound = treatmentInformation.Compound,
                            Mindosage = treatmentInformation.Mindosage,
                            Maxdosage = treatmentInformation.Maxdosage,
                            Frequency = treatmentInformation.Frequency,
                            AdminRoute = treatmentInformation.AdminRoute,
                            GenericAcceptable = treatmentInformation.GenericAcceptable,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddedBy = userName,
                            ANJU_AddDate = DateTime.UtcNow
                        };                        
                        retVal = dbContextNavigate.SaveChanges(objTreatmentInformation, new TreatmentInformation_H(), userName, eAuditChangeType.Insert);
                }
           
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  Get Treatment Information
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>lstTreatmentInformation</returns>
        public List<Data.TreatmentInformation> GetTreatmentInformation(int studyId)
        {
            var lstTreatmentInformation = dbContextNavigate.TreatmentInformation.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.TreatmentInformation
                                                         {
                                                             TreatmentInfoId = x.TreatmentInfoId,
                                                             StudyId = x.StudyId,
                                                             TreatmentArm = x.TreatmentArm,
                                                             NoofPatientsPlanned = x.NoofPatientsPlanned,
                                                             TypeofTrialDrug = x.TypeofTrialDrug,
                                                             Compound = x.Compound.Trim(),
                                                             Mindosage = x.Mindosage.Trim(),
                                                             Maxdosage = x.Maxdosage.Trim(),
                                                             Frequency = x.Frequency.Trim(),
                                                             AdminRoute = x.AdminRoute.Trim(),
                                                             GenericAcceptable = x.GenericAcceptable
                                                         }).ToList();
            return lstTreatmentInformation;
        }

        /// <summary>
        /// Delete Treatment Informations
        /// </summary>
        /// <param name="treatmentInformations"></param>
        /// <returns></returns>
        public bool DeleteTreatmentInformations(Data.TreatmentInformation treatmentInformations,string userName)
        {
            int retVal = default(int);
            if (treatmentInformations != null)
            {
                var result = dbContextNavigate.TreatmentInformation.Where(x => x.TreatmentInfoId == treatmentInformations.TreatmentInfoId).SingleOrDefault();
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };               
                retVal = dbContextNavigate.SaveChanges(result, new TreatmentInformation_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        #endregion
    }
}
