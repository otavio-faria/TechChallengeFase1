# ContactZone

## Objetivo

Este projeto é um Tech Challenge do primeiro período da pós-graduação em Arquiteturas de Sistemas da instituição FIAP. O objetivo principal é aplicar e consolidar os conhecimentos adquiridos nas disciplinas do curso, através do desenvolvimento de um aplicativo prático e funcional.

## Descrição

**ContactZone** é um aplicativo desenvolvido utilizando a plataforma .NET 8 para cadastro de contatos regionais. O projeto abrange conceitos de persistência de dados, validação, e boas práticas de desenvolvimento. Esta aplicação permite o cadastro, consulta, atualização e exclusão de contatos, associando-os a um DDD correspondente à região.

## Estrutura do Diretório

```plaintext
Directory: C:\PersonalProjects\ContactZone

    .github
    └── ...                 # Arquivos de configuração do GitHub

    ContactZone.Api
    └── ...                 # APIs da aplicação

    ContactZone.Application
    └── ...                 # Serviços e lógica de aplicação

    ContactZone.Domain
    └── ...                 # Domínio e modelos de dados

    ContactZone.Infrastructure
    └── ...                 # Implementação de persistência de dados

    ContactZone.Tests
    └── ...                 # Testes unitários

    .gitignore
    ContactZone.sln
    README.md
```

## Funcionalidades

### Requisitos Funcionais

- **Cadastro de Contatos**: Permite o cadastro de novos contatos, incluindo nome, telefone e e-mail, associando cada contato a um DDD correspondente à região.
- **Consulta de Contatos**: Implementa a funcionalidade para consultar e visualizar os contatos cadastrados, podendo filtrar pelo DDD da região.
- **Atualização e Exclusão**: Possibilita a atualização e exclusão de contatos previamente cadastrados.

### Requisitos Técnicos

- **Persistência de Dados**: Utiliza um banco de dados para armazenar as informações dos contatos com Entity Framework Core.
- **Validações**: Implementa validações para garantir dados consistentes (por exemplo: validação de formato de e-mail, telefone, campos obrigatórios).
- **Testes Unitários**: Desenvolve testes unitários utilizando xUnit ou NUnit.

## Controller: `ContactController`

A seguir estão os métodos implementados na controller `ContactController`:

### Métodos

1. **Create**

   - **Endpoint**: `POST: api/Contact`
   - **Descrição**: Permite o cadastro de um novo contato com nome, DDD, telefone e e-mail.
   - **Retorno**: Retorna um código 201 (Created) com o contato criado.

   ```csharp
   public async Task<IActionResult> Create(PostContactAndPersonalDataDto dto)
   ```

2. **GetAll**

   - **Endpoint**: `GET: api/Contact/FilterByDDD/{ddd}`
   - **Descrição**: Consulta contatos cadastrados, filtrando por DDD. Se o DDD for 0, retorna todos os contatos.
   - **Retorno**: Retorna um código 200 (OK) com a lista de contatos.

   ```csharp
   public async Task<ActionResult<IEnumerable<ContactDomain>>> GetAll(int ddd)
   ```

3. **GetById**

   - **Endpoint**: `GET: api/Contact/GetByID/{id}`
   - **Descrição**: Retorna os detalhes de um contato específico pelo ID.
   - **Retorno**: Retorna um código 200 (OK) com os dados do contato ou 404 (Not Found) se não encontrado.

   ```csharp
   public async Task<IActionResult> GetById(int id)
   ```

4. **Update**

   - **Endpoint**: `PUT: api/Contact/{id}`
   - **Descrição**: Atualiza os dados de um contato existente.
   - **Retorno**: Retorna um código 204 (No Content) se a atualização for bem-sucedida.

   ```csharp
   public async Task<IActionResult> Update(int id, PostContactDto contactDto)
   ```

5. **Delete**

   - **Endpoint**: `DELETE: api/Contact/{id}`
   - **Descrição**: Remove um contato pelo ID.
   - **Retorno**: Retorna um código 204 (No Content) se a remoção for bem-sucedida.

   ```csharp
   public async Task<IActionResult> Delete(int id)
   ```

## Atualização do Banco de Dados

Para atualizar o banco de dados, é necessário rodar as migrações do Entity Framework. Você pode fazer isso com os seguintes comandos no terminal:

```bash
dotnet ef migrations add <NomeDaMigracao>
dotnet ef database update
```

## Executando os Testes

Os testes unitários podem ser executados utilizando o seguinte comando no terminal:

```bash
dotnet test
```

## Requisitos de Sistema

Este projeto foi desenvolvido com o **.NET 8**. Para executar o aplicativo localmente, você precisa ter o SDK do .NET 8 instalado. Você pode baixar o SDK através do link abaixo:

- [.NET 8 SDK Download](https://dotnet.microsoft.com/download/dotnet/8.0)




