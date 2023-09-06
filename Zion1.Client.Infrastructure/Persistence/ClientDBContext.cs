using Microsoft.EntityFrameworkCore;
using Zion1.Client.Domain.Entities;

namespace Zion1.Client.Infrastructure.Persistence
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
        }

        public DbSet<ClientInfo> Clients { get; set; }
    }


}