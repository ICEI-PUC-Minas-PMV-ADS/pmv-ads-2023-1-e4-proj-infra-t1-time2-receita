CREATE TABLE Usuarios (
  IdUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nome VARCHAR(45) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  Senha VARCHAR(255) NOT NULL,
  UF VARCHAR(2) NOT NULL,
  DataCadastro TIMESTAMP NOT NULL)

CREATE TABLE Receita (
  IdReceita INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nome VARCHAR(45) NOT NULL,
  Tempo INT NOT NULL,
  Rendimento FLOAT NOT NULL,
  Foto TEXT NOT NULL,
  IdUsuario INT NOT NULL,
  FOREIGN KEY (IdUsuario)
    REFERENCES Usuarios (IdUsuario))

CREATE TABLE Ingrediente (
  IdIngrediente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nome VARCHAR(45) NOT NULL)

CREATE TABLE Receita_Ingrediente (
  IdReceita INT NOT NULL,
  Id_Ingrediente INT NOT NULL,
    FOREIGN KEY (IdReceita)
    REFERENCES Receita (IdReceita),
    FOREIGN KEY (Id_Ingrediente)
    REFERENCES Ingrediente (IdIngrediente))

CREATE TABLE Etapa (
  IdEtapa INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Descricao TEXT NOT NULL,
  NumPosicao INT NOT NULL)

CREATE TABLE Ingrediente_Etapa (
  IdIngrediente INT NOT NULL,
  IdEtapa INT NOT NULL,
  Unidade VARCHAR(20) NOT NULL,
  Quantidade VARCHAR(20) NOT NULL,
    FOREIGN KEY (IdIngrediente)
    REFERENCES Ingrediente (IdIngrediente),
    FOREIGN KEY (IdEtapa)
    REFERENCES Etapa (IdEtapa))

CREATE TABLE Receita_Etapa (
  IdReceita INT NOT NULL,
  IdEtapa INT NOT NULL,
    FOREIGN KEY (IdReceita)
    REFERENCES Receita (IdReceita),
    FOREIGN KEY (IdEtapa)
    REFERENCES Etapa (IdEtapa))

CREATE TABLE Eletrodomestico (
  IdEletrodomestico INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nome VARCHAR(50) NOT NULL)

CREATE TABLE Eletrodomestico_Etapa (
  IdEletrodomestico INT NOT NULL,
  IdEtapa INT NOT NULL,
    FOREIGN KEY (IdEletrodomestico)
    REFERENCES Eletrodomestico (IdEletrodomestico),
    FOREIGN KEY (IdEtapa)
    REFERENCES Etapa (IdEtapa))
