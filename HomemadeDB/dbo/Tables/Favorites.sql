CREATE TABLE [dbo].[Favorites]
(
	[RecepieId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Favorites_Users] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId]), 
    CONSTRAINT [FK_Favorites_Recepies] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]),
    PRIMARY KEY([RecepieId],[UserId])
)
