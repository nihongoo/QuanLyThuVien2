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
    public class PhieuMRepo : IPhieuM
    {
        DBContext _dBContext;
        public PhieuMRepo()
        {
            _dBContext = new();
        }

        public PhieuMuon Create(PhieuMuon obj)
        {
            var exobj = _dBContext.PhieuMuon.FirstOrDefault(c => c.IDPhieuMuon == obj.IDPhieuMuon);
            if (exobj != null)
            {
                exobj.IDNhanVien = obj.IDNhanVien;
                exobj.IDDocGia = obj.IDDocGia;
                exobj.NgayMuon = obj.NgayMuon;
                exobj.NgayTra= obj.NgayTra;
                exobj.GhiChu = obj.GhiChu;
            }
            else
            {
                // Nếu đối tượng không tồn tại, tạo đối tượng mới
                _dBContext.PhieuMuon.Add(obj);
            }

            // Gọi SaveChanges sau khi thực hiện tất cả các thay đổi
            _dBContext.SaveChanges();
            return obj;
        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.PhieuMuon.FirstOrDefault(c => c.IDPhieuMuon == Id);

            if (exobj != null)
            {
                _dBContext.PhieuMuon.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<PhieuMView> GetAll()
        {
            var query = from pm in _dBContext.PhieuMuon
                        join nv in _dBContext.NhanVien
                        on pm.IDNhanVien equals nv.IDNhanVien
                        join dg in _dBContext.DocGia
                        on pm.IDDocGia equals dg.IDDocGia
                        join nd in _dBContext.NguoiDung
                        on nv.TaiKhoan equals nd.TaiKhoan
                        select new PhieuMView
                        {
                            IDPhieuMuon = pm.IDPhieuMuon,
                            NgayMuon = pm.NgayMuon,
                            NgayTra = pm.NgayTra,
                            IDDocGia = pm.IDDocGia,
                            IDNhanVien =pm.IDNhanVien,
                            GhiChu =pm.GhiChu,
                            TenDocGia =dg.Ten,
                            TenNV = nd.Ten
                        };
            return query.ToList();
           // throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }

        public void Update(int Id, PhieuMuon obj)
        {
            var exobj = _dBContext.PhieuMuon.FirstOrDefault(c => c.IDPhieuMuon == Id);
            if (exobj != null)
            {
                exobj.NgayMuon = obj.NgayMuon;
                exobj.NgayTra = obj.NgayTra;
                exobj.IDDocGia = obj.IDDocGia;
                exobj.IDNhanVien = obj.IDNhanVien;
                exobj.GhiChu = obj.GhiChu;
            }
            _dBContext.PhieuMuon.Update(exobj);
            _dBContext.SaveChanges();
        }

    }
}
