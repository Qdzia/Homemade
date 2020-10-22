CREATE TABLE [dbo].[Restrictions]
(
	[ResId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [MaxNum] DECIMAL NULL, 
    [MinNum] DECIMAL NULL,
    CONSTRAINT [FK_Restrictions_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]),
    PRIMARY KEY([UserId],[ResId])
)
