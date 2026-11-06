using System;
using System.IO;
using Anju.EmailService.BusinessAccess;
using Anju.EmailService.Utilities;
using Microsoft.Extensions.Configuration;

namespace Anju.EmailService
{
    public class EmailService
    {
        static void Main(string[] args)
        {
            try
            {
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");
                //builder.Properties[0].ke
                var configuration = builder.Build();
                ConfigValues.DBConnection = configuration.GetConnectionString("SqlConnectionString");
                ConfigValues.Host = configuration.GetSection("Host")["Value"].ToString();
                ConfigValues.Port = Convert.ToInt32(configuration.GetSection("SMTPPort")["Value"].ToString());
                ConfigValues.SMTPPassword = configuration.GetSection("SMTPPassword")["Value"].ToString();
                ConfigValues.FromMail = configuration.GetSection("FromMail")["Value"].ToString();


                ConfigValues.EnrollmentReminderSubject = configuration.GetSection("Enrollement_Reminder")["Subject"].ToString();
                ConfigValues.EnrollmentReminderBody = configuration.GetSection("Enrollement_Reminder")["Body"].ToString();

                ConfigValues.ActivationReminderSubject = configuration.GetSection("Activation_Reminder")["Subject"].ToString();
                ConfigValues.ActivationReminderBody = configuration.GetSection("Activation_Reminder")["Body"].ToString();

                ConfigValues.DocumentReminderSubject = configuration.GetSection("Document_Reminder")["Subject"].ToString();
                ConfigValues.DocumentReminderBody = configuration.GetSection("Document_Reminder")["Body"].ToString();

                bool mailsend = new BusinessAccess.EmailService().SendMail();
            }
            catch (Exception ex)
            {

                ErrorHandler.LogError("Main:" + ex.ToString());
            }

        }
    }
}
