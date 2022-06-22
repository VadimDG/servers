using Microsoft.EntityFrameworkCore;
using TestWebApi.Data.Models;

namespace TestWebApi.Data
{
    public class ServersDbContext: DbContext
    {
        public ServersDbContext(DbContextOptions<ServersDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);

            modelBuilder.DescribeUser();
        }
    }
}
