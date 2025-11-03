using Abp.Application.Services;
using myproject.MultiTenancy.Dto;

namespace myproject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

