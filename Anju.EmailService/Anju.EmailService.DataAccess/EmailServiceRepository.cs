using Anju.EmailService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.EmailService.DataAccess
{
    public class EmailServiceRepository
    {
        #region Properties
        private readonly EmailServiceContext dbContextEmailService;
        string[] Arrayvalues;
      
        #endregion

        public EmailServiceRepository(EmailServiceContext dbContext)
        {
            dbContextEmailService = new EmailServiceContext();
        }

        public bool SendMail()
        {          
            List<string> reminders = new List<string>();
            bool Emailresult = false;

            try
            {
                reminders.Add(ConstDefaultValue.Enrollment_Reminder_Conf);
                reminders.Add(ConstDefaultValue.Document_Reminder_Conf);
                reminders.Add(ConstDefaultValue.Activation_Reminder_Conf);

                for (int i = 0; i < reminders.Count; i++)
                {
                    Arrayvalues = GetGlobalSetting(reminders[i]);

                    var result = GetMilestone(reminders[i], Convert.ToInt32(Arrayvalues[1]));
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            int studyid = item.StudyId;
                            Emailresult = ReminderMail(studyid, Arrayvalues, reminders[i]);
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                ErrorHandler.LogError("SendMail:" + ex.ToString());
            }
            return Emailresult;
        }

        private bool ReminderMail(int studyid,string[] values,string type)
        {
            int retVal = default(int);
            string userName = string.Empty;
            if (studyid > 0 && values.Length > 0)
            {
                for(int i =2;i<values.Length;i++)
                {
                    int codeId = Convert.ToInt32(RemoveSpecial(values[i]));
                    string userType = dbContextEmailService.SysCodeValues?.Where(x => x.CodeId == codeId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault()?.Code;
                    if(!string.IsNullOrEmpty(userType))
                    {
                        if(userType == ConstDefaultValue.PI)
                        {
                             userName = dbContextEmailService.NewStudy?.Where(x => x.StudyId == studyid).FirstOrDefault()?.ANJU_AddedBy;
                        }
                        else if(userType == ConstDefaultValue.TrialLeader) { 
                            userName = dbContextEmailService.PLStudyReview.AsEnumerable()
                                                        .Join(dbContextEmailService.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                        (pl, u) => new { pl, u })
                                                        .Where(x => x.pl.StudyId == studyid && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                        .Select(x => x.u.UserName).FirstOrDefault();
                        }
                        else if(userType == ConstDefaultValue.ProgramLeader)
                        {
                            userName = dbContextEmailService.PLStudyReview.AsEnumerable()
                                                    .Join(dbContextEmailService.Users.AsEnumerable(), pl => pl.PLuserId, u => u.UserId,
                                                    (pl, u) => new { pl, u })
                                                    .Where(x => x.pl.StudyId == studyid && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                    .Select(x => x.u.UserName).FirstOrDefault();
                        }
                        else if (userType == ConstDefaultValue.MSL)
                        {
                            userName = dbContextEmailService.StudyReview.AsEnumerable()
                                                    .Join(dbContextEmailService.Users.AsEnumerable(), sr => sr.MsluserId, u => u.UserId,
                                                    (sr, u) => new { sr, u })
                                                    .Where(x => x.sr.StudyId == studyid && x.sr.IsActive == true && x.sr.IsDeleted == false)
                                                    .Select(x => x.u.UserName).FirstOrDefault();
                        }
                        else if (userType == ConstDefaultValue.MD)
                        {
                            userName = dbContextEmailService.MRCStudyReview.Where(x => x.StudyId == studyid && x.IsActive == true && x.IsDeleted == false && x.RecordType == "LocalMRC")
                                                                            .Select(x => x.LocalMrcdecisionMadeBy).FirstOrDefault();
                        }
                        if (!string.IsNullOrEmpty(userName)) {

                            string salutation = dbContextEmailService.Users?.Where(x => x.UserName == userName).FirstOrDefault().Salutation;
                            string studyname = dbContextEmailService.NewStudy?.Where(x => x.StudyId == studyid).FirstOrDefault().TitleofTrial;
                            string body = string.Empty;
                            if (type == ConstDefaultValue.Enrollment_Reminder_Conf) { 
                                body = ConfigValues.EnrollmentReminderBody;
                                body = body.Replace("Salutation", salutation);
                                body = body.Replace("Param0", userName);
                                body = body.Replace("Param1", ConstDefaultValue.EnrollmentMilestoneName);
                                body = body.Replace("Param2", ConstDefaultValue.Enrollment);
                                body = body.Replace("Param3", "<a href='http://rdsb05.clinplus.com:8081/'>" + studyname + "</a>");
                            }
                            else if(type == ConstDefaultValue.Activation_Reminder_Conf)
                            {
                                body = ConfigValues.ActivationReminderBody;
                                body = body.Replace("Salutation", salutation);
                                body = body.Replace("Param0", userName);                                
                                body = body.Replace("Param3", "<a href='http://rdsb05.clinplus.com:8081/'>" + studyname + "</a>");
                            }
                            else if (type == ConstDefaultValue.Document_Reminder_Conf)
                            {
                                body = ConfigValues.DocumentReminderBody;
                                body = body.Replace("Salutation", salutation);
                                body = body.Replace("Param0", userName);
                                body = body.Replace("Param3", "<a href='http://rdsb05.clinplus.com:8081/'>" + studyname + "</a>");
                            }

                            EmailConfig objemailconfig = new Utilities.EmailConfig();
                            objemailconfig.To = dbContextEmailService.Users?.Where(x => x.UserName == userName).FirstOrDefault().PrimaryEmailId;

                            if (type == ConstDefaultValue.Enrollment_Reminder_Conf)
                                objemailconfig.Subject = ConfigValues.EnrollmentReminderSubject;
                            else if (type == ConstDefaultValue.Activation_Reminder_Conf)
                                objemailconfig.Subject = ConfigValues.ActivationReminderSubject;
                            else if (type == ConstDefaultValue.Document_Reminder_Conf)
                                objemailconfig.Subject = ConfigValues.DocumentReminderSubject;

                            objemailconfig.Body = body;
                            bool result = Utilities.Utilities.SendMail(objemailconfig, ConfigValues.FromMail);
                            if(result)
                            {
                                EmailMessages objEmailMessage = new EmailMessages
                                {
                                    StudyID = studyid,
                                    CreateDate = DateTime.UtcNow,
                                    SendDate = DateTime.UtcNow,
                                    FromAddress = ConfigValues.FromMail,
                                    ToAddress = objemailconfig.To,
                                    EmailSubject = objemailconfig.Subject,
                                    EmailBody = objemailconfig.Body
                                };
                                dbContextEmailService.EmailMessages.Add(objEmailMessage);
                                retVal=dbContextEmailService.SaveChanges();
                                if (retVal > 0)
                                    return true;
                                else
                                    return false;
                            }
                            else
                                 return result;
                        }                       
                    }
                }
            }
            return false;
        }

        private List<Milestones> GetMilestone(string type,int Noofdays)
        {
            var lstMilestones = new List<Milestones>();

            if (type == ConstDefaultValue.Enrollment_Reminder_Conf)
            {
                // int Noofdays = Convert.ToInt32(Arrayvalues[1]);
                //important please uncomment below commented lines and  comment dummy data query..
             
                lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x?.Type == ConstDefaultValue.Enrollment && x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null && x.Estimatedcompletiondate > DateTime.UtcNow && ((DateTime)x?.Estimatedcompletiondate).Subtract(DateTime.UtcNow.Date).Days == Noofdays)
               //lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x?.Type == ConstDefaultValue.Enrollment && x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null)
                                                                 .Select(x => new DataAccess.Milestones
                                                                 {
                                                                     StudyId = x.StudyId,
                                                                     Name = x.Name,
                                                                     Estimatedcompletiondate = x.Estimatedcompletiondate,
                                                                     Milestonecompletiondate = x.Milestonecompletiondate,
                                                                     MilestoneStatus = x.MilestoneStatus,
                                                                     Remindersentdate = x.Remindersentdate
                                                                 }).ToList();
               
            }
            else if(type == ConstDefaultValue.Document_Reminder_Conf)
            {
                lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x?.Type == ConstDefaultValue.Document && x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null && x.Estimatedcompletiondate > DateTime.UtcNow && ((DateTime)x?.Estimatedcompletiondate).Subtract(DateTime.UtcNow.Date).Days == Noofdays)                
                //lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x?.Type == ConstDefaultValue.Document && x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null )                
                                                                 .Select(x => new DataAccess.Milestones
                                                                 {
                                                                     StudyId = x.StudyId,
                                                                     Name = x.Name,
                                                                     Estimatedcompletiondate = x.Estimatedcompletiondate,
                                                                     Milestonecompletiondate = x.Milestonecompletiondate,
                                                                     MilestoneStatus = x.MilestoneStatus,
                                                                     Remindersentdate = x.Remindersentdate
                                                                 }).ToList();
            }
            else if(type == ConstDefaultValue.Activation_Reminder_Conf)
            {
                lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x.Name.Contains(ConstDefaultValue.Activation) && x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null && x.Estimatedcompletiondate > DateTime.UtcNow && ((DateTime)x?.Estimatedcompletiondate).Subtract(DateTime.UtcNow.Date).Days == Noofdays)
                //lstMilestones = dbContextEmailService.Milestones?.AsEnumerable().Where(x => x.Name.Contains(ConstDefaultValue.Activation)&& x?.IsActive == true && x.IsDeleted == false && x.Milestonecompletiondate == null)
                                                                 .Select(x => new DataAccess.Milestones
                                                                 {
                                                                     StudyId = x.StudyId,
                                                                     Name = x.Name,
                                                                     Estimatedcompletiondate = x.Estimatedcompletiondate,
                                                                     Milestonecompletiondate = x.Milestonecompletiondate,
                                                                     MilestoneStatus = x.MilestoneStatus,
                                                                     Remindersentdate = x.Remindersentdate
                                                                 }).ToList();
            }
            return lstMilestones;           

        }

        private string[] GetGlobalSetting(string type)
        {
           var lstGlobalSettings = dbContextEmailService.GlobalSettings?.Where(x => x.IsActive == true && x.IsDeleted == false && x.GlobalKey == type)
                                                      .Select(x => new DataAccess.GlobalSettings
                                                      {
                                                          GlobalValue = x.GlobalValue

                                                      }).FirstOrDefault().GlobalValue;
            Arrayvalues = lstGlobalSettings.Split(',');
            return Arrayvalues;
        }

        public string RemoveSpecial(string evalstr)
        {
            string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]","{","}" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (evalstr.Contains(chars[i]))
                {
                    evalstr = evalstr.Replace(chars[i], "");
                }
            }
            return evalstr;
        }
    }
}
