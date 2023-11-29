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
    public class NgonNguSev : INgonNgu
    {
        NgonNguRepo _repo;
        public NgonNguSev()
        {
            _repo = new();
        }
        public NgonNgu Create(NgonNgu obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public void Update(int Id, NgonNgu obj)
        {
            _repo.Update(Id, obj);
        }
    }
}
