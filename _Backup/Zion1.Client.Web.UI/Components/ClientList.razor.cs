using Newtonsoft.Json;
using System.Collections;
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Zion1.Client.Web.UI.Models;
using Zion1.Common.API.Consumer;


namespace Zion1.Client.Web.UI.Components
{
    public partial class ClientList
    {
        public List<ClientInfoVM> clientList { get; set; } = new List<ClientInfoVM>();
        public string MessageResult { get; set; } = string.Empty;

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        public ClientList()
        {
            
        }

        protected override async Task OnInitializedAsync()
        {
            await GetClientList();
            await Task.Delay(2000);
        }

        private async Task GetClientList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetClientList");
            clientList = restResponse.Convert<List<ClientInfoVM>>();
        }

        private async Task CreateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            if (clientInfo != null) 
            {

                _apiConsumer.Body = clientInfo;
                var response = await _apiConsumer.ExecuteAsync("CreateClient");

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
                _apiConsumer.Body = clientInfo;
                var response = await _apiConsumer.ExecuteAsync("UpdateClient");

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

        private async Task DeleteClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            if (clientInfo != null)
            {

                _apiConsumer.Params.Add("clientId", clientInfo.ClientId.ToString());
                var response = await _apiConsumer.ExecuteAsync("DeleteClient");

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
