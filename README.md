# Epood – ASP.NET Core Web API E-Shop

Epood ("e-shop" in Estonian) is an ASP.NET Core Web API that provides a full shop backend. It was built as a coursework project for *Programmeerimine 2* and is currently a **work in progress**.

The database covers **55 SQL Server tables** spanning:

- Product catalog
- Orders
- Inventory and warehouse
- Loyalty programs
- Payments
- Reviews
- ...and more

## Features

- ASP.NET Core Web API
- Entity Framework Core with SQL Server
- CORS configuration
- One-time `SeedData` that populates **36 rows per table**
- Auto-generated EF Core migrations

## Project Structure

```
.
├── KooliProjekt.Application/     # Application layer
├── KooliProjekt.WebAPI/          # ASP.NET Core Web API (startup project)
├── KooliProjekt.sln              # Visual Studio solution
├── EPoodDiagram.png / .svg       # Full database diagram
├── EPoodDiagramSimple.png / .svg # Simplified database diagram
├── EPoodModel.docx               # Data model documentation
└── .gitignore
```

## Database Diagrams

| Diagram | Files |
| --- | --- |
| Full model | `EPoodDiagram.png`, `EPoodDiagram.svg` |
| Simplified model | `EPoodDiagramSimple.png`, `EPoodDiagramSimple.svg` |

The complete model description is available in `EPoodModel.docx`.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version matching the project's target framework)
- SQL Server (LocalDB, Express, or a full instance)
- [EF Core CLI tools](https://learn.microsoft.com/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`
- Visual Studio 2022 or VS Code (optional)

## Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/EvaLiisaAibast/Programeerimine2-Epood-WIP-PleaseNoGitPullOrFork.git
   cd Programeerimine2-Epood-WIP-PleaseNoGitPullOrFork
   ```

2. **Configure the connection string**

   Update the SQL Server connection string in `KooliProjekt.WebAPI/appsettings.json` to point at your own SQL Server instance.

3. **Apply the migrations**

   ```bash
   dotnet ef database update --project KooliProjekt.WebAPI
   ```

   If the migrations live in the Application project, add `--startup-project KooliProjekt.WebAPI` and point `--project` at the correct one.

4. **Run the API**

   ```bash
   dotnet run --project KooliProjekt.WebAPI
   ```

   On first startup the `SeedData` routine fills each table with 36 sample rows. It is a one-time seed and will not duplicate data on later runs.

## Status

This project is a work in progress. Features, endpoints and the schema may change.

## Note

The repository name asks visitors **not to pull or fork** it. Please respect that and treat the code as view-only.

## Author

[EvaLiisaAibast](https://github.com/EvaLiisaAibast)
