CREATE PROCEDURE [dbo].[spUsers_GetUserById]
	@UserId INT
AS
BEGIN
	SELECT * FROM Users
	WHERE UserId = @UserId;
END
