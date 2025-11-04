# ASP.NET Core Zero Documentation

## What is ASP.NET Core Zero

ASP.NET Core Zero là một framework khởi điểm được xây dựng dựa trên nền tảng ASP.NET Core và ABP Framework ( ASP.NET Boilerplate ). Nó cung cấp một kiến trúc ứng dụng hoàn chỉnh voiw các tính năng cơ bản đã được tích hợp sẵn , giúp các nhà phát triển có thể bắt đầu dự án nhanh chóng mà không cần phải xây dựng lại các tính năng cơ bản từ đầu.

ASP.NET Core Zero được phát triển bởi Volosoft và là phiên bản thương mại của ABP Framework, cung cấp các module và tinh năng nâng cao hơn so với phiên bản miễn phí. Nó tuân theo các nguyên tắc thiết kế như Domain-Driven Design (DDD), Multi-tenancy, và các best practices trong phát triển phần mềm hiện đại.

## Some Key Feature

1. Multi-Tenancy (Đa người thuê)

- Hỗ trợ kiến trúc SaaS ( Software as a Service )
- Có thể cấu hình database riêng cho mỗi tenant hoặc chia sẻ chung
- Quản lý tenant động với các tính năng như subdomain routing

2. Authentication and Authrization

- Hệ thống xác thực đa dạng : JWT, Cookie-based, External providers (Google, Facebook, Microsoft)
- Quản lý vai trò (Role) và quyền (Permission) linh hoạt
- Hỗ trợ Two-Factor Authentication (2FA)
- Identity Server Integration cho Single Sign-On (SSO)

3. Moduler Architecture

- Cấu trúc module rõ ràng, dễ bảo trì và mở rộng
- Phân tác rõ ràng giữa Core, Application, Web layers
- Dependency Injection được tích hợp sâu

4. Pre-built UI

- Template sẵn có với Angular, React, hoặc MVC/Razor Pages
- Responsive design với Bootstrap
- Các trang quản trị cơ bản: User, Role, Tenant management
- Localization (đa ngôn ngữ) được tích hợp sẵn

5. Background Jobs

- Hangfire integration để xử lý các tác vụ nền
- Quartz.NET hỗ trợ cho các scheduled jobs
- Reliable job execution với retry mechanism

6. Audit Logging

- Tự động log các thao tác quan trọng
- Theo dõi lịch sử thay đổi dữ liệu 
- Lưu thông tin nguời dùng, thời gian, và các thay đổi chi tiết

7. Data filtering

- Soft delete: xóa mềm dữ liệu, thay vì xóa vĩnh viễn
- Multi-tenancy filter tự động
- Custom filters có thể mở rộng

8. Rapid Applicaion Development tools

- Code generators để tạo CRUD operations nhanh chóng
- ASP.NET Zero Power Tools
- Entity scaffolding với UI

9. Real-time Communication

- SignalR integration cho chat, notifications
- Built-in notification system
- Real-time dashboard updates

10. Mobile support

- Xamarin template cho IOS và Android
- React Native template 
- RESTful API sẵn có cho mobile apps

11. Testing Infrastructure

- Unit test project template
- Integration test setup
- Test data builders

12. Edition and Feature Management

- Quản lý các gói tính năng (editions) cho SaaS
- Feature toggle system
- Subscription management 

## Positive and Negative

### Positive

1. Tiết kiệm thời gian phát triển

- Không cần xây dựng lại các tính năng cơ bản
- Authentication và authorization đã được implement sẵn 
- Giảm 40-60% thời gian phát triển phase đầu tiên của dự án

2. Best practices đucợ áp dụng sẵn

- Domain-Driven Desing (DDD)
- SOLID principles
- Clean Architecture
- Repository Pattern, Unit of Work

3. Bảo mật tốt

- Security được chú trọng tự đầu 
- Protection against common vulnerabilities (CSRF, XSS, SQL Injection)
- Regular security updates

4. Scalability 

- Kiến trúc phù hợp cho cả small và Large applications 
- Hỗ trợ Microservice
- Cloud-ready (Azure, AWS, GCP)

