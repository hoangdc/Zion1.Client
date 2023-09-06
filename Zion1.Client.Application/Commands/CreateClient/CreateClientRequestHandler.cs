using MediatR;
using Zion1.Client.Application.Contracts;
using Zion1.Client.Application.Mapper;
using Zion1.Client.Domain.Entities;

namespace Zion1.Client.Application.Commands.CreateClient
{
    public class CreateClientRequestHandler : IRequestHandler<CreateClientRequest, int>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        public CreateClientRequestHandler(IClientCommandRepository clientRepository)
        {
            _clientCommandRepository = clientRepository;
        }

        public async Task<int> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = ClientMapper.Mapper.Map<ClientInfo>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _clientCommandRepository.AddAsync(clientInfo);
            return newClientInfo.ClientId;
        }
    }
}
