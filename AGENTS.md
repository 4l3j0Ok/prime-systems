# Prime Systems

## Build & Run
- `cd src && dotnet run`

## Database
- Connects via `SQL_CONNECTION_STRING` env var (default: localhost SQL Server)
- On first run without config file, a `ConfigurationWizard` dialog launches
- `CLEAR_DB_ON_STARTUP=true` wipes and recreates DB
- `POPULATE_DB_ON_STARTUP=true` seeds test data (roles, users, clients, suppliers, articles, stock, sample purchases/sales)

## Test Users (with POPULATE_DB_ON_STARTUP)
- admin / Administrador
- vendedor1 / Vendedor
- comprador1 / Gestor de Compras
- Passwords shown in console output during seed

## Project Structure
- `src/Program.cs` → entry point, launches Login form
- `src/Core/` → EF Core context, config, DB init, test data
- `src/Models/` → data models
- `src/Controllers/` → business logic
- `src/Views/` → WinForms UI

## Scripts
- `scripts/mdb-to-sql.sh` — converts Access .mdb schema to MySQL SQL (requires mdb-tools)