using System.ComponentModel.DataAnnotations;

namespace Fayroz.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "User Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [MinLength(8,ErrorMessage ="Minimum Length is 8")]
        public string Password { get; set; }


        [Display(Name = "RePassword")]
        [Required(ErrorMessage = "This failed is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, try again")]
        [MinLength(8, ErrorMessage = "Minimum Length is 8")]
        public string RePassword { get; set; }


        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email")]
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}