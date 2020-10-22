CREATE PROCEDURE [dbo].[spMeals_Insert]
	@MealId INT NULL, 
    @RecepieId INT NULL, 
    @UserId INT NULL, 
    @ExpectedDate DATE NULL, 
    @NumberOfMeal INT NULL, 
    @Servings INT NULL, 
    @Notes NVARCHAR(50) NULL
AS
IF EXISTS (
    SELECT * FROM Meals m 
    WHERE m.ExpectedDate = @ExpectedDate 
    AND m.NumberOfMeal = @NumberOfMeal
    )
BEGIN
    UPDATE Meals
    SET RecepieId = @RecepieId, Servings = @Servings, Notes = @Notes
    WHERE ExpectedDate = @ExpectedDate 
    AND NumberOfMeal = @NumberOfMeal 
END
ELSE
BEGIN
    INSERT INTO Meals
    (RecepieId, UserId, ExpectedDate, NumberOfMeal, Servings, Notes)
    VALUES
    (@RecepieId, @UserId, @ExpectedDate, @NumberOfMeal, @Servings, @Notes);
END
 