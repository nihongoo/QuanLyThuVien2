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
    public class MemberRepo : IMemBer
    {
        DBContext _dBContext;
        public MemberRepo()
        {
            _dBContext = new();
        }
        public List<DocGia> GetAll()
        {
            return _dBContext.DocGia.Where(c => c.LoaiThe == "vip").ToList();
        }

        public List<SachView> GetHangSach()
        {
            var query = from sach in _dBContext.Sach
                        join TheLoai in _dBContext.TheLoaiSach
                        on sach.IDTheLoai equals TheLoai.IDTheLoai
                        join NgonNgu in _dBContext.NgonNgu
                        on sach.IDNgonNgu equals NgonNgu.IDNgonNgu
                        join tacgia in _dBContext.TacGia
                        on sach.IDTacGia equals tacgia.IDTacGia
                        select new SachView
                        {
                            IDSach = sach.IDSach,
                            TenSach = sach.TenSach,
                            IDTheLoai = sach.IDTheLoai,
                            IDNgonNgu = sach.IDNgonNgu,
                            HangSach = sach.HangSach,
                            TenTheLoai = TheLoai.TenTheLoai,
                            TenNgonNgu = NgonNgu.TenNgonNgu,
                            TenTacGia = tacgia.TenTacGia
                        };
            return query.Where(c => c.HangSach == "VJp").ToList();
        }

        public void Update(int Id)
        {
            var exobj = _dBContext.DocGia.FirstOrDefault(c => c.IDDocGia == Id);
            if (exobj != null)
            {
                exobj.LoaiThe = "nor";
            }
            _dBContext.DocGia.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
