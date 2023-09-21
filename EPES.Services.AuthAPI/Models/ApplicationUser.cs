using Microsoft.AspNetCore.Identity;

namespace EPES.Services.AuthAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
       
    }
}
