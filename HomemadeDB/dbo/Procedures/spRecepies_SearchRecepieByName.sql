CREATE PROCEDURE [dbo].[spRecepies_SearchRecepieByName]
	@Name nvarchar(256)
AS
BEGIN

SELECT * FROM Recepies 
WHERE RecepieName LIKE @Name;

END

