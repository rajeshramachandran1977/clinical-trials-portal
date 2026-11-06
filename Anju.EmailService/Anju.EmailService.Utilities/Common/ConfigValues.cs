using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.EmailService.Utilities
{
    public class ConfigValues
    {
        public static string DBConnection { get; set; }
        public static string DBType { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static string FromMail { get; set; }
        public static string SMTPPassword { get; set; }
        public static bool IsSSL { get; set; }
        public static string EnrollmentReminderSubject { get; set; }
        public static string EnrollmentReminderBody { get; set; }
        public static string ActivationReminderSubject { get; set; }
        public static string ActivationReminderBody { get; set; }
        public static string DocumentReminderSubject { get; set; }
        public static string DocumentReminderBody { get; set; }
    }
}
