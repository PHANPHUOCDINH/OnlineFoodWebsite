using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineFoodWebsite.Model
{
    public partial class OnlineFoodWebsiteDbContext : DbContext
    {
        public OnlineFoodWebsiteDbContext()
            : base("name=OnlineFoodWebsiteDbContext")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTNNL>()
                .Property(e => e.MACTN)
                .IsUnicode(false);

            modelBuilder.Entity<CTNNL>()
                .Property(e => e.MANL)
                .IsUnicode(false);

            modelBuilder.Entity<CTNNL>()
                .Property(e => e.CHIPHI)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTNNL>()
                .Property(e => e.DONVITINH)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MACTHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAMON)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TRANGTHAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIMON>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.MAMON)
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MON>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<MON>()
                .Property(e => e.DONVITINH)
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MANL)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CHUCVU)
                .IsUnicode(false);
        }
    }
}
