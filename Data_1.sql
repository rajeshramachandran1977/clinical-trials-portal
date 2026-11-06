IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Salutation' AND Code = 'Dr') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Salutation', 'Dr', 'Doctor', 0, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Salutation' AND Code = 'Mr') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Salutation', 'Mr', 'Mister', 1, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Salutation' AND Code = 'Ms') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Salutation', 'Ms', 'Miss', 2, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Salutation' AND Code = 'Mrs') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Salutation', 'Mrs', 'Mises', 3, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserStatus' AND Code = 'Active') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'UserStatus', 'Active', 'Active', 0, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserStatus' AND Code = 'Inactive') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'UserStatus', 'Inactive', 'Inactive', 1, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserStatus' AND Code = 'Locked') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'UserStatus', 'Locked', 'Locked', 2, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Gender' AND Code = 'Female') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Gender', 'Female', 'Female', 1, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Gender' AND Code = 'Male') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users', 'Gender', 'Male', 'Male', 2, 1, 0, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Credentials' AND Code = 'BA') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Credentials','BA','BA',1,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Credentials' AND Code = 'BS') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Credentials','BS','BS',2,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Credentials' AND Code = 'DO') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Credentials','DO','DO',3,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Credentials' AND Code = 'JD') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Credentials','JD','JD',4,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Credentials' AND Code = 'LPN') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Credentials','LPN','LPN',5,1,0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Suffix' AND Code = 'II') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Suffix',	'II','II',1,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Suffix' AND Code = 'III') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Suffix','III','III',	2,1,0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Suffix' AND Code = 'IV') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Suffix','IV','IV',3,	1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Suffix' AND Code = 'Jr.') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Suffix','Jr.','Jr.',4,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Suffix' AND Code = 'Sr.') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Suffix','Sr.','Sr.',	5,1,0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Biostatistics') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Department','Biostatistics','Biostatistics',1,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Clinical Operations') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Department','Clinical Operations','Clinical Operations',	2,1,0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Clinical Research') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Department','Clinical Research','Clinical Research',3,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Discovery') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users','Department',	'Discovery','Discovery',4,1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Drug Supply') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'Department',	'Drug Supply',	'Drug Supply',	5,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'Department' AND Code = 'Executive Team') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'Department',	'Executive Team',	'Executive Team',	6,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'TrialLeader') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'TrialLeader',	'Trial Leader',	1,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'IISAdmin') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'IISAdmin',	'IISAdmin',	2,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'MeetingMembers') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'MeetingMembers',	'Meeting Members',	3,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'MD') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'MD',	'MD',	4,	1,	0,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'MSL') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'MSL',	'MSL',	5,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'MSL RD') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'MSL RD',	'MSL RD',	6,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'Admin') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'Admin',	'Admin',	7,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'ContractManager') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'ContractManager',	'Contract Manager',	8,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'Management') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'Management',	'Management',	9,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'ProgramLeader') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'ProgramLeader',	'Program Leader',	10,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Users' AND ColumnName = 'UserType' AND Code = 'PI') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Users',	'UserType',	'PI',	'PI',	11,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundType' AND Code = 'Co-Therapy') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundType',	'Co-Therapy',	'Co-Therapy',	1,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundType' AND Code = 'Comparator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundType',	'Comparator',	'Comparator',	2,	1,0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundCategory' AND Code = 'Primary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundCategory',	'Primary',	'Primary',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundCategory' AND Code = 'Secondary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundCategory',	'Secondary',	'Secondary',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundCategory' AND Code = 'Tertiary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundCategory',	'Tertiary',	'Tertiary',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Objectivenames' AND Code = 'Biomarkers') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Objectivenames',	'Biomarkers',	'Biomarkers',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Objectivenames' AND Code = 'Bone Anabolic Effect') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Objectivenames',	'Bone Anabolic Effect',	'Bone Anabolic Effect',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Objectivetypes' AND Code = 'Primary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Objectivetypes',	'Primary',	'Primary',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Objectivetypes' AND Code = 'Secondary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Objectivetypes',	'Secondary',	'Secondary',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Objectivetypes' AND Code = 'Exploratory') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Objectivetypes',	'Exploratory',	'Exploratory',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Randomized' AND Code = 'Randomized') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Randomized',	'Randomized',	'Randomized',	NULL	,1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Randomized' AND Code = 'Non-Randomized') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Randomized',	'Non-Randomized',	'Non-Randomized',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Structure' AND Code = 'None') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Structure',	'None',	'None',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Structure' AND Code = 'Cross-Over') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Structure',	'Cross-Over',	'Cross-Over',	NULL,	1,	0,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Structure' AND Code = 'Intra-Subject') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Structure',	'Intra-Subject',	'Intra-Subject',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Structure' AND Code = 'Parallel Group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Structure',	'Parallel Group',	'Parallel Group',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Structure' AND Code = 'Single Group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Structure',	'Single Group',	'Single Group',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Typeoftrialdrug' AND Code = 'Investigational') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Typeoftrialdrug',	'Investigational',	'Investigational',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Typeoftrialdrug' AND Code = 'Comparator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Typeoftrialdrug',	'Comparator',	'Comparator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Typeoftrialdrug' AND Code = 'Co-therapy') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Typeoftrialdrug',	'Co-therapy',	'Co-therapy',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Blinding' AND Code = 'Open') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Blinding',	'Open',	'Open',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Blinding' AND Code = 'Single Bind') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Blinding',	'Single Bind',	'Single Bind',	NULL,	1,	0,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Blinding' AND Code = 'Double Bind') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Blinding',	'Double Bind',	'Double Bind',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundPrimary' AND Code = 'AFINITOR(everolimus/RAD001)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundPrimary',	'AFINITOR(everolimus/RAD001)',	'AFINITOR(everolimus/RAD001)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundPrimary' AND Code = 'Arzerra(ofatumumab/OMB157)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundPrimary',	'Arzerra(ofatumumab/OMB157)',	'Arzerra(ofatumumab/OMB157)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundSecondary' AND Code = 'AFINITOR(everolimus/RAD001)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundSecondary',	'AFINITOR(everolimus/RAD001)',	'AFINITOR(everolimus/RAD001)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundSecondary' AND Code = 'Arzerra(ofatumumab/OMB157)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundSecondary',	'Arzerra(ofatumumab/OMB157)',	'Arzerra(ofatumumab/OMB157)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundTertiary' AND Code = 'AFINITOR(everolimus/RAD001)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundTertiary',	'AFINITOR(everolimus/RAD001)',	'AFINITOR(everolimus/RAD001)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundTertiary' AND Code = 'Arzerra(ofatumumab/OMB157)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundTertiary',	'Arzerra(ofatumumab/OMB157)',	'Arzerra(ofatumumab/OMB157)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MinimumAge' AND Code = '6 mos') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MinimumAge',	'6 mos',	'6 mos',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MinimumAge' AND Code = '1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MinimumAge',	'1',	'1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MinimumAge' AND Code = '2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MinimumAge',	'1',	'2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MaximumAge' AND Code = 'None') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MaximumAge',	'None',	'None',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MaximumAge' AND Code = '1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MaximumAge',	'1',	'1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'MaximumAge' AND Code = '2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'MaximumAge',	'2',	'2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'CooperativeGroupName' AND Code = 'Alliance for clinical trials in oncology') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'CooperativeGroupName',	'Alliance for clinical trials in oncology',	'Alliance for clinical trials in oncology',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'CooperativeGroupName' AND Code = 'American college of Radiology imaging Network') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'CooperativeGroupName',	'American college of Radiology imaging Network',	'American college of Radiology imaging Network',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'CooperativeGroupName' AND Code = 'American college of surgeons oncology group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'CooperativeGroupName',	'American college of surgeons oncology group',	'American college of surgeons oncology group',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Franchise' AND Code = 'Breast') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Franchise',	'Breast',	'Breast',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Franchise' AND Code = 'EDSI') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Franchise',	'EDSI',	'EDSI',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Franchise' AND Code = 'Hematology') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Franchise',	'Hematology',	'Hematology',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Franchise' AND Code = 'Oncology') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Franchise',	'Oncology',	'Oncology',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PrimaryIndication' AND Code = 'Aggressive Systemic Mastocytosis') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PrimaryIndication',	'Aggressive Systemic Mastocytosis',	'Aggressive Systemic Mastocytosis',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PrimaryIndication' AND Code = 'Amyloidosis') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PrimaryIndication',	'Amyloidosis',	'Amyloidosis',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PrimaryIndication' AND Code = 'Carcinoma-Adenoid Cystic') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PrimaryIndication',	'Carcinoma-Adenoid Cystic',	'Carcinoma-Adenoid Cystic',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PrimaryIndication' AND Code = 'Carcinoma-Basal Cell') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PrimaryIndication',	'Carcinoma-Basal Cell',	'Carcinoma-Basal Cell',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PIInstitution' AND Code = 'ACORN Research LLC') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PIInstitution',	'ACORN Research LLC',	'ACORN Research LLC',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PIInstitution' AND Code = 'Albany Medical College') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PIInstitution',	'Albany Medical College',	'Albany Medical College',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'PIInstitution' AND Code = 'Alvin J. Siteman Cancer Center Washington University School of Medicine and Barnes-Jewish Hospital') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'PIInstitution',	'Alvin J. Siteman Cancer Center Washington University School of Medicine and Barnes-Jewish Hospital',	'Alvin J. Siteman Cancer Center Washington University School of Medicine and Barnes-Jewish Hospital',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Decision' AND Code = 'Accepted') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Decision',	'Accepted',	'Accepted',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'Decision' AND Code = 'Resubmit') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'Decision',	'Resubmit',	'Resubmit',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentStatus' AND Code = 'Draft') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentStatus',	'Draft',	'Draft',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentStatus' AND Code = 'Final') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentStatus',	'Final',	'Final',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentStatus' AND Code = 'N/A') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentStatus',	'N/A',	'N/A',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentStatus' AND Code = 'Pending Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentStatus',	'Pending Review',	'PendingReview',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'CDA') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'CDA',	'CDA',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'CIF') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'CIF',	'CIF',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'COC') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'COC',	'COC',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'Regulatory') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'Regulatory',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'Attestation') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'Attestation',	'Attestation',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'Submission Support') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'Submission Support',	'SubmissionSupport',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'Document Milestone') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'Document Milestone',	'DocumentMilestone',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentType' AND Code = 'Budget') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentType',	'Budget',	'Budget',	NULL,	1,	0	,'SYSTEM',	GETDATE()	,'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentVersion' AND Code = 'Original') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentVersion',	'Original',	'Original',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentVersion' AND Code = 'Amendment') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentVersion',	'Amendment',	'Amendment',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Documents' AND ColumnName = 'DocumentVersion' AND Code = 'Amendment 1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Documents',	'DocumentVersion',	'Amendment 1',	'Amendment 1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundSecondaryType' AND Code = 'Co-Therapy') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundSecondaryType',	'Co-Therapy',	'Co-Therapy',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundSecondaryType' AND Code = 'Comparator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundSecondaryType',	'Comparator',	'Comparator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundTertiaryType' AND Code = 'Co-Therapy') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundTertiaryType',	'Co-Therapy',	'Co-Therapy',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'NewStudy' AND ColumnName = 'DrugorCompoundTertiaryType' AND Code = 'Comparator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('NewStudy',	'DrugorCompoundTertiaryType',	'Comparator',	'Comparator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'StudyDescriptors' AND Code = 'N/A') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'StudyDescriptors',	'N/A',	'N/A',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'StudyDescriptors' AND Code = 'Chart Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'StudyDescriptors',	'Chart Review',	'Chart Review',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'InterventionStatus' AND Code = 'Interventional') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'InterventionStatus',	'Interventional',	'Interventional',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'InterventionStatus' AND Code = 'Non-Interventional') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'InterventionStatus',	'Non-Interventional',	'Non-Interventional',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PatientType' AND Code = 'Patients') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PatientType',	'Patients',	'Patients',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PatientType' AND Code = 'Healthy Volunteers') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PatientType',	'Healthy Volunteers',	'Healthy Volunteers',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Franchise' AND Code = 'Breast') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Franchise',	'Breast',	'Breast',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'EDSI' AND Code = 'EDSI') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Franchise',	'EDSI',	'EDSI',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Hematology' AND Code = 'Hematology') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Franchise',	'Hematology',	'Hematology',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PatientPopulation' AND Code = 'Adult') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PatientPopulation',	'Adult',	'Adult',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PatientPopulation' AND Code = 'All') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PatientPopulation',	'All',	'All',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PatientPopulation' AND Code = 'Anaemia') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PatientPopulation',	'Anaemia',	'Anaemia',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'RiskFactors' AND Code = '14q32translocations') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'RiskFactors',	'14q32translocations',	'14q32translocations',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'RiskFactors' AND Code = '14q32translocations') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'RiskFactors',	'14q32translocations',	'14q32translocations',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'RiskFactors' AND Code = 'BCL2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'RiskFactors',	'BCL2',	'BCL2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'GenomicProfile' AND Code = 'Basal-Like') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'GenomicProfile',	'Basal-Like',	'Basal-Like',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'GenomicProfile' AND Code = 'BRAF Mutation +') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'GenomicProfile',	'BRAF Mutation +',	'BRAF Mutation +',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'LineOfTherapy' AND Code = '1st Line') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'LineOfTherapy',	'1st Line',	'1st Line',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'LineOfTherapy' AND Code = '1st Line +') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'LineOfTherapy',	'1st Line +',	'1st Line +',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Compoundtype' AND Code = 'Primary [Company] Compound') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Compoundtype',	'Primary [Company] Compound',	'Primary [Company] Compound',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Compoundtype' AND Code = 'Secondary [Company] Compound') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Compoundtype',	'Secondary [Company] Compound',	'Secondary [Company] Compound',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Noncompanycompound' AND Code = '131-Iodine') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Noncompanycompound',	'131-Iodine',	'131-Iodine',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Noncompanycompound' AND Code = 'AC220') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Noncompanycompound',	'AC220',	'AC220',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'IndicationType' AND Code = 'Primary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'IndicationType',	'Primary',	'Primary',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'IndicationType' AND Code = 'Secondary') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'IndicationType',	'Secondary',	'Secondary',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Indication' AND Code = 'Carcinoma-in situ') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Indication',	'Carcinoma-in situ',	'Carcinoma-in situ',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Indication' AND Code = 'Amyloidosis') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Indication',	'Amyloidosis',	'Amyloidosis',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Pandemicpreparednesstrialcategorization' AND Code = 'A') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Pandemicpreparednesstrialcategorization',	'A',	'A',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Pandemicpreparednesstrialcategorization' AND Code = 'B') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Pandemicpreparednesstrialcategorization',	'B',	'B',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Pandemicpreparednesstrialcategorization' AND Code = 'C') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Pandemicpreparednesstrialcategorization',	'C',	'C',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Indstatus' AND Code = 'IND') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Indstatus',	'IND',	'IND',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Indstatus' AND Code = 'IND Exempt') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Indstatus',	'IND Exempt',	'IND Exempt',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Disease' AND Code = 'D1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Disease',	'D1',	'Disease1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Disease' AND Code = 'D2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Disease',	'D1',	'Disease2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Diseaseforpatientpopulation' AND Code = 'D1DP') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Diseaseforpatientpopulation',	'D1DP',	'D1DP',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Diseaseforpatientpopulation' AND Code = 'D2DP') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Diseaseforpatientpopulation',	'D2DP',	'D2DP',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Stage' AND Code = 'Stage1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Stage',	'Stage1',	'Stage1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Stage' AND Code = 'Stage2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Stage',	'Stage2',	'Stage2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Treatmentsegment' AND Code = 'Treatmentsegment1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Treatmentsegment',	'Treatmentsegment1',	'Treatmentsegment1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Treatmentsegment' AND Code = 'Treatmentsegment2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Treatmentsegment',	'Treatmentsegment2',	'Treatmentsegment2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Lineoftreatment' AND Code = 'Lineoftreatment1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Lineoftreatment',	'Lineoftreatment1',	'Lineoftreatment1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Lineoftreatment' AND Code = 'Lineoftreatment2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Lineoftreatment',	'Lineoftreatment2',	'Lineoftreatment2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'QualityofLife' AND Code = 'QualityofLife1') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'QualityofLife',	'QualityofLife1',	'QualityofLife1',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'QualityofLife' AND Code = 'QualityofLife2') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'QualityofLife',	'QualityofLife2',	'QualityofLife2',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'NoncompanyCompound' AND Code = '131-Iodine') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'NoncompanyCompound',	'131-Iodine',	'131-Iodine',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'NoncompanyCompound' AND Code = 'AC220') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'NoncompanyCompound',	'AC220',	'AC220',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Contacttype' AND Code = 'Budget Coordinator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Contacttype',	'Budget Coordinator',	'Budget Coordinator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Contacttype' AND Code = 'Clinical Trials Manager') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Contacttype',	'Clinical Trials Manager',	'Clinical Trials Manager',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Country' AND Code = 'USA') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Country',	'USA',	'USA',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Country' AND Code = 'Canada') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Country',	'Canada',	'Canada',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Region' AND Code = 'North America') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Region',	'North America',	'North America',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Region' AND Code = 'Europe') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Region',	'Europe',	'Europe',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'LocalMRCDecision' AND Code = 'Rejected') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'LocalMRCDecision',	'Rejected',	'Rejected',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'LocalMRCDecision' AND Code = 'Approved') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'LocalMRCDecision',	'Approved',	'Approved',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'LocalMRCDecision' AND Code = 'Conditionally Approved - Resubmission required') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'LocalMRCDecision',	'Conditionally Approved - Resubmission required',	'Conditionally Approved - Resubmission required',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'LocalMRCDecision' AND Code = 'Tabled') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'LocalMRCDecision',	'Tabled',	'Tabled',	4,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'LocalMRCDecision' AND Code = 'Withdrawn') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'LocalMRCDecision',	'Withdrawn',	'Withdrawn',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'RejectedDecisionComments' AND Code = 'Budget') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'RejectedDecisionComments',	'Budget',	'Budget',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'RejectedDecisionComments' AND Code = 'Contract') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'RejectedDecisionComments',	'Contract',	'Contract',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'RejectedDecisionComments' AND Code = 'Investigator/Site Qualifications') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'RejectedDecisionComments',	'Investigator/Site Qualifications',	'Investigator/Site Qualifications',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'RejectedDecisionComments' AND Code = 'Medical Strategy') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'RejectedDecisionComments',	'Medical Strategy',	'Medical Strategy',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'DocumentType' AND Code = 'Meeting Support') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'DocumentType',	'Meeting Support',	'Meeting Support',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'DeliveryMethod' AND Code = 'Allow system to send documents') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'DeliveryMethod',	'Allow system to send documents',	'Allow system to send documents',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'DeliveryMethod' AND Code = 'Send documents manually') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'DeliveryMethod',	'Send documents manually',	'Send documents manually',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalSAEFrequency' AND Code = 'Annual') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalSAEFrequency',	'Annual',	'Annual',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalSAEFrequency' AND Code = 'Quaterly') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalSAEFrequency',	'Quaterly',	'Quaterly',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalSAEFrequency' AND Code = 'Biannually') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalSAEFrequency',	'Biannually',	'Biannually',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReSubmissionComments' AND Code = 'PI consents to resubmit') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReSubmissionComments',	'PI consents to resubmit',	'PI consents to resubmit',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReSubmissionComments' AND Code = 'PI declines to resubmit') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReSubmissionComments',	'PI declines to resubmit',	'PI declines to resubmit',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Approved') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Approved',	'Approved',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Conditionally Approved') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Conditionally Approved',	'Conditionally Approved',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Conditionally Approved - Resubmission required') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Conditionally Approved - Resubmission required',	'Conditionally Approved - Resubmission required',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Rejected') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Rejected',	'Rejected',	4,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Tabled') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Tabled',	'Tabled',	5,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GlobalMRCDecision' AND Code = 'Withdrawn') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GlobalMRCDecision',	'Withdrawn',	'Withdrawn',	6,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Organization' AND Code = 'Organization A') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'Organization',	'Organization A',	'Organization A',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Organization' AND Code = 'Organization B') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'Organization',	'Organization B',	'Organization B',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Organization' AND Code = 'Sponsor Protocol Number') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'Organization',	'Sponsor Protocol Number',	'Sponsor Protocol Number',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Organization' AND Code = 'MACS') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'Organization',	'MACS',	'MACS',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Datacollectioninterventional' AND Code = 'WITH a [Company] Drug') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Datacollectioninterventional',	'WITH a [Company] Drug',	'WITH a [Company] Drug',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Datacollectioninterventional' AND Code = 'WITH No [Company] Drug') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Datacollectioninterventional',	'WITH No [Company] Drug',	'WITH No [Company] Drug',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Datacollectionnoninterventional' AND Code = 'Involving PRIMARY DATA COLLECTION WITH a [Company] Product of Focus') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Datacollectionnoninterventional',	'Involving PRIMARY DATA COLLECTION WITH a [Company] Product of Focus',	'Involving PRIMARY DATA COLLECTION WITH a [Company] Product of Focus',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Datacollectionnoninterventional' AND Code = 'Involving PRIMARY DATA COLLECTION WITHOUT a [Company] Product of Focus') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Datacollectionnoninterventional',	'Involving PRIMARY DATA COLLECTION WITHOUT a [Company] Product of Focus',	'Involving PRIMARY DATA COLLECTION WITHOUT a [Company] Product of Focus',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'Datacollectionnoninterventional' AND Code = 'BASED ON SECONDARY USE OF DATA') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'Datacollectionnoninterventional',	'BASED ON SECONDARY USE OF DATA',	'BASED ON SECONDARY USE OF DATA',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewDecision' AND Code = 'Approved') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewDecision',	'Approved',	'Approved',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewDecision' AND Code = 'Rejected') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewDecision',	'Rejected',	'Rejected',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GMRCApprovalTasks' AND Code = 'Upload Fair Market Value Analysis Document') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GMRCApprovalTasks',	'Upload Fair Market Value Analysis Document',	'Upload Fair Market Value Analysis Document',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GMRCApprovalTasks' AND Code = 'Drug Activities') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GMRCApprovalTasks',	'Drug Activities',	'Drug Activities',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GMRCApprovalTasks' AND Code = 'Manage Contract Status') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GMRCApprovalTasks',	'Manage Contract Status',	'Manage Contract Status',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'GMRCApprovalTasks' AND Code = 'Identify Activation Documents') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'GMRCApprovalTasks',	'Identify Activation Documents',	'Identify Activation Documents',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'PIApprovalTasks' AND Code = 'Submit Required ICF Document') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'PIApprovalTasks',	'Submit Required ICF Document',	'Submit Required ICF Document',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'PIApprovalTasks' AND Code = 'Submit Protocol') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'PIApprovalTasks',	'Submit Protocol',	'Submit Protocol',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ContractType' AND Code = 'Original') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ContractType',	'Original',	'Original',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ContractType' AND Code = 'Amendment') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ContractType',	'Amendment',	'Amendment',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ContractStatus' AND Code = 'Fully-Executed Contract') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ContractStatus',	'Fully-Executed Contract',	'Fully-Executed Contract',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ContractStatus' AND Code = 'CIF') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ContractStatus',	'CIF',	'CIF',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'CurrentLocation' AND Code = 'Contracts Group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'CurrentLocation',	'Contracts Group',	'Contracts Group',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'CurrentLocation' AND Code = 'Site') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'CurrentLocation',	'Site',	'Site',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'IND or IND Exemption Letter (Include Novartis form)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'IND or IND Exemption Letter (Include Novartis form)',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'FDA 1572 Form (both sides)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'FDA 1572 Form (both sides)',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'Drug Shipping Form') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'Drug Shipping Form',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'Signed CV of Principal Investigator (copy filed w/USMA)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'Signed CV of Principal Investigator (copy filed w/USMA)',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'Medical License') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'Medical License',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'IRB Approved Protocol') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'IRB Approved Protocol',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'IRB Approved Patient Informed Consent') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'IRB Approved Patient Informed Consent',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'IRB Approval Letter') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'IRB Approval Letter',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'IdentifyActivationDocuments' AND Code = 'Fully executed Clinical Trial Agreement (CTA)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'IdentifyActivationDocuments',	'Fully executed Clinical Trial Agreement (CTA)',	'Regulatory',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewICFDecision' AND Code = 'Redlined') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewICFDecision',	'Redlined',	'Redlined',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewICFDecision' AND Code = 'Approved to submit to IRB') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewICFDecision',	'Approved to submit to IRB',	'Approved to submit to IRB',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'StudyStatus' AND Code = 'On Hold') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'StudyStatus',	'On Hold',	'On Hold',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'StudyStatus' AND Code = 'Cancelled') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'StudyStatus',	'Cancelled',	'Cancelled',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'StatusChangeReason' AND Code = 'Administrative / Operational') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'StatusChangeReason',	'Administrative / Operational',	'Administrative / Operational',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'StatusChangeReason' AND Code = 'Investigator Request') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'StatusChangeReason',	'Investigator Request',	'Investigator Request',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'StatusChangeReason' AND Code = 'Regulatory / Safety') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'StatusChangeReason',	'Regulatory / Safety',	'Regulatory / Safety',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM DocumentSubTypes WHERE DocumentSubTypeId = 20158 AND Name = 'VDR' AND Code = 'VDR') 
	BEGIN
		INSERT INTO DocumentSubTypes (DocumentTypeId, Name, Code,  IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES (20158,	'VDR',	'VDR',		1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewProtocolDecision' AND Code = 'Approved to Submit to IRB') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewProtocolDecision',	'Approved to Submit to IRB',	'Approved to Submit to IRB',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ReviewProtocolDecision' AND Code = 'Resubmit') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ReviewProtocolDecision',	'Resubmit',	'Resubmit',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'AmendmentDecision' AND Code = 'Approved') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'AmendmentDecision',	'Accepted',	'Accepted',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'AmendmentDecision' AND Code = 'Rejected') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'AmendmentDecision',	'Rejected',	'Rejected',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'AmendmentDecision' AND Code = 'Resubmit') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'AmendmentDecision',	'Resubmit',	'Resubmit',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO


IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'TLActivationTasks' AND Code = 'TPSR Reconciliation') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'TLActivationTasks',	'TPSR Reconciliation',	'TPSR Reconciliation',	1,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'TLActivationTasks' AND Code = 'Drug Reconciliation') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'TLActivationTasks',	'Drug Reconciliation',	'Drug Reconciliation',	2,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'TLActivationTasks' AND Code = 'Budget Reconciliation') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'TLActivationTasks',	'Budget Reconciliation',	'Budget Reconciliation',	3,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'TLActivationTasks' AND Code = 'PO Closeout Requested') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'TLActivationTasks',	'PO Closeout Requested',	'PO Closeout Requested',	4,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'PIActivationTasks' AND Code = 'Final Study Data/Report') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'PIActivationTasks',	'Final Study Data/Report',	'Final Study Data/Report',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'MaintainanceAndMonitoring' AND ColumnName = 'MaintainanceAndMonitoring' AND Code = 'Accrual Update') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('MaintainanceAndMonitoring',	'MaintainanceAndMonitoring',	'Accrual Update',	'AccrualUpdate',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'MaintainanceAndMonitoring' AND ColumnName = 'MaintainanceAndMonitoring' AND Code = 'Amend Protocol/budget') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('MaintainanceAndMonitoring',	'MaintainanceAndMonitoring',	'Amend Protocol/budget',	'AmendProtocol',	NULL,	2,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'MaintainanceAndMonitoring' AND ColumnName = 'MaintainanceAndMonitoring' AND Code = 'Update Documents') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('MaintainanceAndMonitoring',	'MaintainanceAndMonitoring',	'Update Documents',	'UpdateDocuments',	NULL,	3,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestonePhase' AND Code = 'Closeout') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestonePhase',	'Closeout',	'Closeout',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestonePhase' AND Code = 'Tracking') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestonePhase',	'Tracking',	'Tracking',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneType' AND Code = 'Document') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneType',	'Document',	'Document',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneType' AND Code = 'Enrollment') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneType',	'Enrollment',	'Enrollment',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneType' AND Code = 'Manual (Trial Leader)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneType',	'Manual (Trial Leader)',	'Manual (Trial Leader)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneType' AND Code = 'System') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneType',	'System',	'System',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneStatus' AND Code = 'Complete') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneStatus',	'Complete',	'Complete',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneStatus' AND Code = 'Inactive') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneStatus',	'Inactive',	'Inactive',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneStatus' AND Code = 'N/A') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneStatus',	'N/A',	'N/A',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneStatus' AND Code = 'Pending') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneStatus',	'Pending',	'Pending',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestones' AND ColumnName = 'MilestoneStatus' AND Code = 'Under Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestones',	'MilestoneStatus',	'Under Review',	'Under Review',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PhysicianNetworkNames' AND Code = 'ACORN') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PhysicianNetworkNames',	'ACORN',	'ACORN',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'EditStudy' AND ColumnName = 'PhysicianNetworkNames' AND Code = 'Canadian Urologic Oncology Group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('EditStudy',	'PhysicianNetworkNames',	'Canadian Urologic Oncology Group',	'Canadian Urologic Oncology Group',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Contracttimelines' AND ColumnName = 'ContractStatus' AND Code = 'CIF') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Contracttimelines',	'ContractStatus',	'CIF',	'CIF',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Contracttimelines' AND ColumnName = 'ContractStatus' AND Code = 'Fully-Executed-Contract') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Contracttimelines',	'ContractStatus',	'Fully-Executed-Contract',	'Fully-Executed-Contract',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Contracttimelines' AND ColumnName = 'CurrentLocation' AND Code = 'Contracts Group') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Contracttimelines',	'CurrentLocation',	'Contracts Group',	'Contracts Group',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Contracttimelines' AND ColumnName = 'CurrentLocation' AND Code = 'Site') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Contracttimelines',	'CurrentLocation',	'Site',	'Site',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Cancelled') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Cancelled',	'Closed-Cancelled',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Completed') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Completed',	'Closed-Completed',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Divested') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Divested',	'Closed-Divested',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Stopped by Investigator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Stopped by Investigator',	'Closed-Stopped by Investigator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Stopped by Company') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Stopped by Company',	'Closed-Stopped by Company',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Cancelled') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Cancelled',	'Closed-Cancelled',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Completed') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Completed',	'Closed-Completed',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Divested') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Divested',	'Closed-Divested',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Stopped by Investigator') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Stopped by Investigator',	'Closed-Stopped by Investigator',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO
IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'WorkFlow' AND ColumnName = 'ClosureReasons' AND Code = 'Closed-Stopped by Company') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('WorkFlow',	'ClosureReasons',	'Closed-Stopped by Company',	'Closed-Stopped by Company',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'MilestoneType' AND Code = 'Document') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'MilestoneType',	'Document',	'Document',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'MilestoneType' AND Code = 'Enrollment') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'MilestoneType',	'Enrollment',	'Enrollment',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'MilestoneType' AND Code = 'Manual (Trial Leader)') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'MilestoneType',	'Manual (Trial Leader)',	'Manual (Trial Leader)',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'MilestoneType' AND Code = 'System') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'MilestoneType',	'System',	'System',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'StudyPhase' AND Code = 'Closeout') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'StudyPhase',	'Closeout',	'Closeout',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Milestone' AND ColumnName = 'StudyPhase' AND Code = 'Tracking') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Milestone',	'StudyPhase',	'Tracking',	'Tracking',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Submission' AND ColumnName = 'SubmissionType' AND Code = 'LOI') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Submission',	'SubmissionType',	'LOI',	'LOI',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Submission' AND ColumnName = 'SubmissionType' AND Code = 'Concept') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Submission',	'SubmissionType',	'Concept',	'Concepts',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Submission' AND ColumnName = 'SubmissionType' AND Code = 'MACSConcept') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Submission',	'SubmissionType',	'MACSConcept',	'MACSConcept',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'Submission' AND ColumnName = 'SubmissionType' AND Code = 'Protocol') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('Submission',	'SubmissionType',	'MACSConcept',	'MACSConcept',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'ICFReview' AND Code = 'Draft') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'ICFReview',	'Draft',	'Draft',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'ICFReview' AND Code = 'Full Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'ICFReview',	'Full Review',	'Full Review',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'ICFReview' AND Code = 'No Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'ICFReview',	'No Review',	'No Review',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentStatus' AND Code = 'Complete') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentStatus',	'Terminated',	'Terminated',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentStatus' AND Code = 'In Review') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentStatus',	'In Review',	'In Review',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentStatus' AND Code = 'Rejected') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentStatus',	'Rejected',	'Rejected',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentStatus' AND Code = 'Submitted') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentStatus',	'Submitted',	'Submitted',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentStatus' AND Code = 'Terminated') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentStatus',	'Terminated',	'Terminated',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentType' AND Code = 'Administrative') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentType',	'Administrative',	'Administrative',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'AmendmentType' AND Code = 'Substantive') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'AmendmentType',	'Substantive',	'Substantive',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'ConversionStatus' AND Code = 'Complete') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'ConversionStatus',	'Complete',	'Complete',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'ConversionStatus' AND Code = 'Pending') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'ConversionStatus',	'Pending',	'Pending',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'SAEFrequency' AND Code = 'Annual') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'SAEFrequency',	'Annual',	'Annual',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'SAEFrequency' AND Code = 'Quarterly') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'SAEFrequency',	'Quarterly',	'Quarterly',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

