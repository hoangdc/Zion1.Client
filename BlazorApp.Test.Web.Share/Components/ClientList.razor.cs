using BlazorApp.Test.Web.Share.Models;
using Telerik.Blazor.Components;


namespace BlazorApp.Test.Web.Share.Components
{
    public partial class ClientList
    {
        public List<ClientInfoVM> clientList { get; set; } = new List<ClientInfoVM>();
        public string MessageResult { get; set; } = string.Empty;

        public ClientList()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await GetClientList();

        }

        private async Task GetClientList()
        {
            clientList.Add(new ClientInfoVM() { ClientId = 1, ClientName = "Redeemer1", Address = DateTime.Now.ToString(), Email = "123@mail.com", PhoneNumber = "1234-567-890" });
            clientList.Add(new ClientInfoVM() { ClientId = 2, ClientName = "Redeemer2", Address = DateTime.Now.ToString(), Email = "123@mail.com", PhoneNumber = "1234-567-890" });
            clientList.Add(new ClientInfoVM() { ClientId = 3, ClientName = "Redeemer3", Address = DateTime.Now.ToString(), Email = "123@mail.com", PhoneNumber = "1234-567-890" });
            clientList.Add(new ClientInfoVM() { ClientId = 4, ClientName = "Redeemer4", Address = DateTime.Now.ToString(), Email = "123@mail.com", PhoneNumber = "1234-567-890" });
            //await Task.Delay(5 * 1000);
        }

        private async Task CreateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            //Reload Data
            await GetClientList();
        }

        private async Task UpdateClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;

            //Reload Data
            await GetClientList();
        }

        private async Task DeleteClient(GridCommandEventArgs args)
        {
            ClientInfoVM? clientInfo = args.Item as ClientInfoVM;



            //Reload Data
            await GetClientList();
        }
    }
}
