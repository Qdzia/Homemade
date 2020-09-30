CREATE PROCEDURE [dbo].[spRestrictions_GetFromUser]
	@UserId int 
AS
Begin
	SELECT t.Tag,r.Max,r.Min FROM Restrictions r
	JOIN Tags t ON t.TagId = r.TagId
	WHERE UserId = @UserId;
End