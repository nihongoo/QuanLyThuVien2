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
    public class NXBSev : INXBSev
    {
        NXBRepo _repo;
        public NXBSev()
        {
            _repo = new();
        }
        public NXB Create(NXB obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
            //throw new NotImplementedException();
        }

        public List<NXB> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public void Update(int Id, NXB obj)
        {
            _repo.Update(Id, obj);
            //throw new NotImplementedException();
        }
    }
}
