# Api Clientes (.NET)

## Descripción
Este proyecto es una Api REST desarrollada en el entorno de .NET 6 enfocada a la administracion de Clientes pudiendo agregar, editar, visualizar o eliminar registros de los mismos.

## Tecnologías y metodologías utilizadas
- .NET Core (.NET 6)
- Entity Framework Core
- Entity Framework Core Tools (SqlServer)
- Automapper
- Code First
- Swagger

## Instalación
Es necesario tener Visual Studio y .NET instalados, o tambien puede correrse en Visual Studio Code. Puede clonar el repositorio o descargarlo en forma de zip comprimido. Luego de abrirlo en Visual Studio, debe compilar la solucion y correrlo en debug (tambien se puede crear una version de Release para produccion de la api).
Luego, presione F5 o en el boton de ejecutar aplicacion. Se abrira una ventana con Swagger (herramienta que nos permite manejar solicitudes HTTP de una manera facil para probar la API, tambien podria utilizarse Postman o Insomnia, etc...).
Listo, de esta manera ya puede consultar, agregar, modificar o eliminar registros, al principio no vera clientes en su base de datos porque localmente no se ha creado ninguno.

Para ver la informacion de los clientes debe abrir en Visual Studio la ventana de "SQL Server Object Explorer" e ir la tabla de Clientes en la Base de Datos:

![image](https://github.com/octaviosancho-dev/api-clientes/assets/90013852/090ca2d8-501c-473b-af71-65e43afdcc63)

Por ultimo presione en la tabla Clientes click derecho -> View Data (o Ver Información)

## Endpoints
Consta de 6 diferentes endpoints para realizar las peticiones mencionadas anteriormente. Podra utilizarlos facilmente utilizando Swagger al correr la aplicación:
- GetAll (GetAll): Devuelve una lista de todos los clientes
- Get (GetById): Devuelve un cliente especifico
- Search (SearchByNombre): Trae una lista de registros que contengan los parametros de busqueda en los Nombres del cliente
- Insert (Post): Agrega un nuevo cliente a la base de datos
- Update (Put): Edita un cliente ya existente
- Delete: Elimina un cliente de la base de datos

## Validaciones
Existen validaciones para la informacion que se envía a traves de los endpoints en cada parametro, que pueden ser tanto de: formatos especificos, tipo de caracteres, campos requeridos, entre otras.

## Propiedades de los Clientes
- ID (unique - Primary Key)
- Nombres (string)
- Apellidos (string)
- Fecha de Nacimiento (DateTime)
- CUIT (string)
- Domicilio (string)
- Telefono Celular (string)
- Email (string)
