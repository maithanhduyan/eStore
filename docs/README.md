# eStore project documents base on DotNet

### Create Project Dependencies

1. Create solution

```
dotnet new sln -n eStore

```

2. Create projects

```
mkdir src
cd src
mkdir Web
mkdir Admin
mkdir API
mkdir ApplicationCore
mkdir Infrastructure
cd Web
dotnet new mvc -f net6.0 -o Web

cd ..
cd API
dotnet new webapi -f net6.0

cd ..
cd ApplicationCore
dotnet new classlib -o Entities
dotnet new classlib -o Services

cd ..
dotnet new classlib -o Infrastructure

cd..
cd Admin
dotnet new webapi -f net6.0

dotnet new mvc -o Admin

```

3. Project Preferences

```
dotnet sln add src/Web/Web.csproj
dotnet sln add src/API/API.csproj
dotnet sln add src/Infrastructure/Infrastructure.csproj
dotnet sln add src/ApplicationCore/Entities/Entities.csproj
dotnet sln add src/ApplicationCore/Services/Services.csproj
dotnet sln add src/Admin/Admin.csproj


```

cd src

```
dotnet add Web/Web.csproj reference Infrastructure/Infrastructure.csproj
dotnet add Web/Web.csproj reference ApplicationCore/Entities/Entities.csproj
dotnet add Web/Web.csproj reference ApplicationCore/Services/Services.csproj

dotnet add Admin/Admin.csproj reference Infrastructure/Infrastructure.csproj
dotnet add Admin/Admin.csproj reference ApplicationCore/Entities/Entities.csproj
dotnet add Admin/Admin.csproj reference ApplicationCore/Services/Services.csproj


dotnet add API/API.csproj reference Infrastructure/Infrastructure.csproj
dotnet add API/API.csproj reference ApplicationCore/Entities/Entities.csproj
dotnet add API/API.csproj reference ApplicationCore/Services/Services.csproj

dotnet add ApplicationCore/Services/Services.csproj reference ApplicationCore/Entities/Entities.csproj
dotnet add Infrastructure/Infrastructure.csproj reference ApplicationCore/Entities/Entities.csproj

```

```
src
    Admin
        Admin.csproj
    API
        API.csproj
    ApplicationCore
        Entities
            Entities.csproj
        Services
            Services.csproj
    Infrastructure
        Infrastructure.csproj
    Web
        Web.csproj
```

### Addition Framework

cd Infrastructure

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.1
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.2
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Cosmos --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.1
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0
dotnet add package FirebirdSql.EntityFrameworkCore.Firebird --version 8.5.4
dotnet add package MySql.EntityFrameworkCore --version 5.0.8
dotnet add package Oracle.EntityFrameworkCore --version 6.21.5

```

cd Web

```
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```

### EF Core

```
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet ef migrations add InitialModel --context applicationdbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations
dotnet ef migrations add InitialIdentityModel --context appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Identity/Migrations
```

create Database script

```
dotnet ef migrations script --context applicationdbcontext -p ../Infrastructure/Infrastructure.csproj  -s Web.csproj -o ../Infrastructure/Data/Migrations/Create.sql
```
