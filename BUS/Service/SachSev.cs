using BUS.IService;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class SachSev : ISachSev
    {
        SachRepo _repo;
        public SachSev()
        {
            _repo = new();
        }
        public Sach Create(Sach obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public Sach FindByID(int Id)
        {
            return _repo.FindByID(Id);
            throw new NotImplementedException();
        }

        public List<Sach> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public List<T> GetRecords<T>()
        {
            return _repo.GetRecords<T>();
            throw new NotImplementedException();
        }

        public void Update(int Id, Sach obj)
        {
            _repo.Update(Id, obj);
            //throw new NotImplementedException();
        }
    }
}
