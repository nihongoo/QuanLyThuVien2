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
    public class PhieuMCTSev : IPhieuMCTSev
    {
        PhieuMCT _repo;
        public PhieuMCTSev()
        {
            _repo = new();
        }
        public bool Create(PhieuMuonCT obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public List<PhieuMCTView> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public List<T> GetRecords<T>()
        {
            return _repo.GetRecords<T>();
            throw new NotImplementedException();
        }

        public bool Update(int Id, PhieuMuonCT obj, int iddg, int idsct)
        {
            return _repo.Update(Id, obj, iddg, idsct);
        }
    }
}
