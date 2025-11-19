# Prime Systems

Sistema de gestión empresarial desarrollado en .NET 9 con Windows Forms.

## Requisitos

- .NET 9 SDK
- SQL Server (LocalDB o instancia completa)
- Visual Studio 2022 o superior (opcional)

## Configuración

### Variables de Entorno

El sistema utiliza las siguientes variables de entorno para su configuración:

#### `SQL_CONNECTION_STRING`
Define la cadena de conexión a la base de datos SQL Server.

**Valor por defecto:** `Server=127.0.0.1;Database=PrimeSystems;Trusted_Connection=True;TrustServerCertificate=True;`

**Ejemplo:**
```bash
# Windows (PowerShell)
$env:SQL_CONNECTION_STRING="Server=localhost;Database=PrimeSystems;User Id=sa;Password=tuPassword;TrustServerCertificate=True;"

# Windows (CMD)
set SQL_CONNECTION_STRING=Server=localhost;Database=PrimeSystems;User Id=sa;Password=tuPassword;TrustServerCertificate=True;

# Linux/macOS
export SQL_CONNECTION_STRING="Server=localhost;Database=PrimeSystems;User Id=sa;Password=tuPassword;TrustServerCertificate=True;"
```

#### `CLEAR_DB_ON_STARTUP`
Limpia y recrea la base de datos cada vez que se inicia la aplicación.

**?? ADVERTENCIA:** Esta opción eliminará todos los datos existentes.

**Valores aceptados:** `true` (activa la limpieza), cualquier otro valor o ausencia (desactiva la limpieza)

**Ejemplo:**
```bash
# Windows (PowerShell)
$env:CLEAR_DB_ON_STARTUP="true"

# Windows (CMD)
set CLEAR_DB_ON_STARTUP=true

# Linux/macOS
export CLEAR_DB_ON_STARTUP="true"
```

#### `POPULATE_DB_ON_STARTUP`
Puebla la base de datos con datos de prueba predefinidos al iniciar la aplicación.

**Nota:** Esta opción solo insertará datos si las tablas están vacías, evitando duplicados.

**Valores aceptados:** `true` (activa la población), cualquier otro valor o ausencia (desactiva la población)

**Datos incluidos:**
- 3 Roles (Administrador, Vendedor, Gestor de Compras)
- 3 Usuarios de prueba
- 5 Clientes
- 4 Proveedores
- 5 Categorías
- 13 Subcategorías
- 19 Artículos
- Stock para cada artículo
- 3 Compras con detalles
- 4 Ventas con detalles
- 9 Registros de actividad

**Ejemplo:**
```bash
# Windows (PowerShell)
$env:POPULATE_DB_ON_STARTUP="true"

# Windows (CMD)
set POPULATE_DB_ON_STARTUP=true

# Linux/macOS
export POPULATE_DB_ON_STARTUP="true"
```

### Configuración Combinada para Desarrollo

Para iniciar con una base de datos limpia y poblada con datos de prueba:

```bash
# Windows (PowerShell)
$env:CLEAR_DB_ON_STARTUP="true"
$env:POPULATE_DB_ON_STARTUP="true"

# Windows (CMD)
set CLEAR_DB_ON_STARTUP=true
set POPULATE_DB_ON_STARTUP=true

# Linux/macOS
export CLEAR_DB_ON_STARTUP="true"
export POPULATE_DB_ON_STARTUP="true"
```

## Ejecución

### Desde Visual Studio
1. Abrir el proyecto en Visual Studio
2. Configurar las variables de entorno en las propiedades del proyecto (Debug > Opciones de inicio)
3. Presionar F5 para ejecutar

### Desde línea de comandos
```bash
# Navegar al directorio del proyecto
cd src

# Ejecutar
dotnet run
```

## Usuarios por Defecto

Después de la primera ejecución, se creará automáticamente un usuario administrador con credenciales aleatorias que se mostrarán en un cuadro de diálogo.

Si se usa `POPULATE_DB_ON_STARTUP=true`, se crearán los siguientes usuarios adicionales:

| Usuario | Rol | Nombre |
|---------|-----|--------|
| admin | Administrador | Juan Administrador |
| vendedor1 | Vendedor | María González |
| comprador1 | Gestor de Compras | Carlos Martínez |

**Nota:** Las contraseñas se generan aleatoriamente y se muestran en la consola durante la población de datos.

## Estructura del Proyecto

```
src/
??? Core/               # Lógica central y utilidades
?   ??? AppDbContext.cs    # Contexto de Entity Framework
?   ??? DbInitializer.cs   # Inicializador de base de datos
?   ??? Tests.cs           # Datos de prueba (PopulateDB)
?   ??? ...
??? Models/            # Modelos de datos
??? Controllers/       # Controladores de lógica de negocio
??? Views/             # Formularios y controles de UI
?   ??? Forms/
?   ??? Controls/
??? PrimeSystems.csproj
```

## Desarrollo

### Agregar Nuevos Datos de Prueba

Para modificar o agregar nuevos datos de prueba, editar el archivo `Core/Tests.cs` y modificar los métodos correspondientes:

- `PopulateRoles()` - Roles de usuario
- `PopulateUsers()` - Usuarios
- `PopulateClients()` - Clientes
- `PopulateSuppliers()` - Proveedores
- `PopulateCategories()` - Categorías
- `PopulateSubcategories()` - Subcategorías
- `PopulateArticles()` - Artículos
- `PopulateStock()` - Stock
- `PopulatePurchases()` - Compras
- `PopulateSells()` - Ventas
- `PopulateActivityRecords()` - Registros de actividad

## Licencia

[Especificar licencia del proyecto]

## Contribución

[Instrucciones para contribuir al proyecto]
