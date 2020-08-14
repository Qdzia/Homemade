CREATE TABLE [dbo].[FamilyMembers]
(
	[MemberId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PhysicalActivity] VARCHAR(50) NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [FullName] NCHAR(10) NULL, 
    [UserId] INT NULL, 
    CONSTRAINT [FK_FamilyMembers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
