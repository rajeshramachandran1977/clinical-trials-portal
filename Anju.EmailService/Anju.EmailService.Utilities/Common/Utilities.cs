using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Anju.EmailService.Utilities
{
    public static class Utilities
    {
        /// <summary>
        /// Send Smtp mail
        /// </summary>
        /// <param name="emailConfig"></param>
        /// <returns>true</returns>
        public static bool SendMail(EmailConfig emailConfig, string fromMail)
        {
            try
            {

                using (var client = new SmtpClient())
                {
                    client.Host = ConfigValues.Host;
                    client.Port = ConfigValues.Port;
                    client.EnableSsl = ConfigValues.IsSSL;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(ConfigValues.FromMail, ConfigValues.SMTPPassword);

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

                    var mailMessage = new MailMessage(ConfigValues.FromMail, emailConfig.To);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = emailConfig.Subject;
                    mailMessage.Body = emailConfig.Body;
                    if (mailMessage.CC.Count > 0)
                        mailMessage.CC.Add(emailConfig.CC);
                    client.Send(mailMessage);

                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError("Utility:-SendMail:" + ex.ToString());
            }
            return false;
        }

        public static void LogError()
        {

        }

    }
}
