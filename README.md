# BlazorDevApp
### A demo app in Clean Architecture with Blazor Server-Side

dotnet ef commands for managing database..
```
dotnet ef migrations add <name> -c AppDbContext -p src/BlazorDevApp.Infrastructure -s src/BlazorDevApp.Web -o Data/Migrations
dotnet ef migrations remove -c AppDbContext -p src/BlazorDevApp.Infrastructure -s src/BlazorDevApp.Web
dotnet ef database update -c AppDbContext -p src/BlazorDevApp.Infrastructure -s src/BlazorDevApp.Web
```
