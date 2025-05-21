# Challange — Clientes e Motos

API RESTful em ASP.NET Core para gerenciamento de **Clientes** e **Motos**, com EF Core e Oracle.

---

##  Arquitetura  

- **Domain**  
  - `Entities` (Cliente, Moto)  
  - `Interfaces` (IClienteRepository, IMotoRepository)  
- **Application**  
  - `Dtos` (ClienteDto, MotoDto,)  
  - `Interfaces` (IClienteService, IMotoService)  
  - `Services` (ClienteService, MotoService)  
- **Infrastructure**  
  - `Data/AppData/ApplicationDbContext.cs`  
  - `Data/Repositories` (ClienteRepository, MotoRepository)  
- **Presentation**  
  - `Controllers` (ClienteController, MotoController)  
  - `Program.cs`, `appsettings.json`  
- **Project file**  
  - `CP2.API.csproj`  

---

## Tecnologias  

- .NET 8 / C#  
- ASP.NET Core Web API  
- Entity Framework Core 9 + Oracle.EntityFrameworkCore  
- Swagger / OpenAPI  
- Oracle Database (ou In-Memory para testes)  

---

##  Como executar  

1. **Clone** o repositório e acesse a pasta da API  
   ```bash
   git clone https://github.com/<USERNAME>/<REPO>.git
   cd <REPO>/CP2.API

## Endpoints

### Clientes
- `GET    /api/cliente?nome={filtro}`
- `GET    /api/cliente/{id}`
- `POST   /api/cliente`
- `PUT    /api/cliente/{id}`
- `DELETE /api/cliente/{id}`

### Motos
- `GET    /api/moto?marca={filtro}&ano={filtro}`
- `GET    /api/moto/{id}`
- `POST   /api/moto`
- `PUT    /api/moto/{id}`
- `DELETE /api/moto/{id}`

---

## ✅ Testes

Use o **Swagger UI** para verificar:

- **POST** → `201 Created`
- **GET**  → `200 OK` ou `404 Not Found`
- **PUT**  → `204 No Content` ou `400 Bad Request` / `404 Not Found`
- **DELETE** → `204 No Content`

**Filtros:**
- `/api/cliente?nome=Maria`
- `/api/moto?marca=Honda&ano=2022`

---

## ℹObservações

- Mapeamos tabelas/colunas em **maiúsculas** via Fluent API em `OnModelCreating`.  
- Para testes **sem Oracle**, comente `UseOracle(...)` e descomente  
  `UseInMemoryDatabase("TestDb")` em `Program.cs`.  
- Mantenha um **.gitignore** para `bin/`, `obj/`, `*.vs/`, etc.  

