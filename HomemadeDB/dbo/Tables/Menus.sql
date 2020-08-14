CREATE TABLE [dbo].[Menus]
(
	[MenuId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MenuName] NVARCHAR(50) NULL, 
    [Notes] NVARCHAR(255) NULL, 
    [UserId] INT NULL, 
    CONSTRAINT [FK_Menus_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
