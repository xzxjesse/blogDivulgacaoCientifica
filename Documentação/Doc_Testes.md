# Documentação dos Testes

## Sumário
- [Introdução](#introdução)
- [Testes Implementados](#testes-implementados)
  - [Categoria](#categoria)
  - [Feed](#feed)
  - [Formulário](#formulário)
  - [Login](#login)
- [Bibliotecas Utilizadas](#bibliotecas-utilizadas)

---

## Introdução

A cobertura de testes para a **ConectaCienciaAPI** implementa 12 **testes automatizados com xUnit** que validam as operações dos controladores `CategoriaController`, `FeedController`, `FormulariosController` e `LoginController`. 

## Testes Implementados

### Categoria

#### GetTodasAsCategorias
- **Objetivo**: Validar a recuperação de todas as categorias disponíveis no banco de dados.
- **Cenário**: O teste verifica se o método `GetTodasAsCategorias` retorna corretamente uma lista de categorias.
- **Resposta Esperada**: `200 OK` com uma lista de categorias em JSON.

### Feed

#### GetTodosOsArtigos
- **Objetivo**: Validar a recuperação de todos os artigos.
- **Cenário**: O teste verifica se o método `GetTodosOsArtigos` retorna corretamente todos os artigos do banco de dados.
- **Resposta Esperada**: `200 OK` com uma lista de artigos em JSON.

#### GetArtigosPorPesquisa
- **Objetivo**: Validar a pesquisa de artigos com base em texto, categoria ou data de publicação.
- **Cenário**: O teste simula diferentes parâmetros de pesquisa e verifica a filtragem correta dos artigos.
- **Resposta Esperada**: `200 OK` com uma lista filtrada de artigos.

#### GetArtigosPorUsuario
- **Objetivo**: Validar a recuperação de artigos de um usuário específico.
- **Cenário**: O teste verifica se o método retorna corretamente todos os artigos publicados por um usuário, filtrando pelo ID.
- **Resposta Esperada**: `200 OK` com uma lista de artigos do usuário.

#### GetArtigoPorId
- **Objetivo**: Validar a recuperação de um artigo específico pelo ID.
- **Cenário**: O teste verifica se o método retorna corretamente o artigo solicitado pelo ID.
- **Resposta Esperada**: `200 OK` com os dados do artigo.

#### PostNovoArtigoComId
- **Objetivo**: Validar a criação de um novo artigo.
- **Cenário**: O teste verifica se o método `POST` adiciona corretamente um novo artigo ao banco de dados.
- **Resposta Esperada**: `201 Created` e uma mensagem de sucesso.

#### PatchAtualizarCategoriaDoArtigo
- **Objetivo**: Validar a atualização de um artigo existente.
- **Cenário**: O teste verifica se o método `PATCH` atualiza corretamente os dados de um artigo.
- **Resposta Esperada**: `200 OK` e uma mensagem de sucesso.

#### DeleteArtigoPorId
- **Objetivo**: Validar a exclusão de um artigo específico pelo ID.
- **Cenário**: O teste verifica se o método `DELETE` remove corretamente o artigo solicitado.
- **Resposta Esperada**: `200 OK` com uma mensagem de sucesso.

### Formulário

#### PostSugestaoArtigo
- **Objetivo**: Validar a adição de uma sugestão de artigo.
- **Cenário**: O teste verifica se o método `POST` adiciona corretamente uma sugestão de artigo ao sistema.
- **Resposta Esperada**: `201 Created` com uma mensagem de sucesso.

#### PostSugestaoTema
- **Objetivo**: Validar a adição de uma sugestão de tema.
- **Cenário**: O teste verifica se o método `POST` adiciona corretamente uma sugestão de tema ao sistema.
- **Resposta Esperada**: `201 Created` com uma mensagem de sucesso.

### Login

#### PostCadastroNovoUsuario
- **Objetivo**: Validar o cadastro de um novo usuário.
- **Cenário**: O teste verifica se o método `POST` cadastra corretamente um novo usuário.
- **Resposta Esperada**: `201 Created` com os dados do novo usuário.

#### GetLoginUsuario
- **Objetivo**: Validar o login de um usuário.
- **Cenário**: O teste verifica se o método `GET` autentica corretamente o usuário, validando seu e-mail e senha.
- **Resposta Esperada**: `200 OK` com os dados do usuário autenticado.

## Bibliotecas Utilizadas

Para a implementação dos testes, diversas bibliotecas e pacotes foram utilizados, incluindo:

- **xUnit**: Framework de teste usado para organizar e executar os testes, fornecendo suporte para asserções e gerenciamento de casos de teste.

- **System.Net.Http**: Usado para realizar chamadas HTTP, permitindo enviar requisições para a API.

- **System.Text**: Utilizado para manipular strings, ajudando na definição do tipo de conteúdo das requisições HTTP.

- **System.Text.Json**: Usado para serializar objetos em JSON e desserializar respostas JSON, facilitando a comunicação com a API.

Os seguintes `using` foram adicionados para a execução dos testes:

```csharp
using System.Net;
using System.Text;
using System.Net.Http.Json;
