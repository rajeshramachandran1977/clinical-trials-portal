using Anju.Navigate.Utilities;
using System;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class ConceptDesignandRationaleRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public ConceptDesignandRationaleRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Methods    
        /// <summary>
        /// Enter Concept Design and Rationale
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="conceptDesignandRationale"></param>
        /// <param name="mode"></param>
        /// <returns>void</returns>
        public void CreateUpdateConceptDesignandRationale(int StudyID, Data.ConceptDesignandRationale conceptDesignandRationale, string[] Gender, string mode,string username)
        {
            if (conceptDesignandRationale != null)
            {                
                    var result = dbContextNavigate.ConceptDesignandRationale.Where(x => x.StudyId == StudyID).SingleOrDefault();
                if (result != null)
                {
                    result.Indication = conceptDesignandRationale.Indication?.Trim();
                    result.RationaleforTrial = conceptDesignandRationale.RationaleforTrial?.Trim();
                    result.TrialDesign = conceptDesignandRationale.TrialDesign?.Trim();
                    result.Binding = conceptDesignandRationale.Binding;
                    result.Structure = conceptDesignandRationale.Structure;
                    result.Randomized = conceptDesignandRationale.Randomized;
                    result.Gender = String.Join(",", Gender);
                    result.MinimumAge = conceptDesignandRationale.MinimumAge;
                    result.MaximumAge = conceptDesignandRationale.MaximumAge;
                    result.PatientPopulation = conceptDesignandRationale.PatientPopulation?.Trim();
                    result.KeyInclusionCriteria = conceptDesignandRationale.KeyInclusionCriteria?.Trim();
                    result.KeyExclusionCriteria = conceptDesignandRationale.KeyExclusionCriteria?.Trim();                   
                    dbContextNavigate.SaveChanges(result, new ConceptDesignandRationale_H(), username, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.ConceptDesignandRationale objConceptDesignandRationale = new DataAccess.ConceptDesignandRationale()
                    {
                        StudyId = StudyID,
                        Indication = conceptDesignandRationale.Indication?.Trim(),
                        RationaleforTrial = conceptDesignandRationale.RationaleforTrial?.Trim(),
                        TrialDesign = conceptDesignandRationale.TrialDesign?.Trim(),
                        Binding = conceptDesignandRationale.Binding,
                        Structure = conceptDesignandRationale.Structure,
                        Randomized = conceptDesignandRationale.Randomized,
                        Gender = Gender.Length > 0 ? String.Join(",", Gender) : null,
                        MinimumAge = conceptDesignandRationale.MinimumAge,
                        MaximumAge = conceptDesignandRationale.MaximumAge,
                        PatientPopulation = conceptDesignandRationale.PatientPopulation?.Trim(),
                        KeyInclusionCriteria = conceptDesignandRationale.KeyInclusionCriteria?.Trim(),
                        KeyExclusionCriteria = conceptDesignandRationale.KeyExclusionCriteria?.Trim()
                    };
                    dbContextNavigate.SaveChanges(objConceptDesignandRationale, new ConceptDesignandRationale_H(), username, eAuditChangeType.Insert);
                }
            }            
        }
        #endregion
    }
}
