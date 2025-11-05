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
