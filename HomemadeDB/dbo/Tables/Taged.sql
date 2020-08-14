CREATE TABLE [dbo].[Taged]
(
	[TagId] INT NOT NULL, 
    [RecepieId] INT NOT NULL,
	CONSTRAINT [FK_Taged_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId]),
    CONSTRAINT [FK_Taged_Tags] FOREIGN KEY ([TagId]) REFERENCES [Tags]([TagId]),
    PRIMARY KEY([RecepieId],[TagId])
)
