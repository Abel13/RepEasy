CREATE TABLE [dbo].[MoradorDespesa]
(
  [Morador] INT NOT NULL,
  [Despesa] INT NOT NULL,
  [Valor] DECIMAL(5, 2) NULL, 
    PRIMARY KEY CLUSTERED ([Despesa], [Morador]),
  FOREIGN KEY ([Morador]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
  FOREIGN KEY ([Despesa]) REFERENCES [dbo].[Despesa] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)
