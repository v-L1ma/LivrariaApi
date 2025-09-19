📚 Livraria API

Um sistema de livraria onde podemos gerenciar autores e livros. Esse projeto foi base de estudos para que eu pudesse revisar sobre APIs .NET, CRUD, SQL Server, Entity FrameWork, Repository pattern e documentação com Swagger.

APIs RESTful com .NET

SQL Server

Entity Framework Core

Repository Pattern

Documentação com Swagger


🚀 Tecnologias Utilizadas

.NET 6 ou superior

Entity Framework Core

SQL Server

Swagger / Swashbuckle

Repository Pattern

📌 Funcionalidades da API

🔹 Autor

| Endpoint                                  | Descrição                                                     |
| ------------------------------------- | ------------------------------------------------------------- |
| <kbd>GET /Autor</kbd>                 | Exibe uma lista de todos os autores                           |
| <kbd>POST /Autor</kbd>                | Cadastra um novo autor                                        |
| <kbd>GET /Autor/{idAutor}</kbd>       | Retorna os detalhes de um autor pelo ID                       |
| <kbd>PUT /Autor/{idAutor}</kbd>       | Atualiza os dados de um autor existente                       |
| <kbd>DELETE /Autor/{idAutor}</kbd>    | Remove um autor do sistema                                    |
| <kbd>GET /Autor/livro/{idLivro}</kbd> | Retorna o autor de um livro específico (usando o ID do livro) |

🔹 Livro

| Rota                                  | Descrição                                              |
| ------------------------------------- | ------------------------------------------------------ |
| <kbd>GET /Livro</kbd>                 | Exibe uma lista de todos os livros                     |
| <kbd>POST /Livro</kbd>                | Cadastra um novo livro                                 |
| <kbd>GET /Livro/{idLivro}</kbd>       | Retorna os detalhes de um livro pelo ID                |
| <kbd>PUT /Livro/{idLivro}</kbd>       | Atualiza os dados de um livro existente                |
| <kbd>DELETE /Livro/{idLivro}</kbd>    | Remove um livro do sistema                             |
| <kbd>GET /Livro/autor/{idAutor}</kbd> | Lista todos os livros escritos por um autor específico |

🛠️ Como executar o projeto

Clone o repositório:
```bash
git clone https://github.com/v-L1ma/LivrariaApi
```


Abra a solução no Visual Studio ou VS Code.

Configure a connection string para o SQL Server no arquivo appsettings.json.

Execute as migrações do Entity Framework:
```bash
dotnet ef database update
```

Rode o projeto:
```bash
dotnet run
```

Acesse a documentação Swagger:
```bash
http://localhost:5254/swagger/index.html
```
📄 Documentação

A API conta com documentação interativa através do Swagger. Você pode testar todas as rotas diretamente por meio da interface web após rodar o projeto.
