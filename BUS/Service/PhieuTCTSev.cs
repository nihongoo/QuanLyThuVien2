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
    public class PhieuTCTSev : IPhieuTCTSev
    {
        PhieuTCTRepo _repo;
        public PhieuTCTSev()
        {
            _repo = new();
        }
        public bool Create(PhieuTraCT obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public List<PhieuTCTView> GetAll()
        {
            return _repo.GetAll();
        }

        public List<T> GetRecords<T>()
        {
            return _repo.GetRecords<T>();
        }

        public bool Update(int Id, PhieuTraCT obj, int iddg, int idsct)
        {
            return _repo.Update(Id, obj, iddg, idsct);
        }
    }
}