5. Database Flexibility 

- Hỗ trợ nhiều database: SQL Server, MySQL, PostgreSQL, Oracle
- Entity framework core với migration support
- Dapper integration cho high-performance queries

6. Production-ready

- Đã được test kỹ lưỡng
- Logging, monitoring infrastructure
- Performance optimization

### Negative

1. Chi Phí license

- Không miễn phí ( giá từ 2,999 đô cho 3 developer và 1 sản phẩm)
- Renewal fees hàng năm
- Chi phí cao cho startup và dự án nhỏ

2. Over-engineering cho dự án nhỏ

- Quá phức tạp nếu chỉ cần một CRUD đơn giản
- nhiều features khong cần thiết cho small projects
- Performance overhead do abstraction layers

3. Steep Learning Curve

- Cần thời gian để hiểu kiến trúc phức tạp
- Nhiều concepts: DDD, Multi-tenancy, ABP Framework
- Đòi hỏi kiến thức về nhiều công nghệ

4. Tight Coupling với ABP Framework

- Phụ thuộc nhiều vào ABP ecosystem
- Khó migrate sang framework khác
- Phải follow ABP conventions và patterns

5. Customization Challenges

- Thay đổi core behavior có thể phức tạp
- Breaking change khi update version
- Conflict với custom implementations

6. Database Size

- Initial database schema khá lớn
- Nhiều tables mặc dù chưa sử dụng hết features
- Complexity trong database relationships

7. Performance Overhead

- Nhiều abstraction layers có thể ảnh hưởng performance
- Cần optimization cho high-traffic applications
- Memory footprint lớn hơn minimal frameworks

8. Vendor Lock-in

- Phụ thuộc vào readmap của Volosoft
- Discontinued features có thể ảnh hưởng tới dự án
- Limited control over core updates

## When do you need to use APS.NET Core Zero

### Cases where it should be used

1. SaaS Application (Multi-tenant)

- Khi bạn xây dựng ứng dụng SaaS với nhiều khách hàng
- Cần quản lý tenants với data isolation
- Yêu cầu subscription và edition management

2. Enterprise Application

- Dự án lớn, phức tạp với nhiều modules
- Cần authentication và authorization phức tạp
- Yêu cầu audit logging và compliance
- Team lớn cần structure rõ ràng

3. Khi có Budget và Timeline chặt chẽ

- Budget cho license nhưng cần giảm thời gian phát triển
- Dealine gấp, cần production-ready solution nhanh
- ROI (tỉ suất hoàn vốn đầu tư) cao hơn chi phí phát triển và license

4. Dự án cần khả năng mở rộng (Scalability)

- Dự kiến mở rộng lớn trong tương lai
- Cần kiến trúc có hỗ trợ microservice
- Performance (hiệu năng) và availability(tính sẵn sàng) là ưu tiên

5. Team thiếu senior developers

- Team junior cần structure sẵn có 
- Cần best practices được implement sẵn
- Giảm thời gian quyết định kiến trúc

6. Ứng dụng có User Management phức tạp

- Nhiều roles và permissions
- Hệ thống phân cấp đơn vị tổ chức
- Quy trình làm việc phức tạp của người dùng

7. Khi cần mobile apps

- Yêu cầu cả web và mobile (IOS/Android)
- API-first approach
- Cross-platform development

### Cases where it shouldn't be used

1. Dự án nhỏ, đơn giản

- CRUD application đơn giản
- Prototype hoặc bản MVP
- Personal project

2. Ngân sách hạn chế

- Startups giai đoạn đầu
- Không đủ budget cho license

3. Team chưa có kinh nhiệm với .NET Core

- Thời gian học lâu, cần training nhiều

4. Dự án ngắn hạn

- Proof of concept
- Short-term project ( < 3 tháng )
- One-time application

5. Khi cần full control

- Không muốn vendor Lock-in
- Yêu cầu hiệu suất cụ thể

6.Single-tenat application đơn giản

- Không cần Multi-tenancy
- Basic authentication đủ
- Chức năng tối thiểu

## 🚀 Getting Started With Sample Project

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