IF 0 = (SELECT COUNT(1) FROM SysCodeValues WHERE TableName = 'IISAdmindetails' AND ColumnName = 'SAEFrequency' AND Code = 'Biannually') 
	BEGIN
		INSERT INTO SysCodeValues (TableName, ColumnName, Code, Description, SortOrder, IsActive, IsDeleted, ANJU_AddedBy, ANJU_AddDate, ANJU_ChangedBy, ANJU_ChangeDate) VALUES ('IISAdmindetails',	'SAEFrequency',	'Biannually',	'Biannually',	NULL,	1,	0	,'SYSTEM',	GETDATE(),'SYSTEM',	GETDATE())
	END;
GO

update SysCodeValues set IsActive = 0, IsDeleted = 1 where Code = 'Amend Protocol/budget' And ColumnName = 'MaintainanceAndMonitoring'
 


---DefaultMileStones Table enteries

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Submission Approval' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Submission Approval',0,0,'Tracking','System populates completion date with the Global MRC meeting / approval date entered on the task form. This will happen with either the decision "Approved" or "Conditionally Approved".',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Create / Deliver Approval Letter' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Create / Deliver Approval Letter',15,1,'Tracking','System populates completion date when “Deliver Approval Letter” Task complete.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Draft Protocol' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Draft Protocol',60,2,'Tracking','System populates completion date when PI completes protocol submission task',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO
IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Final Protocol' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Final Protocol',45,3,'Tracking','System populates completion date when final protocol review task is completed (this indicates Company approval to submit protocol to IRB)',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Contract Execution Date' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Contract Execution Date',120,4,'Tracking','System populates completion date when "Upload Fully Executed Contract" task is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Activation (Drug Shipment)' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Activation (Drug Shipment)',15,5,'Tracking','System populates with the date of activation set in the activation letter task form.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'First Patient First Visit - the date the first patient received study drug' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','First Patient First Visit - the date the first patient received study drug',30,6,'Tracking','System populates with the FPFV date entered on the first "Patient Accrual" update where the number of subjects is at least 1.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Enrollment' AND MilestoneName = 'Last Patient First Visit - Enrollment Complete' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Enrollment','Last Patient First Visit - Enrollment Complete',100,7,'Tracking','System populates with the LPFV date entered on the Patient Accrual task form where the Enrollment Complete box is checked.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Last Patient Last Treatment -- the date the last patient receives their last dose of study drug' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Last Patient Last Treatment -- the date the last patient receives their last dose of study drug',180,8,'Tracking','System populates with the LPLT date entered on the "Patient Accrual" update. 30 days following this date, the SAE Reporting Confirmation task should be created for the PI.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO
IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'Last Patient Last Visit (LPLV)' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','Last Patient Last Visit (LPLV)',180,9,'Tracking','System populates with the LPLV date entered on the final "Patient Accrual" update. By recording this task, the Study Closeout Phase will be initiated."Closeout Letter" gets sent to PI.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO
IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'System' AND MilestoneName = 'SAE Final Reconciliation Report Confirmation' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('System','SAE Final Reconciliation Report Confirmation',30,10,'Tracking','System populates completion date when "Serious Adverse Events Reporting Confirmation" task is completed by Investigator.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO
IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Document' AND MilestoneName = 'Final Study Data / Report' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Document','Final Study Data / Report',350,11,'Closeout','"Final Study Data/Manuscript" action item remains on the PI''s list until the action is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Manual (Trial Leader)' AND MilestoneName = 'TPSR Reconciliation' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Manual (Trial Leader)','TPSR Reconciliation',360,11,'Closeout','TPSR Reconciliation action item remains in the Trial Leader''s list until the action is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO
IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Manual (Trial Leader)' AND MilestoneName = 'Drug Reconciliation' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Manual (Trial Leader)','Drug Reconciliation',360,11,'Closeout','Drug Reconciliation action item remains in the Trial Leader''s list until the action is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Manual (Trial Leader)' AND MilestoneName = 'Budget Reconciliation' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Manual (Trial Leader)','Budget Reconciliation',360,11,'Closeout','Budget Reconciliation action item remains in the Trial Leader''s list until the action is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

IF 0 = (SELECT COUNT(1) FROM DefaultMileStone WHERE MilestoneType = 'Manual (Trial Leader)' AND MilestoneName = 'PO Closeout Requested' ) 
BEGIN
	INSERT INTO [dbo].[DefaultMileStone]([MilestoneType],[MilestoneName],[BusinessDays],[Dependency],[StudyPhase],[Comments],[IsActive],[IsDeleted],[ANJU_AddedBy],[ANJU_AddDate],[ANJU_ChangedBy],[ANJU_ChangeDate])VALUES('Manual (Trial Leader)','PO Closeout Requested',360,11,'Closeout','PO Closeout Requested action item remains in the Trial Leader''s list until the action is completed.',1,0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

GO

---Global Settings-starts


IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'External Users Help Page') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'External Users Help Page', N'Click here edit in a separate page', NULL, 1, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Internal Users Help Page') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Internal Users Help Page', N'Click here edit in a separate page', NULL, 2, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'EMAIL_DEFAULT_POSTBOX') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'EMAIL_DEFAULT_POSTBOX', N'insite.help@novartis.com', N'This constant contains default PB.', 3, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'ENABLE_BUSINESS_DAY_CALCULATION') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'ENABLE_BUSINESS_DAY_CALCULATION', N'false', N'This constant is used to determine whether batch processes utilize business days or calendar days as basis for calculations.', 4, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'FDA_Link') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'FDA_Link', N'http://www.fda.gov/Drugs/DevelopmentApprovalProcess/HowDrugsareDevelopedandApproved/ApprovalApplications/InvestigationalNewDrugINDApplication/default.htm', N'This constant is used in submission wizards where FD link is shown to the user. If you would want to change the link in the submission wizard, you would have to change in this place and it would get reflected in the submission wizards automatically. Only valid and full web address MUST BE entered.', 5, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Holiday Date List') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Holiday Date List', NULL,'This constant contains a comma separated list of dates for business holidays in Global Constant DATE_FORMAT format.', 6, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'InvalidLoginAttemptsToDisableUser') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'InvalidLoginAttemptsToDisableUser', N'5', N'Used for disable user account after N unsuccessful login attemtps.', 7, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'LOGIN_PAGE_CONTENT') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'LOGIN_PAGE_CONTENT', N'Anjus US Oncology is committed to discovering innovative new therapies, collaborating to advance science and improving patient care.$$The mission and purpose of the Anjus IIT Program is to provide support for investigator-initiated oncology research that advances scientific knowledge and improve patient outcomes for marketed products and investigational agents.$$Begin by registering as a new user and create your in.site account.', N'This constant is used by the application to display login page content', 8, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'MTC_ENABLE_ESTIMATION_DATE_CALCULATION') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'MTC_ENABLE_ESTIMATION_DATE_CALCULATION', N'True', N'If the value of this constant is True, System calculates Estimated completion date for milestones . If the constant is set to False, dont calculates Estimated completion date.', 9, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'MTC_ENABLE_REALTIME_EDC') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'MTC_ENABLE_REALTIME_EDC', N'True', N'If the value of this constant is True, System re calculates estimated completion dates for milestones. If the constant is set to False, estimated completion date will not re calculated.', 10, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Num_Of_Site') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Num_Of_Site', N'1000', N'This constant is used by the application to set the maximum number of sites that could be entered by the user in the submission wizard, "Scientific Rationale II" section. Enter a Whole Number ONLY.', 11, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'PRIVACY_POLICY_URL') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'PRIVACY_POLICY_URL', N'https://www.pharma.us.novartis.com/hcp-privacy-policy', N'to configure the URL used to display the appropriate Usage Privacy Policy', 12, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER', N'10',N'This constant is used by the application to remember previous passwords set by user', 13, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SEC_PASSWORD_EXPIRATION_DAYS') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SEC_PASSWORD_EXPIRATION_DAYS', N'90', N'	This constant is used to represent the number of days which password should expire in OPENIIS.if you want to change days which password should expire change it to a positive integer', 14, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SMTP_PASSWORD') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SMTP_PASSWORD', NULL, N'This constant is used by the application to set the SMTP server password', 15, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SMTP_PORT') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SMTP_PORT', N'2525', N'This constant is used by the application to set the SMTP server port', 16, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SMTP_SERVER_NAME') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SMTP_SERVER_NAME', N'107.22.164.99', N'This constant is used by the application to set the SMTP server name', 17, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SMTP_TLS_SECURITY') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SMTP_TLS_SECURITY', N'No', N'This constant is used by the application to set the SMTP Transport Layer Security, this should be YES or NO', 18, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'SMTP_USERNAME') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'SMTP_USERNAME', NULL, N'This constant is used by the application to set the SMTP server username', 19, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'USAGE_TERMS_URL') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'USAGE_TERMS_URL', N'https://www.pharma.us.novartis.com/terms-use', N'to configure the URL used to display the appropriate Usage Terms', 20, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'app_name') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'app_name', N'[Company]', N'This constant is used by application to set application name', 21, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Mail.From') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Mail.From', N'insite.administrator@novartis.com', N'FROM Email address.', 22, 1, 0, N'SYSTEM', GETDATE(), N'SYSTEM', GETDATE())
END;

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'BannerUpload') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'BannerUpload', N'Banner Upload', NULL, 23, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'BackgroundUpload') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'BackgroundUpload', N'Background Upload', NULL, 24, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'VerbiageForNewUser') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'VerbiageForNewUser', N'(For Non-Novartis users only)', NULL, 25, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'EnforcePasswordLength') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'EnforcePasswordLength', N'2', NULL, 26, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'EnforceOneUpperandOneLowerCaseCharacter') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'EnforceOneUpperandOneLowerCaseCharacter', N'True', NULL, 27, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'EnforceOneNumber') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'EnforceOneNumber', N'True',NULL, 28, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'EnforceSpecialChar') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'EnforceSpecialChar', N'True',NULL, 29, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'PasswordResetExpiryDate') 
	BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'PasswordResetExpiryDate', N'28-05-2019',NULL, 30, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Activation_Reminder_Conf') 
BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Activation_Reminder_Conf', N'Activation,30,{3483,3486}','This constant contains 1. Activation Milestone Type Name, 2. No. of biz days remaining for the expected completion date of the milestone on which reminder is sent and 3. Comma separated list of roles enclosed in braces {}. Users for these roles will recieve the Activation reminder.', 31, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Document_Reminder_Conf') 
BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Document_Reminder_Conf', N'Document,30,{3483,3486}','This constant contains 1. Document Milestone Type Name, 2. No. of biz days remaining for the expected completion date of the milestone on which reminder is sent. 3. Comma separated list of roles enclosed in braces {}. Users for these roles will recieve the Document reminder.', 32, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

IF 0 = (SELECT COUNT(1) FROM GlobalSettings WHERE GlobalKey = 'Enrollment_Reminder_Conf') 
BEGIN
INSERT [dbo].[GlobalSettings] ([GlobalKey], [GlobalValue], [Remarks], [SortOrder], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES (N'Enrollment_Reminder_Conf', N' Enrollment,30,{3483,3486}','This constant contains 1. Enrollment Milestone Type Name, 2. No. of biz days remaining for the expected completion date of the milestone on which reminder is sent and 3. Comma separated list of roles enclosed in braces {}. Users for these roles will recieve the Enrollment reminder.', 33, 1, 0,'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
END;
GO

---Global Settings-ends

-----------------------------------------------------------------------------------------------------------------------------------------------
--Edit Study Attributes
-----------------------------------------------------------------------------------------------------------------------------------------------
--SET IDENTITY_INSERT EditStudyAttributes OFF

SET IDENTITY_INSERT [dbo].[EditStudyAttributes] OFF 

GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Disease States', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 10101, N'Disease States we', N'DiseaseStates', N'Disease States', N'Disease States', N'Tab', NULL, NULL, NULL, 1, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Science Main', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 10100, N'Science Main', N'ScienceMain', N'Science Main', NULL, N'Tab', NULL, N'Large', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Scientific Rationale', 1, N'IIS', 101, N'Scientific Rationale', 101, N'Scientific Rationale', 101, N'Scientific Rationale', N'Scientific Rationale', N'Scientific Rationale', NULL, N'Parent Tab', NULL, N'Large', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Title of Study', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010001, N'Title of Study', N'Title of Study', N'StudyTitle', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Descriptors', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010002, N'Study Descriptors', N'Study Descriptors', N'StudyDescriptors', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Maximum Age', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010004, N'Maximum Age', N'Maximum Age', N'MaximumAge', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Exclusion Criteria', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010005, N'Exclusion Criteria', N'Exclusion Criteria', N'ExclusionCriteria', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Clinical Pharmacology', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010006, N'Clinical Pharmacology', N'Clinical Pharmacology', N'ClinicalPharmacology', NULL, N'Text', NULL, N'Small', 0, 1, 1, 6, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Intervention Status', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010007, N'Intervention Status', N'Intervention Status', N'InterventionStatus', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Indication', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010008, N'Indication', N'Indication', N'Indicationforsciencemain', NULL, N'Text', NULL, N'Large', 0, 1, 1, 8, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Placebo Controlled', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010009, N'Placebo Controlled', N'Placebo Controlled', N'PlaceboControlled', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Patient Type', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010010, N'Patient Type', N'Patient Type', N'PatientType', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Safety Criteria', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010011, N'Safety Criteria', N'Safety Criteria', N'SafetyCriteria', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 1, 10, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Compound', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010012, N'Other Compound', N'Other Compound', N'OtherCompound', NULL, N'Text', NULL, N'Large', 0, 1, 1, 11, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Phase', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010013, N'Study Phase', N'Study Phase', N'StudyPhase', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phase I', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010014, N'Phase I', N'Phase I', N'PhaseI', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0,'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phase II', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010015, N'Phase II', N'Phase II', N'PhaseII', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 14, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phase III', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010016, N'Phase III', N'Phase III', N'PhaseIII', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phase IV', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010017, N'Phase IV', N'Phase IV', N'PhaseIV', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 16, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Rationale for Study', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010018, N'Rationale for Study', N'Rationale for Study', N'RationaleforStudy', NULL, N'Text Area (Rich)', NULL, N'Small', 0, 1, 1, 17, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Design', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010019, N'Study Design', N'Study Design', N'StudyDesign', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 1, 18, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Minimum Age', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010020, N'Minimum Age', N'Minimum Age', N'MinimumAge', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 19, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Inclusion Criteria', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010021, N'Inclusion Criteria', N'Inclusion Criteria', N'Inclusioncriteria', NULL, N'Text', NULL, N'Large', 0, 1, 1, 21, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Basis for Sample Size', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010022, N'Basis for Sample Size', N'Basis for Sample Size', N'Basisforsamplesize', NULL, N'Text', NULL, N'Large', 0, 1, 1, 22, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('How many Treatment Arms apply for this trial', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010023, N'How many Treatment Arms apply for this trial', N'How many Treatment Arms apply for this trial', N'HowmanyTreatmentArmsapplyforthistrial', NULL, N'Text', NULL, N'Small', 0, 1, 1, 23, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Gender', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010024, N'Gender', N'Gender', N'Gender', NULL, N'Multi-Select', NULL, N'Small', 0, 1, 1, 24, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Patient Population', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1010025, N'Patient Population', N'Patient Population', N'PatientPopulation', NULL, N'Text', NULL, N'Large', 0, 1, 1, 25, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Franchise', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010101, N'Franchise', N'Franchise', N'Franchise', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Randomized', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010102, N'Randomized', N'Randomized', N'Randomized', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Blinding', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010103, N'Blinding', N'Blinding', N'Blinding', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Genomic Profile', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010104, N'Genomic Profile', N'Genomic Profile', N'GenomicProfile', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Structure', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010105, N'Structure', N'Structure', N'Structure', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Line Of Therapy', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010106, N'Line Of Therapy', N'Line Of Therapy', N'LineOfTherapy', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Disease', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010107, N'Disease', N'Disease', N'Disease', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Disease for patient population', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010108, N'Disease for patient population', N'Diseaseforpatientpopulation', N'Diseaseforpatientpopulation', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Stage', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010109, N'Stage', N'Stage', N'Stage', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Treatment Segment', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010110, N'Treatment Segment', N'Treatment Segment', N'Treatmentsegment', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Quality of Life', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010111, N'Quality of Life', N'Quality of Life', N'QualityofLife', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Will this study include Correlative Science (Y/N)', 1, N'IIS', 101, N'Scientific Rationale', 10104, N'Correlative Science', 1010201, N'Will this study include Correlative Science (Y/N)', N'Will this study include Correlative Science (Y/N)', N'Isstudyincludecorrelativescience', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Biomarker / Correlative Science Sampling Details', 1, N'IIS', 101, N'Scientific Rationale', 10104, N'Correlative Science', 1010202, N'Biomarker / Correlative Science Sampling Details', N'Biomarker / Correlative Science Sampling Details', N'Correlativesciencesamplingdetails', NULL, N'Text', NULL, N'Large', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Biomarker / Correlative Science Sampling Details', 1, N'IIS', 101, N'Scientific Rationale', 10104, N'Correlative Science', 1010203, N'Biomarker / Correlative Science Sampling Details', N'Biomarker / Correlative Science Studies performed at [Company] Site', N'Correlativesciencestudiesperformedatcompanysite', NULL, N'Text', NULL, N'Large', 0, 1, 1, 3, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Biomarker / Correlative Science Studies performed at Study Site(s)', 1, N'IIS', 101, N'Scientific Rationale', 10104, N'Correlative Science', 1010204, N'Biomarker / Correlative Science Studies performed at Study Site(s)', N'Biomarker / Correlative Science Studies performed at Study Site(s)', N'Correlativesciencestudiesperformedatstudysite', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Risk Factors', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010113, N'Risk Factors', N'Risk Factors', N'RiskFactors', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Line of Treatment', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010112, N'Line of Treatment', N'Line of Treatment', N'Lineoftreatment', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Interventional trial - Data Collection', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010801, N'Interventional trial - Data Collection', N'Interventional trial - Data Collection', N'Datacollectioninterventional', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('All reports describing the occurrence of other special scenarios', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010802, N'All reports describing the occurrence of other special scenarios', N'Occurrenceofotherspecialscenarios', N'Occurrenceofotherspecialscenarios', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 21, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Specify what safety data (if any) will be collected', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010803, N'Specify what safety data (if any) will be collected', N'Specify what safety data (if any) will be collected', N'Safetydata', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Adverse events exempt from collection', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010804, N'Adverse events exempt from collection', N'Adverse events exempt from collection', N'Adverseevents', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('All non-serious AEs', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010805, N'All non-serious AEs', N'All non-serious AEs', N'Allnonseriousaes', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Compound Type', 1, N'IIS', 101, N'Scientific Rationale', 10105, N'Study Compounds', 1010501, N'Compound Type', N'Compoundtype', N'Compoundtype', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('[Company] Compound', 1, N'IIS', 101, N'Scientific Rationale', 10105, N'Study Compounds', 1010502, N'[Company] Compound', N'[Company] Compound', N'DrugorCompoundPrimary', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Non [Company] Compound', 1, N'IIS', 101, N'Scientific Rationale', 10105, N'Study Compounds', 1010503, N'Non [Company] Compound', N'Non [Company] Compound', N'Noncompanycompound', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Compound Category', 1, N'IIS', 101, N'Scientific Rationale', 10105, N'Study Compounds', 1010504, N'Compound Category', N'Compound Category', N'DrugorCompoundSecondaryType', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('No.of patients', 1, N'IIS', 101, N'Scientific Rationale', 10102, N'Cohort Levels', 1010201, N'No.of patients', N'No.of patients', N'Noofpatients', NULL, N'Number', NULL, N'Large', 0, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Cohort Level', 1, N'IIS', 101, N'Scientific Rationale', 10102, N'Cohort Levels', 1010202, N'Cohort Level', N'Cohort Level', N'Cohortlevel', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Drug A dose and freq', 1, N'IIS', 101, N'Scientific Rationale', 10102, N'Cohort Levels', 1010203, N'Drug A dose and freq', N'Drug A dose and freq', N'drugAdoseandfreq', NULL, N'Text', NULL, N'Large', 0, 1, 1, 3, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Drug B dose and freq', 1, N'IIS', 101, N'Scientific Rationale', 10102, N'Cohort Levels', 1010204, N'Drug B dose and freq', N'Drug B dose and freq', N'drugBdoseandfreq', NULL, N'Text', NULL, N'Large', 0, 1, 1, 1, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study start(FPFV)', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010900, N'Study start(FPFV)', N'Study start(FPFV)', N'Studystart', NULL, N'Date', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Total No. of Patients', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010901, N'Total No. of Patients', N'Total No. of Patients', N'Totalnoofpatients', NULL, N'Number', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Duration', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010902, N'Study Duration', N'Study Duration', N'Studyduration', NULL, N'Text', NULL, N'Large', 0, 1, 1, 3, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Are there competing studies AT your institution?', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010903, N'Are there competing studies AT your institution?', N'Are there competing studies AT your institution?', N'Iscompetingstudiesatyourinstitution', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('How will these studies impact patient accrual for the proposed study?', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010904, N'How will these studies impact patient accrual for the proposed study?', N'How will these studies impact patient accrual for the proposed study?', N'Impactpatientaccrualfortheproposedstudy', NULL, N'Text', NULL, N'Large', 0, 1, 1, 5, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Recruitment End (LPFV)', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010905, N'Recruitment End (LPFV)', N'Recruitment End (LPFV)', N'RecruitmentEnd', NULL, N'Date', NULL, N'Large', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Completion of Final Study Report', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010906, N'Completion of Final Study Report', N'Completion of Final Study Report', N'CompletionofFinalStudyReport', NULL, N'Date', NULL, N'Large', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Trial End (Last Patient Last Visit)', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010907, N'Trial End (Last Patient Last Visit)', N'Trial End (Last Patient Last Visit)', N'TrialEnd', NULL, N'Date', NULL, N'Large', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('No. of Patients per treatment group', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010908, N'No. of Patients per treatment group', N'No. of Patients per treatment group', N'NoofPatientsperTreatmentGroup', NULL, N'Text', NULL, N'Large', 0, 1, 1, 9, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Enrollment History for Other Related Studies', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010909, N'Enrollment History for Other Related Studies', N'Enrollment History for Other Related Studies', N'EnrollmentHistoryforOtherRelatedStudies', NULL, N'Text', NULL, N'Large', 0, 1, 1, 10, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Primary Publication Date', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010910, N'Primary Publication Date', N'Primary Publication Date', N'PrimaryPublicationDate', NULL, N'Date', NULL, N'Large', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IRB Registration Requirement', 1, N'IIS', 101, N'Scientific Rationale', 10110, N'IRB Requirement', 1011001, N'IRB Registration Requirement', N'IRB Registration Requirement', N'IsIRBRegistrationRequirement', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Safety Monitoring Interval - Follows visit Design', 1, N'IIS', 101, N'Scientific Rationale', 10111, N'Pandemic Preparedness Trial Categorization', 1011102, N'Safety Monitoring Interval - Follows visit Design', N'Safety Monitoring Interval - Follows visit Design', N'IsSafetyMonitoringInterval', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Maximum allowable time between visits (in weeks)', 1, N'IIS', 101, N'Scientific Rationale', 10111, N'Pandemic Preparedness Trial Categorization', 1011103, N'Maximum allowable time between visits (in weeks)', N'Maximum allowable time between visits (in weeks)', N'Maximumallowabletimebetweenvisits', NULL, N'Text', NULL, N'Large', 0, 1, 1, 3, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Do you plan to submit an IND for the proposed study?', 1, N'IIS', 101, N'Scientific Rationale', 10112, N'Regulatory Requirements', 1011201, N'Do you plan to submit an IND for the proposed study?', N'Do you plan to submit an IND for the proposed study?', N'IssubmitanINDfortheproposedstudy', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Rationale for IND Exemption', 1, N'IIS', 101, N'Scientific Rationale', 10112, N'Regulatory Requirements', 1011202, N'Rationale for IND Exemption', N'Rationale for IND Exemption', N'RationaleforINDExemption', NULL, N'Text', NULL, N'Large', 0, 1, 1, 2, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Final IND Status', 1, N'IIS', 101, N'Scientific Rationale', 10112, N'Regulatory Requirements', 1011203, N'Final IND Status', N'Final IND Status', N'FinalINDStatus', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IND Number', 1, N'IIS', 101, N'Scientific Rationale', 10112, N'Regulatory Requirements', 1011204, N'IND Number', N'IND Number', N'INDNumber', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contact Type', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040002, N'Contact Type', N'Contact Type', N'Contacttype', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contact Type Details', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040001, N'Contact Type Details', N'Contact Type Details', N'Contacttypedetails', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Tax ID', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040003, N'Tax ID', N'Tax ID', N'TaxID', NULL, N'Text', NULL, N'Small', 0, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Salutation', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040004, N'Salutation', N'Salutation', N'Salutation', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('First Name', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040005, N'First Name', N'First Name', N'Firstname', NULL, N'Text', NULL, N'Small', 0, 1, 1, 6, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Last Name', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040006, N'Last Name', N'Last Name', N'Lastname', NULL, N'Text', NULL, N'Small', 0, 1, 1, 7, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Suffix', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040007, N'Suffix', N'Suffix', N'Suffix', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Title', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040008, N'Title', N'Title', N'Title', NULL, N'Text', NULL, N'Small', 0, 1, 1, 9, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Credentials', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040009, N'Credentials', N'Credentials', N'Credentials', NULL, N'Multi-Select', NULL, N'Large', 0, 1, 1, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Institution', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040010, N'Institution', N'PIInstitution', N'PIInstitution', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('First Address', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040011, N'First Address', N'Address Line 1', N'Address1', NULL, N'Text', NULL, N'Large', 0, 1, 1, 12, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Address Line 2', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040012, N'Address Line 2', N'Address Line 2', N'Address2', NULL, N'Text', NULL, N'Large', 0, 1, 1, 13, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Address Line 3', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040013, N'Address Line 3', N'Address Line 3', N'Address3', NULL, N'Text', NULL, N'Large', 0, 1, 1, 14, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('City', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040014, N'City', N'City', N'City', NULL, N'Text', NULL, N'Large', 0, 1, 1, 16, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('State', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040015, N'State', N'State', N'State', NULL, N'Text', NULL, N'Small', 0, 1, 1, 19, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Postal code', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040016, N'Postal code', N'Postalcode', N'Postalcode', NULL, N'Text', NULL, N'Small', 0, 1, 1, 18, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Country', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040017, N'Country', N'Country', N'Country', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 17, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phone', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040018, N'Phone', N'Phone', N'Phone', NULL, N'Text', NULL, N'Small', 0, 1, 1, 20, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Fax', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040019, N'Fax', N'Fax', N'Fax', NULL, N'Text', NULL, N'Small', 0, 1, 1, 21, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Email', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040020, N'Email', N'Email', N'Email', NULL, N'Text', NULL, N'Small', 0, 1, 1, 22, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('NPI#', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040021, N'NPI#', N'NPI', N'NPI', NULL, N'Text', NULL, N'Small', 0, 1, 1, 23, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Region', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040022, N'Region', N'Region', N'Region', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Randomization', 1, N'IIS', 101, N'Scientific Rationale', 10101, N'Disease States', 1010109, N'Randomization', N'Randomization', N'Randomized', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Indication Type', 1, N'IIS', 101, N'Scientific Rationale', 10106, N'Indications', 1010601, N'Indication Type', N'Indication Type', N'IndicationType', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Indication', 1, N'IIS', 101, N'Scientific Rationale', 10106, N'Indications', 1010602, N'Indication', N'Indication', N'Indication', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Enrollment Rate (Pts/Month)', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 1010911, N'Enrollment Rate (Pts/Month)', N'Enrollment rate', N'Enrollmentrate', NULL, N'Number', NULL, N'Small', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Medical Specialty', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040101, N'Medical Specialty', N'Medical Specialty', N'Medicalspecialty', NULL, N'Number', NULL, N'Large', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Board Certification', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040102, N'Board Certification', N'Board Certification', N'BoardCertification', NULL, N'Text', NULL, N'Large', 0, 1, 1, 2, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('License or Equivalent', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040103, N'License or Equivalent', N'License or Equivalent', N'LicenseorEquivalent', NULL, N'Text', NULL, N'Large', 0, 1, 1, 3, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Have you received GCP training the past 3 years?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040104, N'Have you received GCP training the past 3 years?', N'Have you received GCP training the past 3 years?', N'IsreceivedGCPtrainingthepast3years', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('When was your last GCP training?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040105, N'When was your last GCP training?', N'When was your last GCP training?', N'LastGCPtraining', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Type of Training received', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040106, N'Type of Training received', N'Type of Training received', N'Typeoftrainingreceived', NULL, N'Text', NULL, N'Small', 0, 1, 1, 6, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('List trial experience', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040107, N'List trial experience', N'List trial experience', N'Listtrialexperience', NULL, N'Text', NULL, N'Small', 0, 1, 1, 7, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('participated in a [Company] trial?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040108, N'participated in a [Company] trial?', N'participated in a [Company] trial?', N'Isparticipatedinacompanytrial', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Dates of Trial Participation', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040109, N'Dates of Trial Participation', N'Dates of Trial Participation', N'Datesoftrialparticipation', NULL, N'Text', NULL, N'Small', 0, 1, 1, 9, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Drug names', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040110, N'Drug names', N'Drug names', N'Drugnames', NULL, N'Text', NULL, N'Small', 0, 1, 1, 10, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Protocol numbers', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040111, N'Protocol numbers', N'Protocol numbers', N'Protocolnumbers', NULL, N'Text', NULL, N'Small', 0, 1, 1, 11, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Number of ongoing clinical trials', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040112, N'Number of ongoing clinical trials', N'Number of ongoing clinical trials', N'Noofongoingclinicaltrials', NULL, N'Text', NULL, N'Small', 0, 1, 1, 12, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Have you or your site been inspected by a Health Authority, IRB/EC?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040113, N'Have you or your site been inspected by a Health Authority, IRB/EC?', N'Have you or your site been inspected by a Health Authority, IRB/EC?', N'Isinspectedbyahealthauthority', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Which health authority', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040114, N'Which health authority', N'Which health authority', N'Whichhealthauthority', NULL, N'Text', NULL, N'Small', 0, 1, 1, 14, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Date of last inspection', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040115, N'Date of last inspection', N'Date of last inspection', N'Dateoflastinspection', NULL, N'Date', NULL, N'Large', 0, 1, 1, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Have you or your site been inspected by the FDA?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040116, N'Have you or your site been inspected by the FDA?', N'Have you or your site been inspected by the FDA?', N'IsinspectedbytheFDA', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 16, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Date of FDA inspection', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040117, N'Date of FDA inspection', N'Date of FDA inspection', N'Dateoffdainspection', NULL, N'Date', NULL, N'Large', 0, 1, 1, 17, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Did the FDA issue a FDA483 form?', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040118, N'Did the FDA issue a FDA483 form?', N'Did the FDA issue a FDA483 form?', N'IsFDAissueaFDA483form', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 18, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Details of the main observations', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 1040119, N'Details of the main observations', N'Details of the main observations', N'Detailsofthemainobservations', NULL, N'Dropdown', NULL, N'Large', 0, 1, 0, 19, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Occurrence of other special scenarios', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1010807, N'Occurrence of other special scenarios', N'Occurrence of other special scenarios', N'Occurrenceofotherspecialscenarios', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 15, 39, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Cohort Levels', 1, N'IIS', 101, N'Scientific Rationale', 10102, N'Cohort Levels', 10102, N'Cohort Levels', N'Cohort Levels', N'Cohort Levels', NULL, N'Tab', NULL, N'Large', 0, 1, NULL, 3, 43, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contacts', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 10400, N'Contacts', N'Contacts', N'Contacts', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Correlative Science', 1, N'IIS', 101, N'Scientific Rationale', 10104, N'Correlative Science', 10104, N'Correlative Science', N'Correlative Science', N'Correlative Science', NULL, N'Tab', NULL, N'Large', 0, 1, 0, 5, 334, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Indications', 1, N'IIS', 101, N'Scientific Rationale', 10106, N'Indications', 10106, N'Indications', N'Indications', N'Indicationtab', NULL, N'Tab', NULL, NULL, 0, 1, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Investigator Qualifications', 1, N'IIS', 104, N'Personnel Sites & Support', 10401, N'Investigator Qualifications', 10401, N'Investigator Qualifications', N'Investigator Qualifications', N'Investigator Qualifications', NULL, N'Tab', NULL, N'Large', 0, 1, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IRB Requirement', 1, N'IIS', 101, N'Scientific Rationale', 10110, N'IRB Requirement', 10110, N'IRB Requirement', N'IRB Requirement', N'IRB Requirement', NULL, N'Tab', NULL, NULL, 0, 1, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Pandemic Preparedness Trial Categorization', 1, N'IIS', 101, N'Scientific Rationale', 10111, N'Pandemic Preparedness Trial Categorization', 10111, N'Pandemic Preparedness Trial Categorization', N'Pandemic Preparedness Trial Categorization', N'Pandemic Preparedness Trial Categorization', NULL, N'Tab', NULL, N'Large', 0, 1, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Pharmacovigilance', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 10108, N'Pharmacovigilance', N'Pharmacovigilance', N'Pharmacovigilance', NULL, N'Tab', NULL, N'Large', 0, 1, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Regulatory Requirements', 1, N'IIS', 101, N'Scientific Rationale', 10112, N'Regulatory Requirements', 10112, N'Regulatory Requirements', N'Regulatory Requirements', N'Regulatory Requirements', NULL, N'Tab', NULL, N'Large', 0, 1, NULL, 13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Sites', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 10402, N'Sites', N'Sites', N'Sites', NULL, N'Tab', NULL, N'', 0, 1, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Compounds', 1, N'IIS', 101, N'Scientific Rationale', 10105, N'Study Compounds', 10105, N'Study Compounds', N'Study Compounds', N'Study Compounds', NULL, N'Tab', NULL, NULL, 0, 1, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Enrollment & Timelines', 1, N'IIS', 101, N'Scientific Rationale', 10109, N'Study Enrollment & Timelines', 10109, N'Study Enrollment & Timelines', N'Study Enrollment & Timelines', N'Study Enrollment and Timelines', NULL, N'Tab', NULL, NULL, 0, 1, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Pandemic Preparedness Trial Categorization', 1, N'IIS', 101, N'Scientific Rationale', 10111, N'Pandemic Preparedness Trial Categorization', 1011101, N'Pandemic Preparedness Trial Categorization', N'Pandemic Preparedness Trial Categorization', N'PandemicPreparednessTrialCategorization', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Key references', 1, N'IIS', 101, N'Scientific Rationale', 10114, N'Key references', 10114, N'Key references', N'Key references', N'Keyreferencestab', NULL, N'Tab', NULL, N'Large', 0, 1, 0, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IIS', 1, N'IIS', 1, N'IIS', 1, N'IIS', 1, N'IIS', N'IIS', N'IIS', N'IIS', N'GrandParent Tab', NULL, N'Large', 0, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', NULL, NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Objectives', 1, N'IIS', 101, N'Scientific Rationale', 10403, N'Objectives', 10403, N'Objectives', N'Objectives', N'Objectives', NULL, N'Tab', NULL, NULL, NULL, 1, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Objective Types', 1, N'IIS', 101, N'Scientific Rationale', 10403, N'Objectives', 1040202, N'Objective Types', N'Objective Types', N'Objectivetypes', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Objective Name', 1, N'IIS', 101, N'Scientific Rationale', 10403, N'Objectives', 1040203, N'Objective Name', N'Objective Name', N'Objectivenames', NULL, N'Dropdown', NULL, N'Large', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Objective Description', 1, N'IIS', 101, N'Scientific Rationale', 10403, N'Objectives', 1040204, N'Objective Description', N'Objective Description', N'Objectivedescription', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('End Point Description', 1, N'IIS', 101, N'Scientific Rationale', 10403, N'Objectives', 1040205, N'End Point Description', N'End Point Description', N'Endpointdescription', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study / Protocol Number(s)', 1, N'IIS', 101, N'Scientific Rationale', 10113, N'Study / Protocol Number(s)', 10113, N'Study / Protocol Number(s)', N'Study / Protocol Number(s)', N'StudyProtocolNumberstab', NULL, N'Tab', NULL, NULL, NULL, 1, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Organization', 1, N'IIS', 101, N'Scientific Rationale', 10113, N'Study / Protocol Number(s)', 1040206, N'Organization', N'Organization', N'Organization', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Site Index', 1, N'IIS', 104, N'Personnel Sites & Support', 10400, N'Contacts', 1040207, N'Site Index', N'Site Index', N'SiteIndex', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Site Institution Name', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 1040208, N'Site Institution Name', N'Site Institution Name', N'Siteinstitution', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Institution - Internal', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 1040209, N'Institution - Internal', N'Institution - Internal', N'InstitutionInternal', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Site Country', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 1040210, N'Site Country', N'Site Country', N'Country', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Drug Shipped to Site', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 1040211, N'Drug Shipped to Site', N'Drug Shipped to Site', N'IsDrugshippedtosite', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract direct with Site', 1, N'IIS', 104, N'Personnel Sites & Support', 10402, N'Sites', 1040212, N'Contract direct with Site', N'Contract direct with Site', N'IsContractdirectwithsite', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Personnel Sites & Support', 1, N'IIS', 104, N'Personnel Sites & Support', 104, N'Personnel Sites & Support', 104, N'Personnel Sites & Support', N'Personnel Sites & Support', N'Personnel Sites and Support', NULL, N'Parent Tab', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Research Group Description', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 10404, N'Research Group Description', N'Research Group Description', N'Researchgroupdescription', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Sponsor Name', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040213, N'Study Sponsor Name', N'Study Sponsor Name', N'StudySponsor', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study Drug Source', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040214, N'Study Drug Source', N'Study Drug Source', N'StudyDrugSource', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Cooperative Group Study?', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040215, N'Cooperative Group Study?', N'Cooperative Group Study?', N'IsCooperativeGroupStudy', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Cooperative Group Name', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040216, N'Cooperative Group Name', N'Cooperative Group Name', N'CooperativeGroupName', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Cooperative Group Name - Other', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040217, N'Cooperative Group Name - Other', N'Cooperative Group Name - Other', N'CooperativeGroupNameOther', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Physician Network Study?', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040218, N'Physician Network Study?', N'Physician Network Study?', N'IsPhysicianNetworkStudy', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Physician Network Name (s)', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040219, N'Physician Network Name (s)', N'Physician Network Name (s)', N'PhysicianNetworkNames', NULL, N'Multi-Select', NULL, N'Small', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Corporate Sponsorship?', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040220, N'Other Corporate Sponsorship?', N'Other Corporate Sponsorship?', N'IsOtherCorporateSponsorship', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Corporate Sponsor', 1, N'IIS', 104, N'Personnel Sites & Support', 10404, N'Research Group Description', 1040221, N'Other Corporate Sponsor', N'Other Corporate Sponsor', N'OtherCorporateSponsor', NULL, N'Text', NULL, N'Small', 0, 1, 1, 9, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Treatment Information', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 10405, N'Treatment Information', N'Treatment Information', N'Treatmentinformation', NULL, N'Tab', NULL, N'Small', 0, 1, 1, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Treatment arm', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040222, N'Treatment arm', N'Treatment arm', N'Treatmentarm', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('# of Pts Planned', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040223, N'# of Pts Planned', N'# of Pts Planned', N'Noofpatientsplanned', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Type of Study Drug', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040224, N'Type of Study Drug', N'Type of Study Drug', N'Typeoftrialdrug', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Compound  (specify brand or generic)', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040225, N'Compound  (specify brand or generic)', N'Compound  (specify brand or generic)', N'Compound', NULL, N'Text', NULL, N'Large', 0, 1, 1, 4, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Minimum Dose and Unit', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040226, N'Minimum Dose and Unit', N'Minimum Dose and Unit', N'Mindosage', NULL, N'Text', NULL, N'Large', 0, 1, 1, 5, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Maximum Dose and Unit', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040227, N'Maximum Dose and Unit', N'Maximum Dose and Unit', N'Maxdosage', NULL, N'Text', NULL, N'Small', 0, 1, 1, 6, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Frequency', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040228, N'Frequency', N'Frequency', N'Frequency', NULL, N'Text', NULL, N'Small', 0, 1, 1, 7, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Route of Administration', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040229, N'Route of Administration', N'Route of Administration', N'Adminroute', NULL, N'Text', NULL, N'Small', 0, 1, 1, 8, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Generic Acceptable', 1, N'IIS', 101, N'Scientific Rationale', 10405, N'Treatment Information', 1040230, N'Generic Acceptable', N'Generic Acceptable', N'Genericacceptable', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Non-Interventional trial - Data Collection', 1, N'IIS', 101, N'Scientific Rationale', 10108, N'Pharmacovigilance', 1040231, N'Non-Interventional trial - Data Collection', N'Non-Interventional trial - Data Collection', N'Datacollectionnoninterventional', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study / Protocol Number(s)', 1, N'IIS', 101, N'Scientific Rationale', 10113, N'Study / Protocol Number(s)', 1011301, N'Study / Protocol Number(s)', N'Study / Protocol Number(s)', N'StudyProtocolNumbers', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Key references', 1, N'IIS', 101, N'Scientific Rationale', 10114, N'Key references', 1011401, N'Key references', N'Key references', N'Keyreferences', NULL, N'Text Area (Rich)', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Original Financial Request', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 10406, N'Original Financial Request', N'Original Financial Request', N'Originalfinancialrequest', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Are you requesting a [Company] study compound', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040232, N'Are you requesting a [Company] study compound', N'Are you requesting a [Company] study compound', N'Isrequestingacompanystudycompound', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Are you requesting study funding?', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040233, N'Are you requesting study funding?', N'Are you requesting study funding', N'Isrequestingstudyfunding', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Will support be provided from other sources?', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040234, N'Will support be provided from other sources?', N'Will support be provided from other sources', N'Issupportbeprovidedfromothersources', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Support Description', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040235, N'Other Support Description', N'Other Support Description', N'Othersupportdescription', NULL, N'Text', NULL, N'Small', 0, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Will Government Support be Provided?', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040236, N'Will Government Support be Provided?', N'Will Government Support be Provided', N'Isgovernmentsupportbeprovided', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Original Requested Study Amount', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040237, N'Original Requested Study Amount', N'Original Requested Study Amount', N'Originalrequestedstudyamount', NULL, N'Number', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Government Support Description', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040238, N'Government Support Description', N'Government Support Description', N'Governmentsupportdescription', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 1, 7, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Are you requesting support from [Company] other than drug or funding?', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040239, N'Are you requesting support from [Company] other than drug or funding?', N'Are you requesting support from [Company] other than drug or funding?', N'Isrequestingsupportfromcompanyotherthandrugorfunding', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Non-[Company] Support Sources', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040240, N'Non-[Company] Support Sources', N'Non-[Company] Support Sources', N'Noncompanysupportsources', NULL, N'Text', NULL, N'Small', 0, 1, 1, 9, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Global Funding Requested', 1, N'IIS', 104, N'Personnel Sites & Support', 10406, N'Original Financial Request', 1040241, N'Global Funding Requested', N'Global Funding Requested', N'Globalfundingrequested', NULL, N'Number', NULL, N'Small', 0, 1, 1, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Investigational Drug and Reference Therapy', 1, N'IIS', 101, N'Scientific Rationale', 10100, N'Science Main', 1040242, N'Investigational Drug and Reference Therapy', N'Investigational Drug and Reference Therapy', N'Investigationaldrugandreferencetherapy', NULL, N'Text', NULL, N'Small', 0, 1, 1, 26, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Email List', 1, N'IIS', 104, N'Personnel Sites & Support', 10407, N'Email List', 10407, N'Email List', N'Email List', N'EmailList', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Recipient', 1, N'IIS', 104, N'Personnel Sites & Support', 10407, N'Email List', 1040243, N'Recipient', N'Recipient', N'Recipient', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, N'^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$', N'Please enter a valid email address', NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Tracking', 1, N'IIS', 105, N'Tracking', 105, N'Tracking', 105, N'Tracking', N'Tracking', N'Tracking', NULL, N'Parent Tab', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestones', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 10408, N'Milestones', N'Milestones', N'Milestones', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Name of the milestone', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040244, N'Name of the milestone', N'Milestone Name', N'Milestonename', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Type', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040245, N'Milestone Type', N'Milestone Type', N'Milestonetype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Phase', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040246, N'Milestone Phase', N'Milestone Phase', N'Milestonephase', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Parameters', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040247, N'Milestone Parameters', N'Milestone Parameters', N'Milestoneparameters', NULL, N'Text Area (Rich)', NULL, N'Small', 0, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Dependency', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040248, N'Dependency', N'Dependency', N'Dependency', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Estimated Completion Date', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040249, N'Estimated Completion Date', N'Estimatedcompletiondate', N'Estimatedcompletiondate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Completion Date', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040250, N'Milestone Completion Date', N'Milestone Completion Date', N'Milestonecompletiondate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('My statuses', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040251, N'My statuses', N'Status', N'Status', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Reminder sent date', 1, N'IIS', 105, N'Tracking', 10408, N'Milestones', 1040252, N'Reminder sent date', N'Reminder sent date', N'Remindersentdate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Patient Accrual', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 10409, N'Patient Accrual', N'Patient Accrual', N'PatientAccrual', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Month and Year of Accrual', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 1040253, N'Month and Year of Accrual', N'Month and Year of Accrua', N'Monthandyearofaccrual', NULL, N'Date', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Number of New Patients Treated this month', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 1040254, N'Number of New Patients Treated this month', N'Number of New Patients Treated this month', N'Numberofnewpatientstreatedthismonth', NULL, N'Number', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Total no. of patients currently on treatment', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 1040255, N'Total no. of patients currently on treatment', N'Total no. of patients currently on treatment', N'Totalnoofpatientscurrentlyontreatment', NULL, N'Number', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Total No. of patients withdrawn from treatment', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 1040256, N'Total No. of patients withdrawn from treatment', N'Total No. of patients withdrawn from treatment', N'Totalnoofpatientswithdrawnfromtreatment', NULL, N'Number', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Total No. of patients completed treatment', 1, N'IIS', 105, N'Tracking', 10409, N'Patient Accrual', 1040257, N'Total No. of patients completed treatment', N'Total No. of patients completed treatment', N'Totalnoofpatientscompletedtreatment', NULL, N'Number', NULL, N'Small', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Invoices', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 10410, N'Invoices', N'Invoices', N'Invoices', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('My Site', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040259, N'My Site', N'Check Sent to Site', N'Checksenttosite', NULL, N'Date', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Pay', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040260, N'Pay', N'Description of payment', N'Descriptionofpayment', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Invoice Date', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040261, N'Invoice Date', N'Invoice Date', N'Invoicedate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Invoice Number', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040262, N'Invoice Number', N'Invoice Number', N'Invoicenumber', NULL, N'Number', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('PO Number', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040263, N'PO Number', N'PO Number', N'PONumber', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Currency', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040264, N'Currency', N'Currency', N'Currency', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Payment Amount', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040265, N'Payment Amount', N'Payment Amount', N'Paymentamount', NULL, N'Number', NULL, N'Small', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Line Item', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040266, N'Line Item', N'Milestone name (i.e. Upon Enrollment of 10% of Sub', N'Lineitem', NULL, N'Text', NULL, N'Small', 0, 1, 1, 8, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('General Ledger Number', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040267, N'General Ledger Number', N'4Digit General Ledger Number (from the Payment Sch', N'Generalledgernumber', NULL, N'Number', NULL, N'Small', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Department Code', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040268, N'Department Code', N'4 Digit Celgene Department Code/Cost Center Code (', N'Departmentcode', NULL, N'Text', NULL, N'Small', 0, 1, 1, 10, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Budget Source', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040269, N'Budget Source', N'funding source for this payment', N'Budgetsource', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Personnel', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040270, N'Personnel', N'Personnel spend', N'Personnelspend', NULL, N'Number', NULL, N'Small', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IRB Fees', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040271, N'IRB Fees', N'IRB fees portion of this payment', N'IRBFees', NULL, N'Number', NULL, N'Small', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('IRB Annual Fees', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040272, N'IRB Annual Fees', N'IRB Annual Fees portion of payment', N'IRBAnnualfees', NULL, N'Number', NULL, N'Small', 0, 1, 1, 14, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Administrative', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040273, N'Administrative', N'Administrative portion of the payment', N'Administrativeportionofthepayment', NULL, N'Number', NULL, N'Small', 0, 1, 1, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Pharmacy', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040274, N'Pharmacy', N'Pharmacy portion of the payment', N'Pharmacyportionofthepayment', NULL, N'Number', NULL, N'Small', 0, 1, 1, 16, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Start-Up', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040275, N'Start-Up', N'Start-Up Spend', N'Startup', NULL, N'Number', NULL, N'Small', 0, 1, 1, 17, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Correlative', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040276, N'Correlative', N'Correlative portion of this payment', N'Correlative', NULL, N'Number', NULL, N'Small', 0, 1, 1, 18, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040277, N'Other', N'Other', N'Other', NULL, N'Number', NULL, N'Small', 0, 1, 1, 19, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Organization Type', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040278, N'Organization Type', N'Organization Type', N'Organizationtype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 20, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Nature of Expenditure', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040279, N'Nature of Expenditure', N'Nature of Expenditure', N'Natureofexpenditure', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 21, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Purpose of Expenditure', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040280, N'Purpose of Expenditure', N'Purpose of Expenditure', N'Purposeofexpenditure', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 22, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Setting of Activity', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040281, N'Setting of Activity', N'Setting of Activity', N'Settingofactivity', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 23, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Procedural', 1, N'IIS', 105, N'Tracking', 10410, N'Invoices', 1040282, N'Procedural', N'Procedural', N'Procedural', NULL, N'Number', NULL, N'Small', 0, 1, 1, 24, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contracts Timeline', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 10411, N'Contracts Timeline', N'Contracts Timeline', N'ContractsTimeline', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Type', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040283, N'Contract Type', N'Contract Type', N'ContractType', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Status', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040284, N'Contract Status', N'Contract Status', N'ContractStatus', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Version', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040285, N'Version', N'Version', N'Contractstimelineversion', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Current Location', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040286, N'Current Location', N'Current Location', N'CurrentLocation', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contact Name', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040287, N'Contact Name', N'Contact Name', N'Contactname', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Status Change Date', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040288, N'Status Change Date', N'Status Change Date', N'Statuschangedate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Comments', 1, N'IIS', 105, N'Tracking', 10411, N'Contracts Timeline', 1040289, N'Comments', N'Comments', N'Comments', NULL, N'Text', NULL, N'Small', 0, 1, 1, 7, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('General Details', 1, N'IIS', 106, N'General Details', 106, N'General Details', 106, N'General Details', N'General Details', N'Generaldetails', NULL, N'Parent Tab', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Reviews and Notes', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 10413, N'Reviews and Notes', N'Reviews and Notes', N'Reviewsandnotes', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Review Date', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040296, N'Review Date', N'Review Date', N'Reviewdate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('User Name', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040297, N'User Name', N'User Name', N'Username', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Role', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040298, N'Role', N'Role', N'Role', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Review Step', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040299, N'Review Step', N'Review Step', N'Reviewstep', NULL, N'Text', NULL, N'Small', 0, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Submission Comments', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040300, N'Submission Comments', N'Submission Comments', N'Submissioncomments', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 1, 5, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Decision', 1, N'IIS', 106, N'General Details', 10413, N'Reviews and Notes', 1040301, N'Decision', N'Decision', N'Reviewdecision', NULL, N'Text', NULL, N'Small', 0, 1, 1, 6, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Attributes', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 10416, N'Other Attributes', N'Other Attributes', N'Otherattributes', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('The amendment request includes a change in the Primary Investigator', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040320, N'The amendment request includes a change in the Primary Investigator', N'The amendment request includes a change in the Primary Investigator', N'Amendmentrequestincludesachangeintheprimaryinvestigator', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Autoproxy enabled', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040321, N'Autoproxy enabled', N'Autoproxy enabled', N'Autoproxyenabled', NULL, N'Checkbox', NULL, N'Small', 0, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Lead Organization', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040322, N'Lead Organization', N'Lead Organization', N'Leadorganization', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conditional Approval', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040323, N'Conditional Approval', N'Conditional Approval', N'Conditionalapproval', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conditions of Approval', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040324, N'Conditions of Approval', N'Conditions of Approval', N'Conditionsofapproval', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 1, 5, 4000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('ICF Review', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040325, N'ICF Review', N'ICF Review', N'ICFReview', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Amendment Status', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040326, N'Amendment Status', N'Amendment Status', N'Amendmentstatus', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Amendment Type', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040327, N'Amendment Type', N'Amendment Type', N'Amendmenttype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Amendment Required', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040328, N'Contract Amendment Required', N'Contract Amendment Required', N'Contractamendmentrequired', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Is PI Study Sponsor?', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040329, N'Is PI Study Sponsor?', N'Is PI Study Sponsor?', N'IsPIstudysponsor', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Execution Date', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040330, N'Contract Execution Date', N'Contract Execution Date', N'Contractexecutiondate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Migration Date', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040331, N'Migration Date', N'Migration Date', N'Migrationdate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conversion Status', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040332, N'Conversion Status', N'Conversion Status', N'Conversionstatus', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Update Frequency Days', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040333, N'Milestone Update Frequency Days', N'Milestone Update Frequency Days', N'Milestoneupdatefrequencydays', NULL, N'Number', NULL, N'Small', 0, 1, 1, 14, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Accrual Milestone Update Frequency Days', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040334, N'Accrual Milestone Update Frequency Days', N'Accrual Milestone Update Frequency Days', N'Accrualmilestoneupdatefrequencydays', NULL, N'Number', NULL, N'Small', 0, 1, 1, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Last Send EMail', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040335, N'Last Send EMail', N'Last Send EMail', N'Lastsendemail', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 16, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('SAE Frequency', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040336, N'SAE Frequency', N'SAE Frequency', N'SAEFrequency', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 17, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Documents', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 10414, N'Documents', N'Documents', N'Documentstab', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040303, N'Document', N'Document', N'Document', NULL, N'Binary', NULL, N'Small', 1, 1, 1, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Status', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040304, N'Status', N'Status', N'Status', NULL, N'Dropdown', NULL, N'Small', 1, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document Amendment Version', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040305, N'Document Amendment Version', N'Document Amendment Version', N'Documentamendmentversion', NULL, N'Text', NULL, N'Small', 1, 1, 1, 4, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Original or Amendment Documet Version', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040306, N'Original or Amendment Document Version', N'Original or Amendment Document Version', N'Originaloramendmentdocumentversion', NULL, N'Dropdown', NULL, N'Small', 1, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document Type', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040307, N'Document Type', N'Document Type', N'Documenttype', NULL, N'Dropdown', NULL, N'Small', 1, 1, 1, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document Sub Type', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040308, N'Document Sub Type', N'Document Sub Type', N'Documentsubtype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Uploaded By', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040310, N'Uploaded By', N'Uploaded By', N'Uploadedby', NULL, N'Text', NULL, N'Small', 0, 1, 1, 9, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document Date', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040311, N'Document Date', N'Document Date', N'Documentdate', NULL, N'Text', NULL, N'Small', 0, 1, 1, 10, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Original Date', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040312, N'Original Date', N'Original Date', N'Originaldate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Expiration Date', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040313, N'Expiration Date', N'Expiration Date', N'Expirationdate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Document Source', 1, N'IIS', 106, N'General Details', 10414, N'Documents', 1040314, N'Document Source', N'Document Source', N'Documentsource', NULL, N'Label', NULL, N'Small', 0, 1, 1, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Submissions', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 10415, N'Submissions', N'Submissions', N'Submissions', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Submission Type', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 1040315, N'Submission Type', N'Submission Type', N'Submissiontype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Version', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 1040316, N'Version', N'Version', N'Version', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Study eligibility date', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 1040317, N'Study eligibility date', N'Study eligibility date', N'Studyeligibilitydate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Submission Date', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 1040318, N'Submission Date', N'Submission Date', N'Submissiondate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Submission Details', 1, N'IIS', 106, N'General Details', 10415, N'Submissions', 1040319, N'Submission Details', N'Submission Details', N'Submissiondetails', NULL, N'Binary', NULL, N'Small', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
--INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Other Attributes', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 10416, N'Other Attributes', N'Other Attributes', N'Otherattributes', NULL, N'Tab', NULL, N'Small', 0, 1, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
--GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('The amendment request includes a change in the Primary Investigator', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040320, N'The amendment request includes a change in the Primary Investigator', N'The amendment request includes a change in the Primary Investigator', N'Amendmentrequestincludesachangeintheprimaryinvestigator', NULL, N'Checkbox', NULL, N'Small', 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Autoproxy enabled', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040321, N'Autoproxy enabled', N'Autoproxy enabled', N'Autoproxyenabled', NULL, N'Checkbox', NULL, N'Small', 0, 1, 0, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Lead Organization', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040322, N'Lead Organization', N'Lead Organization', N'Leadorganization', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conditional Approval', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040323, N'Conditional Approval', N'Conditional Approval', N'Conditionalapproval', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conditions of Approval', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040324, N'Conditions of Approval', N'Conditions of Approval', N'Conditionsofapproval', NULL, N'Text Area (Rich)', NULL, N'Large', 0, 1, 0, 5, 4000, N'[0-9 -()+]+$', N'Please enter integers only', NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('ICF Review', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040325, N'ICF Review', N'ICF Review', N'ICFReview', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 6, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Amendment Status', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040326, N'Amendment Status', N'Amendment Status', N'Amendmentstatus', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Amendment Type', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040327, N'Amendment Type', N'Amendment Type', N'Amendmenttype', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Amendment Required', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040328, N'Contract Amendment Required', N'Contract Amendment Required', N'Contractamendmentrequired', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Is PI Study Sponsor?', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040329, N'Is PI Study Sponsor?', N'Is PI Study Sponsor?', N'IsPIstudysponsor', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Contract Execution Date', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040330, N'Contract Execution Date', N'Contract Execution Date', N'Contractexecutiondate', NULL, N'Date', NULL, N'Small', 0, 1, 0, 11, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Migration Date', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040331, N'Migration Date', N'Migration Date', N'Migrationdate', NULL, N'Date', NULL, N'Small', 0, 1, 0, 12, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Conversion Status', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040332, N'Conversion Status', N'Conversion Status', N'Conversionstatus', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Milestone Update Frequency Days', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040333, N'Milestone Update Frequency Days', N'Milestone Update Frequency Days', N'Milestoneupdatefrequencydays', N'MilestoneupdatefrequencydaysMilestoneupdatefrequencydays', N'Number', NULL, N'Small', 0, 1, 0, 14, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Accrual Milestone Update Frequency Days', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040334, N'Accrual Milestone Update Frequency Days', N'Accrual Milestone Update Frequency Days', N'Accrualmilestoneupdatefrequencydays', NULL, N'Number', NULL, N'Small', 0, 1, 0, 15, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Last Send EMail', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040335, N'Last Send EMail', N'Last Send EMail', N'Lastsendemail', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 16, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('SAE Frequency', 1, N'IIS', 106, N'General Details', 10416, N'Other Attributes', 1040336, N'SAE Frequency', N'SAE Frequency', N'SAEFrequency', NULL, N'Dropdown', NULL, N'Small', 0, 1, 0, 17, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Related Users', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 10417, N'Related Users', N'Related Users', N'Relatedusers', NULL, N'Tab', NULL, N'Small', 0, 1, 1, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Full Name', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040337, N'Full Name', N'Full Name', N'Fullname', NULL, N'Dropdown', NULL, N'Small', 1, 1, 1, 1, 1, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Email', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040338, N'Email', N'Email', N'Relatedusersemail', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,Admin,ContractManager,ProgramLeader,Management,MD,MeetingMembers,MSL,MSL RD,PI', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Phone', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040339, N'Phone', N'Phone', N'Relatedusersphone', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,Admin,ContractManager,ProgramLeader,Management,MD,MeetingMembers,MSL,MSL RD,PI', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('User Type', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040340, N'User Type', N'User Type', N'Relatedusersrole', NULL, N'Dropdown', NULL, N'Small', 1, 1, 1, 4, 1, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Begin Date', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040341, N'Begin Date', N'Begin Date', N'Relatedusersbegindate', NULL, N'Date', NULL, N'Small', 1, 1, 1, 5, 1, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('End Date', 1, N'IIS', 106, N'General Details', 10417, N'Related Users', 1040342, N'End Date', N'End Date', N'Relatedusersenddate', NULL, N'Date', NULL, N'Small', 0, 1, 1, 6, 1, NULL, NULL, NULL, N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,Admin,ContractManager,ProgramLeader,Management,MD,MeetingMembers,MSL,MSL RD,PI', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', N'TrialLeader,PI,MeetingMembers,MD,MSL,MSL RD,Admin,ContractManager,Management,ProgramLeader', 1, 0, N'SYSTEM', GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Status', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 10418, N'Status', N'Status', N'Statusineditstudy', NULL, N'Tab', NULL, N'Small', 0, 1, 0, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',  GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Stage', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 1040343, N'Stage', N'Stage', N'Statusstage', NULL, N'Text', NULL, N'Small', 0, 1, 1, 1, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',  GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('State', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 1040344, N'State', N'State', N'State', NULL, N'Text', NULL, N'Small', 0, 1, 1, 2, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM', GETDATE(),NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Status', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 1040345, N'Status', N'Status', N'Status', NULL, N'Text', NULL, N'Small', 0, 1, 1, 3, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',  GETDATE(), NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Date', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 1040346, N'Date', N'Date', N'Date', NULL, N'Date', NULL, N'Small', 0, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',  GETDATE(),NULL, NULL)
GO
INSERT [dbo].[EditStudyAttributes] ( [Name], [ParentID], [ParentName], [ChildId], [ChildName], [SubChildID], [SubChildName], [GrandChildId], [GrandChildName], [Description], [FieldType], [HelpText], [Type], [ListofValuesId], [Size], [IsMandatory], [IsViewable], [IsSearchable], [DisplayOrder], [ColumnWidth], [RegexExpression], [ValidationMessage], [GroupPermissionsId], [RestrictCreateUser], [RestrictViewUser], [RestrictEditUser], [IsFieldViewableInMetaData], [RestrictDeleteUser], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ('Time', 1, N'IIS', 105, N'Tracking', 10418, N'Status', 1040347, N'Time', N'Time', N'Time', NULL, N'Text', NULL, N'Small', 0, 1, 1, 5, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'SYSTEM',  GETDATE(), NULL, NULL)
GO

update EditStudyAttributes set IsFieldViewableInMetaData = 1
update EditStudyAttributes set IsFieldViewableInMetaData = 0 where SubChildName = 'Documents' AND GrandChildId ! = 10414
update EditStudyAttributes set IsFieldViewableInMetaData = 0 where SubChildName = 'Related Users' AND GrandChildId ! = 10417


--SET IDENTITY_INSERT EditStudyAttributes OFF


update [dbo].[EditStudyAttributes] set Type = 'GrandParent Tab' where GrandChildId = ParentID
GO

update [dbo].[EditStudyAttributes] set Type = 'Parent Tab' where GrandChildId != ParentID AND ChildId = GrandChildId
GO

-----------------------------------------------------------------------------------------------------------------------------------------------
--Global Settings Enteries
-------------------------------------------------------------------------------------------------------------

/*IsDisplay column values updated in SysCodeValues*/
update SysCodeValues set IsDisplay=1
GO

update SysCodeValues set IsDisplay= 0 WHERE ColumnName IN ('Country','GMRCApprovalTasks','MaintainanceAndMonitoring','PIActivationTasks','PIApprovalTasks','Region','TLActivationTasks')
GO

-- Workflow Scheme
INSERT [dbo].[WorkflowScheme] ([Code], [Scheme], [CanBeInlined], [InlinedSchemes], [Tags]) VALUES (N'Submit New Study', N'<Process Name="Submit New Study" CanBeInlined="false" Tags="">
  <Designer />
  <Actors>
    <Actor Name="PI" Rule="IsUser" Value="PI" />
    <Actor Name="IISAdmin" Rule="IsUser" Value="IISAdmin" />
    <Actor Name="MSL" Rule="IsUser" Value="MSL" />
    <Actor Name="PL" Rule="IsUser" Value="Program Leader" />
    <Actor Name="TL" Rule="IsUser" Value="Trial Leader" />
  </Actors>
  <Commands>
    <Command Name="AssignMSLAndPLToStudy" />
    <Command Name="ReviewStudyByMSL" />
    <Command Name="AcceptedByMSL" />
    <Command Name="ResubmitByMSL" />
    <Command Name="ResubmissionByPI" />
    <Command Name="AcceptedByPL" />
    <Command Name="ResubmitByPL" />
    <Command Name="RecordLocalMRC" />
    <Command Name="RecordGlobalMRC" />
    <Command Name="CreateOrDeliverApprovalLetter" />
  </Commands>
  <Activities>
    <Activity Name="NewStudySubmitted" State="NewStudySubmitted" IsInitial="True" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="40" Y="150" />
    </Activity>
    <Activity Name="AssignMSLAndPLToStudy" State="AssignMSLAndPLToStudy" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="40" Y="410" />
    </Activity>
    <Activity Name="MSLLOIReview" State="MSLLOIReview" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="560" Y="150" />
    </Activity>
    <Activity Name="PLReview" State="PLReview" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="1100" Y="140" />
    </Activity>
    <Activity Name="RecordLocalMRCResult" State="RecordLocalMRCResult" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="1130" Y="300" />
    </Activity>
    <Activity Name="RecordGlobalMRCResult" State="RecordGlobalMRCResult" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="720" Y="290" />
    </Activity>
    <Activity Name="CreateOrDeliverApprovalLetter" State="CreateOrDeliverApprovalLetter" IsInitial="False" IsFinal="False" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="740" Y="490" />
    </Activity>
    <Activity Name="MileStoneComplete" State="MileStoneComplete" IsInitial="False" IsFinal="True" IsForSetState="True" IsAutoSchemeUpdate="True">
      <Designer X="300" Y="490" />
    </Activity>
  </Activities>
  <Transitions>
    <Transition Name="NewStudySubmitted_AssignMSLAndPLToStudy_1" To="AssignMSLAndPLToStudy" From="NewStudySubmitted" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="AssignMSLAndPLToStudy" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
    <Transition Name="AssignMSLAndPLToStudy_MSLReview_1" To="MSLLOIReview" From="AssignMSLAndPLToStudy" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="ReviewStudyByMSL" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
    <Transition Name="MSLReview_PLReview_1" To="PLReview" From="MSLLOIReview" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="AcceptedByMSL" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer X="918" Y="95" />
    </Transition>
    <Transition Name="MSLReview_NewStudySubmitted_1" To="NewStudySubmitted" From="MSLLOIReview" Classifier="Reverse" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="ResubmitByMSL" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer X="400" Y="105.5" />
    </Transition>
    <Transition Name="NewStudySubmitted_MSLReview_1" To="MSLLOIReview" From="NewStudySubmitted" Classifier="NotSpecified" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Restrictions>
        <Restriction Type="Allow" NameRef="PI" />
      </Restrictions>
      <Triggers>
        <Trigger Type="Command" NameRef="ResubmissionByPI" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer X="406" Y="170" />
    </Transition>
    <Transition Name="PLReview_RecordLocalMRCResult_1" To="RecordLocalMRCResult" From="PLReview" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="AcceptedByPL" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
    <Transition Name="PLReview_MSLReview_1" To="MSLLOIReview" From="PLReview" Classifier="Reverse" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="ResubmitByPL" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer X="928" Y="185" />
    </Transition>
    <Transition Name="RecordLocalMRCResult_RecordGlobalMRCResult_1" To="RecordGlobalMRCResult" From="RecordLocalMRCResult" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="RecordLocalMRC" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
    <Transition Name="RecordGlobalMRCResult_CreateLetter_1" To="CreateOrDeliverApprovalLetter" From="RecordGlobalMRCResult" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="RecordGlobalMRC" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
    <Transition Name="CreateOrDeliverApprovalLetter_MileStoneComplete_1" To="MileStoneComplete" From="CreateOrDeliverApprovalLetter" Classifier="Direct" AllowConcatenationType="And" RestrictConcatenationType="And" ConditionsConcatenationType="And" IsFork="false" MergeViaSetState="false" DisableParentStateControl="false">
      <Triggers>
        <Trigger Type="Command" NameRef="CreateOrDeliverApprovalLetter" />
      </Triggers>
      <Conditions>
        <Condition Type="Always" />
      </Conditions>
      <Designer />
    </Transition>
  </Transitions>
  <CodeActions>
    <CodeAction Name="IsUser" Type="RuleCheck" IsGlobal="False" IsAsync="False">
      <ActionCode><![CDATA[//return WorkflowHelper.IsUser(processInstance,runtime,identityId,parameter);

return true;]]></ActionCode>
      <Usings><![CDATA[System.Collections.Generic;System;OptimaJet.Workflow;OptimaJet.Workflow.Core.Model;System.Threading.Tasks;System.Threading;System.Linq;System.Collections;Anju.Navigate.BusinessAccess.Workflow;]]></Usings>
    </CodeAction>
  </CodeActions>
</Process>', 0, NULL, NULL)

GO

/*Scripts to create New Admin User(Internal user) and insert scripts for country,state and city 
UserName:Openq.admin
Password:password-1
*/


Declare @Countryid int
Declare @Stateid int
Declare @cityid int

INSERT [dbo].[Country] ( [Code], [Name], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ( N'USA', N'United States', 1, 0,N'SYSTEM', GETDATE(), N'SYSTEM', GETDATE())
select @Countryid = Scope_Identity()
INSERT [dbo].[State] ( [CountryId], [Name], [Code], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ( @Countryid, N'Alaska', N'AK', 1, 0, N'SYSTEM',  GETDATE(), N'SYSTEM',  GETDATE())
select @Stateid = Scope_Identity()
INSERT [dbo].[City] ([StateId], [Name], [IsActive], [IsDeleted], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ( @Stateid, N'Anchorage', 1, 0, N'SYSTEM', GETDATE(), N'SYSTEM', GETDATE())
select @cityid = Scope_Identity()


INSERT [dbo].[Users] ( [Salutation], [FirstName], [LastName], [Title], [RoleID], [OrganizationName], [Department], [Address1], [Address2], [CityID], [StateID], [CountryID], [Zip], [TelephoneNumber], [MobileNumber], [DOB], [Fax], [PrimaryEmailID], [SecondaryEmailID], [Gender], [UserName], [Password], [PasswordExpiryDate], [UserType], [UserStatus], [Suffix], [IsActive], [IsDeleted], [IsAccountLocked], [FailedAttempts], [EndUserType], [ANJU_AddedBy], [ANJU_AddDate], [ANJU_ChangedBy], [ANJU_ChangeDate]) VALUES ( N'Mr', N'OpenQ-ADMIN', N'OpenQ-ADMIN', NULL, NULL, NULL, N'Biostatistics', N'55 Main Street', NULL, @cityid, @Stateid, @Countryid, N'00000', NULL, N'0000000000', NULL, NULL, N'Openq.admin@AnjuSoftware.com', NULL, NULL, N'Openq.admin', N'6MWUw7xQSn9Xv/9Nt96pSRyX2JM=', GETDATE(), N'Admin', N'Active              ', NULL, 1, 0, 0, 0, N'InternalUser', N'SYSTEM',GETDATE(), N'SYSTEM',GETDATE())

