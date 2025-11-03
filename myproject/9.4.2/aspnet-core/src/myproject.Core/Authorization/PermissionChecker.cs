using Abp.Authorization;
using myproject.Authorization.Roles;
using myproject.Authorization.Users;

namespace myproject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
