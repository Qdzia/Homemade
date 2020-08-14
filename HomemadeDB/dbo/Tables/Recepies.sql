CREATE TABLE [dbo].[Recepies]
(
	[RecepieId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecepieName] NVARCHAR(50) NOT NULL, 
    [Instruction] NCHAR(10) NULL, 
    [PrepTime] TIME NULL, 
    [TotalTime] TIME NULL, 
    [Video] NVARCHAR(50) NULL, 
    [Photo] NVARCHAR(50) NULL, 
    [UserId] INT NULL, 
    [CreatedAt] DATETIME NULL,
    [Rating] TINYINT NULL, 
    CONSTRAINT [FK_Recepies_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]) 
)
