To make app work you need to:
1. Configure database and server.
2. Change "ServerName" in connectionString in appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServerName;Database=Instruments;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
3. Update database in Package Manager Console using Migration:
Update-Database
