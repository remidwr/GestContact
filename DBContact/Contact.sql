CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL  IDENTITY,
	Prenom VARCHAR(50),
	Nom VARCHAR(50),
	Email VARCHAR (70) NOT NULL,
	Telephone VARCHAR(15), 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
)
