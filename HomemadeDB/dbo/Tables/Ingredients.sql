CREATE TABLE [dbo].[Ingredients]
(
	[IngId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IngName] NCHAR(10) NOT NULL, 
    [Category] NVARCHAR(50) NULL, 
    [Calories] INT NULL, 
    [Fat] INT NULL, 
    [Carbs] INT NULL, 
    [Fiber] INT NULL, 
    [Sugar] INT NULL, 
    [Protein] INT NULL, 
    [Sodium] INT NULL, 
    [TransFat] INT NULL, 
    [Cholesterol] INT NULL
)
