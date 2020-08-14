CREATE TABLE [dbo].[Contain]
(
	[RecepieId] INT NOT NULL, 
    [IngId] INT NOT NULL, 
    CONSTRAINT [FK_Contain_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId]), 
    CONSTRAINT [FK_Contain_Ing] FOREIGN KEY ([IngId]) REFERENCES [Ingredients]([IngId]),
    PRIMARY KEY([RecepieId],[IngId])
)
