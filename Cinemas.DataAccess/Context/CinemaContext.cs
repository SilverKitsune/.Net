using Cinemas.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cinemas.DataAccess.Context
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Screening> Screening { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Address).IsRequired();
                });

            modelBuilder.Entity<Movie>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Title).IsRequired();
                    entity.Property(m => m.Director).IsRequired();
                    entity.Property(m => m.DateOfPremiere).IsRequired();
                    entity.Property((m => m.Age)).IsRequired();
                });

            modelBuilder.Entity<Screening>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Date).IsRequired();
                    entity.Property(s => s.Time).IsRequired();
                    entity.HasOne(s => s.Cinema)
                        .WithMany(c => c.Screening)
                        .HasForeignKey(s => s.CinemaId)
                        .HasConstraintName("FK_Screening_Cinema");
                    entity.HasOne(s => s.Movie)
                        .WithOne(m => m.Screening)
                        .HasForeignKey<Movie>(s => s.Screening)
                        .HasConstraintName("FK_Screening_Movie");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}