CREATE TABLE [dbo].[Morador]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nome] CHAR(100) NOT NULL, 
    [cpf] NCHAR(11) NOT NULL, 
    [senha] CHAR(50) NOT NULL, 
    [data_nascimento] DATE NOT NULL
)
