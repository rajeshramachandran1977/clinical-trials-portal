using System.Collections.Generic;
using System.Linq;
using Anju.Navigate.Utilities;

namespace Anju.Navigate.DataAccess
{
    public class CommonRepository
    {
        #region Properties

        private readonly Navigate30Context dbContextNavigate;

        public CommonRepository()
        {
            dbContextNavigate = new Navigate30Context();
        }


        #endregion

        #region Constructor


        public CommonRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }

        #endregion

        #region methods

        public int GetExceptionID()
        {            
            return 1;
        }



        /// <summary>
        /// Check for fields general visibility
        /// </summary>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> IsFieldRestrictedView()
        {
            var isfieldvisibilitysetforrole = dbContextNavigate.EditStudyAttributes.Where(x => x.IsViewable == false)
                                                     .Select(x => new Data.EditStudyAttributes
                                                     {
                                                         FieldType = x.FieldType
                                                     }).ToList();
            if (isfieldvisibilitysetforrole != null && isfieldvisibilitysetforrole.Count > 0)
                return isfieldvisibilitysetforrole;
            else
                return new List<Data.EditStudyAttributes>();
        }



        /// <summary>
        /// Check for fields role based visibility
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<Data.EditStudyAttributes> IsFieldRestrictedViewforgivenRole(string role)
        {
            var isfieldvisibilitysetforrole = dbContextNavigate.EditStudyAttributes.Where(x => x.IsViewable == true && x.RestrictViewUser == role)
                                                     .Select(x => new Data.EditStudyAttributes
                                                     {
                                                         FieldType = x.FieldType
                                                     }).ToList();
            if (isfieldvisibilitysetforrole != null && isfieldvisibilitysetforrole.Count > 0)
                return isfieldvisibilitysetforrole;
            else
                return new List<Data.EditStudyAttributes>();
        }


        /// <summary>
        /// Get Configured Email from Global settings
        /// </summary>
        /// <returns></returns>
        public string GetFromMail()
        {                        
            var frommail = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.MAILFROM)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                  }).FirstOrDefault(); 
            return frommail?.GlobalValue;
            
        }

        /// <summary>
        /// Get Configured Email from Global settings
        /// </summary>
        /// <returns></returns>
        public List<string> GetSMTPList()
        {
            var smtpObject = new object();
            List<string> smtpList = new List<string>();
            var frommail = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.MAILFROM)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                     }).FirstOrDefault();
            var smtpPort = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SMTP_PORT)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                     }).FirstOrDefault();
            var smtpPassword = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SMTP_PASSWORD)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                     }).FirstOrDefault();
            var smtpServerName = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SMTP_SERVER_NAME)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                     }).FirstOrDefault();
            var smtpTLSSecurity = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SMTP_TLS_SECURITY)
                                                     .Select(x => new Data.GlobalSettings
                                                     {
                                                         GlobalValue = x.GlobalValue
                                                     }).FirstOrDefault();
            var smtpUserName = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SMTP_USERNAME)
                                                    .Select(x => new Data.GlobalSettings
                                                    {
                                                        GlobalValue = x.GlobalValue
                                                    }).FirstOrDefault();
            smtpList.Add(frommail.GlobalValue);
            smtpList.Add(smtpPort.GlobalValue);
            smtpList.Add(smtpPassword.GlobalValue);
            smtpList.Add(smtpServerName.GlobalValue);
            smtpList.Add(smtpTLSSecurity.GlobalValue);
            smtpList.Add(smtpUserName.GlobalValue);

            return smtpList;

        }



        public bool SendMail(string body, string tomail, string subject, List<string> lsparameter, int studyId,string ccMail)
        {
            string salutation = dbContextNavigate.Users?.Where(x => x.UserName == tomail).FirstOrDefault().Salutation;
            string delimiter = ",";
            body = body.Replace("Salutation", salutation);
            string param = "", paramvalue = "";
            for (int i = 0; i < lsparameter.Count; i++)
            {
                param = "Param" + i;
                paramvalue = lsparameter[i];
                body = body.Replace(param, paramvalue);
                param = "";
            }

            EmailConfig objemailconfig = new Utilities.EmailConfig(); 
            objemailconfig.To = dbContextNavigate.Users?.Where(x => x.UserName == tomail).FirstOrDefault().PrimaryEmailId;
            if (!(string.IsNullOrEmpty(ccMail)))
            {
                var ccList = dbContextNavigate.Users?.AsEnumerable().Where(x => x?.UserType == ccMail && x?.IsActive == true && x?.IsDeleted == false).Select(x => x?.PrimaryEmailId).ToList()?.Aggregate((i, j) => i + delimiter + j);
                objemailconfig.CC = ccList;
            }
            objemailconfig.Subject = subject;
            objemailconfig.Body = body;

            bool result =Utilities.Utilities.SendMail(objemailconfig, GetSMTPList());
            return result;
        }

        public string GetCompanyName()
        {
            string appName = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.APPNAME).Select(x => x.GlobalValue).FirstOrDefault();
            return appName;
        }
        #endregion
    }
}