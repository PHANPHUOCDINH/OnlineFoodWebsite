using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineFoodWebsite.Model
{
    public partial class FoodOnlineWebsiteDbContext : DbContext
    {
        public FoodOnlineWebsiteDbContext()
            : base("name=FoodOnlineWebsiteDbContext")
        {
        }

        public virtual DbSet<CTNNL> CTNNLs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIMON> LOAIMONs { get; set; }
        public virtual DbSet<MON> MONs { get; set; }
        public virtual DbSet<NGUYENLIEU> NGUYENLIEUx { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTNNL>()
                .Property(e => e.MACTN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTNNL>()
                .Property(e => e.MANL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTNNL>()
                .Property(e => e.DONVI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.GHICHU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.GHICHU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TRANGTHAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TENTK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.HOTEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIACHI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAIMON>()
                .Property(e => e.MALOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAIMON>()
                .Property(e => e.TENLOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.MAMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.TENMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.MOTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MON>()
                .Property(e => e.LOAIMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MANL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.TENNL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MOTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.TINHTRANG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TENTK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.HOTEN)
                .IsFixedLength();

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TENTK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MK)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
