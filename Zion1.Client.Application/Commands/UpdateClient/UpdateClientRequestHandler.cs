using MediatR;
using Zion1.Client.Application.Contracts;
using Zion1.Client.Application.Mapper;
using Zion1.Client.Domain.Entities;

namespace Zion1.Client.Application.Commands.UpdateClient
{
    public class UpdateClientRequestHandler : IRequestHandler<UpdateClientRequest, int>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        public UpdateClientRequestHandler(IClientCommandRepository clientRepository)
        {
            _clientCommandRepository = clientRepository;
        }

        public async Task<int> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = ClientMapper.Mapper.Map<ClientInfo>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Client not found");
            }
            var newClientInfo = await _clientCommandRepository.UpdateAsync(clientInfo);
            return newClientInfo.ClientId;
        }
    }
}
