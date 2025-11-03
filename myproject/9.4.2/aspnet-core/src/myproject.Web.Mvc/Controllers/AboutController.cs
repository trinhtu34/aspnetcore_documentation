using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using myproject.Controllers;

namespace myproject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : myprojectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
