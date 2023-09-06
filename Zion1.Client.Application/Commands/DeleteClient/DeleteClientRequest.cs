using MediatR;

namespace Zion1.Client.Application.Commands.DeleteClient
{
    public class DeleteClientRequest : IRequest<int>
    {
        public int ClientId { get; set; } = 0;

        public DeleteClientRequest()
        {

        }

        public DeleteClientRequest(int clientId)
        {
            ClientId = clientId;
        }
    }
}
