CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Login] NVARCHAR(16) NOT NULL, 
    [Password] NVARCHAR(16) NOT NULL, 
    [Email] NCHAR(10) NULL, 
    [CreatedAt] DATETIME NULL, 
    [LastActive] DATETIME NULL
)
