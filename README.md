# Ejercicio de Login
Este proyecto es la solución al caso técnico: Login Básico con Estilo

Consiste en una aplicación fullstack que contiene el backend y frontend para una pantalla de login con correo y contraseña. El proyecto fue realizado con .NET, Docker y SQLServer para el backend y la base de datos (además del uso de librerías como EntityFramework, JWTBearer, Xunit) y React con TypeScript y Tailwind para el frontend.


# React + TypeScript + Vite

Este proyecto utiliza **React**, **TypeScript** y **Vite** para ofrecer un entorno rápido y moderno de desarrollo frontend.  
Incluye configuración básica de **ESLint** y soporte para **Hot Module Replacement (HMR)**.


## 🚀 Requisitos previos

Asegurarse de tener instalado:
* Docker Desktop
* .NET 8.0 SDK
* Visual Studio 2022 o VS Code (opcional, pero recomendado)
* [Node.js](https://nodejs.org/) (versión 18 o superior)
* [npm](https://www.npmjs.com/)



## ⚙️ Instalación y ejecución

Sigue estos pasos para clonar y ejecutar el proyecto en tu máquina local:

1. Clonar el repositorio:

```bash
git clone https://github.com/juliflorezg/EjercicioLoginNeitek
```

2. Levantar la base de datos con Docker

* Con Docker instalado, ejecutar el siguiente comando:
```bash
docker run -e "ACCEPT_EULA=Y" \
-e "SA_PASSWORD=LoginExerciseAPI2025!" -p 1433:1433 \
--name sqlserverloginexerciseneitek \
-d mcr.microsoft.com/mssql/server:2022-latest
```

Esto levantará la base de datos en un contenedor sin tener que crearla de manera local.

2. Ejecutar el proyecto backend

    1. Entrar a la carpeta de la API Backend
    ```bash
    cd EjercicioLoginNeitekBackend
    ```

    2. Restaurar paquetes NuGet:
    ```bash
    dotnet restore
    ```

    3. Compilar el proyecto:
    ```bash
    dotnet build
    ```

    4. Ejecutar la API:
    ```bash
    dotnet run --project EjercicioLoginNeitekBackend
    ```

3. Ejecutar el proyecto frontend

    1. Entrar a la carpeta de la app frontend
    ```bash
    cd EjercicioLoginNeitekFrontend
    ```

    2. Instalar dependencias
    ```bash
    npm install
    ```

    3. Ejecutar el servidor de desarrollo
    ```bash
    npm run dev 
    ```

* Una vez realizados los pasos anteriores, el proyecto ya debería estar listo para realizar las pruebas necesarias.

## Funcionalidades adicionales al reto

* Adición de la entidad ```UserType``` para relacionar un usuario con un tipo de usuario
* Pantalla de registro o 'signup' donde el usuario puede ingresar su correo y contraseña así como darse de alta como usuario 'cliente' o 'administrador'
* Pantalla de inicio en la aplicación
* Uso de JWT para generar un token de autenticación cuando el usuario se loguea satisfactoriamente
* Uso de Azure para el despliegue

    ### Despliegue en Azure  
    Para el despliegue hice la creación de un grupo de recursos donde se alojan los servicios para la API (***app service***), para el frontend(***Static Web App***) y la base de datos (***SQL Database***) de Azure, realizando las conexiones y configuraciones necesarias para que los servicios se comuniquen entre si. 
    
    El proyecto se puede visualizar en el siguiente enlace: https://nice-wave-01c143d0f.3.azurestaticapps.net/


## Posibles areas de mejora:

* Redireccionar al usuario una vez se registre o inicie sesión
* Hacer manejo del token JWT para futuras peticiones al backend
* Guardar las credenciales sensibles en el servicio ***Key Vault*** de Azure en producción