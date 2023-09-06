using MediatR;

namespace Zion1.Client.Application.Commands.CreateClient
{
    public class CreateClientRequest : IRequest<int>
    {
        public string ClientName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
