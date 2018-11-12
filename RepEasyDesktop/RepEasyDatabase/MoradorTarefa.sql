CREATE TABLE [dbo].[MoradorTarefa] (
  [Morador] int NOT NULL,
  [Tarefa] int NOT NULL,
  PRIMARY KEY CLUSTERED ([Tarefa], [Morador]),
	FOREIGN KEY ([Morador]) REFERENCES [dbo].[Morador] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
	FOREIGN KEY ([Tarefa]) REFERENCES [dbo].[Tarefa] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)