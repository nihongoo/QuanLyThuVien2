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
    public class NXBRepo : INXB
    {
        DBContext _dBContext;
        public NXBRepo()
        {
            _dBContext = new();
        }
        public NXB Create(NXB obj)
        {
            var exobj = _dBContext.NXB.FirstOrDefault(c => c.IDNXB == obj.IDNXB);

            if (exobj == null)
            {
                _dBContext.NXB.Add(obj);
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
            var exobj = _dBContext.NXB.FirstOrDefault(c => c.IDNXB == Id);
            if (exobj != null)
            {
                _dBContext.NXB.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<NXB> GetAll()
        {
            return _dBContext.NXB.ToList();
        }

        public void Update(int Id, NXB obj)
        {
            var exobj = _dBContext.NXB.FirstOrDefault(c => c.IDNXB == Id);
            if (exobj != null)
            {
                exobj.TenNXB = obj.TenNXB;
                exobj.MoTa = obj.MoTa;
            }
            _dBContext.NXB.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
