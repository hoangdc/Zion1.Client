using Zion1.Client.Application.Contracts;
using Zion1.Client.Domain.Entities;
using Zion1.Common.Infrastructure.Persistence.Repositories;

namespace Zion1.Client.Infrastructure.Persistence.Repositories
{
    public class ClientInfoCommandRepository : CommandRepository<ClientInfo>, IClientCommandRepository
    {
        private ClientDbContext _clientDbContext;
        public ClientInfoCommandRepository(ClientDbContext clientDbContext) : base(clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }
    }
}
