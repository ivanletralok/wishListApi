# Proyecto Web API

Este es un proyecto Web API que utiliza la metodología API First y el enfoque Code First con Entity Framework. El proyecto está estructurado para separar la lógica de la base de datos del proyecto de la API.

## Estructura del Proyecto

- **`DatabaseProject`**: Contiene las migraciones, modelos de datos y el contexto de Entity Framework.
- **`WebApiProject`**: Contiene los controladores y lógica de la API, y utiliza la inyección de dependencias para acceder al `DatabaseProject`.

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versión recomendada: 6.0 o superior)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (para bases de datos)
- [Visual Studio](https://visualstudio.microsoft.com/) (opcional pero recomendado)

## Instalación

### Clonar el Repositorio

1. Clona el repositorio utilizando Git:

   ```bash
   git clone https://github.com/usuario/repositorio.git
