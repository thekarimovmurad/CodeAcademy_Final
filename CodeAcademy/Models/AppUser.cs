using Microsoft.AspNetCore.Identity;

namespace CodeAcademy.Models
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
