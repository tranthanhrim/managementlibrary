namespace Managament_Library_v2._0.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryDataContext : DbContext
    {
        public LibraryDataContext()
            : base("name=LibraryDataContext")
        {
        }

        public virtual DbSet<CUONSACH> CUONSACHes { get; set; }
        public virtual DbSet<DAUSACH> DAUSACHes { get; set; }
        public virtual DbSet<DKCHOMUON> DKCHOMUONs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<MATKHAU> MATKHAUs { get; set; }
        public virtual DbSet<MUONSACH> MUONSACHes { get; set; }
        public virtual DbSet<NGONNGU> NGONNGUs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }
        public virtual DbSet<TUASACH> TUASACHes { get; set; }
        public virtual DbSet<VIPHAM> VIPHAMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CUONSACH>()
                .Property(e => e.macuonsach)
                .IsUnicode(false);

            modelBuilder.Entity<CUONSACH>()
                .Property(e => e.madausach)
                .IsUnicode(false);

            modelBuilder.Entity<CUONSACH>()
                .HasMany(e => e.MUONSACHes)
                .WithRequired(e => e.CUONSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DAUSACH>()
                .Property(e => e.madausach)
                .IsUnicode(false);

            modelBuilder.Entity<DAUSACH>()
                .Property(e => e.matuasach)
                .IsUnicode(false);

            modelBuilder.Entity<DAUSACH>()
                .HasMany(e => e.DKCHOMUONs)
                .WithRequired(e => e.DAUSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DKCHOMUON>()
                .Property(e => e.madocgia)
                .IsUnicode(false);

            modelBuilder.Entity<DKCHOMUON>()
                .Property(e => e.madausach)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.madocgia)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.DKCHOMUONs)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .HasOptional(e => e.HOCSINH)
                .WithRequired(e => e.DOCGIA);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.MUONSACHes)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .HasOptional(e => e.NHANVIEN)
                .WithRequired(e => e.DOCGIA);

            modelBuilder.Entity<DOCGIA>()
                .HasOptional(e => e.VIPHAM)
                .WithRequired(e => e.DOCGIA);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.madocgia)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.lop)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .Property(e => e.lop1)
                .IsUnicode(false);

            modelBuilder.Entity<MUONSACH>()
                .Property(e => e.madocgia)
                .IsUnicode(false);

            modelBuilder.Entity<MUONSACH>()
                .Property(e => e.macuonsach)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.madocgia)
                .IsUnicode(false);

            modelBuilder.Entity<THAMSO>()
                .Property(e => e.tenthamso)
                .IsUnicode(false);

            modelBuilder.Entity<THAMSO>()
                .Property(e => e.kieu)
                .IsUnicode(false);

            modelBuilder.Entity<THAMSO>()
                .Property(e => e.giatri)
                .IsUnicode(false);

            modelBuilder.Entity<TUASACH>()
                .Property(e => e.matuasach)
                .IsUnicode(false);

            modelBuilder.Entity<VIPHAM>()
                .Property(e => e.madocgia)
                .IsUnicode(false);
        }
    }
}
