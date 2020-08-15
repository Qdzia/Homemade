CREATE TABLE [dbo].[Ingredients]
(
	[IngId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IngName] NCHAR(10) NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL CHECK 
    ([Category] IN('Dark-Green', 
                    'Red & Orange', 
                    'Legumes', 
                    'Starchy', 
                    'Vegetables', 
                    'Protein Foods', 
                    'Grains',
                    'Fruits', 
                    'Oils', 
                    'Dairy',
                    'Others')),
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
