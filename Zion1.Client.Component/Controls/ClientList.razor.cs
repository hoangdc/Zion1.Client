using RestSharp;
using System.Net.Http.Json;
using System.Text.Json;
using Telerik.Blazor.Components;
using Zion1.Client.Component.Models;

namespace Zion1.Client.Component.Controls
{
    public partial class ClientList
    {
        const string ROOT_URL = "https://hoangdinh.homeip.net/Zion1.api/";
        public List<ClientInfoVM> clientList { get; set; } = new List<ClientInfoVM>();
        public string MessageResult { get; set; } = string.Empty;

        private readonly RestClient _clientApi;
        private readonly RestRequest _requestApi;
        public ClientList()
        {
            _clientApi = new RestClient(ROOT_URL);
            _requestApi = new RestRequest("api/Client");
        }

        protected override async Task OnInitializedAsync()
        {
            await GetClientList();
        }

        private async Task GetClientList()
        {
            try
            {
                var response = await _clientApi.GetAsync(_requestApi);
                if (response.Content != null)
                {
                    clientList = JsonSerializer.Deserialize<List<ClientInfoVM>>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

            }
            catch (Exception ex)
            {
                if(ex.Message.Contains(""))
                {

                }
            }
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
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    using (var client = new HttpClient(httpClientHandler))
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
