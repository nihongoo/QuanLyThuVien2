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
    public class TacGiaSev : ITacGiaSev
    {
        TacGiarepo _repo;
        public TacGiaSev()
        {
            _repo = new();
        }
        public TacGia Create(TacGia obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
            //throw new NotImplementedException();
        }

        public List<TacGia> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public void Update(int Id, TacGia obj)
        {
            _repo.Update(Id, obj);
            //throw new NotImplementedException();
        }
    }
}
