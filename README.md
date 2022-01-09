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

Add project in to solution

> dotnet sln add Web/Web.csproj
