using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PhieuTRepo : IPhieuT
    {
        DBContext _dBContext;
        public PhieuTRepo()
        {
            _dBContext = new();
        }
        public PhieuTra Create(PhieuTra obj)
        {
            var exobj = _dBContext.PhieuTra.FirstOrDefault(c => c.IDPhieuTra == obj.IDPhieuTra);
            if (exobj != null)
            {
                exobj.IDNhanVien = obj.IDNhanVien;
                exobj.IDDocGia = obj.IDDocGia;
                exobj.NgayMuon = obj.NgayMuon;
                exobj.NgayTra = obj.NgayTra;
                exobj.GhiChu = obj.GhiChu;
            }
            else
            {
                // Nếu đối tượng không tồn tại, tạo đối tượng mới
                _dBContext.PhieuTra.Add(obj);
            }

            // Gọi SaveChanges sau khi thực hiện tất cả các thay đổi
            _dBContext.SaveChanges();
            return obj;
        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.PhieuTra.FirstOrDefault(c => c.IDPhieuTra == Id);

            if (exobj != null)
            {
                _dBContext.PhieuTra.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<PhieuTraView> GetAll()
        {
            var query = from pm in _dBContext.PhieuTra
                        join nv in _dBContext.NhanVien
                        on pm.IDNhanVien equals nv.IDNhanVien
                        join dg in _dBContext.DocGia
                        on pm.IDDocGia equals dg.IDDocGia
                        join nd in _dBContext.NguoiDung
                        on nv.TaiKhoan equals nd.TaiKhoan
                        select new PhieuTraView
                        {
                            IDPhieuTra = pm.IDPhieuTra,
                            NgayMuon = pm.NgayMuon,
                            NgayTra = pm.NgayTra,
                            IDDocGia = pm.IDDocGia,
                            IDNhanVien = pm.IDNhanVien,
                            GhiChu = pm.GhiChu,
                            TenDocGia = dg.Ten,
                            TenNV = nd.Ten
                        };
            return query.ToList();
        }

        public List<QLMSView> GetQLMS()
        {
            var query = from qlms in _dBContext.QuanLyMuonSach
                        join dg in _dBContext.DocGia
                        on qlms.IDDocGia equals dg.IDDocGia
                        join sct in _dBContext.SachCT
                        on qlms.IDSachCT equals sct.IDSachCT
                        join sa in _dBContext.Sach
                        on sct.IDSach equals sa.IDSach
                        select new QLMSView
                        {
                            IDDocGia = qlms.IDDocGia,
                            IDSachCT = qlms.IDSachCT,
                            GhiChu = qlms.GhiChu,
                            TenDocGia = dg.Ten,
                            TenSach = sa.TenSach
                        };
            
            return query.ToList();
        }

        public List<T> GetRecords<T>()
        {
            List<T> records = new List<T>();
            if (typeof(T) == typeof(DocGia))
            {
                return _dBContext.DocGia.ToList() as List<T>;
            }
            else if (typeof(T) == typeof(NhanVienView))
            {

                var query = from nd in _dBContext.NguoiDung
                            join nv in _dBContext.NhanVien
                            on nd.TaiKhoan equals nv.TaiKhoan
                            select new NhanVienView
                            {
                                IDNhanVien = nv.IDNhanVien,
                                TaiKhoan = nd.TaiKhoan,
                                MatKhau = nd.MatKhau,
                                TenNhanVien = nd.Ten
                            };
                return query.ToList() as List<T>;
            }
            return records;
        }

        public void Update(int Id, PhieuTra obj)
        {
            var exobj = _dBContext.PhieuTra.FirstOrDefault(c => c.IDPhieuTra == Id);
            if (exobj != null)
            {
                exobj.NgayMuon = obj.NgayMuon;
                exobj.NgayTra = obj.NgayTra;
                exobj.IDDocGia = obj.IDDocGia;
                exobj.IDNhanVien = obj.IDNhanVien;
                exobj.GhiChu = obj.GhiChu;
            }
            _dBContext.PhieuTra.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
