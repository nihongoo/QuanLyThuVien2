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
    public class TacGiarepo : ITacGia
    {
        DBContext _dBContext;
        public TacGiarepo()
        {
            _dBContext = new();
        }
        public TacGia Create(TacGia obj)
        {
            var exobj = _dBContext.TacGia.FirstOrDefault(c => c.IDTacGia == obj.IDTacGia);

            if (exobj == null)
            {
                _dBContext.TacGia.Add(obj);
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
            var exobj = _dBContext.TacGia.FirstOrDefault(c => c.IDTacGia == Id);
            if (exobj != null)
            {
                _dBContext.TacGia.Remove(exobj);
                _dBContext.SaveChanges();
            }
            //throw new NotImplementedException();
        }

        public List<TacGia> GetAll()
        {
            return _dBContext.TacGia.ToList();
            throw new NotImplementedException();
        }

        public void Update(int Id, TacGia obj)
        {
            var exobj = _dBContext.TacGia.FirstOrDefault(c => c.IDTacGia == Id);
            if(exobj != null)
            {
                //exobj.IDTacGia = obj.IDTacGia;
                exobj.TenTacGia = obj.TenTacGia;
                exobj.MoTa = obj.MoTa;
            }
            _dBContext.TacGia.Update(exobj);
            _dBContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
