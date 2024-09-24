# **Projeto Blog de Divulgação Científica**

## **Sumário**
1. [Arquitetura do Projeto](#arquitetura-do-projeto)
   - [Banco de Dados](#banco-de-dados)
   - [API](#api)
   - [Web Forms](#web-forms)
   - [Estilo](#estilo)
   - [Outras Considerações](#outras-considerações)
2. [Como Rodar o Projeto](#como-rodar-o-projeto)
   - [1. Clonar o Repositório](#1-clonar-o-repositório)
   - [2. Configurar o Banco de Dados](#2-configurar-o-banco-de-dados)
   - [3. Rodar a API](#3-rodar-a-api)
   - [4. Rodar os Web Forms](#4-rodar-os-web-forms)
   - [5. Acessar o Aplicativo](#5-acessar-o-aplicativo)
   - [Considerações Finais](#considerações-finais)

---

## **Arquitetura do Projeto**

### **Banco de Dados**
**SQL Server**  
Utiliza o SQL Server como sistema de gerenciamento de banco de dados para armazenar e gerenciar todas as informações do projeto, incluindo categorias, artigos, sugestões e usuários. O banco de dados foi estruturado com tabelas otimizadas para garantir a integridade dos dados e a eficiência nas operações de consulta. [Mais sobre o banco de dados](https://github.com/xzxjesse/blogDivulgacaoCientifica/blob/main/Documentação/Doc_BD.md).

### **API**
**ASP.NET Core Web API**  
A API é responsável pela comunicação entre o frontend e o backend, permitindo operações de CRUD (Criar, Ler, Atualizar, Deletar) para os diferentes recursos do sistema, como usuários, artigos, categorias e sugestões. A API implementa autenticação e autorização, garantindo a segurança das operações sensíveis. Além disso, são utilizados padrões RESTful para a estruturação dos endpoints, proporcionando uma interface intuitiva. [Mais sobre a API](https://github.com/xzxjesse/blogDivulgacaoCientifica/blob/main/Documentação/Doc_API.md).

### **Web Forms**
**ASP.NET Web Forms**  
A interface do usuário é construída utilizando Web Forms, permitindo a criação de páginas dinâmicas e interativas. Essa abordagem facilita a implementação de lógica e de eventos nas páginas. O uso de Web Forms também permite uma integração fluida com a API, garantindo uma experiência de usuário responsiva. [Mais sobre os Web Forms](https://github.com/xzxjesse/blogDivulgacaoCientifica/blob/main/Documentação/Doc_WebForms.md).

### **Estilo**
**Bootstrap**  
O design do projeto é baseado no framework Bootstrap, que proporciona um layout responsivo e moderno. Com o Bootstrap, é possível garantir que a aplicação se adapte a diferentes tamanhos de tela e dispositivos, melhorando a usabilidade e a experiência do usuário. Além disso, foram utilizados componentes e classes do Bootstrap para acelerar o desenvolvimento e manter a consistência visual em todas as páginas. [Bootstrap](https://getbootstrap.com).

### **Outras Considerações**
- **Integração:** A arquitetura do projeto foi desenvolvida para garantir uma integração fluida entre o banco de dados, a API e a interface do usuário, facilitando a manutenção e a escalabilidade do sistema.
- **Testes:** Medidas de segurança são implementadas na API para garantir o funcionamento correto dos endpoints. [Mais sobre os testes](https://github.com/xzxjesse/blogDivulgacaoCientifica/blob/main/Documentação/Doc_Testes.md).

---

## **Como Rodar o Projeto**

### **1. Clonar o Repositório**
- Acesse o repositório do GitHub e clone-o:
  ```bash
  git clone https://github.com/xzxjesse/blogDivulgacaoCientifica.git
  ```
- Navegue até o diretório do projeto:
  ```bash
  cd blogDivulgacaoCientifica
  ```

### **2. Configurar o Banco de Dados**
- **Criar o Banco de Dados**
  - Execute o script `ConectaCiencia.sql` no SQL Server Management Studio (SSMS) para criar o banco e tabelas.
  
- **Popular o Banco de Dados**
  - Execute o script `preenchimentoBD.sql` no SSMS para adicionar dados iniciais.

### **3. Rodar a API**
- Abra o projeto da API em uma IDE.
- **Alterar a String de Conexão**
  - No arquivo `appsettings.json`, ajuste a string de conexão na seção `ConnectionStrings`:
    ```json
    "ConnectionStrings": {
        "conexao": "Server=JE_EVE\\MSSQLSERVER01;Database=ConectaCiencia;Integrated Security=true;"
    }
    ```
  
- **Instalar Dependências**
  - No Console do Gerenciador de Pacotes, execute:
    ```bash
    dotnet restore
    ```

- **Iniciar a API**
  - Pressione `F5` ou clique em "Run" para iniciar a API.

### **4. Rodar os Web Forms**
- Abra o projeto Web Forms em uma IDE e inicie-o pressionando `F5`.

### **5. Acessar o Aplicativo**
- Acesse as funcionalidades do aplicativo no navegador, usando as URLs definidas nas configurações.

### **Considerações Finais**
- **Erro de Conexão:** Verifique a string de conexão no arquivo da API se houver problemas.
- **Documentação:** Consulte a documentação do projeto para mais informações.
