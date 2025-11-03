using Abp.AspNetCore.Mvc.ViewComponents;

namespace myproject.Web.Views
{
    public abstract class myprojectViewComponent : AbpViewComponent
    {
        protected myprojectViewComponent()
        {
            LocalizationSourceName = myprojectConsts.LocalizationSourceName;
        }
    }
}
