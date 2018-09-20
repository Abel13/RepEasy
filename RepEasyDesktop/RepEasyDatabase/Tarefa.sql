CREATE TABLE [dbo].[Tarefa]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titulo] NCHAR(20) NOT NULL, 
    [Descricao] CHAR(300) NULL, 
    [Data] DATETIME NULL
)
