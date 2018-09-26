# aspcorewebapi-duis
ASP.NET Core WebAPI 2.1 authorization flow
Microsoft.AspNetCore.App 2.1 + Microsoft.EntityFrameworkCore.Sqlite 2.1.3
### Start App
1) cmd "dotnet restore"
2) cmd "dotnet ef database update"
3) Press "Play" in VS Code
4) http://127.0.0.1:3333/api/authentication?username=Admin - to SingIn
5) http://127.0.0.1:3333/api/values
6) http://127.0.0.1:3333/api/authentication - to SingOut
