# Entity Framework Core

dotnet new console -o EFGetStated

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

```

- Remove DBContext
  > dotnet ef migrations remove
