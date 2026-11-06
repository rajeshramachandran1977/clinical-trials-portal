IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SysCodeValues') 
	BEGIN
		CREATE TABLE [dbo].[SysCodeValues](
		[CodeID] [int] IDENTITY(1,1) NOT NULL,
		[TableName] [nvarchar](255) NOT NULL,
		[ColumnName] [nvarchar](255) NOT NULL,
		[Code] [nvarchar](255) NULL,
		[Description] [nvarchar](255) NULL,
		[SortOrder] [int] NULL,
		[IsDefault] [bit] NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT DF_SysCodeValues_IsActive DEFAULT (1),
		[IsDeleted] [bit] NOT NULL CONSTRAINT DF_SysCodeValues_IsDeleted DEFAULT (0),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_SysCodeValues] PRIMARY KEY CLUSTERED ([CodeID] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Attribute') 
	BEGIN
		CREATE TABLE [dbo].[Attribute](
		[AttributeID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](300) NOT NULL,
		[Description] [nvarchar](300) NOT NULL,
		[IsSearchable] [bit] NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[RefrenceTableName] [nvarchar](100) NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
		(
			[AttributeID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Center') 
	BEGIN
		CREATE TABLE [dbo].[Center](
		[CenterId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[Institution] [nvarchar](max) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_Center] PRIMARY KEY CLUSTERED 
		(
			[CenterId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Country') 
	BEGIN
		CREATE TABLE [dbo].[Country](
		[CountryId] [int] IDENTITY(1,1) NOT NULL,
		[Code] [nvarchar](3) NOT NULL,
		[Name] [nvarchar](100) NOT NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_Country_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Country_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_Country_CountryId] PRIMARY KEY CLUSTERED 
		(
			[CountryId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'State') 
	BEGIN
		CREATE TABLE [dbo].[State](
		[StateId] [int] IDENTITY(1,1) NOT NULL,
		[CountryId] [int] NOT NULL,
		[Name] [nvarchar](100) NOT NULL,
		[Code] [nvarchar](3) NOT NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_State_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_State_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_County_Id] PRIMARY KEY CLUSTERED 
		(
			[StateId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
		 CONSTRAINT [IX_State_Name_Country_Id] UNIQUE NONCLUSTERED 
		(
			[Name] ASC,
			[CountryId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_CountryId] FOREIGN KEY([CountryId])
		REFERENCES [dbo].[Country] ([CountryId])

		ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_CountryId]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Status') 
	BEGIN
		CREATE TABLE [dbo].[Status](
		[StatusId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[Stage] [nvarchar](255) NULL,
		[State] [nvarchar](255) NULL,
		[StudyStatus] [nvarchar](255) NULL,
		[Date] [datetime] NULL,
		[Time] [nvarchar](255) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
		(
			[StatusId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'City') 
	BEGIN
		CREATE TABLE [dbo].[City](
		[CityId] [int] IDENTITY(1,1) NOT NULL,
		[StateId] [int] NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_City_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_City_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_City_Id] PRIMARY KEY CLUSTERED 
		(
			[CityId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
		CONSTRAINT [IX_City_state_Name] UNIQUE NONCLUSTERED 
		(
			[StateId] ASC,
			[Name] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_StateId] FOREIGN KEY([StateId])
		REFERENCES [dbo].[State] ([StateId])		

		ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_StateId]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CohortLevels') 
	BEGIN
		CREATE TABLE [dbo].[CohortLevels](
		[CohortID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[NoofPatients] [int] NULL,
		[Cohortlevel] [varchar](50) NULL,
		[DoseandFrequencyDrugA] [varchar](50) NULL,
		[DoseandFrequencyDrugB] [varchar](50) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_CohortLevels] PRIMARY KEY CLUSTERED 
		(
			[CohortID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ConceptDesignandRationale') 
	BEGIN
		CREATE TABLE [dbo].[ConceptDesignandRationale](
		[ConceptDesignandRationaleID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[Indication] [nvarchar](max) NULL,
		[RationaleforTrial] [nvarchar](max) NULL,
		[TrialDesign] [nvarchar](max) NULL,
		[Binding] [nvarchar](50) NULL,
		[Structure] [nvarchar](50) NULL,
		[Randomized] [nvarchar](50) NULL,
		[Gender] [varchar](50) NULL,
		[MinimumAge] [varchar](50) NULL,
		[MaximumAge] [varchar](50) NULL,
		[PatientPopulation] [nvarchar](max) NULL,
		[KeyInclusionCriteria] [nvarchar](max) NULL,
		[KeyExclusionCriteria] [nvarchar](max) NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ConceptDesignandRationale] PRIMARY KEY CLUSTERED 
		(
			[ConceptDesignandRationaleID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CorrelativeScienceStudies') 
	BEGIN
		CREATE TABLE [dbo].[CorrelativeScienceStudies](
		[CorrelativeScienceStudiesID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[IsincludeCorrelativeScience] [bit] NULL,
		[BiomarkerStudiesperformedatStudySite] [nvarchar](max) NULL,
		[BiomarkerStudiesperformedatCompanySite] [nvarchar](max) NULL,
		[BiomarkerSamplingDetails] [nvarchar](max) NULL,
		[ANJU_AddedBy] [nvarchar](50) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](50) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_CorrelativeScienceStudies] PRIMARY KEY CLUSTERED 
		(
			[CorrelativeScienceStudiesID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END;


IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Documents') 
	BEGIN
		CREATE TABLE [dbo].[Documents](
		[DocumentId] [int] IDENTITY(1,1) NOT NULL,
		[DocumentName] [nvarchar](max) NOT NULL,
		[DocumentNameWithOutExtension] [nvarchar](50) NULL,
		[StudyId] [int] NULL,
		[SubModuleID] [int] NULL,
		[SubModuleName] [nvarchar](100) NULL,
		[DocumentSize] [int] NOT NULL,
		[DocumentExtension] [nvarchar](100) NOT NULL,
		[Path] [nvarchar](max) NULL,
		[DocumentStatus] [nvarchar](50) NULL,
		[DocumentType] [nvarchar](50) NULL,
		[DocumentSubType] [nvarchar](50) NULL,
		[DocumentVersion] [nvarchar](50) NULL,
		[OriginalDate] [datetime] NULL,
		[ExpirationDate] [datetime] NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[IsSubmit] [bit] NULL,
		[IsActivated] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](50) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](50) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
		(
			[DocumentId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Documents_H') 
BEGIN
	CREATE TABLE [dbo].[Documents_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[DocumentName] [nvarchar](max) NOT NULL,
	[DocumentNameWithOutExtension] [nvarchar](50) NULL,
	[StudyId] [int] NOT NULL,
	[SubModuleID] [int] NULL,
	[SubModuleName] [nvarchar](100) NULL,
	[DocumentSize] [int] NOT NULL,
	[DocumentExtension] [nvarchar](100) NOT NULL,
	[Path] [nvarchar](max) NULL,
	[DocumentStatus] [nvarchar](50) NULL,
	[DocumentType] [nvarchar](50) NULL,
	[DocumentSubType] [nvarchar](50) NULL,
	[DocumentVersion] [nvarchar](50) NULL,
	[OriginalDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[IsSubmit] [bit] NULL,
	[IsActivated] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](50) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](50) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Documents_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DocumentSubTypes') 
	BEGIN
		CREATE TABLE [dbo].[DocumentSubTypes](
		[DocumentSubTypeId] [int] IDENTITY(1,1) NOT NULL,
		[DocumentTypeId] [int] NOT NULL,
		[Name] [nvarchar](100) NOT NULL,
		[Code] [nvarchar](100) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_DocumentSubTypes] PRIMARY KEY CLUSTERED 
		(
			[DocumentSubTypeId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DrugorCompounddetails') 
	BEGIN
		CREATE TABLE [dbo].[DrugorCompounddetails](
		[DrugorCompounddetailsID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[Primarydrug] [nvarchar](50) NOT NULL,
		[Secondarydrug] [nvarchar](50) NULL,
		[Tertiarydrug] [nvarchar](50) NULL,
		[SecondaryType] [nvarchar](50) NULL,
		[TertiaryaryType] [nvarchar](50) NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_DrugorCompounddetails] PRIMARY KEY CLUSTERED 
		(
			[DrugorCompounddetailsID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EditStudyAttributes') 
	BEGIN
		CREATE TABLE [dbo].[EditStudyAttributes](
		[EditstudyattributeId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](300) NOT NULL,
		[ParentID] [int] NULL,
		[ParentName] [nvarchar](300) NULL,
		[ChildId] [int] NULL,
		[ChildName] [nvarchar](300) NULL,
		[SubChildID] [int] NULL,
		[SubChildName] [nvarchar](300) NULL,
		[GrandChildId] [int] NULL,
		[GrandChildName] [nvarchar](300) NULL,
		[Description] [nvarchar](300) NULL,
		[FieldType] [nvarchar](max) NULL,
		[HelpText] [nvarchar](max) NULL,
		[Type] [nvarchar](50) NULL,
		[ListofValuesId] [int] NULL,
		[Size] [nvarchar](50) NULL,
		[IsMandatory] [bit] NULL,
		[IsViewable] [bit] NULL,
		[IsSearchable] [bit] NULL,
		[DisplayOrder] [int] NULL,
		[ColumnWidth] [int] NULL,
		[RegexExpression] [nvarchar](max) NULL,
		[ValidationMessage] [nvarchar](max) NULL,
		[GroupPermissionsId] [int] NULL,
		[RestrictCreateUser] [varchar](max) NULL,
		[RestrictViewUser] [varchar](max) NULL,
		[RestrictEditUser] [varchar](max) NULL,
		[IsFieldViewableInMetaData] [bit] NULL,
		[RestrictDeleteUser] [varchar](max) NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_EditStudyAttributes] PRIMARY KEY CLUSTERED 
		(
			[EditstudyattributeId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailList') 
	BEGIN
		CREATE TABLE [dbo].[EmailList](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[Email] [nvarchar](60) NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_EmailList] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GlobalSettings') 
	BEGIN
		CREATE TABLE [dbo].[GlobalSettings](
		[GlobalId] [int] IDENTITY(1,1) NOT NULL,
		[GlobalKey] [nvarchar](50) NULL,
		[GlobalValue] [nvarchar](max) NULL,
		[Remarks] [nvarchar](max) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_GlobalSettings] PRIMARY KEY CLUSTERED 
		(
			[GlobalId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'IISAdmindetails') 
	BEGIN
		CREATE TABLE [dbo].[IISAdmindetails](
	[IISAdmindetailsid] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Studydescriptors] [nvarchar](255) NULL,
	[InvestigationalDrugandReferenceTherapy] [nvarchar](255) NULL,
	[PatientType] [varchar](50) NULL,
	[Safetycriteria] [nvarchar](255) NULL,
	[Othercompanycompound] [nvarchar](255) NULL,
	[IsPlacebocontrolled] [bit] NULL,
	[Studydesign] [nvarchar](255) NULL,
	[Rationaleforstudy] [nvarchar](255) NULL,
	[Basisforsamplesize] [nvarchar](255) NULL,
	[Riskfactors] [nvarchar](255) NULL,
	[GenomicProfile] [nvarchar](255) NULL,
	[Lineoftherapy] [nvarchar](255) NULL,
	[Disease] [nvarchar](255) NULL,
	[Diseasepaatientpopulation] [nvarchar](255) NULL,
	[DiseaseStage] [nvarchar](255) NULL,
	[TreatmentSegment] [nvarchar](255) NULL,
	[LineofTreatment] [nvarchar](255) NULL,
	[Qualityoflife] [nvarchar](255) NULL,
	[Indicationforsciencemain] [nvarchar](255) NULL,
	[Studyduration] [nvarchar](255) NULL,
	[Noofpatientspertreatmentgroup] [nvarchar](255) NULL,
	[Enrollmentrate] [int] NULL,
	[FinalINDStatus] [nvarchar](255) NULL,
	[INDNumber] [nvarchar](255) NULL,
	[Credentials] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[Region] [nvarchar](255) NULL,
	[Interventionaltrialdatacollection] [nvarchar](255) NULL,
	[NonInterventionaltrialdatacollection] [nvarchar](255) NULL,
	[StudySponsor] [nvarchar](255) NULL,
	[StudyDrugSource] [nvarchar](255) NULL,
	[OtherCooperativeGroup] [nvarchar](255) NULL,
	[Isrequestingacompanystudycompound] [bit] NULL,
	[Othersupportdescription] [nvarchar](255) NULL,
	[Isrequestingsupportfromcompanyotherthandrugorfunding] [bit] NULL,
	[Globalfundingrequested] [int] NULL,
	[Isamendmentrequestincludesachangeintheprimaryinvestigator] [bit] NULL,
	[Isautoproxyenabled] [bit] NULL,
	[Leadorganization] [nvarchar](255) NULL,
	[Isconditionalapproval] [bit] NULL,
	[Conditionsofapproval] [nvarchar](max) NULL,
	[ICFReview] [nvarchar](255) NULL,
	[Amendmentstatus] [nvarchar](255) NULL,
	[Amendmenttype] [nvarchar](255) NULL,
	[Contractamendmentrequired] [nvarchar](255) NULL,
	[Ipistudyssponsor] [bit] NULL,
	[Migrationdate] [datetime] NULL,
	[Conversionstatus] [nvarchar](255) NULL,
	[Milestoneupdatefrequencydays] [int] NULL,
	[Accrualmilestoneupdatefrequencydays] [int] NULL,
	[Lastsendemail] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_IISAdmindetails] PRIMARY KEY CLUSTERED 
(
	[IISAdmindetailsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	END;

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log') 
	BEGIN
		CREATE TABLE [dbo].[Log](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Application] [nvarchar](50) NOT NULL,
		[Logged] [datetime] NOT NULL,
		[Level] [nvarchar](50) NOT NULL,
		[Message] [nvarchar](max) NOT NULL,
		[Logger] [nvarchar](250) NULL,
		[Callsite] [nvarchar](max) NULL,
		[Exception] [nvarchar](max) NULL,
		[MiiwaData] [nvarchar](max) NULL,
		[RetryCount] [tinyint] NULL,
		 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginAttempts') 
	BEGIN
		CREATE TABLE [dbo].[LoginAttempts](
		[LoginattemptId] [int] IDENTITY(1,1) NOT NULL,
		[UserID] [nvarchar](255) NULL,
		[IPv4Address] [nvarchar](255) NULL,
		[IPv6Address] [nvarchar](255) NULL,
		[DateTime] [nvarchar](255) NULL,
		[LoginAttemptStatus] [nvarchar](63) NULL,
		 CONSTRAINT [PK_LoginAttempts] PRIMARY KEY CLUSTERED 
		(
			[LoginattemptId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NewStudy') 
	BEGIN
		CREATE TABLE [dbo].[NewStudy](
		[StudyID] [int] IDENTITY(1,1) NOT NULL,
		[StudyType] [nvarchar](300) NULL,
		[TitleofTrial] [nvarchar](300) NULL,
		[Treatmentarms] [nvarchar](max) NULL,
		[SampleSizeJustificationandStatisticalAnalysis] [nvarchar](max) NULL,
		[ClinicalPharmacology] [nvarchar](max) NULL,
		[EnrollmentHistoryforOtherRelatedStudies] [nvarchar](300) NULL,
		[IsCompetingStudies] [bit] NULL,
		[CompetingStudies] [nvarchar](300) NULL,
		[IsINDSubmission] [bit] NULL,
		[RationaleforINDExemption] [nvarchar](1000) NULL,
		[IsIRBRegistrationRequirement] [bit] NULL,
		[KeyReferences] [nvarchar](max) NULL,
		[MedicalSpecialty] [nvarchar](300) NULL,
		[BoardCertification] [nvarchar](300) NULL,
		[MedicalLicense] [nvarchar](300) NULL,
		[IsCompanySponsoredtrial] [bit] NULL,
		[DrugName] [nvarchar](300) NULL,
		[ProtocolNumber] [nvarchar](300) NULL,
		[TrialParticipation] [nvarchar](300) NULL,
		[IsOtherTrainingsReceived] [bit] NULL,
		[LastTrainingDetails] [nvarchar](300) NULL,
		[TypeOfTraining] [nvarchar](300) NULL,
		[TrialExperiences] [nvarchar](max) NULL,
		[NumberOfOngoingTrials] [nvarchar](300) NULL,
		[IsSiteInspectedByHealthAuthority] [bit] NULL,
		[NameOfHealthAuthority] [nvarchar](300) NULL,
		[DateOflastInspection] [datetime] NULL,
		[IsSiteInspectedByFDA] [bit] NULL,
		[DateOfFDAInspection] [datetime] NULL,
		[ISFDA483formIssued] [bit] NULL,
		[DetailsOfObservation] [nvarchar](max) NULL,
		[IsCooperativeGroupStudy] [bit] NULL,
		[CooperativeGroupName] [nvarchar](63) NULL,
		[IsPhysicianNetworkStudy] [bit] NULL,
		[PhysicianNetworkName] [nvarchar](300) NULL,
		[IsGovernmentSupportProvided] [bit] NULL,
		[SupportDescription] [nvarchar](300) NULL,
		[IsSupportProvidedByOtherSources] [bit] NULL,
		[SupportSources] [nvarchar](300) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[IsRequestedForDrugSupply] [bit] NULL,
		[IsRequestedForFinancialSupport] [bit] NULL,
		[BudgetRequestedForTrial] [int] NULL,
		[Stage] [nvarchar](50) NULL,
		[State] [nvarchar](max) NULL,
		[TaskStatus] [nvarchar](max) NULL,
		[PITaskStatus] [nvarchar](max) NULL,
		[TaskName] [nvarchar](max) NULL,
		[InvestigationalSiteProtocolNumber] [nvarchar](350) NULL,
		[StudyActivationDate] [datetime] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_NewProposalSubmission] PRIMARY KEY CLUSTERED 
		(
			[StudyID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MRCStudyReview') 
	BEGIN
		CREATE TABLE [dbo].[MRCStudyReview](
		[MRCReviewId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[RecordType] [varchar](50) NULL,
		[LocalMRCDecision] [varchar](50) NULL,
		[LocalMRCDecisionComments] [varchar](100) NULL,
		[LocalMRCDateOfDecision] [datetime] NULL,
		[LocalMRCDecisionMadeBy] [varchar](50) NULL,
		[SAEReconciliationFrequency] [varchar](50) NULL,
		[GlobalMRCDecision] [varchar](50) NULL,
		[GlobalMRCDecisionDate] [datetime] NULL,
		[MACSNumber] [varchar](50) NULL,
		[StudyNumber] [varchar](50) NULL,
		[MRCDecisionRejectedBy] [varchar](50) NULL,
		[MRCRejectedDeliveryMethod] [varchar](50) NULL,
		[MRCDecisionWithdrawalBy] [varchar](50) NULL,
		[MRCWithdrawalDeliveryMethod] [varchar](50) NULL,
		[CAResubmissionDecision] [varchar](50) NULL,
		[CAResubmissionComments] [varchar](max) NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_MRCStudyReview] PRIMARY KEY CLUSTERED 
		(
			[MRCReviewId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[MRCStudyReview]  WITH CHECK ADD  CONSTRAINT [FK_MRCStudyReview_MRCStudyReview] FOREIGN KEY([StudyId])
		REFERENCES [dbo].[NewStudy] ([StudyID])

		ALTER TABLE [dbo].[MRCStudyReview] CHECK CONSTRAINT [FK_MRCStudyReview_MRCStudyReview]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GMRCApprovalTask') 
	BEGIN
		CREATE TABLE [dbo].[GMRCApprovalTask](
		[GMRCApprovalTaskId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[TaskName] [nvarchar](50) NOT NULL,
		[AssignedTo] [nvarchar](50) NOT NULL,
		[IsTaskCompleted] [bit] NULL,
		[IsGearTaskCompleted] [bit] NULL,
		[ContractType] [nvarchar](50) NULL,
		[ContractStatus] [nvarchar](50) NULL,
		[CurrentLocation] [nvarchar](50) NULL,
		[ContactName] [nvarchar](50) NULL,
		[SubmissionDate] [datetime] NULL,
		[ExecutionDate] [datetime] NULL,
		[EffectiveDate] [datetime] NULL,
		[ExpirationDate] [datetime] NULL,
		[Comments] [nvarchar](max) NULL,
		[Decision] [nvarchar](50) NULL,
		[StudyStatus] [nvarchar](50) NULL,
		[StatusChangeReason] [nvarchar](50) NULL,
		[Version] [nvarchar](255) NULL,
		[StatusChangeDate] [datetime] NULL,
		[IsClosureActivitiesCompleted] [bit] NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
	 CONSTRAINT [PK_GMRCApprovalTask] PRIMARY KEY CLUSTERED 
	(
		[GMRCApprovalTaskId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[GMRCApprovalTask]  WITH CHECK ADD  CONSTRAINT [FK_GMRCApprovalTask_NewStudy] FOREIGN KEY([StudyId])
	REFERENCES [dbo].[NewStudy] ([StudyID])

	ALTER TABLE [dbo].[GMRCApprovalTask] CHECK CONSTRAINT [FK_GMRCApprovalTask_NewStudy]
  END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjectiveName') 
	BEGIN
		CREATE TABLE [dbo].[ObjectiveName](
		[ObjectiveNameID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](255) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ObjectiveName] PRIMARY KEY CLUSTERED 
		(
			[ObjectiveNameID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjectivesandEndpoints') 
	BEGIN
		CREATE TABLE [dbo].[ObjectivesandEndpoints](
		[ObjandEndPointsID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[ObjectiveType] [varchar](50) NULL,
		[ObjectiveName] [varchar](max) NULL,
		[ObjectiveDescription] [varchar](max) NULL,
		[EndpointDescription] [varchar](max) NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ObjectivesandEndpoints] PRIMARY KEY CLUSTERED 
		(
			[ObjandEndPointsID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjectiveType') 
	BEGIN		
		CREATE TABLE [dbo].[ObjectiveType](
			[ObjectiveTypeID] [int] IDENTITY(1,1) NOT NULL,
			[Name] [nvarchar](255) NULL,
			[Description] [nvarchar](255) NULL,
			[IsActive] [bit] NULL,
			[IsDeleted] [bit] NULL,
			[ANJU_AddedBy] [nvarchar](63) NULL,
			[ANJU_AddDate] [datetime] NULL,
			[ANJU_ChangedBy] [nvarchar](63) NULL,
			[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ObjectiveType] PRIMARY KEY CLUSTERED 
		(
			[ObjectiveTypeID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PasswordHistory') 
	BEGIN
		CREATE TABLE [dbo].[PasswordHistory](
		[PasswordId] [int] IDENTITY(1,1) NOT NULL,
		[UserName] [varchar](255) NOT NULL,
		[Email] [nvarchar](255) NOT NULL,
		[Previouspassword] [varchar](255) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](255) NULL,
		[ANJU_AddDate] [datetime] NULL,
		 CONSTRAINT [PK_PasswordHistory] PRIMARY KEY CLUSTERED 
		(
			[PasswordId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PharmacovigilanceRequirements') 
	BEGIN
		CREATE TABLE [dbo].[PharmacovigilanceRequirements](
		[PharmacovigilanceRequirementsId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[TrialType] [nvarchar](255) NULL,
		[IsAllnonseriousAEs] [bit] NULL,
		[IsAllreportsdescribingtheoccurrenceofotherspecialscenarios] [bit] NULL,
		[Safetydata] [nvarchar](4000) NULL,
		[AdverseEventsExemptfromCollection] [nvarchar](4000) NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_PharmacovigilanceRequirements] PRIMARY KEY CLUSTERED 
		(
			[PharmacovigilanceRequirementsId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PlannedTrialMilestoneDatesandEnrollment') 
	BEGIN		
		CREATE TABLE [dbo].[PlannedTrialMilestoneDatesandEnrollment](
		[PlannedTrialMilestoneDatesandEnrollmentID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[TrialStart] [datetime] NULL,
		[RecruitmentEnd] [datetime] NULL,
		[TrialEnd] [datetime] NULL,
		[CompletionofTrialReport] [datetime] NULL,
		[PrimaryPublicationDate] [datetime] NULL,
		[TotalPlannedNumberofPatients] [int] NULL,
		[PlannedNumberofCenters] [int] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_PlannedTrialMilestoneDatesandEnrollment] PRIMARY KEY CLUSTERED 
		(
			[PlannedTrialMilestoneDatesandEnrollmentID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PLStudyReview') 
	BEGIN
		CREATE TABLE [dbo].[PLStudyReview](
		[PLReviewId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[PLUserId] [int] NULL,
		[StudyDescriptors] [nvarchar](max) NULL,
		[CompoundCategory1] [nvarchar](100) NULL,
		[CompoundCategory2] [nvarchar](100) NULL,
		[CompoundCategory3] [nvarchar](100) NULL,
		[CompoundType1] [nvarchar](100) NULL,
		[CompoundType2] [nvarchar](100) NULL,
		[CompoundType3] [nvarchar](100) NULL,
		[TrialCategorization] [nvarchar](50) NULL,
		[MonitoringInterval] [bit] NULL,
		[MaximumAllowableVists] [nvarchar](max) NULL,
		[TLUserId] [int] NULL,
		[Decision] [nvarchar](50) NULL,
		[Comments] [nvarchar](max) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_PLStudyReview] PRIMARY KEY CLUSTERED 
		(
			[PLReviewId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		ALTER TABLE [dbo].[PLStudyReview]  WITH CHECK ADD  CONSTRAINT [FK_PLStudyReview_NewStudy] FOREIGN KEY([StudyId])
		REFERENCES [dbo].[NewStudy] ([StudyID])

		ALTER TABLE [dbo].[PLStudyReview] CHECK CONSTRAINT [FK_PLStudyReview_NewStudy]
	END

	IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'InformationCategory') 
	BEGIN
		CREATE TABLE [dbo].[InformationCategory](
			[CategoryID] [int] IDENTITY(1,1) NOT NULL,
			[CategoryName] [nvarchar](50) NULL,
			[IsActive] [bit] NULL,
			[IsDeleted] [bit] NULL,
			[ANJU_AddedBy] [nvarchar](50) NULL,
			[Anju_AddedDate] [datetime] NULL,
			[ANJU_ChangedBy] [nvarchar](50) NULL,
			[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_InformationCategory] PRIMARY KEY CLUSTERED 
		(
			[CategoryID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PrincipalInvestigator') 
	BEGIN
		CREATE TABLE [dbo].[PrincipalInvestigator](
		[PrincipalInvestigatorID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[CategoryID] [int] NULL,
		[Salutation] [nvarchar](10) NULL,
		[FirstName] [nvarchar](100) NULL,
		[LastName] [nvarchar](100) NULL,
		[Suffix] [nvarchar](10) NULL,
		[Title] [nvarchar](50) NULL,
		[Degree] [nvarchar](255) NULL,
		[NPINumber] [nvarchar](50) NULL,
		[Institution] [nvarchar](100) NULL,
		[CountryID] [int] NULL,
		[StateID] [int] NULL,
		[CityID] [int] NULL,
		[Address1] [nvarchar](255) NULL,
		[Address2] [nvarchar](255) NULL,
		[Address3] [nvarchar](255) NULL,
		[Phone] [nvarchar](60) NULL,
		[Fax] [nvarchar](60) NULL,
		[PrimaryEmailID] [nvarchar](60) NULL,
		[PostalCode] [nvarchar](15) NULL,
		[SiteIndex] [nvarchar](255) NULL,
		[ContactType] [nvarchar](255) NULL,
		[ContactTypeDetails] [nvarchar](255) NULL,
		[TaxID] [nvarchar](255) NULL,
		[Region] [nvarchar](255) NULL,
		[IsActive] [bit]  NULL,
		[IsDeleted] [bit]  NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_PrincipalInvestigator] PRIMARY KEY CLUSTERED 
		(
			[PrincipalInvestigatorID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[PrincipalInvestigator]  WITH CHECK ADD  CONSTRAINT [FK_PrincipalInvestigator_City] FOREIGN KEY([CityID])
		REFERENCES [dbo].[City] ([CityId])
		
		ALTER TABLE [dbo].[PrincipalInvestigator] CHECK CONSTRAINT [FK_PrincipalInvestigator_City]	

		ALTER TABLE [dbo].[PrincipalInvestigator]  WITH CHECK ADD  CONSTRAINT [FK_PrincipalInvestigator_Country] FOREIGN KEY([CountryID])
		REFERENCES [dbo].[Country] ([CountryId])

		ALTER TABLE [dbo].[PrincipalInvestigator] CHECK CONSTRAINT [FK_PrincipalInvestigator_Country]
		ALTER TABLE [dbo].[PrincipalInvestigator]  WITH CHECK ADD  CONSTRAINT [FK_PrincipalInvestigator_PrincipalInvestigator] FOREIGN KEY([StudyID])
		REFERENCES [dbo].[NewStudy] ([StudyID])

		ALTER TABLE [dbo].[PrincipalInvestigator] CHECK CONSTRAINT [FK_PrincipalInvestigator_PrincipalInvestigator]
		ALTER TABLE [dbo].[PrincipalInvestigator]  WITH CHECK ADD  CONSTRAINT [FK_PrincipalInvestigator_State] FOREIGN KEY([StateID])
		REFERENCES [dbo].[State] ([StateId])

		ALTER TABLE [dbo].[PrincipalInvestigator] CHECK CONSTRAINT [FK_PrincipalInvestigator_State]
	END



IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyCompounds') 
	BEGIN
		CREATE TABLE [dbo].[StudyCompounds](
		[StudyComponentID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[CompoundType] [nvarchar](256) NULL,
		[CompanyCompound] [nvarchar](256) NULL,
		[NonCompanyCompound] [nvarchar](256) NULL,
		[CompoundCategory] [nvarchar](256) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyReview') 
	BEGIN
		CREATE TABLE [dbo].[StudyReview](
		[ReviewId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[MSLUserId] [int] NULL,
		[Franchise] [varchar](100) NULL,
		[PrimaryIndication] [varchar](max) NULL,
		[SecondaryIndication] [varchar](max) NULL,
		[Institution] [varchar](max) NULL,
		[Decision] [varchar](50) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_StudyReview] PRIMARY KEY CLUSTERED 
		(
			[ReviewId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		ALTER TABLE [dbo].[StudyReview]  WITH CHECK ADD  CONSTRAINT [FK_StudyReview_StudyReview] FOREIGN KEY([StudyId])
		REFERENCES [dbo].[NewStudy] ([StudyID])

		ALTER TABLE [dbo].[StudyReview] CHECK CONSTRAINT [FK_StudyReview_StudyReview]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyTask') 
	BEGIN
		CREATE TABLE [dbo].[StudyTask](
		[TaskId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[MSLUserID] [int] NOT NULL,
		[PLUserID] [int] NOT NULL,
		[UpcomingTask] [nvarchar](max) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_StudyTask] PRIMARY KEY CLUSTERED 
		(
			[TaskId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		ALTER TABLE [dbo].[StudyTask]  WITH CHECK ADD  CONSTRAINT [FK_StudyTask_NewStudy] FOREIGN KEY([StudyId])
		REFERENCES [dbo].[NewStudy] ([StudyID])

		ALTER TABLE [dbo].[StudyTask] CHECK CONSTRAINT [FK_StudyTask_NewStudy]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TreatmentInformation') 
	BEGIN
		CREATE TABLE [dbo].[TreatmentInformation](
		[TreatmentInfoID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[TreatmentArm] [nvarchar](255) NULL,
		[NoofPatientsPlanned] [nvarchar](255) NULL,
		[TypeofTrialDrug] [nvarchar](255) NULL,
		[Compound] [nvarchar](255) NULL,
		[Mindosage] [nvarchar](255) NULL,
		[Maxdosage] [nvarchar](255) NULL,
		[Frequency] [nvarchar](255) NULL,
		[AdminRoute] [nvarchar](255) NULL,
		[GenericAcceptable] [bit] NULL,
		[IsActive] [bit] NULL,
		[IsDeleted] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		CONSTRAINT [PK_TreatmentInformation] PRIMARY KEY CLUSTERED 
		(
			[TreatmentInfoID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TrialPhase') 
	BEGIN
		CREATE TABLE [dbo].[TrialPhase](
		[TrialPhaseID] [int] IDENTITY(1,1) NOT NULL,
		[StudyID] [int] NOT NULL,
		[PhaseI] [bit] NULL,
		[PhaseII] [bit] NULL,
		[PhaseIII] [bit] NULL,
		[PhaseIV] [bit] NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_TrialPhase] PRIMARY KEY CLUSTERED 
		(
			[TrialPhaseID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Typeoftrialdrug') 
	BEGIN
		CREATE TABLE [dbo].[Typeoftrialdrug](
		[TypeoftrialdrugID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](255) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_Typeoftrialdrug] PRIMARY KEY CLUSTERED 
		(
			[TypeoftrialdrugID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END	

	IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserRoles') 
	BEGIN
		CREATE TABLE [dbo].[UserRoles](
		[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Description] [nvarchar](255) NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_UserRoles_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_UserRoles_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
		(
			[UserRoleID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

	IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users') 
	BEGIN
		CREATE TABLE [dbo].[Users](
		[UserID] [int] IDENTITY(1,1) NOT NULL,
		[Salutation] [nvarchar](10) NOT NULL,
		[FirstName] [nvarchar](255) NULL,
		[LastName] [nvarchar](255) NULL,
		[Title] [nvarchar](255) NULL,
		[RoleID] [int] NULL,
		[OrganizationName] [nvarchar](255) NULL,
		[Department] [nvarchar](255) NULL,
		[Address1] [nvarchar](255) NULL,
		[Address2] [nvarchar](255) NULL,
		[CityID] [int] NULL,
		[StateID] [int] NULL,
		[CountryID] [int] NULL,
		[Zip] [nvarchar](15) NULL,
		[TelephoneNumber] [nvarchar](60) NULL,
		[MobileNumber] [nvarchar](60) NULL,
		[DOB] [datetime] NULL,
		[Fax] [nvarchar](60) NULL,
		[PrimaryEmailID] [nvarchar](60) NULL,
		[SecondaryEmailID] [nvarchar](60) NULL,
		[Gender] [nvarchar](15) NULL,
		[UserName] [varchar](255) NULL,
		[Password] [varchar](255) NULL,
		[PasswordExpiryDate] [datetime] NULL,
		[UserType] [nvarchar](50) NULL,
		[UserStatus] [nchar](20) NULL,
		[Suffix] [nchar](20) NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)),
		[IsAccountLocked] [bit] NULL,
		[FailedAttempts] [int] NULL,
		[EndUserType] [nvarchar](50) NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
		(
			[UserID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_City_CityId] FOREIGN KEY([CityID])
		REFERENCES [dbo].[City] ([CityId])

		ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_City_CityId]

		ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Country_CountryId] FOREIGN KEY([CountryID])
		REFERENCES [dbo].[Country] ([CountryId])

		ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Country_CountryId]

		ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role_RoleId] FOREIGN KEY([RoleID])
		REFERENCES [dbo].[UserRoles] ([UserRoleID])

		ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role_RoleId]

		ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_State_StateId] FOREIGN KEY([StateID])
		REFERENCES [dbo].[State] ([StateId])

		ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_State_StateId]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserCredentials') 
	BEGIN
		CREATE TABLE [dbo].[UserCredentials](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[UserID] [int] NULL,
		[CredentialID] [int] NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_UserCredentials_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_UserCredentials_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_UserCredentials] PRIMARY KEY CLUSTERED 
		(
			[ID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_UserCredentials_Credentials_CredentialID] FOREIGN KEY([CredentialID])
		REFERENCES [dbo].[SysCodeValues] ([CodeID])

		ALTER TABLE [dbo].[UserCredentials] CHECK CONSTRAINT [FK_UserCredentials_Credentials_CredentialID]

		ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_UserCredentials_Credentials_UserID] FOREIGN KEY([UserID])
		REFERENCES [dbo].[Users] ([UserID])

		ALTER TABLE [dbo].[UserCredentials] CHECK CONSTRAINT [FK_UserCredentials_Credentials_UserID]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProxyUserDetails') 
	BEGIN
		CREATE TABLE [dbo].[ProxyUserDetails](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[UserName] [varchar](255) NOT NULL,
		[CREATED] [datetime2](0) NOT NULL,
		[ProxyUserName] [varchar](255) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ProxyUserDetails] PRIMARY KEY CLUSTERED 
		(
			[ID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[ProxyUserDetails ] ADD  CONSTRAINT [DF_Users_LOGIN_ATTEMPTS_IsActive]  DEFAULT ((1)) FOR [IsActive]

		ALTER TABLE [dbo].[ProxyUserDetails ] ADD  CONSTRAINT [DF_Users_LOGIN_ATTEMPTS_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
	END


IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ReviewsandNotes') 
	BEGIN
		CREATE TABLE [dbo].[ReviewsandNotes](
		[ReviewsandNotesId] [int] IDENTITY(1,1) NOT NULL,
		[StudyId] [int] NOT NULL,
		[Reviewdate] [datetime] NULL,
		[Username] [nvarchar](255) NULL,
		[Role] [nvarchar](255) NULL,
		[Reviewstep] [nvarchar](255) NULL,
		[Submissioncomments] [nvarchar](255) NULL,
		[Decision] [nvarchar](255) NULL,
		[IsActive] [bit] NOT NULL,
		[IsDeleted] [bit] NOT NULL,
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_ReviewsandNotes] PRIMARY KEY CLUSTERED 
		(
			[ReviewsandNotesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END



IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserTypes') 
	BEGIN
		CREATE TABLE [dbo].[UserTypes](
		[UserTypeID] [bigint] IDENTITY(1,1) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
		[IsActive] [bit] NOT NULL CONSTRAINT [DF_UserTypes_IsActive]  DEFAULT ((1)),
		[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_UserTypes_IsDeleted]  DEFAULT ((0)),
		[ANJU_AddedBy] [nvarchar](63) NULL,
		[ANJU_AddDate] [datetime] NULL,
		[ANJU_ChangedBy] [nvarchar](63) NULL,
		[ANJU_ChangeDate] [datetime] NULL,
		 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
		(
			[UserTypeID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyIndication') 
BEGIN
	CREATE TABLE [dbo].[StudyIndication](
                [IndicationId] [int] IDENTITY(1,1) NOT NULL,
                [StudyId] [int] NOT NULL,
                [IndicationType] [nvarchar](255) NULL,
                [IndicationCauses] [nvarchar](255) NULL,
                [IsActive] [bit] NOT NULL,
                [IsDeleted] [bit] NOT NULL,
                [ANJU_AddedBy] [nvarchar](63) NULL,
                [ANJU_AddDate] [datetime] NULL,
                [ANJU_ChangedBy] [nvarchar](63) NULL,
                [ANJU_ChangeDate] [datetime] NULL,
CONSTRAINT [PK_StudyIndication] PRIMARY KEY CLUSTERED 
(
                [IndicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyProtocol') 
BEGIN
CREATE TABLE [dbo].[StudyProtocol](
                [StudyProtocolId] [int] IDENTITY(1,1) NOT NULL,
                [StudyId] [int] NOT NULL,
                [StudyProtocolnos] [nvarchar](255) NULL,
                [Organization] [nvarchar](255) NULL,
                [IsActive] [bit] NOT NULL,
                [IsDeleted] [bit] NOT NULL,
                [ANJU_AddedBy] [nvarchar](63) NULL,
                [ANJU_AddDate] [datetime] NULL,
                [ANJU_ChangedBy] [nvarchar](63) NULL,
                [ANJU_ChangeDate] [datetime] NULL,
CONSTRAINT [PK_StudyProtocol] PRIMARY KEY CLUSTERED 
(
                [StudyProtocolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudySites') 
BEGIN
CREATE TABLE [dbo].[StudySites](
                [SiteId] [int] IDENTITY(1,1) NOT NULL,
                [StudyId] [int] NOT NULL,
                [SiteInstitution] [nvarchar](255) NULL,
                [InstitutionInternal] [nvarchar](255) NULL,
                [SiteCountry] [nvarchar](255) NULL,
                [IsDrugShippedtoSite] [bit] NULL,
                [IsContractdirectwithSite] [bit] NULL,
                [IsActive] [bit] NOT NULL,
                [IsDeleted] [bit] NOT NULL,
                [ANJU_AddedBy] [nvarchar](63) NULL,
                [ANJU_AddDate] [datetime] NULL,
                [ANJU_ChangedBy] [nvarchar](63) NULL,
                [ANJU_ChangeDate] [datetime] NULL,
CONSTRAINT [PK_StudySites] PRIMARY KEY CLUSTERED 
(
                [SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PatientAccrual') 
BEGIN
CREATE TABLE [dbo].[PatientAccrual](
    [PatientaccrualId] [int] IDENTITY(1,1) NOT NULL,
    [StudyId] [int] NOT NULL,
    [Year] [int] NULL,
    [MonthYear] [nvarchar](255) NULL,
    [TreatedPatients] [int] NULL,
    [CurrentPatients] [int] NULL,
    [WithdrawnPatients] [int] NULL,
    [CompletedPatients] [int] NULL,
    [FirstPatientFirstVisit] [datetime] NULL,
    [PatientEnrollment] [bit] NULL,
    [LastPatientFirstVisit] [datetime] NULL,
    [LastPatientLastTreatment] [datetime] NULL,
    [LastPatientLastVisit] [datetime] NULL,
    [IsActive] [bit] NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [ANJU_AddedBy] [varchar](50) NULL,
    [ANJU_AddDate] [datetime] NULL,
    [ANJU_ChangedBy] [varchar](50) NULL,
    [ANJU_ChangeDate] [datetime] NULL,
CONSTRAINT [PK_PatientAccrual] PRIMARY KEY CLUSTERED 
(
    [PatientaccrualId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

ALTER TABLE [dbo].[PatientAccrual]  WITH CHECK ADD  CONSTRAINT [FK_PatientAccrual_NewStudy] FOREIGN KEY([StudyId])
REFERENCES [dbo].[NewStudy] ([StudyID])
 
ALTER TABLE [dbo].[PatientAccrual] CHECK CONSTRAINT [FK_PatientAccrual_NewStudy]

END

GO

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Milestones') 
BEGIN
CREATE TABLE [dbo].[Milestones](
	[MilestoneId] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[Phase] [nvarchar](255) NULL,
	[Parameters] [nvarchar](255) NULL,
	[Dependency] [int] NULL,
	[Milestonecompletiondate] [datetime] NULL,
	[Estimatedcompletiondate] [datetime] NULL,
	[MilestoneStatus] [nvarchar](255) NULL,
	[Remindersentdate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_Milestones] PRIMARY KEY CLUSTERED 
(
	[MilestoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

GO

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Invoicedetails') 
BEGIN
CREATE TABLE [dbo].[Invoicedetails](
	[InvoicesdetailsId] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Checksenttosite] [datetime] NULL,
	[Descriptionofpayment] [nvarchar](255) NULL,
	[Invoicedate] [datetime] NULL,
	[Invoicenumber] [nvarchar](255) NULL,
	[PONumber] [nvarchar](255) NULL,
	[Currency] [nvarchar](255) NULL,
	[Paymentamount] [nvarchar](255) NULL,
	[Lineitem] [nvarchar](255) NULL,
	[Generalledgernumber] [nvarchar](255) NULL,
	[Departmentcode] [nvarchar](255) NULL,
	[Budgetsource] [nvarchar](255) NULL,
	[Personnel] [nvarchar](255) NULL,
	[Procedural] [nvarchar](255) NULL,
	[IRBFees] [nvarchar](255) NULL,
	[IRBAnnualfees] [nvarchar](255) NULL,
	[Administrative] [nvarchar](255) NULL,
	[Pharmacy] [nvarchar](255) NULL,
	[Startup] [nvarchar](255) NULL,
	[Correlative] [nvarchar](255) NULL,
	[Other] [nvarchar](255) NULL,
	[Organizationtype] [nvarchar](255) NULL,
	[Natureofexpenditure] [nvarchar](255) NULL,
	[Purposeofexpenditure] [nvarchar](255) NULL,
	[Settingofactivity] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_Invoicedetails] PRIMARY KEY CLUSTERED 
(
	[InvoicesdetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailMessages') 
BEGIN
	CREATE TABLE [dbo].[EmailMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[SendDate] [datetime] NULL,
	[FromAddress] [nvarchar](255) NOT NULL,
	[ToAddress] [nvarchar](255) NOT NULL,
	[CcAddress] [nvarchar](max) NULL,
	[BccAddress] [nvarchar](max) NULL,
	[EmailSubject] [nvarchar](max) NOT NULL,
	[EmailBody] [nvarchar](max) NOT NULL,
	[EmailPriority] [nvarchar](20) NULL,
	[RetryCount] [int] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_EmailMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProxyUserDetails_H') 
BEGIN
	CREATE TABLE [dbo].[ProxyUserDetails_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[CREATED] [datetime2](0) NOT NULL,
	[ProxyUserName] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_ProxyUserDetails_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users_H') 
BEGIN
CREATE TABLE [dbo].[Users_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[Salutation] [nvarchar](10) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
	[RoleID] [int] NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Address1] [nvarchar](255) NULL,
	[Address2] [nvarchar](255) NULL,
	[CityID] [int] NULL,
	[StateID] [int] NULL,
	[CountryID] [int] NULL,
	[Zip] [nvarchar](15) NULL,
	[TelephoneNumber] [nvarchar](60) NULL,
	[MobileNumber] [nvarchar](60) NULL,
	[DOB] [datetime] NULL,
	[Fax] [nvarchar](60) NULL,
	[PrimaryEmailID] [nvarchar](60) NULL,
	[SecondaryEmailID] [nvarchar](60) NULL,
	[Gender] [nvarchar](15) NULL,
	[UserName] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[PasswordExpiryDate] [datetime] NULL,
	[UserType] [nvarchar](50) NULL,
	[UserStatus] [nchar](20) NULL,
	[Suffix] [nchar](20) NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Users_H_IsActive]  DEFAULT ((1)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Users_H_IsDeleted]  DEFAULT ((0)),
	[IsAccountLocked] [bit] NULL,
	[FailedAttempts] [int] NULL,
	[EndUserType] [nvarchar](50) NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Users_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END


IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserCredentials_H') 
BEGIN
	CREATE TABLE [dbo].[UserCredentials_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CredentialID] [int] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_UserCredentials_H_IsActive]  DEFAULT ((1)),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_UserCredentials_H_IsDeleted]  DEFAULT ((0)),
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
	 CONSTRAINT [PK_UserCredentials_H] PRIMARY KEY CLUSTERED 
	(
		[PsuedoKey] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyTask_H') 
BEGIN
CREATE TABLE [dbo].[StudyTask_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[MSLUserID] [int] NOT NULL,
	[PLUserID] [int] NOT NULL,
	[UpcomingTask] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_StudyTask_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyReview_H') 
BEGIN
	CREATE TABLE [dbo].[StudyReview_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[MSLUserId] [int] NULL,
	[Franchise] [varchar](100) NULL,
	[PrimaryIndication] [varchar](max) NULL,
	[SecondaryIndication] [varchar](max) NULL,
	[Institution] [varchar](max) NULL,
	[Decision] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_StudyReview_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Submissions') 
BEGIN
	CREATE TABLE [dbo].[Submissions](
	[SubmissionId] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Submissiontype] [nvarchar](255) NULL,
	[Submissionversion] [nvarchar](255) NULL,
	[Studyeligibilitydate] [datetime] NULL,
	[Submissiondate] [datetime] NULL,
	[Submissiondetails] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_Submissions] PRIMARY KEY CLUSTERED 
(
	[SubmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Submissions_H') 
BEGIN
	CREATE TABLE [dbo].[Submissions_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Submissiontype] [nvarchar](255) NULL,
	[Version] [nvarchar](255) NULL,
	[Studyeligibilitydate] [datetime] NULL,
	[Submissiondate] [datetime] NULL,
	[Submissiondetails] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Submissions_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END


IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PLStudyReview_H') 
BEGIN
	CREATE TABLE [dbo].[PLStudyReview_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[PLUserId] [int] NULL,
	[StudyDescriptors] [nvarchar](max) NULL,
	[CompoundCategory1] [nvarchar](100) NULL,
	[CompoundCategory2] [nvarchar](100) NULL,
	[CompoundCategory3] [nvarchar](100) NULL,
	[CompoundType1] [nvarchar](100) NULL,
	[CompoundType2] [nvarchar](100) NULL,
	[CompoundType3] [nvarchar](100) NULL,
	[TrialCategorization] [nvarchar](50) NULL,
	[MonitoringInterval] [bit] NULL,
	[MaximumAllowableVists] [nvarchar](max) NULL,
	[TLUserId] [int] NULL,
	[Decision] [nvarchar](50) NULL,
	[Comments] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_PLStudyReview_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MRCStudyReview_H') 
BEGIN
	CREATE TABLE [dbo].[MRCStudyReview_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[RecordType] [varchar](50) NULL,
	[LocalMRCDecision] [varchar](50) NULL,
	[LocalMRCDecisionComments] [varchar](100) NULL,
	[LocalMRCDateOfDecision] [datetime] NULL,
	[LocalMRCDecisionMadeBy] [varchar](50) NULL,
	[SAEReconciliationFrequency] [varchar](50) NULL,
	[GlobalMRCDecision] [varchar](50) NULL,
	[GlobalMRCDecisionDate] [datetime] NULL,
	[MACSNumber] [varchar](50) NULL,
	[StudyNumber] [varchar](50) NULL,
	[MRCDecisionRejectedBy] [varchar](50) NULL,
	[MRCRejectedDeliveryMethod] [varchar](50) NULL,
	[MRCDecisionWithdrawalBy] [varchar](50) NULL,
	[MRCWithdrawalDeliveryMethod] [varchar](50) NULL,
	[CAResubmissionDecision] [varchar](50) NULL,
	[CAResubmissionComments] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_MRCStudyReview_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GMRCApprovalTask_H') 
BEGIN
	CREATE TABLE [dbo].[GMRCApprovalTask_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
	[AssignedTo] [nvarchar](50) NOT NULL,
	[IsTaskCompleted] [bit] NULL,
	[IsGearTaskCompleted] [bit] NULL,
	[ContractType] [nvarchar](50) NULL,
	[ContractStatus] [nvarchar](50) NULL,
	[CurrentLocation] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[SubmissionDate] [datetime] NULL,
	[ExecutionDate] [datetime] NULL,
	[EffectiveDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
	[Decision] [nvarchar](50) NULL,
	[StudyStatus] [nvarchar](50) NULL,
	[StatusChangeReason] [nvarchar](50) NULL,
	[Version] [nvarchar](255) NULL,
	[StatusChangeDate] [datetime] NULL,
	[IsClosureActivitiesCompleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_GMRCApprovalTask_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PatientAccrual_H') 
BEGIN
	CREATE TABLE [dbo].[PatientAccrual_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Year] [int] NULL,
	[MonthYear] [nvarchar](255) NULL,
	[TreatedPatients] [int] NULL,
	[CurrentPatients] [int] NULL,
	[WithdrawnPatients] [int] NULL,
	[CompletedPatients] [int] NULL,
	[FirstPatientFirstVisit] [datetime] NULL,
	[PatientEnrollment] [bit] NULL,
	[LastPatientFirstVisit] [datetime] NULL,
	[LastPatientLastTreatment] [datetime] NULL,
	[LastPatientLastVisit] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [varchar](50) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [varchar](50) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_PatientAccrual_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TreatmentInformation_H') 
BEGIN
	CREATE TABLE [dbo].[TreatmentInformation_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[TreatmentArm] [nvarchar](255) NULL,
	[NoofPatientsPlanned] [nvarchar](255) NULL,
	[TypeofTrialDrug] [nvarchar](255) NULL,
	[Compound] [nvarchar](255) NULL,
	[Mindosage] [nvarchar](255) NULL,
	[Maxdosage] [nvarchar](255) NULL,
	[Frequency] [nvarchar](255) NULL,
	[AdminRoute] [nvarchar](255) NULL,
	[GenericAcceptable] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_TreatmentInformation_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END



IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudySites_H') 
BEGIN
	CREATE TABLE [dbo].[StudySites_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[SiteInstitution] [nvarchar](255) NULL,
	[InstitutionInternal] [nvarchar](255) NULL,
	[SiteCountry] [nvarchar](255) NULL,
	[IsDrugShippedtoSite] [bit] NULL,
	[IsContractdirectwithSite] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_StudySites_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyProtocol_H') 
BEGIN
	CREATE TABLE [dbo].[StudyProtocol_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[StudyProtocolnos] [nvarchar](255) NULL,
	[Organization] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_StudyProtocol_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyIndication_H') 
BEGIN
	
CREATE TABLE [dbo].[StudyIndication_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Indicationtype] [nvarchar](255) NULL,
	[Indicationcauses] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Indication_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudyCompounds_H') 
BEGIN
	CREATE TABLE [dbo].[StudyCompounds_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[CompoundType] [nvarchar](256) NULL,
	[CompanyCompound] [nvarchar](256) NULL,
	[NonCompanyCompound] [nvarchar](256) NULL,
	[CompoundCategory] [nvarchar](256) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NewStudy_H') 
BEGIN
	CREATE TABLE [dbo].[NewStudy_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NULL,
	[StudyType] [nvarchar](300) NULL,
	[TitleofTrial] [nvarchar](300) NULL,
	[Treatmentarms] [nvarchar](max) NULL,
	[SampleSizeJustificationandStatisticalAnalysis] [nvarchar](max) NULL,
	[ClinicalPharmacology] [nvarchar](max) NULL,
	[EnrollmentHistoryforOtherRelatedStudies] [nvarchar](300) NULL,
	[IsCompetingStudies] [bit] NULL,
	[CompetingStudies] [nvarchar](300) NULL,
	[IsINDSubmission] [bit] NULL,
	[RationaleforINDExemption] [nvarchar](1000) NULL,
	[IsIRBRegistrationRequirement] [bit] NULL,
	[KeyReferences] [nvarchar](max) NULL,
	[MedicalSpecialty] [nvarchar](300) NULL,
	[BoardCertification] [nvarchar](300) NULL,
	[MedicalLicense] [nvarchar](300) NULL,
	[IsCompanySponsoredtrial] [bit] NULL,
	[DrugName] [nvarchar](300) NULL,
	[ProtocolNumber] [nvarchar](300) NULL,
	[TrialParticipation] [nvarchar](300) NULL,
	[IsOtherTrainingsReceived] [bit] NULL,
	[LastTrainingDetails] [nvarchar](300) NULL,
	[TypeOfTraining] [nvarchar](300) NULL,
	[TrialExperiences] [nvarchar](max) NULL,
	[NumberOfOngoingTrials] [nvarchar](300) NULL,
	[IsSiteInspectedByHealthAuthority] [bit] NULL,
	[NameOfHealthAuthority] [nvarchar](300) NULL,
	[DateOflastInspection] [datetime] NULL,
	[IsSiteInspectedByFDA] [bit] NULL,
	[DateOfFDAInspection] [datetime] NULL,
	[ISFDA483formIssued] [bit] NULL,
	[DetailsOfObservation] [nvarchar](max) NULL,
	[IsCooperativeGroupStudy] [bit] NULL,
	[CooperativeGroupName] [nvarchar](63) NULL,
	[IsPhysicianNetworkStudy] [bit] NULL,
	[PhysicianNetworkName] [nvarchar](300) NULL,
	[IsGovernmentSupportProvided] [bit] NULL,
	[SupportDescription] [nvarchar](300) NULL,
	[IsSupportProvidedByOtherSources] [bit] NULL,
	[SupportSources] [nvarchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsRequestedForDrugSupply] [bit] NULL,
	[IsRequestedForFinancialSupport] [bit] NULL,
	[BudgetRequestedForTrial] [int] NULL,
	[Stage] [nvarchar](50) NULL,
	[State] [nvarchar](max) NULL,
	[TaskStatus] [nvarchar](max) NULL,
	[PITaskStatus] [nvarchar](max) NULL,
	[TaskName] [nvarchar](max) NULL,
	[InvestigationalSiteProtocolNumber] [nvarchar](350) NULL,
	[StudyActivationDate] [datetime] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_NewStudy_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PrincipalInvestigator_H') 
BEGIN
	CREATE TABLE [dbo].[PrincipalInvestigator_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[CategoryID] [int] NULL,
	[Salutation] [nvarchar](10) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Suffix] [nvarchar](10) NULL,
	[Title] [nvarchar](50) NULL,
	[Degree] [nvarchar](255) NULL,
	[NPINumber] [nvarchar](50) NULL,
	[Institution] [nvarchar](100) NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[CityID] [int] NULL,
	[Address1] [nvarchar](255) NULL,
	[Address2] [nvarchar](255) NULL,
	[Address3] [nvarchar](255) NULL,
	[Phone] [nvarchar](60) NULL,
	[Fax] [nvarchar](60) NULL,
	[PrimaryEmailID] [nvarchar](60) NULL,
	[PostalCode] [nvarchar](15) NULL,
	[SiteIndex] [nvarchar](255) NULL,
	[ContactType] [nvarchar](255) NULL,
	[ContactTypeDetails] [nvarchar](255) NULL,
	[TaxID] [nvarchar](255) NULL,
	[Region] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_PrincipalInvestigator_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CorrelativeScienceStudies_H') 
BEGIN
	CREATE TABLE [dbo].[CorrelativeScienceStudies_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[IsincludeCorrelativeScience] [bit] NULL,
	[BiomarkerStudiesperformedatStudySite] [nvarchar](max) NULL,
	[BiomarkerStudiesperformedatCompanySite] [nvarchar](max) NULL,
	[BiomarkerSamplingDetails] [nvarchar](max) NULL,
	[ANJU_AddedBy] [nvarchar](50) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](50) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_CorrelativeScienceStudies_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ConceptDesignandRationale_H') 
BEGIN
	CREATE TABLE [dbo].[ConceptDesignandRationale_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[Indication] [nvarchar](max) NULL,
	[RationaleforTrial] [nvarchar](max) NULL,
	[TrialDesign] [nvarchar](max) NULL,
	[Binding] [nvarchar](50) NULL,
	[Structure] [nvarchar](50) NULL,
	[Randomized] [nvarchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[MinimumAge] [varchar](50) NULL,
	[MaximumAge] [varchar](50) NULL,
	[PatientPopulation] [nvarchar](max) NULL,
	[KeyInclusionCriteria] [nvarchar](max) NULL,
	[KeyExclusionCriteria] [nvarchar](max) NULL,
	[ANJU_AddedBy] [nvarchar](50) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](50) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_ConceptDesignandRationale_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contracttimelines') 
BEGIN
	CREATE TABLE [dbo].[Contracttimelines](
	[ContractId] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Contracttype] [nvarchar](255) NULL,
	[Contracttimelinestatus] [nvarchar](255) NULL,
	[Contractversion] [nvarchar](255) NULL,
	[Currentlocation] [nvarchar](255) NULL,
	[Contactname] [nvarchar](255) NULL,
	[Statuschange] [datetime] NULL,
	[Comments] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NOT NULL,
	[ANJU_AddDate] [datetime] NOT NULL,
	[ANJU_ChangedBy] [nvarchar](63) NOT NULL,
	[ANJU_ChangeDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contracttimelines] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contracttimelines_H') 
BEGIN
	CREATE TABLE [dbo].[Contracttimelines_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Contracttype] [nvarchar](255) NULL,
	[Contracttimelinestatus] [nvarchar](255) NULL,
	[Contractversion] [nvarchar](255) NULL,
	[Currentlocation] [nvarchar](255) NULL,
	[Contactname] [nvarchar](255) NULL,
	[Statuschange] [datetime] NULL,
	[Comments] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Contracttimelines)_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TrialPhase_H') 
BEGIN
	CREATE TABLE [dbo].[TrialPhase_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[PhaseI] [bit] NULL,
	[PhaseII] [bit] NULL,
	[PhaseIII] [bit] NULL,
	[PhaseIV] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_TrialPhase_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PlannedTrialMilestoneDatesandEnrollment_H') 
BEGIN
	CREATE TABLE [dbo].[PlannedTrialMilestoneDatesandEnrollment_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[TrialStart] [datetime] NULL,
	[RecruitmentEnd] [datetime] NULL,
	[TrialEnd] [datetime] NULL,
	[CompletionofTrialReport] [datetime] NULL,
	[PrimaryPublicationDate] [datetime] NULL,
	[TotalPlannedNumberofPatients] [int] NULL,
	[PlannedNumberofCenters] [int] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_PlannedTrialMilestoneDatesandEnrollment_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjectivesandEndpoints_H') 
BEGIN
	CREATE TABLE [dbo].[ObjectivesandEndpoints_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[ObjectiveType] [varchar](50) NULL,
	[ObjectiveName] [varchar](max) NULL,
	[ObjectiveDescription] [varchar](max) NULL,
	[EndpointDescription] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_ObjectivesandEndpoints_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailList_H') 
BEGIN
	CREATE TABLE [dbo].[EmailList_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[Email] [nvarchar](60) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_EmailList_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DrugorCompounddetails_H') 
BEGIN
	CREATE TABLE [dbo].[DrugorCompounddetails_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[Primarydrug] [nvarchar](50) NOT NULL,
	[Secondarydrug] [nvarchar](50) NULL,
	[Tertiarydrug] [nvarchar](50) NULL,
	[SecondaryType] [nvarchar](50) NULL,
	[TertiaryaryType] [nvarchar](50) NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_DrugorCompounddetails_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Milestones_H') 
BEGIN
	CREATE TABLE [dbo].[Milestones_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[Phase] [nvarchar](255) NULL,
	[Parameters] [nvarchar](255) NULL,
	[Dependency] [int] NULL,
	[Milestonecompletiondate] [datetime] NULL,
	[Estimatedcompletiondate] [datetime] NULL,
	[MilestoneStatus] [nvarchar](255) NULL,
	[Remindersentdate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Milestones_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PharmacovigilanceRequirements_H') 
BEGIN
	CREATE TABLE [dbo].[PharmacovigilanceRequirements_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[TrialType] [nvarchar](255) NULL,
	[IsAllnonseriousAEs] [bit] NULL,
	[IsAllreportsdescribingtheoccurrenceofotherspecialscenarios] [bit] NULL,
	[Safetydata] [nvarchar](4000) NULL,
	[AdverseEventsExemptfromCollection] [nvarchar](4000) NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_PharmacovigilanceRequirements_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ReviewsandNotes_H') 
BEGIN
	CREATE TABLE [dbo].[ReviewsandNotes_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Reviewdate] [datetime] NULL,
	[Username] [nvarchar](255) NULL,
	[Role] [nvarchar](255) NULL,
	[Reviewstep] [nvarchar](255) NULL,
	[Submissioncomments] [nvarchar](255) NULL,
	[Decision] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_ReviewsandNotes_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserRoles_H') 
BEGIN
	CREATE TABLE [dbo].[UserRoles_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_UserRoles_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Center_H') 
BEGIN
	CREATE TABLE [dbo].[Center_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Institution] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Center_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'City_H') 
BEGIN
	CREATE TABLE [dbo].[City_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_City_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_City_state_Name_H] UNIQUE NONCLUSTERED 
(
	[StateId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CohortLevels_H') 
BEGIN
	CREATE TABLE [dbo].[CohortLevels_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyID] [int] NOT NULL,
	[NoofPatients] [int] NULL,
	[Cohortlevel] [varchar](50) NULL,
	[DoseandFrequencyDrugA] [varchar](50) NULL,
	[DoseandFrequencyDrugB] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_CohortLevels_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Country_H') 
BEGIN
	CREATE TABLE [dbo].[Country_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](3) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Country_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DefaultMileStone_H') 
BEGIN
	CREATE TABLE [dbo].[DefaultMileStone_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[MilestoneType] [nvarchar](50) NOT NULL,
	[MilestoneName] [nvarchar](100) NOT NULL,
	[BusinessDays] [int] NOT NULL,
	[Dependency] [int] NOT NULL,
	[StudyPhase] [nvarchar](50) NOT NULL,
	[Comments] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_DefaultMileStone_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GlobalSettings_H') 
BEGIN
	CREATE TABLE [dbo].[GlobalSettings_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[GlobalKey] [nvarchar](50) NULL,
	[GlobalValue] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_GlobalSettings_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'State_H') 
BEGIN
	CREATE TABLE [dbo].[State_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](3) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_County_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Status_H') 
BEGIN
	CREATE TABLE [dbo].[Status_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Stage] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[StudyStatus] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[Time] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_Status_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SysCodeValues_H') 
BEGIN
	CREATE TABLE [dbo].[SysCodeValues_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](255) NOT NULL,
	[ColumnName] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[SortOrder] [int] NULL,
	[IsDefault] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_SysCodeValues_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'IISAdmindetails_H') 
BEGIN
	CREATE TABLE [dbo].[IISAdmindetails_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[StudyId] [int] NOT NULL,
	[Studydescriptors] [nvarchar](255) NULL,
	[InvestigationalDrugandReferenceTherapy] [nvarchar](255) NULL,
	[PatientType] [varchar](50) NULL,
	[Safetycriteria] [nvarchar](255) NULL,
	[Othercompanycompound] [nvarchar](255) NULL,
	[IsPlacebocontrolled] [bit] NULL,
	[Studydesign] [nvarchar](255) NULL,
	[Rationaleforstudy] [nvarchar](255) NULL,
	[Basisforsamplesize] [nvarchar](255) NULL,
	[Riskfactors] [nvarchar](255) NULL,
	[GenomicProfile] [nvarchar](255) NULL,
	[Lineoftherapy] [nvarchar](255) NULL,
	[Disease] [nvarchar](255) NULL,
	[Diseasepaatientpopulation] [nvarchar](255) NULL,
	[DiseaseStage] [nvarchar](255) NULL,
	[TreatmentSegment] [nvarchar](255) NULL,
	[LineofTreatment] [nvarchar](255) NULL,
	[Qualityoflife] [nvarchar](255) NULL,
	[Indicationforsciencemain] [nvarchar](255) NULL,
	[Studyduration] [nvarchar](255) NULL,
	[Noofpatientspertreatmentgroup] [nvarchar](255) NULL,
	[Enrollmentrate] [int] NULL,
	[FinalINDStatus] [nvarchar](255) NULL,
	[INDNumber] [nvarchar](255) NULL,
	[Credentials] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[Region] [nvarchar](255) NULL,
	[Interventionaltrialdatacollection] [nvarchar](255) NULL,
	[NonInterventionaltrialdatacollection] [nvarchar](255) NULL,
	[StudySponsor] [nvarchar](255) NULL,
	[StudyDrugSource] [nvarchar](255) NULL,
	[OtherCooperativeGroup] [nvarchar](255) NULL,
	[Isrequestingacompanystudycompound] [bit] NULL,
	[Othersupportdescription] [nvarchar](255) NULL,
	[Isrequestingsupportfromcompanyotherthandrugorfunding] [bit] NULL,
	[Globalfundingrequested] [int] NULL,
	[Isamendmentrequestincludesachangeintheprimaryinvestigator] [bit] NULL,
	[Isautoproxyenabled] [bit] NULL,
	[Leadorganization] [nvarchar](255) NULL,
	[Isconditionalapproval] [bit] NULL,
	[Conditionsofapproval] [nvarchar](max) NULL,
	[ICFReview] [nvarchar](255) NULL,
	[Amendmentstatus] [nvarchar](255) NULL,
	[Amendmenttype] [nvarchar](255) NULL,
	[Contractamendmentrequired] [nvarchar](255) NULL,
	[Ipistudyssponsor] [bit] NULL,
	[Migrationdate] [datetime] NULL,
	[Conversionstatus] [nvarchar](255) NULL,
	[Milestoneupdatefrequencydays] [int] NULL,
	[Accrualmilestoneupdatefrequencydays] [int] NULL,
	[Lastsendemail] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_IISAdmindetails_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EditStudyAttributes_H') 
BEGIN
	CREATE TABLE [dbo].[EditStudyAttributes_H](
	[PsuedoKey] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[ParentID] [int] NULL,
	[ParentName] [nvarchar](300) NULL,
	[ChildId] [int] NULL,
	[ChildName] [nvarchar](300) NULL,
	[SubChildID] [int] NULL,
	[SubChildName] [nvarchar](300) NULL,
	[GrandChildId] [int] NULL,
	[GrandChildName] [nvarchar](300) NULL,
	[Description] [nvarchar](300) NULL,
	[FieldType] [nvarchar](max) NULL,
	[HelpText] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[ListofValuesId] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[IsMandatory] [bit] NULL,
	[IsViewable] [bit] NULL,
	[IsSearchable] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[ColumnWidth] [int] NULL,
	[RegexExpression] [nvarchar](max) NULL,
	[ValidationMessage] [nvarchar](max) NULL,
	[GroupPermissionsId] [int] NULL,
	[RestrictCreateUser] [varchar](max) NULL,
	[RestrictViewUser] [varchar](max) NULL,
	[RestrictEditUser] [varchar](max) NULL,
	[RestrictDeleteUser] [varchar](max) NULL,
	[IsFieldViewableInMetaData] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
	[ANJU_ChangeType] [int] NOT NULL,
	[ANJU_HistoryDate] [datetime] NULL,
 CONSTRAINT [PK_EditStudyAttributes_H] PRIMARY KEY CLUSTERED 
(
	[PsuedoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Operation') 
BEGIN
CREATE TABLE [dbo].[Operation](
	[Id] [uniqueidentifier] NOT NULL,
	[OperationId] [int] NOT NULL,
	[WorkflowName] [nvarchar](1000) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[ProxyUser] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END


IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OperationWorkflowLog') 
BEGIN
CREATE TABLE [dbo].[OperationWorkflowLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessId] [uniqueidentifier] NOT NULL,
	[Comment] [nvarchar](1000) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[ProxyUser] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OperationWorkflowLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[OperationWorkflowLog]  WITH CHECK ADD  CONSTRAINT [FK_OperationWorkflowLog_Operation] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Operation] ([Id])

ALTER TABLE [dbo].[OperationWorkflowLog] CHECK CONSTRAINT [FK_OperationWorkflowLog_Operation]

END
GO

IF 0 = (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DefaultMileStone') 
BEGIN

CREATE TABLE [dbo].[DefaultMileStone](
	[DefaultMilestoneID] [int] IDENTITY(1,1) NOT NULL,
	[MilestoneType] [nvarchar](100) NOT NULL,
	[MilestoneName] [nvarchar](max) NOT NULL,
	[BusinessDays] [int] NOT NULL,
	[Dependency] [int] NOT NULL,
	[StudyPhase] [nvarchar](50) NOT NULL,
	[Comments] [nvarchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ANJU_AddedBy] [nvarchar](63) NULL,
	[ANJU_AddDate] [datetime] NULL,
	[ANJU_ChangedBy] [nvarchar](63) NULL,
	[ANJU_ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_DefaultMileStone] PRIMARY KEY CLUSTERED 
(
	[DefaultMilestoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

GO



/*
	WorkflowEngine.NET Provider for MSSQL and Azure SQL(https://workflowengine.io)
	Workflow Tables
*/

BEGIN TRANSACTION

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessScheme'
		)
BEGIN
	CREATE TABLE WorkflowProcessScheme (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessScheme PRIMARY KEY
		,[Scheme] NTEXT NOT NULL
		,[DefiningParameters] NTEXT NOT NULL
		,[DefiningParametersHash] NVARCHAR(24) NOT NULL
		,[SchemeCode] NVARCHAR(256) NOT NULL
		,[IsObsolete] BIT DEFAULT 0 NOT NULL
		,[RootSchemeCode] NVARCHAR(256)
		,[RootSchemeId] UNIQUEIDENTIFIER
		,[AllowedActivities] NVARCHAR(max)
		,[StartingTransition] NVARCHAR(max)
		)

	CREATE INDEX IX_SchemeCode_Hash_IsObsolete ON WorkflowProcessScheme (
		SchemeCode
		,DefiningParametersHash
		,IsObsolete
		)

	PRINT 'WorkflowProcessScheme CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessInstance'
		)
BEGIN
	CREATE TABLE WorkflowProcessInstance (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessInstance PRIMARY KEY
		,[StateName] NVARCHAR(max)
		,[ActivityName] NVARCHAR(max) NOT NULL
		,[SchemeId] UNIQUEIDENTIFIER
		,[PreviousState] NVARCHAR(max)
		,[PreviousStateForDirect] NVARCHAR(max)
		,[PreviousStateForReverse] NVARCHAR(max)
		,[PreviousActivity] NVARCHAR(max)
		,[PreviousActivityForDirect] NVARCHAR(max)
		,[PreviousActivityForReverse] NVARCHAR(max)
		,[ParentProcessId] UNIQUEIDENTIFIER
		,[RootProcessId] UNIQUEIDENTIFIER NOT NULL
		,[IsDeterminingParametersChanged] BIT DEFAULT 0 NOT NULL
		)

	PRINT 'WorkflowProcessInstance CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessInstancePersistence'
		)
BEGIN
	CREATE TABLE WorkflowProcessInstancePersistence (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessInstancePersistence PRIMARY KEY NONCLUSTERED
		,[ProcessId] UNIQUEIDENTIFIER NOT NULL
		,[ParameterName] NVARCHAR(max) NOT NULL
		,[Value] NVARCHAR(max) NOT NULL
		)

	CREATE CLUSTERED INDEX IX_ProcessId_Clustered ON WorkflowProcessInstancePersistence (ProcessId)

	PRINT 'WorkflowProcessInstancePersistence CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessTransitionHistory'
		)
BEGIN
	CREATE TABLE WorkflowProcessTransitionHistory (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessTransitionHistory PRIMARY KEY NONCLUSTERED
		,[ProcessId] UNIQUEIDENTIFIER NOT NULL
		,[ExecutorIdentityId] NVARCHAR(256)
		,[ActorIdentityId] NVARCHAR(256)
		,[FromActivityName] NVARCHAR(max) NOT NULL
		,[ToActivityName] NVARCHAR(max) NOT NULL
		,[ToStateName] NVARCHAR(max)
		,[TransitionTime] DATETIME NOT NULL
		,[TransitionClassifier] NVARCHAR(max) NOT NULL
		,[IsFinalised] BIT NOT NULL
		,[FromStateName] NVARCHAR(max)
		,[TriggerName] NVARCHAR(max)
		)

	CREATE CLUSTERED INDEX IX_ProcessId_Clustered ON WorkflowProcessTransitionHistory (ProcessId)

	CREATE INDEX IX_ExecutorIdentityId ON WorkflowProcessTransitionHistory (ExecutorIdentityId)

	PRINT 'WorkflowProcessTransitionHistory CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessInstanceStatus'
		)
BEGIN
	CREATE TABLE WorkflowProcessInstanceStatus (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessInstanceStatus PRIMARY KEY
		,[Status] TINYINT NOT NULL
		,[Lock] UNIQUEIDENTIFIER NOT NULL
		)

	PRINT 'WorkflowProcessInstanceStatus CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM sys.procedures
		WHERE name = N'spWorkflowProcessResetRunningStatus'
		)
BEGIN
	EXECUTE (
			'CREATE PROCEDURE [spWorkflowProcessResetRunningStatus]
	AS
	BEGIN
		UPDATE [WorkflowProcessInstanceStatus] SET [WorkflowProcessInstanceStatus].[Status] = 2 WHERE [WorkflowProcessInstanceStatus].[Status] = 1
	END'
			)

	PRINT 'spWorkflowProcessResetRunningStatus CREATE PROCEDURE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowScheme'
		)
BEGIN
	CREATE TABLE WorkflowScheme (
		[Code] NVARCHAR(256) NOT NULL CONSTRAINT PK_WorkflowScheme PRIMARY KEY,
		[Scheme] NVARCHAR(max) NOT NULL,
		[CanBeInlined] [bit] NOT NULL DEFAULT(0),
		[InlinedSchemes] [nvarchar](max) NULL
		)

	PRINT 'WorkflowScheme CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM sys.procedures
		WHERE name = N'DropWorkflowProcess'
		)
BEGIN
	EXECUTE (
			'CREATE PROCEDURE [DropWorkflowProcess]
		@id uniqueidentifier
	AS
	BEGIN
		BEGIN TRAN

		DELETE FROM dbo.WorkflowProcessInstance WHERE Id = @id
		DELETE FROM dbo.WorkflowProcessInstanceStatus WHERE Id = @id
		DELETE FROM dbo.WorkflowProcessInstancePersistence  WHERE ProcessId = @id

		COMMIT TRAN
	END'
			)

	PRINT 'DropWorkflowProcess CREATE PROCEDURE'
END

IF NOT EXISTS (
		SELECT 1
		FROM sys.procedures
		WHERE name = N'DropWorkflowProcesses'
		)
BEGIN
	EXECUTE (
			'CREATE TYPE IdsTableType AS TABLE
	( Id uniqueidentifier );'
			)

	PRINT 'IdsTableType CREATE TYPE'

	EXECUTE (
			'CREATE PROCEDURE [DropWorkflowProcesses]
		@Ids  IdsTableType	READONLY
	AS
	BEGIN
		BEGIN TRAN

		DELETE dbo.WorkflowProcessInstance FROM dbo.WorkflowProcessInstance wpi  INNER JOIN @Ids  ids ON wpi.Id = ids.Id
		DELETE dbo.WorkflowProcessInstanceStatus FROM dbo.WorkflowProcessInstanceStatus wpi  INNER JOIN @Ids  ids ON wpi.Id = ids.Id
		DELETE dbo.WorkflowProcessInstanceStatus FROM dbo.WorkflowProcessInstancePersistence wpi  INNER JOIN @Ids  ids ON wpi.ProcessId = ids.Id


		COMMIT TRAN
	END'
			)

	PRINT 'DropWorkflowProcesses CREATE PROCEDURE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowInbox'
		)
BEGIN
	CREATE TABLE WorkflowInbox (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowInbox PRIMARY KEY NONCLUSTERED
		,[ProcessId] UNIQUEIDENTIFIER NOT NULL
		,[IdentityId] NVARCHAR(256) NOT NULL
		)

	CREATE CLUSTERED INDEX IX_IdentityId_Clustered ON WorkflowInbox (IdentityId)

	CREATE INDEX IX_ProcessId ON WorkflowInbox (ProcessId)

	PRINT 'WorkflowInbox CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM sys.procedures
		WHERE name = N'DropWorkflowInbox'
		)
BEGIN
	EXECUTE (
			'CREATE PROCEDURE [DropWorkflowInbox]
		@processId uniqueidentifier
	AS
	BEGIN
		BEGIN TRAN
		DELETE FROM dbo.WorkflowInbox WHERE ProcessId = @processId
		COMMIT TRAN
	END'
			)

	PRINT 'DropWorkflowInbox CREATE PROCEDURE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowProcessTimer'
		)
BEGIN
	CREATE TABLE WorkflowProcessTimer (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowProcessTimer PRIMARY KEY NONCLUSTERED
		,[ProcessId] UNIQUEIDENTIFIER NOT NULL
		,[Name] NVARCHAR(max) NOT NULL
		,[NextExecutionDateTime] DATETIME NOT NULL
		,[Ignore] BIT NOT NULL
		)

	CREATE CLUSTERED INDEX IX_NextExecutionDateTime_Clustered ON WorkflowProcessTimer (NextExecutionDateTime)

	PRINT 'WorkflowProcessTimer CREATE TABLE'
END

IF NOT EXISTS (
		SELECT 1
		FROM [INFORMATION_SCHEMA].[TABLES]
		WHERE [TABLE_NAME] = N'WorkflowGlobalParameter'
		)
BEGIN
	CREATE TABLE WorkflowGlobalParameter (
		[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_WorkflowGlobalParameter PRIMARY KEY NONCLUSTERED
		,[Type] NVARCHAR(306) NOT NULL
		,[Name] NVARCHAR(128) NOT NULL
		,[Value] NVARCHAR(max) NOT NULL
		)

	CREATE UNIQUE CLUSTERED INDEX IX_Type_Name_Clustered ON WorkflowGlobalParameter (
		Type
		,Name
		)

	PRINT 'WorkflowGlobalParameter CREATE TABLE'
END

COMMIT TRANSACTION

/*
	WorkflowEngine.NET Provider for MSSQL and Azure SQL(https://workflowengine.io)
	Upgrade Workflow from 4.0 to 4.1
*/


IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'WorkflowProcessInstance' 
AND [COLUMN_NAME] = N'TenantId')
BEGIN
	ALTER TABLE WorkflowProcessInstance ADD TenantId nvarchar (1024) NULL
	PRINT 'ADD WorkflowProcessInstance.TenantId type nvarchar(1024) NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'WorkflowScheme' 
AND [COLUMN_NAME] = N'Tags')
BEGIN
    ALTER TABLE WorkflowScheme ADD Tags nvarchar(max) NULL
    PRINT 'ADD WorkflowScheme.Tags type nvarchar(max) NULL'
END
GO

/*IsDisplay Column added in SysCodeValues*/
IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'SysCodeValues' 
AND [COLUMN_NAME] = N'IsDisplay')
BEGIN
	ALTER TABLE SysCodeValues ADD IsDisplay bit NULL
	PRINT 'ADD SysCodeValues.IsDisplay type bit NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'SysCodeValues_H' 
AND [COLUMN_NAME] = N'IsDisplay')
BEGIN
	ALTER TABLE SysCodeValues_H ADD IsDisplay bit NULL
	PRINT 'ADD SysCodeValues_H.IsDisplay type bit NULL'
END
GO

/*SortOrder column added in GlobalSettings*/
IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'GlobalSettings' 
AND [COLUMN_NAME] = N'SortOrder')
BEGIN
    ALTER TABLE GlobalSettings ADD SortOrder int NULL
    PRINT 'ADD GlobalSettings.SortOrder type int NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'GlobalSettings_H' 
AND [COLUMN_NAME] = N'SortOrder')
BEGIN
    ALTER TABLE GlobalSettings_H ADD SortOrder int NULL
    PRINT 'ADD GlobalSettings_H.SortOrder type int NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'StudyProtocol' 
AND [COLUMN_NAME] = N'Module')
BEGIN
    ALTER TABLE StudyProtocol ADD Module  nvarchar(50) NULL
    PRINT 'ADD StudyProtocol.Module type nvarchar NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'StudyProtocol_H' 
AND [COLUMN_NAME] = N'Module')
BEGIN
    ALTER TABLE StudyProtocol_H ADD Module  nvarchar(50) NULL
    PRINT 'ADD StudyProtocol_H.Module type nvarchar NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'StudyCompounds' 
AND [COLUMN_NAME] = N'Module')
BEGIN
    ALTER TABLE StudyCompounds ADD Module  nvarchar(50) NULL
    PRINT 'ADD StudyCompounds.Module type nvarchar NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'StudyCompounds_H' 
AND [COLUMN_NAME] = N'Module')
BEGIN
    ALTER TABLE StudyCompounds_H ADD Module  nvarchar(50) NULL
    PRINT 'ADD StudyCompounds_H.Module type nvarchar NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'DrugorCompounddetails' 
AND [COLUMN_NAME] = N'IsActive')
BEGIN
    ALTER TABLE DrugorCompounddetails ADD IsActive bit NULL
    PRINT 'ADD DrugorCompounddetails.IsActive type bit NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'DrugorCompounddetails' 
AND [COLUMN_NAME] = N'IsDeleted')
BEGIN
    ALTER TABLE DrugorCompounddetails ADD IsDeleted bit NULL
    PRINT 'ADD DrugorCompounddetails.IsDeleted type bit NULL'
END
GO


IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'DrugorCompounddetails_H' 
AND [COLUMN_NAME] = N'IsActive')
BEGIN
    ALTER TABLE DrugorCompounddetails_H ADD IsActive bit NULL
    PRINT 'ADD DrugorCompounddetails_H.IsActive type bit NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'DrugorCompounddetails_H' 
AND [COLUMN_NAME] = N'IsDeleted')
BEGIN
    ALTER TABLE DrugorCompounddetails_H ADD IsDeleted bit NULL
    PRINT 'ADD DrugorCompounddetails_H.IsDeleted type bit NULL'
END
GO
IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'Submissions' 
AND [COLUMN_NAME] = N'DocumentSize')
BEGIN
    ALTER TABLE Submissions ADD DocumentSize int NULL
    PRINT 'ADD Submissions.DocumentSize type int NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'Submissions' 
AND [COLUMN_NAME] = N'DocumentExtension')
BEGIN
    ALTER TABLE Submissions ADD DocumentExtension  nvarchar(50) NULL
    PRINT 'ADD Submissions.DocumentExtension type nvarchar NULL'
END
GO


IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'Submissions_H' 
AND [COLUMN_NAME] = N'DocumentSize')
BEGIN
    ALTER TABLE Submissions_H ADD DocumentSize int NULL
    PRINT 'ADD Submissions_H.DocumentSize type int NULL'
END
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = N'Submissions_H' 
AND [COLUMN_NAME] = N'DocumentExtension')
BEGIN
    ALTER TABLE Submissions_H ADD DocumentExtension  nvarchar(50) NULL
    PRINT 'ADD Submissions_H.DocumentExtension type nvarchar NULL'
END
GO