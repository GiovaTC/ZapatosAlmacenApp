# ZapatosAlmacenApp

![image](https://github.com/user-attachments/assets/b77a8a48-2bdd-49d9-a1f1-0f02beaf20e9)

![image](https://github.com/user-attachments/assets/1f2a2b9f-4925-4d31-ab0d-e2c37d6edb5a)

# Guía para desarrollar una aplicación MVC en Visual Studio 2022 conectada a SQL Server para gestionar un almacén de zapatos (CRUD)

## 🛠️ Tecnologías utilizadas:
- Visual Studio 2022  
- ASP.NET MVC (.NET 6 o 8)  
- SQL Server  
- Entity Framework (Code First o Database First)  

---

## 1. Configurar el proyecto

1. Abre **Visual Studio 2022**.  
2. Crea un nuevo proyecto:
   - Tipo: **ASP.NET Core Web App (Model-View-Controller)**  
   - Nombre: `ZapatosAlmacenApp`  
   - Framework: `.NET 6.0 o 8.0`  

---

## 2. Crear la base de datos en SQL Server

Ejecuta el siguiente script en **SQL Server Management Studio (SSMS)**:

```sql
CREATE DATABASE ZapatosAlmacen;

USE ZapatosAlmacen;

CREATE TABLE Zapatos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(100),
    Modelo NVARCHAR(100),
    Talla INT,
    Color NVARCHAR(50),
    Cantidad INT,
    Precio DECIMAL(10,2)
);
3. Conectar el proyecto a SQL Server
En appsettings.json, configura tu cadena de conexión:

json

"ConnectionStrings": {
  "ZapatosDb": "Server=TU_SERVIDOR_SQL;Database=ZapatosAlmacen;Trusted_Connection=True;"
}
4. Crear el modelo
En la carpeta Models, crea un archivo Zapato.cs:

csharp

using System.ComponentModel.DataAnnotations;

public class Zapato
{
    public int Id { get; set; }

    [Required]
    public string Marca { get; set; }

    [Required]
    public string Modelo { get; set; }

    [Range(20, 50)]
    public int Talla { get; set; }

    public string Color { get; set; }

    [Range(0, int.MaxValue)]
    public int Cantidad { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Precio { get; set; }
}
5. Crear el contexto de base de datos
En Data/ApplicationDbContext.cs:

csharp

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Zapato> Zapatos { get; set; }
}
En Program.cs:

csharp

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZapatosDb")));
6. Crear el controlador y vistas (Scaffolding)
Clic derecho en la carpeta Controllers → Add → Controller...

Selecciona MVC Controller with views, using Entity Framework

Modelo: Zapato, Contexto: ApplicationDbContext

Visual Studio generará:

Controlador: ZapatosController.cs

Vistas en: Views/Zapatos/ (Index, Create, Edit, Details, Delete)

7. Ejecutar migraciones
En la Consola del Administrador de Paquetes:

powershell

Add-Migration InitialCreate
Update-Database
8. Probar la aplicación
Ejecuta la app y navega a /Zapatos para realizar operaciones CRUD:

Ver todos los zapatos

Agregar nuevo zapato

Editar

Eliminar

Ver detalles

🔐 Agregar autenticación con Identity en ASP.NET MVC
✅ 1. Crear un nuevo proyecto con autenticación
En Visual Studio 2022:

Crea un nuevo proyecto ASP.NET Core Web App (Model-View-Controller)

Marca Authentication Type: Individual Accounts

Nombre del proyecto: ZapatosAlmacenApp

Esto incluirá automáticamente:

Controladores para autenticación (AccountController, Register, Login, etc.)

Vistas relacionadas (Views/Account/)

Tablas de usuario y roles en la base de datos

✅ 2. Configura la cadena de conexión
En appsettings.json:

json

"ConnectionStrings": {
  "ZapatosDb": "Server=TU_SERVIDOR_SQL;Database=ZapatosAlmacen;Trusted_Connection=True;"
}
✅ 3. Migraciones de Identity y Base de Datos
En la Consola del Administrador de Paquetes:

powershell

Add-Migration IdentityInit
Update-Database
Esto crea las tablas necesarias (AspNetUsers, AspNetRoles, etc.)

✅ 4. Restringir el acceso a las vistas del CRUD
En ZapatosController.cs, agrega el atributo [Authorize]:

csharp

using Microsoft.AspNetCore.Authorization;

[Authorize]
public class ZapatosController : Controller
{
    // Acciones CRUD aquí
}
Esto asegura que solo usuarios autenticados puedan acceder a las acciones CRUD.

✅ 5. Agregar inicio de sesión en el menú
Edita _Layout.cshtml (en Views/Shared/):

html

@using Microsoft.AspNetCore.Identity
@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager

<ul class="navbar-nav">
    @if (SignInManager.IsSignedIn(User))
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="Logout">Cerrar sesión</a>
        </li>
    }
    else
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Login">Iniciar sesión</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Register">Registrarse</a>
        </li>
    }
</ul>

✅ 6. Probar la aplicación
Ejecuta la app

Regístrate con un nuevo usuario

Inicia sesión

Navega a /Zapatos, ahora accesible solo para usuarios autenticados

🚀 Extensiones opcionales
Autorización por roles (Ej. "Administrador", "Empleado")

Registro con confirmación de email

Restablecimiento de contraseña

Subida de imágenes para zapatos

