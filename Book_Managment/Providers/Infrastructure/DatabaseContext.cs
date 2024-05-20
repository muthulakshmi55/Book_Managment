using Book_Managment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Managment.API.Providers.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DatabaseContext(IConfiguration configuration, DbContextOptions options)
        {
            Configuration = configuration;
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
