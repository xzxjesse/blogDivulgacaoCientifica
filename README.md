# **MVP: Blog de Divulgação Científica**

**Academia .Net**  
**Projeto Final - .NET Core**  
**Autora: Jéssica Eveline**

---

## **Proposta**

O **Blog de Divulgação Científica** é uma plataforma destinada a tornar o acesso a artigos científicos mais interativo e acessível. O propósito é criar um espaço onde pesquisadores, professores e estudantes possam compartilhar e explorar conhecimento científico de maneira dinâmica, buscando promover uma experiência colaborativa. O objetivo é transformar o site em um ponto de encontro para o compartilhamento de conhecimento e discussões científicas.

---

## **Público-Alvo**

### **Professores**
- **Faixa etária**: Adultos e idosos.
- **Interesse**: Desenvolvimento de materiais educativos para a comunidade acadêmica ou não.
- **Motivações**:
  - Modernizar os conteúdos.
  - Tornar acessíveis os temas trabalhados em aula.
  - Implementar abordagens interativas em aula.

### **Estudantes Universitários**
- **Faixa etária**: Adultos e idosos.
- **Interesse**: Praticar as ideias desenvolvidas em aula e contribuir para a divulgação científica.
- **Motivações**:
  - Acessar materiais já produzidos.
  - Enriquecer o currículo com contribuições científicas.
  - Sugerir temas para serem abordados em aula e no blog.

---

## **Funcionalidades**

### **Essenciais:**
- **Sobre**: Página que apresenta o objetivo do blog e informações sobre os autores.
- **Feed de Artigos**: Exibição de todos os artigos publicados, organizados cronologicamente.
- **Filtros**: Filtragem por categoria, palavra-chave ou data.
- **Sugerir Publicação**: Formulário para sugerir novos temas ou tópicos.
- **Sugerir Tema**: Opção para que os leitores sugiram temas para postagens futuras.

### **Desejáveis:**
- **Login**: Sistema de autenticação para criação de contas e acesso a funcionalidades exclusivas.
- **Publicar Artigos**: Usuários autenticados podem criar e publicar seus próprios artigos.
- **Acessar Artigos**: Usuários autenticados podem visualizar seus artigos publicados.
- **Editar Publicação**: Usuários podem editar suas próprias postagens.
- **Apagar Publicação**: Exclusão de postagens pessoais, restrita ao autor.
- **Curtir Artigos**: Usuários conectados podem curtir postagens.
- **Comentar Artigos**: Área de comentários para discussão entre leitores e autores.
- **Chat Privado**: Sistema de mensagens privadas entre usuários autenticados.

### **Não Desejáveis:**
- **Verificação de Artigos Publicados**: Não é necessário verificar se os artigos foram publicados em revistas acadêmicas.
- **Verificação de Plágio**: Sem prioridade para a implementação de sistemas automáticos de verificação de plágio ou IA.
- **Total de Visualizações no Post**: Não exibe o número de visualizações dos artigos.

---

## **Roteiro**
[Trello de Gerenciamento de etapas](https://trello.com/invite/b/66df81376f95a28c3d95be36/ATTIc2a800e06ddbc3e3669f7e63b252fd0553F48520/projeto-final-net)

### **Semana 1:**

#### **09/09 - Configuração Inicial**
- Documentar proposta. ✔️
- Criar WebForms e organizar pastas. ✔️

#### **10/09 - Página Sobre**
- Criar o repositório no GitHub. ✔️
- Configurar SQL Server e tabelas. ✔️
- Criar backlog de User Stories da Sprint01. ✔️
- Desenvolver Figma da página Sobre. ✔️
- Adicionar informações sobre o blog. ✔️

#### **11/09 - Feed de Artigos**
- Desenvolver Figma da página Feed. ✔️
- Conectar o feed ao banco de dados e listar artigos cronologicamente. ✔️

#### **12/09 - Filtros**
- Implementar filtro por categoria. ✔️
- Implementar filtro por palavra chave. ✔️

#### **13/09 - Formulário Sugestão de Tema**
- Implementar filtro por data. ✔️
- Desenvolver Figma da página Sugestão de Tema. ✔️
- Adicionar campos de contato (nome e e-mail). ✔️
- Adicionar campo para conteúdo (descrição da sugestão). ✔️
- Armazenar sugestões no banco de dados. ✔️

### **Semana 2:**

#### **16/09 - Formulário Sugestão de Artigo**
- Criar backlog de User Stories da Sprint02 e Sprint03. ✔️
- Estilizar formulários. ✔️
- RN ativação do botão. ✔️
- Desenvolver Figma da página Sugestão de Artigo. ✔️
- Adicionar campos de contato (nome e e-mail), título e conteúdo. ✔️
- Armazenar sugestões no banco de dados. ✔️
- Criar a API. ✔️

---
#### Fim do MVP e Início de Incrementos
---

#### **18/09 - API**
- Implementar os endpoints. ✔️
- Desenvolver Figma da página de Acesso. ✔️
- Desenvolver Figma da página de Cadastro. ✔️
- Desenvolver Figma da página de Perfil. ✔️
- Desenvolver Figma da página de Meus Artigos. ✔️
- Desenvolver Figma da página de Publicação. ✔️
- Desenvolver Figma da página de Edição. ✔️
- Adequar banco de dados para Login/Singin.

#### **19/09 - Autenticação**
- Criar página de acesso com campos de e-mail e senha.
- Adicionar página de cadastro com nome, e-mail e senha.

#### **20/09 - Publicação de Artigos**
- Adicionar campos de título e conteúdo.
- Armazenar publicações no banco de dados.

### **Semana 3:**

#### **23/09 - Página de Meus Artigos**
- Listar artigos publicados pelo usuário conectado.

#### **24/09 - Editar e Apagar Publicação**
- Implementar edição de artigos com campos pré-populados.
- Implementar exclusão de artigos publicados pelo usuário.

#### **25/09 - Preparo da Apresentação Final**
- Revisar o projeto.
- Preparar documentação e demonstração para a apresentação final.