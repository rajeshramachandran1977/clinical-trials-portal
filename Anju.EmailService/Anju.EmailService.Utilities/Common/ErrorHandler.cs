using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.EmailService.Utilities
{
    public class ErrorHandler
    {
        public static void LogError(string ErrorMsg)
        {
            System.IO.StreamWriter objWriter;
            string FILE_NAME;
            string logpath = "C:\\TessituraDataImport";
            if (!System.IO.Directory.Exists((logpath + "\\TessituraDataImport")))
            {
                System.IO.Directory.CreateDirectory((logpath + "\\TessituraDataImport"));
            }
            FILE_NAME = logpath + "\\TessituraDataImport" + "\\Log_" + System.DateTime.Now.ToString("MM-dd-yyy") + ".txt";
            if (!System.IO.File.Exists(FILE_NAME))
            {
                objWriter = System.IO.File.CreateText(FILE_NAME);
            }
            else
            {
                objWriter = new System.IO.StreamWriter(FILE_NAME, true);
            }
            objWriter.WriteLine(ErrorMsg);
            objWriter.WriteLine();
            objWriter.Close();
        }
    }
}
