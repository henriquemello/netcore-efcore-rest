# Net Core EF Core Rest
Criação de REST API com ASP.NET Core 2.2, EF Core, Migrations, Docker, Repository Pattern, MVC, View Models, Swagger Documentation


## DOCKER
Para utilizar o container do SQL Server para ser acesso e consumido pela API deve criar o container abaixo:


>Aceitar o EULA, Definir senha do SA, porta padrão.

``
$ sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1q2w3e!@#' -e 'MSSQL_PID=Express' -p 1433:1433 -d microsoft/mssql-server-linux:latest
``

#### Para mostrar todos os containers:
``
sudo docker ps -a
``

#### Subir o container:
``
sudo docker start [ID_CONTAINER]
``

#### Parar o container:
``
sudo docker stop [ID_CONTAINER]
``

## .NET CORE
Para rodar a aplicação deve-se efetuar restore das dependências, compilar e rodar o projeto:

**Neste ponto se atentar a string de conexão, usuário e senha que estão dentro do arquivo StoreDataContext de acordo com a criação do seu Container.**
> dotnet restore

> dotnet build

> dotnet run


## Postman

### CRUD Categorias

>GET http://localhost:5000/v1/categories

>GET http://localhost:5000/v1/categories/2

#### Utilizar no header:  **Content-Type: application/json**
>POST http://localhost:5000/v1/categories

``
{
	title:"Turismo 2"
}
``

>PUT http://localhost:5000/v1/categories

``
{
	id:1,
	title:"Video Games"
}
``

>DEL http://localhost:5000/v1/categories

``
{
	id:4
}
``

### CRUD Produtos



> GET http://localhost:5000/v1/products

> GET http://localhost:5000/v1/products/2

#### Utilizar no header:  **Content-Type: application/json**
> POST http://localhost:5000/v1/products

``
  {
	"title":"Novo Produto",
	"description":"ABNT2 pt-BR",
	"price":220,
	"quantity":5,
	"image":"url da imagem..",
	"categoryId":1
  }
``

> PUT http://localhost:5000/v1/products

``
  {
	"id": 1
	"title":"accccccb",
	"description":"ABNT pt-BR",
	"price":110,
	"quantity":10,
	"image":"url da imagem..",
	"categoryId":1
  }
``


> DEL http://localhost:5000/v1/products

``
{
	id:4
}
``








