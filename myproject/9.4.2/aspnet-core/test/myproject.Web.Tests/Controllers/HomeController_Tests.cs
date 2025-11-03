using System.Threading.Tasks;
using myproject.Models.TokenAuth;
using myproject.Web.Controllers;
using Shouldly;
using Xunit;

namespace myproject.Web.Tests.Controllers
{
    public class HomeController_Tests: myprojectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}