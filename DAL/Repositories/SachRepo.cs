using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
            var exobj = _dBContext.Sach.FirstOrDefault(c => c.IDSach == obj.IDSach);
            if (exobj != null)
            {
                exobj.TenSach = obj.TenSach;
                exobj.IDTacGia = obj.IDTacGia;
                exobj.IDNgonNgu = obj.IDNgonNgu;
                exobj.IDTheLoai = obj.IDTheLoai;
                exobj.HangSach = obj.HangSach;
            }
            else
            {
                // Nếu đối tượng không tồn tại, tạo đối tượng mới
                _dBContext.Sach.Add(obj);
            }

            // Gọi SaveChanges sau khi thực hiện tất cả các thay đổi
            _dBContext.SaveChanges();

            return obj;

        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.Sach.FirstOrDefault(c => c.IDSach == Id);

            if (exobj != null)
            {
                _dBContext.Sach.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }


        public List<SachView> GetAll()
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
            var exobj = _dBContext.Sach.FirstOrDefault(c => c.IDSach == Id);
            if(exobj != null)
            {
                exobj.TenSach = obj.TenSach;
                exobj.IDTacGia = obj.IDTacGia;
                exobj.IDNgonNgu = obj.IDNgonNgu;
                exobj.HangSach = obj.HangSach;
                exobj.IDTheLoai = obj.IDTheLoai;
            }
            _dBContext.Sach.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
