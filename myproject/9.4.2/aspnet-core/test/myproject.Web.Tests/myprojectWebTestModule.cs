using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myproject.EntityFrameworkCore;
using myproject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace myproject.Web.Tests
{
    [DependsOn(
        typeof(myprojectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class myprojectWebTestModule : AbpModule
    {
        public myprojectWebTestModule(myprojectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(myprojectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(myprojectWebMvcModule).Assembly);
        }
    }
}