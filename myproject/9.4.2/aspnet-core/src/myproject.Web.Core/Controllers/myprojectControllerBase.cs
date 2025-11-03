using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace myproject.Controllers
{
    public abstract class myprojectControllerBase: AbpController
    {
        protected myprojectControllerBase()
        {
            LocalizationSourceName = myprojectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
