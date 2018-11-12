CREATE TABLE [dbo].[Item] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [Descricao] nchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id])
)