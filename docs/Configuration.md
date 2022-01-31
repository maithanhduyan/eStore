### [Reading Values From Appsettings.json In ASP.NET Core](https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/)

Sample appsetting.json

```
"MySettings": {
    "DbConnection": "abc",
    "Email": "abc@domain.com",
    "SMTPPort": "5605"
  }
```

C# Get Configuration Setting from appsetting.json

```
string dbConn = configuration.GetSection("MySettings").GetSection("DbConnection").Value;
```

OR

```
string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
```
