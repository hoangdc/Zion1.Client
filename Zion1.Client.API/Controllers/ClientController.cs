using Microsoft.AspNetCore.Mvc;
using Zion1.Client.Application.Commands.CreateClient;
using Zion1.Client.Application.Commands.DeleteClient;
using Zion1.Client.Application.Commands.UpdateClient;
using Zion1.Client.Application.Queries;
using Zion1.Client.Domain.Entities;
using Zion1.Common.API.Controller;

namespace Zion1.Client.API.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CoreController
    {
        [HttpGet]
        public async Task<IReadOnlyList<ClientInfo>> GetClientList()
        {
            return await Mediator.Send(new GetClientListQuery());
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<ClientInfo> GetClient(int clientId)
        {
            return await Mediator.Send(new GetClientQuery(clientId));

        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateClient(CreateClientRequest clientInfo)
        {
            var validator = new CreateClientValidator();
            var result = validator.Validate(clientInfo);

            if (result.IsValid)
            {
                return await Mediator.Send(clientInfo);
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPut]
        public async Task<int> UpdateClient(UpdateClientRequest clientInfo)
        {
            var client = GetClient(clientInfo.ClientId);
            if(client != null)
                return await Mediator.Send(clientInfo);
            return 0;
        }

        [HttpDelete]
        public async Task<int> DeleteClient(DeleteClientRequest clientInfo)
        {
            return await Mediator.Send(new DeleteClientRequest(clientInfo.ClientId));
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task<int> DeleteClientById(int clientId)
        {
            return await Mediator.Send(new DeleteClientRequest(clientId));
        }
    }
}
