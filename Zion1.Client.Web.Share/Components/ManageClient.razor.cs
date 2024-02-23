using Microsoft.AspNetCore.Components;
using RestSharp;
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Zion1.Client.Web.Share.Models;
using Zion1.Common.Components;
using Zion1.Common.Helper.Api;

namespace Zion1.Client.Web.Share.Components
{
    public partial class ManageClient : ComponentApi
    {
        public List<ClientInfoVM> ClientList { get; set; } = [];
        

        protected override async Task OnInitAsync()
        {
            await GetClientList();
            await base.OnInitAsync();
        }

        private async Task GetClientList()
        {
            ClientList = await base.GetAsync<List<ClientInfoVM>>("GetClientList");
        }

        private async Task CreateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;
            //Create data
            await SaveAsync<ClientInfoVM>(clientInfo, "CreateClient");
            //Reload Data
            await GetClientList();
        }

        private async Task UpdateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;
            //Update data
            await SaveAsync<ClientInfoVM>(clientInfo, "UpdateClient");
            //Reload Data
            await GetClientList();
        }

        private async Task DeleteClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;
            //Set param
            //ApiConsumer.Params.Add("clientId", clientInfo.ClientId.ToString());
            //Delete data
            await SaveAsync<ClientInfoVM>(clientInfo, "DeleteClient");
            //Reload Data
            await GetClientList();
        }
    }
}
