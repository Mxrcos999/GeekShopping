using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductApi.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        [StringLength(300)]

        public string ImageUrl { get; set; }
    }
}
