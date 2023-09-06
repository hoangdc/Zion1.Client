using Zion1.Client.Domain.Entities;
using Zion1.Common.Application.Contracts;

namespace Zion1.Client.Application.Contracts
{
    public interface IClientCommandRepository : ICommandRepository<ClientInfo>
    {
        
    }
}
