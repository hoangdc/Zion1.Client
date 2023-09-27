using MediatR;
using Zion1.Client.Domain.Entities;
using Zion1.Client.Application.Contracts;

namespace Zion1.Client.Application.Queries
{
    public class GetClientQuery : IRequest<ClientInfo>
    {
        public int ClientId { get; set; } = 0;

        public GetClientQuery(int clientId)
        {
            ClientId = clientId;
        }

        public class GetClientListQueryHandler : IRequestHandler<GetClientQuery, ClientInfo>
        {
            private readonly IClientQueryRepository _clientRepository;
            public GetClientListQueryHandler(IClientQueryRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            

            public async Task<ClientInfo> Handle(GetClientQuery request, CancellationToken cancellationToken)
            {
                return await _clientRepository.GetByIdAsync(request.ClientId);
            }
            
        }
    }
}
