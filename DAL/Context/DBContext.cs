using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BDH> BDHs { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<NgonNgu> NgonNgus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NXB> NXBs { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<PhieuMuonCT> PhieuMuonCTs { get; set; }
        public virtual DbSet<PhieuTra> PhieuTras { get; set; }
        public virtual DbSet<PhieuTraCT> PhieuTraCTs { get; set; }
        public virtual DbSet<Sach> Sachs { get; set; }
        public virtual DbSet<SachCT> SachCTs { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TacGiaCT> TacGiaCTs { get; set; }
        public virtual DbSet<TheLoaiSach> TheLoaiSachs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= NIHONGGOO\\SQLEXPRESS ;Initial Catalog= QLTV;Integrated Security=True;TrustServerCertificate=true");

        internal void waite()
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TacGiaCT>().HasNoKey();
        }
    }
}
