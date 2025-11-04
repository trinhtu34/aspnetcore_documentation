# Tài Liệu ASP.NET Core Zero

## ASP.NET Core Zero là gì?

ASP.NET Core Zero là một framework khởi điểm được xây dựng dựa trên nền tảng ASP.NET Core và ABP Framework (ASP.NET Boilerplate). Nó cung cấp một kiến trúc ứng dụng hoàn chỉnh với các tính năng cơ bản đã được tích hợp sẵn, giúp các nhà phát triển có thể bắt đầu dự án nhanh chóng mà không cần phải xây dựng lại các tính năng cơ bản từ đầu.

ASP.NET Core Zero được phát triển bởi Volosoft và là phiên bản thương mại của ABP Framework, cung cấp các module và tính năng nâng cao hơn so với phiên bản miễn phí. Nó tuân theo các nguyên tắc thiết kế như Domain-Driven Design (DDD), Multi-tenancy, và các best practices trong phát triển phần mềm hiện đại.

## Các Tính Năng Chính

### 1. Đa Người Thuê (Multi-Tenancy)

- Hỗ trợ kiến trúc SaaS (Software as a Service)
- Có thể cấu hình database riêng cho mỗi tenant hoặc chia sẻ chung
- Quản lý tenant động với các tính năng như subdomain routing

### 2. Xác Thực và Phân Quyền

- Hệ thống xác thực đa dạng: JWT, Cookie-based, External providers (Google, Facebook, Microsoft)
- Quản lý vai trò (Role) và quyền (Permission) linh hoạt
- Hỗ trợ xác thực hai yếu tố (Two-Factor Authentication - 2FA)
- Tích hợp Identity Server cho đăng nhập một lần (Single Sign-On - SSO)

### 3. Kiến Trúc Module

- Cấu trúc module rõ ràng, dễ bảo trì và mở rộng
- Phân tách rõ ràng giữa các lớp Core, Application, Web
- Dependency Injection được tích hợp sâu

### 4. Giao Diện Có Sẵn

- Template sẵn có với Angular, React, hoặc MVC/Razor Pages
- Thiết kế responsive với Bootstrap
- Các trang quản trị cơ bản: Quản lý User, Role, Tenant
- Đa ngôn ngữ (Localization) được tích hợp sẵn

### 5. Tác Vụ Nền

- Tích hợp Hangfire để xử lý các tác vụ nền
- Hỗ trợ Quartz.NET cho các công việc theo lịch trình
- Thực thi công việc đáng tin cậy với cơ chế thử lại

### 6. Ghi Nhật Ký Kiểm Toán

- Tự động ghi log các thao tác quan trọng
- Theo dõi lịch sử thay đổi dữ liệu
- Lưu thông tin người dùng, thời gian, và các thay đổi chi tiết

### 7. Lọc Dữ Liệu

- Xóa mềm (Soft delete): xóa dữ liệu logic thay vì xóa vĩnh viễn
- Bộ lọc multi-tenancy tự động
- Bộ lọc tùy chỉnh có thể mở rộng

### 8. Công Cụ Phát Triển Nhanh

- Trình tạo code để tạo các thao tác CRUD nhanh chóng
- ASP.NET Zero Power Tools
- Entity scaffolding với giao diện người dùng

### 9. Giao Tiếp Thời Gian Thực

- Tích hợp SignalR cho chat, thông báo
- Hệ thống thông báo tích hợp sẵn
- Cập nhật dashboard theo thời gian thực

### 10. Hỗ Trợ Di Động

- Template Xamarin cho iOS và Android
- Template React Native
- RESTful API sẵn có cho ứng dụng di động

### 11. Cơ Sở Hạ Tầng Kiểm Thử

- Template dự án unit test
- Thiết lập integration test
- Trình tạo dữ liệu test

### 12. Quản Lý Phiên Bản và Tính Năng

