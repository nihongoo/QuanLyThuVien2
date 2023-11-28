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
    public class UserSev : IUserSev
    {
        UserRepo _repo;
        public UserSev()
        {
            _repo = new();
        }

        public bool Check(string TaiKhoan, string MatKhau)
        {
            return _repo.Check(TaiKhoan, MatKhau);
            throw new NotImplementedException();
        }

        public NguoiDung Create(NguoiDung obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(string TaiKhoan)
        {
            _repo.Delete(TaiKhoan);
        }

        public List<NguoiDung> GetAll(string Search, string Type)
        {
            return _repo.GetAll(Search, Type);
            throw new NotImplementedException();
        }

        public string GetRole(string TaiKhoan)
        {
            return _repo.GetRole(TaiKhoan).ToString();
            throw new NotImplementedException();
        }

        public void Update(string TaiKhoan, NguoiDung obj)
        {
            _repo.Update(TaiKhoan,obj);
            throw new NotImplementedException();
        }
    }
}
