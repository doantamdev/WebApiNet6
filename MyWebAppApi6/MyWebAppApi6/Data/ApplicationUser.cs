using Microsoft.AspNetCore.Identity;

namespace MyWebAppApi6.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
    }
}
