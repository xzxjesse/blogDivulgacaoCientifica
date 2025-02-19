# Estrutura do Banco de Dados

## Versão 1

### 1. **Tabela: Formulário Tema**
> Armazena as sugestões de temas enviadas pelos usuários.

| Campo             | Tipo            | Descrição                     |
|------------------|----------------|--------------------------------|
| `id_sugestao_tema` | `int` (PK)      | Identificador único da sugestão |
| `nome`           | `varchar(255)`  | Nome do usuário                |
| `email`          | `varchar(255)`  | Email do usuário               |
| `tema`           | `varchar(255)`  | Tema sugerido                  |
| `id_categoria`   | `int` (FK)      | Categoria relacionada (FK → Categorias) |

---

### 2. **Tabela: Formulário Artigo**
> Armazena as sugestões de artigos enviadas pelos usuários.

| Campo               | Tipo           | Descrição                           |
|--------------------|---------------|------------------------------------|
| `id_sugestao_artigo` | `int` (PK)    | Identificador único da sugestão    |
| `nome`             | `varchar(255)` | Nome do usuário                    |
| `email`            | `varchar(255)` | Email do usuário                   |
| `titulo`           | `varchar(255)` | Título do artigo sugerido          |
| `conteudo`         | `text`         | Conteúdo do artigo sugerido        |
| `id_categoria`     | `int` (FK)     | Categoria relacionada (FK → Categorias) |

---

### 3. **Tabela: Artigos**
> Armazena os artigos publicados no blog.

| Campo        | Tipo           | Descrição                                      |
|------------|---------------|-------------------------------------------------|
| `id_artigo` | `int` (PK)    | Identificador único do artigo                  |
| `data`      | `datetime`    | Data da publicação                             |
| `titulo`    | `varchar(255)` | Título do artigo                              |
| `conteudo`  | `text`        | Conteúdo do artigo                            |
| `nome`      | `varchar(255)` | Nome do autor (futuramente FK para Usuários) |

---

### 4. **Tabela: Categorias**
> Armazena as categorias usadas para filtrar temas, artigos e sugestões.

| Campo          | Tipo           | Descrição                          |
|--------------|---------------|----------------------------------|
| `id_categoria` | `int` (PK)    | Identificador único da categoria |
| `nome_categoria` | `varchar(255)` | Nome da categoria               |

---

## Versão 2

### 5. **Tabela: Usuário**
> Armazena os dados de usuários autenticados no sistema.

| Campo        | Tipo           | Descrição                      |
|------------|---------------|------------------------------|
| `id_usuario` | `int` (PK)    | Identificador único do usuário |
| `nome`      | `varchar(255)` | Nome completo do usuário       |
| `email`     | `varchar(255)` (Unique) | Email do usuário (único) |
| `senha`     | `varchar(255)` | Senha criptografada           |
