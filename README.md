# Demokrata

Demokrata es una aplicación ASP.NET Core para la gestión de usuarios. Este proyecto incluye una API RESTful que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los usuarios.

## Estructura del Proyecto

- **Demokrata**: Contiene la aplicación principal.
  - **Controllers**: Controladores de la API.
  - **Data**: Contexto de la base de datos.
  - **DTOs**: Objetos de transferencia de datos.
  - **Filters**: Filtros personalizados.
  - **Mappings**: Configuración de AutoMapper.
  - **Migrations**: Migraciones de Entity Framework.
  - **Models**: Modelos de datos.
  - **Repositories**: Repositorios para acceso a datos.
  - **Services**: Servicios de negocio.
  - **Properties**: Configuraciones del proyecto.
  - **Program.cs**: Configuración de inicio de la aplicación.
  - **appsettings.json**: Configuración de la aplicación.
  - **appsettings.Development.json**: Configuración de la aplicación para el entorno de desarrollo.

- **Demokrata.Tests**: Contiene las pruebas unitarias y de integración.
  - **Controllers**: Pruebas para los controladores.
  - **Services**: Pruebas para los servicios.

## Configuración

### Requisitos

- .NET 8.0 SDK
- SQL Server

### Configuración de la Base de Datos

Asegúrate de tener una instancia de SQL Server en ejecución y actualiza la cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=Demokrata;Trusted_Connection=True;TrustServerCertificate=True;"
}


Migraciones de Entity Framework

Para aplicar las migraciones y crear la base de datos, ejecuta los siguientes comandos en la terminal:
dotnet ef migrations add InitialCreate
dotnet ef database update

Ejecución del Proyecto
Para ejecutar la aplicación, utiliza el siguiente comando:

dotnet run --project Demokrata

La API estará disponible en http://localhost:5274/swagger para el entorno de desarrollo.

Pruebas
Para ejecutar las pruebas, utiliza el siguiente comando:
dotnet test



Autor: Ruben DArio Hernandez