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
- Tiếp theo, tạo SectorCategoryController.cs và SectorCategoryViewModel.cs và CreateOrEditSectorCategoryModalViewModel.cs trong Areas/Dms bởi vì đây không phải là một chức năng quản trị ( Nếu đây là 1 chức năng quản trị thì đưa vào Areas/App )
- Thêm Permission tại hàm SetPermissionCategories của file AppAuthorizationProvider.cs
- Tiếp theo, cần tạo Controller Models View Js tất cả đều nằm tại .Web.Mvc -> Areas -> Dms
  - Controller : Areas/Dms/Controller/CategorySectorCategoryController.cs
  - Models : Areas/Dms/Models/CreateOrEditSectorCategoryModalViewModel.cs và Areas/Dms/Models/SectorCategoryViewModel 
  - View : Areas/Dms/Views/SectorCategory/Index.cshtml và Areas/Dms/Views/SectorCategory/_CreateOrEditModal.cshtml và Areas/Dms/Views/SectorCategory/_ViewDetailModal.cshtml
  - JS : wwwroot/view-resources/Areas/Dms/Category/SectorCategory/Index.js và wwwroot/view-resources/Areas/Dms/Category/SectorCategory/_CreateOrEditModal.js 

## Các file đã thao tác ( thêm - sửa code mới vào file )
- AppPageNames.cs
- AppNavigationProvider.cs
- AbpZero.xml
- AbpZero-vi.xml
- AppPermissions.cs
- ZeroDbContext.cs
- D:\Company_Folder\Company_Project\customize\Dms\DPS.Dms.Application\CustomDtoMapper.cs
- ISectorCategoryAppService.cs
- SectorCategoryAppService.cs
- CreateOrEditSectorCategoryDto.cs
- GetSectorCategoryForEditOutput.cs
- SectorCategoryDto.cs
- GetSectorCategoryForViewDto.cs
- GetAllSectorCategoriesInput.cs
- ISectorCategoryAppService.cs
- SectorCategoryAppService.cs
- D:\Company_Folder\Company_Project\src\Zero.Web.Mvc\wwwroot\view-resources\Areas\Dms\Category\SectorCategory\Index.js
- D:\Company_Folder\Company_Project\src\Zero.Web.Mvc\wwwroot\view-resources\Areas\Dms\Category\SectorCategory\_CreateOrEditModal.js
- SectorCategoryController.cs
- CreateOrEditSectorCategoryModalViewModel.cs
- SectorCategoryViewModel.cs
- D:\Company_Folder\Company_Project\src\Zero.Web.Mvc\Areas\Dms\Views\SectorCategory\Index.cshtml
- D:\Company_Folder\Company_Project\src\Zero.Web.Mvc\Areas\Dms\Views\SectorCategory\_CreateOrEditModal.cshtml
- D:\Company_Folder\Company_Project\src\Zero.Web.Mvc\Areas\Dms\Views\SectorCategory\_ViewDetailModal.cshtml

## Workflow khi làm 1 tính năng mới 
- Tạo entity -> Migrate database -> DTO -> CustomDtoMapper.cs -> Interface and AppService ( business logic ) -> UI ( Controller and View )