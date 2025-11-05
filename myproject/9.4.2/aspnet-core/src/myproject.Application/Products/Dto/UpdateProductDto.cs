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
