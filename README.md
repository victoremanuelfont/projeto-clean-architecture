# Clean Architecture API - Gestão de Produtos

Este projeto é uma API RESTful desenvolvida em .NET 10 (C#), aplicando os princípios da **Clean Architecture** para garantir desacoplamento, testabilidade e manutenção facilitada.

O foco principal foi construir a estrutura completa de camadas, configurar a Injeção de Dependência e implementar o fluxo de dados completo (Controller -> Service -> Repository -> Database) utilizando um Banco de Dados em Memória para prototipagem rápida.

## 🚀 Tecnologias Utilizadas

* **.NET 10 SDK**
* **C#** (Linguagem)
* **Entity Framework Core** (ORM)
* **EF Core In-Memory** (Banco de dados volátil para testes)
* **AutoMapper** (Mapeamento Entidade <-> DTO)
* **Dependency Injection** (Nativo do .NET)
* **VS Code** (IDE)

## 🏗️ Estrutura da Arquitetura

O projeto foi dividido em 5 camadas físicas para respeitar a separação de responsabilidades:

1.  **CleanArc.Domain**: O coração do projeto. Contém as Entidades (`Product`) e as Interfaces do Repositório (`IProductRepository`). Não depende de ninguém.
2.  **CleanArc.Application**: Contém a lógica de aplicação. Define os DTOs, Interfaces de Serviço (`IProductService`), Implementação dos Serviços (`ProductService`) e perfis de Mapeamento.
3.  **CleanArc.Infra.Data**: Camada de acesso a dados. Implementa os Repositórios (`ProductRepository`), configura o Contexto do Banco (`ApplicationDbContext`) e o Entity Framework.
4.  **CleanArc.Infra.IoC**: Responsável pela Injeção de Dependência. Centraliza a configuração de serviços, repositórios e banco de dados, mantendo a API limpa.
5.  **CleanArc.API**: Camada de entrada. Contém os Controllers (`ProductsController`) e expõe os endpoints HTTP.

## 📝 Relatório de Desenvolvimento

Durante a construção deste projeto, foram realizadas as seguintes etapas:
1.  **Configuração do Ambiente:** Criação da Solution (`.sln`) e dos 5 projetos de classe/API.
2.  **Definição do Domínio:** Criação da entidade `Product` com validações ricas.
3.  **Implementação da Infraestrutura:** Configuração do EF Core para usar **In-Memory Database**, permitindo testes sem instalação do SQL Server.
4.  **Service Layer & DTOs:** Uso do **AutoMapper** para converter dados e isolar o Domínio da API externa. (Nota: Fixada versão 12.0.1 do AutoMapper para evitar conflitos de dependência).
5.  **Injeção de Dependência:** Configuração centralizada no projeto `Infra.IoC` para resolver todas as interfaces.
6.  **API Controller:** Criação de endpoints REST (GET, POST, PUT, DELETE) para gerenciar produtos.

## ⚙️ Como Rodar o Projeto

### Pré-requisitos
* Ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.

### Passo a Passo

1.  **Clonar o repositório (ou baixar a pasta):**
    ```bash
    git clone <SEU_LINK_DO_GIT_AQUI>
    ```

2.  **Navegar até a pasta da API:**
    O comando de execução deve ser rodado dentro do projeto de entrada.
    ```bash
    cd CleanArc.API
    ```

3.  **Rodar a aplicação:**
    ```bash
    dotnet watch run
    ```
    *Aguarde aparecer a mensagem "Now listening on: http://localhost:XXXX"*

4.  **Acessar no Navegador:**
    Abra `http://localhost:5034/api/products` (Verifique se a porta 5034 é a mesma no seu terminal).
    *Nota: Como o banco é em memória, a lista iniciará vazia `[]`.*

### 🧪 Testando a API (Inserindo Dados)

Como o banco inicia vazio, use o terminal (PowerShell) para inserir um produto de teste:

```powershell
Invoke-RestMethod -Method Post -Uri "http://localhost:5034/api/products" -Body '{"name":"Caderno", "description":"Caderno 10 materias", "price":25.50, "stock":100, "image":"caderno.jpg"}' -ContentType "application/json"
