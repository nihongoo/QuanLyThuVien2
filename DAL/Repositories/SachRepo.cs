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

        public List<T> GetRecords<T>()
        {
            List<T> records = new List<T>();
            if (typeof(T) == typeof(TheLoaiSach))
            {
                return _dBContext.TheLoaiSach.ToList() as List<T>;
            }
            else if (typeof(T) == typeof(TacGia))
            {
                return _dBContext.TacGia.ToList() as List<T>;
            }
            else if (typeof(T) == typeof(NgonNgu))
            {
                return _dBContext.NgonNgu.ToList() as List<T>;
            }
            throw new NotImplementedException();
        }

        public void Update(int Id, Sach obj)
        {
            //_dBContext.Sach.Attach(obj);
            //_dBContext.Entry(obj).State = EntityState.Modified;
            //_dBContext.SaveChanges();
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
            var exobj = query.AsNoTracking().FirstOrDefault(c => c.IDSach == Id);
            if(exobj != null)
            {
                exobj.TenSach = obj.TenSach;
                exobj.IDTacGia = obj.IDTacGia;
                exobj.IDNgonNgu = obj.IDNgonNgu;
                exobj.HangSach = obj.HangSach;
                exobj.IDTheLoai = obj.IDTheLoai;
            }
            _dBContext.Update(exobj);
            _dBContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
