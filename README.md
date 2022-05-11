# ApiCar


Aplicação utilizando o padrão MVC de Carro feita em .Net Core 3.1, Entity Framework e Banco Sql.


Você deve possuir instalado previamente na sua máquina :
- Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64) (link -> https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Se desejar baixar o Sql Server Management Studio: https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15 ou utilize a ferramenta de administração de banco de dados desejada.
- .NET Core 3.1 ( link -> https://dotnet.microsoft.com/en-us/download/dotnet/3.1 )




Como subir a aplicação :
- Clonar o repositório na pasta desejada.
- Baixar os pacotes no nuget.
- Alterar a DefaultConnection na aba ConnectionStrings do Appsettings.json. 
- Alterar o optionsBuilder.UseSqlServer() no OnConfiguring no arquivo CarContext.
- Executar o projeto.
- O projeto será aberto no navegador na url disponibilizando o swagger : https://localhost:5001/index.html


Se desejar usar o postman,disponibilizei a collection com as requisições no arquivo ApiCarro.postman_collection.json .

Como rodar através do docker :  
**OBS : Esses comandos devem ser executados onde se encontra o arquivo DockerFile do projeto.**
 - Alterar o DefaultConnection na aba ConnectionStrings do Appsettings.json :
	"DefaultConnection": "Server=host.docker.internal; Database=CarroApp;User Id={inserirAquiOUsarioDoSeuBanco};Password={inserirAquiOPasswordDoSeuBanco};"
 - Alerar o optionsBuilder.UseSqlServer no CarContext :
	 optionsBuilder.UseSqlServer("Server=host.docker.internal; Database=CarroApp;User Id={inserirAquiOUsarioDoSeuBanco};Password={inserirAquiOPasswordDoSeuBanco};");
- Buildar a imagem:
	docker build -t apicar:01  .
- Subir o container : 
	docker run --name container-apicar-01 -p 5010:80 apicar:01
- O projeto será aberto no navegador na url disponibilizando o swagger : https://localhost:5010/index.html

