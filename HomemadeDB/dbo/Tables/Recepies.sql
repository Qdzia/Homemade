CREATE TABLE [dbo].[Recepies]
(
	[RecepieId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecepieName] NVARCHAR(50) NOT NULL, 
    [Instruction] NVARCHAR(1000) NULL, 
    [PrepTime] TIME NULL, 
    [TotalTime] TIME NULL, 
    [Video] NVARCHAR(200) NULL, 
    [Photo] NVARCHAR(200) NULL, 
    [UserId] INT NULL, 
    [CreatedAt] DATETIME NULL,
    [Rating] TINYINT NULL, 
    CONSTRAINT [FK_Recepies_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]) 
)
