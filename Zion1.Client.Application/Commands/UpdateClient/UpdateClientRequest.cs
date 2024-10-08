﻿using MediatR;

namespace Zion1.Client.Application.Commands.UpdateClient
{
    public class UpdateClientRequest : IRequest<int>
    {
        public int ClientId { get; set; } = 0;
        public string ClientName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
