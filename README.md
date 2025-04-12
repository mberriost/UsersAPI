# UsersAPI
This API was developed with .NET Core 9 and Entity Framework. It uses the Swagger UI to visualize and test endpoints. The database it connects to is SQL Server.

## Installation

These are the installed Nutgets packages:

### Entity Framework:
- Microsoft.EntityFrameWorkCore
- Microsoft.EntityFrameWorkCore.SqlServer
- Microsoft.EntityFrameWorkCore.Tools

### Swagger
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Swagger

After installing, run this command in the Package Manager Console:

```bash
Scaffold-DbContext "Data Source=YOURSERVER;Database=UsersAPI;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
```

![image](https://github.com/user-attachments/assets/b0e12615-e807-43e1-9e3c-5bf4381d27c0)
