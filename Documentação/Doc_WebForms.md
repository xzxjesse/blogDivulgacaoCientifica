# Documentação do WebForms

## Sumário
- [Estrutura do Projeto](#estrutura-do-projeto)
  - [Arquivo Principal](#arquivo-principal)
  - [Páginas Públicas](#páginas-públicas)
  - [Acesso](#acesso)
  - [Páginas Logadas](#páginas-logadas)
- [Informações Gerais](#informações-gerais)
- [Estrutura do WebForms](#estrutura-do-webforms)

---

## Estrutura do Projeto

### Arquivo Principal

#### **Site.Master**: 
  - Arquivo que define a estrutura base e layout padrão de todas as páginas do projeto, garantindo consistência visual.

### Páginas Públicas

#### **About.aspx**: 
  - Apresenta informações sobre o projeto, incluindo seu objetivo, funcionamento e detalhes de contato.

#### **Default.aspx**: 
  - Página principal que exibe um feed de todos os artigos publicados, organizados cronologicamente.
  - **Filtros disponíveis**:
    - **Categoria**: Permite filtrar os artigos por categoria.
    - **Data**: Filtra os artigos com base na data de publicação.
    - **Texto**: Busca por palavras-chave no título e no conteúdo dos artigos.

#### **Forms.aspx**: 
  - Contém formulários para o envio de sugestões de temas e artigos.
  - **Campos obrigatórios**:
    - **Tema**: Nome, email, categoria e tema.
    - **Artigo**: Nome, email, categoria, título e conteúdo.
  - O botão de envio é ativado apenas após o preenchimento completo dos campos, com mensagens de erro ou confirmação exibidas após o envio.

### Acesso

#### **Login.aspx**: 
  - Página de login do blog, com opção para redirecionamento ao cadastro.
  - **Campos obrigatórios**: Email e senha.
  - O botão de login é ativado apenas quando os campos estão preenchidos.

#### **SignIn.aspx**: 
  - Página para o cadastro de novos usuários, com opção de redirecionamento para a página de login.
  - **Campos obrigatórios**: Nome, email e senha.
  - O botão de cadastro é ativado somente após o preenchimento de todos os campos.

### Páginas Logadas

#### **Profile.aspx**: 
  - Exibe o perfil do usuário logado, com acesso às publicações pessoais e opção de logout.

#### **MeusArtigos.aspx**: 
  - Página dedicada às publicações do usuário. 
  - **Funcionalidades**:
    - Criar nova publicação (redireciona para Publicar.aspx).
    - Editar publicações existentes através de modal.
    - Excluir publicações.

#### **Publicar.aspx**: 
  - Página para a inserção de novos artigos no blog. 
  - **Campos obrigatórios**: Título, conteúdo e categoria.
  - O botão de publicação é ativado somente após o preenchimento completo dos campos.

### Informações Gerais

- **Observações**:
  - Não há verificação de e-mails.
  - Não existem critérios definidos para senhas.

---

## Estrutura do WebForms

O projeto é estruturado seguindo o padrão das soluções WebForms, apresentando as seguintes características:

- **Model**: 
  - Definições que são baseadas no banco de dados e na API.

- **Estrutura do WebForms**:
  - **ASPX**: Interface que segue o padrão baseado na Master Page, utilizando Bootstrap para uma estilização padronizada e agradável. Scripts simples de JavaScript são aplicados conforme necessário.
  - **ASPX.CS**: Contém a lógica de negócios e os serviços que se conectam à API, facilitando a manipulação dos dados.