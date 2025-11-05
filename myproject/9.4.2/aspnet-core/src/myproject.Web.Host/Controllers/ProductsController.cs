using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using myproject.Controllers;
using myproject.Products;
using myproject.Products.Dto;
using System.Threading.Tasks;

namespace myproject.Web.Host.Controllers
{
    /// <summary>
    /// Optional: Custom controller for Products
    /// Note: ABP already exposes ProductAppService as API automatically
    /// This is only needed if you want custom routing or additional logic
    /// </summary>
    [Route("api/[controller]")]
    public class ProductsController : myprojectControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        /// <summary>
        /// Get all products with paging and filtering
        /// </summary>
        [HttpGet]
        public async Task<PagedResultDto<ProductDto>> GetAll([FromQuery] GetAllProductsInput input)
        {
            return await _productAppService.GetAllAsync(input);
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productAppService.GetAsync(new EntityDto<int>(id));
        }

        /// <summary>
        /// Create new product
        /// </summary>
        [HttpPost]
        public async Task<ProductDto> Create([FromBody] CreateProductDto input)
        {
            return await _productAppService.CreateAsync(input);
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ProductDto> Update(int id, [FromBody] UpdateProductDto input)
        {
            input.Id = id;
            return await _productAppService.UpdateAsync(input);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productAppService.DeleteAsync(new EntityDto<int>(id));
        }
    }
}
