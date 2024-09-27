# Documentação da API

## Sumário
- [ConectaCienciaAPI](#conecta-ciencia-api)
- [Recursos da API](#recursos-da-api)
  - [Categorias](#categorias)
  - [Feed](#feed)
  - [Formulários](#formulários)
  - [Login e Cadastro](#login-e-cadastro)

---

## Conecta Ciencia API

A **Conecta Ciencia API** é uma **API Web em ASP.NET Core** baseada no padrão **MVC**, que fornece endpoints para acessar e manipular tabelas de categorias, artigos, formulários de sugestões e usuários no banco de dados. Seus **endpoints são consumidos pelo WebForms** do blog Conecta Ciência, permitindo a integração entre as interfaces do blog e os dados. A API segue os **princípios RESTful**, utilizando **JSON como formato** para as requisições e respostas. Foi desenvolvida com **ADO.NET** e utiliza **parameters para prevenir SQL injection**, garantindo a segurança nas consultas e manipulações de dados.

---

## Recursos da API

### Categorias

#### Listar Categorias

Retorna uma lista de todas as categorias disponíveis.

- **Endpoint**: `GET /api/Categoria`
- **Parâmetros**: Nenhum
- **Resposta**:
  - **Status**: `200 OK`
  - **Exemplo**:
    ```json
    [
        {
            "id_Categoria": 1,
            "nome_Categoria": "Física"
        },
        {
            "id_Categoria": 2,
            "nome_Categoria": "Biologia"
        }
    ]
    ```

### Feed

#### Pesquisar Artigos

Busca artigos com filtros opcionais de texto, nome de categoria e data de publicação.

- **Endpoint**: `GET /api/Feed`
- **Parâmetros (Query)**:
  - `textoPesquisa`: Filtro por palavras no texto
  - `nomeCategoria`: Filtro por categoria do artigo
  - `dataPublicacao`: Filtro pela data de publicação do artigo
- **Resposta**:
  - **Status**: `200 OK`
  - **Exemplo**:
    ```json
    [
        {
            "id_Artigo": 1,
            "data": "2024-03-10T16:00:00",
            "titulo": "Mudanças Climáticas e Seus Efeitos na Biodiversidade",
            "conteudo": "As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.",
            "categoria": {
                "id_Categoria": 2,
                "nome_Categoria": "Biologia"
            },
            "usuario": {
                "id_Usuario": 2,
                "nome": "Maria Souza"
            }
        }
    ]
    ```

#### Pesquisar Artigos por Usuários

Retorna todos os artigos publicados por um usuário específico, identificado pelo ID.

- **Endpoint**: `GET /api/Feed/MeusArtigos`
- **Parâmetros (Query)**:
  - `id_usuario`: ID do usuário que publicou os artigos
- **Resposta**:
  - **Status**: `200 OK`
  - **Exemplo**:
    ```json
    [
        {
            "id_Artigo": 4,
            "data": "2024-03-01T09:00:00",
            "titulo": "A Origem do Universo: Uma Revisão das Teorias Cosmológicas",
            "conteudo": "Neste artigo, revisamos as principais teorias sobre a origem do universo, desde o Big Bang até teorias mais recentes como o modelo do multiverso. Analisamos como as evidências astronômicas e experimentais sustentam ou contestam essas teorias e discutimos as implicações para o futuro da cosmologia. O artigo também explora como diferentes culturas e tradições entenderam a origem do cosmos e o impacto dessas visões sobre a ciência moderna.",
            "categoria": {
                "id_Categoria": 4,
                "nome_Categoria": "Astronomia"
            },
            "usuario": {
                "id_Usuario": 1,
                "nome": "João Silva"
            }
        }
    ]
    ```

#### Pesquisar Artigo por ID de Artigo

Obtém um artigo específico pelo ID.

- **Endpoint**: `GET /api/Feed/Artigo/{id}`
- **Parâmetros (URL)**:
  - `id`: ID do artigo
- **Resposta**:
  - **Status**: `200 OK`
  - **Exemplo**:
    ```json
    {
        "id_Artigo": 1,
        "data": "2024-03-10T16:00:00",
        "titulo": "Mudanças Climáticas e Seus Efeitos na Biodiversidade",
        "conteudo": "As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.",
        "categoria": {
            "id_Categoria": 2,
            "nome_Categoria": "Biologia"
        },
        "usuario": {
            "id_Usuario": 2,
            "nome": "Maria Souza"
        }
    }
    ```

#### Adicionar Artigo

Adiciona um novo artigo ao sistema.

- **Endpoint**: `POST /api/Feed/Artigo`
- **Exemplo**:
  ```json
    {
        "id_Artigo": 0,
        "data": "2024-09-24T18:53:08.185Z",
        "titulo": "string",
        "conteudo": "string",
        "categoria": {
            "id_Categoria": 0,
            "nome_Categoria": "string"
        },
        "usuario": {
            "id_Usuario": 0,
            "nome": "string"
        }
    }
  ```
- **Resposta**:
  - **Status**: `200 OK`
  - **Texto**: `"Publicação adicionada com sucesso."`

#### Alterar Artigo

Atualiza um artigo existente, de acordo com o id dele.

- **Endpoint**: `PATCH /api/Feed/Artigo/Patch/{id}`
- **Parâmetros (URL)**:
  - `id`: ID do artigo
- **Exemplo**:
  ```json
    {
        "id_Artigo": 0,
        "data": "2024-09-24T18:57:04.421Z",
        "titulo": "string",
        "conteudo": "string",
        "categoria": {
            "id_Categoria": 0,
            "nome_Categoria": "string"
        },
        "usuario": {
            "id_Usuario": 0,
            "nome": "string"
        }
    }
  ```
- **Resposta**:
  - **Status**: `200 OK`
  - **Texto**: `"Publicação atualizada com sucesso."`

#### Excluir Artigo

Remove um artigo pelo ID.

- **Endpoint**: `DELETE /api/Feed/Artigo/Delete/{id}`
- **Parâmetros (URL)**:
  - `id`: ID do artigo
- **Resposta**:
  - **Status**: `200 OK`
  - **Texto**: `"Publicação deletada com sucesso."`

### Formulários

#### Adicionar Tema

Permite que o usuário sugira um tema para futuros artigos.

- **Endpoint**: `POST /api/Formularios/tema`
- **Exemplo**:
  ```json
    {
        "idSugestaoTema": 0,
        "nome": "string",
        "email": "string",
        "tema": "string",
        "id_Categoria": 0,
        "categoria": {
            "id_Categoria": 0,
            "nome_Categoria": "string"
        }
    }
  ```
- **Resposta**:
  - **Status**: `200 OK`
  - **Texto**: `"Sugestão de tema adicionada com sucesso."`

#### Adicionar Artigo

Permite que o usuário sugira um artigo para futuras publicações.

- **Endpoint**: `POST /api/Formularios/artigo`
- **Exemplo**:
  ```json
    {
        "idSugestaoArtigo": 0,
        "nome": "string",
        "email": "string",
        "titulo": "string",
        "conteudo": "string",
        "id_Categoria": 0,
        "categoria": {
            "id_Categoria": 0,
            "nome_Categoria": "string"
        }
    }
  ```
- **Resposta**:
  - **Status**: `200 OK`
  - **Texto**: `"Sugestão de artigo adicionada com sucesso."`

### Login e Cadastro

#### Realizar Login

Valida o e-mail e a senha de um usuário para login.

- **Endpoint**: `GET /api/Login/login`
- **Parâmetros (Query)**:
  - `email`: string (obrigatório)
  - `senha`: string (obrigatório)
- **Resposta**:
  - **Status**: `200 OK`
  - **Exemplo**:
    ```json
    {
      "id_usuario": 1,
      "nome": "João da Silva"
    }
    ```

#### Registrar Usuário

Cadastra um novo usuário no sistema.

- **Endpoint**: `POST /api/Login/cadastro`
- **Exemplo**:
  ```json
  {
    "nome": "string",
    "email": "string",
    "senha": "string"
  }
  ```
- **Resposta**:
  - **Status**: `201 Created`
  - **Corpo**: `{ "id_usuario": 1, "nome": "João da Silva" }`
