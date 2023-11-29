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
    public class NgonNguRepo : INgonNgu
    {
        DBContext _dBContext;
        public NgonNguRepo()
        {
            _dBContext = new();
        }
        public NgonNgu Create(NgonNgu obj)
        {
            var exobj = _dBContext.NgonNgu.FirstOrDefault(c => c.IDNgonNgu == obj.IDNgonNgu);

            if (exobj == null)
            {
                _dBContext.NgonNgu.Add(obj);
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
            var exobj = _dBContext.NgonNgu.FirstOrDefault(c => c.IDNgonNgu == Id);
            if (exobj != null)
            {
                _dBContext.NgonNgu.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public void Update(int Id, NgonNgu obj)
        {
            var exobj = _dBContext.NgonNgu.FirstOrDefault(c => c.IDNgonNgu == Id);
            if (exobj != null)
            {
                exobj.TenNgonNgu = obj.TenNgonNgu;
                exobj.MoTa = obj.MoTa;
                _dBContext.NgonNgu.Update(exobj);
                _dBContext.SaveChanges();
            }

        }
    }
}
