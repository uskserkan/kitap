using Microsoft.AspNetCore.Identity;

namespace Kitabim.Models
{
    public class UygulamaUser : IdentityUser
    {
        
        public string FirstName { get; internal set; }
        
        public string LastName { get; internal set; }
    }
}
