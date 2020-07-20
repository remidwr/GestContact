CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL IDENTITY, 
    [Login] NCHAR(50) NOT NULL, 
    [Password] NCHAR(120) NOT NULL, 
    CONSTRAINT [PK_Login] PRIMARY KEY ([Id])
)
