# Hướng dẫn chạy Migration cho Product Entity

## Bước 1: Kiểm tra Connection String
File: `src\myproject.Migrator\appsettings.json`
```
Server=localhost; Database=myprojectDb; Trusted_Connection=True; TrustServerCertificate=True;
```

## Bước 2: Chạy Migrator

### Cách 1: Chạy từ Visual Studio
1. Set `myproject.Migrator` làm Startup Project (chuột phải > Set as Startup Project)
2. Nhấn F5 hoặc Ctrl+F5 để chạy

### Cách 2: Chạy từ Command Line
```bash
cd src\myproject.Migrator
dotnet run
```

## Kết quả mong đợi
- Tạo bảng `Products` trong database với các columns:
  - Id (int, Primary Key, Identity)
  - Name (nvarchar(200), NOT NULL)
  - Description (nvarchar(1000), NULL)
  - Price (decimal(18,2), NOT NULL)
  - Stock (int, NOT NULL)
  - IsActive (bit, NOT NULL)
  - CreationTime (datetime2, NOT NULL)
  - CreatorUserId (bigint, NULL)
  - LastModificationTime (datetime2, NULL)
  - LastModifierUserId (bigint, NULL)
  - IsDeleted (bit, NOT NULL)
  - DeleterUserId (bigint, NULL)
  - DeletionTime (datetime2, NULL)

## Kiểm tra Migration đã chạy thành công
Kết nối SQL Server và chạy:
```sql
SELECT * FROM __EFMigrationsHistory ORDER BY MigrationId DESC
-- Phải thấy: 20241220000000_Added_Product_Entity

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products'
-- Phải trả về 1 row
```
