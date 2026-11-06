using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Mail;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Anju.Navigate.Utilities
{
    public static class Utilities
    {
        //Get AppDomain
        //Start
        private static IHttpContextAccessor m_httpContextAccessor;
        public static HttpContext Current => m_httpContextAccessor.HttpContext;
        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            m_httpContextAccessor = contextAccessor;
        }


        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IApplicationBuilder UseHttpContext(this IApplicationBuilder app)
        {
            Utilities.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            return app;
        }
        //End


        /// <summary>
        /// Send Smtp mail
        /// </summary>
        /// <param name="emailConfig"></param>
        /// <returns>true</returns>
        public static bool SendMail(EmailConfig emailConfig,List<string> smtpList)
        {
            try
            {
                
                using (var client = new SmtpClient())
                {
                    if (smtpList[3] != null || smtpList[3] != "")
                    {
                        client.Host = smtpList[3];
                    }
                    else {
                        client.Host = ConfigValues.Host;
                    }
                    if (smtpList[1] != null || smtpList[1] != "")
                    {
                        client.Port = Convert.ToInt32(smtpList[1]);
                    }
                    else
                    {
                        client.Port = ConfigValues.Port;
                    }
                    var fromMail = "";
                    var smtpPassword = "";

                    if (smtpList[0] != null || smtpList[0] != "")
                    {
                        fromMail = smtpList[0];
                    }
                   
                    if (smtpList[2] != null || smtpList[2] != "")
                    {
                        smtpPassword = smtpList[2];
                    }
                    else
                    {
                        client.Port = ConfigValues.Port;
                    }
                    client.EnableSsl = ConfigValues.IsSSL;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(fromMail, smtpPassword);

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

                    var mailMessage = new MailMessage(smtpList[0], emailConfig.To);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = emailConfig.Subject;
                    mailMessage.Body = emailConfig.Body;
                    if(mailMessage.CC.Count > 0 )
                        mailMessage.CC.Add(emailConfig.CC);
                    client.Send(mailMessage);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// Copy Entity By Field
        /// </summary>
        /// <param name="fromEntity"></param>
        /// <param name="toEntity"></param>
        public static void CopyEntityByField(Object fromEntity, Object toEntity)
        {
            PropertyInfo[] sourceProperties = fromEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);

            if (sourceProperties == null)
                return;

            bool performCopy = true;

            foreach (PropertyInfo fromProp in sourceProperties)
            {
                performCopy = true;

                if (performCopy)
                {
                    object sourceValue = fromProp.GetValue(fromEntity, null);

                    if (sourceValue != null)
                    {
                        PropertyInfo toProp = toEntity.GetType().GetProperty(fromProp.Name);

                        if (toProp != null)
                        {
                            toProp.SetValue(toEntity, sourceValue, null);
                        }
                    }
                }
            }
        }
    }   
}
