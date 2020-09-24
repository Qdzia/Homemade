CREATE TABLE [dbo].[Items]
(
	[StoredIn] VARCHAR(6) NOT NULL CHECK ([StoredIn] IN('Fridge', 'Shelf', 'List')), 
    [IngId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Count] DECIMAL NULL, 
    [Unit] INT NULL, 
    [Notes] NVARCHAR(20) NULL, 
    CONSTRAINT [FK_Items_Ing] FOREIGN KEY ([IngId]) REFERENCES [Ingredients]([IngId]), 
    CONSTRAINT [FK_Items_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]),
    PRIMARY KEY([StoredIn],[IngId],[UserId])
)
