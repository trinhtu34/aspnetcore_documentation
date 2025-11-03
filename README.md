## 🚀 Getting Started

### Step 1: Clone Repository
```bash
git clone <repository-url>
cd aspnetzero_documentation/myproject
```

### Step 2: Database Setup & Migration
```bash
# Navigate to Migrator project
cd D:\.vs\aspnetzero_documentation\myproject\9.4.2\aspnet-core\src\myproject.Migrator

# Restore NuGet packages
dotnet restore

# Run database migration
dotnet run
```

**What this does:**
- 📊 Creates the database schema
- 🌱 Seeds initial data (admin user, roles, permissions)
- 🔧 Sets up multi-tenancy structure

### Step 3: Run the Application

#### Option A: Using Visual Studio (Recommended)
1. 📂 Open `myproject.sln` in Visual Studio
2. 🎯 Set `myproject.Web.Mvc` as startup project
3. ⚡ Press `F5` or click **Start Debugging**

### Step 4: Access the Application

🌐 **Application URLs:**
- **Web Application**: https://localhost:44311
- **API Documentation**: https://localhost:44311/swagger
- **Health Check**: https://localhost:44311/health

🔑 **Default Login Credentials:**
- **Username**: `admin`
- **Password**: `123qwe`

## 📁 Project Structure

```
myproject/
├── 📂 src/
│   ├── 🏛️ myproject.Core/              # Domain Layer
│   │   ├── Entities/                   # Domain Entities
│   │   ├── Authorization/              # Permissions & Roles
│   │   └── Localization/              # Language Resources
│   ├── 🔧 myproject.Application/       # Application Layer
│   │   ├── Services/                   # Application Services
│   │   ├── DTOs/                      # Data Transfer Objects
│   │   └── Authorization/             # Application Permissions
│   ├── 🗄️ myproject.EntityFrameworkCore/ # Infrastructure Layer
│   │   ├── EntityFrameworkCore/       # DbContext & Configurations
│   │   ├── Migrations/                # Database Migrations
│   │   └── Repositories/              # Repository Implementations
│   ├── 🌐 myproject.Web.Core/         # Web Core Layer
│   │   ├── Authentication/            # JWT & Auth Logic
│   │   ├── Controllers/               # Base Controllers
│   │   └── Startup/                   # Dependency Injection
│   ├── 🎨 myproject.Web.Mvc/          # Presentation Layer (MVC)
│   │   ├── Controllers/               # MVC Controllers
│   │   ├── Views/                     # Razor Views
│   │   ├── wwwroot/                   # Static Files
│   │   └── Areas/                     # Feature Areas
│   ├── 🔄 myproject.Migrator/         # Database Migrator
│   └── 🌍 myproject.Web.Host/         # API Host (for SPA)
├── 📂 test/
│   ├── myproject.Tests/               # Unit Tests
│   └── myproject.Web.Tests/           # Integration Tests
└── 📂 docker/                         # Docker Configurations
```

## ⚙️ Configuration

### Database Configuration
Update connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=myprojectDb; Trusted_Connection=True; TrustServerCertificate=True;"
  }
}
```

or, if you use MSSQL on Docker 

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=myprojectDb; User Id=sa; Password=Password123!; TrustServerCertificate=True;"
  }
}
```

#### 🗄️ Database Connection Issues
- ✅ Ensure SQL Server is running
- ✅ Check connection string format
- ✅ Verify database permissions
- ✅ Try using SQL Server LocalDB

#### Warning 

Currently, I am using MSSQL on Docker