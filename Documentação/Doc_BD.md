# Documentação do Banco de Dados

## Sumário
- [Introdução](#introdução)
- [Estrutura do Banco de Dados](#estrutura-do-banco-de-dados)
  - [Categorias](#categorias)
  - [Formulário Tema](#formulário-tema)
  - [Formulário Artigo](#formulário-artigo)
  - [Artigos](#artigos)
  - [Usuários](#usuários)
- [Relacionamentos](#relacionamentos)
- [Operações Básicas](#operações-básicas)
- [Considerações Finais](#considerações-finais)

---

## Introdução

O banco de dados **ConectaCiencia**, desenvolvido no SQL Server é projetado para gerenciar usuários, categorias de artigos científicos, sugestões de temas e artigos submetidos por usuários.

## Estrutura do Banco de Dados

### Categorias

- **Tabela**: `Categorias`
- **Descrição**: Armazena as diferentes categorias de artigos disponíveis.
- **Colunas**:
  - **id_categoria**: INT, chave primária, auto-incremental.
  - **nome_categoria**: VARCHAR(255), não nulo.

#### Criação
```sql
CREATE TABLE Categorias (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    nome_categoria VARCHAR(255) NOT NULL
);
```

### Formulário Tema

- **Tabela**: `FormularioTema`
- **Descrição**: Armazena sugestões de temas enviadas pelos usuários.
- **Colunas**:
  - **id_sugestao_tema**: INT, chave primária, auto-incremental.
  - **nome**: VARCHAR(255), não nulo.
  - **email**: VARCHAR(255), não nulo.
  - **tema**: VARCHAR(255), não nulo.
  - **id_categoria**: INT, chave estrangeira que referencia `Categorias(id_categoria)`.

#### Criação
```sql
CREATE TABLE FormularioTema (
    id_sugestao_tema INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    tema VARCHAR(255) NOT NULL,
    id_categoria INT,
    CONSTRAINT FK_FormularioTema_Categoria FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);
```

### Formulário Artigo

- **Tabela**: `FormularioArtigo`
- **Descrição**: Armazena sugestões de artigos enviadas pelos usuários.
- **Colunas**:
  - **id_sugestao_artigo**: INT, chave primária, auto-incremental.
  - **nome**: VARCHAR(255), não nulo.
  - **email**: VARCHAR(255), não nulo.
  - **titulo**: VARCHAR(255), não nulo.
  - **conteudo**: TEXT, não nulo.
  - **id_categoria**: INT, chave estrangeira que referencia `Categorias(id_categoria)`.

#### Criação
```sql
CREATE TABLE FormularioArtigo (
    id_sugestao_artigo INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    titulo VARCHAR(255) NOT NULL,
    conteudo TEXT NOT NULL,
    id_categoria INT,
    CONSTRAINT FK_FormularioArtigo_Categoria FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);
```

### Artigos

- **Tabela**: `Artigos`
- **Descrição**: Armazena os artigos submetidos, com informações sobre título, conteúdo e autor.
- **Colunas**:
  - **id_artigo**: INT, chave primária, auto-incremental.
  - **data**: DATETIME, não nulo, valor padrão `GETDATE()`.
  - **titulo**: VARCHAR(255), não nulo.
  - **conteudo**: TEXT, não nulo.
  - **nome**: VARCHAR(255), não nulo.
  - **id_categoria**: INT, chave estrangeira que referencia `Categorias(id_categoria)`.
  - **id_usuario**: INT, chave estrangeira que referencia `Usuarios(id_usuario)`.

#### Criação
```sql
CREATE TABLE Artigos (
    id_artigo INT PRIMARY KEY IDENTITY(1,1),
    data DATETIME NOT NULL DEFAULT GETDATE(),
    titulo VARCHAR(255) NOT NULL,
    conteudo TEXT NOT NULL,
    nome VARCHAR(255) NOT NULL,
    id_categoria INT,
    id_usuario INT,
    CONSTRAINT FK_Artigos_Categorias FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria),
    CONSTRAINT FK_Artigos_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);
```

### Usuários

- **Tabela**: `Usuarios`
- **Descrição**: Armazena informações dos usuários que submetem artigos e sugestões.
- **Colunas**:
  - **id_usuario**: INT, chave primária, auto-incremental.
  - **nome**: VARCHAR(255), não nulo.
  - **email**: VARCHAR(255), não nulo, único.
  - **senha**: VARCHAR(255), não nulo.

#### Criação
```sql
CREATE TABLE Usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL
);
```

## Relacionamentos

- **Categorias** são referenciadas por:
  - **FormularioTema** (id_categoria)
  - **FormularioArtigo** (id_categoria)
  - **Artigos** (id_categoria)
- **Usuarios** são referenciados por:
  - **Artigos** (id_usuario)

## Inserção de dados

### Inserir Categoria
```sql
INSERT INTO Categorias (nome_categoria) 
VALUES 
    ('Física'),
    ('Biologia'),
    ('Química'),
    ('Astronomia'),
    ('Tecnologia');
```

### Inserir Formulário de Tema
```sql
INSERT INTO FormularioTema (nome, email, tema, id_categoria) 
VALUES 
    ('Carlos Souza', 'carlos.souza@email.com', 'O impacto da física quântica no cotidiano', 1), 
    ('Ana Oliveira', 'ana.oliveira@email.com', 'A evolução dos sistemas biológicos no ambiente urbano', 2),
    ('João Santos', 'joao.santos@email.com', 'Avanços recentes na química ambiental', 3),
    ('Mariana Lima', 'mariana.lima@email.com', 'A origem e evolução do universo', 4),
    ('Pedro Almeida', 'pedro.almeida@email.com', 'Inovações tecnológicas na medicina', 5);
```

### Inserir Formulário de Artigos
```sql
INSERT INTO FormularioArtigo (nome, email, titulo, conteudo, id_categoria) 
VALUES 
    ('Fernanda Silva', 'fernanda.silva@email.com', 'O poder dos aceleradores de partículas', 
     'Uma discussão sobre o impacto dos aceleradores de partículas em nossa compreensão da física.', 1), 
    ('Ricardo Pereira', 'ricardo.pereira@email.com', 'A genética no combate a doenças', 
     'Como os avanços em genética têm contribuído para a cura de doenças complexas.', 2),
    ('Juliana Costa', 'juliana.costa@email.com', 'Novos materiais para a química sustentável', 
     'Estudos recentes sobre compostos químicos que podem revolucionar o desenvolvimento sustentável.', 3),
    ('Lucas Matos', 'lucas.matos@email.com', 'Exploração do sistema solar', 
     'Uma análise das missões espaciais e os principais desafios da exploração interplanetária.', 4),
    ('Paula Nunes', 'paula.nunes@email.com', 'Tecnologia de impressão 3D em próteses', 
     'Como a impressão 3D está revolucionando a criação de próteses mais acessíveis.', 5);
```

### Inserir Usuário
```sql
INSERT INTO Usuarios (nome, email, senha) 
VALUES
    ('João Silva', 'joao.silva@example.com', 'senhaDoJoao'),
    ('Maria Souza', 'maria.souza@example.com', 'Maria123'),
    ('Carlos Lima', 'carlos.lima@example.com', 'SenhaSecreta');
```

### Inserir Artigos
```sql
INSERT INTO Artigos (data, titulo, conteudo, nome, id_categoria, id_usuario) 
VALUES 
    ('2024-03-10T16:00:00', 'Mudanças Climáticas e Seus Efeitos na Biodiversidade', 
     'As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.', 
     'Maria Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Biologia'), 2), 

    ('2024-01-15T10:00:00', 'A Teoria das Cordas: uma revolução na física', 
     'Este artigo explora os fundamentos da Teoria das Cordas, uma proposta revolucionária na física teórica. A teoria sugere que as partículas fundamentais do universo não são pontos, mas sim pequenas cordas vibrantes que oscilam em diferentes modos. Esta visão alternativa tenta unir a mecânica quântica e a relatividade geral, oferecendo uma possível solução para o problema da gravidade quântica. A teoria das cordas também sugere a existência de dimensões adicionais além das conhecidas quatro dimensões do espaço-tempo. Vamos discutir como essa teoria pode resolver problemas antigos e abrir novas possibilidades para a física moderna. A análise abrange desde a origem da teoria até suas implicações para a física de partículas e cosmologia.', 
     'Carlos Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física'), 3),  

    ('2024-02-20T14:30:00', 'Explorando a Antimatéria: O que é e por que é importante?', 
     'A antimatéria é uma das áreas mais fascinantes e misteriosas da física moderna. Quando partículas de antimatéria se encontram com partículas de matéria, elas se aniquilam mutuamente, liberando uma quantidade de energia imensa. Este artigo explora o conceito de antimatéria, como ela é criada e estudada, e o papel que pode desempenhar em futuras tecnologias e na compreensão do universo. Investigamos também como a antimatéria pode ser utilizada em tratamentos médicos e em futuras viagens espaciais.', 
     'Maria Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física'), 2),  

    ('2024-03-01T09:00:00', 'A Origem do Universo: Uma Revisão das Teorias Cosmológicas', 
     'Neste artigo, revisamos as principais teorias sobre a origem do universo, desde o Big Bang até teorias mais recentes como o modelo do multiverso. Analisamos como as evidências astronômicas e experimentais sustentam ou contestam essas teorias e discutimos as implicações para o futuro da cosmologia. O artigo também explora como diferentes culturas e tradições entenderam a origem do cosmos e o impacto dessas visões sobre a ciência moderna.', 
     'João Silva', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Astronomia'), 1);  
```