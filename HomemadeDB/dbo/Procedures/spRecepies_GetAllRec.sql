CREATE PROCEDURE [dbo].[spRecepies_GetAllRec]
AS
BEGIN
	SELECT * FROM Recepies ORDER BY RecepieName ASC;
END

