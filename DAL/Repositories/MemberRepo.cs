using DAL.Context;
using DAL.Models;
using QuanLyThuVien.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MemberRepo : IMemBer
    {
        DBContext _dBContext;
        public MemberRepo()
        {
            _dBContext = new();
        }
        public List<DocGia> GetAll()
        {
            return _dBContext.DocGia.ToList();
        }

        public List<SachView> GetHangSach()
        {
            return _dBContext.SachView.ToList();
        }

        public void Update(int Id, DocGia obj)
        {
            var exobj = _dBContext.DocGia.FirstOrDefault(c => c.IDDocGia == Id);
            if (exobj != null)
            {
                exobj.DiaChi = obj.DiaChi;
                exobj.SDT = obj.SDT;
                exobj.Ten = obj.Ten;
                exobj.NgayDangKy = obj.NgayDangKy;
                exobj.LoaiThe = obj.LoaiThe;
                exobj.CCCD = obj.CCCD;
            }
            _dBContext.DocGia.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
