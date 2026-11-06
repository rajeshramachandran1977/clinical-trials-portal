using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
namespace Anju.Navigate.DataAccess
{
    internal class DbTableAttribute : TableAttribute
    {
        public DbTableAttribute(string msSqlName, string oracleName, string msSqlSchema = null, string oracleSchema = null)
            : base(Tools.DbProvider == DbProviders.MsSql ? msSqlName
                : Tools.DbProvider == DbProviders.Oracle ? oracleName
                : null)
        {
            switch (Tools.DbProvider)
            {
                case DbProviders.MsSql:
                    Schema = (string.IsNullOrEmpty(msSqlSchema) ? "dbo" : msSqlSchema);
                    break;
                case DbProviders.Oracle:
                    Schema = (oracleSchema == "IRMS" ? ConfigurationManager.AppSettings["OraclDBOSchema"] : ConfigurationManager.AppSettings["OracleAESchema"]);
                    break;
            }
        }
    }
}
