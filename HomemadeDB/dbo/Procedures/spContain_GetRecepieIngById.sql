CREATE PROCEDURE [dbo].[spContain_GetRecepieIngById]
	@RecepieId int
AS
BEGIN
	SELECT i.IngName, c.Number, c.Unit, c.Notes 
	FROM Contain c
	JOIN Ingredients i ON c.IngId = i.IngId
	WHERE RecepieId = @RecepieId;
END
