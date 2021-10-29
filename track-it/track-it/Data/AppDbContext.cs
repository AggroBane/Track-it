using Microsoft.EntityFrameworkCore;
using track_it.Entities;

namespace track_it.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
