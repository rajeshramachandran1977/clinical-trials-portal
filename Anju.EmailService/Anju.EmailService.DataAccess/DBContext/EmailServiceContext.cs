using System;
using System.Collections.Generic;
using System.Text;
using Anju.EmailService.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Anju.EmailService.DataAccess
{
    public class EmailServiceContext : DbContext
    {
        #region Constructor      

        public EmailServiceContext(DbContextOptions<EmailServiceContext> options)
            : base(options)
        {
        }


        public EmailServiceContext()
        {

        }
        #endregion

        #region OverRide
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigValues.DBConnection);
            }
        }

        #endregion
        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
        public virtual DbSet<NewStudy> NewStudy { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<SysCodeValues> SysCodeValues { get; set; }  
        public virtual DbSet<PLStudyReview> PLStudyReview { get; set; }  
        public virtual DbSet<StudyReview> StudyReview { get; set; }  
        public virtual DbSet<MRCStudyReview> MRCStudyReview { get; set; }
        public virtual DbSet<EmailMessages> EmailMessages { get; set; }
    }
}
