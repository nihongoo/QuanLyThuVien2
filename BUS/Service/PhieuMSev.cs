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
    public class PhieuMSev : IPhieuMSev
    {
        PhieuMRepo _repo;
        public PhieuMSev()
        {
            _repo = new();
        }
        public PhieuMuon Create(PhieuMuon obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
            //throw new NotImplementedException();
        }

        public List<PhieuMView> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public List<T> GetRecords<T>()
        {
            return _repo.GetRecords<T>();
            throw new NotImplementedException();
        }

        public void Update(int Id, PhieuMuon obj)
        {
            _repo.Update(Id, obj);
            //throw new NotImplementedException();
        }
    }
}
