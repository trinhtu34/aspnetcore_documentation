using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using myproject.Authorization;
using myproject.Controllers;
using myproject.Products;

namespace myproject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductsController : myprojectControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
