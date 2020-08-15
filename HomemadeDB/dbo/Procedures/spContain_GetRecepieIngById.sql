CREATE PROCEDURE [dbo].[spContain_GetRecepieIngById]
	@RecepieId int
AS
BEGIN
	SELECT * FROM Contain
	WHERE RecepieId = @RecepieId;
END
