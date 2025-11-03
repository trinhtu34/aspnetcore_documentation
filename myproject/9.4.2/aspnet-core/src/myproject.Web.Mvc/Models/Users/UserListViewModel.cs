using System.Collections.Generic;
using myproject.Roles.Dto;

namespace myproject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
