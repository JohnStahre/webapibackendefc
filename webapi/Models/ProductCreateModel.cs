using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = "";
        [Required]
        
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = "";

        [Required]
        public int SubCategoryId { get; set; }
    }
}
