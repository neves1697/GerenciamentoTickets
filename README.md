# GerenciamentoTickets

Projeto de gerenciamento de tickets por funcionários.

Foi utilizado o tipo de projeto "Aplicativo de Console".

Utilizei a arquitetura (MVC) para separação do código. 
Para a manipuilação do banco de dados, usei o DbContext e a forma de encapsulamento DAL
Para este projeto usei o banco de dados SQLSERVER instalado no Visual Studio e os pacotes do EntityFramework. Abaixo script para instalação.
- Instalando SQLSERVER
  - <pre>Install-Package Microsoft.EntityFrameworkCore.SqlServer</pre>
  - <pre>dotnet add package Microsoft.EntityFrameworkCore.SqlServer</pre>
- Instalando EntityFrameworkCore.Proxies e Tools
  - <pre>dotnet add package Microsoft.EntityFrameworkCore.Proxies</pre>
  - <pre>dotnet add package Microsoft.EntityFrameworkCore.Tools</pre>

Scripts do Banco de Dados

- Criando o banco
  ```sql
  create database GerenciamentoTickets;
  ```
- Criando tabelas
  - Funcionario
    ```sql
    CREATE TABLE Funcionario (
    idfuncionario INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    cpf VARCHAR(14) unique NOT NULL,
    situacao CHAR(1) NOT NULL DEFAULT 'A',
    dataalteracao DATETIME NOT NULL DEFAULT GETDATE());
  - Ticket
    ```sql
    CREATE TABLE Ticket (
    idticket INT IDENTITY(1,1) PRIMARY KEY,
    idfuncionario INT NOT NULL UNIQUE,
    quantidade INT NOT NULL,
    situacao CHAR(1) NOT NULL DEFAULT 'A',
    datamodificacao DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Ticket_Funcionario FOREIGN KEY (idfuncionario) REFERENCES Funcionario(idfuncionario));
