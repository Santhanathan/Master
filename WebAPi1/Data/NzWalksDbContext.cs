using Microsoft.EntityFrameworkCore;
using WebApplication1.Model.Domain;

namespace WebApplication1.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options): base(options)
        {
            
        }

        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<WalkDificulty> WalkDificulty { get; set; }
    }
}
