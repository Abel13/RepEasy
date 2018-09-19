CREATE TABLE [dbo].[DespesaMorador]
(
  [Morador] INT NOT NULL,
  [Despesa] INT NOT NULL,
  PRIMARY KEY CLUSTERED ([Despesa], [Despesa]),
  FOREIGN KEY ([Morador]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
  FOREIGN KEY ([Despesa]) REFERENCES [dbo].[Despesa] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)
