using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppTuyenSinh.Models
{
    public partial class DbConnect : DbContext
    {
        public DbConnect()
            : base("name=DbConnect")
        {
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocBa> HocBas { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<ThiSinh> ThiSinhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonVi>()
                .Property(e => e.DonVi_Ma)
                .IsFixedLength();

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.Nganhs)
                .WithRequired(e => e.DonVi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nganh>()
                .Property(e => e.Nganh_Ma)
                .IsFixedLength();

            modelBuilder.Entity<Nganh>()
                .Property(e => e.Nganh_ToHopXT)
                .IsUnicode(false);

            modelBuilder.Entity<ThiSinh>()
                .Property(e => e.ThiSinh_DienThoai)
                .IsFixedLength();

            modelBuilder.Entity<ThiSinh>()
                .HasMany(e => e.HocBas)
                .WithRequired(e => e.ThiSinh)
                .WillCascadeOnDelete(false);
        }
    }
}
