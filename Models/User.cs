using Microsoft.AspNetCore.Identity;

namespace Fayroz.Models
{
    public class User:IdentityUser
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Email {  get; set; }
    }
}
