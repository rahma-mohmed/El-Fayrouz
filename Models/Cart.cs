using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fayroz.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Image { get; set; }
        public string? UserId { get; set; } 
        public int? RecipeId { get; set; }
    }
}
