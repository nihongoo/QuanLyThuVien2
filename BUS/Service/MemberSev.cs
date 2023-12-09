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
    public class MemberSev : IMemberSev
    {
        MemberRepo _repo;
        public MemberSev()
        {
            _repo = new();
        }
        public List<DocGia> GetAll()
        {
            return _repo.GetAll();
            throw new NotImplementedException();
        }

        public List<SachView> GetHangSach()
        {
            return _repo.GetHangSach();
            throw new NotImplementedException();
        }

        public void Update(int Id)
        {
            _repo.Update(Id);
        }
    }
}
