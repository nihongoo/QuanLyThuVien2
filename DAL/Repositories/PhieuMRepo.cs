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
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public List<PhieuMuon> GetAll()
        {
            var query = from pm in _dBContext.PhieuMuon
                        join nv in _dBContext.NhanVien
                        on pm.IDNhanVien equals nv.IDNhanVien
                        join dg in _dBContext.DocGia
                        on pm.IDDocGia equals dg.IDDocGia
                        join nd in _dBContext.NguoiDung
                        on nv.TaiKhoan equals nd.TaiKhoan
                        select new PhieuMuon
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
            throw new NotImplementedException();
        }

        public void Update(string Id, PhieuMuon obj)
        {
            throw new NotImplementedException();
        }
    }
}
