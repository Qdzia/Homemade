CREATE PROCEDURE [dbo].[spRecepies_GetById]
	@RecepieId int 
AS
Begin
	SELECT * FROM Recepies
	WHERE RecepieId = @RecepieId;
End
