namespace Anju.Navigate.DataAccess
{
    internal static class Tools
    {
        private static DbProviders _dbProvider;

        public static DbProviders DbProvider
        {
            get
            {
                if (_dbProvider != DbProviders.None)
                    return _dbProvider;

                _dbProvider = DbProviders.MsSql;              

                return _dbProvider;
            }
        }
    }
}
