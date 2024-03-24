using DairyFarm.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DairyFarm.Data
{
    public class ApplicationContextDB : DbContext
    {
        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options) : base(options)
        {
        }

        public DbSet<Cattle> Cattles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cattle>(entity =>
            {
              entity.Property(e => e.Date)
             .IsRequired()
             .HasColumnType("Date");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
