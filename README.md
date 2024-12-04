<h1 align="center">
    ToDoList 🚀
</h1>

<h1>
   🚀 Tecnologias
</h1>


Este projeto foi desenvolvido com as seguintes tecnologias:
- C#
- .NET 8
- Postgress
- Docker

<h1>
    💻 Como utilizar
</h1>

- Para executar esta aplicação, você precisará de [.NET] (https://dotnet.microsoft.com/pt-br/download/dotnet/7.0), [Docker] (https://docs.docker.com/engine/install/),[Visual Studio] (https://visualstudio.microsoft.com/ pt-br/), ou [Visual Studio Code] (https://code.visualstudio.com/) instalado em seu computador.

<h1>
    Docker e Banco de dados:
</h1>

- Vamos rodar o comando abaixo para verificar se o Docker está instalado corretamente:

```bash
$ docker --version
```

- Caso esteja tudo certo, você vai conseguir criar o seu container utilizando o comando abaixo:

```bash
$  cd .\Api
```
- e rode: 

```bash
$  docker-compose down docker-compose up --build
```

- Agora você precisar rodar o comando abaixo para instalar o dotnet ef:

```bash
$ dotnet tool install --global dotnet-ef
```

- Agora você precisar rodar o comando abaixo para acessar o projeto:

```bash
$ cd .\Infrastructure
```

- Agora você precisar rodar o comando abaixo para rodar suas migrations e assim, criar a database:

```bash
$ dotnet ef migrations add InitialCreate
```

- Agora, atualize sua database:

```bash
$ dotnet ef database update
```

- Agora podemos seguir para aplicação e utiliza-lá, para isso: 
```bash
$ Execute o aplicativo em modo de desenvolvimento ou digite 'dotnet run' em sua linha de comando. Abra https://localhost:8080/swagger/index.html para visualizá-lo em seu navegador.
```


<h2>
   🚀 Perguntas para o PO
</h2>


<h3>
Sobre Projetos e usuarios, poderiamos discurtir sobre a limitação de Tarefas por Projeto, o limite de 20 tarefas por projeto é uma limitação rígida ou pode ser ajustado no futuro? Haverá uma maneira de aumentar esse limite?

No caso de uma tarefa for excluida, ela deve ser permanentemente excluída ou existe a necessidade de um processo de arquivamento? 

Os relatorios de desempenho, poderiam ter a data ajustada pelo gerente?
</h3>

<h2>
   🚀 Melhorias para o Projeto
</h2>


<h3>
Poderiamos pensar em melhorias para implementação de Microsserviços, melhorando a separação de responsabilidade e seguindo os principios de SOLID. Poderiamos implementar teste de perfomace, para ver como a API se comporta com uma alta demanda de requisições. E poderiamos pensar numa esteira de CI/CD junto de AWS ou Azure DevOps
</h3>

