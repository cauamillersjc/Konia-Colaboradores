CREATE DATABASE [db_colaboradores]
GO
USE [db_colaboradores]
GO
CREATE TABLE [colaboradores] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [nome] varchar(255) NOT NULL,
  [data_criacao] datetime NOT NULL DEFAULT (GETDATE())
)
GO
