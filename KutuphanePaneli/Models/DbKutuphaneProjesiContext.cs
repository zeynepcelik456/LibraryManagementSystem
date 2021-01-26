using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class DbKutuphaneProjesiContext : DbContext
    {
        public DbKutuphaneProjesiContext()
        {
        }

        public DbKutuphaneProjesiContext(DbContextOptions<DbKutuphaneProjesiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblHareket> TblHarekets { get; set; }
        public virtual DbSet<TblKategori> TblKategoris { get; set; }
        public virtual DbSet<TblKitap> TblKitaps { get; set; }
        public virtual DbSet<TblPersonel> TblPersonels { get; set; }
        public virtual DbSet<TblUye> TblUyes { get; set; }
        public virtual DbSet<TblYazar> TblYazars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DNNFR5;Database=DbKutuphaneProjesi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<TblHareket>(entity =>
            {
                entity.ToTable("TblHareket");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alistarihi)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ALISTARIHI");

                entity.Property(e => e.Iadetarihi)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("IADETARIHI");

                entity.Property(e => e.Islemdurum)
                    .HasColumnName("ISLEMDURUM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Kitap).HasColumnName("KITAP");

                entity.Property(e => e.Uye).HasColumnName("UYE");

                entity.HasOne(d => d.KitapNavigation)
                    .WithMany(p => p.TblHarekets)
                    .HasForeignKey(d => d.Kitap)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TblHareket_TblKitap");

                entity.HasOne(d => d.PersonelNavigation)
                    .WithMany(p => p.TblHarekets)
                    .HasForeignKey(d => d.Personel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TblHareket_TblPersonel");

                entity.HasOne(d => d.UyeNavigation)
                    .WithMany(p => p.TblHarekets)
                    .HasForeignKey(d => d.Uye)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TblHareket_TblUye");
            });

            modelBuilder.Entity<TblKategori>(entity =>
            {
                entity.ToTable("TblKategori");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Ad)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AD");
            });

            modelBuilder.Entity<TblKitap>(entity =>
            {
                entity.ToTable("TblKitap");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AD");

                entity.Property(e => e.Basimyili)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BASIMYILI")
                    .IsFixedLength(true);

                entity.Property(e => e.Durum)
                    .HasColumnName("DURUM")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Kategori).HasColumnName("KATEGORI");

                entity.Property(e => e.Sayfasayisi)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SAYFASAYISI");

                entity.Property(e => e.Yayinevi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("YAYINEVI");

                entity.Property(e => e.Yazar).HasColumnName("YAZAR");

                entity.HasOne(d => d.KategoriNavigation)
                    .WithMany(p => p.TblKitaps)
                    .HasForeignKey(d => d.Kategori)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TblKitap_TblKategori");

                entity.HasOne(d => d.YazarNavigation)
                    .WithMany(p => p.TblKitaps)
                    .HasForeignKey(d => d.Yazar)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TblKitap_TblYazar");
            });

            modelBuilder.Entity<TblPersonel>(entity =>
            {
                entity.ToTable("TblPersonel");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Personel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERSONEL");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<TblUye>(entity =>
            {
                entity.ToTable("TblUye");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AD");

                entity.Property(e => e.Maİl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MAİL");

                entity.Property(e => e.Soyad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SOYAD");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TELEFON");
            });

            modelBuilder.Entity<TblYazar>(entity =>
            {
                entity.ToTable("TblYazar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AD");

                entity.Property(e => e.Soyad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SOYAD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
