CREATE PROCEDURE [dbo].[spIngredients_Insert]
    @IngName NVARCHAR(50) NOT NULL,
    @Calories DECIMAL NULL, 
    @Fat DECIMAL NULL, 
    @Carbs DECIMAL NULL, 
    @Fiber DECIMAL NULL, 
    @Sugar DECIMAL NULL, 
    @Protein DECIMAL NULL, 
    @Sodium DECIMAL NULL, 
    @TransFat DECIMAL NULL, 
    @Cholesterol DECIMAL NULL
AS
BEGIN
    INSERT INTO Ingredients
    (IngName, Category, Calories, Fat, Carbs, Fiber, Sugar, Protein, Sodium, TransFat, Cholesterol)
    VALUES 
    (@IngName,1, @Calories, @Fat, @Carbs, @Fiber, @Sugar, @Protein, @Sodium, @TransFat, @Cholesterol);
END