CREATE PROCEDURE [dbo].[spContain_Insert]
	@RecepieId INT  NULL, 
    @IngId INT NULL, 
    @Number DECIMAL NULL, 
    @Unit NVARCHAR(50) NULL, 
    @Notes NVARCHAR(50) NULL
AS
BEGIN
    INSERT INTO Contain
    (RecepieId, IngId, Number, Unit, Notes)
    VALUES 
    (@RecepieId, @IngId, @Number, @Unit, @Notes);
END
