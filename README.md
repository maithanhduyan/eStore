# eStore

eCommerce Store

# Dot Net eCommerce Store

Create solution

> dotnet new sln -n eStore

Create Web Project

> mkdir Web
> cd Web
> dotnet new webapp -f net6.0
> dotnet new page --name Pizza --namespace RazorPagesPizza.Pages --output Pages

Create API Project

> mkdir API
> cd API
> dotnet new webapi -f net6.0

Create Class Lib

> dotnet new classlib -o Core

Create Infrastructure Project

> dotnet new classlib -o Infrastructure

Add project in to solution

> dotnet sln add Web/Web.csproj
> dotnet sln add API/API.csproj
> dotnet sln add Infrastructure/Infrastructure.csproj

### [Entity Framework Core ](https://docs.microsoft.com/en-us/ef/core/)

In Infrastructure Project

> cd Infrastructure
> dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.1
> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.2
> dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.1
> dotnet add package Microsoft.EntityFrameworkCore.Cosmos --version 6.0.1
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.1
> dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0
> dotnet add package FirebirdSql.EntityFrameworkCore.Firebird --version 8.5.4
> dotnet add package MySql.EntityFrameworkCore --version 5.0.8
> dotnet add package Oracle.EntityFrameworkCore --version 6.21.5

- Add reference project

  > dotnet add Test/EFCore/EFCore.csproj reference Infrastructure/Infrastructure.csproj

- Create table in database

```
dotnet ef migrations add 0000InitialCreate --context Web.Data.ApplicationDbContext -o Data/Migrations
dotnet ef database update
```

- Create SQL Script

```
dotnet ef migrations script -o Data/Migrations/Create.sql
```

##### [Razor Pages with Entity Framework Core in ASP.NET Core ](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio-code)

```
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```

```
dotnet aspnet-codegenerator razorpage -m Student -dc Infrastructure.Data.SchoolContext -udl -outDir Pages\Students --referenceScriptLibraries -sqlite

```
