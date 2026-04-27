# Prime Systems

## Build & Run
- `cd src && dotnet run` — runs from `src/` where the `.csproj` lives
- No test project exists; `dotnet test` will not work

## Configuration

### config.yaml (primary config)
- Lives next to the executable (`src/`)
- Controls `Database.Provider` (default: `sqlite`) and `Database.ConnectionString`
- If absent, `ConfigurationWizard` dialog launches on first run

### Environment variables (overrides)
| Variable | Purpose | Default |
|---|---|---|
| `SQL_CONNECTION_STRING` | SQL Server connection | — |
| `CLEAR_DB_ON_STARTUP` | Wipe and recreate DB | false |
| `POPULATE_DB_ON_STARTUP` | Seed test data | false |

### Database providers
- **SQLite** (default): data stored at `data/primesystems.db`
- **SQL Server**: requires both `Provider: sqlserver` in yaml and `SQL_CONNECTION_STRING` env var

Switching providers happens in `Config.cs:37-46` → `AppDbContext.cs:36-49`. Both places must agree.

## Test Data (`POPULATE_DB_ON_STARTUP=true`)

Seeds via `Core/Tests.cs` — creates if tables are empty (idempotent):
- Roles: admin, vendedor, gestor_compras
- Users: admin/admin, maria.gonzalez/maria, carlos.martinez/carlos (passwords printed to console)

## Project Structure

```
src/
├── Core/              # EF Core context, config, DB init, test data
├── Models/            # Entity models (UserModel, ArticleModel, etc.)
├── Services/          # Business logic (NOT Controllers/)
├── Views/
│   ├── Forms/         # WinForms (Login, Main, ConfigurationWizard, etc.)
│   └── Controls/      # Reusable UI components
├── PrimeSystems.csproj
└── Program.cs         # Entry point → Login form
```

Note: `Controllers/` directory does not exist. Business logic lives in `Services/`.

## Generated Code
- `Properties/Resources.Designer.cs` — auto-generated from `Properties/Resources.resx`
  - Do not edit manually; edit `.resx` and rebuild

## Scripts
- `scripts/mdb-to-sql.sh` — converts Access .mdb schema to MySQL SQL (requires mdb-tools)

## UI Framework
- ReaLTaiizor (MaterialSkin) for theming — see `Core/Config.cs:126-148` for color scheme
- Primary color: `#003554`, accent: `#00a6fb`