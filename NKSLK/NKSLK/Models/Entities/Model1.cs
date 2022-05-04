using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NKSLK.Models.Entities
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACCOUNT_ROLE> ACCOUNT_ROLE { get; set; }
        public virtual DbSet<CONG_NHAN> CONG_NHAN { get; set; }
        public virtual DbSet<CONG_NHAN_KHOAN> CONG_NHAN_KHOAN { get; set; }
        public virtual DbSet<CONG_VIEC> CONG_VIEC { get; set; }
        public virtual DbSet<DAU_MUC_CV> DAU_MUC_CV { get; set; }
        public virtual DbSet<NHOM_THUC_HIEN_KHOAN> NHOM_THUC_HIEN_KHOAN { get; set; }
        public virtual DbSet<NKSLKs> NKSLKs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
        public virtual DbSet<v_Luong> v_Luong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_ROLE)
                .WithOptional(e => e.ACCOUNT)
                .HasForeignKey(e => e.ID_ACCOUNT);

            modelBuilder.Entity<CONG_NHAN>()
                .HasMany(e => e.CONG_NHAN_KHOAN)
                .WithRequired(e => e.CONG_NHAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONG_VIEC>()
                .Property(e => e.DonGia);

            modelBuilder.Entity<CONG_VIEC>()
                .HasMany(e => e.DAU_MUC_CV)
                .WithRequired(e => e.CONG_VIEC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DAU_MUC_CV>()
                .HasMany(e => e.NKSLKs)
                .WithOptional(e => e.DAU_MUC_CV)
                .HasForeignKey(e => e.CongViec);

            modelBuilder.Entity<NHOM_THUC_HIEN_KHOAN>()
                .HasMany(e => e.CONG_NHAN_KHOAN)
                .WithRequired(e => e.NHOM_THUC_HIEN_KHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHOM_THUC_HIEN_KHOAN>()
                .HasMany(e => e.NKSLKs)
                .WithOptional(e => e.NHOM_THUC_HIEN_KHOAN)
                .HasForeignKey(e => e.NhomThucHienKhoan);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.ACCOUNT_ROLE)
                .WithOptional(e => e.ROLE)
                .HasForeignKey(e => e.ID_ROLE);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.DAU_MUC_CV)
                .WithOptional(e => e.SAN_PHAM)
                .HasForeignKey(e => e.SPApDung);
        }
    }
}
