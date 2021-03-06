using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCar.Migrations
{
    public partial class InsertDados : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            InserirDados(migrationBuilder);
        }
                           

        public void InserirDados(MigrationBuilder migrationBuilder) {

            migrationBuilder.Sql(

            @"
        USE [CarroApp]
        GO

		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (12,50,35,420,1,168,20291,NULL,1,'2022-05-20 00:41:00.0000000',NULL,'2022-05-07 00:41:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (12,25,14,108,2,168,20291,NULL,1,'2022-05-20 00:41:00.0000000',NULL,'2022-05-07 00:41:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (40,40,10,80,3,400,24309,NULL,1,'2022-05-07 00:42:00.0000000',NULL,'2022-05-07 00:42:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (14,50,24,70,4,336,5000,NULL,1,'2022-05-07 00:43:00.0000000',NULL,'2022-05-07 00:43:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (18,60,38,65,5,684,70000,NULL,1,'2022-05-07 00:45:00.0000000',NULL,'2022-05-07 00:45:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (92,25,20,80,6,1840,25730,NULL,1,'2022-05-07 00:45:00.0000000',NULL,'2022-05-07 00:46:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (20,44,40,60,7,800,87378,NULL,1,'2022-05-07 00:47:00.0000000',NULL,'2022-05-07 00:47:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (48,52,30,80,8,1440,10849,NULL,1,'2022-05-07 00:47:00.0000000',NULL,'2022-05-07 00:47:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (79,48,5,45,9,395,56778,NULL,1,'2022-05-07 00:47:00.0000000',NULL,'2022-05-07 00:47:00.0000000');
		    INSERT INTO [dbo].[Carro] ([Km],[CapacidadeTanque],[QtsLitrosNoTanque],[VelocidadeMedia],[Modelo],[Autonomia] ,[Preco] ,[Ativo],[CriadoPor],[DataCriacao],[ModificacaoPor],[DataModificacao]) VALUES (8,848,8,8,10,64,18797,NULL,1,'2022-05-08 09:13:00.0000000',NULL,'2022-05-08 09:13:00.0000000');
        ");


        }

    }
}
