# Bước 4: DTOs - Hoàn thành ✅

## Các DTOs đã tạo:

### 1. **ProductDto.cs** - Output DTO
- Dùng để trả về dữ liệu từ API
- Chứa: Id, Name, Description, Price, Stock, IsActive, CreationTime
- Mapping: Product → ProductDto

### 2. **CreateProductDto.cs** - Input DTO
- Dùng khi tạo sản phẩm mới
- Validation:
  - Name: Required, MaxLength 200
  - Description: MaxLength 1000
  - Price: Required, > 0
  - Stock: >= 0
- Mapping: CreateProductDto → Product

### 3. **UpdateProductDto.cs** - Input DTO
- Dùng khi cập nhật sản phẩm
- Có thêm Id để xác định sản phẩm cần update
- Validation giống CreateProductDto
- Mapping: UpdateProductDto → Product

### 4. **GetAllProductsInput.cs** - Query DTO
- Dùng cho API GetAll với paging, sorting, filtering
- Kế thừa từ PagedAndSortedResultRequestDto (có sẵn MaxResultCount, SkipCount, Sorting)
- Thêm: Keyword (search), IsActive (filter)

### 5. **ProductMapProfile.cs** - AutoMapper Configuration
- Cấu hình mapping giữa Entity và DTOs
- Tự động được scan và đăng ký bởi AbpAutoMapper

## Cấu trúc thư mục:
```
myproject.Application/
└── Products/
    └── Dto/
        ├── ProductDto.cs
        ├── CreateProductDto.cs
        ├── UpdateProductDto.cs
        ├── GetAllProductsInput.cs
        └── ProductMapProfile.cs
```

## Lợi ích của DTOs:

1. **Tách biệt Entity và API Contract**
   - Entity có thể thay đổi mà không ảnh hưởng API
   - Không expose toàn bộ Entity ra ngoài

2. **Validation tập trung**
   - Data Annotations validation
   - ABP tự động validate trước khi vào AppService

3. **Bảo mật**
   - Không trả về sensitive fields (passwords, internal IDs...)
   - Chỉ expose những gì cần thiết

4. **Performance**
   - Chỉ select những fields cần thiết
   - Giảm data transfer

## Bước tiếp theo:
**Bước 5: Application Service** - Implement business logic
