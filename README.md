# LanceCerto.WebApp

**Lance Certo** é uma aplicação web desenvolvida em ASP.NET Core MVC com .NET 8.0 para gerenciamento e participação em leilões de imóveis. O sistema permite cadastrar, editar, visualizar e excluir imóveis, além de realizar pesquisas com filtros por cidade, estado, tipo e preço.

---

## 🔧 Tecnologias Utilizadas

- ASP.NET Core MVC (.NET 8.0)
- Entity Framework Core
- SQL Server (Azure SQL Database)
- Bootstrap 5
- Razor Views
- LINQ

---

## ✅ Funcionalidades Implementadas

### 📄 CRUD Completo de Imóveis
- Cadastro de novo imóvel
- Listagem com filtros de pesquisa
- Visualização de detalhes
- Edição de dados
- Confirmação e exclusão

### 🔍 Filtros de Pesquisa
- Cidade
- Estado
- Tipo de imóvel
- Preço máximo

### 🎯 Extras
- Validação de formulários com Data Annotations
- Interface responsiva com Bootstrap
- Página de erro personalizada (`/Imovel/Error`)
- Ações na tabela: Ver, Editar e Excluir

---

## 🚀 Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/lancecerto.git
```

2. Configure a string de conexão no `appsettings.json` com sua base de dados Azure SQL.

3. Execute o update do banco:
```bash
Update-Database
```

4. Compile e execute o projeto no Visual Studio (`Ctrl + F5`)

---

## 🧩 Estrutura do Projeto

```
LanceCerto.WebApp/
├── Controllers/
│   └── ImovelController.cs
├── Models/
│   └── Imovel.cs
├── Data/
│   └── LanceCertoDbContext.cs
├── Views/
│   └── Imovel/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       ├── Details.cshtml
│       └── Delete.cshtml
├── appsettings.json
├── Program.cs
└── README.md
```

---

## 🏗️ Próximos Passos

- Implementar autenticação de usuários (corretor, comprador, vendedor)
- Criar módulo de leilões com histórico de lances
- Adicionar upload de imagens reais para os imóveis

---

## 👨‍💻 Desenvolvido por

Daniel – Estudante de Análise e Desenvolvimento de Sistemas  
PUC Minas  
Projeto acadêmico - 2025
