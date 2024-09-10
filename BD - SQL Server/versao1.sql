CREATE DATABASE ConectaCiencia;
GO

USE ConectaCiencia;
GO

-- Categorias
CREATE TABLE Categorias (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    nome_categoria VARCHAR(255) NOT NULL
);
GO

-- Formulário Tema
CREATE TABLE FormularioTema (
    id_sugestao_tema INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    tema VARCHAR(255) NOT NULL,
    id_categoria INT,
    CONSTRAINT FK_FormularioTema_Categoria FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);
GO

-- Formulário Artigo
CREATE TABLE FormularioArtigo (
    id_sugestao_artigo INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    titulo VARCHAR(255) NOT NULL,
    conteudo TEXT NOT NULL,
    id_categoria INT,
    CONSTRAINT FK_FormularioArtigo_Categoria FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);
GO

-- Artigos
CREATE TABLE Artigos (
    id_artigo INT PRIMARY KEY IDENTITY(1,1),
    data DATETIME DEFAULT GETDATE(),
    titulo VARCHAR(255) NOT NULL,
    conteudo TEXT NOT NULL,
    nome VARCHAR(255) NOT NULL 
);
GO
