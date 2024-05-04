using System.ComponentModel.DataAnnotations;

namespace Fayroz.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password format")]
        [StringLength(maximumLength:50,ErrorMessage ="Password length must be between 8 and 50",MinimumLength =8)]
        public string? Password { get; set; }
    }
}
