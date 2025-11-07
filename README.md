# ASP.NET ZERO - ASP.NET Core Version
* Start from here: https://www.aspnetzero.com/Documents/Development-Guide-Core
* This project will be used as startup source for other projects.
* 3rds used on this project:
- Telerik Reporting 2021 R1 SP2 - 15.0.21.326
- Telerik Kendo UI 2021 R1 SP2 - 2021.1.330
- Telerik UI for ASP.NET CORE 2021 R1 SP2 - 2021.1.330

## Kiến trúc của dự án - theo Clean Architecture
- Tầng Domain : DPS.Dms.Core
- Tầng Application : DPS.Dms.Application , DPS.Dms.Application.Shared (DTO)
- Tầng Infrastructure : Zero.EntityFrameworkCore
- Tầng Presentation : Zero.Web.Mvc


## Các bước để thêm 1 chức năng vào phần " Danh mục " 

- Vào trang AppPageNames.cs thêm vào phần class dms
- Tiếp theo, vào trang AppNavigationProvider.cs và thêm code vào hàm MenuCategories
- Tiếp theo, vào AbpZero-vi.xml thêm tiếp 1 dòng với mục đích để hiển thị mục để ấn "Danh sách ngành, lĩnh vực"
- Tiếp theo, tạo model là "SectorCategory"
- Tiếp theo, sửa file ZeroDbContext.cs để chuẩn bị cho bước migration của databse 
- Tiếp theo, dùng PMC ( package management console ) -> cd vào EntityFrameworkCore và chạy lệnh migrate database : 
```
cd Zero.Core.EntityFrameworkCore
dotnet ef migrations add Added_SectorCategory
dotnet ef database update
```
- Tiếp theo, tạo DTO cho CRUD tại mục : D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application.Shared\Dto\Category\SectorCategory lần lượt là : 
    - CreateOrEditSectorCategoryDto - Dùng cho form tạo/sửa
    - GetSectorCategoryForEditOutput - Output khi lấy dữ liệu để edit
    - SectorCategoryDto -  Dùng để hiển thị dữ liệu
- Tiếp theo, tạo ISectorCategoryAppService nằm tại : D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application.Shared\Interface\Category\ và SectorCategoryAppService.cs nằm tại : D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application\Services\Category\SectorCategoryAppService.cs 
- Tiếp theo, cấu hình AutoMapper trong file CustomAutoMapper.cs
- Tiếp theo, tạo SectorCategoryController.cs và SectorCategoryViewModel.cs và CreateOrEditSectorCategoryModalViewModel.cs trong Areas/Dms bởi vì đây không phải là một chức năng quản trị ( Nếu đây là 1 chức năng quản trị thì đưa vào Areas/App )

## Các file cần thao tác tiếp


## Các file đã sửa ( thêm code mới vào file )
- AppPageNames.cs
- AppNavigationProvider.cs
- AbpZero.xml
- AbpZero-vi.xml
- AppPermissions.cs
- ZeroDbContext.cs

## Các file đã thêm mới
- D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Core\Category\SectorCategory.cs  - Mục đích : tạo Model gốc
- D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application.Shared\Dto\Category\SectorCategory\  - Mục đích : tạo các DTO cho SectorCategory 
- D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application.Shared\Interface\Category\ISectorCategoryAppService.cs 
- D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application\Services\Category\SectorCategoryAppService.cs

## Workflow khi làm 1 tính năng mới 
- Tạo entity -> Migrate database -> DTO -> CustomDtoMapper.cs -> Interface and AppService ( business logic ) -> UI ( Controller and View )