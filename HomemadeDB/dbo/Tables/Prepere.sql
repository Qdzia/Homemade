CREATE TABLE [dbo].[Prepere]
(
	[RecepieId] INT NOT NULL, 
    [IngId] INT NOT NULL, 
    CONSTRAINT [FK_Prepere_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId]), 
    CONSTRAINT [FK_Prepere_Ing] FOREIGN KEY ([IngId]) REFERENCES [Ingredients]([IngId]),
    PRIMARY KEY([RecepieId],[IngId])
)
