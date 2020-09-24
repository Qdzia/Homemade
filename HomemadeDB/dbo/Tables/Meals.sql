CREATE TABLE [dbo].[Meals]
(
	[MealId] INT NOT NULL PRIMARY KEY IDENTITY,
    [RecepieId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [ExpectedDate] DATE NOT NULL, 
    [NumberOfMeal] INT NOT NULL, 
    [Servings] DECIMAL NOT NULL,
    [Notes] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Meals_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Meals_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId])
)
