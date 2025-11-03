using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using myproject.Configuration.Dto;

namespace myproject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : myprojectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
