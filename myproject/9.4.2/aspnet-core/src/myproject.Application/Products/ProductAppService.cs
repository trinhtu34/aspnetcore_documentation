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
