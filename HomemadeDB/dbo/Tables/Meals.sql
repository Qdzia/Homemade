CREATE TABLE [dbo].[Meals]
(
	[MealId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExpectedDate] DATE NOT NULL, 
    [Notes] NVARCHAR(50) NULL, 
    [RecepieId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Number] INT NULL DEFAULT 0, 
    CONSTRAINT [FK_Meals_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Meals_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId])
)
