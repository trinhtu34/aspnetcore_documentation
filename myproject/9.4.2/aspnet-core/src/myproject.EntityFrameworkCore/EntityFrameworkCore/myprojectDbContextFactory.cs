using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using myproject.Configuration;
using myproject.Web;

namespace myproject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class myprojectDbContextFactory : IDesignTimeDbContextFactory<myprojectDbContext>
    {
        public myprojectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<myprojectDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            myprojectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(myprojectConsts.ConnectionStringName));

            return new myprojectDbContext(builder.Options);
        }
    }
}
