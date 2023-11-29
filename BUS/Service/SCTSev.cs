using BUS.IService;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class SCTSev : ISCTSev
    {
        SCTRepo _repo;
        public SCTSev()
        {
            _repo = new();
        }
        public SachCT Create(SachCT obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public List<SachCTView> GetAll(int Id)
        {
            return _repo.GetAll(Id);
            throw new NotImplementedException();
        }

        public SachCT Update(int Id, SachCT obj)
        {
            return _repo.Update(Id, obj);
            throw new NotImplementedException();
        }
    }
}