- Quản lý các gói tính năng (editions) cho SaaS
- Hệ thống bật/tắt tính năng (Feature toggle)
- Quản lý đăng ký (Subscription management)

## Ưu Điểm và Nhược Điểm

### Ưu Điểm

#### 1. Tiết Kiệm Thời Gian Phát Triển

- Không cần xây dựng lại các tính năng cơ bản
- Xác thực và phân quyền đã được triển khai sẵn
- Giảm 40-60% thời gian phát triển giai đoạn đầu tiên của dự án

#### 2. Best Practices Được Áp Dụng Sẵn

- Domain-Driven Design (DDD)
- Nguyên tắc SOLID
- Clean Architecture
- Repository Pattern, Unit of Work

#### 3. Bảo Mật Tốt

- Bảo mật được chú trọng từ đầu
- Bảo vệ chống lại các lỗ hổng phổ biến (CSRF, XSS, SQL Injection)
- Cập nhật bảo mật thường xuyên

#### 4. Khả Năng Mở Rộng

- Kiến trúc phù hợp cho cả ứng dụng nhỏ và lớn
- Hỗ trợ Microservices
- Sẵn sàng cho Cloud (Azure, AWS, GCP)

#### 5. Linh Hoạt Về Database

- Hỗ trợ nhiều database: SQL Server, MySQL, PostgreSQL, Oracle
- Entity Framework Core với hỗ trợ migration
- Tích hợp Dapper cho các truy vấn hiệu năng cao

#### 6. Sẵn Sàng Cho Production

- Đã được kiểm thử kỹ lưỡng
- Cơ sở hạ tầng logging và monitoring
- Tối ưu hóa hiệu năng

### Nhược Điểm

#### 1. Chi Phí Bản Quyền

- Không miễn phí (giá từ $2,999 cho 3 developer và 1 sản phẩm)
- Phí gia hạn hàng năm
- Chi phí cao cho startup và dự án nhỏ

#### 2. Quá Phức Tạp Cho Dự Án Nhỏ

- Quá phức tạp nếu chỉ cần một ứng dụng CRUD đơn giản
- Nhiều tính năng không cần thiết cho dự án nhỏ
- Chi phí hiệu năng do các lớp trừu tượng

#### 3. Đường Cong Học Tập Dốc

- Cần thời gian để hiểu kiến trúc phức tạp
- Nhiều khái niệm: DDD, Multi-tenancy, ABP Framework
- Đòi hỏi kiến thức về nhiều công nghệ

#### 4. Gắn Chặt Với ABP Framework

- Phụ thuộc nhiều vào hệ sinh thái ABP
- Khó di chuyển sang framework khác
- Phải tuân theo các quy ước và mẫu thiết kế của ABP

#### 5. Thách Thức Trong Tùy Chỉnh

- Thay đổi hành vi cốt lõi có thể phức tạp
- Breaking changes khi cập nhật phiên bản
- Xung đột với các triển khai tùy chỉnh

#### 6. Kích Thước Database

- Schema database ban đầu khá lớn
- Nhiều bảng mặc dù chưa sử dụng hết tính năng
- Độ phức tạp trong các mối quan hệ database

#### 7. Chi Phí Hiệu Năng

- Nhiều lớp trừu tượng có thể ảnh hưởng hiệu năng
- Cần tối ưu hóa cho ứng dụng lưu lượng cao
- Dung lượng bộ nhớ lớn hơn các framework tối giản

#### 8. Phụ Thuộc Nhà Cung Cấp

- Phụ thuộc vào lộ trình phát triển của Volosoft
- Các tính năng bị ngừng có thể ảnh hưởng đến dự án
- Kiểm soát hạn chế đối với các cập nhật cốt lõi

## Khi Nào Nên Sử Dụng ASP.NET Core Zero

### Các Trường Hợp Nên Sử Dụng

#### 1. Ứng Dụng SaaS (Multi-tenant)

