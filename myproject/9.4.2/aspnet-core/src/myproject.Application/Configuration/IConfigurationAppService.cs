using System.Threading.Tasks;
using myproject.Configuration.Dto;

namespace myproject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
