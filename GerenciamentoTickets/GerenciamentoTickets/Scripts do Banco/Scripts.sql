-- Criando o banco de dados

create database GerenciamentoTickets;

-- Criando tabelas
-- Funcionario

CREATE TABLE Funcionario (
    idfuncionario INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    cpf VARCHAR(14) unique NOT NULL,
    situacao CHAR(1) NOT NULL DEFAULT 'A',
    dataalteracao DATETIME NOT NULL DEFAULT GETDATE()
);

-- Ticket

CREATE TABLE Ticket (
    idticket INT IDENTITY(1,1) PRIMARY KEY,
    idfuncionario INT NOT NULL UNIQUE,
    quantidade INT NOT NULL,
    situacao CHAR(1) NOT NULL DEFAULT 'A',
    datamodificacao DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Ticket_Funcionario FOREIGN KEY (idfuncionario) REFERENCES Funcionario(idfuncionario)
);
