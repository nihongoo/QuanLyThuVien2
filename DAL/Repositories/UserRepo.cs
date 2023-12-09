using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepo : IUser
    {
        DBContext _dBContext;
        public UserRepo()
        {
            _dBContext = new();
        }
        public List<NguoiDung> GetAll(string Search, string Type)
        {
            if (string.IsNullOrEmpty(Search) && (string.IsNullOrEmpty(Type)))
            {
                return _dBContext.NguoiDung.ToList();
            }
            else if(Type == "Tên")
            {
                return _dBContext.NguoiDung.Where(n => n.Ten.Contains(Search)).ToList();
            }
            else if(Type == "Quyền")
            {
                return _dBContext.NguoiDung.Where(n => n.Quyen.Contains(Search)).ToList();
            }
            else
            {
                return _dBContext.NguoiDung.ToList();
            }
    
            throw new NotImplementedException();
        }
        public NguoiDung Create(NguoiDung obj)
        {
            _dBContext.NguoiDung.Add(obj);
            _dBContext.SaveChanges();
            return obj;
        }
        public void Update(string TaiKhoan, NguoiDung obj)
        {
            var exobj = _dBContext.NguoiDung.FirstOrDefault(c => c.TaiKhoan == TaiKhoan);
            if (exobj != null)
            {
                exobj.Ten = obj.Ten;
                exobj.MatKhau = obj.MatKhau;
                exobj.DiaChi = obj.DiaChi;
                exobj.SDT = obj.SDT;
                exobj.NgaySinh = obj.NgaySinh;
                exobj.Email = obj.Email;
                exobj.Quyen = obj.Quyen;
            }
            _dBContext.NguoiDung.Update(exobj);
            _dBContext.SaveChanges();
        }
        public void Delete(string TaiKhoan)
        {
            var exobj = _dBContext.NguoiDung.FirstOrDefault(c => c.TaiKhoan == TaiKhoan);

            if (exobj != null)
            {
                _dBContext.NguoiDung.Remove(exobj);
                _dBContext.SaveChanges();
            }


        }
        public string GetRole(string TaiKhoan)
        {
            var exobj = _dBContext.NguoiDung.FirstOrDefault(c => c.TaiKhoan == TaiKhoan);
            if(exobj!= null)
            {
                return exobj.Quyen;
            }
            return null;
        }

        public bool Check(string TaiKhoan, string MatKhau)
        {

            var exobj = _dBContext.NguoiDung.FirstOrDefault(c => c.TaiKhoan == TaiKhoan);
            if (exobj!= null)
            {
                exobj.TaiKhoan = TaiKhoan;
                exobj.MatKhau = MatKhau;
                return true;
            }
            return false;
            throw new NotImplementedException();
        }

    }
}
