CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Login] NVARCHAR(16) NOT NULL, 
    [Password] NVARCHAR(16) NOT NULL, 
    [Email] NVARCHAR(30) NULL, 
    [CreatedAt] DATETIME NULL, 
    [LastActive] DATETIME NULL,
    [FullName] NCHAR(10) NULL,
    [PhysicalActivity] VARCHAR(50) NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL
    
)
