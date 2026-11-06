using System;
using Anju.Navigate.DataAccess.DataEntities;
using Anju.Navigate.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OptimaJet.Workflow.DbPersistence;

namespace Anju.Navigate.DataAccess
{
    public partial class Navigate30Context : DbContext
    {
        #region Constructor      

        public Navigate30Context(DbContextOptions<Navigate30Context> options)
            : base(options)
        {
        }


        public Navigate30Context()
        {

        }
        #endregion

        #region Data Entities  
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Users_H> Users_H { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserRoles_H> UserRoles_H { get; set; }
        public virtual DbSet<SysCodeValues> SysCodeValues { get; set; }
        public virtual DbSet<SysCodeValues_H> SysCodeValues_H { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Country_H> Country_H { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<State_H> State_H { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<City_H> City_H { get; set; }
        public virtual DbSet<UserCredentials> UserCredentials { get; set; }
        public virtual DbSet<UserCredentials_H> UserCredentials_H { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
        public virtual DbSet<GlobalSettings_H> GlobalSettings_H { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistory { get; set; }
        public virtual DbSet<CohortLevels> CohortLevels { get; set; }
        public virtual DbSet<CohortLevels_H> CohortLevels_H { get; set; }
        public virtual DbSet<ObjectivesandEndpoints> ObjectivesandEndpoints { get; set; }
        public virtual DbSet<ObjectivesandEndpoints_H> ObjectivesandEndpoints_H { get; set; }
        public virtual DbSet<TreatmentInformation> TreatmentInformation { get; set; }
        public virtual DbSet<TreatmentInformation_H> TreatmentInformation_H { get; set; }
        public virtual DbSet<Age> Age { get; set; }
        public virtual DbSet<NewStudy> NewStudy { get; set; }
        public virtual DbSet<NewStudy_H> NewStudy_H { get; set; }
        public virtual DbSet<PrincipalInvestigator> PrincipalInvestigator { get; set; }
        public virtual DbSet<PrincipalInvestigator_H> PrincipalInvestigator_H { get; set; }
        public virtual DbSet<TrialPhase> TrialPhase { get; set; }
        public virtual DbSet<TrialPhase_H> TrialPhase_H { get; set; }
        public virtual DbSet<DrugorCompounddetails> DrugorCompounddetails { get; set; }
        public virtual DbSet<DrugorCompounddetails_H> DrugorCompounddetails_H { get; set; }
        public virtual DbSet<ConceptDesignandRationale> ConceptDesignandRationale { get; set; }
        public virtual DbSet<ConceptDesignandRationale_H> ConceptDesignandRationale_H { get; set; }
        public virtual DbSet<CorrelativeScienceStudies> CorrelativeScienceStudies { get; set; }
        public virtual DbSet<CorrelativeScienceStudies_H> CorrelativeScienceStudies_H { get; set; }
        public virtual DbSet<PlannedTrialMilestoneDatesandEnrollment> PlannedTrialMilestoneDatesandEnrollment { get; set; }
        public virtual DbSet<PlannedTrialMilestoneDatesandEnrollment_H> PlannedTrialMilestoneDatesandEnrollment_H { get; set; }
        public virtual DbSet<EmailList> EmailList { get; set; }
        public virtual DbSet<EmailList_H> EmailList_H { get; set; }
        public virtual DbSet<Center> Center { get; set; }
        public virtual DbSet<Center_H> Center_H { get; set; }
        public virtual DbSet<PharmacovigilanceRequirements> PharmacovigilanceRequirements { get; set; }
        public virtual DbSet<PharmacovigilanceRequirements_H> PharmacovigilanceRequirements_H { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Documents_H> Documents_H { get; set; }
        public virtual DbSet<StudyTask> StudyTask { get; set; }
        public virtual DbSet<StudyTask_H> StudyTask_H { get; set; }
        //public virtual DbSet<BannerImage> BannerImage { get; set; }
        public virtual DbSet<StudyReview> StudyReview { get; set; }
        public virtual DbSet<StudyReview_H> StudyReview_H { get; set; }
        public virtual DbSet<DocumentSubTypes> DocumentSubTypes { get; set; }
        public virtual DbSet<PLStudyReview> PLStudyReview { get; set; }
        public virtual DbSet<PLStudyReview_H> PLStudyReview_H { get; set; }
        public virtual DbSet<EditStudyAttributes> EditStudyAttributes { get; set; }
        public virtual DbSet<EditStudyAttributes_H> EditStudyAttributes_H { get; set; }
        public virtual DbSet<MRCStudyReview> MRCStudyReview { get; set; }
        public virtual DbSet<MRCStudyReview_H> MRCStudyReview_H { get; set; }
        public virtual DbSet<StudyCompounds> StudyCompounds { get; set; }
        public virtual DbSet<StudyCompounds_H> StudyCompounds_H { get; set; }
        public virtual DbSet<IISAdmindetails> IISAdmindetails { get; set; }
        public virtual DbSet<IISAdmindetails_H> IISAdmindetails_H { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<AttributeSearchResult> SearchResult { get; set; }
        public virtual DbSet<ProxyUserDetails> ProxyUserDetails { get; set; }
        public virtual DbSet<ProxyUserDetails_H> ProxyUserDetails_H { get; set; }
        public virtual DbSet<StudyIndication> StudyIndication { get; set; }
        public virtual DbSet<StudyIndication_H> StudyIndication_H { get; set; }
        public virtual DbSet<StudyProtocol> StudyProtocol { get; set; }
        public virtual DbSet<StudyProtocol_H> StudyProtocol_H { get; set; }
        public virtual DbSet<StudySites> StudySites { get; set; }
        public virtual DbSet<StudySites_H> StudySites_H { get; set; }
        public virtual DbSet<PatientAccrual> PatientAccrual { get; set; }
        public virtual DbSet<PatientAccrual_H> PatientAccrual_H { get; set; }
        public virtual DbSet<GMRCApprovalTask> GMRCApprovalTask { get; set; }
        public virtual DbSet<GMRCApprovalTask_H> GMRCApprovalTask_H { get; set; }
        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<Milestones_H> Milestones_H { get; set; }
        public virtual DbSet<Invoicedetails> Invoicedetails { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Status_H> Status_H { get; set; }
        public virtual DbSet<LoginAttempts> LoginAttempts { get; set; }
        public virtual DbSet<DefaultMileStone> DefaultMileStone { get; set; }
        public virtual DbSet<DefaultMileStone_H> DefaultMileStone_H { get; set; }
        public virtual DbSet<ReviewsandNotes> ReviewsandNotes { get; set; }
        public virtual DbSet<ReviewsandNotes_H> ReviewsandNotes_H { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }
        public virtual DbSet<Submissions_H> Submissions_H { get; set; }
        public virtual DbSet<Contracttimelines> Contracttimelines { get; set; }
        public virtual DbSet<Contracttimelines_H> Contracttimelines_H { get; set; }
        #endregion

        #region  "Workflow"
        public virtual DbSet<WorkflowScheme> WorkflowScheme { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationWorkflowLog> OperationWorkflowLog { get; set; }
        #endregion

        #region Overrides

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            if (entity is ReadOnlyEntityBase)
            {
                (entity as ReadOnlyEntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as ReadOnlyEntityBase).ANJU_AddedBy = "System";
            }

            if (entity is EntityBase)
            {
                (entity as EntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_AddedBy = "System";

                (entity as EntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_ChangedBy = "System";
            }

            if (entity is HistoryReadOnlyEntityBase)
            {
                (entity as HistoryReadOnlyEntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as HistoryReadOnlyEntityBase).ANJU_AddedBy = "System";
            }

            if (entity is HistoryEntityBase)
            {
                (entity as HistoryEntityBase).ANJU_AddDate = DateTime.UtcNow; //ANJU_AddDate
                (entity as HistoryEntityBase).ANJU_AddedBy = "System";

                (entity as HistoryEntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as HistoryEntityBase).ANJU_ChangedBy = "System";
            }

            return base.Add(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is EntityBase)
            {
                (entity as EntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_ChangedBy = "System";
            }

            if (entity is HistoryEntityBase)
            {
                (entity as HistoryEntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as HistoryEntityBase).ANJU_ChangedBy = "System";
            }

            return base.Update(entity);
        }
        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigValues.DBConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            
            modelBuilder.Entity<WorkflowScheme>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.Scheme).IsRequired();
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ProxyUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkflowName)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<OperationWorkflowLog>(entity =>
            {
                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ProxyUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.OperationWorkflowLog)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperationWorkflow_Operation");
            });
        }

        public EntityEntry Add<TEntity>(string loginUserName, TEntity entity)
        {
            if (entity is ReadOnlyEntityBase)
            {
                (entity as ReadOnlyEntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as ReadOnlyEntityBase).ANJU_AddedBy = loginUserName;
            }

            if (entity is EntityBase)
            {
                (entity as EntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_AddedBy = loginUserName;

                (entity as EntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_ChangedBy = loginUserName;
            }

            if (entity is HistoryReadOnlyEntityBase)
            {
                (entity as HistoryReadOnlyEntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as HistoryReadOnlyEntityBase).ANJU_AddedBy = loginUserName;
            }

            if (entity is HistoryEntityBase)
            {
                (entity as HistoryEntityBase).ANJU_AddDate = DateTime.UtcNow;
                (entity as HistoryEntityBase).ANJU_AddedBy = loginUserName;

                (entity as HistoryEntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as HistoryEntityBase).ANJU_ChangedBy = loginUserName;
            }

            return base.Add(entity);
        }

        public EntityEntry Update<TEntity>(string loginUserName, TEntity entity)
        {
            if (entity is EntityBase)
            {
                (entity as EntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as EntityBase).ANJU_ChangedBy = loginUserName;
            }

            if (entity is HistoryEntityBase)
            {
                (entity as HistoryEntityBase).ANJU_ChangeDate = DateTime.UtcNow;
                (entity as HistoryEntityBase).ANJU_ChangedBy = loginUserName;
            }

            return base.Update(entity);
        }

        public int SaveChanges<TEntity, THistoryEntity>(TEntity entity, THistoryEntity historyEntity, string loginUserName, Anju.Navigate.Utilities.eAuditChangeType changeType)
        {
            if (changeType == Utilities.eAuditChangeType.Insert)
            {
                this.Add(loginUserName, entity);
            }
            else if (changeType == Utilities.eAuditChangeType.Update)
            {
                this.Update(loginUserName, entity);
            }
            else if (changeType == Utilities.eAuditChangeType.Delete)
            {               
                this.Update(loginUserName, entity);
            }

            int recordsAffected = base.SaveChanges();

            if (recordsAffected > 0 && historyEntity != null)
            {
                Anju.Navigate.Utilities.Utilities.CopyEntityByField(entity, historyEntity);

                (historyEntity as HistoryEntityBase).ANJU_ChangeType = (int)changeType;
                (historyEntity as HistoryEntityBase).ANJU_HistoryDate = DateTime.UtcNow;

                this.Add(loginUserName, historyEntity);

                this.SaveChanges();
            }

            return recordsAffected;
        }


        

        #endregion
    }
}
