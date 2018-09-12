CREATE TABLE [dbo].[Morador]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] CHAR(100) NOT NULL, 
    [Cpf] CHAR(11) NOT NULL, 
    [Senha] CHAR(100) NOT NULL, 
    [DataNascimento] DATE NOT NULL
)
