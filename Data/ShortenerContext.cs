using Microsoft.EntityFrameworkCore;
using ProyectoRegularizador.Entities;

namespace ProyectoRegularizador.Data
{
    public class ShortenerContext : DbContext
    {

        public DbSet<Url> Urls { get; set; }

        public DbSet<User> Users { get; set; }
        public ShortenerContext(DbContextOptions<ShortenerContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //  .HasMany<Url>(u => u.Urls)
            //  .WithOne(c => c.User);



            base.OnModelCreating(modelBuilder);
        }
    }
}
