using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fayroz.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = "";

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; } = default!;
        public string? Image { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Is Special item?")]
        public bool isSpecial { get; set; } = false;

        [Required(ErrorMessage = "Price is required")]
        [Range(10, 500, ErrorMessage = "Price must be between 10 and 500")]
        public decimal? Price { get; set; }

    public Recipe()
        {
            DateTime = DateTime.Now;
        }
    }
}
