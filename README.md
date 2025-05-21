# Challange — Clientes e Motos

API RESTful em ASP.NET Core para gerenciamento de **Clientes** e **Motos**, com EF Core e Oracle.

---

##  Arquitetura  

- **Domain**  
  - `Entities` (Cliente, Moto)  
  - `Interfaces` (IClienteRepository, IMotoRepository)  
- **Application**  
  - `Dtos` (ClienteDto, CreateClienteDto, MotoDto, CreateMotoDto)  
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
