using jago.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace jago.Infrastructure.DBConfiguration
{
    public interface IAppDbContext { }
    public class ApplicationContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public ApplicationContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
