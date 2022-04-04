# API-InvitaTech

API REST - CRUD Cliente e Endereço utilização do Entity Framework Core e Migrations (criação do Banco de dados code first).

Banco de dados utilizado SQL Server - Script do banco de dados indexado ao repositório (caso seja necessário).


## Alteração necessárias para funcionamento em seu computador

Dentro da biblioteca de classe "Repositório" abra o arquivo "LoremIpsumDBContext.cs" e altere a string de conexão para acessar seu SQL Server.

Com isso você conseguirá efetuar a criação do banco de dados e suas respectivas tabelas.
Execute o comando "Update-Database Initial" no Console do Gerenciador de Pacotes de seu Visual Studio.


