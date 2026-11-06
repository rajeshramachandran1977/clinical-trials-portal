namespace Anju.Navigate.DataAccess
{
    public class UserTypesRepository 
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;  
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
       
        public UserTypesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = dbContext;

        }
        #endregion

        #region Methods     
     
        #endregion
    }
}
