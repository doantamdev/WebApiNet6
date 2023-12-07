using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyWebAppApi6.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext (DbContextOptions<MyDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<NguoiDung>? NguoiDungs { get; set; }
        public DbSet<HangHoaData>? HangHoas { get; set; }
        public DbSet<Loai>? Loais { get; set; }
        public DbSet<DonHang>? DonHangs { get; set; }
        public DbSet<DonHangChiTiet>? DonHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity => 
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh,e.MaHh});

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });
            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.Hoten).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
    
        }
    }
}
