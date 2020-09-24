CREATE PROCEDURE [dbo].[spRecepies_Insert]
	@RecepieName NVARCHAR(50),
	@Instruction NVARCHAR(2000) NULL, 
    @PrepTime TIME NULL, 
    @TotalTime TIME NULL, 
    @Video NVARCHAR(200) NULL, 
    @Photo NVARCHAR(200) NULL, 
    @UserId INT NULL, 
    @CreatedAt DATETIME NULL
AS
BEGIN
	INSERT INTO Recepies
    (RecepieName, Instruction, PrepTime, TotalTime,Video,Photo,UserId,CreatedAt)
    VALUES 
    (@RecepieName, @Instruction, @PrepTime, @TotalTime,@Video,@Photo,@UserId,@CreatedAt);
END
