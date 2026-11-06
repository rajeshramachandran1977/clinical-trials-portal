using System;

namespace Anju.Navigate.Utilities
{
    public class ConfigValues
    {
        public static string DBConnection { get; set; }
        public static string DBType { get; set; }
        public static string ServiceURL { get; set; }
        public static string APIURL { get; set; }
        public static int LinkSession { get; set; }
        public static string ForgotPasswordTemplate { get; set; }
        public static string PasswordRecoverySubject { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static bool IsSSL { get; set; }
        public static DateTime ExpiryDate { get; set; }
        public static string DocumentsUploadFolderPath { get; set; }
        public static string DocumentMappedFolderPath { get; set; }
        public static string FromMail { get; set; }
        public static string appName { get; set; }
        public static string ipV4Address { get; set; }
        public static string ipV6Address { get; set; }
        public static string version { get; set; }
        public static string Year { get; set; }

    }
}
