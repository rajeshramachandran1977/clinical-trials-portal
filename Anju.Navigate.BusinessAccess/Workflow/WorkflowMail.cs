using System;
using System.Net;
using System.Net.Mail;

namespace Anju.Navigate.BusinessAccess.Workflow
{
    public class WorkflowMail
    {
        public const string Host = "";
        public const int Port = 0;
        public const string From = "";
        public const string FromPassword = "";

        public static void SendEmail(WorkflowMessage mailDetails)
        {
            try
            {
                var smtp = new SmtpClient(Host, Port)
                {
                    Credentials = new NetworkCredential(From, FromPassword)
                };

                var message = new MailMessage
                {
                    From = new MailAddress(From)
                };
                message.To.Add(new MailAddress(string.Join(",", mailDetails.To)));
                message.CC.Add(new MailAddress(string.Join(",", mailDetails.Cc)));
                message.Subject = mailDetails.Subject;
                message.Body = mailDetails.Message;
                smtp.Send(message);
            }
            catch (Exception)
            {
                throw new Exception("Workflow Mail failed");
            }
        }
    }
}
