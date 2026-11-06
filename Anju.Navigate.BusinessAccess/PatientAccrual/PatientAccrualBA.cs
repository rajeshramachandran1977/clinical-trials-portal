using System.Collections.Generic;
using Anju.Navigate.DataAccess;

namespace Anju.Navigate.BusinessAccess
{
    public class PatientAccrualBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public PatientAccrualBA()
        {
            unitOfWork = new UnitOfWork();
        }

        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Methods 
        /// <summary>
        /// Get Patient Enrollment Details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public List<Data.PatientAccrual> GetPatientEnrollmentDetails(int studyId)
        {
            return unitOfWork.PatientAccrual.GetPatientEnrollmentDetails(studyId);
        }

        /// <summary>
        /// create PatientEnrollmentDetails
        /// </summary>
        /// <returns>true/false</returns>
        public bool CreatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual)
        {
            return unitOfWork.PatientAccrual.CreatePatientEnrollmentDetails(patientAccrual);
        }
        /// <summary>
        /// Update PatientEnrollmentDetails Dates
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdatePatientEnrollmentDates(Data.PatientAccrual patientAccrual, int studyId)
        {
            return unitOfWork.PatientAccrual.UpdatePatientEnrollmentDates(patientAccrual, studyId);
        }

        /// <summary>
        /// Update PatientEnrollmentDetails
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual, int studyId)
        {
            return unitOfWork.PatientAccrual.UpdatePatientEnrollmentDetails(patientAccrual, studyId);
        }

        /// <summary>
        /// Get Patient Enrollment Details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List</returns>
        public List<Data.NewStudy> GetActivationDate(int studyId)
        {
            return unitOfWork.PatientAccrual.GetActivationDate(studyId);
        }
        #endregion
    }
}
