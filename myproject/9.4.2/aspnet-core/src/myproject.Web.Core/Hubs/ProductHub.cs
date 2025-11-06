using Abp.AspNetCore.SignalR.Hubs;
using Abp.RealTime;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace myproject.Web.Hubs
{
    public class ProductHub : AbpCommonHub
    {
        public ProductHub(IOnlineClientManager onlineClientManager, IOnlineClientInfoProvider clientInfoProvider) 
            : base(onlineClientManager, clientInfoProvider)
        {
        }

        public async Task SendProductUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveProductUpdate", message);
        }

        public async Task NotifyProductCreated(int productId, string productName)
        {
            await Clients.All.SendAsync("ProductCreated", new 
            { 
                id = productId, 
                name = productName,
                message = $"New product '{productName}' has been created!"
            });
        }
    }
}
