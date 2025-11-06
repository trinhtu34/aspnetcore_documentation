# Quy Trình Thêm Một Chức Năng Trong ASP.NET Core Zero

## Workflow

Domain Entity -> Database Migration -> Permission -> DTOs -> App Service ( business logic )-> API Controller -> UI

## Details Of Step With Product Management Feature

### 1. Domain Entity

1. Tạo Folder là tên của Service
2. Tạo file ví dụ như Product.cs chứa các properties của đối tượng
3. Code ví dụ như sau :
```csharp
namespace myproject.Products
{
    [Table("Products")]
    public class Product : FullAuditedEntity<int>, IMustHaveTenant
    {
        public const int MaxNameLength = 200;
        public const int MaxDescriptionLength = 1000;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
    }
}

```

### 2. Database Migration

1. Thêm DbSet vào etcDbContext.cs ví dụ như sau 
```csharp
using myproject.Products;

namespace myproject.EntityFrameworkCore
{
    public class myprojectDbContext : AbpZeroDbContext<Tenant, Role, User, myprojectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Product> Products { get; set; }
        
        public myprojectDbContext(DbContextOptions<myprojectDbContext> options)
            : base(options)
        {
        }
    }
}
```
2. Tạo file Migration bằng cách chạy 2 lệnh sau 

```bash
cd c:\Users\trinh\Downloads\myproject\9.4.2\aspnet-core\src\myproject.EntityFrameworkCore

dotnet ef migrations add Added_Product_Entity
```

Tiếp theo, chạy Migration vào database

```bash
cd c:\Users\trinh\Downloads\myproject\9.4.2\aspnet-core\src\myproject.Migrator

dotnet run
```

### 3. Permission 

Lý do cần chỉnh Permission là để phân quyền người dùng. Thực hiện như sau :

1. Thêm nội dung vào file PermissionNames trông myproject.Core.Authorization như sau 
```csharp
        public const string Pages_Products = "Pages.Products";
        public const string Pages_Products_Create = "Pages.Products.Create";
        public const string Pages_Products_Edit = "Pages.Products.Edit";
        public const string Pages_Products_Delete = "Pages.Products.Delete";
```

2. Thêm nội dung sau vào file myprojectAuthorizationProvider.cs, thêm vào hàm SetPermissions : 
```csharp
            var products = context.CreatePermission(PermissionNames.Pages_Products, L("Products"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Create, L("CreateNewProduct"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Edit, L("EditProduct"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Delete, L("DeleteProduct"));
```

3. Thêm nội dung sau vaofo file myproject.xml, thêm vào cuối file và nằm trong thẻ <texts> có sẵn trước đó :
```xml
    <text name="Products">Products</text>
    <text name="CreateNewProduct">Create new product</text>
    <text name="EditProduct">Edit product</text>
    <text name="DeleteProduct">Delete product</text>
    <text name="ProductName">Product name</text>
    <text name="Description">Description</text>
    <text name="Price">Price</text>
    <text name="Stock">Stock</text>
```
### 4. DTOs

1. Tạo ProductDto.cs 
```csharp
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using myproject.Products;
using System;

namespace myproject.Products.Dto
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
```
2. Tạo CreateProductDto.cs
```csharp
using Abp.AutoMapper;
using myproject.Products;
using System.ComponentModel.DataAnnotations;

namespace myproject.Products.Dto
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto
    {
        [Required]
        [StringLength(Product.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Product.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        public bool IsActive { get; set; }
    }
}
```
3. Tạo UpdateProductDto.cs
```csharp
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using myproject.Products;
using System.ComponentModel.DataAnnotations;

namespace myproject.Products.Dto
{
    [AutoMapTo(typeof(Product))]
    public class UpdateProductDto : EntityDto<int>
    {
        [Required]
        [StringLength(Product.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Product.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        public bool IsActive { get; set; }
    }
}
```
4. Tạo GetAllProductsInput.cs
```csharp
using Abp.Application.Services.Dto;

namespace myproject.Products.Dto
{
    public class GetAllProductsInput : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
```
5. Tạo ProductMapProfile
```csharp
using AutoMapper;
using myproject.Products;

namespace myproject.Products.Dto
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
```

### 5. App Service ( business logic )

1. Tạo IProductAppService interface
```csharp
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using myproject.Products.Dto;
using System.Threading.Tasks;

namespace myproject.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, GetAllProductsInput, CreateProductDto, UpdateProductDto>
    {
        Task<ProductDto> GetByIdAsync(int id);
    }
}
```
2. Tạo ProductAppService.cs
```csharp
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using myproject.Authorization;
using myproject.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace myproject.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, GetAllProductsInput, CreateProductDto, UpdateProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository)
            : base(repository)
        {
        }

        [AbpAuthorize(PermissionNames.Pages_Products_Create)]
        public override Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Products_Edit)]
        public override Task<ProductDto> UpdateAsync(UpdateProductDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Products_Delete)]
        public override Task DeleteAsync(Abp.Application.Services.Dto.EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await Repository.GetAsync(id);
            return ObjectMapper.Map<ProductDto>(product);
        }

        protected override IQueryable<Product> CreateFilteredQuery(GetAllProductsInput input)
        {
            return Repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), 
                    x => x.Name.Contains(input.Keyword) || x.Description.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, 
                    x => x.IsActive == input.IsActive.Value);
        }

        protected override IQueryable<Product> ApplySorting(IQueryable<Product> query, GetAllProductsInput input)
        {
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                return base.ApplySorting(query, input);
            }

            return query.OrderByDescending(x => x.CreationTime);
        }
    }
}
```

### 6. API Controller



### 7. UI 

1. Tạo Views/Products/Index.cshtml

2. Tạo wwwroot/view-resource/Views/Index.js

Có lỗi từng xảy ra trong js . Tại project này, tại file abp.dataTable.js đang set default config cho TẤT CẢ DataTables 
```js
$.extend(true, $.fn.dataTable.defaults, {
    dom: "...B..." // B = Buttons placeholder
});
```
Vì có ký tự B trong dom config = Vị trí hiển thị Button ( Export, Print, Copy, ...) là button string . Để không gây là lỗi tương tự thì trong các file js sử dụng Button theo dạng Object để tránh lỗi.