using System.Collections.Generic;
using myproject.Roles.Dto;

namespace myproject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}