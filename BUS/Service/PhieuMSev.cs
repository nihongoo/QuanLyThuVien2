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
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public List<PhieuMuon> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public void Update(string Id, PhieuMuon obj)
        {
            throw new NotImplementedException();
        }
    }
}
