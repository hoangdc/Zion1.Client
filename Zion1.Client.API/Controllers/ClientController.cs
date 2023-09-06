using Microsoft.AspNetCore.Mvc;
using Zion1.Client.Application.Commands.CreateClient;
using Zion1.Client.Application.Commands.DeleteClient;
using Zion1.Client.Application.Commands.UpdateClient;
using Zion1.Client.Application.Queries;
using Zion1.Client.Domain.Entities;
using Zion1.Common.API.Controller;

namespace Zion1.Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CoreController
    {
        [HttpPost(Name = "CreateClient")]
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

        [HttpPut("{clientId}")]
        public async Task<int> UpdateClient(int clientId, UpdateClientRequest clientInfo)
        {
            if (clientId != clientInfo.ClientId)
            {
                return 0;
            }

            return await Mediator.Send(clientInfo);
        }

        [HttpDelete("{clientId}")]
        public async Task<int> DeleteClient(int clientId)
        {
            return await Mediator.Send(new DeleteClientRequest(clientId));
        }

        [HttpGet(Name = "GetClientList")]
        //[Route("clientlist/{clientid}")]
        public async Task<IReadOnlyList<ClientInfo>> GetClientList()
        {
            return await Mediator.Send(new GetClientListQuery());
        }
    }
}
