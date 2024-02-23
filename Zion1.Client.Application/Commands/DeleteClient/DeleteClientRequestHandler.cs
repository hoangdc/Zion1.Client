using MediatR;
using Zion1.Client.Application.Contracts;

namespace Zion1.Client.Application.Commands.DeleteClient
{
    public class DeleteClientRequestHandler : IRequestHandler<DeleteClientRequest, int>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        public DeleteClientRequestHandler(IClientCommandRepository clientRepository)
        {
            _clientCommandRepository = clientRepository;
        }

        public async Task<int> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = await _clientCommandRepository.GetByIdAsync(request.ClientId);
            if (clientInfo is null)
            {
                throw new ApplicationException("Client not found");
            }
            var newClientInfo = await _clientCommandRepository.DeleteAsync(clientInfo);
            return newClientInfo.ClientId;
        }
    }
}
