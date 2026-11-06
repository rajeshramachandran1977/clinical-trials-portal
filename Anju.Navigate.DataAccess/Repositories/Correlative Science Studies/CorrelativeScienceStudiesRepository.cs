using Anju.Navigate.Utilities;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class CorrelativeScienceStudiesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public CorrelativeScienceStudiesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Methods    
        /// <summary>
        /// Create/Update Correlative Science Studies
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="correlativeScienceStudies"></param>
        /// <param name="mode"></param>
        public void CreateUpdaterCorrelativeScienceStudies(int studyId, Data.CorrelativeScienceStudies correlativeScienceStudies,string username)
        {
            if (correlativeScienceStudies != null)
            {
                var checkIfrecordexist = dbContextNavigate.CorrelativeScienceStudies.Where(x => x.StudyId == studyId)
                                                         .Select(x => new Data.CorrelativeScienceStudies
                                                         {
                                                             StudyId = x.StudyId
                                                         }).ToList();


                if (checkIfrecordexist.Count == 0) //Create if record doesn't exist
                {
                    DataAccess.CorrelativeScienceStudies objcorrelativeScienceStudies = new DataAccess.CorrelativeScienceStudies()
                    {
                        StudyId = studyId,
                        IsincludeCorrelativeScience = correlativeScienceStudies.IsincludeCorrelativeScience,
                        BiomarkerSamplingDetails = correlativeScienceStudies.BiomarkerSamplingDetails?.Trim(),
                        BiomarkerStudiesperformedatCompanySite = correlativeScienceStudies.BiomarkerStudiesperformedatCompanySite?.Trim(),
                        BiomarkerStudiesperformedatStudySite = correlativeScienceStudies.BiomarkerStudiesperformedatStudySite?.Trim()

                    };                   
                    dbContextNavigate.SaveChanges(objcorrelativeScienceStudies, new CorrelativeScienceStudies_H(), username, eAuditChangeType.Insert);
                }
                else
                {
                    var result = dbContextNavigate.CorrelativeScienceStudies.Where(x => x.StudyId == studyId).SingleOrDefault();
                    if (result != null)
                    {                        
                        result.IsincludeCorrelativeScience = correlativeScienceStudies.IsincludeCorrelativeScience;
                        if (result.IsincludeCorrelativeScience == true)
                        {
                            result.BiomarkerSamplingDetails = correlativeScienceStudies.BiomarkerSamplingDetails?.Trim();
                            result.BiomarkerStudiesperformedatCompanySite = correlativeScienceStudies.BiomarkerStudiesperformedatCompanySite?.Trim();
                            result.BiomarkerStudiesperformedatStudySite = correlativeScienceStudies.BiomarkerStudiesperformedatStudySite?.Trim();
                        }
                        else
                        {
                            result.BiomarkerSamplingDetails = null;
                            result.BiomarkerStudiesperformedatCompanySite = null;
                            result.BiomarkerStudiesperformedatStudySite = null;
                        }                       
                        dbContextNavigate.SaveChanges(result, new CorrelativeScienceStudies_H(), username, eAuditChangeType.Update);
                    }
                }
            }
        }



        /// <summary>
        /// Create/Update Correlative Science Studies
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public bool CreateUpdateCorrelativeScienceStudies(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                CommonRepository cmnRep = new CommonRepository();
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                var newcorrelativeScienceStudies = dbContextNavigate.CorrelativeScienceStudies.Where(x => x.StudyId == newStudy.StudyId).SingleOrDefault();
                if (newcorrelativeScienceStudies != null)
                {
                    bool isincludecorrelativesciencerestricted = false;
                    bool isbiomarkerstudiesperformedatstudysiterestricted = false;
                    bool isbiomarkerstudiesperformedatcompanysiterestricted = false;
                    bool isbiomarkersamplingdetailsrestricted = false;

                    foreach (var item in lstfields)
                    {
                        switch (item.FieldType)
                        {
                            case ConstDefaultValue.ISSTUDYINCLUDECORRELATIVESCIENCE:
                                newcorrelativeScienceStudies.IsincludeCorrelativeScience = newStudy.IsincludeCorrelativeScience ?? newcorrelativeScienceStudies.IsincludeCorrelativeScience;
                                isincludecorrelativesciencerestricted = true;
                                break;
                            case ConstDefaultValue.CORRELATIVESCIENCESTUDIESPERFORMEDATSTUDYSITE:
                                newcorrelativeScienceStudies.BiomarkerStudiesperformedatStudySite = newStudy.BiomarkerStudiesperformedatStudySite ?? newcorrelativeScienceStudies.BiomarkerStudiesperformedatStudySite;
                                isbiomarkerstudiesperformedatstudysiterestricted = true;
                                break;
                            case ConstDefaultValue.CORRELATIVESCIENCESTUDIESPERFORMEDATCOMPANYSITE:
                                newcorrelativeScienceStudies.BiomarkerStudiesperformedatCompanySite = newStudy.BiomarkerStudiesperformedatCompanySite ?? newcorrelativeScienceStudies.BiomarkerStudiesperformedatCompanySite;
                                isbiomarkerstudiesperformedatcompanysiterestricted = true;
                                break;
                            case ConstDefaultValue.CORRELATIVESCIENCESAMPLINGDETAILS:
                                newcorrelativeScienceStudies.BiomarkerSamplingDetails = newStudy.BiomarkerSamplingDetails ?? newcorrelativeScienceStudies.BiomarkerSamplingDetails;
                                isbiomarkersamplingdetailsrestricted = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (isincludecorrelativesciencerestricted == false)
                        newcorrelativeScienceStudies.IsincludeCorrelativeScience = newStudy.IsincludeCorrelativeScience;
                    if (isbiomarkerstudiesperformedatstudysiterestricted == false)
                        newcorrelativeScienceStudies.BiomarkerStudiesperformedatStudySite = newStudy.BiomarkerStudiesperformedatStudySite;
                    if (isbiomarkerstudiesperformedatcompanysiterestricted == false)
                        newcorrelativeScienceStudies.BiomarkerStudiesperformedatCompanySite = newStudy.BiomarkerStudiesperformedatCompanySite;
                    if (isbiomarkersamplingdetailsrestricted == false)
                        newcorrelativeScienceStudies.BiomarkerSamplingDetails = newStudy.BiomarkerSamplingDetails;

                   
                    retVal = dbContextNavigate.SaveChanges(newcorrelativeScienceStudies, new CorrelativeScienceStudies_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {;
                    DataAccess.CorrelativeScienceStudies objCorrelativeScienceStudies = new DataAccess.CorrelativeScienceStudies()
                    {
                        StudyId = newStudy.StudyId,
                        IsincludeCorrelativeScience = newStudy.IsincludeCorrelativeScience,
                        BiomarkerStudiesperformedatStudySite = newStudy.BiomarkerStudiesperformedatStudySite,
                        BiomarkerStudiesperformedatCompanySite = newStudy.BiomarkerStudiesperformedatCompanySite,
                        BiomarkerSamplingDetails = newStudy.BiomarkerSamplingDetails,

                    };                  
                    retVal = dbContextNavigate.SaveChanges(objCorrelativeScienceStudies, new CorrelativeScienceStudies_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
