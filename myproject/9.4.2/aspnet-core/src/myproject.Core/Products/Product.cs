using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
