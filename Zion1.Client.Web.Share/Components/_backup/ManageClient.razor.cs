using Microsoft.AspNetCore.Components;
using RestSharp;
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Zion1.Client.Web.Share.Models;
using Zion1.Common.Components;

namespace Zion1.Client.Web.Share.Components
{
    public partial class ManageClient : ComponentApi
    {
        public List<ClientInfoVM> ClientList { get; set; } = new List<ClientInfoVM>();
        public string MessageResult { get; set; } = string.Empty;

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

            if (clientInfo != null)
            {

                ApiConsumer.Body = clientInfo;
                //var response = await ApiConsumer.ExecuteAsync("CreateClient");
                var response = await ApiConsumer.ExecuteClientAsync<RestResponse>("CreateClient");

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = response.Content;
                }
                else
                {
                    MessageResult = "Success";
                }
            }
            else
            {
                MessageResult = "Client info is null";
            }

            //Reload Data
            await GetClientList();
        }

        private async Task UpdateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            if (clientInfo != null)
            {
                ApiConsumer.Body = clientInfo;
                var response = await _httpClient.PutAsJsonAsync("api/client", clientInfo);
                if(response.IsSuccessStatusCode)
                {
                    MessageResult = "Success";
                }
                else
                {
                    MessageResult = response.StatusCode + " - " + response.Content.ToString();
                }
                //var response = await ApiConsumer.ExecuteClientAsync<RestResponse>("UpdateClient"); 
                ////var response = await ApiConsumer.ExecuteAsync("UpdateClient");
                //if (!response.IsSuccessStatusCode)
                //{
                //    //Logic for handling unsuccessful response
                //    MessageResult = response.StatusCode + " - " + response.Content.ToString();
                //}
                //else
                //{
                //    MessageResult = "Success";
                //}
            }
            else
            {
                MessageResult = "Client info is null";
            }

            //Reload Data
            await GetClientList();
        }

        private async Task DeleteClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            if (clientInfo != null)
            {

                ApiConsumer.Params.Add("clientId", clientInfo.ClientId.ToString());
                var response = await ApiConsumer.ExecuteAsync("DeleteClient");

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = response.StatusCode + " - " + response.Content.ToString();
                }
                else
                {
                    MessageResult = "Success";
                }
            }
            else
            {
                MessageResult = "Client info is null";
            }

            //Reload Data
            await GetClientList();
        }
    }
}
