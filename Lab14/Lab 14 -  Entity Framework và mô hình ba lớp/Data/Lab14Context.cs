using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Data
{
    public class Lab14Context : DbContext
    {
        public DbSet<MonHoc> MonHocs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MONHOC", t =>
                    t.HasCheckConstraint("CK_MONHOC_SoTinChi", "[SoTinChi] >= 1 AND [SoTinChi] <= 6"));

                entity.HasKey(e => e.MaMonHoc);

                entity.Property(e => e.MaMonHoc)
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.TenMonHoc)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.SoTinChi)
                      .IsRequired();

                entity.Property(e => e.TrangThai)
                      .HasDefaultValue(true);
            });
        }
    }
}