using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingApp.EF.TrainingAppEF
{
    public partial class TrainingAppDbContext : DbContext
    {
        public TrainingAppDbContext()
        {
        }

        public TrainingAppDbContext(DbContextOptions<TrainingAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TrainingDetails> TrainingDetails { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-TKV4705;Initial Catalog=TrainingAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TrainingDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TrainingName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
