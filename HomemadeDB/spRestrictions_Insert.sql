CREATE PROCEDURE [dbo].[spRestrictions_Insert]
	@ResId INT , 
    @UserId INT, 
    @MaxNum DECIMAL, 
    @MinNum DECIMAL
AS
BEGIN
    DELETE FROM Restrictions 
    WHERE ResId = @ResId AND UserId = @UserId;

	INSERT INTO Restrictions 
    (ResId, UserId, MaxNum, MinNum)
    VALUES 
    (@ResId, @UserId, @MaxNum, @MinNum);
END
