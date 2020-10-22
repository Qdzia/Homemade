CREATE PROCEDURE [dbo].[spRestrictions_GetFromUser]
	@UserId int 
AS
Begin
	SELECT ResId,MaxNum,MinNum FROM Restrictions
	WHERE UserId = @UserId;
End