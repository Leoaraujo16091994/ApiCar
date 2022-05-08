# ApiCar



Aplicação utilizando o padrão MVC de Carro feita em .Net Core 3.1, Entity Framework e Banco Sql.


Você deve possuir instalado previamente na sua máquina :
- Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64) (link -> https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Se desejar baixar o Sql Server Management Studio: https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15 ou utilize a ferramenta de administração de banco de dados desejada.
- .NET Core 3.1 ( link -> https://dotnet.microsoft.com/en-us/download/dotnet/3.1 )




Como susbir a aplicação :
- Clonar o repositório na pasta desejada.
- Baixar os pacotes no nuget.
- Alterar a DefaultConnection na aba ConnectionStrings do Appsettings.json. 
- Alterar o optionsBuilder.UseSqlServer() no OnConfiguring no arquivo CarContext.
- Executar o projeto.



Pacotes do nuget necessários:
- Microsoft.EntityFrameworkCore.Design v3.1.24
- Microsoft.EntityFrameworkCore.SqlLite v3.1.24
- Microsoft.EntityFrameworkCore.SqlServer v3.1.24
- Microsoft.EntityFrameworkCore.SqlServer.Design v1.1.16
- Microsoft.EntityFrameworkCore.Tools v3.1.4




Documentação para alterar a connection string e optionsBuilder.

SqlConnection (.NET)

Conexão padrão utilizando Login e Senha do SQL

**Data Source=meuServidor; Initial Catalog=CarroApp; User Id=NomeUsuario; Password=SenhaUsuario;** 

ou

**Server=meuServidor; Database=CarroApp; User ID=NomeUsuario; Password=SenhaUsuario; Trusted_Connection=False;**

Conexão utilizando " Conexão Segura via Windows"

**Data Source=meuServidor; Initial Catalog=CarroApp; Integrated Security=SSPI;**

ou

**Server=meuServidor; Database=CarroApp; Trusted_Connection=True;**
