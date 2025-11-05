using Abp.Application.Services.Dto;

namespace myproject.Products.Dto
{
    public class GetAllProductsInput : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