- Khi bạn xây dựng ứng dụng SaaS với nhiều khách hàng
- Cần quản lý tenants với cô lập dữ liệu
- Yêu cầu quản lý đăng ký và phiên bản

#### 2. Ứng Dụng Doanh Nghiệp

- Dự án lớn, phức tạp với nhiều modules
- Cần xác thực và phân quyền phức tạp
- Yêu cầu ghi nhật ký kiểm toán và tuân thủ
- Đội ngũ lớn cần cấu trúc rõ ràng

#### 3. Khi Có Ngân Sách và Thời Hạn Chặt Chẽ

- Có ngân sách cho bản quyền nhưng cần giảm thời gian phát triển
- Deadline gấp, cần giải pháp sẵn sàng production nhanh chóng
- ROI (tỷ suất hoàn vốn đầu tư) cao hơn chi phí phát triển và bản quyền

#### 4. Dự Án Cần Khả Năng Mở Rộng

- Dự kiến mở rộng lớn trong tương lai
- Cần kiến trúc hỗ trợ microservices
- Hiệu năng và tính sẵn sàng là ưu tiên

#### 5. Đội Ngũ Thiếu Senior Developers

- Đội ngũ junior cần cấu trúc sẵn có
- Cần best practices được triển khai sẵn
- Giảm thời gian quyết định kiến trúc

#### 6. Ứng Dụng Có Quản Lý Người Dùng Phức Tạp

- Nhiều vai trò và quyền
- Hệ thống phân cấp đơn vị tổ chức
- Quy trình làm việc phức tạp của người dùng

#### 7. Khi Cần Ứng Dụng Di Động

- Yêu cầu cả web và mobile (iOS/Android)
- Tiếp cận API-first
- Phát triển đa nền tảng

### Các Trường Hợp Không Nên Sử Dụng

#### 1. Dự Án Nhỏ, Đơn Giản

- Ứng dụng CRUD đơn giản
- Prototype hoặc bản MVP
- Dự án cá nhân

#### 2. Ngân Sách Hạn Chế

- Startups giai đoạn đầu
- Không đủ ngân sách cho bản quyền

#### 3. Đội Ngũ Chưa Có Kinh Nghiệm Với .NET Core

- Thời gian học lâu, cần đào tạo nhiều
- Thiếu kiến thức nền tảng về .NET ecosystem

#### 4. Dự Án Ngắn Hạn

- Proof of concept
- Dự án ngắn hạn (< 3 tháng)
- Ứng dụng một lần

#### 5. Khi Cần Kiểm Soát Hoàn Toàn

- Không muốn phụ thuộc nhà cung cấp
- Yêu cầu tối ưu hóa hiệu năng cụ thể
- Cần tùy chỉnh sâu các thành phần cốt lõi

#### 6. Ứng Dụng Single-Tenant Đơn Giản

- Không cần Multi-tenancy
- Xác thực cơ bản là đủ
- Chức năng tối thiểu

## 🚀 Bắt Đầu Với Dự Án Mẫu

### Bước 1: Clone Repository

```bash
git clone <repository-url>
cd aspnetzero_documentation/myproject
```

### Bước 2: Thiết Lập và Migration Database

```bash
# Di chuyển đến thư mục Migrator
cd D:\.vs\aspnetzero_documentation\myproject\9.4.2\aspnet-core\src\myproject.Migrator

# Khôi phục các gói NuGet
dotnet restore

# Chạy migration database
dotnet run
```

**Các thao tác được thực hiện:**
- 📊 Tạo schema database
- 🌱 Khởi tạo dữ liệu ban đầu (admin user, roles, permissions)
- 🔧 Thiết lập cấu trúc multi-tenancy

### Bước 3: Tải thư viện 

- Để bản demo này có giao diện đẹp thì bạn cần cài thư viện như bootstrap và JQuery, đặt chúng nằm tại đường dẫn ```*.Web.Mvc/wwwroot/libs/```

