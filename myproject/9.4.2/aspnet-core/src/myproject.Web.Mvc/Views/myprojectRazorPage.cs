using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace myproject.Web.Views
{
    public abstract class myprojectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected myprojectRazorPage()
        {
            LocalizationSourceName = myprojectConsts.LocalizationSourceName;
        }
    }
}
