CREATE TABLE [dbo].[Restrictions]
(
	[TagId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Max] DECIMAL NULL, 
    [Min] DECIMAL NULL,
    CONSTRAINT [FK_Restrictions_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Restrictions_Tags] FOREIGN KEY ([TagId]) REFERENCES [Tags]([TagId]),
    PRIMARY KEY([UserId],[TagId])
)
