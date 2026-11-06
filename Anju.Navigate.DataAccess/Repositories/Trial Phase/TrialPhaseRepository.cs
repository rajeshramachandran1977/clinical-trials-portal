using Anju.Navigate.Utilities;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class TrialPhaseRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public TrialPhaseRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Enter Trial Phase
        /// </summary>
        /// <param name="StudyID"></param>
        /// <param name="trialPhase"></param>
        /// <param name="mode"></param>
        public void CreateUpdateTrialPhase(int StudyID, Data.TrialPhase trialPhase, string mode,string userName)
        {
            if (trialPhase != null)
            {                
                var result = dbContextNavigate.TrialPhase.Where(x => x.StudyId == StudyID).FirstOrDefault();
                if (result != null)
                {
                    result.PhaseI = trialPhase.PhaseI;
                    result.PhaseII = trialPhase.PhaseII;
                    result.PhaseIII = trialPhase.PhaseIII;
                    result.PhaseIV = trialPhase.PhaseIV;                    
                    dbContextNavigate.SaveChanges(result, new TrialPhase_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.TrialPhase objtrialPhase = new DataAccess.TrialPhase()
                    {
                        StudyId = StudyID,
                        PhaseI = trialPhase.PhaseI,
                        PhaseII = trialPhase.PhaseII,
                        PhaseIII = trialPhase.PhaseIII,
                        PhaseIV = trialPhase.PhaseIV
                    };                   
                    dbContextNavigate.SaveChanges(objtrialPhase, new TrialPhase_H(), userName, eAuditChangeType.Insert);
                }               
            }
        }
        #endregion
    }
}
