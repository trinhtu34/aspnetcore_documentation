using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myproject.Authorization;

namespace myproject
{
    [DependsOn(
        typeof(myprojectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class myprojectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<myprojectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(myprojectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
