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
    public class TheLoaiSachSev : ITheLoaiSachSev
    {
        TheLoaiRepo _repo;
        public TheLoaiSachSev()
        {
            _repo = new();
        }
        public TheLoaiSach Create(TheLoaiSach obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public void Update(int Id, TheLoaiSach obj)
        {
            _repo.Update(Id, obj);
        }
    }
}
