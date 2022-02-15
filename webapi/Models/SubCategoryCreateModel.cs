using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class SubCategoryCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]

        public int CategoryId { get; set; }
    }
}
