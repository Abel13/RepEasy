CREATE TABLE [dbo].[Tarefa] (
  [Id] int NOT NULL,
  [Titulo] nchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Descricao] char(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Data] datetime NULL, 
    CONSTRAINT [PK_Tarefa] PRIMARY KEY ([Id])
)