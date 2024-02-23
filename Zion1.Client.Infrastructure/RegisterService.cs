using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zion1.Client.Application.Commands.CreateClient;
using Zion1.Client.Application.Commands.DeleteClient;
using Zion1.Client.Application.Commands.UpdateClient;
using Zion1.Client.Application.Contracts;
using Zion1.Client.Application.Queries;
using Zion1.Client.Infrastructure.Persistence;
using Zion1.Client.Infrastructure.Persistence.Repositories;

namespace Zion1.Client.Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddClientService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClientDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Zion1.Client"), b => b.MigrationsAssembly(typeof(ClientDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientListQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClientRequest).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateClientRequest).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteClientRequest).Assembly));

            services.AddScoped<IClientCommandRepository, ClientInfoCommandRepository>();
            services.AddScoped<IClientQueryRepository, ClientInfoQueryRepositoty>();

            return services;
        }
    }
}
