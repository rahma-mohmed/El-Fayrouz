using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fayroz.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password format")]
        public string? Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, try again")]
        [Display(Name = " Confirm password")]
        public string RePassword { get; set; }
    }
}
