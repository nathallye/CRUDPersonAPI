using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using CRUDPersonAPI.Models;

namespace CRUDPersonAPI.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext()
        {
        }

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options,
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CRUDPersonAPIConnection"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__A5D4E15B89531ACF");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Address)
                    .HasMaxLength(100);
            });
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
