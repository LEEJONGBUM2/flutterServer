using Microsoft.AspNetCore.Identity;

namespace Iconnexz.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public UserType UserType { set; get; }
    }

    public enum UserType
    {
        Individual = 1,
        Organization = 2,
        Vendor = 3
    }
}
