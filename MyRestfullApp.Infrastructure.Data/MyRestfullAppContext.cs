using Microsoft.EntityFrameworkCore;
using MyRestfullApp.Infrastructure.Data.Model;

namespace MyRestfullApp.Infrastructure.Data
{
    public class MyRestfullAppContext :DbContext
    {
        public MyRestfullAppContext(DbContextOptions<MyRestfullAppContext>options)
            :base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();
            });
        }
    }
}
