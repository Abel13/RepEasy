CREATE TABLE [dbo].[Morador] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [Nome] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Cpf] char(11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Senha] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DataNascimento] date NOT NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Morador] PRIMARY KEY ([Id])
)