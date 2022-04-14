using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BTL_APIMOVIE.Models
{
    public partial class APIMOVIESContext : IdentityDbContext<IdentityUser>
    {
        public APIMOVIESContext()
        {
        }

        public APIMOVIESContext(DbContextOptions<APIMOVIESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBinhluan> TbBinhluans { get; set; } = null!;
        public virtual DbSet<TbLoaiphim> TbLoaiphims { get; set; } = null!;
        public virtual DbSet<TbNguoidung> TbNguoidungs { get; set; } = null!;
        public virtual DbSet<TbPhim> TbPhims { get; set; } = null!;
        public virtual DbSet<TbPhimLoaiPhim> TbPhimLoaiPhims { get; set; } = null!;
        public virtual DbSet<TbPhimQuocgia> TbPhimQuocgia { get; set; } = null!;
        public virtual DbSet<TbQuocgia> TbQuocgia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V8QLP2N\\SQLEXPRESS;Database=APIMOVIES;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TbBinhluan>(entity =>
            {
                entity.HasKey(e => e.Mabinhluan)
                    .HasName("PK_BINHLUAN");

                entity.ToTable("TB_BINHLUAN");

                entity.Property(e => e.Mabinhluan).HasColumnName("MABINHLUAN");

                entity.Property(e => e.Maphim).HasColumnName("MAPHIM");

                entity.Property(e => e.Mataikhoan).HasColumnName("MATAIKHOAN");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(100)
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Thoigian)
                    .HasColumnType("date")
                    .HasColumnName("THOIGIAN");

                entity.HasOne(d => d.MaphimNavigation)
                    .WithMany(p => p.TbBinhluans)
                    .HasForeignKey(d => d.Maphim)
                    .HasConstraintName("FK_TB_PHIM_BINHLUAN");

                entity.HasOne(d => d.MataikhoanNavigation)
                    .WithMany(p => p.TbBinhluans)
                    .HasForeignKey(d => d.Mataikhoan)
                    .HasConstraintName("FK_BINHLUAN_NGUOIDUNG");
            });

            modelBuilder.Entity<TbLoaiphim>(entity =>
            {
                entity.HasKey(e => e.Maloaiphim)
                    .HasName("PK_LOAIPHIM");

                entity.ToTable("TB_LOAIPHIM");

                entity.Property(e => e.Maloaiphim).HasColumnName("MALOAIPHIM");

                entity.Property(e => e.Tenloaiphim)
                    .HasMaxLength(20)
                    .HasColumnName("TENLOAIPHIM");
            });

            modelBuilder.Entity<TbNguoidung>(entity =>
            {
                entity.HasKey(e => e.Mataikhoan)
                    .HasName("PK_TAIKHOAN");

                entity.ToTable("TB_NGUOIDUNG");

                entity.Property(e => e.Mataikhoan).HasColumnName("MATAIKHOAN");

                entity.Property(e => e.Loaitaikhoan)
                    .HasMaxLength(20)
                    .HasColumnName("LOAITAIKHOAN");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(100)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(20)
                    .HasColumnName("TENDANGNHAP");
            });

            modelBuilder.Entity<TbPhim>(entity =>
            {
                entity.HasKey(e => e.Maphim)
                    .HasName("PK_PHIM");

                entity.ToTable("TB_PHIM");

                entity.Property(e => e.Maphim).HasColumnName("MAPHIM");

                entity.Property(e => e.Anh)
                    .HasMaxLength(1000)
                    .HasColumnName("ANH");

                entity.Property(e => e.Danhgiaphim)
                    .HasMaxLength(100)
                    .HasColumnName("DANHGIAPHIM");

                entity.Property(e => e.Duongdan)
                    .HasMaxLength(100)
                    .HasColumnName("DUONGDAN");

                entity.Property(e => e.Motaphim)
                    .HasMaxLength(1000)
                    .HasColumnName("MOTAPHIM");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngonngu)
                    .HasMaxLength(100)
                    .HasColumnName("NGONNGU");

                entity.Property(e => e.Tenphim)
                    .HasMaxLength(100)
                    .HasColumnName("TENPHIM");

                entity.Property(e => e.Thoiluong).HasColumnName("THOILUONG");
            });

            modelBuilder.Entity<TbPhimLoaiPhim>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_PHIM_lOAIPHIM");

                entity.ToTable("TB_Phim_LoaiPhim");

                entity.Property(e => e.Ma).HasColumnName("MA");

                entity.Property(e => e.Maloaiphim).HasColumnName("MALOAIPHIM");

                entity.Property(e => e.Maphim).HasColumnName("MAPHIM");

                entity.HasOne(d => d.MaloaiphimNavigation)
                    .WithMany(p => p.TbPhimLoaiPhims)
                    .HasForeignKey(d => d.Maloaiphim)
                    .HasConstraintName("FK_TB_LoaiPhim");

                entity.HasOne(d => d.MaphimNavigation)
                    .WithMany(p => p.TbPhimLoaiPhims)
                    .HasForeignKey(d => d.Maphim)
                    .HasConstraintName("FK_TB_PHIM");
            });

            modelBuilder.Entity<TbPhimQuocgia>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_PHIM_QUOCGIA");

                entity.ToTable("TB_PHIM_QUOCGIA");

                entity.Property(e => e.Ma).HasColumnName("MA");

                entity.Property(e => e.Maphim).HasColumnName("MAPHIM");

                entity.Property(e => e.Maquocgia).HasColumnName("MAQUOCGIA");

                entity.HasOne(d => d.MaphimNavigation)
                    .WithMany(p => p.TbPhimQuocgia)
                    .HasForeignKey(d => d.Maphim)
                    .HasConstraintName("FK_TB_PHIM_QG");

                entity.HasOne(d => d.MaquocgiaNavigation)
                    .WithMany(p => p.TbPhimQuocgia)
                    .HasForeignKey(d => d.Maquocgia)
                    .HasConstraintName("FK_TB_QUOCGIA");
            });

            modelBuilder.Entity<TbQuocgia>(entity =>
            {
                entity.HasKey(e => e.Maquocgia)
                    .HasName("PK_QUOCGIA");

                entity.ToTable("TB_QUOCGIA");

                entity.Property(e => e.Maquocgia).HasColumnName("MAQUOCGIA");

                entity.Property(e => e.Tenquocgia)
                    .HasMaxLength(20)
                    .HasColumnName("TENQUOCGIA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
