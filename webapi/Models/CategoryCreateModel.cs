using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CategoryCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
