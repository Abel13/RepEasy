CREATE TABLE [dbo].[ItemDespesa] (
  [Despesa] int NOT NULL,
  [Item] int NOT NULL,
	PRIMARY KEY CLUSTERED ([Despesa], [Item]),
	FOREIGN KEY ([Item]) REFERENCES [dbo].[Item] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
	FOREIGN KEY ([Despesa]) REFERENCES [dbo].[Despesa] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)