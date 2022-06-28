CREATE DATABASE escola;

CREATE TABLE Turma
(Id INT IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(500) NOT NULL,
Ativo BIT NOT NULL);

CREATE TABLE Aluno
(Id INT IDENTITY (1,1) PRIMARY KEY,
Nome VARCHAR (200) NOT NULL,
Data_Nascimento DATETIME,
Sexo CHAR,
Turma_Id  INT,
Total_Faltas INT,
Ativo BIT);