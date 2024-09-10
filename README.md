# Projet ASP.NET Core Web API avec Entity Framework Core, MySQL et AutoMapper

## Prérequis

- .NET SDK
- MySQL Server & MySQL Workbench
- Visual Studio Code

## 1. Créer un projet ASP.NET Core

```bash
dotnet new webapi -n MyApi
cd MyApi
```

## 2. Installer les packages nécessaires

### Entity Framework Core avec MySQL

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### AutoMapper

```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

## 3. Configurer la connexion à MySQL

- Créez une base de données dans MySQL (par exemple `my_database`).
- Mettez à jour le fichier `appsettings.json` avec la chaîne de connexion MySQL.

  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "server=localhost;database=my_database;user=my_user;password=my_password;"
    }
  }
  ```

## 4. Créer la structure des dossiers
- **Models** : Contient les entités `User` et `Activity`.
- **DTOs** : Contient les objets DTO (`UserDto`, `UserCreationDto`, etc.).
- **Repositories** : Implémente les interfaces `IUserRepository` et `IActivityRepository`.
- **Data** : Contient le fichier `ApplicationDbContext.cs`.

## 5. Configurer Entity Framework Core dans `Program.cs`

Ajoutez les services suivants dans `Program.cs` :

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 25))));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
```

## 6. Exécuter les migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 7. Implémenter AutoMapper

- Créez un fichier `MappingProfile.cs` dans le dossier **DTOs** pour configurer les mappings entre les modèles et les DTOs.

  ```csharp
  public class MappingProfile : Profile
  {
      public MappingProfile()
      {
          CreateMap<User, UserDto>();
          CreateMap<UserCreationDto, User>();
          CreateMap<UserEditionDto, User>();
          CreateMap<Activity, ActivityDto>();
          CreateMap<ActivityCreationDto, Activity>();
          CreateMap<ActivityEditionDto, Activity>();
      }
  }
  ```

- Enregistrez AutoMapper dans les services du projet dans `Program.cs`.

## 8. Lancer le projet avec Swagger

Ajoutez Swagger pour documenter l'API dans `Program.cs` :

```csharp
builder.Services.AddSwaggerGen();
```

Lancez l'API :

```csharp
dotnet run
```

Swagger sera disponible à l'URL http://localhost:5009/swagger.

## 9. Commandes Utiles
- Pour lancer l'application : `dotnet run`
- Pour générer une migration : `dotnet ef migrations add <MigrationName>`
- Pour mettre à jour la base de données : `dotnet ef database update`

```go
Ce fichier `README.md` fournit une vue d'ensemble claire et concise de toutes les étapes nécessaires pour configurer et lancer le projet ASP.NET Core Web API.
```
