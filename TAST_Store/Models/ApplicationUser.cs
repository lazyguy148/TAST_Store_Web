using Microsoft.AspNetCore.Identity;

namespace TAST_Store.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;



    }
}
