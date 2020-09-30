CREATE PROCEDURE [dbo].[spMeals_GetMealsOfDay]
	@Day Date
AS
BEGIN
	SELECT m.MealId,m.RecepieId,m.UserId,m.ExpectedDate,m.NumberOfMeal,m.Servings,m.Notes,r.RecepieName
	FROM Meals m
	JOIN Recepies r ON r.RecepieId = m.RecepieId
	WHERE m.ExpectedDate = @Day
	ORDER BY m.NumberOfMeal;
END
