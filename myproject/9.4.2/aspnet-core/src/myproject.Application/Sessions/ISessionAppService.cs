using System.Threading.Tasks;
using Abp.Application.Services;
using myproject.Sessions.Dto;

namespace myproject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
