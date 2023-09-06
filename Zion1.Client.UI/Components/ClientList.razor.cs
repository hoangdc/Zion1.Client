using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Zion1.Client.UI.Models;
using Zion1.Common.API.Consumer;

namespace Zion1.Client.UI.Components
{
    public partial class ClientList
    {
        const string ROOT_URL = "https://hoangdinh.homeip.net/Zion1.api/";
        public List<ClientInfoVM> clientList { get; set; } = new List<ClientInfoVM>();
        public string MessageResult { get; set; } = string.Empty;


        private ApiComsumer _apiConsumer = new ApiComsumer();

        public ClientList()
        {
            
        }

        protected override async Task OnInitializedAsync()
        {
            await GetClientList();
        }

        private async Task GetClientList()
        {
            clientList = await _apiConsumer.ExecuteAsync<ClientInfoVM>("GetClient");
        }

        private async Task CreateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            if (clientInfo != null) 
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ROOT_URL);
                HttpResponseMessage response = await httpClient.PostAsync("api/Client", JsonContent.Create(clientInfo));

                //_requestApi.AddObject(JsonContent.Create(clientInfo));
                //var response = await _clientApi.ExecutePostAsync(_requestApi);

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = await response.Content.ReadAsStringAsync();
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
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ROOT_URL);
                HttpResponseMessage response = await httpClient.PutAsync($"api/Client/{clientInfo.ClientId}", JsonContent.Create(clientInfo));

                //_requestApi.AddObject(JsonContent.Create(clientInfo));
                //var response  = await _clientApi.ExecutePostAsync(_requestApi);

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
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ROOT_URL);
                HttpResponseMessage response = await httpClient.DeleteAsync($"api/Client/{clientInfo.ClientId}");

                //_requestApi.AddObject(JsonContent.Create(clientInfo));
                //var response = await _clientApi.ExecutePostAsync(_requestApi);

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
