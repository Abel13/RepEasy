CREATE TABLE [dbo].[Recebimento] (
  [Morador] int NOT NULL,
  [Devedor] int NOT NULL,
  [Valor] decimal(5,2) NOT NULL,
  PRIMARY KEY CLUSTERED ([Devedor], [Morador]),
	FOREIGN KEY ([Morador]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
	FOREIGN KEY ([Devedor]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)