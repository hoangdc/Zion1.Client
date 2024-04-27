using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion1.Client.Application.Notifications
{
    public class ClientCreatedSMSHandler : INotificationHandler<ClientCreatedNotification>
    {
        public Task Handle(ClientCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} - Start ClientCreatedSMSHandler with {notification.ClientId}");
            Task.Delay(5000).Wait();
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} - End ClientCreatedSMSHandler with {notification.ClientId}");

            return Task.CompletedTask;
        }
    }
}
