using MediatR;
using Zion1.Client.Domain.Entities;
using Zion1.Client.Application.Contracts;

namespace Zion1.Client.Application.Queries
{
    public class GetClientListQuery : IRequest<IReadOnlyList<ClientInfo>>
    {
        public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, IReadOnlyList<ClientInfo>>
        {
            private readonly IClientQueryRepository _clientRepository;
            public GetClientListQueryHandler(IClientQueryRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            

            public async Task<IReadOnlyList<ClientInfo>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
            {
                return await _clientRepository.GetAllAsync();
            }
            
        }
    }
}
