CREATE TABLE [dbo].[Ingredients]
(
	[IngId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IngName] NVARCHAR(50) NOT NULL, 
    [Category] INT NOT NULL,
    [Calories] DECIMAL NULL, 
    [Fat] DECIMAL NULL, 
    [Carbs] DECIMAL NULL, 
    [Fiber] DECIMAL NULL, 
    [Sugar] DECIMAL NULL, 
    [Protein] DECIMAL NULL, 
    [Sodium] DECIMAL NULL, 
    [TransFat] DECIMAL NULL, 
    [Cholesterol] DECIMAL NULL
)
