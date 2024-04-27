using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zion1.Client.Application.Commands.CreateClient;

namespace Zion1.Client.Application.Notifications
{
    public class ClientCreatedNotification : INotification
    {
        public int ClientId { get; set; } = 0;
    }
}
