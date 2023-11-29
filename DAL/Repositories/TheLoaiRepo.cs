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
    public class TheLoaiRepo : ITheLoai
    {
        DBContext _dBContext;
        public TheLoaiRepo()
        {
            _dBContext = new();
        }
        public TheLoaiSach Create(TheLoaiSach obj)
        {
            var exobj = _dBContext.TheLoaiSach.FirstOrDefault(c => c.IDTheLoai == obj.IDTheLoai);

            if (exobj == null)
            {
                _dBContext.TheLoaiSach.Add(obj);
                _dBContext.SaveChanges();
                return obj;
            }
            else
            {
                return exobj;
            }
        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.TheLoaiSach.FirstOrDefault(c => c.IDTheLoai == Id);
            if (exobj != null)
            {
                _dBContext.TheLoaiSach.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }


        public void Update(int Id, TheLoaiSach obj)
        {
            var exobj = _dBContext.TheLoaiSach.FirstOrDefault(c => c.IDTheLoai == Id);
            if (exobj != null)
            {
                exobj.TenTheLoai = obj.TenTheLoai;
                exobj.MoTa = obj.MoTa;
            }
            _dBContext.TheLoaiSach.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
