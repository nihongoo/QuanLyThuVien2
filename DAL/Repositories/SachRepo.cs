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
    public class SachRepo : ISach
    {
        DBContext _dBContext;
        public SachRepo()
        {
            _dBContext = new();
        }
        public Sach Create(Sach obj)
        {
            _dBContext.Sachs.Add(obj);
            _dBContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Sach FindByID(int Id)
        {
            return _dBContext.Sachs.FirstOrDefault(c => c.IDSach == Id);
            throw new NotImplementedException();
        }

        public List<Sach> GetAll()
        {
            return _dBContext.Sachs.ToList();
            throw new NotImplementedException();
        }

        public void Update(int Id, Sach obj)
        {
            var exobj = _dBContext.Sachs.FirstOrDefault(c => c.IDSach == Id);

            if (exobj == null)
            {
                exobj.IDSach = obj.IDSach;
                exobj.TenSach = obj.TenSach;
                exobj.IDTheLoai = obj.IDTheLoai;
                exobj.IDNgonNgu = obj.IDNgonNgu;
                exobj.HangSach = obj.HangSach;
            }
            _dBContext.Sachs.Update(exobj);
            _dBContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
