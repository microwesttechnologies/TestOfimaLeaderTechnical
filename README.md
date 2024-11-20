# Ofima S.A.S. - Application - EmployeeManager

**EmployeeManager** es una aplicación para la gestión eficiente de empleados dentro de una organización, diseñada para realizar un seguimiento de los registros de ingreso, los tipos de empleados y las operaciones relacionadas con los datos laborales.

## Características principales

- **Gestión de empleados**: permite agregar, actualizar, listar y eliminar empleados, con notificaciones sobre eventos clave como renovaciones de contratos o vencimientos.
- **Seguimiento de registros**: almacena los ingresos de los empleados en un registro de logs centralizado.
- **Clasificación de empleados**: administración de tipos de empleados para facilitar una mejor organización interna.

## Tecnologías utilizadas

- **Frontend**: Angular con Bootstrap para diseño responsivo y separación de responsabilidades.
- **Backend**: .NET Core con arquitectura de capas.
- **Database**: Microsoft SQL Server para almacenamiento y manejo de datos.

## Requisitos

- Node.js instalado en el sistema.
- .NET SDK 8.0 o superior.
- Microsoft SQL Server configurado.
- Angular CLI instalado globalmente.

## Instalación

1. Clona este repositorio:
    ```bash
    git clone https://github.com/nameRepository/AppName.git
    ```

2. Navega al directorio del proyecto frontend:
    ```bash
    cd EmployeeManager/Frontend
    ```

3. Instala las dependencias del frontend:
    ```bash
    npm install
    ```

4. Configura el backend:
    - Navega al directorio del backend:
      ```bash
      cd ../Backend
      ```
    - Restaura las dependencias:
      ```bash
      dotnet restore
      ```

5. Configura la base de datos:
    - Crea una base de datos en SQL Server llamada `OfimaEmployeeManager`.
    - Ejecuta el script de migración inicial ubicado en `Ofm.EmployeeManager\Ofm.EmployeeManager.Data\Query\InitialScript.sql`.

6. Inicia la aplicación:
    - Arranca el backend:
      ```bash
      dotnet run
      ```
    - Arranca el frontend:
      ```bash
      ng serve
      ```

## Arquitectura

### Backend
El backend está diseñado siguiendo una **arquitectura en capas**, que incluye:
- **Capa de Presentación**: controladores para manejar las solicitudes HTTP.
- **Capa de Aplicación**: lógica de negocio, servicios y validaciones.
- **Capa de Datos**: conexión a SQL Server mediante Entity Framework Core, siguiendo los principios de separación de responsabilidades.

### Frontend
El frontend está estructurado para mantener una separación clara entre:
- **Componentes**: encargados de la presentación y captura de datos.
- **Servicios**: responsables de la comunicación con el backend.
- **Módulos**: para organizar las funcionalidades principales, como gestión de empleados y registros de logs.

### Database
La base de datos incluye las siguientes tablas:
- **Employee**: contiene información como nombre, tipo de empleado y fecha de ingreso.
- **TypesEmployee**: define categorías como contratista, permanente, o temporal.
- **LogsEmployee**: registra las entradas de los empleados con marca de tiempo.

## Contacto
Para dudas o sugerencias, contacta al administrador del repositorio: **Ofima S.A.S. Repository**.