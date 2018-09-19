CREATE TABLE [dbo].[Despesa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descricao] NCHAR(50) NOT NULL, 
    [Valor] DECIMAL(5, 2) NOT NULL,

)
