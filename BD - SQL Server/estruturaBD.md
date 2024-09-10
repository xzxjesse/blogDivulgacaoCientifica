# Estrutura do Banco de dados

## Versão 1
### 1. **Tabela: Formulário Tema**
Armazena as sugestões de temas enviadas pelos usuários.
- `id_sugestao_tema` (int, PK)
- `nome` (varchar(255))
- `email` (varchar(255))
- `tema` (varchar(255))
- `id_categoria` (int, FK -> Categorias)

### 2. **Tabela: Formulário Artigo**
Armazena as sugestões de artigos enviadas pelos usuários.
- `id_sugestao_artigo` (int, PK)
- `nome` (varchar(255))
- `email` (varchar(255))
- `titulo` (varchar(255))
- `conteudo` (text)
- `id_categoria` (int, FK -> Categorias)

### 3. **Tabela: Artigos**
Armazena os artigos publicados no blog.
- `id_artigo` (int, PK)
- `data` (datetime)
- `titulo` (varchar(255))
- `conteudo` (text)
- `nome` (varchar(255)) – futuramente um FK para a tabela de Usuário

### 4. **Tabela: Categorias**
Armazena as categorias usadas para filtrar temas, artigos, e sugestões.
- `id_categoria` (int, PK)
- `nome_categoria` (varchar(255))

---
## Versão 2

### 5. **Tabela: Usuário**
Armazena os dados de usuários autenticados no sistema.
- `id_usuario` (int, PK)
- `nome` (varchar(255))
- `email` (varchar(255), Unique)
- `senha` (varchar(255))