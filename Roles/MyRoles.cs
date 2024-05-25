using Microsoft.AspNetCore.Identity;

namespace CM.Roles
{
    public class MyRoles:IdentityUser
    {
        public const string Role_User = "user";
        public const string Role_Admin = "Admin";
        public const string Role_Publisher = "Publisher";
    }
}
