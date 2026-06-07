# ReadNet Library System

## Descripción

ReadNet es un sistema de gestión bibliotecaria desarrollado utilizando una arquitectura cliente-servidor. La aplicación permite administrar autores, libros y miembros mediante operaciones CRUD completas (Crear, Consultar, Actualizar y Eliminar).

El proyecto fue desarrollado utilizando Angular para el frontend, ASP.NET Core Web API para el backend y SQL Server como sistema gestor de base de datos.

---

## Tecnologías Utilizadas

### Frontend

* Angular
* TypeScript
* HTML5
* CSS3

### Backend

* ASP.NET Core Web API
* C#
* Entity Framework Core
* AutoMapper

### Base de Datos

* SQL Server

### Herramientas de Desarrollo

* Visual Studio 2022
* Visual Studio Code
* Swagger
* Git
* GitHub

---

## Arquitectura del Proyecto

El sistema fue desarrollado siguiendo una arquitectura por capas:

### Presentation Layer

Interfaz de usuario desarrollada en Angular.

### API Layer

Controladores REST encargados de exponer los servicios.

### Business Layer

Implementación de la lógica de negocio mediante servicios.

### Data Access Layer

Repositorios encargados de la comunicación con la base de datos.

### Database Layer

SQL Server para almacenamiento persistente de la información.

---

## Funcionalidades Implementadas

### Gestión de Autores

* Consultar autores
* Crear autores
* Editar autores
* Eliminar autores

### Gestión de Libros

* Consultar libros
* Crear libros
* Editar libros
* Eliminar libros

### Gestión de Miembros

* Consultar miembros
* Crear miembros
* Editar miembros
* Eliminar miembros

### API REST

* Endpoints documentados mediante Swagger
* Operaciones GET, POST, PUT y DELETE

---

## Estructura del Proyecto

ReadNet

* ReadNet.API

  * Controllers
  * DTOs
  * Profiles

* ReadNet.Domain

  * Entities
  * Interfaces
  * Services

* ReadNet.DataAccess

  * Context
  * Repositories
  * Seeders

* ReadNetFrontend

  * pages
  * services
  * routes

---

## Configuración y Ejecución

### Backend

1. Abrir la solución en Visual Studio.
2. Configurar la cadena de conexión a SQL Server.
3. Ejecutar las migraciones.
4. Iniciar la API.

Swagger:

https://localhost:7166/swagger

---

### Frontend

1. Abrir el proyecto ReadNetFrontend.
2. Instalar dependencias:

npm install

3. Ejecutar Angular:

ng serve

4. Abrir:

http://localhost:4200

---

## Patrones y Buenas Prácticas Implementadas

* Repository Pattern
* Dependency Injection
* DTO Pattern
* AutoMapper
* Arquitectura por capas
* Principios de separación de responsabilidades
* Servicios desacoplados
