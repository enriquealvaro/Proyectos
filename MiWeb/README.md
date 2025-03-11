# 🎯 Proyecto CoParental - API de Usuarios

Este proyecto es una **API REST en ASP.NET Core** con **Entity Framework Core** y **MySQL**, diseñada para gestionar usuarios con **registro** y **autenticación (login)**.

## 👤 Estructura del Proyecto

```
MiWeb/
├── Controllers/         # Controladores de la API (UsuariosController.cs)
├── Models/             # Modelos de la base de datos (Usuario.cs)
├── Data/               # Contexto de la base de datos (AppDbContext.cs)
├── wwwroot/            # Archivos HTML, CSS, JavaScript
├── appsettings.json    # Configuración de la conexión a MySQL
├── Program.cs          # Configuración principal de la aplicación
└── MiWeb.csproj        # Archivo del proyecto
```


## ⚙ **Instalación y Configuración**
### 🛠 **1. Requisitos Previos**
Antes de ejecutar el proyecto, asegúrate de tener instalados:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/)
- [MySQL Workbench](https://www.mysql.com/products/workbench/)

---

### 🔧 **2. Configurar la Base de Datos**
1. **Abre MySQL Workbench** y ejecuta la siguiente consulta para crear la base de datos:
   ```sql
   CREATE DATABASE miweb;
   ```
2. **Abre el archivo `appsettings.json`** y configura la cadena de conexión:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;port=3306;database=miweb;user=root;password=tu_contraseña"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

### 🚀 **3. Ejecutar el Proyecto**
1. Abre una terminal en la carpeta del proyecto y ejecuta:
   ```bash
   dotnet run
   ```
2. Si todo está correcto, verás un mensaje como:
   ```
   Now listening on: http://localhost:5156
   ```

---

## 🌍 **Uso de la API**

### 📌 **Probar en Postman o `curl`**
#### 👉 **1. Verificar si la API está activa**
```bash
curl -X GET "http://localhost:5156/api/usuarios"
```

#### 👉 **2. Registrar un Usuario**
```bash
curl -X POST "http://localhost:5156/api/usuarios/registro" -H "Content-Type: application/json" -d '{
    "Rol": "Padre",
    "Genero": "Masculino",
    "Nombre": "Juan",
    "Apellidos": "Pérez",
    "Email": "juan@example.com",
    "Password": "123456"
}'
```

#### 👉 **3. Iniciar Sesión**
```bash
curl -X POST "http://localhost:5156/api/usuarios/login" -H "Content-Type: application/json" -d '{
    "Email": "juan@example.com",
    "Password": "123456"
}'
```

---

## 🎨 **Frontend (HTML y JavaScript)**
- **`registro.html`** → Formulario de registro de usuarios.
- **`login.html`** → Formulario de inicio de sesión.
- **JavaScript en el frontend** se encarga de conectar con la API mediante `fetch()`.

---

## 🛠 **Tecnologías Utilizadas**
- **C#** + **ASP.NET Core** 🚀
- **Entity Framework Core** (ORM para interactuar con MySQL)
- **MySQL** (Base de datos)
- **HTML, CSS y JavaScript** (Frontend)
- **Postman / `curl`** (Pruebas de API)

---

## 🔄 **Posibles Mejoras**
✅ Hashear contraseñas con **BCrypt**  
✅ Implementar **tokens JWT** para autenticación segura  
✅ Crear un sistema de **recuperación de contraseña**  

---

## 👥 **Autores**
- **Enrique Álvaro** (@enriquealvaro)


