CREATE TABLE [dbo].[MoradorDespesa] (
  [Morador] int NOT NULL,
  [Despesa] int NOT NULL,
  [Responsavel] int NOT NULL,
  [Valor] decimal(5,2) NOT NULL,
  PRIMARY KEY CLUSTERED ([Despesa], [Morador]),
  FOREIGN KEY ([Morador]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE,
  FOREIGN KEY ([Despesa]) REFERENCES [dbo].[Despesa] ([Id]) ON DELETE CASCADE,
  FOREIGN KEY ([Responsavel]) REFERENCES [dbo].[Morador] ([Id])
)