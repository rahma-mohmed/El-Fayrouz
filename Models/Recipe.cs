using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Fayroz.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = "";

        [Required]
        [NotMapped]
        public IFormFile ImageFile { get; set; } = default!;
        public string? Image { get; set; }

        public DateTime DateTime { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public bool isSpecial { get; set; } = false;

        public Recipe()
        {
            DateTime = DateTime.Now;
        }        
    }
}
