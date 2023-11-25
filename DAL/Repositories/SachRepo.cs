using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SachRepo : ISach
    {
        DBContext _dBContext;
        public SachRepo()
        {
            _dBContext = new();
        }
        public Sach Create(Sach obj)
        {
            _dBContext.Sach.Add(obj);
            _dBContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Sach FindByID(int Id)
        {
            return _dBContext.Sach.FirstOrDefault(c => c.IDSach == Id);
            throw new NotImplementedException();
        }

        public List<Sach> GetAll()
        {
            var query = from sach in _dBContext.Sach
                        join TheLoai in _dBContext.TheLoaiSach
                        on sach.IDTheLoai equals TheLoai.IDTheLoai
                        join NgonNgu in _dBContext.NgonNgu
                        on sach.IDNgonNgu equals NgonNgu.IDNgonNgu
                        join tacgia in _dBContext.TacGia
                        on sach.IDTacGia equals tacgia.IDTacGia
                        select new Sach
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
            return query.ToList();

            throw new NotImplementedException();
        }

        public void Update(int Id, Sach obj)
        {
            var exobj = _dBContext.Sach.FirstOrDefault(c => c.IDSach == Id);

            if (exobj == null)
            {
                exobj.IDSach = obj.IDSach;
                exobj.TenSach = obj.TenSach;
                exobj.IDTheLoai = obj.IDTheLoai;
                exobj.IDNgonNgu = obj.IDNgonNgu;
                exobj.HangSach = obj.HangSach;
            }
            _dBContext.Sach.Update(exobj);
            _dBContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
