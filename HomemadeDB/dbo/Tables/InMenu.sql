CREATE TABLE [dbo].[InMenu]
(
	[MenuId] INT NOT NULL, 
    [RecepieId] INT NOT NULL, 
    [Day] INT NOT NULL, 
    [Number] INT NOT NULL, 
    CONSTRAINT [FK_InMenu_Menus] FOREIGN KEY ([MenuId]) REFERENCES [Menus]([MenuId]), 
    CONSTRAINT [FK_InMenu_Recepies] FOREIGN KEY ([RecepieId]) REFERENCES [Recepies]([RecepieId]),
    PRIMARY KEY([MenuId],[RecepieId] )
)
