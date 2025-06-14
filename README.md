**IdentityAPI** is a RESTful API built with .NET 6, ASP.NET Core, and Entity Framework (Code First). It's designed to manage users and their related requests in a simple social media-like platform. It uses **PostgreSQL** as the relational database and includes **Swagger** for auto-generated API documentation.

---

## Features

* Full CRUD operations for users (`User`)
* Request management linked to each user (`Request`)
* Clean architecture with DTOs and ViewModels
* Logging with **Serilog**
* Auto-documentation with **Swagger**

---

## Technologies Used

* ASP.NET Core (.NET 6)
* Entity Framework Core (Code First)
* PostgreSQL
* Serilog
* Swagger / Swashbuckle
* C#
* Dependency Injection

---

## Project Structure

```
IdentityAPI/
├── Controllers/
│   ├── UsersController.cs
│   └── RequestsController.cs (draft)
├── Model/
│   ├── DTOs/
│   │   ├── UserCreateDTO.cs
│   │   └── UserUpdateDTO.cs
│   ├── ViewModels/
│   │   ├── UserViewModel.cs
│   │   └── RequestViewModel.cs
│   ├── Request.cs
│   └── AppConfig.cs
├── Services/
│   ├── Interfaces/
│   │   └── IUserService.cs
│   └── UserService.cs
├── Service/
│   ├── Model/
│   │   └── User.cs
│   └── UserContext.cs
├── appsettings.json
└── Program.cs
```

---


### Prerequisites

* [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code
* Postman or a browser to test endpoints

## Author

**Siderilla**
Designer & Developer in progress
Based in Genoa, Italy
Passionate about full stack development, music, pixel art, and storytelling

---

## Notes

This project is under development and serves as a training exercise.
For suggestions or contributions, open an issue or contact the author directly.
