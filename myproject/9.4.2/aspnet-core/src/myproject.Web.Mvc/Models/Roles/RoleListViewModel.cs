using System.Collections.Generic;
using myproject.Roles.Dto;

namespace myproject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
