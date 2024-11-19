Demokrata

Demokrata es un proyecto que implementa un API REST para la gestión de usuarios. Este API permite realizar operaciones básicas de CRUD (Crear, Leer, Actualizar, Eliminar) sobre una base de datos, incluyendo la búsqueda por ID y búsqueda paginada por nombre o apellido.
Características principales

    Tecnología: .NET 8
    Base de datos: SQL Server
    Operaciones CRUD: Crear, Leer, Actualizar y Eliminar usuarios.
    Búsquedas:
        Por ID.
        Por nombre/apellido con paginación.
    Validaciones:
        Reglas estrictas para los campos, incluyendo validaciones de longitud, tipos de datos y restricciones de negocio.
    Pruebas:
        Unitarias y de integración utilizando xUnit y Moq.
    Documentación: Integración con Swagger para explorar los endpoints.

Requisitos previos

    .NET 8 SDK instalado. Descargar aquí.
    SQL Server configurado y corriendo localmente o en la nube.
    Herramientas de desarrollo como Visual Studio o Visual Studio Code.
    Administrador de paquetes como NuGet.

Configuración del proyecto
1. Clonar el repositorio

git clone <URL del repositorio>
cd Demokrata

2. Configurar la cadena de conexión

En el archivo appsettings.json, configura la conexión a tu base de datos SQL Server:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Demokrata;Trusted_Connection=True;"
  }
}

3. Crear la base de datos

Ejecuta las migraciones para crear la base de datos y las tablas:

dotnet ef database update

4. Ejecutar el proyecto

Inicia el servidor:

dotnet run

El API estará disponible en: http://localhost:5000.
5. Explorar la documentación de la API

Accede a Swagger en: http://localhost:5000/swagger.
Endpoints
Método	Endpoint	Descripción
GET	/api/usuarios/{id}	Obtener un usuario por su ID.
GET	/api/usuarios	Obtener todos los usuarios.
GET	/api/usuarios/search	Buscar usuarios por nombre o apellido (paginado).
POST	/api/usuarios	Crear un nuevo usuario.
PUT	/api/usuarios/{id}	Actualizar un usuario existente.
DELETE	/api/usuarios/{id}	Eliminar un usuario por su ID.
Validaciones de usuario
Campos obligatorios

    Primer nombre: Máximo 50 caracteres, sin números.
    Primer apellido: Máximo 50 caracteres, sin números.
    Fecha de nacimiento: No puede estar vacía.
    Sueldo: Mayor que 0.

Campos opcionales

    Segundo nombre: Máximo 50 caracteres, sin números.
    Segundo apellido: Máximo 50 caracteres, sin números.

Pruebas
Tecnologías utilizadas

    xUnit: Para pruebas unitarias.
    Moq: Para simular dependencias.

Ejecutar las pruebas

Desde el directorio raíz del proyecto:

dotnet test

Cobertura

    Pruebas para UsuarioService validando lógica de negocio.
    Pruebas para UsuariosController verificando las respuestas HTTP y validaciones.

Tecnologías utilizadas

    Framework: ASP.NET Core 8
    ORM: Entity Framework Core
    Base de datos: SQL Server
    Pruebas: xUnit y Moq
    Documentación: Swagger

Colaboradores

    Autor: [Tu nombre]
    Contacto: [Tu email]