### Bước 3: Chạy Ứng Dụng

#### Sử Dụng Visual Studio (Khuyến Nghị)

1. 📂 Mở file `myproject.sln` trong Visual Studio
2. 🎯 Đặt `myproject.Web.Mvc` làm startup project
3. ⚡ Nhấn `F5` hoặc click **Start Debugging**

### Bước 4: Truy Cập Ứng Dụng

🌐 **Các URL Ứng Dụng:**
- **Ứng dụng Web**: https://localhost:44311
- **Tài liệu API**: https://localhost:44311/swagger

🔑 **Thông Tin Đăng Nhập Mặc Định:**
- **Tên đăng nhập**: `admin`
- **Mật khẩu**: `123qwe`

## 📁 Cấu Trúc Dự Án

```
myproject/
├── 📂 src/
│   ├── 🏛️ myproject.Core/              # Lớp Domain
│   │   ├── Entities/                   # Các Entity Domain
│   │   ├── Authorization/              # Permissions & Roles
│   │   └── Localization/              # Tài nguyên ngôn ngữ
│   ├── 🔧 myproject.Application/       # Lớp Application
│   │   ├── Services/                   # Application Services
│   │   ├── DTOs/                      # Data Transfer Objects
│   │   └── Authorization/             # Application Permissions
│   ├── 🗄️ myproject.EntityFrameworkCore/ # Lớp Infrastructure
│   │   ├── EntityFrameworkCore/       # DbContext & Configurations
│   │   ├── Migrations/                # Database Migrations
│   │   └── Repositories/              # Repository Implementations
│   ├── 🌐 myproject.Web.Core/         # Lớp Web Core
│   │   ├── Authentication/            # JWT & Auth Logic
│   │   ├── Controllers/               # Base Controllers
│   │   └── Startup/                   # Dependency Injection
│   ├── 🎨 myproject.Web.Mvc/          # Lớp Presentation (MVC)
│   │   ├── Controllers/               # MVC Controllers
│   │   ├── Views/                     # Razor Views
│   │   ├── wwwroot/                   # Static Files
│   │   └── Areas/                     # Feature Areas
│   ├── 🔄 myproject.Migrator/         # Database Migrator
│   └── 🌍 myproject.Web.Host/         # API Host (cho SPA)
├── 📂 test/
│   ├── myproject.Tests/               # Unit Tests
│   └── myproject.Web.Tests/           # Integration Tests
└── 📂 docker/                         # Cấu hình Docker
```

## ⚙️ Cấu Hình

### Cấu Hình Database

Cập nhật connection string trong file `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=myprojectDb; Trusted_Connection=True; TrustServerCertificate=True;"
  }
}
```

Hoặc, nếu bạn sử dụng MSSQL trên Docker:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost; Database=myprojectDb; User Id=sa; Password=Password123!; TrustServerCertificate=True;"
  }
}
```

### 🗄️ Xử Lý Sự Cố Kết Nối Database

- ✅ Đảm bảo SQL Server đang chạy
- ✅ Kiểm tra định dạng connection string
- ✅ Xác minh quyền truy cập database
- ✅ Thử sử dụng SQL Server LocalDB

### ⚠️ Lưu Ý

Hiện tại, tôi đang sử dụng MSSQL trên Docker

## 📚 Tài Nguyên Bổ Sung

### Tài Liệu Chính Thức
- [ASP.NET Zero Documentation](https://docs.aspnetzero.com/)
- [ABP Framework Documentation](https://docs.abp.io/)

### Cộng Đồng
- [ASP.NET Zero Forum](https://support.aspnetzero.com/)
- [GitHub Repository](https://github.com/aspnetzero)

### Hỗ Trợ
- Email: info@aspnetzero.com
- Support Portal: https://support.aspnetzero.com/

---

**Phiên bản tài liệu**: 1.0  
**Cập nhật lần cuối**: 2024
