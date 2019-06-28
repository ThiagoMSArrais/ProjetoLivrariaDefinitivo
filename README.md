# ProjetoLivraria
Este projeto foi elaborado para atender ao desafio que foi requisitado pelo Brasil Center.
___
## Script de criação da tabela.
É necessário rodar este script no SQL Server e alterar o connectionstring local.
```sql
CREATE DATABASE [ProjetoLivraria]
GO

USE [ProjetoLivraria]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Livro] (
    [ISBN]           NVARCHAR(17)    NOT NULL,
    [Autor]          NVARCHAR (180)  NOT NULL,
    [Nome]           NVARCHAR (180)  NOT NULL,
    [Preco]          MONEY           NOT NULL,
    [DataPublicacao] DATE            NOT NULL,
);
```
