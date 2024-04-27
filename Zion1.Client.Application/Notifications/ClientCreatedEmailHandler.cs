using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion1.Client.Application.Notifications
{
    public class ClientCreatedEmailHandler : INotificationHandler<ClientCreatedNotification>
    {
        public Task Handle(ClientCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} - Start ClientCreatedEmailHandler with {notification.ClientId}");
            Task.Delay(5000).Wait();
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} - End ClientCreatedEmailHandler with {notification.ClientId}");

            return Task.CompletedTask;
        }
    }
}
