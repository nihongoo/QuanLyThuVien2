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
    public class PhieuTSev : IPhieuTSev
    {
        PhieuTRepo _repo;
        public PhieuTSev()
        {
            _repo = new();
        }
        public PhieuTra Create(PhieuTra obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
            throw new NotImplementedException();
        }

        public List<PhieuTraView> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public List<QLMSView> GetQLMS()
        {
            return _repo.GetQLMS();
        }

        public List<T> GetRecords<T>()
        {
            return _repo.GetRecords<T>();
            throw new NotImplementedException();
        }

        public void Update(int Id, PhieuTra obj)
        {
            _repo.Update(Id, obj);
            //throw new NotImplementedException();
        }
    }
}
