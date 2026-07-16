<h1 align="center">E.T. Nº12 D.E. 1º "Libertador Gral. José de San Martín"</h1>

<p align="center">
  <img src="https://et12.edu.ar/imgs/et12.svg">
</p>

# Monitoreo

Proyecto escolar que trata sobre el monitoreo de las computadoras dentro de laboratorios. Este sistema esta desarrollado en **.NET 8.0 con C#** y presenta de una integración con una base de datos **MySQL** utilizando el paquete `MySqlConnector` y `Dapper`.

Hecho mediante un plan de aprendizaje de la especialidad "Computación" del segundo bimestre, cursando 5to año en una escuela técnica de la cápital de Buenos Aires, Argentina.

**[Ver plan](https://docs.google.com/document/d/1qmluz8_D9ewM1CwVogVJZieahgNIxKe2JhOZI0hVrfM/edit?tab=t.0)**

---

## Estructura de carpetas

```
monitoreo/
├── docs/...
    └── diagrams/...
├── scripts/
    ├── functions/...
    ├── stored_procedures/...
    └── tables/...
├── src/
    ├── data/...
    ├── domain/...
    └── presentation/...
├── monitoreo.sln
├── .gitattributes
├── .gitignore
└── README.md
```

**Las carpetas `bin/` y `obj/` son generadas por el compilador y estan excluidas por el `.gitignore`**

---

## Despliegue

![C#](https://img.shields.io/badge/Language-C%23-blue)
![MySQL](https://img.shields.io/badge/Database-MySQL-violet)

Siga estas instrucciones para configurar un entorno de desarrollo local y ejecutar el proyecto con éxito.

### Requisitos

---

Asegúrese de tener instalados los siguientes componentes:

| Nombre | Versión | Descripcion |
| :--- | :---: | :--- |
| .NET SDK | `8.0` | Entorno de ejecución y compilación |
| MySQL | `8.0.45` | Motor de base de datos relacional |
| MySqlConnector | `2.6.1` | Driver asíncrono para conectar con MySQL |
| Microsoft.Extensions.Configuration.FileExtensions	| `10.0.9` | Primitivas para leer configuraciones desde archivos |
| Microsoft.Extensions.Configuration | `10.0.9` | Soporte para gestión de configuraciones |
| Microsoft.Extensions.Configuration.Json | `10.0.9` | Lectura de ajustes desde "appsettings.json" |


### Clonar el Repositorio

Abra su terminal o consola de comandos y ejecute:

```bash
git clone https://github.com/matiasfEt12d1/monitoreo
cd monitoreo
```

### Instalar las dependencias

Si estás construyendo el proyecto desde cero, puedes agregar estas librerías rapidamente ejecutando estos comandos en la terminal:

```bash
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
dotnet add package MySql.MySqlConnector
dotnet add package Dapper
``` 

Podes descargar la extension llamada **NuGet Package Manager GUI** de "aliasadidev" para administrar estos paquetes en una interfaz


#### Configuración de la Aplicación

Antes de ejecutar el proyecto debes cambiarle el nombre al archivo llamado *appsettings.Example.json* a `appsettings.json`.

Luego reemplazar con tus datos reales para que funcione correctamente.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=monitoreo;Uid=USUARIO;Pwd=CONTRASEÑA;"
  }
}
```


#### Ejecucion

Finalmente, restaure las dependencias y lance la aplicación:

```bash
dotnet restore
dotnet run --project ./monitoreo/src/presentation/presentation.csproj
```

---

## .gitignore

El `.gitignore` incluido esta basado en la plantilla oficial de Visual Studio para .NET e ignora entre otras cosas:

```
- Artefactos de compilacion: `bin/`, `obj/`
- Archivos de usuario de IDE: `*.suo`, `*.user`, `.vs/`
- Paquetes NuGet descargados: `packages/`
- Resultados de tests: `TestResults/`
- Variables de entorno sensibles: `*.env`
```

<hr style="border: 2px solid #333;">