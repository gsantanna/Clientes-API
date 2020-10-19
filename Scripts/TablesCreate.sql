GO

CREATE TABLE [Cliente] (
[Id] INT IDENTITY NOT NULL,
[Nome] nvarchar(30) NOT NULL,
[Cpf] nvarchar(11) NOT NULL,
[Idade] int NOT NULL,
[DataNascimento] datetime2 NOT NULL,
CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Endereco] (
[Id] INT IDENTITY NOT NULL,
[Logradouro] nvarchar(50) NOT NULL,
[Bairro] nvarchar(40) NOT NULL,
[Cidade] nvarchar(40) NOT NULL,
[Estado] nvarchar(40) NOT NULL,
CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id]),
);