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
        public virtual DbSet<BDH> BDH { get; set; }
        public virtual DbSet<DocGia> DocGia { get; set; }
        public virtual DbSet<NgonNgu> NgonNgu { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NXB> NXB { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuon { get; set; }
        public virtual DbSet<PhieuMuonCT> PhieuMuonCT { get; set; }
        public virtual DbSet<PhieuTra> PhieuTra { get; set; }
        public virtual DbSet<PhieuTraCT> PhieuTraCT { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<SachView> SachView { get; set; }
        public virtual DbSet<SachCT> SachCT { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TheLoaiSach> TheLoaiSach { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= NIHONGGOO\\SQLEXPRESS ;Initial Catalog= QLTV;Integrated Security=True;TrustServerCertificate=true");

        internal void waite()
        {
            throw new NotImplementedException();
        }
    }
}
